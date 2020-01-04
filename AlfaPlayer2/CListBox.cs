using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AlfaPlayer
{
    class CListBox : System.Windows.Forms.ListBox
    {
        private bool mShowScroll;
        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!mShowScroll)
                    cp.Style = cp.Style & ~0x200000;
                return cp;
            }
        }
        public bool ShowScrollbar
        {
            get { return mShowScroll; }
            set
            {
                if (value != mShowScroll)
                {
                    mShowScroll = value;
                    if (IsHandleCreated)
                        RecreateHandle();
                }
            }
        }




        public Color SelectedItemBackColor { get; set; }



        internal SolidBrush selectedItemForeBrush;
        Color selectedItemForeColor = Color.Red;
        public Color SelectedItemForeColor
        {
            get
            {
                return selectedItemForeColor;
            }
            set
            {
                selectedItemForeBrush = new SolidBrush(value);
                selectedItemForeColor = value;
            }

        }



        internal Brush selectedSpecialItemForeBrush;
        Color selectedSpecialItemForeColor = Color.Red;
        public Color SelectedSpecialItemForeColor
        {
            get
            {
                return selectedSpecialItemForeColor;
            }
            set
            {
                selectedSpecialItemForeBrush = new SolidBrush(value);
                selectedSpecialItemForeColor = value;
            }

        }

        internal SolidBrush foreBrush = new SolidBrush(Color.Black);
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

        public int PaddingTop { get; set; }
        public int PaddingBottom { get; set; }
        public int PaddingLeft { get; set; }
        public int PaddingRight { get; set; }
    }
}
