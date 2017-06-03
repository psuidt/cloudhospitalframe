using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EfwControls.Common.Licensing;
using System.Collections;
using EfwControls.Properties;
using EfwControls.Common;
using System.Drawing.Drawing2D;

namespace EfwControls.HISControl.BedCard.Controls
{
    [LicenseProvider(typeof(EfwControls.Common.Licensing.ComponentLicenseProvider))]
    public partial class BedCardControlNew : UserControl
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
                this.Invalidate();
            }
        }
        private void CheckLicense()
        {
            ComponentLicense lic = LicenseManager.Validate(typeof(BedCardControl), this) as ComponentLicense;
            if (lic != null)
            {
                _isDemo = lic.IsDemo;
                if (_isDemo)
                {
                    MessageBox.Show("正确设置[BedCardControl]控件的许可证，才能使用！");
                }
            }
        }
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }
        #endregion
        public BedCardControlNew()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.Font = new Font("宋体", 10.0f);

            flpBed.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(flpBed, true, null);

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

                       
        }

        #region 公开属性
        private Object _datasource = null;
        [Description("绑定数据源")]
        public Object DataSource
        {
            get { return _datasource; }
            set
            {
                _datasource = value;
                if (_datasource != null)
                {
                    _selectedBed = null;//清空默认值
                    lastSelectedBedIndex = -1;
                    InitBedInfoControl(_datasource);
                }
            }
        }

        private List<ContextField> _bedContextFields;
        [Description("床位内容字段")]
        public List<ContextField> BedContextFields
        {
            get
            {
                return _bedContextFields;
            }
            set
            {
                _bedContextFields = value;
            }
        }

        private int _BedWidth = 168;
        [Description("床位宽度")]
        [Browsable(false)]
        public int BedWidth
        {
            get { return _BedWidth; }
            set { _BedWidth = value; }
        }

        private int _BedHeight = 200;
        [Description("床位高度")]
        [Browsable(false)]
        public int BedHeight
        {
            get { return _BedHeight; }
            set { _BedHeight = value; }
        }

        private BedInfo _selectedBed = null;
        [Description("选中床位")]
        [Browsable(false)]
        public BedInfo SelectedBed
        {
            get { return _selectedBed; }
            set
            {
                if (value != null && value.Equals(_selectedBed) == false)
                {
                    _selectedBed = value;
                    if (lastSelectedBedIndex != -1)
                    {
                        ((UserControl)flpBed.Controls[lastSelectedBedIndex]).Invalidate();
                        ((UserControl)flpBed.Controls[SelectedBedIndex]).Invalidate();
                    }
                    else
                    {
                        ((UserControl)flpBed.Controls[SelectedBedIndex]).Invalidate();
                    }
                }
                else
                {
                    _selectedBed = value;
                }
            }
        }

        private int _selectedBedIndex = -1;
        [Description("选中床位索引")]
        [Browsable(false)]
        public int SelectedBedIndex
        {
            get
            {
                return _selectedBedIndex;
            }
            set
            {
                if (_datasource != null && value > -1)
                {
                    SelectedBed = (BedInfo)(_datasource as IList)[value];
                    _selectedBedIndex = value;
                }
            }
        }

        [Description("床位数")]
        [Browsable(false)]
        public int BedNum
        {
            get
            {
                if (_datasource != null)
                    return (_datasource as IList).Count;
                return 0;
            }
        }

        private bool _Simple = false;
        [Description("精简模式")]
        public bool Simple
        {
            set
            {
                _Simple=value;

                if (_Simple)
                {
                    BedHeight = _titleHeight + _bottomHeight;
                    BedWidth = 100;
                }
                else
                {
                    BedHeight = 200;
                    BedWidth = 168;
                }
            }
        }
        #endregion

        #region 内部变量
        private int _titleHeight = 30;
        private int _bottomHeight = 28;
        private int _bedWidth = 30;
        private bool _UnUseBedNo = false;        
        #endregion

        #region 事件定义
        [Browsable(true), Description("点击标题时产生")]
        public event OnButtonClick BedTitleClick;
        [Browsable(true), Description("点击病案首页按钮时产生")]
        public event OnButtonClick HeadPageClick;
        [Browsable(true), Description("点击体温单按钮时产生")]
        public event OnButtonClick TemperatureClick;
        [Browsable(true), Description("点击医嘱按钮时产生")]
        public event OnButtonClick AdviceClick;
        [Browsable(true), Description("点击申请单按钮时产生")]
        public event OnButtonClick ApplyFormClick;
        [Browsable(true), Description("点击床位")]
        public event EventHandler BedClick;
        [Browsable(true), Description("双击床位")]
        public event EventHandler BedDoubleClick;
        [Browsable(true), Description("床位内容样式格式化")]
        public event BedFormatStyle BedFormatStyleEvent;
        #endregion

        #region 内部成员变量定义
        /// <summary>
        /// 标题区位置
        /// </summary>
        private Rectangle _rectTitle;
        /// <summary>
        /// 内容区
        /// </summary>
        private Rectangle _rectContext;
        /// <summary>
        /// 底部
        /// </summary>
        private Rectangle _rectBotton;
        /// <summary>
        /// 床号显示区域
        /// </summary>
        private Rectangle _rectBed;
        /// <summary>
        /// 饮食区域
        /// </summary>
        private Rectangle _rectDietType;
        /// <summary>
        /// 护理级别按钮
        /// </summary>
        private Rectangle _rectNurse;
        /// <summary>
        /// 病案首页按钮
        /// </summary>
        private Rectangle _rectHeadPage;
        /// <summary>
        /// 医嘱按钮
        /// </summary>
        private Rectangle _rectAdvice;
        /// <summary>
        /// 体温单按钮
        /// </summary>
        private Rectangle _rectTemperature;
        /// <summary>
        /// 申请单按钮
        /// </summary>
        private Rectangle _rectApply;
        /// <summary>
        /// 边框线颜色 
        /// </summary>
        private Color _BorderColor = ColorTranslator.FromHtml("#d0d7e5");
        #endregion

        private int lastSelectedBedIndex = -1;
        private PointButton pbNew = PointButton.pbNone;
        /// <summary>
        /// 给控件绑定数据的时候初始化床头卡控件
        /// </summary>
        /// <param name="bedlist"></param>
        public void InitBedInfoControl(Object bedlist)
        {
            if (bedlist is IList)
            {
                flpBed.SuspendLayout();
                flpBed.Controls.Clear();
                flpBed.AutoScroll = true;
                for (int i = 0; i < (bedlist as IList).Count; i++)
                {
                    BedItem bed = new BedItem();
                    bed.SuspendLayout();
                    bed.Name = "BedCard";
                    bed.Size = new System.Drawing.Size(_BedWidth, _BedHeight);
                    bed.ResumeLayout(false);
                    bed.Bed = (BedInfo)((bedlist as IList)[i]);
                    bed.BedIndex = i;

                    bed.Click += new EventHandler(bed_Click);
                    bed.DoubleClick += new EventHandler(bed_DoubleClick);
                    bed.Paint += new PaintEventHandler(bed_Paint);
                    bed.MouseMove += new MouseEventHandler(bed_MouseMove);
                    bed.MouseDown += new MouseEventHandler(bed_MouseDown);
                    bed.MouseUp += new MouseEventHandler(bed_MouseUp);
                    bed.MouseEnter += new EventHandler(bed_MouseEnter);
                    bed.MouseLeave += new EventHandler(bed_MouseLeave);
                    bed.Resize += new EventHandler(bed_Resize);
                    bed.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);

                    bed_Resize(null,null);
                    _rectBed = new Rectangle(1, 1, _bedWidth, _titleHeight - 2);
                    flpBed.Controls.Add(bed);
                }
                flpBed.ResumeLayout(true);
            }
        }


        #region 床位事件
        /// <summary>
        /// 床头卡双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bed_DoubleClick(object sender, EventArgs e)
        {
            if (BedDoubleClick != null)
                BedDoubleClick(sender, e);
        }
        /// <summary>
        /// 床头卡单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bed_Click(object sender, EventArgs e)
        {
            if (BedClick != null)
                BedClick(sender, e);
        }
        /// <summary>
        /// 床头卡重设大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bed_Resize(object sender, EventArgs e)
        {
            _rectTitle = new Rectangle(0, 0, BedWidth - 1, _titleHeight);
            _rectContext = new Rectangle(0, _titleHeight, BedWidth - 1, BedHeight - _titleHeight - 1);
            _rectBotton = new Rectangle(0, BedHeight - _bottomHeight, BedWidth - 1, _bottomHeight);
        }
        /// <summary>
        /// 床头卡鼠标进入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bed_MouseEnter(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 床头卡鼠标离开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bed_MouseLeave(object sender, EventArgs e)
        {
            //((UserControl)sender).Invalidate(new Rectangle(0, 0, 1, 1));
            //this.Invalidate();
        }
        /// <summary>
        /// 床头卡鼠标Up事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bed_MouseUp(object sender, MouseEventArgs e)
        {
            BedInfo Bed = ((BedItem)sender).Bed; //(BedInfo)((UserControl)sender).Tag;
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = ((UserControl)sender).CreateGraphics();
                SetButtonStatus(g, pbNew, ButtonState.bsSelected, true, Bed);
            }
        }
        /// <summary>
        /// 床头卡鼠标Down事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                BedInfo Bed = ((BedItem)sender).Bed; //(BedInfo)((UserControl)sender).Tag;
                _selectedBedIndex = ((BedItem)sender).BedIndex;//放SelectedBed的前面
                SelectedBed = Bed;
                lastSelectedBedIndex = flpBed.Controls.IndexOf((UserControl)sender);

                if (Bed.IsUsed)
                {
                    Graphics g = ((UserControl)sender).CreateGraphics();
                    SetButtonStatus(g, pbNew, ButtonState.bsButtonDown, false, Bed);
                }
            }
        }
        /// <summary>
        /// 床头卡鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bed_MouseMove(object sender, MouseEventArgs e)
        {
            BedInfo Bed = ((BedItem)sender).Bed; //(BedInfo)((UserControl)sender).Tag;
            Graphics g = ((UserControl)sender).CreateGraphics();
            PointButton _pbNew = PointButton.pbNone;


            if (Bed.IsUsed && _selectedBed != null && Bed.Equals(_selectedBed))
            //if (Bed.IsUsed)
            {
                Point flpBedPoint = flpBed.PointToClient(Control.MousePosition); //鼠标相对于容器左上角的坐标
                if (MouseInRect(e.X, e.Y, _rectHeadPage))
                {
                    _pbNew = PointButton.pbHeadPage;
                    toolTip1.Show("病案首页", this, flpBedPoint.X + _rectHeadPage.Width, flpBedPoint.Y - _rectHeadPage.Height, 2000);
                }
                else if (MouseInRect(e.X, e.Y, _rectTemperature))
                {
                    _pbNew = PointButton.pbTemperature;
                    toolTip1.Show("体温单", this, flpBedPoint.X + _rectTemperature.Width, flpBedPoint.Y - _rectTemperature.Height, 2000);
                }
                else if (MouseInRect(e.X, e.Y, _rectAdvice))
                {
                    _pbNew = PointButton.pbAdvice;
                    toolTip1.Show("医嘱", this, flpBedPoint.X + _rectAdvice.Width, flpBedPoint.Y - _rectAdvice.Height, 2000);
                }
                else if (MouseInRect(e.X, e.Y, _rectApply))
                {
                    _pbNew = PointButton.pbApply;
                    toolTip1.Show("特殊申请", this, flpBedPoint.X + _rectApply.Width, flpBedPoint.Y - _rectApply.Height, 2000);
                }
            }
            if (Bed.IsUsed || !_UnUseBedNo)
            {
                _rectBed = new Rectangle(1, 1, _bedWidth, _rectTitle.Height - 2);
            }
            else
            {
                _rectBed = new Rectangle((int)(_rectTitle.Width - _bedWidth) / 2, 1, _bedWidth, _titleHeight - 2);
            }
            //_rectBed = new Rectangle(1, 1, _bedWidth, _rectTitle.Height - 2);

            if (MouseInRect(e.X, e.Y, _rectBed))
                _pbNew = PointButton.pbTitle;

            //鼠标指向的按钮没有变化
            if (pbNew != _pbNew)
            {
                if (pbNew != PointButton.pbNone)
                {
                    if (pbNew == PointButton.pbTitle)
                        ((UserControl)sender).Invalidate(_rectBed);
                    else if (pbNew == PointButton.pbHeadPage)
                        ((UserControl)sender).Invalidate(_rectHeadPage);
                    else if (pbNew == PointButton.pbTemperature)
                        ((UserControl)sender).Invalidate(_rectTemperature);
                    else if (pbNew == PointButton.pbAdvice)
                        ((UserControl)sender).Invalidate(_rectAdvice);
                    else if (pbNew == PointButton.pbApply)
                        ((UserControl)sender).Invalidate(_rectApply);
                }
                pbNew = _pbNew;
                SetButtonStatus(g, pbNew, ButtonState.bsSelected, false, Bed);
            }
        }
        /// <summary>
        /// 床头卡绘制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void bed_Paint(object sender, PaintEventArgs e)
        {
            BedInfo _bed = ((BedItem)sender).Bed; //(BedInfo)((UserControl)sender).Tag;

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            DrawBackGroup(e, _bed);
            DrawTitle(e, _bed);
            if (!_Simple)
            {
                DrawContext(e, _bed);
            }
            DrawBottom(e, _bed);

        }
        #endregion


        #region 画床位
        /// <summary>
        /// 画背景色
        /// </summary>
        /// <param name="e"></param>
        /// <param name="_bed"></param>
        private void DrawBackGroup(PaintEventArgs e, BedInfo _bed)
        {
            //选中时床卡颜色
            if (SelectedBed != null && SelectedBed.Equals(_bed))
            {
                //蓝色:8DEEEE
                //浅黄:fff7eb
                //浅黄+1:fdedd5
                //浅蓝:e4f1ff
                DrawRectangleBackGroup(e.Graphics, _rectTitle,
                    ColorTranslator.FromHtml("#fff7eb"),
                    ColorTranslator.FromHtml("#fdedd5"),
                    _BorderColor, 0);
                DrawRectangleBackGroup(e.Graphics, _rectContext,
                                    ColorTranslator.FromHtml("#fff7eb"),
                                    ColorTranslator.FromHtml("#fdedd5"),
                                    _BorderColor, 2);

             }
            //
            else
            {
                DrawRectangleBackGroup(e.Graphics, _rectTitle,
                    Color.White,
                    ColorTranslator.FromHtml("#e4f1ff"),
                    _BorderColor, 0);
                DrawRectangleBackGroup(e.Graphics, _rectContext,
                                    Color.White,
                                    ColorTranslator.FromHtml("#e4f1ff"),
                                    _BorderColor, 2);

            }

            //DrawFilter(_rectTitle, Color.FromArgb(241, 251, 252), Color.FromArgb(213, 221, 234), LinearGradientMode.Vertical, e.Graphics);

            e.Graphics.DrawRectangle(new Pen(_BorderColor), _rectTitle);
            //e.Graphics.DrawLine(new Pen(_BorderColor), _rectTitle.Width, _rectTitle.Top, _rectTitle.Width, _rectTitle.Height);
        }
        //画床位卡内部背景色
        public void DrawFilter(Rectangle rect, Color c1, Color c2, LinearGradientMode mode, Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            LinearGradientBrush lBrush = new LinearGradientBrush(rect, c1, c2, mode);
            g.FillRectangle(lBrush, rect);
        }
        /// <summary>
        /// 调用DrawFilter 画矩形背景
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="c1">开始色</param>
        /// <param name="c2">结束色</param>
        /// <param name="clrBorder">边框色</param>
        /// <param name="iBorderWidth"></param>
        public void DrawRectangleBackGroup(Graphics g, Rectangle rect, Color c1, Color c2, Color clrBorder, int iBorderWidth)
        {
            DrawFilter(rect, c1, c2, LinearGradientMode.Vertical, g);
            Pen pen = new Pen(clrBorder, iBorderWidth);
            if (iBorderWidth > 0)
                g.DrawRectangle(pen, rect.Left, rect.Top, rect.Width, rect.Height);
        }
        /// <summary>
        /// 调用DrawFilter 画圆形背景
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="c1">开始色</param>
        /// <param name="c2">结束色</param>
        /// <param name="clrBorder">边框色</param>
        /// <param name="iBorderWidth"></param>
        public void DrawEllipseBackGroup(Graphics g, Rectangle rect, Color c1, Color c2, Color clrBorder, int iBorderWidth)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            LinearGradientBrush lBrush = new LinearGradientBrush(rect, c1, c2, LinearGradientMode.Vertical);
            g.FillEllipse(lBrush, rect);

            Pen pen = new Pen(clrBorder, iBorderWidth);
            if (iBorderWidth > 0)
                g.DrawEllipse(pen, rect.Left, rect.Top, rect.Width, rect.Height);
        }

        /// <summary>
        /// 画床位卡头 包床的床头卡背景为绿色   出院医嘱的病人名字红色
        /// </summary>
        /// <param name="e"></param>
        /// <param name="_bed"></param>
        private void DrawTitle(PaintEventArgs e, BedInfo _bed)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Font font = new Font(Font.FontFamily, 10.5f, FontStyle.Bold);
            SizeF fontsize = e.Graphics.MeasureString(_bed.BedNo, font);

            int iX = 1;
            int iY = _rectBed.Top + (int)(((float)_rectBed.Height - fontsize.Height) / 2) + 1;

            if (_bed.IsUsed == false)  //未使用状态, 在中间画标题
            {
                //重新计算标题栏的位置
                if (_UnUseBedNo)
                {
                    _rectBed = new Rectangle((int)(_rectTitle.Width - _bedWidth) / 2, 1, _bedWidth, _titleHeight - 2);
                }
                else
                {
                    _rectBed = new Rectangle(iX, 1, _bedWidth, _rectTitle.Height - 2);
                }
                e.Graphics.DrawString(_bed.BedNo, font,
                                        Brushes.Black,
                                        _rectBed.Left + (_bedWidth - fontsize.Width) / 2,
                                        _rectBed.Top + (_rectBed.Height - fontsize.Height) / 2 + 1);
            }
            else
            {
                //1.画床位号   
                _rectBed = new Rectangle(iX, 1, _bedWidth, _rectTitle.Height - 2);
                //包床标志时，需要绘制包床背景
                if (_bed.Group)
                    DrawRectangleBackGroup(e.Graphics, _rectBed, ColorTranslator.FromHtml("#B4EEB4"), ColorTranslator.FromHtml("#B4EEB4"), Color.DarkGreen, 0);
                //ColorTranslator.FromHtml("#B3EE3A")   Color.FromArgb(255, 244, 230) Color.FromArgb(255, 209, 146) 
                //e.Graphics.DrawString(_bed.BedNo, font, Brushes.Black,
                //                _rectBed.Left + (_rectBed.Width - fontsize.Width) / 2,
                //                iY);
                e.Graphics.DrawString(_bed.BedNo, font, Brushes.Black,
                                       new Rectangle(_rectBed.Left + (int)(_rectBed.Width - fontsize.Width) / 2,
                                                     iY,
                                                     iX + (int)Math.Ceiling(fontsize.Width),
                                                    (int)fontsize.Height));

                font = new Font(Font.FontFamily, 10f, FontStyle.Bold);
                //2.画姓名
                iX = iX + _bedWidth + 3;
                String sName = _bed.PatientName;
                if (sName.Length > 0)
                {
                    fontsize = e.Graphics.MeasureString(sName, Font);
                    e.Graphics.DrawString(sName, font,
                                (_bed.Step == 1) ? new SolidBrush(ColorTranslator.FromHtml("#c34953")) : Brushes.Black,
                                new Rectangle(iX,
                                                iY,
                                                iX + (int)Math.Ceiling(fontsize.Width),
                                                (int)fontsize.Height));
                    //e.Graphics.DrawLine(new Pen(_BorderColor),_rectBed.Width, _rectTitle.Top, _rectBed.Width, _rectTitle.Height);
                }
                
                if (!_Simple)
                {
                    //3.画年龄
                    String sAge = _bed.Age;
                    if (sAge.Length > 0)
                    {

                        fontsize = e.Graphics.MeasureString(sAge, Font);
                        e.Graphics.DrawString(sAge, font,
                                    Brushes.Black,
                                    new Rectangle(BedWidth - (int)Math.Ceiling(fontsize.Width) - 4,
                                                iY,
                                                (int)Math.Ceiling(fontsize.Width) + 4,
                                                (int)fontsize.Height));
                        // e.Graphics.DrawLine(new Pen(_BorderColor), _rectBed.Width, _rectTitle.Top,_rectBed.Width, _rectTitle.Height);
                    }
                    //4.显示男女图标   
                    int iImageSize = 14;
                    iX = (int)Math.Ceiling(fontsize.Width) + iImageSize;
                    Rectangle rect = new Rectangle(BedWidth - iX-3, 
                                            iY,
                                                iImageSize, iImageSize);
                    if (_bed.Sex == "男")
                        e.Graphics.DrawImage(Resources.男, rect,
                                         new Rectangle(0, 0, Resources.男.Width, Resources.男.Height), GraphicsUnit.Pixel);
                    else if (_bed.Sex == "女")
                        e.Graphics.DrawImage(Resources.女, rect,
                                         new Rectangle(0, 0, Resources.女.Width, Resources.女.Height), GraphicsUnit.Pixel);
                }
            }
        }
        /// <summary>
        /// 画内容板
        /// </summary>
        /// <param name="e"></param>
        /// <param name="_bed"></param>
        private void DrawContext(PaintEventArgs e, BedInfo _bed)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Font font = new Font(Font.FontFamily, 10.5f, FontStyle.Regular);
            SizeF fontsize = e.Graphics.MeasureString(_bed.BedNo, font);
            int iLeftMargin = 8;
            int iTopMargin = 5;
            int iRow = 0;
            if (_bed.IsUsed == true)  //未使用状态,不需要画
            {
                //显示卡片内容
                int lastfRowHeight = _rectContext.Top + iTopMargin + iTopMargin;
                for (int i = 0; i < BedContextFields.Count; i++)
                {
                    string fvalue = Tools.ToString(_bed.GetType().GetProperty(BedContextFields[i].DataPropertyName).GetValue(_bed, null));
                    if (BedContextFields[i].FieldName.Contains("住院号"))
                    {
                        //如果本行内容超过一行，画的高度变成内容的高度
                        e.Graphics.DrawString(fvalue, BedContextFields[i].fieldFontContext, BedContextFields[i].fontBrushContext, iLeftMargin, lastfRowHeight);
                    }
                    else if (BedContextFields[i].FieldName.Replace(" ", "").Contains("科室"))
                    {
                        //科室内容的宽度
                        int iDeptWidth = (int)(e.Graphics.MeasureString(fvalue, BedContextFields[i].fieldFontHead).Width) + 4;
                        e.Graphics.DrawString(fvalue, BedContextFields[i].fieldFontContext, BedContextFields[i].fontBrushContext, BedWidth- iDeptWidth, lastfRowHeight);
                    }
                    else
                    {
                        iRow+=1;
                        string fname = BedContextFields[i].FieldName + ":";
                        //标题的宽度
                        int iNameWidth = (int)(e.Graphics.MeasureString(fname, BedContextFields[i].fieldFontHead).Width) + 4;
                        //内容的宽度
                        int iValueWidth = _rectContext.Width - iNameWidth;
                        int iRowTop = lastfRowHeight;

                        if (iRow > 0)//如果上一行内容超过一行,Y向下移
                        {
                            string _fvalue = Tools.ToString(typeof(BedInfo).GetProperty(BedContextFields[i - 1].DataPropertyName).GetValue(_bed, null));
                            _fvalue = _fvalue == "" ? "测试" : _fvalue;
                            SizeF _fontsize = e.Graphics.MeasureString(_fvalue, BedContextFields[i - 1].fieldFontContext);
                            //每个值都只占一行，所以这里的计算间隔可暂时忽略
                            float _frowheight = 1*_fontsize.Height;//((int)(_fontsize.Width / iValueWidth) + 1) * _fontsize.Height;
                            iRowTop = lastfRowHeight + (int)_frowheight+ iTopMargin;
                        }
                        lastfRowHeight = iRowTop;

                        //如果本行内容超过一行，画的高度变成内容的高度
                        SizeF _fontsizeC = e.Graphics.MeasureString(fvalue, BedContextFields[i].fieldFontContext);
                        int iRowCount = (int)Math.Ceiling(_fontsizeC.Width / iValueWidth);
                        if (iRowCount > 1)
                        {
                            fvalue = fvalue.Substring(0, fvalue.Length / iRowCount  - 1) + "..";
                        }
                        float _frowheightC = iRowCount*_fontsizeC.Height;
                        int _fRowHeight = (int)_frowheightC;

                        e.Graphics.DrawString(fname, BedContextFields[i].fieldFontHead, BedContextFields[i].fontBrushHead, iLeftMargin, iRowTop);
                        if (BedFormatStyleEvent != null)
                        {
                            System.Drawing.Font _font = (Font)BedContextFields[i].fieldFontContext.Clone();
                            System.Drawing.Brush _brush = (Brush)BedContextFields[i].fontBrushContext.Clone();
                            BedFormatStyleEvent(_bed, BedContextFields[i].DataPropertyName, ref _font, ref _brush);

                            e.Graphics.DrawString(fvalue, _font, _brush, new Rectangle(iNameWidth, iRowTop, iValueWidth, _fRowHeight));
                        }
                        else
                        {
                            e.Graphics.DrawString(fvalue, BedContextFields[i].fieldFontContext, BedContextFields[i].fontBrushContext, new Rectangle(iNameWidth, iRowTop, iValueWidth, _fRowHeight));
                        }
                    }
                }
            }
            else
            {
                if (SelectedBed != null && SelectedBed.Equals(_bed))
                {
                    int iUnUseHeight = BedHeight - _titleHeight;
                    int iLeft = (BedWidth - Resources.空床图2.Width) / 2;
                    int iTop = (iUnUseHeight - Resources.空床图2.Height) / 2 + _titleHeight;
                    //画空床  
                    Rectangle rect = new Rectangle(iLeft, iTop, Resources.空床图2.Width, Resources.空床图2.Height);
                    e.Graphics.DrawImage(Resources.空床图2, rect,
                                             new Rectangle(0, 0, Resources.空床图2.Width, Resources.空床图2.Height), GraphicsUnit.Pixel);
                }
                else
                {
                    int iUnUseHeight = BedHeight - _titleHeight;
                    int iLeft = (BedWidth - Resources.空床图.Width) / 2;
                    int iTop = (iUnUseHeight - Resources.空床图.Height) / 2 + _titleHeight;
                    //画空床  
                    Rectangle rect = new Rectangle(iLeft, iTop, Resources.空床图.Width, Resources.空床图.Height);
                    e.Graphics.DrawImage(Resources.空床图, rect,
                                             new Rectangle(0, 0, Resources.空床图.Width, Resources.空床图.Height), GraphicsUnit.Pixel);
                }
            }
        }
        /// <summary>
        /// 画底部
        /// </summary>
        /// <param name="e"></param>
        /// <param name="_bed"></param>
        private void DrawBottom(PaintEventArgs e, BedInfo _bed)
        {
            if (_bed.IsUsed == true)  //未使用状态,不需要画
            {
                e.Graphics.DrawLine(new Pen(_BorderColor), 0, BedHeight-_bottomHeight, BedWidth, BedHeight - _bottomHeight);
                //画图标
                int _imgHeight = _bottomHeight-10;
                int _imgWidth = _imgHeight;
                
                int _imgX = 8;
                int _imgY = BedHeight - _bottomHeight;
                int _iXMargin = 4;

                _rectDietType = new Rectangle(_imgX, (_imgY + (_bottomHeight - _imgHeight)/2), (int)Math.Ceiling(_imgWidth * 2.5), (int)_imgHeight);
                _imgX = _imgX + (int)Math.Ceiling(_imgWidth * 2.5)+ _iXMargin + 2;
                _rectNurse = new Rectangle(_imgX , (_imgY + (_bottomHeight - _imgHeight) / 2), (int)_imgWidth,                      (int)_imgHeight);
                _imgX = _imgX + (int)_imgWidth+ _iXMargin;
                _rectHeadPage = new Rectangle(_imgX , (_imgY + (_bottomHeight - _imgHeight) / 2), (int)_imgWidth,                   (int)_imgHeight);
                
                _imgX = _imgX + (int)_imgWidth + _iXMargin;
                _rectAdvice = new Rectangle(_imgX , (_imgY + (_bottomHeight - _imgHeight) / 2), (int)_imgWidth,                     (int)_imgHeight);
                _imgX = _imgX + (int)_imgWidth + _iXMargin;
                _rectApply = new Rectangle(_imgX , (_imgY + (_bottomHeight - _imgHeight) / 2), (int)_imgWidth,                      (int)_imgHeight);
                _imgX = _imgX + (int)_imgWidth + _iXMargin;
                _rectTemperature = new Rectangle(_imgX, (_imgY + (_bottomHeight - _imgHeight) / 2), (int)_imgWidth, (int)_imgHeight);
                //画图标按钮
                //if (_bed.IsUsed == true && _selectedBed != null && _bed.Equals(_selectedBed))  //未使用状态, 在中间画标题
                //{
                DrawSituation(e, _bed);
                DrawDietType(e, _bed);
                DrawNurse(e, _bed);
                if (!_Simple)
                {
                    DrawButton(e.Graphics, _rectHeadPage, Resources.医嘱2, ButtonState.bsNormal);
                    DrawButton(e.Graphics, _rectTemperature, Resources.体温单2, ButtonState.bsNormal);
                    DrawButton(e.Graphics, _rectAdvice, Resources.病案首页2, ButtonState.bsNormal);
                    DrawButton(e.Graphics, _rectApply, Resources.特殊治疗2, ButtonState.bsNormal);
                }
                //}
            }
        }
        /// <summary>
        /// 画病人情况  1病重-黄色-#f8ac59 4病危-红色-#e60012  蓝色-#3c649e 其他不需要
        /// </summary>
        /// <param name="e"></param>
        /// <param name="_bed"></param>
        private void DrawSituation(PaintEventArgs e, BedInfo _bed)
        {
            Color cSituation = ColorTranslator.FromHtml("#d0d7e5");
            if (_bed.Situation != null)
            {
                if (_bed.Situation.Contains("1"))
                {
                    cSituation = ColorTranslator.FromHtml("#f8ac59");
                }
                else if (_bed.Situation.Contains("4"))
                {
                    cSituation = ColorTranslator.FromHtml("#e60012");
                }
            }
            e.Graphics.DrawLine(new Pen(cSituation,2), 0, _rectTitle.Height, _rectTitle.Width, _rectTitle.Height);
        }

        /// <summary>
        /// 画护饮食种类
        /// </summary>
        /// <param name="e"></param>
        /// <param name="_bed"></param>
        private void DrawDietType(PaintEventArgs e, BedInfo _bed)
        {
            String sText;
            Brush fontBrush = Brushes.White;
            Font font = new Font(Font.FontFamily, 9.0f, FontStyle.Bold);
            if (string.IsNullOrEmpty(_bed.DietType))
            {
                DrawRectangleBackGroup(e.Graphics, _rectDietType, ColorTranslator.FromHtml("#6188B5"), ColorTranslator.FromHtml("#6188B5"), _BorderColor, 1);
                sText = "普食";
            }
            else
            {                
                switch (_bed.DietType)
                {
                    case "1":
                        DrawRectangleBackGroup(e.Graphics, _rectDietType, ColorTranslator.FromHtml("#6188B5"), ColorTranslator.FromHtml("#6188B5"), _BorderColor, 1);
                        sText = "普食";
                        break;
                    case "2":
                        DrawRectangleBackGroup(e.Graphics, _rectDietType, ColorTranslator.FromHtml("#cd5502"), ColorTranslator.FromHtml("#cd5502"), _BorderColor, 1);
                        sText = "半流质";
                        break;
                    case "3":
                        DrawRectangleBackGroup(e.Graphics, _rectDietType, ColorTranslator.FromHtml("#f8ac59"), ColorTranslator.FromHtml("#f8ac59"), _BorderColor, 1);
                        sText = "流质";
                        fontBrush = Brushes.White;
                        break;
                    case "4":
                        DrawRectangleBackGroup(e.Graphics, _rectDietType, ColorTranslator.FromHtml("#638c0b"), ColorTranslator.FromHtml("#638c0b"), _BorderColor, 1);
                        sText = "治疗食";
                        break;
                    case "5":
                        DrawRectangleBackGroup(e.Graphics, _rectDietType, ColorTranslator.FromHtml("#c34953"), ColorTranslator.FromHtml("#c34953"), _BorderColor, 1);
                        sText = "禁食";
                        break;
                    default:
                        DrawRectangleBackGroup(e.Graphics, _rectDietType, ColorTranslator.FromHtml("#6188B5"), ColorTranslator.FromHtml("#6188B5"), _BorderColor, 1);
                        sText = "普食";
                        break;
                }
            }
            SizeF fontsize = e.Graphics.MeasureString(sText, font);

            e.Graphics.DrawString(sText, font, fontBrush,
                                    _rectDietType.Left + (int)Math.Ceiling((_rectDietType.Width - fontsize.Width) / 2),
                                    _rectDietType.Top + (int)Math.Ceiling((_rectDietType.Height - fontsize.Height) / 2 + 1));
        }
        /// <summary>
        /// 画护理级别
        /// </summary>
        /// <param name="e"></param>
        /// <param name="_bed"></param>
        private void DrawNurse(PaintEventArgs e, BedInfo _bed)
        {
            if (string.IsNullOrEmpty(_bed.NursingLever))
                return;

            String sText;
            Brush fontBrush = Brushes.White;
            Font font = new Font(Font.FontFamily, 9.0f, FontStyle.Bold);
            switch (_bed.NursingLever)
            {
                case "1":
                    DrawEllipseBackGroup(e.Graphics, _rectNurse, ColorTranslator.FromHtml("#cd5502"), ColorTranslator.FromHtml("#cd5502"), ColorTranslator.FromHtml("#cd5502"), 1);
                    sText = "Ⅰ";
                    break;
                case "2":
                    DrawEllipseBackGroup(e.Graphics, _rectNurse, ColorTranslator.FromHtml("#f8ac59"), ColorTranslator.FromHtml("#f8ac59"), ColorTranslator.FromHtml("#f8ac59"), 1);
                    sText = "Ⅱ";
                    break;
                case "3":
                    DrawEllipseBackGroup(e.Graphics, _rectNurse, ColorTranslator.FromHtml("#6188b5"), ColorTranslator.FromHtml("#6188b5"), ColorTranslator.FromHtml("#6188b5"), 1);
                    sText = "Ⅲ";
                    fontBrush = Brushes.White;
                    break;
                case "4":
                    DrawEllipseBackGroup(e.Graphics, _rectNurse, ColorTranslator.FromHtml("#c34953"), ColorTranslator.FromHtml("#c34953"), ColorTranslator.FromHtml("#c34953"), 1);
                    sText = "特";
                    break;
                default:
                    return;
            }
            
            SizeF fontsize = e.Graphics.MeasureString(sText, font);
            e.Graphics.DrawString(sText, font, fontBrush,
                _rectNurse.Left + (int)Math.Ceiling((_rectNurse.Width - fontsize.Width) / 2),
                _rectNurse.Top + (int)Math.Ceiling((_rectNurse.Height - fontsize.Height) / 2 + 1));
        }
        /// <summary>
        /// 画按钮
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <param name="img"></param>
        /// <param name="bsState"></param>
        private void DrawButton(Graphics g, Rectangle rect, Image img, ButtonState bsState)
        {
            if (bsState == ButtonState.bsSelected)
            {
                DrawRectangleBackGroup(g, rect, Color.FromArgb(255, 244, 230), Color.FromArgb(255, 209, 146),
                                Color.FromArgb(194, 170, 120), 0);
                
            }
            else if (bsState == ButtonState.bsButtonDown)
                DrawRectangleBackGroup(g, rect, Color.FromArgb(243, 196, 98), Color.FromArgb(255, 228, 138),
                                Color.FromArgb(194, 126, 48), 0);
            if (img != null)
            {
                g.DrawImage(img, new Rectangle(rect.Left + (rect.Width - img.Width) / 2,
                                rect.Top + (rect.Height - img.Height) / 2, img.Width, img.Height),
                            new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            }
        }
        private void DrawButton(Graphics g, Rectangle rect, String sText, Font font, ButtonState bsState)
        {
            if (bsState == ButtonState.bsSelected)
            {
                DrawRectangleBackGroup(g, rect, Color.FromArgb(255, 244, 230), Color.FromArgb(255, 209, 146),
                                Color.FromArgb(194, 170, 120), 0);
            }
            else if (bsState == ButtonState.bsButtonDown)
            {
                DrawRectangleBackGroup(g, rect, Color.FromArgb(243, 196, 98), Color.FromArgb(255, 228, 138),
                                Color.FromArgb(194, 126, 48), 0);
            }
            SizeF fontsize = g.MeasureString(sText, font);
            g.DrawString(sText, font, Brushes.Navy, rect.Left + (rect.Width - fontsize.Width) / 2,
                                        rect.Top + (rect.Height - fontsize.Height) / 2 + 1);
        }
        /// <summary>
        /// 判断鼠标是否在方框内
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        private bool MouseInRect(int X, int Y, Rectangle rect)
        {
            return X > rect.X && X < (rect.X + rect.Width) &&
                   Y > rect.Y && Y < (rect.Y + rect.Height);
        }
        /// <summary>
        /// 设置按钮状态
        /// </summary>
        /// <param name="g"></param>
        /// <param name="button"></param>
        /// <param name="state"></param>
        /// <param name="bFireEvent"></param>
        /// <param name="_bed"></param>
        private void SetButtonStatus(Graphics g, PointButton button, ButtonState state, bool bFireEvent, BedInfo _bed)
        {
            BedCardClickEventArgs eventargs = new BedCardClickEventArgs(_bed.BedNo, _bed.PatientID);
            switch (button)
            {
                case PointButton.pbTitle:
                    {
                        Font font = new Font(Font.FontFamily, 10.5f, FontStyle.Bold);
                        DrawButton(g, _rectBed, _bed.BedNo, font, state);
                        if (bFireEvent && BedTitleClick != null)
                        {
                            eventargs.CommandParameter = "床位号";
                            BedTitleClick(this, eventargs);
                        }
                        break;
                    }
                case PointButton.pbHeadPage:
                    DrawButton(g, _rectHeadPage, Resources.医嘱2, state);
                    if (bFireEvent && HeadPageClick != null)
                    {
                        eventargs.CommandParameter = "病历首页";
                        HeadPageClick(this, eventargs);
                    }
                    break;
                case PointButton.pbTemperature:
                    DrawButton(g, _rectTemperature, Resources.体温单2, state);
                    if (bFireEvent && TemperatureClick != null)
                    {
                        eventargs.CommandParameter = "体温单";
                        TemperatureClick(this, eventargs);
                    }
                    break;
                case PointButton.pbAdvice:
                    DrawButton(g, _rectAdvice, Resources.病案首页2, state);
                    if (bFireEvent && AdviceClick != null)
                    {
                        eventargs.CommandParameter = "住院医嘱";
                        AdviceClick(this, eventargs);
                    }
                    break;
                case PointButton.pbApply:
                    DrawButton(g, _rectApply, Resources.特殊治疗2, state);
                    if (bFireEvent && ApplyFormClick != null)
                    {
                        eventargs.CommandParameter = "特殊治疗";
                        ApplyFormClick(this, eventargs);
                    }
                    break;
            }
        }

        #endregion
    }
    #region 结构定义
    public class BedCardClickEventArgs : EventArgs
    {
        private string _bedNumber = "";
        private int _patientid = 0;
        private string _CommandParameter = "";      //命令参数
        public BedCardClickEventArgs(string bed, int patientid)
        {
            this._bedNumber = bed;
            this._patientid = patientid;
        }
        public string BedNumber
        {
            get { return _bedNumber; }
            set { _bedNumber = value; }
        }
        public int PatientID
        {
            get { return _patientid; }
            set { _patientid = value; }
        }
        public string CommandParameter
        {
            get { return _CommandParameter; }
            set { _CommandParameter = value; }
        }
    }

    public delegate void OnButtonClick(object sender, BedCardClickEventArgs e);
    //床位内容样式格式化
    public delegate void BedFormatStyle(BedInfo bed, string dataPropertyName, ref Font contextFont, ref Brush contextBrush);
    /// <summary>
    /// 按钮状态
    /// </summary>
    public enum ButtonState
    {
        bsNormal,       //正常状态
        bsSelected,     //鼠标移到按钮之上
        bsButtonDown,   //按钮被按下
    }

    public enum PointButton        //当前鼠标指向的按钮
    {
        pbNone,             //未指定
        pbTitle,            //标题按钮
        pbGroup,            //标题按钮右击,用于选择分组
        pbHeadPage,         //病案首页按钮
        pbTemperature,      //体温单按钮
        pbAdvice,           //医嘱按钮
        pbApply,            //医嘱申请单按钮
    }
    [Serializable]
    public class ContextField
    {
        public ContextField()
        {

        }
        public ContextField(string fieldName, string dataPropertyName)
        {
            FieldName = fieldName;
            DataPropertyName = dataPropertyName;
        }

        public ContextField(string fieldName, string dataPropertyName, Font fontHead, Font fontContext, Brush brushHead, Brush brushContext)
        {
            FieldName = fieldName;
            DataPropertyName = dataPropertyName;
            fieldFontHead = fontHead;
            fieldFontContext = fontContext;
            fontBrushHead = brushHead;
            fontBrushContext = brushContext;
        }

        public string FieldName { get; set; }
        public string DataPropertyName { get; set; }
        private Font _font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        public Font fieldFontHead
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }
        //private Brush _brush= new SolidBrush(Color.FromArgb(21, 66, 139));
        private Brush _brush = new SolidBrush(ColorTranslator.FromHtml("#999999"));
        public Brush fontBrushHead
        {
            get
            {
                return _brush;
            }
            set
            {
                _brush = value;
            }
        }
        private Font _font1 = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        public Font fieldFontContext
        {
            get
            {
                return _font1;
            }
            set
            {
                _font1 = value;
            }
        }
        //private Brush _brush1 = new SolidBrush(Color.FromArgb(21, 66, 139));
        private Brush _brush1 = new SolidBrush(ColorTranslator.FromHtml("#333333"));
        public Brush fontBrushContext
        {
            get
            {
                return _brush1;
            }
            set
            {
                _brush1 = value;
            }
        }
    }
    #endregion
}
