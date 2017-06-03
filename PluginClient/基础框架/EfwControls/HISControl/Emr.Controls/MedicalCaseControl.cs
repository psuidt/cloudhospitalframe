using DCSoft.Writer;
using DCSoft.Writer.Dom;
using EfwControls.HISControl.Emr.Controls.Controller;
using EfwControls.HISControl.Emr.Controls.Entity;
using EfwControls.HISControl.Emr.Controls.IView;
using EMR_Entity.BasicData;
using EMR_Entity.HomePage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EfwControls.HISControl.Emr.Controls
{
    public partial class MedicalCaseControl : UserControl,IMedicalCaseControlView
    {
        public MedicalCaseControlController controller;

        #region 界面接口实现
        /// <summary>
        /// 病人ID
        /// </summary>
        private int _currpatlistid;
        [Browsable(false)]
        public int CurrPatListId
        {
            get
            {
                return _currpatlistid;
            }

            set
            {
                _currpatlistid = value;
            }
        }

        /// <summary>
        /// 病人科室ID
        /// </summary>
        private int _patdeptid;
        [Browsable(false)]
        public int PatDeptID
        {
            get
            {
                return _patdeptid;
            }

            set
            {
                _patdeptid = value;
            }
        }

        /// <summary>
        /// 病人科室名称
        /// </summary>
        private string _patdeptname;
        [Browsable(false)]
        public string PatDeptName
        {
            get
            {
                return _patdeptname;
            }

            set
            {
                _patdeptname = value;
            }
        }

        /// <summary>
        /// 操作员ID
        /// </summary>
        private int _empid;
        [Browsable(false)]
        public int EmpId
        {
            get
            {
                return _empid;
            }

            set
            {
                _empid = value;
            }
        }

        /// <summary>
        /// 操作员姓名
        /// </summary>
        private string _empname;
        [Browsable(false)]
        public string EmpName
        {
            get
            {
                return _empname;
            }

            set
            {
                _empname = value;
            }
        }

        private Emr_CaseRecord _curCaseRecord;
        /// <summary>
        /// 当前病案记录对象
        /// </summary>
       public Emr_CaseRecord curCaseRecord
        {
            get
            {
                return _curCaseRecord;
            }
            set
            {
                _curCaseRecord = value;
            }
        }
        #endregion

        public MedicalCaseControl()
        {
            InitializeComponent();
            controller = new MedicalCaseControlController(this);
            writerControl1.CommandControler = writerCommandControler1;
            writerCommandControler1.Start();
            //病案首页默认为表单模式
            writerControl1.ExecuteCommand("FormViewMode", false,"Normal");
        }

        #region 右键菜单设置
        private void SetContextMenu()
        {
            if (Math.Abs(writerControl1.Selection.Length) == 1)
            {
                XTextElement element = this.writerControl1.Selection.ContentElements[0];
                if (element is XTextImageElement)
                {
                    this.writerControl1.ContextMenuStrip = this.cmImage;
                    return;
                }
            }
            bool isInCell = false;
            if (writerControl1.Selection.Cells != null && writerControl1.Selection.Cells.Count > 0)
            {
                isInCell = true;
            }
            else
            {
                XTextContainerElement c = null;
                int index = 0;
                writerControl1.Document.Content.GetCurrentPositionInfo(out c, out index);
                if (c is XTextTableCellElement || c.OwnerCell != null)
                {
                    isInCell = true;
                }
            }
            if (isInCell)
            {
                writerControl1.ContextMenuStrip = cmTableCell;
                return;
            }
            writerControl1.ContextMenuStrip = cmEdit;
        }

        private void writerControl1_SelectionChanged(object eventSender, DCSoft.Writer.WriterEventArgs args)
        {
            SetContextMenu();
        }
        #endregion


        /// <summary>
        /// 保存病案记录
        /// </summary>
        public bool SaveCaseFile()
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.StreamWriter stream = new System.IO.StreamWriter(ms, Encoding.UTF8);
            writerControl1.ExecuteCommand("FileSave", true, stream);
            ms.Position = 0;
            return controller.SaveMedicalCase(ms);
        }

        /// <summary>
        /// 获取病人病案记录和病案内容
        /// </summary>
        /// <param name="patlistid">病人Id</param>
        /// <param name="patDeptID">科室Id</param>
        /// <param name="patDeptName">科室名称</param>
        /// <param name="empid">人员ID</param>
        /// <param name="empName">人员姓名</param>
        public void GetMedicalCase(int patlistid,int patDeptID,string patDeptName,int empid,string empName)
        {
            _currpatlistid = patlistid;
            _patdeptid = patDeptID;
            _patdeptname = patDeptName;
            _empid = empid;
            _empname = empName;
            StreamReader stream = controller.OpenFile(patlistid);
            if (stream != null)
            {
                writerControl1.ExecuteCommand("FileOpen", false, stream);
            }
            else
            {
                //从文件中打开病案首页
                string fileName = Path.Combine( Application.StartupPath, "HomePageTempLate\\CaseTemplate.xml");
                writerControl1.ExecuteCommand("FileOpen", false, fileName);
            }
            //获取病人信息绑定数据源
            MedicalCasePatient casePatInfo = controller.GetCasePatInfoDataSource(patlistid);
            writerControl1.SetDocumentParameterValue("MedicalCasePatient", casePatInfo);

            //获取病人诊断信息绑定数据源
            MedicalCaseDiagoInfo caseDiagInfo = controller.GetCaseDiagInfo(patlistid);
            writerControl1.SetDocumentParameterValue("MedicalCaseDiagoInfo", caseDiagInfo);
            writerControl1.WriteDataFromDataSourceToDocument();
        }

        public void ExportMedicalCase()
        {
            writerControl1.ExecuteCommand("FileSaveAs",true,null);
        }

        public void PrintMedicalCase()
        {
            writerControl1.ExecuteCommand("FilePrint",true,null);
        }
    }
}
