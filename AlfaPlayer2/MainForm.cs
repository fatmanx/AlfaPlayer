using NAudio.Wave;
using NAudio.WindowsMediaFormat;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace AlfaPlayer2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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

        private byte[] FLAC_HEADER = new byte[] { 0x66, 0x4C, 0x61, 0x43, 0x00, 0x00, 0x00, 0x22 };
        private byte[] MP3_HEADER = new byte[] { 0x49, 0x44, 0x33 };
        private byte[] WMA_HEADER = new byte[] { 0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11, 0xA6, 0xD9, 0x00, 0xAA, 0x00, 0x62, 0xCE, 0x6C };

        private enum FileType
        {
            None,
            FLAC,
            MP3,
            WMA
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

        private int scrollPos = 0;


        private WaveStream reader;
        private TagLib.File tag;
        private WaveOut waveOut;

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
                    scrollPos = 0;
                    waveOut = new WaveOut(); // or WaveOutEvent()
                    waveOut.Init(reader);
                    waveOut.Play();
                    SaveSettings();
                }
            }
            catch { }
        }
        private float maxVolume = 0.5f;

        private DateTime lastSeekForward;

        private void SeekForward()
        {
            if (reader != null)
            {
                try
                {
                    double s = 0.0005 * (100 + Math.Max(900, (DateTime.Now - lastSeekForward).TotalMilliseconds));
                    waveOut.Volume = 0.1f * maxVolume;
                    reader.CurrentTime += TimeSpan.FromSeconds(1 / s);
                }
                catch (Exception) { }
            }
            lastSeekForward = DateTime.Now;
        }

        private DateTime lastSeekBackward;

        private void SeekBackward()
        {
            if (reader != null)
            {
                try
                {
                    double s = 0.0005 * (100 + Math.Max(900, (DateTime.Now - lastSeekBackward).TotalMilliseconds));
                    waveOut.Volume = 0.1f * maxVolume;
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
                    waveOut.Volume = 0.1f * maxVolume;
                    reader.CurrentTime = TimeSpan.FromSeconds(seconds);
                }
                catch (Exception) { }
            }
        }

        private string lastFolder = @"F:\DATA\MUSIC\www.s-a-f.ro\music\";
        private string lastFile = @"F:\DATA\MUSIC\www.s-a-f.ro\music\07-the_smoke-upm.mp3";
        private double lastFilePos = 0;


        void SaveSettings()
        {
            Console.WriteLine("SAVING");
            Properties.Settings.Default.LastFile = lastFile;
            Properties.Settings.Default.LastFilePos = lastFilePos;
            Properties.Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelBatteryInfo.BackColor = Properties.Settings.Default.BackgroundColor;
            //Properties.Settings.Default.Upgrade();
            lastFolder = Properties.Settings.Default.LastFolder;
            lastFile = Properties.Settings.Default.LastFile;
            lastFilePos = Properties.Settings.Default.LastFilePos;
            maxVolume = Properties.Settings.Default.MaxVolume;

            InitFilePanel();
            ChangeFolder(Path.GetDirectoryName(lastFile));
            OpenFile(lastFile, lastFilePos);
            SeekToSecond(lastFilePos);
            listBoxFilePanel.Select();
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
            int max = 50;
            if (folder.Length > max)
            {
                int dif = folder.Length - max;
                Console.WriteLine("{0}  {1} {2}", folder.Length, max, dif);
                folder = folder.Substring(0, folder.Length / 2 - dif / 2) + "..." + folder.Substring(folder.Length / 2 + dif / 2);
            }

            groupBox1.Text = folder;
        }
    }
}
