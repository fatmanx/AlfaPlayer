using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlfaPlayer2
{
    public partial class VerticalProgressBar : UserControl
    {
        public VerticalProgressBar()
        {
            InitializeComponent();
        }


        int value = 0;
        public int Value
        {
            get { return value; }
            set { this.value = value; Refresh(); }
        }

        private int __Maximum = 100;

        public int Maximum
        {
            get { return __Maximum; }
            set { __Maximum = value; Refresh(); }
        }




        private Color __FillColor;

        public Color FillColor
        {
            get { return __FillColor; }
            set { __FillColor = value; __FillBrush = new SolidBrush(__FillColor); Refresh(); }
        }

        SolidBrush __FillBrush = (SolidBrush)Brushes.Transparent;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;
            rec.Width = rec.Width - Padding.Size.Width;
            rec.Height = (int)((rec.Height - Padding.Size.Height) * ((double)Value / Maximum));

            e.Graphics.FillRectangle(__FillBrush, Padding.Left, -Padding.Bottom + e.ClipRectangle.Height - rec.Height, rec.Width, rec.Height);
        }
    }
}
