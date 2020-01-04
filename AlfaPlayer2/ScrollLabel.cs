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
    public partial class ScrollLabel : Label
    {
        public ScrollLabel()
        {
            InitializeComponent();
        }

        DateTime lastDraw;
        TimeSpan timeout = TimeSpan.FromSeconds(1);
        public double TimeoutSeconds
        {
            get { return timeout.TotalSeconds; }
            set { timeout = TimeSpan.FromSeconds(value); }
        }

        public float Step { get; set; }
        float lastx = 0;


        string text = "";

        float y = 0;
        public override string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                lastx = 0;
                text = base.Text = value;


                ////Console.WriteLine(base.Text);
                ////base.Text = "Alfa PlayerAlfa PlayerAlfa PlayerAlfa PlayerAlfa PlayerAlfa PlayerAlfa PlayerAlfa PlayerAlfa PlayerAlfa PlayerAlfa Player";
                //var s = CreateGraphics().MeasureString(base.Text, Font);

                ////Console.WriteLine("{0}  {1}", Width, s);
                //if (s.Width > 0)
                //{
                //    text = base.Text + "         *         ";

                //    int xx = (int)(Width / s.Width);
                //    StringBuilder sb = new StringBuilder();
                //    text = sb.Insert(0, text, 2 * xx + 2).ToString();
                //    //text = base.Text + " 0 " + base.Text + " 1 " + base.Text + " 2 " + base.Text + " 3 ";
                //    //Console.WriteLine(text);

                //}
            }
        }

        Brush foreBrush = Brushes.Black;
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
                foreBrush = new SolidBrush(value);
            }
        }

        DateTime lastPauseRefresh = DateTime.Now;
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!Enabled)
            {
                return;
            }
            //base.OnPaint(e);

            if (DateTime.Now - lastDraw > timeout)
            {
                lastDraw = DateTime.Now;
                var strSize = e.Graphics.MeasureString(base.Text, Font);
                //Console.WriteLine("{0}  {1}", lastx, sss.Width);
                y = (Height - strSize.Height) / 2f;

                //if (Math.Abs(lastx) >= strSize.Width + 10 * Step)
                //{
                //    lastx = 0;
                //}
                //else
                //{
                //    lastx -= Step;
                //}

                if (strSize.Width > Width + 20)
                {
                    //Console.WriteLine("id:{4} x:{0}  w:{1} sw:{2} df:{3}", lastx, Width, strSize.Width, Width - strSize.Width, this.GetHashCode());
                    if (lastx < Width - strSize.Width || lastx > 5)
                    {
                        Step = -Step;
                        lastPauseRefresh = DateTime.Now;
                        //lastx = Width;
                    }

                    lastx -= Step;
                }

            }
            e.Graphics.DrawString(text, Font, foreBrush, lastx, y + Padding.Top);

        }

        public float PauseScrollRefreshMilliseconds { get; set; } = 1000;

        private void timerRedraw_Tick(object sender, EventArgs e)
        {

            if (DateTime.Now - lastPauseRefresh > TimeSpan.FromMilliseconds(PauseScrollRefreshMilliseconds))
            {
                this.Refresh();
            }

        }

        private void ScrollLabel_Resize(object sender, EventArgs e)
        {
            lastx = 0;
            this.Refresh();
        }
    }
}
