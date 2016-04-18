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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(2, 2);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(252, 446);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "TitleTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelProductName.Font = new System.Drawing.Font("White Rabbit", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductName.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.TitleTextColor;
            this.labelProductName.Location = new System.Drawing.Point(2, 2);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(498, 48);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVersion
            // 
            this.labelVersion.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelVersion.Font = new System.Drawing.Font("White Rabbit", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelTextColor;
            this.labelVersion.Location = new System.Drawing.Point(2, 50);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(498, 48);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCopyright
            // 
            this.labelCopyright.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCopyright.Font = new System.Drawing.Font("White Rabbit", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCopyright.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelTextColor;
            this.labelCopyright.Location = new System.Drawing.Point(2, 146);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(498, 48);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCompanyName.Font = new System.Drawing.Font("White Rabbit", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompanyName.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelTextColor;
            this.labelCompanyName.Location = new System.Drawing.Point(2, 98);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(498, 48);
            this.labelCompanyName.TabIndex = 22;
            this.labelCompanyName.Text = "Company Name";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = global::AlfaPlayer2.Properties.Settings.Default.AboutBoxBackColor;
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDescription.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::AlfaPlayer2.Properties.Settings.Default, "AboutBoxBackColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Font = new System.Drawing.Font("White Rabbit", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescription.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelTextColor;
            this.textBoxDescription.Location = new System.Drawing.Point(2, 194);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(498, 204);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Description";
            this.textBoxDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // okButton
            // 
            this.okButton.DataBindings.Add(new System.Windows.Forms.Binding("ForeColor", global::AlfaPlayer2.Properties.Settings.Default, "FilePanelTextColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton.Font = new System.Drawing.Font("White Rabbit", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.ForeColor = global::AlfaPlayer2.Properties.Settings.Default.FilePanelTextColor;
            this.okButton.Location = new System.Drawing.Point(2, 398);
            this.okButton.Name = "okButton";
            this.okButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.okButton.Size = new System.Drawing.Size(498, 50);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.logoPictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(258, 452);
            this.panel1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBoxDescription);
            this.panel2.Controls.Add(this.labelCopyright);
            this.panel2.Controls.Add(this.labelCompanyName);
            this.panel2.Controls.Add(this.labelVersion);
            this.panel2.Controls.Add(this.okButton);
            this.panel2.Controls.Add(this.labelProductName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(267, 9);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(504, 452);
            this.panel2.TabIndex = 26;
            // 
            // AboutBox
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::AlfaPlayer2.Properties.Settings.Default.AboutBoxBackColor;
            this.ClientSize = new System.Drawing.Size(780, 470);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
