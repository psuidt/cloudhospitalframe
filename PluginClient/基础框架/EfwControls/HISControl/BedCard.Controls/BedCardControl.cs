using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EfwControls.Common.Licensing;
using EfwControls.Properties;
using EfwControls.Common;

namespace EfwControls.HISControl.BedCard.Controls
{
    [LicenseProvider(typeof(EfwControls.Common.Licensing.ComponentLicenseProvider))]
    public partial class BedCardControl : UserControl
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
            //CheckLicense();
        }
        #endregion

        public BedCardControl()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.Font = new Font("宋体", 10.0f);

            flpBed.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(flpBed, true, null);  
        }

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
                    //this.Invalidate();
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
                //if (SelectedBed != null && _datasource != null)
                //{
                //    return _datasource.FindIndex(x => x == SelectedBed);
                //}
                //else
                //    return -1;
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

        private int _BedWidth = 162;
        [Description("床位宽度")]
        public int BedWidth
        {
            get { return _BedWidth; }
            set { _BedWidth = value; }
        }

        private int _BedHeight = 160;
        [Description("床位高度")]
        public int BedHeight
        {
            get { return _BedHeight; }
            set { _BedHeight = value; }
        }
        

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
        private Rectangle _rectTitle;       //标题区位置
        private Rectangle _rectContext;     //内容区
        private Rectangle _rectBed;         //床号显示区域
        private Rectangle _rectNurse;       //病人类型按钮区域
        private Rectangle _rectHeadPage;    //病案首页
        private Rectangle _rectTemperature; //体温单
        private Rectangle _rectAdvice;      //医嘱
        private Rectangle _rectApply;       //申请单
        private Color _BorderColor;         //边框线颜色
        #endregion

        private int lastSelectedBedIndex = -1;
        private PointButton pbNew = PointButton.pbNone;
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
                    bed.MouseLeave += new EventHandler(bed_MouseLeave);
                    bed.Resize += new EventHandler(bed_Resize);


                    _rectTitle = new Rectangle(0, 0, BedWidth - 1, 25);
                    _rectContext = new Rectangle(0, _rectTitle.Height, _BedWidth - 1, _BedHeight - _rectTitle.Height - 1);
                    _rectBed = new Rectangle(1, 1, 40, _rectTitle.Height - 2);

                    flpBed.Controls.Add(bed);
                }
                flpBed.ResumeLayout(true);
            }
        }

        #region 床位事件
        void bed_DoubleClick(object sender, EventArgs e)
        {
            if (BedDoubleClick != null)
                BedDoubleClick(sender, e);
        }

        void bed_Click(object sender, EventArgs e)
        {
            if (BedClick != null)
                BedClick(sender, e);
        }

        void bed_Resize(object sender, EventArgs e)
        {
            _rectTitle = new Rectangle(0, 0, _BedWidth - 1, 25);
            _rectContext = new Rectangle(0, _rectTitle.Height, _BedWidth - 1, _BedHeight - _rectTitle.Height - 1);
        }

        void bed_MouseLeave(object sender, EventArgs e)
        {
            //((UserControl)sender).Invalidate(new Rectangle(0, 0, 1, 1));
            //this.Invalidate();
        }

        void bed_MouseUp(object sender, MouseEventArgs e)
        {
            BedInfo Bed = ((BedItem)sender).Bed; //(BedInfo)((UserControl)sender).Tag;
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = ((UserControl)sender).CreateGraphics();
                SetButtonStatus(g, pbNew, ButtonState.bsSelected, true, Bed);
            }
        }

        void bed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button==MouseButtons.Right)
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

        void bed_MouseMove(object sender, MouseEventArgs e)
        {
            BedInfo Bed = ((BedItem)sender).Bed; //(BedInfo)((UserControl)sender).Tag;
            Graphics g = ((UserControl)sender).CreateGraphics();
            PointButton _pbNew = PointButton.pbNone;


            if (Bed.IsUsed && _selectedBed != null && Bed.Equals(_selectedBed))
            {
                if (MouseInRect(e.X, e.Y, _rectHeadPage))
                    _pbNew = PointButton.pbHeadPage;
                else if (MouseInRect(e.X, e.Y, _rectTemperature))
                    _pbNew = PointButton.pbTemperature;
                else if (MouseInRect(e.X, e.Y, _rectAdvice))
                    _pbNew = PointButton.pbAdvice;
                else if (MouseInRect(e.X, e.Y, _rectApply))
                    _pbNew = PointButton.pbApply;
            }
            if (Bed.IsUsed)
            {
                _rectBed = new Rectangle(1, 1, 30 + 26, _rectTitle.Height - 2);
            }
            else
            {

                _rectBed = new Rectangle((int)(_rectTitle.Width - 40) / 2,
                                        1, 40, _rectTitle.Height - 2);
            }

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

            //床号变亮
            //SetButtonStatus(g, PointButton.pbTitle, ButtonState.bsSelected, false, Bed);
        }
      
        void bed_Paint(object sender, PaintEventArgs e)
        {
            BedInfo _bed = ((BedItem)sender).Bed; //(BedInfo)((UserControl)sender).Tag;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            DrawBackGroup(e, _bed);
            DrawContext(e, _bed);
            //画图标按钮

            if (_bed.IsUsed == true && _selectedBed!=null && _bed.Equals(_selectedBed))  //未使用状态, 在中间画标题
            {
                DrawNurse(e, _bed);
                DrawButton(e.Graphics, _rectHeadPage, Resources.病案首页, ButtonState.bsNormal);
                DrawButton(e.Graphics, _rectTemperature, Resources.体温单, ButtonState.bsNormal);
                DrawButton(e.Graphics, _rectAdvice, Resources.医嘱, ButtonState.bsNormal);
                DrawButton(e.Graphics, _rectApply, Resources.特殊治疗, ButtonState.bsNormal);
            }
        }
        #endregion

        #region 画床位

        private void DrawBackGroup(PaintEventArgs e, BedInfo _bed)
        {
            if (SelectedBed!=null && SelectedBed.Equals(_bed))
            {
                _BorderColor = Color.FromArgb(194, 126, 48);
                DrawRectangleBackGroup(e.Graphics, _rectContext,
                                    Color.FromArgb(243, 196, 98),
                                    Color.FromArgb(255, 228, 138),
                                    _BorderColor, 2);
            }
            else
            {
                _BorderColor = Color.DarkKhaki;
                DrawRectangleBackGroup(e.Graphics, _rectContext,
                                    Color.FromArgb(251, 250, 247),
                                    Color.FromArgb(181, 181, 154),
                                    _BorderColor, 2);
            }

            DrawFilter(_rectTitle, Color.FromArgb(241, 251, 252), Color.FromArgb(213, 221, 234), LinearGradientMode.Vertical, e.Graphics);

            e.Graphics.DrawRectangle(new Pen(_BorderColor), _rectTitle);
            e.Graphics.DrawLine(new Pen(_BorderColor), _rectTitle.Width, _rectTitle.Top,
                            _rectTitle.Width, _rectTitle.Height);
        }

        public void DrawFilter(Rectangle rect, Color c1, Color c2, LinearGradientMode mode, Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            LinearGradientBrush lBrush = new LinearGradientBrush(rect, c1, c2, mode);
            g.FillRectangle(lBrush, rect);
        }

        public void DrawRectangleBackGroup(Graphics g, Rectangle rect, Color c1, Color c2, Color clrBorder, int iBorderWidth)
        {
            DrawFilter(rect, c1, c2, LinearGradientMode.Vertical, g);
            Pen pen = new Pen(clrBorder, iBorderWidth);
            if (iBorderWidth > 0)
                g.DrawRectangle(pen, rect.Left, rect.Top, rect.Width, rect.Height);
        }

        private void DrawContext(PaintEventArgs e, BedInfo _bed)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Font font = new Font(Font.FontFamily, 10.5f, FontStyle.Bold);
            SizeF fontsize = e.Graphics.MeasureString(_bed.BedNo, font);

            if (_bed.IsUsed == false)  //未使用状态, 在中间画标题
            {
                //重新计算标题栏的位置
                _rectBed = new Rectangle((int)(_rectTitle.Width - 40) / 2,
                                         1, 40, _rectTitle.Height - 2);
                e.Graphics.DrawString(_bed.BedNo, font,
                                        Brushes.Black,
                                        _rectBed.Left + (40 - fontsize.Width) / 2,
                                        _rectBed.Top + (_rectBed.Height - fontsize.Height) / 2 + 1);
                return;
            }

            _rectBed = new Rectangle(1, 1, 30+26, _rectTitle.Height - 2);
            //包床标志时，需要绘制包床背景
            if (_bed.Group)
                DrawRectangleBackGroup(e.Graphics, _rectBed, Color.Lime, Color.Green, Color.DarkGreen, 0);

            e.Graphics.DrawString(_bed.BedNo, font, Brushes.Black,
                            _rectBed.Left + (_rectBed.Width - fontsize.Width+20) / 2,
                            _rectBed.Top + (_rectBed.Height - fontsize.Height) / 2 + 1);
            font = new Font(Font.FontFamily, 10f, FontStyle.Bold);
            //显示男女图标
            //ResourceManager rm = new ResourceManager(typeof(BedCardControl));
            Rectangle rect = new Rectangle(_rectTitle.Left + 2, _rectTitle.Top + (_rectTitle.Height - 20) / 2 + 1, 24, 20);
            if (_bed.Sex == "男")
                e.Graphics.DrawImage(Resources.PatientMale, rect,
                                     new Rectangle(0, 0, Resources.PatientMale.Width, Resources.PatientMale.Height), GraphicsUnit.Pixel);
            else if (_bed.Sex == "女")
                e.Graphics.DrawImage(Resources.PatientFemale, rect,
                                     new Rectangle(0, 0, Resources.PatientFemale.Width, Resources.PatientFemale.Height), GraphicsUnit.Pixel);

            //显示姓名和年龄
            String sText = _bed.PatientName + "  " + _bed.Age;
            if (sText.Length > 0)
            {
                fontsize = e.Graphics.MeasureString(sText, Font);
                e.Graphics.DrawString(sText, font,
                            (_bed.Step >= 8) ? Brushes.Red : (_bed.Step == 6) ? Brushes.DodgerBlue : Brushes.Black,
                            new Rectangle(_rectBed.Left + _rectBed.Width + 3,
                            _rectBed.Top + (_rectBed.Height - (int)fontsize.Height) / 2,
                            _rectTitle.Width - _rectBed.Width - 6, (int)fontsize.Height));
                e.Graphics.DrawLine(new Pen(_BorderColor),
                                _rectBed.Width, _rectTitle.Top,
                                _rectBed.Width, _rectTitle.Height);
            }
            


            //画图标

            float _imgWidth = 20;
            float _imgHeight = 20;
            int _imgX = _rectContext.Width - 25;

            int _imgY = _rectContext.Top + 5;
            _rectNurse = new Rectangle(_imgX + 3, _imgY + 3, (int)_imgWidth - 6, (int)_imgHeight - 6);
            _imgY = _imgY + (int)_imgHeight;
            _rectHeadPage = new Rectangle(_imgX, _imgY, (int)_imgWidth, (int)_imgHeight);
            _imgY = _imgY + (int)_imgHeight;
            _rectTemperature = new Rectangle(_imgX, _imgY, (int)_imgWidth, (int)_imgHeight);
            _imgY = _imgY + (int)_imgHeight;
            _rectAdvice = new Rectangle(_imgX, _imgY, (int)_imgWidth, (int)_imgHeight);
            _imgY = _imgY + (int)_imgHeight;
            _rectApply = new Rectangle(_imgX, _imgY, (int)_imgWidth, (int)_imgHeight);

            //护理级别
            //DrawNurse(e, _bed);

            //显示卡片内容
            int lastfRowHeight = _rectContext.Top + 2;
            for (int i = 0; i < BedContextFields.Count; i++)
            {
                string fname = BedContextFields[i].FieldName + ":";
                string fvalue = Tools.ToString(_bed.GetType().GetProperty(BedContextFields[i].DataPropertyName).GetValue(_bed, null));
                //标题的宽度
                int iContextLeft = (int)(e.Graphics.MeasureString(fname, BedContextFields[i].fieldFontHead).Width) + 4;
                //内容的宽度
                int iContextWidth = _rectContext.Width - iContextLeft - 10;
                int iRowTop = lastfRowHeight;

                if (i > 0)//如果上一行内容超过一行,Y向下移
                {
                    string _fvalue = Tools.ToString(typeof(BedInfo).GetProperty(BedContextFields[i - 1].DataPropertyName).GetValue(_bed, null));
                    _fvalue = _fvalue == "" ? "测试" : _fvalue;
                    SizeF _fontsize = e.Graphics.MeasureString(_fvalue, BedContextFields[i - 1].fieldFontContext);
                    float _frowheight = ((int)(_fontsize.Width / iContextWidth) + 1) * _fontsize.Height;
                    iRowTop = lastfRowHeight + (int)_frowheight;
                }

                lastfRowHeight = iRowTop;

                //如果本行内容超过一行，画的高度变成内容的高度
                SizeF _fontsizeC = e.Graphics.MeasureString(fvalue, BedContextFields[i].fieldFontContext);
                float _frowheightC = ((int)(_fontsizeC.Width / iContextWidth) + 1) * _fontsizeC.Height;
                int _fRowHeight = (int)_frowheightC;

                e.Graphics.DrawString(fname, BedContextFields[i].fieldFontHead, BedContextFields[i].fontBrushHead, 3, iRowTop);
                if (BedFormatStyleEvent != null)
                {
                    System.Drawing.Font _font = (Font)BedContextFields[i].fieldFontContext.Clone();
                    System.Drawing.Brush _brush = (Brush)BedContextFields[i].fontBrushContext.Clone();
                    BedFormatStyleEvent(_bed, BedContextFields[i].DataPropertyName, ref  _font, ref  _brush);

                    e.Graphics.DrawString(fvalue, _font, _brush, new Rectangle(iContextLeft, iRowTop, iContextWidth, _fRowHeight));
                }
                else
                {
                    e.Graphics.DrawString(fvalue, BedContextFields[i].fieldFontContext, BedContextFields[i].fontBrushContext, new Rectangle(iContextLeft, iRowTop, iContextWidth, _fRowHeight));
                }
            }
        }


        private void DrawNurse(PaintEventArgs e,BedInfo _bed)
        {
            if (string.IsNullOrEmpty(_bed.Nurse))
                return;

            String sText;
            Brush fontBrush = Brushes.Black;
            switch (_bed.Nurse)
            {
                case "01":
                    DrawRectangleBackGroup(e.Graphics, _rectNurse, Color.Coral, Color.Red, Color.Maroon, 1);
                    sText = "Ⅰ";
                    break;
                case "02":
                    DrawRectangleBackGroup(e.Graphics, _rectNurse, Color.FromArgb(255, 255, 128), Color.Yellow, Color.Olive, 1);
                    sText = "Ⅱ";
                    break;
                case "03":
                    DrawRectangleBackGroup(e.Graphics, _rectNurse, Color.DarkBlue, Color.Blue, Color.Navy, 1);
                    sText = "Ⅲ";
                    fontBrush = Brushes.White;
                    break;
                case "04":
                    DrawRectangleBackGroup(e.Graphics, _rectNurse, Color.Lime, Color.Green, Color.DarkGreen, 1);
                    sText = "特";
                    break;
                default:
                    return;
            }
            Font font = new Font(Font.FontFamily, 9.0f, FontStyle.Regular);
            SizeF fontsize = e.Graphics.MeasureString(sText, font);
            e.Graphics.DrawString(sText, font, fontBrush,
                _rectNurse.Left + (int)(_rectNurse.Width - fontsize.Width) / 2,
                _rectNurse.Top + (int)(_rectNurse.Height - fontsize.Height) / 2 + 1);
        }

        private void DrawButton(Graphics g, Rectangle rect, Image img, ButtonState bsState)
        {
            if (bsState == ButtonState.bsSelected)
                DrawRectangleBackGroup(g, rect, Color.FromArgb(255, 244, 230), Color.FromArgb(255, 209, 146),
                                Color.FromArgb(194, 170, 120), 1);
            else if (bsState == ButtonState.bsButtonDown)
                DrawRectangleBackGroup(g, rect, Color.FromArgb(243, 196, 98), Color.FromArgb(255, 228, 138),
                                Color.FromArgb(194, 126, 48), 1);
            if (img != null)
                g.DrawImage(img, new Rectangle(rect.Left + (rect.Width - img.Width) / 2,
                                rect.Top + (rect.Height - img.Height) / 2, img.Width, img.Height),
                            new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
        }
        private void DrawButton(Graphics g, Rectangle rect, String sText, Font font, ButtonState bsState)
        {
            if (bsState == ButtonState.bsSelected)
                DrawRectangleBackGroup(g, rect, Color.FromArgb(255, 244, 230), Color.FromArgb(255, 209, 146),
                                Color.FromArgb(194, 170, 120), 1);
            else if (bsState == ButtonState.bsButtonDown)
                DrawRectangleBackGroup(g, rect, Color.FromArgb(243, 196, 98), Color.FromArgb(255, 228, 138),
                                Color.FromArgb(194, 126, 48), 1);

            SizeF fontsize = g.MeasureString(sText, font);
            g.DrawString(sText, font, Brushes.Navy, rect.Left + (rect.Width - fontsize.Width) / 2,
                                        rect.Top + (rect.Height - fontsize.Height) / 2 + 1);
        }

        private bool MouseInRect(int X, int Y, Rectangle rect)
        {
            return X > rect.X && X < (rect.X + rect.Width) &&
                   Y > rect.Y && Y < (rect.Y + rect.Height);
        }

        private void SetButtonStatus(Graphics g, PointButton button, ButtonState state, bool bFireEvent, BedInfo _bed)
        {
            //ResourceManager rm = new ResourceManager(typeof(BedCardControl));
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
                    DrawButton(g, _rectHeadPage, Resources.病案首页, state);
                    if (bFireEvent && HeadPageClick != null)
                    {
                        eventargs.CommandParameter = "病历首页";
                        HeadPageClick(this, eventargs);
                    }
                    break;
                case PointButton.pbTemperature:
                    DrawButton(g, _rectTemperature, Resources.体温单, state);
                    if (bFireEvent && TemperatureClick != null)
                    {
                        eventargs.CommandParameter = "体温单";
                        TemperatureClick(this, eventargs);
                    }
                    break;
                case PointButton.pbAdvice:
                    DrawButton(g, _rectAdvice, Resources.医嘱, state);
                    if (bFireEvent && AdviceClick != null)
                    {
                        eventargs.CommandParameter = "住院医嘱";
                        AdviceClick(this, eventargs);
                    }
                    break;
                case PointButton.pbApply:
                    DrawButton(g, _rectApply, Resources.特殊治疗, state);
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


}
