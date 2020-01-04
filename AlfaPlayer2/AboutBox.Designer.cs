namespace AlfaPlayer2
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.scrollLabelRootFolder = new AlfaPlayer2.ScrollLabel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelProductName
            // 
            this.labelProductName.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelProductName.Font = new System.Drawing.Font("Exo 2", 36F);
            this.labelProductName.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.TitleTextColor;
            this.labelProductName.Location = new System.Drawing.Point(2, 2);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(776, 48);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVersion
            // 
            this.labelVersion.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelVersion.Font = new System.Drawing.Font("Exo 2", 27.75F);
            this.labelVersion.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelTextColor;
            this.labelVersion.Location = new System.Drawing.Point(2, 50);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(776, 48);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // okButton
            // 
            this.okButton.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("Exo 2", 27.75F);
            this.okButton.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelTextColor;
            this.okButton.Location = new System.Drawing.Point(2, 498);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.okButton.Size = new System.Drawing.Size(776, 80);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.labelVersion);
            this.panel2.Controls.Add(this.okButton);
            this.panel2.Controls.Add(this.labelProductName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(9, 9);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(782, 582);
            this.panel2.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.scrollLabelRootFolder);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(2, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(776, 61);
            this.panel3.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Exo 2", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelTextColor;
            this.button1.Location = new System.Drawing.Point(686, 0);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(90, 61);
            this.button1.TabIndex = 25;
            this.button1.Text = "...";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.Filter = "Any|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            this.openFileDialog1.ShowReadOnly = true;
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // scrollLabelRootFolder
            // 
            this.scrollLabelRootFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollLabelRootFolder.Font = new System.Drawing.Font("Exo 2 Semi Bold", 36F, System.Drawing.FontStyle.Bold);
            this.scrollLabelRootFolder.ForeColor = System.Drawing.Color.Teal;
            this.scrollLabelRootFolder.Location = new System.Drawing.Point(0, 0);
            this.scrollLabelRootFolder.Name = "scrollLabelRootFolder";
            this.scrollLabelRootFolder.PaddingBottom = 0;
            this.scrollLabelRootFolder.PaddingLeft = 0;
            this.scrollLabelRootFolder.PaddingRight = 0;
            this.scrollLabelRootFolder.PaddingTop = 0;
            this.scrollLabelRootFolder.PauseScrollRefreshMilliseconds = 1000F;
            this.scrollLabelRootFolder.Size = new System.Drawing.Size(686, 61);
            this.scrollLabelRootFolder.Step = -1F;
            this.scrollLabelRootFolder.TabIndex = 0;
            this.scrollLabelRootFolder.Text = "ROOT";
            this.scrollLabelRootFolder.TimeoutSeconds = 0.001D;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::AlfaPlayer2.Properties.Settings.Default.AboutBoxBackColor;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel2);
            this.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "AboutBoxBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutBox1";
            this.Load += new System.EventHandler(this.AboutBox_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AboutBox_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AboutBox_KeyPress);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel3;
        private ScrollLabel scrollLabelRootFolder;
        private System.Windows.Forms.Button button1;
    }
}
