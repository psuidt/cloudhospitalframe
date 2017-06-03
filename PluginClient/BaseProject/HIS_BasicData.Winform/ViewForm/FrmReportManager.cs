using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using EfwControls.Common;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Winform.IView;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.ViewForm
{
    /// <summary>
    /// 报表管理
    /// </summary>
    public partial class FrmReportManager : BaseFormBusiness, IfrmReportManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmReportManager()
        {
            InitializeComponent();
            //记录网格上次选定行
            bindGridSelectIndex(gridReport);
        }

        /// <summary>
        /// 选中的报表配置
        /// </summary>
        private Basic_ReportConfig currReport;

        /// <summary>
        /// 选中的报表配置
        /// </summary>
        public Basic_ReportConfig CurrReport
        {
            get
            {
                currReport.EnumValue = txtEnum.Value;
                currReport.ReportTitle = txtTitle.Text;
                currReport.ReportType = getSysType;
                return currReport;
            }

            set
            {
                currReport = value;
                txtEnum.Value = currReport.EnumValue;
                txtTitle.Text = currReport.ReportTitle;
            }
        }

        /// <summary>
        /// 取得机构ID
        /// </summary>
        public int getWorkId
        {
            get
            {
                return Convert.ToInt32(cbWorkers.SelectedValue);
            }
        }

        /// <summary>
        /// 取得报表类型
        /// </summary>
        public int getSysType
        {
            get
            {
                return Convert.ToInt32(cbReportType.SelectedValue);
            }
        }

        /// <summary>
        /// 绑定报表列表
        /// </summary>
        /// <param name="dt">报表列表</param>
        public void loadReportGrid(DataTable dt)
        {
            gridReport.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["DelFlag"]) == 1)
                {
                    gridReport.SetRowColor(i, Color.Red, true);
                }
            }

            //设置网格定位当前行
            setGridSelectIndex(gridReport);
        }

        /// <summary>
        /// 绑定系统类型列表
        /// </summary>
        /// <param name="dt">系统类型列表</param>
        public void loadSystemTypeBox(DataTable dt)
        {
            cbReportType.DisplayMember = "Name";
            cbReportType.ValueMember = "ID";
            cbReportType.DataSource = dt;
            cbReportType.SelectedIndex = 0;
        }

        /// <summary>
        /// 绑定机构列表
        /// </summary>
        /// <param name="dt">机构列表</param>
        /// <param name="defaultWorkID">默认机构</param>
        public void loadWorkerDataBox(DataTable dt, int defaultWorkID)
        {
            cbWorkers.DisplayMember = "WorkName";
            cbWorkers.ValueMember = "WorkId";
            cbWorkers.DataSource = dt;
            cbWorkers.SelectedValue = defaultWorkID;

            //超级用户
            if ((InvokeController("this") as AbstractController).LoginUserInfo.IsAdmin == 2)
            {
                cbWorkers.Enabled = true;
            }
            else
            {
                cbWorkers.Enabled = false;
            }
        }

        /// <summary>
        /// 切换机构
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void cbWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            InvokeController("GetReportData", getWorkId, getSysType, txtSearchChar.Text);
        }

        /// <summary>
        /// 设置界面控件是否可用
        /// </summary>
        /// <param name="type">操作类型</param>
        private void SetbtnState(OperType type)
        {
            if (type == OperType.新增)
            {
                groupSearch.Enabled = false;
                txtEnum.Enabled = true;
                txtTitle.Enabled = true;
                txtEnum.Value = 0;
                txtTitle.Text = string.Empty;
            }
            else
            {
                groupSearch.Enabled = true;
                txtEnum.Enabled = false;
                txtTitle.Enabled = true;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetbtnState(OperType.新增);
            currReport = new Basic_ReportConfig();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == string.Empty)
            {
                MessageBox.Show("报表名称不能为空！", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                return;
            }

            bool isNew = currReport.ID == 0 ? true : false;

            InvokeController("SaveReport");
            InvokeController("GetReportData", getWorkId, getSysType, txtSearchChar.Text);
            //新增记录定位到最后一行
            if (isNew)
            {
                setGridSelectIndex(gridReport, gridReport.RowCount - 1);
            }
        }

        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (gridReport.CurrentCell != null)
            {
                DataTable dt = gridReport.DataSource as DataTable;
                int id = Convert.ToInt32(dt.Rows[gridReport.CurrentCell.RowIndex]["ID"]);
                int delflag = Convert.ToInt32(dt.Rows[gridReport.CurrentCell.RowIndex]["DelFlag"]);
                if (MessageBox.Show(string.Format("是否{0}此报表？", delflag == 1 ? "启用" : "停用"), "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    delflag = delflag == 1 ? 0 : 1;
                    InvokeController("StopReport", id, delflag);
                    InvokeController("GetReportData", getWorkId, getSysType, txtSearchChar.Text);
                }
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            InvokeController("Close", this);
        }

        /// <summary>
        /// 选定网格
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void gridReport_CurrentCellChanged(object sender, EventArgs e)
        {
            if (gridReport.CurrentCell != null)
            {
                DataTable dt = gridReport.DataSource as DataTable;
                Basic_ReportConfig report = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<Basic_ReportConfig>(dt, gridReport.CurrentCell.RowIndex);
                CurrReport = report;

                SetbtnState(OperType.默认);

                if (report.DelFlag == 1)
                {
                    btnStop.Text = "启用";
                }
                else
                {
                    btnStop.Text = "停用";
                }
            }
        }

        /// <summary>
        /// 打开界面
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void FrmReportManager_OpenWindowBefore(object sender, EventArgs e)
        {
            InvokeController("InitLoadData");
        }

        /// <summary>
        /// 创建空报表
        /// </summary>
        /// <param name="reportfile">报表路径</param>
        private void createEmptyReport(string reportfile)
        {
            string empty = "{\n";
            empty += "\"Version\":\"6.0.1.0\",\n";
            empty += "\"Font\":{\n";
            empty += "\"Name\":\"宋体\",\n";
            empty += "\"Size\":105000,\n";
            empty += "\"Weight\":400,\n";
            empty += "\"Charset\":134\n";
            empty += "},\n";
            empty += "\"Printer\":{\n";
            empty += "},\n";
            empty += "\"ReportHeader\":[\n";
            empty += "{\n";
            empty += "\"Name\":\"ReportHeader1\",\n";
            empty += "\"Height\":1.32292\n";
            empty += "}\n";
            empty += "]\n";
            empty += "}\n";
            using (StreamWriter sw = File.CreateText(reportfile))
            {
                sw.Write(empty);
            }
        }

        /// <summary>
        /// 验证报表文件
        /// </summary>
        /// <param name="id">报表ID</param>
        /// <param name="filename">文件吗</param>
        /// <param name="reportfile">输出报表文件</param>
        /// <param name="updatetime">修改时间</param>
        /// <returns>true：验证通过</returns>
        private bool verifyReport(out int id, out string filename, out string reportfile, out DateTime updatetime)
        {
            DataTable dt = gridReport.DataSource as DataTable;
            Basic_ReportConfig report = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToObject<Basic_ReportConfig>(dt, gridReport.CurrentCell.RowIndex);
            id = report.ID;
            filename = string.IsNullOrEmpty(report.FileName) ? (report.EnumValue + "." + report.ReportTitle + ".grf") : report.FileName;
            reportfile = EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath + @"Report\\" + filename;
            updatetime = report.UpdateTime.AddMinutes(1);

            //1.创建空报表
            //2.本地没有报表从服务器上下载报表
            if (File.Exists(reportfile) == false)
            {
                if (string.IsNullOrEmpty(report.FileName))
                {
                    if (MessageBox.Show("该报表没有对应的报表文件，是否生成一张空报表？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        return false;
                    }
                    else
                    {
                        //生成空报表
                        createEmptyReport(reportfile);
                        UpgradeFileConfigManager.AddReport(filename, updatetime);
                        MessageBoxShowSimple("空报表创建成功！");
                        return true;
                    }
                }
                else
                {
                    if (MessageBox.Show("本地没有该报表文件，是否从服务器上下载此报表文件？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    {
                        return false;
                    }
                    else
                    {
                        InvokeController("GetReportFile", id, filename, reportfile, updatetime);
                        return true;
                    }
                }
            }

            //3.本地报表的没有服务器上报表
            if (UpgradeFileConfigManager.GetReportUpdateTime(filename) == null || UpgradeFileConfigManager.GetReportUpdateTime(filename) < report.UpdateTime)
            {
                //小于服务更新时间，则下载报表文件
                if (MessageBox.Show("该报表文件服务器上有最新版本，是否从服务器上下载此报表文件？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return false;
                }
                else
                {
                    InvokeController("GetReportFile", id, filename, reportfile, updatetime);
                    return true;
                }
            }

            return true;
        }

        /// <summary>
        /// 上传报表
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (gridReport.CurrentCell != null)
            {
                int id;
                string filename;
                string reportfile;
                DateTime updateTime;
                if (verifyReport(out id, out filename, out reportfile, out updateTime))
                {
                    if (MessageBox.Show("是否将该报表本地的报表文件上传到服务器？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        InvokeController("UploadReportFile", id, filename, reportfile, updateTime);
                        UpgradeFileConfigManager.AddReport(filename, updateTime);
                        InvokeController("GetReportData", getWorkId, getSysType, txtSearchChar.Text);
                    }
                }
            }
        }

        /// <summary>
        /// 设计报表
        /// </summary>
        /// <param name="sender">控件</param>
        /// <param name="e">参数</param>
        private void btnDesReport_Click(object sender, EventArgs e)
        {
            if (gridReport.CurrentCell != null)
            {
                int id;
                string filename;
                string reportfile;
                DateTime updateTime;
                if (verifyReport(out id, out filename, out reportfile, out updateTime))
                {
                    //设计报表文件
                    UpgradeFileConfigManager.AddReport(filename, updateTime);
                    System.Diagnostics.Process.Start(reportfile);
                }
            }
        }

        /// <summary>
        /// 操作类型
        /// </summary>
        public enum OperType
        {
            默认, 新增
        }
    }
}
