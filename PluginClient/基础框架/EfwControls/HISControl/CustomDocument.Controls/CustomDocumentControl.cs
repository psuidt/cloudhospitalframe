/*
 *表单控件
 * 1.以纸张形式展示界面
 * 2.可以直接预览、打印
 * 3.自动处理数据
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using EfwControls.Properties;
using System.Drawing.Printing;

namespace EfwControls.HISControl.CustomDocument.Controls
{
    [LicenseProvider(typeof(EfwControls.Common.Licensing.ComponentLicenseProvider))]
    [Designer(typeof(UserControlDesigner))]
    public partial class CustomDocumentControl : UserControl
    {
        #region 许可证
        [Browsable(false)]
        public static string DeveloperKey { get; set; }
        private bool _isDemo = true;
        //private static string _licKey = "";
        [Category("许可证"), Description("设置许可证你才能使用此控件")]
        public string LicenseKey
        {
            get { return DeveloperKey; }
            set
            {
                DeveloperKey = value;
                //CheckLicense();
                this.Invalidate();
            }
        }
        private void CheckLicense()
        {
            Common.Licensing.ComponentLicense lic = LicenseManager.Validate(typeof(CustomDocumentControl), this) as Common.Licensing.ComponentLicense;
            if (lic != null)
            {
                _isDemo = lic.IsDemo;
                if (_isDemo)
                {
                    MessageBox.Show("正确设置[CustomDocumentControl]控件的许可证，才能使用！");
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            //CheckLicense();
        }
        #endregion

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ContentArea
        {
            get
            {
                return pcbFormBack; // 在上面放一个Panel，名字叫 panel1
            }
        }

        private DisplayForm _PageDisplayForm=new DisplayForm("A5");

        //private List<DisplayForm> _customDisplayForm;
        [Description("自定义页面格式")]
        public DisplayForm CustomPageDisplayForm
        {
            get
            {
                return _PageDisplayForm;
            }
            set
            {
                _PageDisplayForm = value;
            }
        }

        private PageType _pageType = PageType.A5;
        [Description("设置页面格式")]
        public PageType SelectPageType
        {
            get
            {
                return _pageType;
            }
            set
            {
                _pageType = value;
                switch (_pageType)
                {
                    case PageType.A5:
                        _PageDisplayForm = new DisplayForm("A5", 1480, 2100, 100, 100);
                        DrawMain();
                        break;
                    case PageType.A4:
                        _PageDisplayForm = new DisplayForm("A4", 2100, 2970, 100, 100);
                        DrawMain();
                        break;
                    case PageType.Custom:
                        DrawMain();
                        break;
                }
            }
        }

        private BackgroundImageType _backgroundImageType = BackgroundImageType.正常皮肤;
        [Description("设置背景图片")]
        public BackgroundImageType SelectBackgroundImageType
        {
            get
            {
                return _backgroundImageType;
            }
            set
            {
                _backgroundImageType = value;
                DrawMain();
            }
        }

    

        public CustomDocumentControl()
        {
            
            InitializeComponent();
            DrawMain();
            pcbFormBack.ControlAdded += new ControlEventHandler(pcbFormBack_ControlAdded);
            pcbFormBack.Parent = this;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }

        void pcbFormBack_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Parent = pcbFormBack;
        }

        private void DrawMain()
        {
            if (_PageDisplayForm != null)
            {
               

                //生成背景
                Graphics Canvas = pcbFormBack.CreateGraphics();
                //转换为以像素表示的单位
                _PageDisplayForm.xPixPermm = Canvas.DpiX / 254.0f;
                _PageDisplayForm.yPixPermm = Canvas.DpiY / 254.0f;
                _PageDisplayForm.xScrDPIDiff = Canvas.DpiX / 96.0f;
                _PageDisplayForm.yScrDPIDiff = Canvas.DpiY / 96.0f;
                Canvas.Dispose();
                pcbFormBack.Width = Convert.ToInt32(_PageDisplayForm.PageWidth * _PageDisplayForm.xPixPermm);
                pcbFormBack.Height = Convert.ToInt32(_PageDisplayForm.PageHeight * _PageDisplayForm.yPixPermm);
                pcbFormBack.Visible = false;
                Bitmap bmpBack = new Bitmap((int)(_PageDisplayForm.PageWidth * _PageDisplayForm.xPixPermm),
                                            (int)(_PageDisplayForm.PageHeight * _PageDisplayForm.yPixPermm));
                Canvas = Graphics.FromImage(bmpBack);
                Canvas.PageUnit = GraphicsUnit.Pixel;
                Canvas.SmoothingMode = SmoothingMode.HighQuality;
                Canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                Canvas.FillRectangle(Brushes.White, 0, 0, bmpBack.Width, bmpBack.Height);
                //画背景纹理图片
                DrawFormBackground(Canvas, _PageDisplayForm);

                //foreach (Control sobj in pcbFormBack.Controls)
                //    pcbFormBack.Controls.Remove(sobj);

                this.Size=new Size(pcbFormBack.Width + 20,pcbFormBack.Height + 20);

                this.SuspendLayout();

                //DrawFormContent(Canvas, _PageDisplayForm);

                Canvas.Dispose();
                this.ResumeLayout(false);
                this.PerformLayout();
                pcbFormBack.BackgroundImage = bmpBack;
                pcbFormBack.Left = Math.Max(8, (this.Width - 30 - pcbFormBack.Width) / 2);
                pcbFormBack.Visible = true;
            }
        }

        private void DrawFormBackground(Graphics Canvas, DisplayForm op_form)
        {
            //画背景纹理图片
            Image imgBack = Resources.灰色皮肤;

            switch (_backgroundImageType)
            {
                case BackgroundImageType.正常皮肤:
                    imgBack = Resources.正常皮肤;
                    break;
                case BackgroundImageType.灰色皮肤:
                    imgBack = Resources.灰色皮肤;
                    break;
                case BackgroundImageType.黄色皮肤:
                    imgBack = Resources.黄色皮肤;
                    break;
                case BackgroundImageType.红色皮肤:
                    imgBack = Resources.红色皮肤;
                    break;
                case BackgroundImageType.白色皮肤:
                    imgBack = Resources.白色皮肤;
                    break;
            }

            int iCol = (int)(op_form.PageWidth * op_form.xPixPermm) / imgBack.Width + 1;
            int iRow = (int)(op_form.PageHeight * op_form.yPixPermm) / imgBack.Height + 1;
            for (int i = 0; i < iRow; i++)
                for (int j = 0; j < iCol; j++)
                    Canvas.DrawImage(imgBack, j * imgBack.Width, i * imgBack.Height);
        }

        private void palView_Resize(object sender, EventArgs e)
        {
            pcbFormBack.Left = Math.Max(8, (this.Width - 30 - pcbFormBack.Width) / 2);
        }

        /// <summary>
        /// 取得打印比例坐标转换参数
        /// </summary>
        private STYLE_CONVERT GetStyleConvert()
        {
            STYLE_CONVERT style = new STYLE_CONVERT();
            Graphics g = Application.OpenForms[0].CreateGraphics();
            style.xPixPermm = g.DpiX / 254.0f;   //每0.1mm对应屏幕上的点数，用于计算偏移量
            style.yPixPermm = g.DpiY / 254.0f;
            style.xScrDPIDiff = g.DpiX / 96.0f; // 等于1
            style.yScrDPIDiff = g.DpiY / 96.0f;
            style.fDPIX = g.DpiX; //屏幕DPI
            style.fDPIY = g.DpiY;
            g.Dispose();
            return style;
        }

        private Font GetFont(Size s, string P_String, Font regularFont)
        {
            Bitmap _bitmap = new Bitmap(s.Width, s.Height);
            string sFontName = regularFont.Name;
            float fontsize = regularFont.Size;
            Graphics _graphics = Graphics.FromImage(_bitmap);
            for (Size _size = s; _size.Width >= s.Width || _size.Height >= s.Height; fontsize -= 0.1f)
            {
                Font font_1 = new Font(sFontName, fontsize);
                _size = _graphics.MeasureString(P_String, font_1).ToSize();
            }
            if (fontsize < 6)
            {
                return new Font(sFontName, 6f);
            }
            else
            {
                return new Font(sFontName, fontsize - 1f);
            }
        }

        public bool Print(Graphics g)
        {
            g.PageUnit = GraphicsUnit.Pixel;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            STYLE_CONVERT style = GetStyleConvert();
            float xPixPerIn = g.DpiX / style.fDPIX; // 打印机DPI/屏幕DPI
            float yPixPerIn = g.DpiY / style.fDPIY;
            float iTopOffset = 0; //自动调整位置的偏移量 对应屏幕DPI

            Control ctrl = pcbFormBack;
            //int iLeft = _PageDisplayForm.LeftMarign;
            //int iTop = _PageDisplayForm.TopMarign;
            //int iWidth = _PageDisplayForm.PageWidth;
            //int iHeight = _PageDisplayForm.PageHeight;

            Pen p = new Pen(Color.Black, 1f);
            RectangleF rectBound = new RectangleF();
            SolidBrush foreBrush = new SolidBrush(Color.Black);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;


            foreach (Control item in ctrl.Controls)
            {
                if (item.Visible)
                {
                    Font regularFont = new Font("宋体", item.Font.Size);//item.Font;
                    StringFormat strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Near;
                    strFormat.LineAlignment = StringAlignment.Near;

                    Form_POS sobj = new Form_POS();
                    //原来存的值为去掉边界后的像素值，边界单位为0.1mm
                    sobj.Pos_Left = item.Left * style.xScrDPIDiff;
                    sobj.Pos_Top = item.Top * style.yScrDPIDiff;
                    sobj.Pos_Right = item.Right * style.xScrDPIDiff;
                    sobj.Pos_Bottom = item.Bottom * style.yScrDPIDiff;

                    //坐标变换到屏幕位置, 自动调整尺寸是需要加上iTopOffset
                    //sobj.Pos_Top += _PageDisplayForm.TopMarign * style.yPixPermm + iTopOffset;
                    //sobj.Pos_Bottom += _PageDisplayForm.TopMarign * style.yPixPermm + iTopOffset;

                    //sobj.Pos_Left += _PageDisplayForm.LeftMarign * style.xPixPermm;
                    //sobj.Pos_Right += _PageDisplayForm.LeftMarign * style.xPixPermm;

                    //由屏幕位置变换到打印机位置
                    sobj.Pos_Top = sobj.Pos_Top * yPixPerIn;
                    sobj.Pos_Bottom = sobj.Pos_Bottom * yPixPerIn;
                    sobj.Pos_Left = sobj.Pos_Left * xPixPerIn;
                    sobj.Pos_Right = sobj.Pos_Right * xPixPerIn;

                    rectBound.X = sobj.Pos_Left;
                    rectBound.Y = sobj.Pos_Top;
                    rectBound.Width = sobj.Width();
                    rectBound.Height = sobj.Height();

                    #region SingleLine
                    if (item is SingleLineX || item is SingleLineY)
                    {
                        g.FillRectangle(foreBrush, rectBound);
                    }
                    #endregion
                    #region Label
                    else if (item is Label)
                    {
                        Label objItem = item as Label;

                        if (objItem.TextAlign == ContentAlignment.MiddleCenter)
                        {
                            strFormat.Alignment = StringAlignment.Center;
                            strFormat.LineAlignment = StringAlignment.Center;
                        }
                        else
                        {
                            strFormat.Alignment = StringAlignment.Near;
                            strFormat.LineAlignment = StringAlignment.Center;
                        }

                        g.DrawString(objItem.Text, GetFont(objItem.Size, objItem.Text, regularFont), foreBrush, rectBound, strFormat);
                    }
                    #endregion
                    #region DateTimePicker
                    else if (item is DateTimePicker)
                    {
                        DateTimePicker objItem = item as DateTimePicker;

                        strFormat.Alignment = StringAlignment.Near;
                        strFormat.LineAlignment = StringAlignment.Center;
                        g.DrawString(objItem.Value.ToString(objItem.CustomFormat), regularFont,
                            new SolidBrush(objItem.ForeColor), rectBound, strFormat);
                    }
                    #endregion
                    #region TextBox
                    else if (item is TextBox)
                    {
                        TextBox objItem = item as TextBox;
                        if (objItem.Visible)
                        {

                            if (objItem.TextAlign == HorizontalAlignment.Center)
                                strFormat.Alignment = StringAlignment.Center;
                            else if (objItem.TextAlign == HorizontalAlignment.Left)
                                strFormat.Alignment = StringAlignment.Near;
                            else
                                strFormat.Alignment = StringAlignment.Far;
                            strFormat.LineAlignment = StringAlignment.Center;

                            g.DrawString(objItem.Text, GetFont(objItem.Size, objItem.Text, regularFont),
                               new SolidBrush(objItem.ForeColor), rectBound, strFormat);
                        }
                    }
                    #endregion
                    #region CheckBox
                    else if (item is CheckBox)
                    {
                        CheckBox objItem = item as CheckBox;

                        if (objItem.Checked)
                        {

                            strFormat.Alignment = StringAlignment.Center;
                            strFormat.LineAlignment = StringAlignment.Center;
                            g.DrawString("√", regularFont, new SolidBrush(objItem.ForeColor), rectBound, strFormat);
                        }
                        g.DrawString(objItem.Text, GetFont(objItem.Size, objItem.Text, regularFont),
                               new SolidBrush(objItem.ForeColor), rectBound, strFormat);
                    }
                    #endregion
                    #region radioButton
                    else if (item is RadioButton)
                    {
                        RadioButton objItem = item as RadioButton;

                        if (objItem.Checked)
                        {
                            strFormat.Alignment = StringAlignment.Center;
                            strFormat.LineAlignment = StringAlignment.Center;
                            g.DrawString("√", regularFont, new SolidBrush(objItem.ForeColor), rectBound, strFormat);
                        }
                        g.DrawString(objItem.Text, GetFont(objItem.Size, objItem.Text, regularFont),
                              new SolidBrush(objItem.ForeColor), rectBound, strFormat);
                    }
                    #endregion
                }
            }
            return true;
        }

        /// <summary>
        /// 预览
        /// </summary>
        public void Preview()
        {
            PrintDocument printDoc = new PrintDocument();
            //设置打印用的纸张 当设置为Custom的时候，可以自定义纸张的大小，还可以选择A4,A5等常用纸型
            int iWidth = (int)(_PageDisplayForm.PageWidth * 100f / (10f * 25.4f));
            int iHeight = (int)(_PageDisplayForm.PageHeight * 100f / (10f * 25.4f));
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custom", iWidth, iHeight); //百分之一英寸
            printDoc.PrintPage += new PrintPageEventHandler(printer_PrintPage);
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDoc;
            printPreviewDialog.ShowIcon = false;
            (printPreviewDialog as Form).WindowState = FormWindowState.Maximized;
            printPreviewDialog.ShowDialog();
        }

        void printer_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Cancel = !Print(e.Graphics);
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
        }
        

    }

    public class UserControlDesigner : ControlDesigner
    {
        public override void Initialize(System.ComponentModel.IComponent Ic)
        {
            base.Initialize(Ic);
            CustomDocumentControl UC = (CustomDocumentControl)Ic;
            EnableDesignMode(UC.ContentArea, "ContentArea");
        }
    }

    public enum BackgroundImageType
    {
        正常皮肤, 红色皮肤, 黄色皮肤, 灰色皮肤,白色皮肤
    }

    public enum PageType
    {
        A4,A5,Custom
    }

    public class DisplayForm
    {
        public DisplayForm()
        {
        }

        public DisplayForm(string _formName)
        {
            DisplayFormName = _formName;
            PageWidth = 1480;
            PageHeight = 2100;
            TopMarign = 100;
            LeftMarign = 100;
        }

        public DisplayForm(string _formName, int _pagewidth, int _pageheight, int _topmarign, int _leftmarign)
        {
            DisplayFormName = _formName;
            PageWidth = _pagewidth;
            PageHeight = _pageheight;
            TopMarign = _topmarign;
            LeftMarign = _leftmarign;
        }

        /// <summary>
        /// 格式名称
        /// </summary>
        public string DisplayFormName { get; set; }
        /// <summary>
        /// 页面宽度, 单位 0.1mm
        /// </summary>
        public int PageWidth { get; set; }
        /// <summary>
        /// 页面高度, 单位 0.1mm
        /// </summary>
        public int PageHeight { get; set; }
        /// <summary>
        /// 上下边距, 单位 0.1mm
        /// </summary>
        public int TopMarign { get; set; }
        /// <summary>
        /// 左右边距, 单位 0.1mm
        /// </summary>
        public int LeftMarign { get; set; }
        /// <summary>
        /// 进纸方向，1--横向 0--纵向
        /// </summary>
        public int PageOrientate { get; set; }
        /// <summary>
        /// 纸张名称：如 A4, A5等
        /// </summary>
        public string PaperName { get; set; }
        /// <summary>
        /// X方向每0.1毫米单对应的象素单位
        /// </summary>
        public float xPixPermm { get; set; }
        /// <summary>
        /// Y方向每0.1毫米单对应的象素单位
        /// </summary>
        public float yPixPermm { get; set; }
        /// <summary>
        /// X方向屏幕DIP误差纠正
        /// </summary>
        public float xScrDPIDiff { get; set; }
        /// <summary>
        /// Y方向屏幕DIP误差纠正
        /// </summary>
        public float yScrDPIDiff { get; set; }

        /// <summary>
        /// 保留的控制选项，按位使用
        /// </summary>
        public int Options { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Memo { get; set; }
    }

    public struct STYLE_CONVERT
    {
        public float xPixPermm;   //每0.1mm对应屏幕上的点数
        public float yPixPermm;
        public float xScrDPIDiff;
        public float yScrDPIDiff;
        public float fDPIX;
        public float fDPIY;
    }

    public struct Form_POS
    {
        /// <summary>
        /// 左上角X位置,单位:象素
        /// </summary>
        public float Pos_Left;
        /// <summary>
        /// 左上角Y位置,单位:象素
        /// </summary>
        public float Pos_Top;
        /// <summary>
        /// 右下角X位置,单位:象素
        /// </summary>
        public float Pos_Right;
        /// <summary>
        /// 右下角Y位置,单位:象素
        /// </summary>
        public float Pos_Bottom;
        /// <summary>
        /// 返回对象宽度，单位：像素
        /// </summary>
        /// <returns></returns>
        public float Width() { return Math.Abs(Pos_Right - Pos_Left); }
        /// <summary>
        /// 返回对象高度，单位：像素
        /// </summary>
        /// <returns></returns>
        public float Height() { return Math.Abs(Pos_Bottom - Pos_Top); }
    }
}
