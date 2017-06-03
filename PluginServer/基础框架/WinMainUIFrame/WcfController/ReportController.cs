using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.CoreFrame.Init;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMainUIFrame.WcfController
{
    /// <summary>
    /// 报表控制器
    /// </summary>
    [WCFController]
    public class ReportController: WcfServerController
    {
        /// <summary>
        /// 获取机构报表数据
        /// </summary>
        /// <returns></returns>
        [WCFMethod]
        public ServiceResponseData GetReportData()
        {
            //int workId = requestData.GetData<int>(0);
            string strsql = @"SELECT  ID,EnumValue,FileName,UpdateTime,WorkID FROM Basic_ReportConfig WHERE DelFlag=0";
            DataTable dt = oleDb.GetDataTable(strsql);
            responseData.AddData(dt);
            return responseData;
        }
        [WCFMethod]
        public ServiceResponseData GetReportFile()
        {
            int Id = requestData.GetData<int>(0);
            string strsql = @"SELECT Format FROM Basic_ReportConfig WHERE ID={0}";
            byte[] data = oleDb.GetBlobData(String.Format(strsql, Id));
            responseData.AddData(data);
            return responseData;
        }

        [WCFMethod]
        public ServiceResponseData SaveReportData()
        {
            int reportNo = requestData.GetData<int>(0);
            string name = requestData.GetData<string>(1);

            string strsql = @"SELECT TOP 1 ID FROM Basic_ReportConfig WHERE EnumValue={0} AND WorkID={1}";
            strsql = string.Format(strsql, reportNo, oleDb.WorkId);
            int val = ConvertExtend.ToInt32(oleDb.GetDataResult(strsql), 0);
            if (val == 0)
            {
                strsql = @"INSERT INTO Basic_ReportConfig
                                        ( ReportType ,EnumValue ,ReportTitle ,WBCode ,PYCode ,FileName ,UpdateTime , Modifyer ,DelFlag ,WorkID)
                                VALUES  (0,{0},'{1}','{2}','{3}','{4}',GETDATE(),{5},0,{6})";
                strsql = String.Format(strsql, reportNo, name, SpellAndWbCode.GetSpellCode(name), SpellAndWbCode.GetWBCode(name), reportNo + "." + name, LoginUserInfo.EmpId, oleDb.WorkId);
                int key = oleDb.InsertRecord(strsql);
                responseData.AddData(key);
            }
            else
            {
                strsql = @"UPDATE Basic_ReportConfig SET UpdateTime=GETDATE(),Modifyer={0} WHERE ID={1}";
                strsql = string.Format(strsql, LoginUserInfo.EmpId, val);
                oleDb.DoCommand(strsql);
                responseData.AddData(val);
            }
            return responseData;
        }

        [WCFMethod]
        public ServiceResponseData SaveReportFile()
        {
            int Id = requestData.GetData<int>(0);
            byte[] buffur = requestData.GetData<byte[]>(1);

            //FileStream fs = new FileStream(AppGlobal.AppRootPath + @"Report\\test.grf", FileMode.Open, FileAccess.Read);
            //byte[] buffur = new byte[fs.Length];
            //fs.Read(buffur, 0, (int)fs.Length);
            //if (fs != null)
            //{
            //    //关闭资源  
            //    fs.Close();
            //}

            string strsql = @"UPDATE Basic_ReportConfig SET Format=@blob WHERE ID={0}";
            oleDb.SaveBlobData(String.Format(strsql, Id), buffur);
            responseData.AddData(true);
            return responseData;
        }
    }
}
