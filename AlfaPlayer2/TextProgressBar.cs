using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlfaPlayer
{
    public partial class TextProgressBar : UserControl
    {
        public TextProgressBar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }



        [Browsable(true)]
        public string ProgressText { get; set; }


        Brush foreBrush = Brushes.White;
        public override Color ForeColor
        {
            get
            {

                return base.ForeColor;
            }

            set
            {
                foreBrush = new SolidBrush(value);
                base.ForeColor = value;
            }
        }


        public Color TextColor { get; set; }



        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                if (MaximumValue == 0)
                    MaximumValue = 10;

                int W = (Width - Padding.Left - Padding.Right);
                int H = Height - Padding.Top - Padding.Bottom;
                float w = (float)Value / MaximumValue;
                e.Graphics.FillRectangle(foreBrush, Padding.Left, Padding.Top, w * W, H);

                var size = TextRenderer.MeasureText(ProgressText, Font);
                TextRenderer.DrawText(e.Graphics, ProgressText, Font, new Point(Padding.Left + (W - size.Width) / 2, 3 + Padding.Top + (H - size.Height) / 2), TextColor);
            }
            catch { }
        }
        int maximumValue = 100;
        public int MaximumValue
        {
            get
            {
                return maximumValue;
            }
            set
            {
                maximumValue = value;
                this.Refresh();
            }
        }


        int value = 0;
        public int Value
        {
            get { return value; }
            set
            {
                this.value = value;
                Refresh();
            }
        }



    }
}
