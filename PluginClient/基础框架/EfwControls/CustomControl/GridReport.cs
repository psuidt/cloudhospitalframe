using EfwControls.Common;
using EFWCoreLib.WcfFrame;
using EFWCoreLib.WcfFrame.DataSerialize;
using gregn6Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EfwControls.CustomControl
{
    /// <summary>
    /// 报表工具
    /// </summary>
    public class ReportTool
    {

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


        private static DataTable _reportData;
        public static DataTable reportData//缓存报表数据
        {
            get
            {
                return getReportData();
            }
            set
            {
                _reportData = null;
            }
        }
        private static DataTable getReportData()
        {
            if (_reportData == null)
            {
                ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "ReportController", "GetReportData");
                _reportData = retdata.GetData<DataTable>(0);
            }
            return _reportData;
        }
        /// <summary>
        /// 填充数据，获取报表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="reportNo">报表的编码</param>
        /// <param name="printerIndex">打印机索引</param>
        /// <param name="para">报表参数</param>
        /// <param name="datasource">报表数据源</param>
        /// <returns></returns>
        public static GridReport GetReport(int workId, int reportNo, int printerIndex, Dictionary<string, Object> para, DataTable datasource)
        {
            //判断服务器没有报表则创建空报表
            //判断本地没有报表文件则下载报表
            //验证本机报表文件的修改时间与服务器上时间对比，如果小于服务器上时间则下载替换本地报表
            DataRow[] drs = reportData.Select(String.Format("EnumValue={0} and WorkID={1}", reportNo, workId));
            if (drs.Length == 0)//服务器不存在此报表
            {
                MessageBox.Show("请先在报表配置界面增加【" + reportNo + "】此编号的报表！");
                return new GridReport();
            }
            else
            {
                printerIndex = GetPrintIndex(reportNo);//获取打印机

                int reportID = Convert.ToInt32(drs[0]["ID"]);
                string reportFile = drs[0]["FileName"].ToString();
                DateTime updateTime = Convert.ToDateTime(Convert.ToDateTime(drs[0]["UpdateTime"]).ToString("yyyy-MM-dd HH:ss:mm"));
                string _reportFile = EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath + @"Report\\" + reportFile;
                if (File.Exists(_reportFile) ==false)//本地没有报表文件，下载报表文件
                {
                    Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
                    {
                        request.AddData(reportID);
                    });
                    ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "ReportController", "GetReportFile", requestAction);
                    byte[] data = retdata.GetData<byte[]>(0);
                    using (FileStream fsWrite = new FileStream(_reportFile, FileMode.Create))
                    {
                        fsWrite.Write(data, 0, data.Length);
                    }

                    UpgradeFileConfigManager.AddReport(reportFile, updateTime);

                    return GetReport(reportFile, printerIndex, para, datasource);
                }
                else//有报表文件
                {
                    //判断文件修改时间
                    if (UpgradeFileConfigManager.GetReportUpdateTime(reportFile) == null || UpgradeFileConfigManager.GetReportUpdateTime(reportFile) < updateTime)//小于服务更新时间，则下载报表文件
                    {
                        File.Delete(_reportFile);
                        Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
                        {
                            request.AddData(reportID);
                        });
                        ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "ReportController", "GetReportFile", requestAction);
                        byte[] data = retdata.GetData<byte[]>(0);
                        using (FileStream fsWrite = new FileStream(_reportFile, FileMode.Create))
                        {
                            fsWrite.Write(data, 0, data.Length);
                        }
                        UpgradeFileConfigManager.AddReport(reportFile, updateTime);
                        return GetReport(reportFile, printerIndex, para, datasource);
                    }
                    else//等于或者大于服务更新时间
                    {
                        return GetReport(reportFile, printerIndex, para, datasource);
                    }
                }
            }
        }

        /// <summary>
        /// 填充数据，获取报表
        /// </summary>
        /// <param name="reportFile">报表文件</param>
        /// <param name="printerIndex">打印机索引</param>
        /// <param name="para">报表参数</param>
        /// <param name="datasource">报表数据源</param>
        /// <returns></returns>
        public static GridReport GetReport(string reportFile, int printerIndex, Dictionary<string, Object> para, DataTable datasource)
        {
            reportFile = EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath + @"Report\\" + reportFile;
            //报表文件不存在创建空的报表格式
            GridReport report = new GridReport(reportFile, para, datasource);
            report.Report.Printer.PrinterName = CustomConfigManager.GetPrintName(printerIndex);
            report.Report.PrintAsDesignPaper = true;
            report.Report.DesignPaperOrientation = report.Report.DesignPaperOrientation;
            return report;
        }

        private static System.Xml.XmlDocument xmlDoc_Print = null;
        /// <summary>
        /// 根据本地配置文件获取报表的打印机索引
        /// </summary>
        /// <param name="reportNo"></param>
        /// <returns></returns>
        private static int GetPrintIndex(int reportNo)
        {
            try {
                if (xmlDoc_Print == null)
                {
                    xmlDoc_Print = new System.Xml.XmlDocument();
                    xmlDoc_Print.Load(EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath + @"Config/ReportPrint.xml");
                }

                System.Xml.XmlNode xn = xmlDoc_Print.DocumentElement.SelectSingleNode("report[@No='" + reportNo + "']");
                if (xn != null)
                {
                    return Convert.ToInt32(xn.Attributes["printIndex"].Value);
                }

                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// 报表打印预览工具
    /// </summary>
    public class GridReport
    {
        public GridppReport Report;
        private DataTable _datasource;
        public GridReport() { }
        public GridReport(string reportfile, Dictionary<string, Object> para, DataTable datasource)
        {
            _datasource = datasource;
            Report = new GridppReport();
            //载入报表模板
            Report.LoadFromFile(reportfile);
            if (para != null)
                GridReport.AddParamToReport(Report, para);
            //连接报表事件
            Report.Initialize += new _IGridppReportEvents_InitializeEventHandler(ReportInitialize);
            Report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ReportFetchRecord);
        }

        private void ReportInitialize()
        {
            //在此记录下每个字段的接口指针
            //C1Field = Report.FieldByName("c1");
            //I1Field = Report.FieldByName("i1");
            //F1Field = Report.FieldByName("f1");
        }

        //在C#中一次填入一条记录不能成功，只能使用一次将记录全部填充完的方式
        private void ReportFetchRecord()
        {
            //将全部记录一次填入
            //Report.DetailGrid.Recordset.Append();
            //FillRecord1();
            //Report.DetailGrid.Recordset.Post();

            //Report.DetailGrid.Recordset.Append();
            //FillRecord2();
            //Report.DetailGrid.Recordset.Post();

            //Report.DetailGrid.Recordset.Append();
            //FillRecord3();
            //Report.DetailGrid.Recordset.Post();
            if (_datasource != null)
                GridReport.FillRecordToReport(Report, _datasource);
        }

        /// <summary>
        /// 预览
        /// </summary>
        /// <param name="ShowModal"></param>
        public void PrintPreview(bool ShowModal)
        {
            if (Report != null)
                Report.PrintPreview(ShowModal);
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="ShowModal"></param>
        public void Print(bool ShowModal)
        {
            if (Report != null)
                Report.Print(ShowModal);
        }

        /// <summary>
        /// 将 对象 的属性数据转储到 Grid++Report 的参数中
        /// </summary>
        /// <param name="Report"></param>
        /// <param name="obj"></param>
        public static void AddParamToReport(IGridppReport Report, Object obj)
        {
            int obj_propertyNum = obj.GetType().GetProperties().Length;
            int rpt_parmNum = Report.Parameters.Count;
            string propertyName, parmName;
            for (int i = 0; i < obj_propertyNum; i++)
            {
                for (int j = 1; j <= rpt_parmNum; j++)
                {
                    propertyName = obj.GetType().GetProperties()[i].Name;
                    parmName = Report.Parameters[j].Name;

                    if (propertyName == parmName)
                    {
                        object obj1 = obj.GetType().GetProperties()[i].GetValue(obj, null);
                        Report.Parameters[j].Value = obj1;
                    }
                }
            }
        }
        /// <summary>
        /// 将 字典数据转储到 Grid++Report 的参数中
        /// </summary>
        /// <param name="Report"></param>
        /// <param name="obj"></param>
        public static void AddParamToReport(IGridppReport Report, Dictionary<string,Object> dic)
        {
            //int obj_propertyNum = dic.Count;
            int rpt_parmNum = Report.Parameters.Count;
            string propertyName, parmName;
            foreach (var item in dic)
            {
                for (int j = 1; j <= rpt_parmNum; j++)
                {
                    propertyName = item.Key;
                    parmName = Report.Parameters[j].Name;
                    if (propertyName == parmName)
                    {
                        Report.Parameters[j].Value = item.Value;
                    }
                }
            }
        }
        /// <summary>
        /// 将 DataTable 的数据转储到 Grid++Report 的网格中
        /// </summary>
        /// <param name="Report"></param>
        /// <param name="dt"></param>
        public static void FillRecordToReport(IGridppReport Report, DataTable dt)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dt.Columns.Count; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }


            // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
            foreach (DataRow dr in dt.Rows)
            {
                Report.DetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
                }

                Report.DetailGrid.Recordset.Post();
            }
        }


        public static uint RGBToOleColor(byte r, byte g, byte b)
        {
            return ((uint)b) * 256 * 256 + ((uint)g) * 256 + r;
        }

        public static uint ColorToOleColor(System.Drawing.Color val)
        {
            return RGBToOleColor(val.R, val.G, val.B);
        }

        private struct MatchFieldPairType
        {
            public IGRField grField;
            public int MatchColumnIndex;
        }
    }
}
