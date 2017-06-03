using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EfwControls.HISControl.CustomDocument.Controls
{
    public partial class SingleLineY : UserControl
    {
        public SingleLineY()
        {
            InitializeComponent();
            this.lineColor = this.ForeColor;
            this.lineWidth = 1;  
        }

        #region 属性定义
        private System.Drawing.Color lineColor;
        private int lineWidth;
        ///   
        /// 线的颜色属性  
        ///   
        public System.Drawing.Color LineColor
        {
            set
            {
                this.lineColor = value;
                System.Windows.Forms.PaintEventArgs ep =
                new PaintEventArgs(this.CreateGraphics(),
                this.ClientRectangle);
                this.LineY_Paint(this, ep);
            }
            get { return this.lineColor; }
        }
        ///   
        /// 线的粗细  
        ///   
        public int LineWidth
        {
            set
            {
                this.lineWidth = value;
                System.Windows.Forms.PaintEventArgs ep =
                new PaintEventArgs(this.CreateGraphics(),
                this.ClientRectangle);
                this.LineY_Paint(this, ep);
            }
            get { return this.lineWidth; }
        }
        #endregion

        private void LineY_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen myPen = new Pen(this.lineColor);
            myPen.Width = this.lineWidth * 2;
            this.Width = this.LineWidth;
            g.DrawLine(myPen, 0, 0, 0, e.ClipRectangle.Bottom);
        }

        private void LineY_Resize(object sender, System.EventArgs e)
        {
            this.Width = this.lineWidth;
        }  
    }
}
