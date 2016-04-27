using NAudio.Wave;
using NAudio.WindowsMediaFormat;

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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



        private WaveStream reader;

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
            r.Offset(0, (int)((e.Bounds.Height - e.Font.Size) / 2));
            r.Width *= 10;
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          listBoxFilePanel.SelectedItemBackColor);//Choose the color

            e.DrawBackground();

            Brush b = listBoxFilePanel.selectedItemForeBrush;

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
            if (listBoxFilePanel.SelectedIndex < listBoxFilePanel.Items.Count - 1)
            {
                listBoxFilePanel.SelectedIndex++;
                OpenFile(groupBox1.Tag.ToString() + Path.DirectorySeparatorChar + listBoxFilePanel.SelectedItem.ToString());
            }
        }

        private void PlayPrev()
        {
            if (listBoxFilePanel.SelectedIndex > 0)
            {
                listBoxFilePanel.SelectedIndex--;
            }
            OpenFile(groupBox1.Tag.ToString() + Path.DirectorySeparatorChar + listBoxFilePanel.SelectedItem.ToString());
        }
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
                reader.Dispose();
            }

            var ft = DetectFileType(fn);
            if (ft == FileType.None)
            {
                return;
            }

            tag = TagLib.File.Create(fn);
            try
            {
                switch (ft)
                {
                    case FileType.MP3:
                        reader = new Mp3FileReader(fn);
                        break;

                    case FileType.FLAC:
                        reader = new NAudio.Flac.FlacReader(fn);
                        break;

                    case FileType.WMA:
                        reader = new WMAFileReader(fn);
                        break;
                }
                reader.CurrentTime = TimeSpan.FromSeconds(pos);
                lastFile = Path.GetFullPath(fn);
                listBoxFilePanel.SelectedItem = Path.GetFileName(fn);
                Console.WriteLine("reader.BlockAlign {0}", reader.BlockAlign);
                if (ft != FileType.None)
                {
                    waveOut = new WaveOut(); // or WaveOutEvent()
                    waveOut.Init(reader);
                    waveOut.Play();
                    SaveSettings();
                }
            }
            catch { }
        }
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Screen.PrimaryScreen.WorkingArea.Height < 1024)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            Util.DoUpgrade(Properties.Settings.Default);
            lastFolder = Properties.Settings.Default.LastFolder;
            lastFile = Properties.Settings.Default.LastFile;
            lastFilePos = Properties.Settings.Default.LastFilePos;
            maxVolume = Properties.Settings.Default.MaxVolume;

            InitFilePanel();
            if (File.Exists(lastFile))
            {
                ChangeFolder(Path.GetDirectoryName(lastFile));
                OpenFile(lastFile, lastFilePos);
                SeekToSecond(lastFilePos);
            }
            listBoxFilePanel.Select();
            timerPlayer.Enabled = true;

            if (isEEE701())
            {
                TopMost = true;

            }
            aboutBox = new AboutBox { ParentForm = this };
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

        private void ChangeFolder(string folder)
        {
            try
            {
                folder = Path.GetFullPath(folder);
                Console.WriteLine("Change folder -> {0}", folder);
                List<string> dirs = new List<string>(Directory.GetDirectories(folder).Select(f => { f = ":" + f.Substring(f.LastIndexOf(Path.DirectorySeparatorChar) + 1); return f; }).ToArray());
                string[] extensions = { ".mp3", ".flac", ".wma" };

                List<string> files = new List<string>(Directory.GetFiles(folder, "*.*")
                    .Where(f => extensions.Contains(System.IO.Path.GetExtension(f).ToLower())).Select(f => { f = f.Substring(f.LastIndexOf(Path.DirectorySeparatorChar) + 1); return f; }).ToArray());

                dirs.Insert(0, @":..");
                dirs.AddRange(files);

                listBoxFilePanel.DataSource = dirs;

                SetFolderLabel(folder);
                Properties.Settings.Default.LastFolder = folder;
                Properties.Settings.Default.Save();
            }
            catch (Exception) { }
        }

        private void SetFolderLabel(string folder)
        {
            groupBox1.Tag = folder;
            int max = 25;
            if (folder.Length > max)
            {
                int dif = folder.Length - max;
                Console.WriteLine("{0}  {1} {2}", folder.Length, max, dif);
                folder = folder.Substring(0, folder.Length / 2 - dif / 2) + "..." + folder.Substring(folder.Length / 2 + dif / 2);
            }

            groupBox1.Text = folder;
        }

        private void listBoxFilePanel_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)
            {
                var sel = listBoxFilePanel.SelectedItem.ToString();
                if (sel.StartsWith(":"))
                {
                    ChangeFolder(groupBox1.Tag.ToString() + Path.DirectorySeparatorChar + sel.Substring(1));
                }
                else
                {
                    OpenFile(groupBox1.Tag.ToString() + Path.DirectorySeparatorChar + listBoxFilePanel.SelectedItem.ToString());
                }
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

                case Keys.MediaNextTrack:
                    PlayNext();
                    break;

                case Keys.MediaPreviousTrack:
                    PlayPrev();
                    break;

                case Keys.MediaStop:
                    Stop();
                    break;

                case Keys.MediaPlayPause:
                    PlayPause();
                    break;

                case Keys.BrowserBack:
                    ChangeFolder(groupBox1.Tag.ToString() + Path.DirectorySeparatorChar + "..");
                    break;
                case Keys.Space:
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
            }
        }

        DateTime lastSpacePress = DateTime.MinValue;
        DateTime lastQPress = DateTime.MinValue;
        TimeSpan sleepTime = TimeSpan.FromSeconds(2);
        TimeSpan hibernateTime = TimeSpan.FromSeconds(5);

        
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (lastSpacePress > DateTime.MinValue && DateTime.Now - lastSpacePress > sleepTime && DateTime.Now - lastSpacePress < hibernateTime)
                    {
                        Sleep();
                    }
                    if (lastSpacePress > DateTime.MinValue && DateTime.Now - lastSpacePress > hibernateTime)
                    {
                        Hibernate();
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

            Console.WriteLine(pos);

            if (reader != null && reader.CanSeek)
            {
                try
                {
                    reader.Seek((long)(pos * reader.Length), System.IO.SeekOrigin.Begin);
                }
                catch (Exception) { }
            }
        }

        private void timerPlayer_Tick(object sender, EventArgs e)
        {
            if (reader != null)
            {
                //Console.WriteLine(reader.Position);

                textProgressBar.Value = (int)(textProgressBar.MaximumValue * reader.Position / reader.Length);
                lastFilePos = reader.CurrentTime.TotalSeconds;

                var ct = reader.CurrentTime.TotalSeconds;
                var tt = reader.TotalTime.TotalSeconds;

                textProgressBar.ProgressText = string.Format("{0:00}:{1:00} / {2:00}:{3:00}", (int)ct / 60, ct % 60, (int)tt / 60, tt % 60);
                if (tag != null)
                {
                    string tit = "";
                    if (!string.IsNullOrEmpty(tag.Tag.Title))
                    {

                        if (tag.Tag.AlbumArtists.Length > 0)
                        {
                            tit = string.Format("{1} ({0})", tag.Tag.AlbumArtists[0], tag.Tag.Title);
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


            SetBatteryColor();

            PowerLine = SystemInformation.PowerStatus.PowerLineStatus;

            if (!Focused && !aboutBox.Visible)
            {
                Activate();
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


            verticalProgressBar1.Value = (int)(100 * battery);
            if (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Online)
            {
                verticalProgressBar1.FillColor = Properties.Settings.Default.OnACColor;
            }
            else
            {
                verticalProgressBar1.FillColor = cc;
            }

        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

       
    }
}