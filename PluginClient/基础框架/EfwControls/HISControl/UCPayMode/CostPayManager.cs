using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.WcfFrame;
using EFWCoreLib.WcfFrame.DataSerialize;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfwControls.HISControl.UCPayMode
{
    //支付方式ID
    //现金    1002
    //POS     1004
    //优惠    1005
    //医保报销 1007
    public delegate void SetFeeValueDelegate(CostFeeStyle CostFee);

    public class CostPayManager
    {
        private static DataTable m_dtPayMethodConfig = null;    //缓存-支付方式配置

        private static List<PayMethod_Config> m_PayConfigs = null;//支付方式列表
        private static List<PAY_THREAD> m_PayThreads = null;    //支付线程列表
        private static List<UCPayMode2> m_UCPayModes = null;//支付控件

        public static CostFeeStyle CostFee = null;
        //private static bool AutoPay = false;
        private static bool defaultCash = false;
        private static int workID = 0;
        private static SetFeeValueDelegate setFeeValue;
        private static AsynPaymentCalculate paymentCalculate;//异步计算

        private static ServiceResponseData InvokeWcfService(string wcfpluginname, string wcfcontroller, string wcfmethod)
        {
            return InvokeWcfService(wcfpluginname, wcfcontroller, wcfmethod, null);
        }

        private static ServiceResponseData InvokeWcfService(string wcfpluginname, string wcfcontroller, string wcfmethod, Action<ClientRequestData> requestAction)
        {
            ClientLink wcfClientLink = ClientLinkManage.CreateConnection(wcfpluginname);
            //绑定LoginRight
            Action<ClientRequestData> _requestAction = ((ClientRequestData request) =>
            {
                request.LoginRight = new EFWCoreLib.CoreFrame.Business.SysLoginRight();
                if (requestAction != null)
                    requestAction(request);
            });
            ServiceResponseData retData = wcfClientLink.Request(wcfcontroller, wcfmethod, _requestAction);
            return retData;
        }
        /// <summary>
        /// 第一步：创建支付方式对象
        /// </summary>
        /// <param name="WorkID">医疗机构ID</param>
        /// <param name="flpPayCtrl">支付对象容器</param>
        /// <param name="iPatType">病人类型</param>
        /// <param name="iUseType">病人来源: 0-门诊 1-住院</param>
        /// <param name="totalFee">处方金额</param>
        /// <param name="zyDepositFee">住院预交金</param>
        /// <param name="_setFeeValue">回调返回金额</param>
        /// <returns>支付方式个数</returns>
        public static int InitUCPayModeControl(int WorkID,FlowLayoutPanel flpPayCtrl, int iPatType, int iUseType)
        {
            workID = WorkID;

            CostFee = new CostFeeStyle();
            m_PayConfigs = new List<PayMethod_Config>();
            m_UCPayModes = new List<UCPayMode2>();
            

            //根据支付方式动态创建支付控件到 flpPayCtrl
            List<PayMethod_Config> rows = GetPatientPayMethodConfig(iPatType, (PAY_USERTYPE)iUseType);
            if (rows == null)
                return 0;
            flpPayCtrl.Controls.Clear();
            flpPayCtrl.SuspendLayout();
            int iTabStopIndex = 0;
            foreach (PayMethod_Config row in rows)
            {
                UCPayMode2 ucPayButton = new UCPayMode2(row);
                ucPayButton.TabIndex = iTabStopIndex++;
                ucPayButton.Margin = new Padding(0, 0, 0, 0);
                //ucPayButton.Dock = DockStyle.Top;
                ucPayButton.Width = flpPayCtrl.Width - 20;

                ucPayButton.btnPayClick += new btnPayClickEventHandler(ucPayButton_btnPayClick);
                ucPayButton.diPayMoneyTextChanged += new diPayMoneyTextChangedEventHandler(ucPayButton_diPayMoneyTextChanged);
                ucPayButton.threadPayFinshed += new threadPayFinshedEventHandler(ucPayButton_threadPayFinshed);
                flpPayCtrl.Controls.Add(ucPayButton);

                if (row.PayMethodID == -1)
                {
                    ucPayButton.diPayMoney.MinValue = -1000000000;//找零可以为负数
                }
                m_UCPayModes.Add(ucPayButton);//控件集合

                PayMethod_Config config = row;
                config.Handle = ucPayButton.Handle;
                m_PayConfigs.Add(config);
            }
            flpPayCtrl.ResumeLayout(false);

            return rows.Count;
        }

        /// <summary>
        /// 第二步：创建控件后开始计算支付金额
        /// </summary>
        /// <param name="totalFee">总金额</param>
        /// <param name="zyDepositFee">预交金总额</param>
        /// <param name="_paymentCalculate">支付方式计算</param>
        /// <param name="_setFeeValue">显示支付金额</param>
        /// <param name="_defaultCash">现金项默认</param>
        public static void StartExecPay(decimal totalFee, decimal zyDepositFee, AsynPaymentCalculate _paymentCalculate, SetFeeValueDelegate _setFeeValue, bool _defaultCash)
        {
            
            CostFee.InitFee(totalFee, zyDepositFee, m_UCPayModes);

            UCPayMode2 change_uPayMode = m_UCPayModes.Find(x => x._config.PayMethodID == -1);
            change_uPayMode.PayValue = CostFee.ChangeFee;//显示找零金额

            paymentCalculate = _paymentCalculate;
            setFeeValue = _setFeeValue;
            if (setFeeValue != null)
            {
                //给界面显示金额
                setFeeValue(CostFee);
            }
            defaultCash = _defaultCash;
            if (m_PayConfigs != null)
            {
                m_PayThreads = null;//清空线程
                //SetCashValue(CostFee.ChangeFee);
                for (int i = 0; i < m_PayConfigs.Count; i++)
                {
                    PayMethod_Config m_PayConfig = m_PayConfigs[i];
                    //m_PayConfig.ProcStep = PAY_PROCSTEP.ppsHandFinsed;//开始

                    PAY_THREAD paythread = new PAY_THREAD();
                    //paythread.iPatType = m_PayConfig.PatientType;
                    //paythread.iPatLstID = patListID;
                    //paythread.FeeIDs = feeIDs;
                    //paythread.PayType = iPatType;
                    //paythread.SoCityNum = "";
                    paythread.PayMethodID = m_PayConfig.PayMethodID;
                    paythread.InputFrom = m_PayConfig.InputFrom;
                    //paythread.ProcStep = m_PayConfig.ProcStep;
                    paythread.Handle = m_PayConfig.Handle;
                    paythread.paymentCalculate = paymentCalculate;

                    //启动后台线程开始支付
                    bool bSucceed = false;
                    bSucceed = StartPay(ref paythread, m_PayConfig);
                    if (bSucceed == false)
                    {
                        //执行支付失败
                        //m_PayConfig.ProcStep = PAY_PROCSTEP.ppsHandFinsed;
                    }
                }
            }
        }

        /// <summary>
        /// 现金获取焦点
        /// </summary>
        public static void CashFocus()
        {
            for (int i = 0; i < m_UCPayModes.Count; i++)
            {
                if (m_UCPayModes[i]._config.PayMethodID == 1002)
                {
                    m_UCPayModes[i].Focus();
                    m_UCPayModes[i].diPayMoney.Focus();
                }
            }
        }

        /// <summary>
        /// 给现金字段赋值
        /// </summary>
        /// <param name="val">金额</param>
        public static void SetCashValue(decimal val)
        {
            if (defaultCash ==true)
            {
                for (int i = 0; i < m_UCPayModes.Count; i++)
                {
                    if (m_UCPayModes[i]._config.PayMethodID == 1002)//现金
                    {
                        val = val < 0 ? (Convert.ToDecimal(m_UCPayModes[i].diPayMoney.Value) - val) : (Convert.ToDecimal(m_UCPayModes[i].diPayMoney.Value) - val);
                        val = val < 0 ? 0 : val;
                        m_UCPayModes[i].PayValue = Convert.ToDecimal(val);
                        m_UCPayModes[i].diPayMoney.Focus();
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 欠费结算
        /// </summary>
        public static void ArrearageCost()
        {
            defaultCash = true;
            decimal val = CostFee.ChangeFee;//找零
            SetCashValue(val);

            //设置所有支付控件只读
            for (int i = 0; i < m_UCPayModes.Count; i++)
            {
                if (m_UCPayModes[i]._config.PayMethodID > 0 && m_UCPayModes[i]._config.InputFrom == PAY_FEE_FROM.pffManualInput)
                {
                    m_UCPayModes[i].SetControlEnabled(false);
                }
            }
        }

        #region 内部处理方法

        static void ucPayButton_threadPayFinshed(PayMethod_Config config, object sender)
        {
            PayMethod_Config m_PayConfig = config;
            UCPayMode2 uPayMode = (UCPayMode2)sender;

            //接收支付线程消息
            PAY_THREAD paythread = GetPayThreadInfo(m_PayConfig.PayMethodID);
            if (paythread != null && paythread.PayMethodID != -1)
            {
                //支付完成
                if (paythread.Succeed)
                {
                    //m_PayConfig.ProcStep = paythread.ProcStep;
                    uPayMode.PayValue = decimal.Round(paythread.PayFee, 2);//显示在控件上
                    uPayMode.TicketNo = paythread.TicketNo;
                    CostFee.SetPayModeFee(m_PayConfig.PayMethodID, paythread.TicketNo, decimal.Round(paythread.PayFee, 2));

                    //CostFee.ChangeValue(m_UCPayModes);//测试
                    SetCashValue(CostFee.ChangeFee);


                    switch (m_PayConfig.InputFrom)
                    {
                        case PAY_FEE_FROM.pffManualInput://手工输入
                            break;
                        case PAY_FEE_FROM.pffAutoCalculate://自动计算支付金额
                            switch (paythread.ProcStep)
                            {
                                case PAY_PROCSTEP.ppsHandFinsed:
                                    uPayMode.btnPay.Text = "获取";
                                    uPayMode.btnPay.Visible = true;
                                    uPayMode.btnPay.Enabled = true;
                                    break;
                                case PAY_PROCSTEP.ppsAutoFinshed:
                                    uPayMode.btnPay.Visible = false;
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("计算错误：" + paythread.LastErrorMessage);
                }
            }
        }

        static void ucPayButton_diPayMoneyTextChanged(PayMethod_Config config, object sender, EventArgs e)
        {
            UCPayMode2 uPayMode = (UCPayMode2)sender;
            //找零的值不执行下面代码
            if (config.PayMethodID == -1) return;

            CostFee.ChangeValue(m_UCPayModes);

            //其他支付方式值改变会自动触发 自动计算支付金额 与 总金额优惠自动计算
            //if (config.InputFrom != PAY_FEE_FROM.pffAutoCalculate)
            //{
            //    for (int i = m_UCPayModes.Count - 1; i >= 0; i--)
            //    {
            //        if (m_UCPayModes[i]._config.InputFrom == PAY_FEE_FROM.pffAutoCalculate)
            //        {
            //            if (m_UCPayModes[i].btnPay.Visible && m_UCPayModes[i].btnPay.Enabled)
            //                m_UCPayModes[i].btnPay.PerformClick();
            //        }
            //    }
            //}


            //显示找零
            UCPayMode2 change_uPayMode = m_UCPayModes.Find(x => x._config.PayMethodID == -1);
            change_uPayMode.PayValue = CostFee.ChangeFee;//显示找零金额

            if (config.PayMethodID != 1002)
            {
                //补充支付方式数据
                CostFee.SetPayModeFee(config.PayMethodID, uPayMode.TicketNo, uPayMode.PayValue);
            }
            else//更新现金支付方式1002
            {
                CostFee.SetPayModeFee(config.PayMethodID, uPayMode.TicketNo, CostFee.CashFee);
            }
            //结算面板显示对应金额
            setFeeValue(CostFee);
        }

        static void ucPayButton_btnPayClick(PayMethod_Config config, object sender, EventArgs e)
        {
            PayMethod_Config m_PayConfig = config;
            UCPayMode2 uPayMode = (UCPayMode2)sender;

            //接收支付线程消息
            PAY_THREAD paythread = (PAY_THREAD)GetPayThreadInfo(m_PayConfig.PayMethodID).Clone();
            if (paythread != null)
            {
                StartPay(ref paythread, m_PayConfig);
            }
            uPayMode.btnPay.Enabled = false;
            CashFocus();
        }

        /// <summary>
        /// 开始执行后台支付
        /// </summary>
        /// <param name="paythread">支付方式线程</param>
        /// <returns>开始支付是否成功</returns>
        private static bool StartPay(ref PAY_THREAD paythread, PayMethod_Config config)
        {
            //启动后台线程开始支付
            bool bSucceed = false;
            switch (paythread.InputFrom)
            {
                case PAY_FEE_FROM.pffManualInput://手工输入
                    bSucceed = true;
                    paythread.Succeed = true;
                    break;
                case PAY_FEE_FROM.pffAutoCalculate://自动计算支付金额
                    paythread.PayThread = new Thread(paythread.ExecAutoDataItfPay);
                    bSucceed = true;
                    break;
                default: //手工输入，支付按钮不可用
                    paythread.LastErrorMessage = "支付完成";
                    paythread.Succeed = true;
                    break;
            }

            //启动线程
            if (bSucceed)
            {
                //保存支付ID为名称，在线程内部根据此值可获得相应的支付配置信息 

                if (paythread.PayThread != null)
                {
                    paythread.PayThread.Name = paythread.PayMethodID.ToString();
                    paythread.PayThread.Priority = ThreadPriority.Normal;
                    AddPayThread(paythread);
                    paythread.PayThread.Start();
                }
                else
                {
                    AddPayThread(paythread);
                }
            }

            //if (paythread.InputFrom == PAY_FEE_FROM.pffAutoCalculate)
            //{
            //    WindowsAPI.SendMessage(paythread.Handle, UCPayMode2.WM_PAY_STATUS, 1, 0);
            //}

            return bSucceed;
        }

        /// <summary>
        /// 添加线程到队列
        /// </summary>
        /// <param name="paythread"></param>
        private static void AddPayThread(PAY_THREAD paythread)
        {
            if (m_PayThreads == null)
                m_PayThreads = new List<PAY_THREAD>();
            Monitor.Enter(m_PayThreads);
            try
            {
                //根据支付ID找到原来的线程
                foreach (PAY_THREAD thread in m_PayThreads)
                {
                    if (thread.PayMethodID == paythread.PayMethodID)
                    {
                        if (thread.PayThread != null && thread.PayThread.IsAlive)
                            thread.PayThread.Abort();
                        m_PayThreads.Remove(thread);
                        break;
                    }
                }
                m_PayThreads.Add(paythread);
            }
            finally
            {
                Monitor.Exit(m_PayThreads);
            }
        }

        /// <summary>
        /// 根据支付ID号，取得支付线程信息
        /// </summary>
        /// <param name="PayMethodID">支付方式ID</param>
        /// <returns>返回支付线程结构信息</returns>
        private static PAY_THREAD GetPayThreadInfo(int PayMethodID)
        {
            foreach (PAY_THREAD thread in m_PayThreads)
            {
                if (thread.PayMethodID == PayMethodID)
                    return thread;
            }
            return null;
        }

        /// <summary>
        /// 根据病人身份信息，取得结算方式
        /// </summary>
        /// <param name="iPatType">病人身份</param>
        /// <param name="iUseType">病人来源: 0-门诊 1-住院</param>
        /// <returns>符合条件的记录</returns>
        private static List<PayMethod_Config> GetPatientPayMethodConfig(int iPatType, PAY_USERTYPE iUseType)
        {
            List<PayMethod_Config> Configs = new List<PayMethod_Config>();
            PayMethod_Config config = new PayMethod_Config();

            #region 根据病人类型获取支付方式
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(iPatType);
                request.AddData((int)iUseType);
                request.AddData(workID);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "CashPaymentController", "GetPaymentData", requestAction);
            m_dtPayMethodConfig = retdata.GetData<DataTable>(0);

            //bool bHavePaySurplus = false;   //是否存在结余支付
            foreach (DataRow row in m_dtPayMethodConfig.Rows)
            {
                config = new PayMethod_Config();
                config.PayMethodID = Convert.ToInt32(row["PaymentID"]);
                config.PatientType = iUseType;
                config.OrderNum = Convert.ToInt32(row["PayOrder"]);
                config.PayMethodName = row["PayName"].ToString();
                config.InputFrom = (PAY_FEE_FROM)Convert.ToInt32(row["InputFrom"]);
                config.RuleExplain = row["PayRule"].ToString();
                config.FontColor = Color.FromArgb(Convert.ToInt32(row["FontColor"]));
                config.IsAccountFee = Convert.ToInt32(row["IsAccountFee"]);
                if (config.FontColor == Color.Transparent || config.FontColor.ToArgb() == 0)
                    config.FontColor = SystemColors.ControlText;
                //config.ProcStep = PAY_PROCSTEP.ppsAutoFinshed;
                Configs.Add(config);
            }

            #endregion

            #region 默认添加现金支付方式，支付方式固定PayMethodID=1002
            //config = new PayMethod_Config();
            //config.PayMethodID = 1002;
            //config.PayMethodName = "现金支付";
            //config.PatientType = iUseType;
            //config.OrderNum = 999999;
            //config.InputFrom = PAY_FEE_FROM.pffManualInput;
            //config.RuleExplain = "";
            //config.FontColor = Color.Red;
            //config.ProcStep = PAY_PROCSTEP.ppsNotStart;
            ////config.PayStID = 0;
            ////config.ProcStatus = true;
            ////config.TicketNo = "";
            ////config.NeedPayFee = 0;
            ////config.PayFee = 0;
            ////config.NeedRound = !bHavePaySurplus;    //存在结余支付，不需要凑整和显示补零;
            ////config.NeedPayFee = 0;
            //Configs.Add(config);

            #endregion

            #region 找零，支付方式固定PayMethodID=-1
            config = new PayMethod_Config();
            config.PayMethodID = -1;
            config.PayMethodName = "找零";
            config.PatientType = iUseType;
            config.OrderNum = 999999;
            config.InputFrom = PAY_FEE_FROM.pffManualInput;
            config.RuleExplain = "";
            config.FontColor = Color.Red;
            //config.ProcStep = PAY_PROCSTEP.ppsAutoFinshed;
            //config.PayStID = -1;
            Configs.Add(config);

            #endregion

            return Configs;
        }
        #endregion
    }

    /// <summary>
    /// 结算金额分类情况
    /// </summary>
    public class CostFeeStyle
    {
        public decimal PayTotalFee;//处方总金额
        public decimal FavorableTotalFee;//优惠总金额
        public decimal SelfTotalFee;//自付金额
        public decimal AccountTotalFee;//记账总金额

        public decimal RoundFee;//凑整费
        public decimal ChangeFee;//找零
        public decimal PosFee;//POS
        public decimal CashFee;//现金

        //住院使用
        public decimal zyDepositFee;//住院押金
        public decimal zyRefundFee;//应退
        public decimal zyChargeFee;//补收

        public List<PayModeFee> payList = null;


        public void InitFee(decimal TotalFee, decimal _zyDepositFee, List<UCPayMode2> m_UCPayModes)
        {

            PayTotalFee = TotalFee;
            SelfTotalFee = TotalFee;
            FavorableTotalFee = 0;
            AccountTotalFee = 0;

            PosFee = 0;
            CashFee = 0;


            payList = new List<PayModeFee>();
            for (int i = 0; i < m_UCPayModes.Count; i++)
            {

                if (m_UCPayModes[i]._config.PayMethodID > 0)
                {
                    PayModeFee pay = new PayModeFee();
                    pay.PayMethodID = m_UCPayModes[i]._config.PayMethodID;
                    pay.TicketNo = "";
                    pay.InputFrom = Convert.ToInt32(m_UCPayModes[i]._config.InputFrom);
                    pay.PayFee = m_UCPayModes[i].PayValue;
                    //pay.PayStID = m_UCPayModes[i]._config.PayStID;
                    pay.Agency = 0;
                    payList.Add(pay);
                }
            }

            zyDepositFee = _zyDepositFee;
            zyRefundFee = 0;
            zyChargeFee = 0;
            decimal ret = zyDepositFee - PayTotalFee;
            if (ret >= 0)//应退
            {
                zyRefundFee = ret;
            }
            else//补收
            {
                zyChargeFee = -ret;
            }

            ChangeFee = ret;//找零
            decimal _needPayFee;
            decimal _roundFee;
            CostFeeStyle.ChangeFeeRoun(ChangeFee, out _needPayFee, out _roundFee);
            ChangeFee = _needPayFee;
            RoundFee = _roundFee;//update zh 20160927

            ChangeValue(m_UCPayModes);//重新计算

            SetPayModeFee(1002, "", CashFee);//设置现金金额
        }

        //支付方式金额变化
        public void ChangeValue(List<UCPayMode2> m_UCPayModes)
        {
            decimal _notChanageFee = 0;//除了找零
            AccountTotalFee = 0;
            for (int i = 0; i < m_UCPayModes.Count; i++)
            {
                if (m_UCPayModes[i]._config.PayMethodID == 1005)//优惠
                {
                    FavorableTotalFee = m_UCPayModes[i].PayValue;
                }
                //记账
                //if (m_UCPayModes[i]._config.PayMethodID > 0 && m_UCPayModes[i]._config.PayMethodID != 1002 && m_UCPayModes[i]._config.PayMethodID != 1005)//排除现金和优惠=记账
                if (m_UCPayModes[i]._config.PayMethodID > 0 && m_UCPayModes[i]._config.IsAccountFee==1)//只取记账的
                {
                    AccountTotalFee += m_UCPayModes[i].PayValue;
                }

                if (m_UCPayModes[i]._config.PayMethodID == 1002)//现金
                {
                    CashFee = m_UCPayModes[i].PayValue;
                }

                //如果有类型现金（如支付宝、刷卡等）可以根据银联刷卡等方式进行减掉,下面代码则是去掉POS部分
                //POS
                if (m_UCPayModes[i]._config.PayMethodID == 1004)
                {
                    PosFee = m_UCPayModes[i].PayValue;
                }

                if (m_UCPayModes[i]._config.PayMethodID != -1)//除了找零
                {
                    _notChanageFee += m_UCPayModes[i].PayValue;
                }
            }

            SelfTotalFee = PayTotalFee - AccountTotalFee - FavorableTotalFee;



            //这里把支付方式为POS的减掉,当作了现金所以补收金额没变
            //AccountTotalFee里面包含了PosFee，因为Pos金额不能影响补收，所以要减去POS
            //decimal ret = zyDepositFee - PayTotalFee + AccountTotalFee - PosFee;//押金减去总金额 加上 记账 减去 pos
            decimal ret = zyDepositFee - PayTotalFee + AccountTotalFee + FavorableTotalFee;//
            zyRefundFee = 0;
            zyChargeFee = 0;
            if (ret >= 0)//应退
            {
                zyRefundFee = ret;
            }
            else//补收
            {
                zyChargeFee = -ret;
            }

            ChangeFee = _notChanageFee - (PayTotalFee) + zyDepositFee;//找零

            decimal _needPayFee;
            decimal _roundFee;

            CostFeeStyle.ChangeFeeRoun(ChangeFee, out _needPayFee, out _roundFee);//计算凑整_roundFee=_needPayFee-fee
            ChangeFee = _needPayFee;//找零（凑整后）
            RoundFee = _roundFee;//凑整费 update zh 20160927

            CashFee = CashFee - ChangeFee;//现金
            SetPayModeFee(1002, "", CashFee);//设置现金金额
        }
        //记账支付方式完成后设置相关信息
        public void SetPayModeFee(int PayMethodID, string TicketNo, decimal PayFee)
        {

            PayModeFee pay = payList.Find(x => x.PayMethodID == PayMethodID);
            if (pay != null)
            {
                pay.TicketNo = TicketNo;
                pay.PayFee = PayFee;
            }
        }

        //自动计算支付金额
        public decimal AutoCalculateFee(PayMethod_Config m_PayConfig, List<UCPayMode2> m_UCPayModes)
        {
            decimal retValue = 0;
            if (m_PayConfig.InputFrom == PAY_FEE_FROM.pffAutoCalculate)
            {
                for (int i = 0; i < m_UCPayModes.Count; i++)
                {
                    if (m_UCPayModes[i]._config.PayMethodID == m_PayConfig.PayMethodID)
                    {
                        //先清0
                        m_UCPayModes[i].PayValue = 0;
                        break;
                    }
                }

                decimal _ChangeFee = 0;//加上凑整费
                for (int i = 0; i < m_UCPayModes.Count; i++)
                {
                    if (m_UCPayModes[i]._config.InputFrom != PAY_FEE_FROM.pffManualInput && m_UCPayModes[i]._config.PayMethodID != -1)
                    {
                        _ChangeFee += m_UCPayModes[i].PayValue;
                    }
                }
                _ChangeFee = -PayTotalFee + _ChangeFee;
            }
            return retValue;
        }

        /// <summary>
        /// 计算四舍五入或者凑整处理
        /// </summary>
        /// <param name="TotalAmt">总金额</param>
        /// <param name="o_FinalPayAmt">转换后的总额</param>
        /// <param name="o_Difference">转换后的差额</param>
        private static void FeeRoun(decimal TotalAmt, out decimal o_FinalPayAmt, out decimal o_Difference)
        {
            //金额转换方式(0.不处理;1.四舍五入;2.凑整费;)
            int ConvertAmount = 2;
            //凑整费金额转换方式(0.角;1.元;)
            int RoundedWayFee = 0;
            o_FinalPayAmt = 0;//最后转换金额
            o_Difference = 0;//两个金额之间的差额

            decimal oldTotalAmt = 0;//未转换之前的金额
            decimal point = 0;//金额(分)数值
            //TotalAmt = Tools.ToDecimal(TotalAmt);
            o_FinalPayAmt = TotalAmt;
            oldTotalAmt = TotalAmt;
            //不处理的情况下保留两位小数
            if (ConvertAmount == 0)
            {
                o_FinalPayAmt = Convert.ToDecimal(Math.Round(TotalAmt, 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                //计算转换后的差额 统计报表的时候要把这个差额相减,不然可能会统计的金额会有几分钱的差别
                o_Difference = o_FinalPayAmt - oldTotalAmt;
            }
            //四舍五入的情况下根据参数进行四舍
            else if (ConvertAmount == 1)
            {
                if (RoundedWayFee == 0)
                {
                    o_FinalPayAmt = Convert.ToDecimal(Math.Round(TotalAmt, 1, MidpointRounding.AwayFromZero).ToString("0.00"));
                    //计算转换后的差额 统计报表的时候要把这个差额相减,不然可能会统计的金额会有几分钱的差别
                    o_Difference = o_FinalPayAmt - oldTotalAmt;
                }
                else if (RoundedWayFee == 1)
                {
                    o_FinalPayAmt = Convert.ToDecimal(Math.Round(TotalAmt, 0, MidpointRounding.AwayFromZero).ToString("0.00"));
                    //计算转换后的差额 统计报表的时候要把这个差额相减,不然可能会统计的金额会有几分钱的差别
                    o_Difference = o_FinalPayAmt - oldTotalAmt;
                }
                else
                {
                    o_FinalPayAmt = Convert.ToDecimal(Math.Round(TotalAmt, 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                    //计算转换后的差额 统计报表的时候要把这个差额相减,不然可能会统计的金额会有几分钱的差别
                    o_Difference = o_FinalPayAmt - oldTotalAmt;
                }
            }
            else if (ConvertAmount == 2)
            {
                TotalAmt = Convert.ToDecimal(Math.Round(TotalAmt, 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                //保留两位小数
                int strLen = TotalAmt.ToString("0.00").IndexOf(".");
                if (RoundedWayFee == 0)
                {
                    point = Convert.ToDecimal(TotalAmt.ToString("0.00").Substring(strLen + 2, 1));

                    if (point > 0 && point < 5)
                        TotalAmt += 0.05M;
                    o_FinalPayAmt = Convert.ToDecimal(Math.Round(Convert.ToDecimal(TotalAmt), 1, MidpointRounding.AwayFromZero).ToString("0.00"));
                    //计算转换后的差额
                    o_Difference = o_FinalPayAmt - oldTotalAmt;
                }
                else if (RoundedWayFee == 1)
                {
                    point = Convert.ToDecimal(TotalAmt.ToString("0.00").Substring(strLen + 1, 1));

                    if (point > 0 && point < 5)
                        TotalAmt += 0.5M;
                    o_FinalPayAmt = Convert.ToDecimal(Math.Round(Convert.ToDecimal(TotalAmt), 0, MidpointRounding.AwayFromZero).ToString("0.00"));
                    //计算转换后的差额
                    o_Difference = o_FinalPayAmt - oldTotalAmt;
                }
            }
        }

        /// <summary>
        /// 计算四舍五入或者凑整处理
        /// </summary>
        /// <param name="TotalAmt">找零金额</param>
        /// <param name="o_FinalPayAmt">转换后的总额</param>
        /// <param name="o_Difference">转换后的差额</param>
        private static void ChangeFeeRoun(decimal TotalAmt, out decimal o_FinalPayAmt, out decimal o_Difference)
        {
            decimal oldTotalAmt = 0;//未转换之前的金额
            oldTotalAmt = TotalAmt;

            bool _isTrue = TotalAmt < 0 ? true : false;
            TotalAmt = TotalAmt < 0 ? -TotalAmt : TotalAmt;

            //金额转换方式(0.不处理;1.四舍五入;2.凑整费;)
            int ConvertAmount = 2;
            //凑整费金额转换方式(0.角;1.元;)
            int RoundedWayFee = 0;
            o_FinalPayAmt = 0;//最后转换金额
            o_Difference = 0;//两个金额之间的差额


            decimal point = 0;//金额(分)数值
            TotalAmt = Convert.ToDecimal(TotalAmt);
            o_FinalPayAmt = TotalAmt;

            //不处理的情况下保留两位小数
            if (ConvertAmount == 0)
            {
                o_FinalPayAmt = Convert.ToDecimal(Math.Round(Convert.ToDecimal(TotalAmt), 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                //计算转换后的差额 统计报表的时候要把这个差额相减,不然可能会统计的金额会有几分钱的差别
                //o_Difference = o_FinalPayAmt - oldTotalAmt;
            }
            //四舍五入的情况下根据参数进行四舍
            else if (ConvertAmount == 1)
            {
                if (RoundedWayFee == 0)
                {
                    TotalAmt -= 0.01M;
                    o_FinalPayAmt = Convert.ToDecimal(Math.Round(Convert.ToDecimal(TotalAmt), 1, MidpointRounding.AwayFromZero).ToString("0.00"));
                    //计算转换后的差额 统计报表的时候要把这个差额相减,不然可能会统计的金额会有几分钱的差别
                    //o_Difference = o_FinalPayAmt - oldTotalAmt;
                }
                else if (RoundedWayFee == 1)
                {
                    TotalAmt -= 0.1M;
                    o_FinalPayAmt = Convert.ToDecimal(Math.Round(Convert.ToDecimal(TotalAmt), 0, MidpointRounding.AwayFromZero).ToString("0.00"));
                    //计算转换后的差额 统计报表的时候要把这个差额相减,不然可能会统计的金额会有几分钱的差别
                    //o_Difference = o_FinalPayAmt - oldTotalAmt;
                }
                else
                {
                    //TotalAmt -= 0.01M;
                    o_FinalPayAmt = TotalAmt; //Tools.ToDecimal(Math.Round(Tools.ToDecimal(TotalAmt), 2, MidpointRounding.AwayFromZero).ToString("0.00"));
                    //计算转换后的差额 统计报表的时候要把这个差额相减,不然可能会统计的金额会有几分钱的差别
                    //o_Difference = 0; //o_FinalPayAmt - oldTotalAmt;
                }
            }
            else if (ConvertAmount == 2)
            {
                //保留两位小数
                int strLen = TotalAmt.ToString("0.00").IndexOf(".");
                if (RoundedWayFee == 0)
                {
                    if (TotalAmt == Convert.ToDecimal(0.05))
                    {
                        o_FinalPayAmt = 0;
                    }
                    else {
                        point = Convert.ToDecimal(TotalAmt.ToString("0.00").Substring(strLen + 2, 1));

                        if (point > 0 && point < 5)
                            TotalAmt -= 0.05M;
                        o_FinalPayAmt = Convert.ToDecimal(Math.Round(Convert.ToDecimal(TotalAmt), 1, MidpointRounding.AwayFromZero).ToString("0.00"));
                        //计算转换后的差额
                        //o_Difference = o_FinalPayAmt - oldTotalAmt;
                    }
                }
                else if (RoundedWayFee == 1)
                {
                    if (TotalAmt == Convert.ToDecimal(0.5))
                    {
                        o_FinalPayAmt = 0;
                    }
                    else {

                        point = Convert.ToDecimal(TotalAmt.ToString("0.00").Substring(strLen + 1, 1));

                        if (point > 0 && point < 5)
                            TotalAmt -= 0.5M;
                        o_FinalPayAmt = Convert.ToDecimal(Math.Round(Convert.ToDecimal(TotalAmt), 0, MidpointRounding.AwayFromZero).ToString("0.00"));
                        //计算转换后的差额
                        //o_Difference = o_FinalPayAmt - oldTotalAmt;
                    }
                }
            }

            if (_isTrue)
            {
                o_FinalPayAmt = -o_FinalPayAmt;
                o_Difference = o_FinalPayAmt - oldTotalAmt;
            }
            else
            {
                o_Difference = o_FinalPayAmt - oldTotalAmt;
            }
        }
    }
    /// <summary>
    /// 支付方式数据
    /// </summary>
    public class PayModeFee
    {
        public int PayMethodID;
        public string TicketNo;
        public decimal PayFee;
        public int InputFrom;
        //public int PayStID;
        public int Agency;//合作机构
    }

    /// <summary>
    /// 支付用户类型
    /// </summary>
    public enum PAY_USERTYPE
    {
        /// <summary>
        /// 门诊支付类型
        /// </summary>
        puOutPatient = 0,
        /// <summary>
        /// 住院支付类型
        /// </summary>
        puInPatient = 1,
    }

    /// <summary>
    /// 支付金额来源
    /// </summary>
    public enum PAY_FEE_FROM
    {
        /// <summary>
        /// 手工输入
        /// </summary>
        pffManualInput = 0,
        /// <summary>
        /// 自动计算支付金额
        /// </summary>
        pffAutoCalculate = 1

    }

    /// <summary>
    /// 支付方式步骤
    /// </summary>
    public enum PAY_PROCSTEP
    {
        /// <summary>
        /// 手动完成
        /// </summary>
        ppsHandFinsed = 0,
        /// <summary>
        /// 自动完成
        /// </summary>
        ppsAutoFinshed = 1

    }
    /// <summary>
    /// 支付方式结构
    /// </summary>
    public struct PayMethod_Config
    {
        /// <summary>
        /// 支付方式ID
        /// </summary>
        public int PayMethodID;
        /// <summary>
        /// 病人来源: 0-门诊 1-住院
        /// </summary>
        public PAY_USERTYPE PatientType;
        /// <summary>
        /// 支持优先顺序
        /// </summary>
        public int OrderNum;
        /// <summary>
        /// 支付方式名称
        /// </summary>
        public String PayMethodName;
        /// <summary>
        /// 金额来源  0--手工输入  1-自动计算支付金额
        /// </summary>
        public PAY_FEE_FROM InputFrom;
        /// <summary>
        /// 支付凭证号
        /// </summary>
        //public String TicketNo;
        /// <summary>
        /// 支付规则描述:										
        /// </summary>
        public String RuleExplain;
        /// <summary>
        /// 是否记账费用支付方式
        /// </summary>
        public int IsAccountFee;
        /// <summary>
        /// 字体显示颜色
        /// </summary>
        public Color FontColor;
        /// <summary>
        /// 支付步骤 0--未处理  1--开始支付  2--取支付结果  9--试算完成  10--支付完成  11--取消支付
        /// </summary>
        //public PAY_PROCSTEP ProcStep;

        /// <summary>
        /// 处理状态 true==成功
        /// </summary>
        //public bool ProcStatus;

        /// <summary>
        /// 要支付方式总额
        /// </summary>
        //public Decimal NeedPayFee;
        /// <summary>
        /// 实际支付金额，2位小数
        /// </summary>
        //public Decimal PayFee;
        /// <summary>
        /// 是否需要凑整运算
        /// </summary>
        //public bool NeedRound;
        /// <summary>
        /// 凑整费
        /// </summary>
        //public Decimal RoundFee;

        public IntPtr Handle;

        //public int PayStID;
    }
}
