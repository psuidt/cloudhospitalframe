using EFWCoreLib.CoreFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfwControls.HISControl.UCPayMode
{
    /// <summary>
    /// 支付线程类
    /// </summary>
    public class PAY_THREAD : ICloneable
    {
        /// <summary>
        /// 异步计算
        /// </summary>
        public AsynPaymentCalculate paymentCalculate;
        /// <summary>
        /// 病人来源: 0-门诊 1-住院
        /// </summary>
        //public PAY_USERTYPE iPatType;
        /// <summary>
        /// 病人就诊ID号
        /// </summary>
        //public int iPatLstID;
        /// <summary>
        /// 支付方式ID
        /// </summary>
        public int PayMethodID;
        /// <summary>
        /// 病人类型
        /// </summary>
        //public int PayType;
        /// <summary>
        /// 金额来源
        /// </summary>
        public PAY_FEE_FROM InputFrom;
        /// <summary>
        /// 支付金额
        /// </summary>
        public Decimal PayFee;
        /// <summary>
        /// 支付凭证号
        /// </summary>
        public String TicketNo;
        /// <summary>
        /// 接收消息的窗口句柄
        /// </summary>
        public IntPtr Handle;
        /// <summary>
        /// 是否支付成功
        /// </summary>
        public bool Succeed;
        /// <summary>
        /// 支付步骤 0--未处理  1--开始支付  2--取支付结果  9--试算完成  10--支付完成  11--取消支付
        /// </summary>
        public PAY_PROCSTEP ProcStep;
        /// <summary>
        /// 最后操作描述信息
        /// </summary>
        public String LastErrorMessage;
        /// <summary>
        /// 执行支付的线程对象
        /// </summary>
        public Thread PayThread = null;
        /// <summary>
        /// 收费费用明细字符串组合
        /// </summary>
        //public int[] FeeIDs;
        /// <summary>
        /// 医保结算号
        /// </summary>
        //public String SoCityNum;

        #region 支付线程函数

        /// <summary>
        /// 全自动数据接口支付线程函数
        /// </summary>
        public void ExecAutoDataItfPay()
        {
            try
            {
                if (paymentCalculate != null)
                {
                    switch (PayMethodID)
                    {
                        case 1005://优惠
                            PayFee = paymentCalculate.FavorableCalculate(out TicketNo, out ProcStep);//优惠在前台调用，医保病人优惠需扣除医保支付金额
                            break;
                        case 1007://医保报销   1006 医保刷卡
                            PayFee = paymentCalculate.MedicalinsuranceCalculate(out TicketNo, out ProcStep);
                            break;
                        case 1006://医保刷卡
                            PayFee = paymentCalculate.MedicalinsuranceCalculatePers(out TicketNo, out ProcStep);
                            break;
                        default:
                            PayFee = 0;
                            TicketNo = "";
                            ProcStep = PAY_PROCSTEP.ppsAutoFinshed;
                            break;
                    }
                    Succeed = true;
                    WindowsAPI.SendMessage(Handle, UCPayMode2.WM_PAY_STATUS, 1, 0);//发送消息
                }
                else
                    throw new Exception("没有给自动计算支付方式金额对象赋值");
            }
            catch (ThreadAbortException e)
            {
                LastErrorMessage = String.Format("支付线程错误：{0}", e.Message);
                Succeed = false;
                WindowsAPI.SendMessage(Handle, UCPayMode2.WM_PAY_STATUS, 0, 0);//发送消息
            }
            catch (Exception err)
            {
                Succeed = false;
                WindowsAPI.SendMessage(Handle, UCPayMode2.WM_PAY_STATUS, 0, 0);//发送消息
                LastErrorMessage = String.Format("支付线程错误：{0}", err.Message);
            }

        }

        #endregion
        /// <summary>
        /// 析构函数
        /// </summary>
        ~PAY_THREAD()
        {
            if (PayThread != null && PayThread.IsAlive)
            {
                PayThread.Abort();
                PayThread.Join(1000);
            }
        }

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
