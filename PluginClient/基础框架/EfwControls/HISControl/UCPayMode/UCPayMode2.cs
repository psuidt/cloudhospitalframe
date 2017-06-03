using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Runtime.InteropServices;

namespace EfwControls.HISControl.UCPayMode
{
    [Serializable]
    [ComVisible(true)]
    public delegate void btnPayClickEventHandler(PayMethod_Config config, object sender, EventArgs e);

    [Serializable]
    [ComVisible(true)]
    public delegate void diPayMoneyTextChangedEventHandler(PayMethod_Config config, object sender, EventArgs e);

    [Serializable]
    [ComVisible(true)]
    public delegate void threadPayFinshedEventHandler(PayMethod_Config config, object sender);

    public partial class UCPayMode2 : UserControl
    {
        public const int WM_PAY_STATUS = 0x0400 + 4838;  //后台支付处理完成消息 WParam > 1 支付完成，其他值为进度状态消息

        [Description("点击操作按钮事件")]
        public event btnPayClickEventHandler btnPayClick;
        [Description("金额改变时候事件")]
        public event diPayMoneyTextChangedEventHandler diPayMoneyTextChanged;
        [Description("支付线程完成事件")]
        public event threadPayFinshedEventHandler threadPayFinshed;

        private decimal _value;
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PayValue
        {
            get
            {
                _value = Convert.ToDecimal(diPayMoney.Value);
                return _value;
            }
            set
            {
                _value = value;
                diPayMoney.Value = Convert.ToDouble(_value);
            }
        }
        private string _ticketno = "";
        /// <summary>
        /// 票据号
        /// </summary>
        public string TicketNo
        {
            get { return _ticketno; }
            set { _ticketno = value; }
        }
        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int wndproc);
        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        public const int GWL_STYLE = -16;
        public const int WS_DISABLED = 0x8000000;
        public void SetControlEnabled(bool enabled)
        {
            Control c = this.diPayMoney;
            if (enabled)
            {
                SetWindowLong(c.Handle, GWL_STYLE, (~WS_DISABLED) & GetWindowLong(c.Handle, GWL_STYLE));
            }
            else
            {
                SetWindowLong(c.Handle, GWL_STYLE, WS_DISABLED + GetWindowLong(c.Handle, GWL_STYLE));
            }
        }

        public PayMethod_Config _config;

        public UCPayMode2(PayMethod_Config config)
        {
            InitializeComponent();

            _config = config;

            //手工输入
            if (config.InputFrom == PAY_FEE_FROM.pffManualInput)
            {
                diPayMoney.Enabled = true;
            }
            else
            {
                SetControlEnabled(false);
                this.diPayMoney.ForeColor = Color.Black;
                this.TabStop = false;
                diPayMoney.TabStop = false;
            }

            if (config.PayMethodID == -1)
            {
                SetControlEnabled(false);
                this.diPayMoney.ForeColor = Color.Black;
                this.TabStop = false;
                diPayMoney.TabStop = false;
            }

            btnPay.Visible = false;

            //显示颜色
            lbTitle.ForeColor = config.FontColor;
            lbTitle.Text = config.PayMethodName;
            diPayMoney.ForeColor = config.FontColor;
            diPayMoney.Value = 0;
        }

        //操作
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (btnPayClick != null)
                btnPayClick(_config, this, e);
        }

        //金额变化
        private void diPayMoney_ValueChanged(object sender, EventArgs e)
        {
            if (diPayMoneyTextChanged != null)
                diPayMoneyTextChanged(_config, this, e);
        }

        //界面收到计算支付方式线程完成的消息
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PAY_STATUS:
                    {
                        if (threadPayFinshed != null)
                            threadPayFinshed(_config, this);
                        break;
                    }
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

    }
}
