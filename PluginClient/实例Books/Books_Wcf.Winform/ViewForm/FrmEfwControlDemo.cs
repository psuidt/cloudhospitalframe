using Books_Wcf.Winform.IView;
using DevComponents.DotNetBar;
using EfwControls.HISControl.BedCard.Controls;
using EFWCoreLib.CoreFrame.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Books_Wcf.Winform.ViewForm
{
    public partial class FrmEfwControlDemo : BaseFormBusiness, IfrmEfwControlDemo
    {
        public FrmEfwControlDemo()
        {
            InitializeComponent();

            dataGrid1.GroupLine = new EfwControls.CustomControl.PaintGroupLineHandle(PaintGroupLine); 
        }
        private void PaintGroupLine(int rowIndex, out int colIndex, out int groupFlag)
        {
            colIndex = 1;
            groupFlag = 1;
        }

        public void bindDept_multiSelectText(DataTable dt)
        {
            multiSelectText1.displayField = "Name";
            multiSelectText1.valueField = "DeptId";
            //multiSelectText1.CardColumn = "DeptId|编码|100,Name|科室名称|auto";
            //multiSelectText1.QueryFieldsString = "Name,Pym,Wbm";
            //multiSelectText1.multiSelectTextType = EfwControls.CustomControl.MultiSelectTextType.CheckBox;
            multiSelectText1.DataSource = dt;

            multiSelectText2.displayField = "Name";
            multiSelectText2.valueField = "DeptId";
            multiSelectText2.CardColumn = "DeptId|编码|100,Name|科室名称|auto";
            multiSelectText2.QueryFieldsString = "Name,Pym,Wbm";
            //multiSelectText2.multiSelectTextType = EfwControls.CustomControl.MultiSelectTextType.Grid;
            multiSelectText2.DataSource = dt.Copy();
        }
        

        public void bindDisease_datagridpage(DataTable dt, int totalCount)
        {
            pager1.SetPagerDataSource(totalCount, dt);
        }

        public void bindDisease_textboxcard(DataTable dt)
        {
            textBoxCard1.DisplayField = "Name";
            textBoxCard1.MemberField = "ICDCode";
            textBoxCard1.CardColumn = "ID||50,ICDCode|编码|100,Name|诊断名称|auto";
            textBoxCard1.QueryFieldsString = "ID,Name,PYCode,WBCode";
            textBoxCard1.ShowCardWidth = 350;
            textBoxCard1.ShowCardDataSource = dt;
        }

        public void bindDiaease_gridboxcardSD(DataTable sourceDt)
        {
            gridBoxCard1.SelectionCards[0].BindColumnIndex = 1;
            gridBoxCard1.SelectionCards[0].CardColumn= "ID||50,ICDCode|编码|100,Name|诊断名称|auto";
            gridBoxCard1.SelectionCards[0].CardSize= new System.Drawing.Size(350, 276);
            gridBoxCard1.SelectionCards[0].QueryFieldsString= "ID,Name,PYCode,WBCode";
            gridBoxCard1.BindSelectionCardDataSource(0, sourceDt);
        }

        public void bindDiaease_gridboxcard(DataTable dt)
        {
            gridBoxCard1.DataSource = dt;
        }

        private void FrmEfwControlDemo_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("loadDiseaseData");
            InvokeController("loadDeptData");
            InvokeController("loadDiseasePage", 1, pager1.pageSize);

            InvokeController("loadDiseaseDataGrid");

            LoadBedData();




            InitBedContor();
            LoadBedDataNew();
        }

        private void pager1_PageNoChanged(object sender, int pageNo, int pageSize)
        {
            InvokeController("loadDiseasePage", pageNo, pageSize);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show(textBoxCard1.MemberValue.ToString());
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show(multiSelectText1.SelectValue.ToString());
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show("开始时间：" + statDateTime1.Bdate.Value.ToString() + "\n结算时间：" + statDateTime1.Edate.Value.ToString());
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            MessageBoxEx.Show(multiSelectText2.SelectValue.ToString());
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }

        public bool SetGridState
        {
            set
            {
                bool b = value;
                if (b == false)
                {
                    gridBoxCard1.ReadOnly = false;
                    gridBoxCard1.Columns[0].ReadOnly = true;
                    gridBoxCard1.Columns[1].ReadOnly = false;
                    gridBoxCard1.Columns[2].ReadOnly = false;
                    gridBoxCard1.Columns[3].ReadOnly = false;
                }
                else
                {
                    gridBoxCard1.ReadOnly = true;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetGridState = false;
            gridBoxCard1.AddRow();
        }

        private void btnAlter_Click(object sender, EventArgs e)
        {
            SetGridState = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gridBoxCard1.CurrentCell != null)
            {
                //int colid = this.gridBoxCard1.CurrentCell.ColumnIndex;
                int rowid = this.gridBoxCard1.CurrentCell.RowIndex;
                DataTable dt = (DataTable)gridBoxCard1.DataSource;

                dt.Rows.RemoveAt(rowid);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gridBoxCard1.EndEdit();
            SetGridState = true;
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            gridBoxCard1.EndEdit();
            DataTable dt = (DataTable)gridBoxCard1.DataSource;
            dt.Clear();
        }

        private void gridBoxCard1_SelectCardRowSelected(object SelectedValue,ref bool stop,ref int customNextColumnIndex)
        {
            try
            {
                DataRow row = (DataRow)SelectedValue;
                int colid = this.gridBoxCard1.CurrentCell.ColumnIndex;
                int rowid = this.gridBoxCard1.CurrentCell.RowIndex;
                DataTable dt = (DataTable)gridBoxCard1.DataSource;

                dt.Rows[rowid]["ID"] = 0;
                dt.Rows[rowid]["ICDCode"] = row["ICDCode"];
                dt.Rows[rowid]["Name"] = row["Name"];
                dt.Rows[rowid]["PYCode"] = row["PYCode"];
                dt.Rows[rowid]["WBCode"] = row["WBCode"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }


        private void LoadBedData()
        {
            //第一步：添加床头卡要显示的内容项
            bedCardControl1.BedContextFields = new List<ContextField>();
            bedCardControl1.BedContextFields.Add(new ContextField("住院号", "PatientNum"));
            bedCardControl1.BedContextFields.Add(new ContextField("结 算", "Diet"));
            //bedCardControl1.BedContextFields.Add(new ContextField("诊 断", "Diagnosis"));
            bedCardControl1.BedContextFields.Add(new ContextField("科 室", "Dept"));
            bedCardControl1.BedContextFields.Add(new ContextField("医 生", "Doctor"));
            bedCardControl1.BedContextFields.Add(new ContextField("入 科", "EnterTime"));
            //other
            //bedCardControl1.BedContextFields.Add(new ContextField("其 他", "other"));

            //第二步：获取病人数据，数据必须是List集合
            List<BedInfo> list = new List<BedInfo>();

            for (int i = 0; i < 20; i++)//前20病人显示信息
            {
                //支持自定义床头卡的内容显示
                BedInfo bed = new BedInfo();
                bed.BedNo = i.ToString();
                bed.PatientID = i + 1;
                bed.PatientNum = "0000012" + i;
                bed.PatientName = "昂三" + i;
                if (i % 3 == 0)
                    bed.Sex = "男";
                else
                    bed.Sex = "女";
                bed.Age = "11岁";
                bed.Diet = "计算";
                bed.Diagnosis = "诊断是的安定和水电费水电费和、安定和水电费水电费和";
                bed.Dept = "妇产科";
                bed.Doctor = "李医生";
                bed.Nurse = "03";
                bed.EnterTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
                //bed.other = "!@#$%^&";
                list.Add(bed);
            }
            //后面的显示空床位
            for (int i = 20; i < 34; i++)
            {
                BedInfo bed = new BedInfo();
                bed.BedNo = i.ToString();
                list.Add(bed);
            }
            //第三步：将病人数据绑定到数据源上显示
            bedCardControl1.DataSource = list;
        }
        private DataTable getReportData()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("C1", typeof(String));
            dt.Columns.Add(dc);
            dc = new DataColumn("I1", typeof(Int32));
            dt.Columns.Add(dc);
            dc = new DataColumn("F1", typeof(Decimal));
            dt.Columns.Add(dc);

            for (int i = 0; i < 20; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "Test" + i;
                dr[1] = i + 100;
                dr[2] = i * 0.33;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int workId = ((InvokeController("this") as AbstractController).LoginUserInfo.WorkId);
            int reportNo = Convert.ToInt32(textBoxX1.Text);
            EfwControls.CustomControl.ReportTool.GetReport(workId, reportNo, 0, null, getReportData()).PrintPreview(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int workId = ((InvokeController("this") as AbstractController).LoginUserInfo.WorkId);
            int reportNo = Convert.ToInt32(textBoxX1.Text);
            EfwControls.CustomControl.ReportTool.GetReport(workId, reportNo, 0, null, getReportData()).Print(true);
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(openFileDialog1.FileName);
                textBoxX2.Text = file.Name;
                textBoxX2.Tag = openFileDialog1.FileName;
            }
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            if (textBoxX2.Tag != null)
                InvokeController("SaveReport", integerInput1.Value, textBoxX2.Text, textBoxX2.Tag.ToString());
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            InvokeController("ShowDialog", "Form1");
        }

        private void buttonX10_Click(object sender, EventArgs e)
        {
            InvokeController("ShowDialog", "FrmSettlementPanel2");
        }
        //异步调用
        private void buttonX11_Click(object sender, EventArgs e)
        {
            AsynInvoked((() =>
            {
                Thread.Sleep(2000);
                //throw new Exception("error asyn");
                return null;
            }), ((object result) =>
             {

             }));
        }

        private void buttonX12_Click(object sender, EventArgs e)
        {
            MessageBoxShowSimple("删除成功！");
        }

        private void buttonX13_Click(object sender, EventArgs e)
        {
            MessageBox.Show(EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetSpellCode("美国许瓦兹Schwarz Pharma Manufacturing, Inc.(珠海许瓦兹制药有限公司分装)"));
        }

        private void buttonX14_Click(object sender, EventArgs e)
        {

        }

        private void buttonX15_Click(object sender, EventArgs e)
        {
            InvokeController("ShowDialog", "FrmIPDOrder");
        }

        private void buttonX16_Click(object sender, EventArgs e)
        {
            InvokeController("OpenBrowser");
        }

        #region 新床头卡
        private void InitBedContor()
        {
            //第一步：添加床头卡要显示的内容项
            bedCardControlNew1.BedContextFields = new List<ContextField>();
            bedCardControlNew1.BedContextFields.Add(new ContextField("住院号", "PatientNum"));
            bedCardControlNew1.BedContextFields.Add(new ContextField("结算", "Diet"));
            bedCardControlNew1.BedContextFields.Add(new ContextField("科室", "Dept"));
            bedCardControlNew1.BedContextFields.Add(new ContextField("医生", "Doctor"));
            bedCardControlNew1.BedContextFields.Add(new ContextField("护士", "Nurse"));
            bedCardControlNew1.BedContextFields.Add(new ContextField("类型", "PatTypeName"));
            bedCardControlNew1.BedContextFields.Add(new ContextField("入科", "EnterTime"));
            bedCardControlNew1.BedContextFields.Add(new ContextField("诊断", "Diagnosis"));
        }
        private void LoadBedDataNew()
        {           
            //other
            //bedCardControl1.BedContextFields.Add(new ContextField("其 他", "other"));

            //第二步：获取病人数据，数据必须是List集合
            List<BedInfo> list = new List<BedInfo>();

            for (int i = 0; i < 20; i++)//前20病人显示信息
            {
                //支持自定义床头卡的内容显示
                BedInfo bed = new BedInfo();
                bed.BedNo = "W" + i.ToString();
                bed.PatientID = i + 1;
                bed.PatientNum = "0000012" + i;
                bed.PatientName = "昂三" + i;
                if (i % 3 == 0)
                    bed.Sex = "男";
                else
                    bed.Sex = "女";
                bed.Age = "120岁";
                bed.Diet = "计算";
                bed.PatTypeName = "居民医保";
                bed.Diagnosis = "诊断是的安定和水电费水电费和、安定和水电费水电费和";
                bed.Dept = "妇产科";
                bed.Doctor = "李医生";
                bed.Nurse = "王美女";
                bed.NursingLever = "3";
                bed.EnterTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm");
                bed.Situation = (i % 5).ToString();
                bed.NursingLever = (i % 5).ToString();
                bed.DietType = (i % 6).ToString();
                if (i > 16)
                {
                    bed.Group = true;
                }
                if (i == 15)
                {
                    bed.Step = 8;
                }
                //bed.other = "!@#$%^&";
                list.Add(bed);
            }
            //后面的显示空床位
            for (int i = 20; i < 34; i++)
            {
                BedInfo bed = new BedInfo();
                bed.BedNo = i.ToString();
                list.Add(bed);
            }
            //第三步：将病人数据绑定到数据源上显示
            bedCardControlNew1.DataSource = list;
        }
        #endregion

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            //bedCardControlNew1.Simple = checkBoxX1.Checked;
            LoadBedDataNew();
        }

        private void buttonX17_Click(object sender, EventArgs e)
        {
            InvokeController("SaveEmrFile");
        }

        private void buttonX18_Click(object sender, EventArgs e)
        {
            InvokeController("GetEmrFile");
        }
    }
}
