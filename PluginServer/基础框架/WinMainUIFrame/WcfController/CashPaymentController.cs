using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMainUIFrame.WcfController
{
    /// <summary>
    /// 收银支付控制器
    /// </summary>
    [WCFController]
    public class CashPaymentController: WcfServerController
    {
        /// <summary>
        /// 获取支付数据
        /// </summary>
        /// <returns></returns>
        [WCFMethod]
        public ServiceResponseData GetPaymentData()
        {
            int PatTypeID = requestData.GetData<int>(0);
            int UseType = requestData.GetData<int>(1);
            int workId= requestData.GetData<int>(2);

            string strsql = @"SELECT a.PaymentID,UseType,PayOrder,PayName,InputFrom,PayRule,FontColor,b.IsAccountFee FROM Basic_PatTypePayment a 
                                LEFT JOIN dbo.Basic_Payment b ON a.PaymentID=b.PaymentID
                                WHERE PatTypeID={0} AND UseType={1} AND a.WorkID={2} AND b.DelFlag=0
                                ORDER BY a.PayOrder";
            strsql = string.Format(strsql, PatTypeID, UseType, workId);
            DataTable dt = oleDb.GetDataTable(strsql);
            responseData.AddData(dt);
            return responseData;
        }
    }
}
