using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EFWCoreLib.WcfFrame.ServerController;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.DataSerialize;

namespace WinMainUIFrame.WcfController
{
    [WCFController]
    public class TestWcfController : WcfServerController
    {
        [WCFMethod(OpenDBKeys = "SQL2005,SQL20052")]
        public ServiceResponseData Test()
        {
            string strsql = @"select * from basemenu";
            DataTable dt1 = oleDb.GetDataTable(strsql);
            UseDb("SQL20052");
            strsql = @"select * from appcenter";
            DataTable dt2 = oleDb.GetDataTable(strsql);

            responseData.AddData("hello");
            responseData.AddData("world");
            return responseData;
            
        }

        [WCFMethod]
        public ServiceResponseData TestDataTable()
        {
            DataTable dt = new DataTable();
            dt.TableName = "Program";
            dt.Columns.Add("playTime", typeof(string));
            dt.Columns.Add("meridiem", typeof(string));
            dt.Columns.Add("tvProgram", typeof(string));
            dt.Columns.Add("tvStationInfo", typeof(string));
            DataRow newRow = dt.NewRow();
            newRow["playTime"] = "09:10";
            newRow["meridiem"] = "PM";
            newRow["tvProgram"] = "开始";
            newRow["tvStationInfo"] = "东方卫视";
            dt.Rows.Add(newRow);

            responseData.AddData(dt);
            return responseData;
        }
    }
}
