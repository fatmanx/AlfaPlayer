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
            this.labelSongTitle = new System.Windows.Forms.Label();
            this.labelBatteryInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timerPlayer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.timerMarquee = new System.Windows.Forms.Timer(this.components);
            this.listBoxFilePanel = new AlfaPlayer.CListBox();
            this.textProgressBar = new AlfaPlayer.TextProgressBar();
            this.textProgressBar2 = new AlfaPlayer.TextProgressBar();
            this.textProgressBar1 = new AlfaPlayer.TextProgressBar();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSongTitle
            // 
            this.labelSongTitle.BackColor = global::AlfaPlayer2.Properties.Settings.Default.TitleBackColor;
            this.labelSongTitle.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelSongTitle.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelSongTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSongTitle.Font = new System.Drawing.Font("White Rabbit", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSongTitle.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.TitleTextColor;
            this.labelSongTitle.Location = new System.Drawing.Point(4, 73);
            this.labelSongTitle.Name = "labelSongTitle";
            this.labelSongTitle.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.labelSongTitle.Size = new System.Drawing.Size(672, 49);
            this.labelSongTitle.TabIndex = 4;
            this.labelSongTitle.Text = "Alfa Player AlfaPlaxasxasx";
            this.labelSongTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSongTitle.UseCompatibleTextRendering = true;
            // 
            // labelBatteryInfo
            // 
            this.labelBatteryInfo.AutoSize = true;
            this.labelBatteryInfo.BackColor = global::AlfaPlayer2.Properties.Settings.Default.OnBatteryColor;
            this.labelBatteryInfo.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "OnBatteryColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelBatteryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBatteryInfo.Location = new System.Drawing.Point(682, 73);
            this.labelBatteryInfo.Name = "labelBatteryInfo";
            this.labelBatteryInfo.Size = new System.Drawing.Size(114, 49);
            this.labelBatteryInfo.TabIndex = 5;
            this.labelBatteryInfo.Text = "100";
            this.labelBatteryInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.listBoxFilePanel);
            this.groupBox1.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelFolderTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelFolderTextColor;
            this.groupBox1.Location = new System.Drawing.Point(4, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 471);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // timerPlayer
            // 
            this.timerPlayer.Tick += new System.EventHandler(this.timerPlayer_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.98583F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.01416F));
            this.tableLayoutPanel1.Controls.Add(this.textProgressBar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelSongTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelBatteryInfo, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 477F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // timerMarquee
            // 
            this.timerMarquee.Interval = 200;
            this.timerMarquee.Tick += new System.EventHandler(this.timerMarquee_Tick);
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
            this.listBoxFilePanel.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelTextColor;
            this.listBoxFilePanel.FormattingEnabled = true;
            this.listBoxFilePanel.ItemHeight = 67;
            this.listBoxFilePanel.Location = new System.Drawing.Point(3, 34);
            this.listBoxFilePanel.Name = "listBoxFilePanel";
            this.listBoxFilePanel.SelectedItemBackColor = global::AlfaPlayer2.Properties.Settings.Default.SelectedItemBackColor;
            this.listBoxFilePanel.SelectedItemForeColor = global::AlfaPlayer2.Properties.Settings.Default.SelectedItemForeColor;
            this.listBoxFilePanel.SelectedSpecialItemForeColor = global::AlfaPlayer2.Properties.Settings.Default.SelectedSpecialItemForeColor;
            this.listBoxFilePanel.ShowScrollbar = false;
            this.listBoxFilePanel.Size = new System.Drawing.Size(786, 434);
            this.listBoxFilePanel.TabIndex = 1;
            this.listBoxFilePanel.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxFilePanel_DrawItem);
            this.listBoxFilePanel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxFilePanel_KeyDown);
            // 
            // textProgressBar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textProgressBar, 2);
            this.textProgressBar.DataBindings.Add(new System.Windows.Forms.Binding("TextColor", global::AlfaPlayer2.Properties.Settings.Default, "ProgressTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textProgressBar.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "ProgressForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textProgressBar.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.ProgressForeColor;
            this.textProgressBar.Location = new System.Drawing.Point(12, 8);
            this.textProgressBar.Margin = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.textProgressBar.MaximumValue = 100;
            this.textProgressBar.Name = "textProgressBar";
            this.textProgressBar.ProgressText = "00:00 / 00:00";
            this.textProgressBar.Size = new System.Drawing.Size(776, 58);
            this.textProgressBar.TabIndex = 3;
            this.textProgressBar.TextColor = global::AlfaPlayer2.Properties.Settings.Default.ProgressTextColor;
            this.textProgressBar.Value = 44;
            this.textProgressBar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textProgressBar_MouseClick);
            // 
            // textProgressBar2
            // 
            this.textProgressBar2.Location = new System.Drawing.Point(61, 38);
            this.textProgressBar2.Margin = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.textProgressBar2.MaximumValue = 100;
            this.textProgressBar2.Name = "textProgressBar2";
            this.textProgressBar2.ProgressText = null;
            this.textProgressBar2.Size = new System.Drawing.Size(445, 62);
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
            this.textProgressBar1.Location = new System.Drawing.Point(54, 31);
            this.textProgressBar1.Margin = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.textProgressBar1.MaximumValue = 100;
            this.textProgressBar1.Name = "textProgressBar1";
            this.textProgressBar1.ProgressText = null;
            this.textProgressBar1.Size = new System.Drawing.Size(445, 62);
            this.textProgressBar1.TabIndex = 0;
            this.textProgressBar1.Tag = "354345";
            this.textProgressBar1.TextColor = global::AlfaPlayer2.Properties.Settings.Default.ProgressTextColor;
            this.textProgressBar1.Value = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(23F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::AlfaPlayer2.Properties.Settings.Default.BackgroundColor;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.textProgressBar2);
            this.Controls.Add(this.textProgressBar1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "BackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("White Rabbit", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.TitleTextColor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AlfaPlayer.TextProgressBar textProgressBar1;
        private AlfaPlayer.CListBox listBoxFilePanel;
        private AlfaPlayer.TextProgressBar textProgressBar2;
        private AlfaPlayer.TextProgressBar textProgressBar;
        private System.Windows.Forms.Label labelSongTitle;
        private System.Windows.Forms.Label labelBatteryInfo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer timerPlayer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timerMarquee;
    }
}

