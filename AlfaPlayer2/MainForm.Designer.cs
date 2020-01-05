namespace AlfaPlayer2
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listBoxFilePanel = new AlfaPlayer.CListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerPlayer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.textProgressBar = new AlfaPlayer.TextProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelSongTitle = new AlfaPlayer2.ScrollLabel();
            this.labelSongInfo = new AlfaPlayer2.ScrollLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new AlfaPlayer2.ScrollLabel();
            this.timerHibernate = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textProgressBar2 = new AlfaPlayer.TextProgressBar();
            this.textProgressBar1 = new AlfaPlayer.TextProgressBar();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelFolderTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Exo 2 Extra Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelFolderTextColor;
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox1.Size = new System.Drawing.Size(784, 290);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.Text = "Alfa Player";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.listBoxFilePanel);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(5, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(774, 284);
            this.panel4.TabIndex = 3;
            // 
            // listBoxFilePanel
            // 
            this.listBoxFilePanel.BackColor = global::AlfaPlayer2.Properties.Settings.Default.BackgroundColor;
            this.listBoxFilePanel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxFilePanel.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "BackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listBoxFilePanel.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listBoxFilePanel.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItemBackColor", global::AlfaPlayer2.Properties.Settings.Default, "SelectedItemBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listBoxFilePanel.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItemForeColor", global::AlfaPlayer2.Properties.Settings.Default, "SelectedItemForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listBoxFilePanel.DataBindings.Add(new System.Windows.Forms.Binding("SelectedSpecialItemForeColor", global::AlfaPlayer2.Properties.Settings.Default, "SelectedSpecialItemForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listBoxFilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFilePanel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxFilePanel.Font = new System.Drawing.Font("Exo 2 Extra Light", 17F);
            this.listBoxFilePanel.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelTextColor;
            this.listBoxFilePanel.FormattingEnabled = true;
            this.listBoxFilePanel.ItemHeight = 40;
            this.listBoxFilePanel.Items.AddRange(new object[] {
            "..",
            "dir1",
            "music1.mp3",
            "cdhsdjhjks hdkjchkj hewjkc hwejk chwejkc hkweh cwjkec hwekjc hwkech wejc "});
            this.listBoxFilePanel.Location = new System.Drawing.Point(0, 0);
            this.listBoxFilePanel.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.listBoxFilePanel.Name = "listBoxFilePanel";
            this.listBoxFilePanel.PaddingBottom = 0;
            this.listBoxFilePanel.PaddingLeft = 0;
            this.listBoxFilePanel.PaddingRight = 0;
            this.listBoxFilePanel.PaddingTop = -5;
            this.listBoxFilePanel.SelectedItemBackColor = global::AlfaPlayer2.Properties.Settings.Default.SelectedItemBackColor;
            this.listBoxFilePanel.SelectedItemForeColor = global::AlfaPlayer2.Properties.Settings.Default.SelectedItemForeColor;
            this.listBoxFilePanel.SelectedSpecialItemForeColor = global::AlfaPlayer2.Properties.Settings.Default.SelectedSpecialItemForeColor;
            this.listBoxFilePanel.ShowScrollbar = false;
            this.listBoxFilePanel.Size = new System.Drawing.Size(493, 284);
            this.listBoxFilePanel.TabIndex = 1;
            this.listBoxFilePanel.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxFilePanel_DrawItem);
            this.listBoxFilePanel.DoubleClick += new System.EventHandler(this.listBoxFilePanel_DoubleClick);
            this.listBoxFilePanel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxFilePanel_KeyDown);
            this.listBoxFilePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxFilePanel_MouseDown);
            this.listBoxFilePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxFilePanel_MouseMove);
            this.listBoxFilePanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxFilePanel_MouseUp);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(493, 0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(10);
            this.panel5.Size = new System.Drawing.Size(281, 284);
            this.panel5.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timerPlayer
            // 
            this.timerPlayer.Interval = 250;
            this.timerPlayer.Tick += new System.EventHandler(this.timerPlayer_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textProgressBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 64);
            this.panel1.TabIndex = 7;
            // 
            // textProgressBar
            // 
            this.textProgressBar.DataBindings.Add(new System.Windows.Forms.Binding("TextColor", global::AlfaPlayer2.Properties.Settings.Default, "ProgressTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textProgressBar.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "ProgressForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textProgressBar.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.ProgressForeColor;
            this.textProgressBar.Location = new System.Drawing.Point(0, 0);
            this.textProgressBar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.textProgressBar.MaximumValue = 100;
            this.textProgressBar.Name = "textProgressBar";
            this.textProgressBar.PaddingBottom = 0;
            this.textProgressBar.PaddingLeft = 0;
            this.textProgressBar.PaddingRight = 0;
            this.textProgressBar.PaddingTop = -5;
            this.textProgressBar.ProgressText = "00:00 / 00:00";
            this.textProgressBar.Size = new System.Drawing.Size(784, 64);
            this.textProgressBar.TabIndex = 3;
            this.textProgressBar.TextColor = global::AlfaPlayer2.Properties.Settings.Default.ProgressTextColor;
            this.textProgressBar.Value = 50;
            this.textProgressBar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textProgressBar_MouseClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelSongTitle);
            this.panel2.Controls.Add(this.labelSongInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 106);
            this.panel2.TabIndex = 8;
            // 
            // labelSongTitle
            // 
            this.labelSongTitle.BackColor = global::AlfaPlayer2.Properties.Settings.Default.TitleBackColor;
            this.labelSongTitle.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelSongTitle.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelSongTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSongTitle.Font = new System.Drawing.Font("Exo 2 Semi Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSongTitle.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.TitleTextColor;
            this.labelSongTitle.Location = new System.Drawing.Point(0, 0);
            this.labelSongTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelSongTitle.Name = "labelSongTitle";
            this.labelSongTitle.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelSongTitle.PaddingBottom = 0;
            this.labelSongTitle.PaddingLeft = 0;
            this.labelSongTitle.PaddingRight = 0;
            this.labelSongTitle.PaddingTop = 0;
            this.labelSongTitle.PauseScrollRefreshMilliseconds = 5000F;
            this.labelSongTitle.Size = new System.Drawing.Size(784, 65);
            this.labelSongTitle.Step = 1F;
            this.labelSongTitle.TabIndex = 2;
            this.labelSongTitle.Text = "Alfa Player";
            this.labelSongTitle.TimeoutSeconds = 0.001D;
            // 
            // labelSongInfo
            // 
            this.labelSongInfo.BackColor = global::AlfaPlayer2.Properties.Settings.Default.TitleBackColor;
            this.labelSongInfo.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelSongInfo.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelSongInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelSongInfo.Font = new System.Drawing.Font("Exo 2 Extra Light", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSongInfo.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.TitleTextColor;
            this.labelSongInfo.Location = new System.Drawing.Point(0, 65);
            this.labelSongInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelSongInfo.Name = "labelSongInfo";
            this.labelSongInfo.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.labelSongInfo.PaddingBottom = 0;
            this.labelSongInfo.PaddingLeft = 0;
            this.labelSongInfo.PaddingRight = 0;
            this.labelSongInfo.PaddingTop = -1;
            this.labelSongInfo.PauseScrollRefreshMilliseconds = 10000F;
            this.labelSongInfo.Size = new System.Drawing.Size(784, 41);
            this.labelSongInfo.Step = 1F;
            this.labelSongInfo.TabIndex = 3;
            this.labelSongInfo.Text = "artist";
            this.labelSongInfo.TimeoutSeconds = 0.001D;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 170);
            this.panel3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 317);
            this.panel3.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Exo 2", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.PaddingBottom = 0;
            this.label1.PaddingLeft = 0;
            this.label1.PaddingRight = 0;
            this.label1.PaddingTop = 0;
            this.label1.PauseScrollRefreshMilliseconds = 10000F;
            this.label1.Size = new System.Drawing.Size(784, 27);
            this.label1.Step = 1F;
            this.label1.TabIndex = 2;
            this.label1.Text = "folder";
            this.label1.TimeoutSeconds = 0.01D;
            // 
            // timerHibernate
            // 
            this.timerHibernate.Tick += new System.EventHandler(this.timerHibernate_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textProgressBar2
            // 
            this.textProgressBar2.Location = new System.Drawing.Point(16, 11);
            this.textProgressBar2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textProgressBar2.MaximumValue = 100;
            this.textProgressBar2.Name = "textProgressBar2";
            this.textProgressBar2.PaddingBottom = 0;
            this.textProgressBar2.PaddingLeft = 0;
            this.textProgressBar2.PaddingRight = 0;
            this.textProgressBar2.PaddingTop = 0;
            this.textProgressBar2.ProgressText = null;
            this.textProgressBar2.Size = new System.Drawing.Size(116, 18);
            this.textProgressBar2.TabIndex = 2;
            this.textProgressBar2.TextColor = System.Drawing.Color.Empty;
            this.textProgressBar2.Value = 0;
            // 
            // textProgressBar1
            // 
            this.textProgressBar1.BackColor = global::AlfaPlayer2.Properties.Settings.Default.BackgroundColor;
            this.textProgressBar1.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "BackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textProgressBar1.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "ProgressForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textProgressBar1.DataBindings.Add(new System.Windows.Forms.Binding("TextColor", global::AlfaPlayer2.Properties.Settings.Default, "ProgressTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textProgressBar1.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.ProgressForeColor;
            this.textProgressBar1.Location = new System.Drawing.Point(14, 9);
            this.textProgressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textProgressBar1.MaximumValue = 100;
            this.textProgressBar1.Name = "textProgressBar1";
            this.textProgressBar1.PaddingBottom = 0;
            this.textProgressBar1.PaddingLeft = 0;
            this.textProgressBar1.PaddingRight = 0;
            this.textProgressBar1.PaddingTop = 0;
            this.textProgressBar1.ProgressText = null;
            this.textProgressBar1.Size = new System.Drawing.Size(116, 18);
            this.textProgressBar1.TabIndex = 0;
            this.textProgressBar1.Tag = "354345";
            this.textProgressBar1.TextColor = global::AlfaPlayer2.Properties.Settings.Default.ProgressTextColor;
            this.textProgressBar1.Value = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(23F, 48F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::AlfaPlayer2.Properties.Settings.Default.BackgroundColor;
            this.ClientSize = new System.Drawing.Size(784, 487);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textProgressBar2);
            this.Controls.Add(this.textProgressBar1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "BackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Exo 2", 30F);
            this.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.TitleTextColor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AlfaPlayer.TextProgressBar textProgressBar1;
        private AlfaPlayer.CListBox listBoxFilePanel;
        private AlfaPlayer.TextProgressBar textProgressBar2;
        private AlfaPlayer.TextProgressBar textProgressBar;
        private System.Windows.Forms.Panel groupBox1;
        private System.Windows.Forms.Timer timerPlayer;
        private ScrollLabel labelSongTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer timerHibernate;
        private ScrollLabel labelSongInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ScrollLabel label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Timer timer1;
    }
}

