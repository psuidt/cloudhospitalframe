using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.WcfFrame.ClientController;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using Books_Wcf.Winform.IView;
using System.Data;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.CoreFrame.DbProvider.SqlPagination;
using System.Windows.Forms;
using System.IO;
using EfwControls.CustomControl;
using HIS_Entity.Mongo;

namespace Books_Wcf.Winform.Controller
{
    [WinformController(DefaultViewName = "frmBookManager")]//在菜单上显示
    [WinformView(Name = "frmBookManager", DllName = "Books_Wcf.Winform.dll", ViewTypeName = "Books_Wcf.Winform.ViewForm.frmBookManager")]//控制器关联的界面
    [WinformView(Name = "FrmEfwControlDemo", DllName = "Books_Wcf.Winform.dll", ViewTypeName = "Books_Wcf.Winform.ViewForm.FrmEfwControlDemo")]//控制器关联的界面
    [WinformView(Name = "Form1", DllName = "Books_Wcf.Winform.dll", ViewTypeName = "Books_Wcf.Winform.ViewForm.Form1")]//控制器关联的界面
    [WinformView(Name = "FrmSettlementPanel2", DllName = "Books_Wcf.Winform.dll", ViewTypeName = "Books_Wcf.Winform.ViewForm.FrmSettlementPanel2")]//控制器关联的界面
    [WinformView(Name = "FrmIPDOrder", DllName = "Books_Wcf.Winform.dll", ViewTypeName = "Books_Wcf.Winform.ViewForm.FrmIPDOrder")]//控制器关联的界面

    public class bookwcfclientController : WcfClientController
    {
        IfrmBookManager _ifrmbookmanager;
        IfrmEfwControlDemo _ifrmEfwControlDemo;
        public override void Init()
        {
            _ifrmbookmanager = (IfrmBookManager)DefaultView;
            _ifrmEfwControlDemo = iBaseView["FrmEfwControlDemo"] as IfrmEfwControlDemo;
            
        }

        //保存
        [WinformMethod]
        public void bookSave()
        {
            if (MessageBoxShowYesNo("是否需要保持？") == DialogResult.Yes)
            {
                Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
                {
                    request.AddData(_ifrmbookmanager.currBook);
                });

                //通过wcf服务调用bookWcfController控制器中的SaveBook方法，并传递参数Book对象
                InvokeWcfService("Books.Service", "bookWcfController", "SaveBook", requestAction);
                GetBooks();
            }
        }

        //获取书籍目录
        [WinformMethod]
        public void GetBooks()
        {
            //通过wcf服务调用bookWcfController控制器中的GetBooks方法
            ServiceResponseData retdata = InvokeWcfService("Books.Service", "bookWcfController", "GetBooks");            
            DataTable dt = retdata.GetData<DataTable>(0);      
            _ifrmbookmanager.loadbooks(dt);
        }

        [WinformMethod]
        public void loadDiseaseData()
        {
            ServiceResponseData retdata = InvokeWcfService("Books.Service", "bookWcfController", "GetDiseaseData");
            DataTable dt = retdata.GetData<DataTable>(0);
            _ifrmEfwControlDemo.bindDisease_textboxcard(dt);
        }
        [WinformMethod]
        public void loadDiseasePage(int pageNo, int pageSize)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(pageNo);
                request.AddData(pageSize);
            });
            ServiceResponseData retdata = InvokeWcfService("Books.Service", "bookWcfController", "GetDiseasePage",requestAction);
            DataTable dt = retdata.GetData<DataTable>(0);
            int totalRecord = retdata.GetData<int>(1);
            _ifrmEfwControlDemo.bindDisease_datagridpage(dt, totalRecord);
        }
        [WinformMethod]
        public void loadDeptData()
        {
            ServiceResponseData retdata = InvokeWcfService("Books.Service", "bookWcfController", "GetDeptData");
            DataTable dt = retdata.GetData<DataTable>(0);
            _ifrmEfwControlDemo.bindDept_multiSelectText(dt);
        }


        [WinformMethod]
        public void loadDiseaseDataGrid()
        {
            ServiceResponseData retdata = InvokeWcfService("Books.Service", "bookWcfController", "GetDiseaseData");
            DataTable dt = retdata.GetData<DataTable>(0);
            _ifrmEfwControlDemo.bindDiaease_gridboxcard(dt.Clone());
            _ifrmEfwControlDemo.bindDiaease_gridboxcardSD(dt);
        }
        [WinformMethod]
        public void SaveReport(int reportno, string reportname, string file)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(reportno);
                request.AddData(reportname);
            });
            ServiceResponseData retdata = InvokeWcfService("MainFrame.Service", "ReportController", "SaveReportData", requestAction);
            int key = retdata.GetData<int>(0);

            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            byte[] buffur = new byte[fs.Length];
            fs.Read(buffur, 0, (int)fs.Length);
            if (fs != null)
            {
                //关闭资源  
                fs.Close();
            }

            requestAction = ((ClientRequestData request) =>
            {
                request.AddData(key);
                request.AddData(buffur);
            });
            retdata = InvokeWcfService("MainFrame.Service", "ReportController", "SaveReportFile", requestAction);
            if (retdata.GetData<bool>(0))
            {
                ReportTool.reportData = null;
                MessageBox.Show("上传成功！");
            }
        }
        public void OpenBrowser()
        {
            InvokeController("MainFrame.UI", "wcfclientLoginController", "ShowBrowser", "百度", "https://email.sinocare.com/owa/auth/logon.aspx");
        }
        string emrid = null;
        [WinformMethod]
        public void SaveEmrFile()
        {
            FileStream fs = new FileStream(@"c:\emr.xml", FileMode.Open, FileAccess.Read);
            EmrPatData data = new EmrPatData();
            data.emrName = "入院记录";
            data.emrData = StreamToBytes(fs); fs.Close();
            data.workId = 1;
            Action<ClientRequestData>  requestAction = ((ClientRequestData request) =>
            {
                request.AddData(data);
            });
            ServiceResponseData retdata = InvokeWcfService("EMRMongoDB.Service", "EMRStoreController", "SaveEmr", requestAction);
            if (retdata.GetData<bool>(0))
            {
                emrid = retdata.GetData<string>(1);
                MessageBox.Show(emrid);
            }
        }

        [WinformMethod]
        public void GetEmrFile()
        {
            if (emrid == null) return;
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(emrid);
            });
            ServiceResponseData retdata = InvokeWcfService("EMRMongoDB.Service", "EMRStoreController", "GetEmr", requestAction);
            if (retdata.GetData<bool>(0))
            {
                EmrPatData data = retdata.GetData<EmrPatData>(1);
                MessageBox.Show(data.emrData.Length.ToString());
            }
        }

        private byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}

