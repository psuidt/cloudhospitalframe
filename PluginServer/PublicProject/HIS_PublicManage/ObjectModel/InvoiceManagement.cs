using HIS_Entity.BasicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_PublicManage.ObjectModel
{
    /// <summary>
    /// 票据处理
    /// </summary>
    public class InvoiceManagement: AbstractObjectModel
    {
        #region 获取当前使用票据号,并使用票号
        /// <summary>
        /// 获取当前使用票据号,并使用票号
        /// </summary>
        /// <param name="invoicetype">票据类型</param>
        /// <param name="_operatorId">当前操作员</param>    
        /// <param name="PerfChar">前缀</param>
        /// <returns></returns>
        public string GetInvoiceCurNOAndUse(InvoiceType invoicetype, int _operatorId,out string PerfChar)
        {
            string invoice_no = "";
            PerfChar = "";
            List<HIS_Entity.BasicData.Basic_Invoice> invoice = null;
            //第一步：查找个人当前可用票据
            invoice = NewObject<Basic_Invoice>().getlist<Basic_Invoice>(" invoicetype=" + (int)invoicetype + " and status=0 and empid =" + _operatorId);
            if (invoice.Count == 0)
            {
                //第二步：查找个人备用票据
                invoice = NewObject<Basic_Invoice>().getlist<Basic_Invoice>(" invoicetype=" + (int)invoicetype + " and status=2 and empid =" + _operatorId);
                if (invoice.Count == 0)
                {
                    throw new Exception("没有可用的发票！请先分配");                   
                }
                else
                {
                    invoice_no = invoice[0].CurrentNO.ToString();
                    PerfChar = invoice[0].PerfChar.Trim();
                    if (IsLastNumber(invoice[0]))
                    {
                        invoice[0].Status = 1; //置用完状态
                    }
                    else
                    {
                        invoice[0].Status = 0; //将备用标志改为在用标志
                        invoice[0].CurrentNO = invoice[0].CurrentNO + 1;
                    }
                    this.BindDb(invoice[0]);
                    invoice[0].save();
                    return invoice_no;
                }
            }
            else
            {
                invoice_no = invoice[0].CurrentNO.ToString();
                PerfChar = invoice[0].PerfChar.Trim();
                if (IsLastNumber(invoice[0]))
                {
                    invoice[0].Status = 1; //置用完状态
                }
                else
                {
                    invoice[0].CurrentNO = invoice[0].CurrentNO + 1;
                }
                this.BindDb(invoice[0]);
                invoice[0].save();
                return invoice_no;
            }
        }
        /// <summary>
        ///  获取当前票据号票据对象
        /// </summary>
        /// <param name="invoicetype">票据类型</param>
        /// <param name="_operatorId">操作员ID</param>
        /// <returns></returns>
        public Basic_Invoice GetInvoiceCurNo(InvoiceType invoicetype, int _operatorId)
        {          
            List<HIS_Entity.BasicData.Basic_Invoice> invoice = null;
            //第一步：查找个人当前可用票据
            invoice = NewObject<Basic_Invoice>().getlist<Basic_Invoice>(" invoicetype=" + (int)invoicetype + " and status=0 and empid =" + _operatorId);
            if (invoice.Count == 0)
            {
                //第二步：查找个人备用票据
                invoice = NewObject<Basic_Invoice>().getlist<Basic_Invoice>(" invoicetype=" + (int)invoicetype + " and status=2 and empid =" + _operatorId);
                if (invoice.Count == 0)
                {
                    throw new Exception("没有可用的发票！请先分配");
                }
                else
                {
                    return invoice[0];                    
                }
            }
            else
            {
                return invoice[0];
            }
        }

        /// <summary>
        /// 获取当前票据号
        /// </summary>
        /// <param name="invoicetype">票据类型</param>
        /// <param name="_operatorId">操作员ID</param>
        /// <param name="PerfChar">票据前缀</param>
        /// <returns></returns>
        public string GetInvoiceCurNo(InvoiceType invoicetype, int _operatorId, out string PerfChar)
        {
            string invoice_no = "";
            PerfChar = "";
            List<HIS_Entity.BasicData.Basic_Invoice> invoice = null;
            //第一步：查找个人当前可用票据
            invoice = NewObject<Basic_Invoice>().getlist<Basic_Invoice>(" invoicetype=" + (int)invoicetype + " and status=0 and empid =" + _operatorId);
            if (invoice.Count == 0)
            {
                //第二步：查找个人备用票据
                invoice = NewObject<Basic_Invoice>().getlist<Basic_Invoice>(" invoicetype=" + (int)invoicetype + " and status=2 and empid =" + _operatorId);
                if (invoice.Count == 0)
                {
                    throw new Exception("没有可用的发票！请先分配");
                }
                else
                {
                    invoice_no = invoice[0].CurrentNO.ToString();
                    PerfChar = invoice[0].PerfChar.Trim();              
                    return invoice_no;
                }
            }
            else
            {
                invoice_no = invoice[0].CurrentNO.ToString();
                PerfChar = invoice[0].PerfChar.Trim();               
                return invoice_no;
            }
        }

        /// <summary>
        /// 判断是否是当前卷中的最后一张票号
        /// </summary>
        /// <param name="invoice">发票卷对象</param>
        /// <returns></returns>
        private bool IsLastNumber(Basic_Invoice invoice)
        {
            if (invoice.CurrentNO == invoice.EndNO)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 获取可用发票张数
        /// <summary>
        /// 获取可用发票张数
        /// </summary>
        /// <param name="invoicetype">票据类型</param>
        /// <param name="OperatorId">操作人员ID</param>
        /// <returns></returns>
        public int GetInvoiceNumberOfCanUse(InvoiceType invoicetype, int OperatorId)
        {
            int count = 0;
            List<Basic_Invoice> invoices = null;
            //第一步：查找个人当前可用票据
            invoices = NewObject<Basic_Invoice>().getlist<Basic_Invoice>("invoicetype=" + (int)invoicetype + " and status=0 and empid =" + OperatorId);
            foreach (Basic_Invoice invoice in invoices)
                count = count + (invoice.EndNO - invoice.CurrentNO + 1);

            //第二步：查找个人备用票据
            invoices = NewObject<Basic_Invoice>().getlist<Basic_Invoice>("invoicetype=" + (int)invoicetype + " and status=2 and empid =" + OperatorId);
            foreach (Basic_Invoice invoice in invoices)
                count = count + (invoice.EndNO - invoice.CurrentNO + 1);

            return count;
        }
        #endregion

        #region 调整票据号
        /// <summary>
        /// 调整票据号
        /// </summary>
        /// <param name="invoicetype">票据类型</param>
        /// <param name="OperatorId">操作员ID</param>
        /// <param name="PerfChar">前缀</param>
        /// <param name="NewInvoiceNo">新票据号</param>
        /// <returns></returns>
        public  bool AdjustInvoiceNo(InvoiceType invoicetype, int OperatorId, string PerfChar, string NewInvoiceNo)
        {
          
          //  Basic_Invoice invoice =(Basic_Invoice) NewObject<Basic_Invoice>().getmodel(" status=0 and empid="+OperatorId+" and invoicetype="+(int)invoicetype+" and perfchar='"+PerfChar+"'");
            List<Basic_Invoice> listInvoice = NewObject<Basic_Invoice>().getlist<Basic_Invoice>(" status=0 and empid=" + OperatorId + " and invoicetype=" + (int)invoicetype + " and perfchar='" + PerfChar + "'");
            int newInvoiceNo = Convert.ToInt32(NewInvoiceNo);
            if (listInvoice != null && listInvoice.Count>0)
            {
                Basic_Invoice invoice = listInvoice[0] as Basic_Invoice;
                if (newInvoiceNo > Convert.ToInt64(invoice.EndNO))
                {
                    throw new Exception("要调整的发票号不能超出本卷票的结束号！");
                }
                if (newInvoiceNo <= Convert.ToInt64(invoice.CurrentNO))
                {
                    throw new Exception("要调整的发票号不能小于当前票号！");
                }
                invoice.CurrentNO = newInvoiceNo;
                this.BindDb(invoice);
                invoice.save();
                return true;
            }
            else
            {
                throw new Exception("没有找到当前在用发票记录！");
            }
        }
        #endregion
    }

    /// <summary>
    /// 票据类型
    /// </summary>
    public enum InvoiceType
    {
        门诊收费, 门诊挂号, 住院预交金, 住院结算,账户充值
    }
}
