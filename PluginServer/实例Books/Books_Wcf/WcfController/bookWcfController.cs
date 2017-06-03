using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ServerController;
using Books_Wcf.Entity;
using System.Data;
using Books_Wcf.Dao;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.CoreFrame.DbProvider.SqlPagination;
using EFWCoreLib.CoreFrame.Common;
using System.Drawing;
using System.Data.Common;
using EFWCoreLib.CoreFrame.EntLib.Aop;
using EFWCoreLib.CoreFrame.DbProvider.Transaction;

namespace Books_Wcf.WcfController
{
    [WCFController]
    public class bookWcfController : WcfServerController
    {
        [WCFMethod]
        public ServiceResponseData SaveBook()
        {
            Books book = requestData.GetData<Books>(0);
            //book.BindDb(oleDb, _container,_cache,_pluginName);//反序列化的对象，必须绑定数据库操作对象
            this.BindDb(book);
            book.save();
            responseData.AddData(true);
            return responseData;
        }

        [WCFMethod]
        public ServiceResponseData GetBooks()
        {
            try  {
                int[] vals= requestData.GetData<int[]>(0);
                MiddlewareLogHelper.WriterLog(LogType.MILog, true, Color.Red, "医保接口日志记录");
                DataTable dt = NewDao<IBookDao>().GetBooks("", 0);
                responseData.AddData(vals);
                responseData.AddData(dt);
                return responseData;
            }
            catch (Exception e)
            {
                throw new Exception("hhyhwhs");
            }
        }
        
        [WCFMethod]
        public ServiceResponseData GetDiseasePage()
        {
            int pageNo = requestData.GetData<int>(0);
            int pageSize= requestData.GetData<int>(1);
            PageInfo page = new PageInfo(pageSize, pageNo);
            page.KeyName = "ID";
            DataTable dt = oleDb.GetDataTable(SqlPage.FormatSql(@"SELECT  ID ,
                                                        ICDCode ,
                                                        Name ,
                                                        PYCode ,
                                                        WBCode ,
                                                        Type FROM HISDB..His_Disease",page,oleDb));
            responseData.AddData(dt);
            responseData.AddData(page.totalRecord);
            return responseData;
        }

        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData GetDiseaseData()
        {
            DataTable dt = oleDb.GetDataTable(@"SELECT  ID ,
                                                        ICDCode ,
                                                        Name ,
                                                        PYCode ,
                                                        WBCode ,
                                                        Type FROM HISDB..His_Disease");
            responseData.AddData(dt);
            return responseData;
        }


        [WCFMethod]
        public ServiceResponseData GetDeptData()
        {
            DataTable dt = oleDb.GetDataTable(@"SELECT  DeptId ,
                                                        Name ,
                                                        Pym ,
                                                        Wbm FROM HISDB..BaseDept");
            responseData.AddData(dt);
            return responseData;
        }

        [WCFMethod]
        public ServiceResponseData TestProc()
        {
            IDbCommand cmd = oleDb.GetProcCommand("SP_DW_CheckAccount");
            oleDb.AddInParameter(cmd as DbCommand, "@WorkID", DbType.Int32, 1);
            oleDb.AddInParameter(cmd as DbCommand, "@DeptID", DbType.Int32, 1);
            oleDb.AddOutParameter(cmd as DbCommand, "@ErrCode", DbType.Int32, 5);
            oleDb.AddOutParameter(cmd as DbCommand, "@ErrMsg", DbType.AnsiString, 200);
            oleDb.DoCommand(cmd);
            string data = oleDb.GetParameterValue(cmd as DbCommand, "@ErrMsg").ToString();
            responseData.AddData(data);
            return responseData;
        }

        [WCFMethod]
        public ServiceResponseData GetDrugItemData()
        {
            int[] data = requestData.GetData<int[]>(0);
            //DataTable dt = oleDb.GetDataTable(@"SELECT  * FROM ViewFeeItem_SimpleList");
            //responseData.AddData(dt);
            responseData.AddData(data);
            return responseData;
        }

        [WCFMethod]
        public ServiceResponseData GetOrders()
        {
            DataTable dt = oleDb.GetDataTable(@"SELECT  * FROM IPD_OrderRecord");
            responseData.AddData(dt);
            return responseData;
        }
    }
}

