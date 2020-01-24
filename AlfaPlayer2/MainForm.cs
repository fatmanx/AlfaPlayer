

using NAudio.Dsp;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.WindowsMediaFormat;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AlfaPlayer2
{
    public partial class MainForm : Form
    {



        private byte[] FLAC_HEADER = new byte[] { 0x66, 0x4C, 0x61, 0x43, 0x00, 0x00, 0x00, 0x22 };

        private byte[] MP3_HEADER = new byte[] { 0x49, 0x44, 0x33 };

        private byte[] WMA_HEADER = new byte[] { 0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11, 0xA6, 0xD9, 0x00, 0xAA, 0x00, 0x62, 0xCE, 0x6C };






        private TagLib.File tag;

        private WaveOut waveOut;

        private float maxVolume = 0.5f;

        private DateTime lastSeekForward;

        private DateTime lastSeekBackward;

        private string lastFolder = @"F:\DATA\MUSIC\www.s-a-f.ro\music\";

        private string lastFile = @"F:\DATA\MUSIC\www.s-a-f.ro\music\07-the_smoke-upm.mp3";

        private double lastFilePos = 0;

        public MainForm()
        {

            InitializeComponent();

        }

        private enum FileType
        {
            None,
            FLAC,
            MP3,
            WMA
        }



        private void listBoxFilePanel_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            Rectangle r = e.Bounds;
            r.Offset(0, (int)((e.Bounds.Height - e.Font.Size) / 2) + listBoxFilePanel.PaddingTop);
            r.Width *= 10;
            Brush b = listBoxFilePanel.foreBrush;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {

                b = listBoxFilePanel.selectedItemForeBrush;
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          listBoxFilePanel.SelectedItemBackColor);//Choose the color
            }
            else
            {
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State,
                                          listBoxFilePanel.ForeColor,
                                          listBoxFilePanel.BackColor);//Choose the color

            }
            e.DrawBackground();



            var sss = listBoxFilePanel.Items[e.Index].ToString();
            if (sss.StartsWith(":"))
            {
                sss = "[" + sss.Substring(1) + "]";
                b = listBoxFilePanel.selectedSpecialItemForeBrush;
            }

            e.Graphics.DrawString(sss, e.Font, b, r, StringFormat.GenericDefault);
        }


        private FileType DetectFileType(string fn)
        {
            FileType ft = FileType.None;
            var rs = File.OpenRead(fn);
            byte[] buf = new byte[16];
            rs.Read(buf, 0, 16);
            if (Enumerable.SequenceEqual(buf.Take(16), WMA_HEADER))
            {
                ft = FileType.WMA;
            }
            else if (Enumerable.SequenceEqual(buf.Take(8), FLAC_HEADER))
            {
                ft = FileType.FLAC;
            }
            else if (Enumerable.SequenceEqual(buf.Take(3), MP3_HEADER))
            {
                ft = FileType.MP3;
            }

            if (ft == FileType.None)
            {
                switch (Path.GetExtension(fn).ToLowerInvariant())
                {
                    case ".mp3":
                        ft = FileType.MP3;
                        break;

                    case ".flac":
                        ft = FileType.FLAC;
                        break;

                    case ".wma":
                        ft = FileType.WMA;
                        break;
                }
            }

            return ft;
        }

        private void PlayNext()
        {
            PlayNextX();
        }
        private void PlayNextX(bool isReverse = false)
        {
            try
            {

                DirectoryInfo root = null;
                try
                {
                    root = new DirectoryInfo(Properties.Settings.Default.RootFolder);
                }
                catch { }


                FileInfo lfi = null;
                try
                {
                    lfi = new FileInfo(lastFile);
                }
                catch { }

                if (root == null || lfi == null || (lfi != null && !lfi.DirectoryName.Contains(root.FullName)))
                {
                    aboutBox.ShowDialog(this);
                    return;
                }


                var cFile = lfi.Name;
                var cDir = lfi.Directory.FullName;
                var fi = new FileInfo(cDir + Path.DirectorySeparatorChar + cFile);


                var files = Library.Instance.GetFiles();
                List<string> filez = new List<string>(files);
                filez.Sort();
                if (isReverse)
                {
                    filez.Reverse();
                }
                int idx = 0;
                bool found = false;
                foreach (var file in filez)
                {
                    if (file == fi.FullName)
                    {
                        if (idx < files.Length - 1)
                        {
                            var f = filez[idx + 1];
                            var ffile = new FileInfo(f);
                            //todo tbd
                            ChangeFolder(ffile.DirectoryName);
                            OpenFile(ffile.FullName);
                            found = true;
                        }
                        break;
                    }
                    idx++;
                }
                if (!found)
                {
                    var f = filez[0];
                    var ffile = new FileInfo(f);
                    ChangeFolder(ffile.DirectoryName);
                    OpenFile(ffile.FullName);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        private void PlayPrev()
        {
            PlayNextX(true);
            //if (listBoxFilePanel.SelectedIndex > 0)
            //{
            //    listBoxFilePanel.SelectedIndex--;
            //}
            //OpenFile(groupBox1.Tag.ToString() + Path.DirectorySeparatorChar + listBoxFilePanel.SelectedItem.ToString());
        }



        private AudioFileReader reader;
        private void OpenFile(string fn, double pos = 0)
        {
            Console.WriteLine(fn);

            if (!File.Exists(fn) || Directory.Exists(fn))
            {
                return;
            }

            Console.WriteLine("{0}  {1}", fn, DetectFileType(fn));

            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
            }
            if (reader != null)
            {
                reader.Close();
                //reader.Dispose();
            }




            var ft = DetectFileType(fn);
            if (ft == FileType.None)
            {
                return;
            }

            tag = TagLib.File.Create(fn);
            try
            {

                reader = new AudioFileReader(fn);
                ////////////var aggregator = new SampleAggregator(reader, FFT_POINTS);
                ////////////aggregator.NotificationCount = reader.WaveFormat.SampleRate / 10;

                ////////////aggregator.PerformFFT = true;
                ////////////aggregator.FftCalculated += Aggregator_FftCalculated;


                var aggregator = new SampleAggregatorDual(reader, FFT_POINTS);


                aggregator.PerformFFT = true;
                aggregator.FftCalculated += Aggregator_FftCalculated1;




                //sampleChannel = new SampleChannel(reader, true);
                //sampleChannel.PreVolumeMeter += SampleChannel_PreVolumeMeter;
                //var postVolumeMeter = new MeteringSampleProvider(sampleChannel);
                //postVolumeMeter.StreamVolume += PostVolumeMeter_StreamVolume;
                //postVolumeMeter.SamplesPerNotification = 64;
                //Console.WriteLine(postVolumeMeter.SamplesPerNotification);
                //switch (ft)
                //{
                //    case FileType.MP3:
                //        reader = new Mp3FileReader(fn);
                //        break;
                //    case FileType.FLAC:
                //        reader = new NAudio.Flac.FlacReader(fn);
                //        break;
                //    case FileType.WMA:
                //        reader = new WMAFileReader(fn);
                //        break;
                //}

                reader.CurrentTime = TimeSpan.FromSeconds(pos);

                lastFile = Path.GetFullPath(fn);
                listBoxFilePanel.SelectedItem = Path.GetFileName(fn);
                Console.WriteLine("reader.BlockAlign {0}", reader.BlockAlign);
                if (ft != FileType.None)
                {

                    //waveViewer1.WaveStream = reader2;

                    waveOut = new WaveOut(); // or WaveOutEvent()
                    waveOut.Init(aggregator, true);
                    waveOut.Play();


                    SaveSettings();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        private void Aggregator_FftCalculated1(object sender, FFTEventArgsDual e)
        {
            if (!IsSpectrumOn)
            {
                return;
            }

            Complex[] res = new Complex[e.Result0.Length];
            for (int i = 0; i < e.Result0.Length / 2; i++)
            {
                res[i] = e.Result0[i];
                res[e.Result0.Length - i - 1] = e.Result1[i];
            }


            setFFTRes(res);
        }

        private void Aggregator_FftCalculated(object sender, FftEventArgs e)
        {
            if (!IsSpectrumOn)
            {
                return;
            }

            setFFTRes(e.Result);

            return;
            //NAudio.Dsp.Complex[] result = e.Result;

            //if (pictureBox1.IsDisposed)
            //{
            //    return;
            //}
            //if (ggg == null)
            //{
            //    bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //    ggg = pictureBox1.CreateGraphics();
            //    ggg = Graphics.FromImage(bm);

            //}
            //int w = pictureBox1.Width;
            //int h = pictureBox1.Height;
            //float f = 10f;
            //ggg.Clear(Color.Transparent);
            ////pb1Graphics.DrawImage(cImage, 0, 0,w,h);

            //float pz0 = 0, pz1 = 0;

            //for (int i = 0; i < result.Length / 2; i++)
            //{
            //    var x0 = result[i].X;
            //    var y0 = result[i].Y;
            //    var z0 = f * w * (float)Math.Sqrt(x0 * x0 + y0 * y0);
            //    var x1 = result[result.Length - i - 1].X;
            //    var y1 = result[result.Length - i - 1].Y;
            //    var z1 = f * w * (float)Math.Sqrt(x1 * x1 + y1 * y1);

            //    ggg.DrawLine(p1, 2 * i, h / 2 - 1, 2 * i, h / 2 - 1 + z0);
            //    ggg.DrawLine(p2, 2 * i, h / 2 + 1, 2 * i, h / 2 + 1 - z1);
            //    ggg.DrawLine(pl1, 2 * i - 1, h / 2 - 1 + pz0, 2 * i + 1, h / 2 - 1 + z0);
            //    ggg.DrawLine(pl2, 2 * i - 1, h / 2 + 2 - pz1, 2 * i + 1, h / 2 + 2 - z1);

            //    pz0 = z0;
            //    pz1 = z1;

            //}

            //pictureBox1.Image = bm;

        }
        Pen pl1 = new Pen(Color.Red, 2);
        Pen p1 = new Pen(Color.DarkRed, 2);
        Pen pl2 = new Pen(Color.Lime, 2);
        Pen p2 = new Pen(Color.DarkGreen, 2);

        Graphics ggg;
        Bitmap bm;





        private void SeekForward()
        {
            if (reader != null)
            {
                try
                {
                    double s = 0.0005 * (100 + Math.Max(900, (DateTime.Now - lastSeekForward).TotalMilliseconds));
                    waveOut.Volume = 0.05f * maxVolume;
                    reader.CurrentTime += TimeSpan.FromSeconds(1 / s);
                }
                catch (Exception) { }
            }
            lastSeekForward = DateTime.Now;
        }
        private void SeekBackward()
        {
            if (reader != null)
            {
                try
                {
                    double s = 0.0005 * (100 + Math.Max(900, (DateTime.Now - lastSeekBackward).TotalMilliseconds));
                    waveOut.Volume = 0.05f * maxVolume;
                    reader.CurrentTime += TimeSpan.FromSeconds(-1 / s);
                }
                catch (Exception) { }
            }
            lastSeekBackward = DateTime.Now;
        }

        private void SeekToSecond(double seconds)
        {
            if (reader != null)
            {
                try
                {
                    waveOut.Volume = 0.05f * maxVolume;
                    reader.CurrentTime = TimeSpan.FromSeconds(seconds);
                }
                catch (Exception) { }
            }
        }
        private void SaveSettings()
        {
            Console.WriteLine("SAVING");
            Properties.Settings.Default.LastFile = lastFile;
            Properties.Settings.Default.LastFilePos = lastFilePos;
            Properties.Settings.Default.MaxVolume = maxVolume;
            Properties.Settings.Default.Save();
        }

        //string extensions = "*.mp3|*.wav|*.flac";






        //string extensionFilter = "";
        private void MainForm_Load(object sender, EventArgs e)
        {

            aboutBox = new AboutBox { ParentForm = this };
            //extensionFilter = "*" + string.Join("|*", extensions);
            //Console.WriteLine("------------------------------------");
            //var di = new DirectoryInfo(".");
            //var files = getFiles(".", extensions, SearchOption.AllDirectories);
            //foreach(var file in files)
            //{
            //    Console.WriteLine("*** {0}", file);
            //}

            if (Screen.PrimaryScreen.WorkingArea.Height < 1024)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            Util.DoUpgrade(Properties.Settings.Default);
            lastFolder = Properties.Settings.Default.LastFolder;
            lastFile = Properties.Settings.Default.LastFile;
            lastFilePos = Properties.Settings.Default.LastFilePos;
            maxVolume = Properties.Settings.Default.MaxVolume;
            IsSpectrumOn = Properties.Settings.Default.IsSpectrumOn;


            InitFilePanel();
            if (File.Exists(lastFile))
            {
                ChangeFolder(Path.GetDirectoryName(lastFile));
                OpenFile(lastFile, lastFilePos);
                SeekToSecond(lastFilePos);
            }
            else
            {
                if (string.IsNullOrEmpty(Properties.Settings.Default.RootFolder))
                {
                    aboutBox.ShowDialog(this);
                }
                ChangeFolder(Properties.Settings.Default.RootFolder);
            }

            listBoxFilePanel.Select();
            timerPlayer.Enabled = true;

            if (isEEE701())
            {
                //TopMost = true;

            }

            backgroundWorker1.RunWorkerAsync();



        }




        private void InitFilePanel()
        {
            if (File.Exists(lastFile))
            {
                ChangeFolder(Path.GetDirectoryName(lastFile));
            }
            else if (Directory.Exists(lastFolder))
            {
                ChangeFolder(lastFolder);
            }
            else
            {
                ChangeFolder(".");
            }
        }

        //string[] extensions = { ".mp3", ".flac", ".wma", ".wav", ".aac" };

        private void ChangeFolder(string folder, string sourceFolderName = null)
        {
            try
            {
                folder = Path.GetFullPath(folder);
                Console.WriteLine("Change folder -> {0}", folder);
                List<string> dirs = new List<string>(Directory.GetDirectories(folder).Select(f => { f = ":" + f.Substring(f.LastIndexOf(Path.DirectorySeparatorChar) + 1); return f; }).ToArray());
                dirs.Sort();


                List<string> files = new List<string>(Directory.GetFiles(folder, "*.*")
                    .Where(f => Library.Instance.extensions.Contains(System.IO.Path.GetExtension(f).ToLower())).Select(f => { f = f.Substring(f.LastIndexOf(Path.DirectorySeparatorChar) + 1); return f; }).ToArray());

                dirs.Insert(0, @":..");
                dirs.AddRange(files);

                listBoxFilePanel.DataSource = dirs;
                listBoxFilePanel.Tag = folder;

                SetFolderLabel(folder, files.Count);


                if (!string.IsNullOrEmpty(sourceFolderName))
                {
                    listBoxFilePanel.SelectedItem = ":" + sourceFolderName;
                }


                Properties.Settings.Default.LastFolder = folder;
                Properties.Settings.Default.Save();



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SetFolderLabel(string folder, int? itemsCount = null)
        {
            label1.Text = groupBox1.Text = string.Format("{0} - ({1})", folder, itemsCount);
            groupBox1.Tag = folder;
            return;
            //int max = 40;
            //if (folder.Length > max)
            //{
            //    int dif = folder.Length - max;
            //    Console.WriteLine("{0}  {1} {2}", folder.Length, max, dif);
            //    //folder = folder.Substring(0, folder.Length / 2 - dif / 2) + "..." + folder.Substring(folder.Length / 2 + dif / 2);
            //    folder = "..." + folder.Reverse().Substring(0, max).Reverse();
            //}
            //label1.Text = groupBox1.Text = folder;
        }

        void OpenFileOrDirectory()
        {
            var dir = groupBox1.Tag.ToString();
            var sel = listBoxFilePanel.SelectedItem.ToString();

            if (sel.StartsWith(":"))
            {
                var newDir = dir + Path.DirectorySeparatorChar + sel.Substring(1);
                if (Directory.Exists(newDir))
                {
                    DirectoryInfo di = new DirectoryInfo(newDir);
                    var rootFolder = Properties.Settings.Default.RootFolder;
                    if (di.FullName.Contains(rootFolder))
                    {
                        ChangeFolder(newDir, new DirectoryInfo(dir).Name);
                    }
                }
            }
            else
            {
                OpenFile(dir + Path.DirectorySeparatorChar + listBoxFilePanel.SelectedItem.ToString());
            }

        }

        private void listBoxFilePanel_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)
            {
                OpenFileOrDirectory();
            }
            else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left/* || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown*/)
            {
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F1)
            {
                aboutBox.ShowDialog(this);
            }
        }

        AboutBox aboutBox;

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine(e.KeyCode);

            switch (e.KeyCode)
            {
                case Keys.Left:
                    SeekBackward();
                    break;

                case Keys.Right:
                    SeekForward();
                    break;

                case Keys.N:
                case Keys.MediaNextTrack:
                    PlayNext();
                    break;

                case Keys.Z:
                case Keys.MediaPreviousTrack:
                    PlayPrev();
                    break;

                case Keys.MediaStop:
                    Stop();
                    break;

                case Keys.MediaPlayPause:
                case Keys.Space:
                    PlayPause();
                    break;


                case Keys.BrowserBack:
                    ChangeFolder(groupBox1.Tag.ToString() + Path.DirectorySeparatorChar + "..", new DirectoryInfo(groupBox1.Tag.ToString()).Name);
                    break;
                case Keys.Escape:
                    if (lastSpacePress == DateTime.MinValue)
                    {
                        lastSpacePress = DateTime.Now;
                    }
                    break;
                case Keys.Q:
                    if (lastQPress == DateTime.MinValue)
                    {
                        lastQPress = DateTime.Now;
                    }
                    break;

                case Keys.VolumeUp:
                case Keys.PageUp:
                    MasterVolume(1000);
                    break;
                case Keys.VolumeDown:
                case Keys.PageDown:
                    MasterVolume(-1000);
                    break;
            }
        }


        void MasterVolume(int val = 1000)
        {
            Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "/nircmd.exe", " changesysvolume " + val);
        }

        DateTime lastSpacePress = DateTime.MinValue;
        DateTime lastQPress = DateTime.MinValue;
        TimeSpan sleepTime = TimeSpan.FromSeconds(2);
        TimeSpan hibernateTime = TimeSpan.FromSeconds(5);


        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (lastSpacePress > DateTime.MinValue && DateTime.Now - lastSpacePress > sleepTime && DateTime.Now - lastSpacePress < hibernateTime)
                    {
                        Sleep();
                    }
                    if (lastSpacePress > DateTime.MinValue && DateTime.Now - lastSpacePress > hibernateTime)
                    {
                        //Hibernate();
                    }
                    lastSpacePress = DateTime.MinValue;
                    break;

                case Keys.Q:
                    if (lastQPress > DateTime.MinValue && DateTime.Now - lastQPress > TimeSpan.FromSeconds(2))
                    {
                        Application.Exit();

                    }
                    lastQPress = DateTime.MinValue;
                    break;
            }
        }

        bool isEEE701()
        {
            return true;
            return Environment.ProcessorCount == 1;
        }

        void Sleep()
        {
            Console.WriteLine("---------------------------------------------------SLEEP NOW");
            if (isEEE701())
            {
                Application.SetSuspendState(PowerState.Suspend, false, true);
            }

        }

        void Hibernate()
        {
            Console.WriteLine("---------------------------------------------------HIBERNATE NOW");
            if (isEEE701())
            {
                Application.SetSuspendState(PowerState.Hibernate, false, true);
            }

        }

        private void Stop()
        {
            if (reader != null)
            {
                try
                {
                    switch (waveOut.PlaybackState)
                    {
                        case PlaybackState.Playing:
                            waveOut.Stop();
                            break;

                        case PlaybackState.Paused:
                            waveOut.Stop();
                            break;
                    }
                }
                catch (Exception) { }
            }
        }



        private void PlayPause()
        {
            if (reader != null)
            {
                try
                {
                    switch (waveOut.PlaybackState)
                    {
                        case PlaybackState.Playing:
                            waveOut.Pause();
                            break;

                        case PlaybackState.Paused:
                            waveOut.Play();
                            break;

                        case PlaybackState.Stopped:
                            waveOut.Play();
                            break;
                    }
                }
                catch (Exception) { }
            }
        }

        private void textProgressBar_MouseClick(object sender, MouseEventArgs e)
        {
            float pos = ((float)e.X / (textProgressBar.Width - textProgressBar.Padding.Left - textProgressBar.Padding.Right)).Clamp(0, 0.999f);

            Console.WriteLine(">>> pos {0}", pos);

            if (reader != null && reader.CanSeek)
            {
                try
                {
                    reader.Seek((long)(pos * reader.Length), System.IO.SeekOrigin.Begin);
                }
                catch (Exception) { }
            }
        }


        private TagLib.File lastTag;
        //Bitmap cImage = null;


        private void SetTagImage()
        {
            if (tag != null)
            {
                if (tag.Tag.Pictures.Length > 0)
                {
                    MemoryStream mStream = new MemoryStream();
                    byte[] pData = tag.Tag.Pictures[0].Data.Data;
                    //Console.WriteLine(tag.Tag.Pictures[0].Data.Checksum);
                    mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                    Bitmap bm = new Bitmap(mStream, false);
                    mStream.Dispose();
                    //cImage = Blur(Blur(Blur(bm)));
                    pictureBox1.Image = bm;
                }
                else
                {
                    //cImage = Blur(Blur(Blur((Bitmap)pictureBox1.InitialImage)));
                    pictureBox1.Image = pictureBox1.InitialImage;
                }
            }
            else
            {
                //cImage = Blur(Blur(Blur((Bitmap)pictureBox1.InitialImage)));
                pictureBox1.Image = pictureBox1.InitialImage;
            }

        }

        private void timerPlayer_Tick(object sender, EventArgs e)
        {
            if (reader != null)
            {



                //Console.WriteLine(reader.Position);

                //FastFourierTransform.FFT(true,2,reader.)


                textProgressBar.Value = (int)(textProgressBar.MaximumValue * reader.Position / reader.Length);
                lastFilePos = reader.CurrentTime.TotalSeconds;

                var ct = reader.CurrentTime.TotalSeconds;
                var tt = reader.TotalTime.TotalSeconds;

                textProgressBar.ProgressText = string.Format("{0:00}:{1:00} / {2:00}:{3:00}", (int)ct / 60, ct % 60, (int)tt / 60, tt % 60);
                if (tag != null)
                {
                    if (lastTag != tag)
                    {
                        lastTag = tag;
                        //Console.WriteLine(tag.Tag.Pictures[0]);
                        SetTagImage();

                        string tit = "";
                        if (!string.IsNullOrEmpty(tag.Tag.Title))
                        {
                            if (tag.Tag.Artists.Length > 0)
                            {
                                tit = string.Format("{0} - {1}", tag.Tag.Artists[0], tag.Tag.Title);
                            }
                            else
                            if (tag.Tag.AlbumArtists.Length > 0)
                            {
                                tit = string.Format("{0} - {1}", tag.Tag.AlbumArtists[0], tag.Tag.Title);
                            }
                            else
                            {
                                tit = tag.Tag.Title;
                            }

                        }
                        else
                        {
                            tit = string.Format("{0}", Path.GetFileName(tag.Name));
                        }

                        if (labelSongTitle.Text != tit)
                        {
                            labelSongTitle.Text = tit;
                        }

                        if (labelSongInfo.Text != tag.Tag.Album)
                        {
                            labelSongInfo.Text = tag.Tag.Album;
                        }
                    }


                }
                else
                {
                    //cImage = Blur(Blur(Blur((Bitmap)pictureBox1.InitialImage)));
                    pictureBox1.Image = pictureBox1.InitialImage;
                }
                if (waveOut != null)
                {
                    //Console.WriteLine(">>> {0}", reader.TotalTime.TotalMilliseconds - reader.CurrentTime.TotalMilliseconds);
                    if (waveOut.PlaybackState == PlaybackState.Playing && reader.TotalTime.TotalMilliseconds - reader.CurrentTime.TotalMilliseconds < 300)
                    {
                        Console.WriteLine("Next");

                        PlayNext();
                    }
                    if (waveOut.Volume < maxVolume)
                        waveOut.Volume += (maxVolume - waveOut.Volume) * 0.1f;
                }
            }


            //SetBatteryColor();

            PowerLine = SystemInformation.PowerStatus.PowerLineStatus;

            if (!Focused && !aboutBox.Visible)
            {
                //todo reactivate
                //Activate();
                listBoxFilePanel.Focus();
            }

        }


        private PowerLineStatus __PowerLine = SystemInformation.PowerStatus.PowerLineStatus;

        public PowerLineStatus PowerLine
        {
            get { return __PowerLine; }
            set
            {

                if (value != PowerLineStatus.Online && value != __PowerLine)
                {
                    timerHibernate.Enabled = true;
                    lastPowerDownTime = DateTime.Now;
                }
                __PowerLine = value;
            }
        }

        DateTime lastPowerDownTime = DateTime.MaxValue;
        private void timerHibernate_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now - lastPowerDownTime > TimeSpan.FromSeconds(10))
            {
                lastPowerDownTime = DateTime.MaxValue;
                Hibernate();
                timerHibernate.Enabled = false;
            }
        }


        void SetBatteryColor()
        {
            float battery = SystemInformation.PowerStatus.BatteryLifePercent;

            var br = Properties.Settings.Default.OnBatteryColor.R;
            var bg = Properties.Settings.Default.OnBatteryColor.G;
            var bb = Properties.Settings.Default.OnBatteryColor.B;


            var ar = Properties.Settings.Default.OnACColor.R;
            var ag = Properties.Settings.Default.OnACColor.G;
            var ab = Properties.Settings.Default.OnACColor.B;




            int r = (int)(br - (br - ar) * battery);
            int g = (int)(bg - (bg - ag) * battery);
            int b = (int)(bb - (bb - ab) * battery);

            Color cc = Color.FromArgb(r, g, b);


            //verticalProgressBar1.Value = (int)(100 * battery);
            //if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)
            //{
            //    verticalProgressBar1.FillColor = Properties.Settings.Default.OnACColor;
            //}
            //else
            //{
            //    verticalProgressBar1.FillColor = cc;
            //}

        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        float[] lfd = new float[FFT_POINTS];
        float[] cfd = new float[FFT_POINTS];
        int fftStep = 0;
        const int FFT_POINTS = 512;

        bool IsPlaying()
        {

            return waveOut != null && waveOut.PlaybackState == PlaybackState.Playing;

        }

        const int FFT_STEP_COUNT = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw2();
        }
        void Draw2()
        {

            if (!IsSpectrumOn || !IsPlaying() || pictureBox1.IsDisposed)
            {
                return;
            }

            for (int i = 0; i < FFT_POINTS; i++)
            {
                ccc[i] = (ccc[i] + nnn[i]) / 1.3f;
            }

            if (ggg == null)
            {
                bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                ggg = pictureBox1.CreateGraphics();
                ggg = Graphics.FromImage(bm);

            }
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            int midh = h / 2;
            float f = .75f;
            ggg.Clear(Color.Transparent);



            float d = 1.5f;
            List<PointF> pp0 = new List<PointF>();
            List<PointF> pp1 = new List<PointF>();

            //pp0.Add(new PointF(0, h / 2 + d));
            //pp1.Add(new PointF(0, h / 2 - d));

            int fftp2 = FFT_POINTS / 2;
            float wf = .5f * pictureBox1.Width / fftp2;

            for (int i = 0; i < fftp2; i++)
            {
                int ii = i * 2;
                int j = FFT_POINTS - i - 1;
                //Console.WriteLine("{0} {1}", i, j);
                float c0y0 = f * ccc[i] * (float)Math.Log(i / 2.5f + 1);
                float c1y0 = -f * ccc[j] * (float)Math.Log(i / 2.5f + 1);

                pp0.Add(new PointF(ii * wf, d + midh + c0y0));
                pp1.Add(new PointF(ii * wf, -d + midh + c1y0));
            }




            pp0.Add(new PointF(0, midh + d));
            pp1.Add(new PointF(0, midh - d));

            ggg.SmoothingMode = SmoothingMode.AntiAlias;
            ggg.InterpolationMode = InterpolationMode.HighQualityBicubic;
            ggg.DrawLines(penRed2, pp0.ToArray());
            ggg.DrawLines(penGreen2, pp1.ToArray());
            ggg.FillPolygon(brFillRed, pp0.ToArray());
            ggg.FillPolygon(brFillGreen, pp1.ToArray());
            ggg.DrawLines(penRed, pp0.ToArray());
            ggg.DrawLines(penGreen, pp1.ToArray());



            pictureBox1.Image = bm;

        }

        Brush brFillRed = Brushes.DarkMagenta;
        Brush brFillGreen = Brushes.DarkCyan;

        Pen penRed = Pens.Magenta;
        Pen penGreen = Pens.Cyan;
        Pen penRed2 = new Pen(Color.FromArgb(100, 255, 0, 255), 3);
        Pen penGreen2 = new Pen(Color.FromArgb(100, 0, 255, 255), 3);


        void Draw1()
        {
            if (!IsSpectrumOn || !IsPlaying() || pictureBox1.IsDisposed)
            {
                return;
            }

            if (fftStep++ > FFT_STEP_COUNT)
            {
                fftStep = 0;
            }
            if (fftData.Count > 0)
            {

                if (fftData.Count > 100)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        fftData.Dequeue();
                    }
                }

                lfd = cfd;
                cfd = fftData.Dequeue();
                Console.WriteLine(fftData.Count);
            }

            float ss = (float)fftStep / FFT_STEP_COUNT;


            if (ggg == null)
            {
                bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                ggg = pictureBox1.CreateGraphics();
                ggg = Graphics.FromImage(bm);

            }
            int w = pictureBox1.Width;
            int h = pictureBox1.Height;
            int midh = h / 2;
            float f = 5f;
            ggg.Clear(Color.Transparent);



            float d = 1.5f;
            List<PointF> pp0 = new List<PointF>();
            List<PointF> pp1 = new List<PointF>();

            //pp0.Add(new PointF(0, h / 2 + d));
            //pp1.Add(new PointF(0, h / 2 - d));

            for (int i = 1; i < FFT_POINTS / 2; i++)
            {
                int ii = i * 2;
                int j = FFT_POINTS / 2 + i - 1;

                float lfdi = lfd[i];
                float cfdi = cfd[i];

                float lfdj = lfd[j];
                float cfdj = cfd[j];


                float c0y0 = ss * f * lfdi + f * ss * (cfdi - lfdi);
                float c1y0 = -ss * f * lfdj - f * ss * (cfdj - lfdj);

                pp0.Add(new PointF(ii, d + midh + c0y0));
                pp1.Add(new PointF(w - ii, -d + midh + c1y0));
                if (c0y0 < 0)
                {
                    Console.WriteLine(c0y0);
                }

            }

            pp0.Add(new PointF(0, midh + d));
            pp1.Add(new PointF(0, midh - d));

            ggg.FillPolygon(Brushes.DarkRed, pp0.ToArray());
            ggg.FillPolygon(Brushes.DarkGreen, pp1.ToArray());
            ggg.DrawLines(Pens.Red, pp0.ToArray());
            ggg.DrawLines(Pens.Green, pp1.ToArray());


            pictureBox1.Image = bm;
        }


        Queue<float[]> fftData = new Queue<float[]>();
        float[] ccc = new float[FFT_POINTS];
        float[] nnn = new float[FFT_POINTS];

        int fftQueueCount = 0;
        void setFFTRes(Complex[] complex)
        {
            //if (fftData.Count > 10)
            //{
            //    fftData.Clear();
            //}
            //if (fftQueueCount++ > 0)
            //{
            //    fftQueueCount = 0;
            //    float[] data = new float[FFT_POINTS];
            //    for (int i = 0; i < complex.Length; i++)
            //    {
            //        data[i] = 1000 * (float)Math.Sqrt(complex[i].X * complex[i].X + complex[i].Y * complex[i].Y);
            //    }
            //    fftData.Enqueue(data);
            //}




            nnn = new float[FFT_POINTS];
            for (int i = 0; i < complex.Length; i++)
            {
                nnn[i] = 1000 * (float)Math.Sqrt(complex[i].X * complex[i].X + complex[i].Y * complex[i].Y);

            }


        }

        private bool isSpectrumOn = false;

        public bool IsSpectrumOn
        {
            get { return isSpectrumOn; }
            set
            {
                isSpectrumOn = value;
                Properties.Settings.Default.IsSpectrumOn = value;
                SaveSettings();
                if (!IsSpectrumOn)
                {
                    SetTagImage();
                    panel5.Width = 281;
                }
                else
                {
                    panel5.Width = Width;
                }

            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            IsSpectrumOn = !IsSpectrumOn;
        }

        private void listBoxFilePanel_DoubleClick(object sender, EventArgs e)
        {
            OpenFileOrDirectory();
        }



        #region file list drag
        int startY = 0;

        private void listBoxFilePanel_MouseDown(object sender, MouseEventArgs e)
        {
            startY = e.Y;
            Console.WriteLine("e.Y {0}", e.Y);
        }

        private void listBoxFilePanel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void listBoxFilePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (Math.Abs(e.Y - startY) > 50)
            {
                if (e.Y > startY)
                {
                    if (listBoxFilePanel.SelectedIndex < listBoxFilePanel.Items.Count - 1)
                    {
                        listBoxFilePanel.SelectedIndex = Math.Min(listBoxFilePanel.Items.Count - 1, listBoxFilePanel.SelectedIndex + (int)(listBoxFilePanel.Height / listBoxFilePanel.ItemHeight));
                    }
                }
                else
                {
                    if (listBoxFilePanel.SelectedIndex > 0)
                    {
                        listBoxFilePanel.SelectedIndex = Math.Max(0, listBoxFilePanel.SelectedIndex - (int)(listBoxFilePanel.Height / listBoxFilePanel.ItemHeight));
                    }
                }
            }
        }

        #endregion file list drag

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("DONE");
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Console.WriteLine("WORK");
            Library.Instance.RefreshLibrary();
        }

        private void listBoxFilePanel_Click(object sender, EventArgs e)
        {
            //OpenFileOrDirectory();
        }

        private void listBoxFilePanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < 100) OpenFileOrDirectory();
            //Console.WriteLine("{0}  {1}", sender, e.X);
        }
    }
}