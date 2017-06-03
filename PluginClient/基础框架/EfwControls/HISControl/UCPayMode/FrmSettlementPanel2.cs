using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections;

namespace EfwControls.HISControl.UCPayMode
{
    public partial class FrmSettlementPanel2 : Form
    {

        #region 公共变量

        public Decimal m_WipeOut = 0;//记账金额
        public Decimal m_diPay = 0;//个人支付
        public Decimal m_PosAmt = 0;//Pos金额
        public Decimal m_Cash = 0;//收取现金
        public Decimal m_Change = 0;//找零

        #endregion

        #region 窗口初始化
        public FrmSettlementPanel2()
        {
            InitializeComponent();

            this.Load += new EventHandler(FrmSettlementPanel_Load);
            btnConfirm.Click += new EventHandler(btnConfirm_Click);
            btnGiveUp.Click += new EventHandler(btnGiveUp_Click);
        }

        //窗体加载
        private void FrmSettlementPanel_Load(object sender, EventArgs e)
        {
            SetFeeValueDelegate setfeeValue = new SetFeeValueDelegate(SetLabelText);

            int iPayControls = CostPayManager.InitUCPayModeControl(1, flpPayCtrl, 106, 0);
            if (iPayControls > 0)
            {
                Height = groupPanel2.Location.Y + 120 + Math.Max(2, iPayControls) * 48 + 15;
                groupPanel2.Height = Math.Max(2, iPayControls) * 48 + 32 + 15;
            }
            CostPayManager.StartExecPay(150, 0,null, setfeeValue, true);
        }
        #endregion

        private void SetLabelText(CostFeeStyle CostFee)
        {
            txtAmount.Text = CostFee.PayTotalFee.ToString();
            lbFavorableSum.Text = CostFee.FavorableTotalFee.ToString();
            lbPersonalSum.Text = CostFee.SelfTotalFee.ToString();
            lbAccountSum.Text = CostFee.AccountTotalFee.ToString();
        }

        //结算
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (CostPayManager.CostFee.ChangeFee < 0)
            {
                MessageBox.Show("支付金额不足!");
                return;
            }

            if (CostPayManager.CostFee.SelfTotalFee + CostPayManager.CostFee.RoundFee < 0)
            {
                MessageBox.Show("记账支付金额不能超过总金额!");
                return;
            }

            if (CostPayManager.CostFee.AccountTotalFee > CostPayManager.CostFee.PayTotalFee)
            {
                MessageBox.Show("总记账支付金额不能超过总金额");
                return;
            }

            m_diPay = CostPayManager.CostFee.SelfTotalFee;
            m_Cash = CostPayManager.CostFee.CashFee + CostPayManager.CostFee.ChangeFee;
            m_Change = CostPayManager.CostFee.ChangeFee;


            StringBuilder sbBuilderEnum = new StringBuilder("");//枚举
            StringBuilder sbBuilderCardNum = new StringBuilder("");//卡号
            StringBuilder sbBuilderMoney = new StringBuilder("");//金额
            StringBuilder sbBuilderInPutFrom = new StringBuilder("");//输入方式
            StringBuilder sbBuilderPayStID = new StringBuilder("");//统计编码
            StringBuilder sbAgencyID = new StringBuilder("");//支付机构
            //循环获取支付方式
            foreach (PayModeFee pay in CostPayManager.CostFee.payList)
            {
                
            }
            //结算处理
        }

        //放弃结算
        private void btnGiveUp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            bool bRet = false;
            switch (keyData)
            {
                case Keys.Up:
                case Keys.PageUp:
                    bRet = ProcessTabKey(false);
                    break;
                case Keys.Down:
                case Keys.PageDown:
                    bRet = ProcessTabKey(true);
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Enter:
                    if (btnGiveUp.Focused == true)
                        btnGiveUp_Click(null, null);
                    else
                    {
                        if (btnConfirm.Focused == false)
                            btnConfirm.Focus();
                        else
                            btnConfirm_Click(null, null);
                    }

                    CostPayManager.SetCashValue(CostPayManager.CostFee.ChangeFee);
                    break;
                default:
                    bRet = base.ProcessDialogKey(keyData);
                    break;
            }
            return bRet;
        }

        private void FrmSettlementPanel_Shown(object sender, EventArgs e)
        {
            if (flpPayCtrl.Controls.Count > 0)
            {
                CostPayManager.CashFocus();
            }
            else
            {
                MessageBox.Show("请设置相关的支付类型");
            }
        }


        public void CopyToClipboard(string SoCityNum, string IDNo)
        {
            string str = string.IsNullOrEmpty(SoCityNum) ? IDNo : SoCityNum;
            if (string.IsNullOrEmpty(str) == false)
                Clipboard.SetText(str);
        }
    }
}
