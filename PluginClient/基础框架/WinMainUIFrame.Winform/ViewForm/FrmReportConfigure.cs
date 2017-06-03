using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using DevComponents.DotNetBar;
using EfwControls.Common;
using EFWCoreLib.CoreFrame.Business;
using WinMainUIFrame.Winform.IView;

namespace WinMainUIFrame.Winform.ViewForm
{
    public partial class FrmReportConfigure : BaseFormBusiness, IFrmReportConfigure
    {
        private string AppRootPath = EFWCoreLib.CoreFrame.Init.AppGlobal.AppRootPath;
        private System.Xml.XmlDocument xmlDoc = null;
        private XmlNodeList nodeList = null;
        public FrmReportConfigure()
        {
            InitializeComponent();
        }

        #region 接口

        /// <summary>
        /// 读取报表数据
        /// </summary>
        /// <param name="dt">数据集</param>
        public void LoadReportGrid(DataTable dt)
        {
            if (dt == null) return;
            if (xmlDoc == null) LoadConfig();
            nodeList = xmlDoc.DocumentElement.SelectNodes("report");
            dt = LoadData(nodeList, dt);
            gridReport.DataSource = dt;
        }

        /// <summary>
        /// 绑定计费模式ShowCard
        /// </summary>
        public void BindPrintInfoCard()
        {
            DataTable dtMode = InitPrint();
            gridReport.SelectionCards[0].BindColumnIndex = 2;
            gridReport.SelectionCards[0].CardColumn = "PrintIndex|打印机|115";
            gridReport.SelectionCards[0].CardSize = new System.Drawing.Size(150, 100);
            gridReport.BindSelectionCardDataSource(0, dtMode);
        }

        #endregion

        #region 函数
        /// <summary>
        /// 读取XML中的数据
        /// </summary>
        /// <param name="nodeList"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        private DataTable LoadData(XmlNodeList nodeList, DataTable dt)
        {
            if (!dt.Columns.Contains("PrintIndex"))
            {
                dt.Columns.Add("PrintIndex");
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                foreach (XmlNode node in nodeList)
                {
                    string no = node.Attributes["No"].Value;
                    string printIndex = node.Attributes["printIndex"].Value;
                    if (no == Tools.ToString(dt.Rows[i]["EnumValue"]))
                    {
                        dt.Rows[i]["PrintIndex"] = GetPrintName(printIndex);
                        break;
                    }
                }
            }
            return dt;
        }

        /// <summary>
        /// 通过序号获取打印机名称
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private string GetPrintName(string no)
        {
            string name = "";
            switch (no)
            {
                case "0":
                    name = "打印机一";
                    break;
                case "1":
                    name = "打印机二";
                    break;
                case "2":
                    name = "打印机三";
                    break;
            }
            return name;
        }

        /// <summary>
        /// 通过打印机名称获取序号
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private string GetPrintNO(string name)
        {
            string no = "";
            switch (name)
            {
                case "打印机一":
                    no = "0";
                    break;
                case "打印机二":
                    no = "1";
                    break;
                case "打印机三":
                    no = "2";
                    break;
            }
            return no;
        }
        /// <summary>
        /// 读取配置文件
        /// </summary>
        private void LoadConfig()
        {
            xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.Load(AppRootPath + @"Config/ReportPrint.xml");
        }
        /// <summary>
        /// 保存XML公共方法
        /// </summary>
        /// <param name="dr">当前列的信息</param>
        /// <param name="index">打印机索引号</param>
        private void SaveConfig(DataRow dr, string index)
        {
            bool isExit = false;
            foreach (XmlNode node in nodeList)
            {
                string no = node.Attributes["No"].Value;
                if (no == Tools.ToString(dr["EnumValue"]))
                {
                    isExit = true;
                    node.Attributes["printIndex"].Value = index == "-1" ? GetPrintNO(Tools.ToString(dr["PrintIndex"])) : GetPrintNO(index);
                }
            }
            if (!isExit)
            {
                XmlElement newElement = xmlDoc.CreateElement("report");
                newElement.SetAttribute("No", Tools.ToString(dr["EnumValue"]));
                newElement.SetAttribute("Name", Tools.ToString(dr["ReportTitle"]));
                newElement.SetAttribute("printIndex", index == "-1" ? GetPrintNO(Tools.ToString(dr["PrintIndex"])) : GetPrintNO(index));
                xmlDoc.DocumentElement.AppendChild(newElement);
            }
            xmlDoc.Save(AppRootPath + @"Config/ReportPrint.xml");
        }
        /// <summary>
        /// 初始化ShowCard数据
        /// </summary>
        /// <returns></returns>
        private DataTable InitPrint()
        {
            DataTable dtMode = new DataTable();
            dtMode.Columns.Add("PrintIndex");
            DataRow dr = dtMode.NewRow();
            dr["PrintIndex"] = "打印机一";
            dtMode.Rows.Add(dr);
            dr = dtMode.NewRow();
            dr["PrintIndex"] = "打印机二";
            dtMode.Rows.Add(dr);
            dr = dtMode.NewRow();
            dr["PrintIndex"] = "打印机三";
            dtMode.Rows.Add(dr);
            return dtMode;
        }
        #endregion

        #region 窗体事件
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gridReport.EndEdit();
            DataTable dt = gridReport.DataSource as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["EnumValue"] == null) continue;
                SaveConfig(dt.Rows[i], "-1");
            }
            MessageBoxShowSimple("保存成功");
            gridReport.Refresh();
        }

        private void FrmReportConfigure_Load(object sender, EventArgs e)
        {
            InvokeController("GetReportData");
            BindPrintInfoCard();
        }

        private void gridReport_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            DataRow selectRow = (DataRow)SelectedValue;
            int colId = gridReport.CurrentCell.ColumnIndex;
            int rowId = gridReport.CurrentCell.RowIndex;
            DataTable dtSource = (DataTable)gridReport.DataSource;
            if (customNextColumnIndex == 2)
            {
                dtSource.Rows[rowId]["PrintIndex"] = selectRow["PrintIndex"];
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (gridReport.CurrentCell == null) return;
            int rowindex = gridReport.CurrentCell.RowIndex;
            DataTable dt = (DataTable)gridReport.DataSource;
            DataRow dr = dt.Rows[rowindex];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["EnumValue"] == null) continue;
                SaveConfig(dt.Rows[i], Tools.ToString(dr["PrintIndex"]));
            }
            MessageBoxShowSimple("设置成功");
            LoadConfig();
            nodeList = xmlDoc.DocumentElement.SelectNodes("report");
            dt = LoadData(nodeList, dt);
            gridReport.DataSource = dt;
        }
        #endregion

        private void FrmReportConfigure_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridReport.EndEdit();
        }
    }
}
