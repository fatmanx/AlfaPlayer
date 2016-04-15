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
            this.labelSongTitle = new System.Windows.Forms.Label();
            this.labelBatteryInfo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textProgressBar = new AlfaPlayer.TextProgressBar();
            this.textProgressBar2 = new AlfaPlayer.TextProgressBar();
            this.listBoxFilePanel = new AlfaPlayer.CListBox();
            this.textProgressBar1 = new AlfaPlayer.TextProgressBar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSongTitle
            // 
            this.labelSongTitle.AutoSize = true;
            this.labelSongTitle.BackColor = global::AlfaPlayer2.Properties.Settings.Default.TitleBackColor;
            this.labelSongTitle.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelSongTitle.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelSongTitle.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.TitleTextColor;
            this.labelSongTitle.Location = new System.Drawing.Point(55, 123);
            this.labelSongTitle.Name = "labelSongTitle";
            this.labelSongTitle.Size = new System.Drawing.Size(267, 31);
            this.labelSongTitle.TabIndex = 4;
            this.labelSongTitle.Text = "Alfa Player";
            // 
            // labelBatteryInfo
            // 
            this.labelBatteryInfo.AutoSize = true;
            this.labelBatteryInfo.BackColor = global::AlfaPlayer2.Properties.Settings.Default.OnBatteryColor;
            this.labelBatteryInfo.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "OnBatteryColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelBatteryInfo.Location = new System.Drawing.Point(531, 100);
            this.labelBatteryInfo.Name = "labelBatteryInfo";
            this.labelBatteryInfo.Size = new System.Drawing.Size(83, 31);
            this.labelBatteryInfo.TabIndex = 5;
            this.labelBatteryInfo.Text = "100";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxFilePanel);
            this.groupBox1.Location = new System.Drawing.Point(41, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 364);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // textProgressBar
            // 
            this.textProgressBar.DataBindings.Add(new System.Windows.Forms.Binding("TextColor", global::AlfaPlayer2.Properties.Settings.Default, "ProgressTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textProgressBar.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "ProgressForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textProgressBar.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.ProgressForeColor;
            this.textProgressBar.Location = new System.Drawing.Point(20, 16);
            this.textProgressBar.Margin = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.textProgressBar.MaximumValue = 100;
            this.textProgressBar.Name = "textProgressBar";
            this.textProgressBar.ProgressText = "3566";
            this.textProgressBar.Size = new System.Drawing.Size(445, 62);
            this.textProgressBar.TabIndex = 3;
            this.textProgressBar.TextColor = global::AlfaPlayer2.Properties.Settings.Default.ProgressTextColor;
            this.textProgressBar.Value = 44;
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
            // listBoxFilePanel
            // 
            this.listBoxFilePanel.BackColor = global::AlfaPlayer2.Properties.Settings.Default.BackgroundColor;
            this.listBoxFilePanel.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "BackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listBoxFilePanel.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listBoxFilePanel.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItemBackColor", global::AlfaPlayer2.Properties.Settings.Default, "SelectedItemBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listBoxFilePanel.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItemForeColor", global::AlfaPlayer2.Properties.Settings.Default, "SelectedItemForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listBoxFilePanel.DataBindings.Add(new System.Windows.Forms.Binding("SelectedSpecialItemForeColor", global::AlfaPlayer2.Properties.Settings.Default, "SelectedSpecialItemForeColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.listBoxFilePanel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBoxFilePanel.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelTextColor;
            this.listBoxFilePanel.FormattingEnabled = true;
            this.listBoxFilePanel.ItemHeight = 67;
            this.listBoxFilePanel.Location = new System.Drawing.Point(20, 96);
            this.listBoxFilePanel.Name = "listBoxFilePanel";
            this.listBoxFilePanel.SelectedItemBackColor = global::AlfaPlayer2.Properties.Settings.Default.SelectedItemBackColor;
            this.listBoxFilePanel.SelectedItemForeColor = global::AlfaPlayer2.Properties.Settings.Default.SelectedItemForeColor;
            this.listBoxFilePanel.SelectedSpecialItemForeColor = global::AlfaPlayer2.Properties.Settings.Default.SelectedSpecialItemForeColor;
            this.listBoxFilePanel.ShowScrollbar = false;
            this.listBoxFilePanel.Size = new System.Drawing.Size(622, 180);
            this.listBoxFilePanel.TabIndex = 1;
            this.listBoxFilePanel.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxFilePanel_DrawItem);
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
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelBatteryInfo);
            this.Controls.Add(this.labelSongTitle);
            this.Controls.Add(this.textProgressBar);
            this.Controls.Add(this.textProgressBar2);
            this.Controls.Add(this.textProgressBar1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "BackgroundColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("White Rabbit", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.TitleTextColor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(11, 7, 11, 7);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AlfaPlayer.TextProgressBar textProgressBar1;
        private AlfaPlayer.CListBox listBoxFilePanel;
        private AlfaPlayer.TextProgressBar textProgressBar2;
        private AlfaPlayer.TextProgressBar textProgressBar;
        private System.Windows.Forms.Label labelSongTitle;
        private System.Windows.Forms.Label labelBatteryInfo;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

