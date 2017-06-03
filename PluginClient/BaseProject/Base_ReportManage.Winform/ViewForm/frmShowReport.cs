using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using base_reportmanage.winform.IView;
using EFWCoreLib.WinformFrame.Controller;
using base_reportmanage.Entity;
using grproLib;

namespace base_reportmanage.winform.ViewForm
{
    public partial class frmShowReport : BaseForm, IfrmShowReport
    {
        public frmShowReport()
        {
            InitializeComponent();
        }

        #region IfrmShowReport 成员
        private void recursionLayer(List<BaseReportLayer> alllayerList, int pid, TreeNode pNode, List<BaseReportTitle> titleList)
        {
            List<BaseReportLayer> _layerList = alllayerList.FindAll(x => x.PLayerId == pid);
            foreach (BaseReportLayer val in _layerList)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                pNode.Nodes.Add(_node);
                loadTitle(titleList, val.LayerId, _node);
                recursionLayer(alllayerList, val.LayerId, _node, titleList);
            }
        }

        private void loadTitle(List<BaseReportTitle> titleList, int layerId, TreeNode node)
        {
            List<BaseReportTitle> _titlelist = titleList.FindAll(x => x.LayerId == layerId);
            foreach (BaseReportTitle val in _titlelist)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                _node.ForeColor = Color.Blue;
                node.Nodes.Add(_node);
            }
        }

        public void loadLayerTree(List<BaseReportLayer> layerList, List<BaseReportTitle> usertitleList)
        {
            treeView1.Nodes.Clear();
            List<BaseReportLayer> _layerList = layerList.FindAll(x => x.PLayerId == -1);
            foreach (BaseReportLayer val in _layerList)
            {
                TreeNode _node = new TreeNode();
                _node.Text = val.Name;
                _node.Tag = val;
                treeView1.Nodes.Add(_node);
                loadTitle(usertitleList, val.LayerId, _node);
                recursionLayer(layerList, val.LayerId, _node, usertitleList);
            }

            treeView1.ExpandAll();
        }

        #endregion

        private void frmShowReport_Load(object sender, EventArgs e)
        {
            InvokeController("LoadShowLayerList");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Tag.GetType() == typeof(BaseReportLayer))
            {
                panelQueryControl.Controls.Clear();
                panelReport.Visible = false;
                toolStripButton1.Enabled = false;
                toolStripButton2.Enabled = false; 
                toolStripButton3.Enabled = false;
                toolStripButton4.Enabled = false;
                splitContainer2.SplitterDistance = 0;

            }
            else
            {
                panelReport.Visible = true;
                toolStripButton1.Enabled = true;
                toolStripButton2.Enabled = true;
                toolStripButton3.Enabled = true;
                toolStripButton4.Enabled = true;
                InvokeController("LoadReportQueryControl", ((BaseReportTitle)treeView1.SelectedNode.Tag).TitleId);
            }
        }

        #region IfrmShowReport 成员


        public void loadQueryControl(List<BaseReportField> fieldList)
        {
            this.panelQueryControl.Controls.Clear();
            List<BaseReportField> _fieldList = fieldList.FindAll(x => x.UiType > 0).OrderBy(x => x.SortId).ToList();

            int maxheight = 0; ;
            for (int i = 0; i < _fieldList.Count; i++)
            {

                Label lab = new Label();
                lab.Text = _fieldList[i].Name;
                lab.TextAlign = ContentAlignment.MiddleRight;
                lab.Width = 100;


                Control txt = null;
                if (_fieldList[i].UiType == 1)
                {
                    txt = new TextBox();
                }
                else if (_fieldList[i].UiType == 2)
                {
                    txt = new DateTimePicker();
                }
                else if (_fieldList[i].UiType == 3)
                {
                    txt = new IntegerInput();
                }
                else if (_fieldList[i].UiType == 4)
                {
                    txt = new DoubleInput();
                }
                else if (_fieldList[i].UiType == 5)
                {
                    txt = new ComboBox();
                    int unitId = 0;
                    if (_fieldList[i].DataUnitId == null || _fieldList[i].DataUnitId == "")
                        unitId = -1;
                    else
                        unitId = Convert.ToInt32(_fieldList[i].DataUnitId);
                    ((ComboBox)txt).DataSource = InvokeController("GetComboData", unitId, _fieldList[i].DynamicSQL);
                    ((ComboBox)txt).DisplayMember = "name";
                    ((ComboBox)txt).ValueMember = "code";
                }
                else if (_fieldList[i].UiType == 6)
                {
                    txt = new CheckBox();
                }
                txt.Width = 200;
                txt.Tag = _fieldList[i];

                if (i % 2 == 0)
                {
                    lab.Location = new Point(0, 15 * i+5);
                    txt.Location = new Point(100, 15 * i+5);
                    
                }
                else
                {
                    lab.Location = new Point(300, 15 * (i - 1)+5);
                    txt.Location = new Point(400, 15 * (i - 1)+5);
                }

                maxheight = 15 * i + 30;
                panelQueryControl.Controls.Add(lab);
                panelQueryControl.Controls.Add(txt);
            }
            splitContainer2.SplitterDistance = maxheight;
            panelQueryControl.Refresh();
        }

        #endregion

        GridppReport Report;
        DataTable tPrintTable;
        public List<object> GetReportParamsValue()
        {
            List<object> paramList = new List<object>();
            foreach (Control val in panelQueryControl.Controls)
            {
                if (val.Tag != null && val.Tag.GetType() == typeof(BaseReportField))
                {
                    BaseReportField field = val.Tag as BaseReportField;
                    if (field.UiType == 1)
                    {
                        paramList.Add(val.Text);
                    }
                    else if (field.UiType == 2)
                    {
                        paramList.Add((val as DateTimePicker).Value);
                    }
                    else if (field.UiType == 3)
                    {
                        paramList.Add((val as IntegerInput).Value);
                    }
                    else if (field.UiType == 4)
                    {
                        paramList.Add((val as DoubleInput).Value);
                    }
                    else if (field.UiType == 5)
                    {
                        paramList.Add((val as ComboBox).SelectedValue);
                    }
                    else if (field.UiType == 6)
                    {
                        paramList.Add((val as CheckBox).Checked?1:0);
                    }
                }
            }
            return paramList;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            axGRDisplayViewer1.Stop();

            BaseReportTitle reportTitle = (BaseReportTitle)treeView1.SelectedNode.Tag;
            tPrintTable = (DataTable)InvokeController("ExecReportResult", reportTitle.TitleId, GetReportParamsValue());

            string Reportname = reportTitle.RptFileName.Trim() + ".grf";
            if (!System.IO.File.Exists(EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath +@"Report\" + Reportname))
            {
                Report = new GridppReport();
                Report.InsertReportHeader();
                Report.InsertDetailGrid();
                Report.InsertReportFooter();
                Report.DetailGrid.IsCrossTab = true;

                IGRRecordset RecordSet = Report.DetailGrid.Recordset;
                foreach (DataColumn col in tPrintTable.Columns)
                {
                    if (col.DataType == typeof(Int32))
                        RecordSet.AddField(col.ColumnName, GRFieldType.grftInteger);
                    else if (col.DataType == typeof(Decimal) || col.DataType == typeof(Double))
                        RecordSet.AddField(col.ColumnName, GRFieldType.grftFloat);
                    else
                        RecordSet.AddField(col.ColumnName, GRFieldType.grftString);
                }

                Report.AddParameter("报表名称", GRParameterDataType.grptString);
                Report.AddParameter("打印时间", GRParameterDataType.grptString);
                Report.AddParameter("当前科室", GRParameterDataType.grptString);
                Report.AddParameter("当前人员", GRParameterDataType.grptString);
                Report.DetailGrid.IsCrossTab = false;
                Report.SaveToFile(EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath + @"Report\" + Reportname);
            }


            Report = new GridppReport();
            Report.LoadFromFile(EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath + @"Report\" + Reportname);

            Report.ParameterByName("报表名称").AsString = reportTitle.Name;
            Report.ParameterByName("打印时间").AsString = System.DateTime.Now.ToString();
            Report.ParameterByName("当前科室").AsString = "";
            Report.ParameterByName("当前人员").AsString = "";
            Report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(reportPrinter_FetchRecord);
            axGRDisplayViewer1.Report = Report;
            axGRDisplayViewer1.Start(); 
        }

        private void reportPrinter_FetchRecord()
        {
            //GridReport.FillRecordToReport(Report, tPrintTable);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            BaseReportTitle reportTitle = (BaseReportTitle)treeView1.SelectedNode.Tag;
            InvokeController("LookReportDataSource", reportTitle.TitleId, GetReportParamsValue());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            BaseReportTitle reportTitle = (BaseReportTitle)treeView1.SelectedNode.Tag;
            string Reportname = EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath + @"Report\" + reportTitle.RptFileName.Trim() + ".grf";
            if (File.Exists(Reportname))
                InvokeController("ReportDesigner", Reportname);
            else
                MessageBoxEx.Show("此报表文件还没有创建，请先点击查询创建基本的报表文件再进行设计！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Report != null)
            {
                Report.PrintPreview(true);
            }
        }
    }
}
