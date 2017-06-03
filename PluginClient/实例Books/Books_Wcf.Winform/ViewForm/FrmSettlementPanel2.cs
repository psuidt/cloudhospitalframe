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
using EFWCoreLib.CoreFrame.Business;
using EfwControls.HISControl.UCPayMode;

namespace Books_Wcf.Winform.ViewForm
{
    public partial class FrmSettlementPanel2 : BaseFormBusiness
    {


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
            int iPayControls = CostPayManager.InitUCPayModeControl(1, flpPayCtrl, 106, 0);
            if (iPayControls > 0)
            {
                //根据支付方式控件多少，自动设置界面高度
                Height = groupPanel2.Location.Y + 120 + Math.Max(2, iPayControls) * 40 + 15;
                groupPanel2.Height = Math.Max(2, iPayControls) * 40 + 32 + 15;
            }

            SetFeeValueDelegate setfeeValue = new SetFeeValueDelegate(SetLabelText);//实列化委托，各项金额实时显示
            PaymentAutoCalculate autocal = new PaymentAutoCalculate(35, 106, new int[] { 1, 2, 3 }, InvokeController);//实列化对象，支付方式金额计算
            CostPayManager.StartExecPay(Convert.ToDecimal(152.14), 0, autocal, setfeeValue, false);
        }
        #endregion

        //实时显示各项金额
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

        
            StringBuilder sb = new StringBuilder();
            sb.Append("结算成功，支付方式：\n");
            //循环获取支付方式
            foreach (PayModeFee pay in CostPayManager.CostFee.payList)
            {
                sb.Append(pay.PayMethodID + "@" + pay.PayFee + "@" + pay.TicketNo + "\n");
            }
            //结算处理
            sb.Append("总金额:" + CostPayManager.CostFee.PayTotalFee + "\n");
            sb.Append("优惠金额:" + CostPayManager.CostFee.FavorableTotalFee + "\n");
            sb.Append("Pos金额:" + CostPayManager.CostFee.PosFee + "\n");
            sb.Append("现金金额:" + CostPayManager.CostFee.CashFee + "\n");
            sb.Append("凑整费:" + CostPayManager.CostFee.RoundFee + "\n");

            MessageBox.Show(sb.ToString());
        }

        //放弃结算
        private void btnGiveUp_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //监听键盘事件
        protected override bool ProcessDialogKey(Keys keyData)
        {
            bool bRet = false;
            switch (keyData)
            {
                case Keys.PageUp:
                    bRet = ProcessTabKey(false);
                    break;
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

                    //CostPayManager.SetCashValue(CostPayManager.CostFee.ChangeFee);
                    break;
                default:
                    bRet = base.ProcessDialogKey(keyData);
                    break;
            }
            return bRet;
        }
        //设置焦点
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
    }

    public class PaymentAutoCalculate : AsynPaymentCalculate
    {
        private ControllerEventHandler InvokeController;
        public PaymentAutoCalculate(int _patListID, int _iPatType, int[] _feeIDs, ControllerEventHandler _InvokeController) : base(_patListID, _iPatType, _feeIDs)
        {
            InvokeController = _InvokeController;
        }

        public override decimal FavorableCalculate(out string ticketNo, out PAY_PROCSTEP procStep)
        {
            //InvokeController(""); 调用控制器处理
            ticketNo = "优惠111";
            procStep = PAY_PROCSTEP.ppsHandFinsed;
            return Convert.ToDecimal(20.23);
        }

        public override decimal MedicalinsuranceCalculate(out string ticketNo, out PAY_PROCSTEP procStep)
        {
            //InvokeController(""); 调用控制器处理
            ticketNo = "医保计算111";
            procStep = PAY_PROCSTEP.ppsAutoFinshed;
            return Convert.ToDecimal(33.59);
        }
    }
}
