using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using base_dictionarymanage.Entity;
using base_reportmanage.Entity;
using base_reportmanage.ObjectModel;
using base_reportmanage.winform.IView;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WinformFrame.Controller;
//using WinMainUIFrame.Entity;

namespace base_reportmanage.winform.Controller
{
    [WinformController(DefaultViewName = "frmReportConfiguration")]//在菜单上显示
    [WinformView(Name = "frmReportConfiguration", DllName = "base_reportmanage.winform.dll", ViewTypeName = "base_reportmanage.winform.ViewForm.frmReportConfiguration")]//控制器关联的界面
    [WinformView(Name = "frmGroupReport", DllName = "base_reportmanage.winform.dll", ViewTypeName = "base_reportmanage.winform.ViewForm.frmGroupReport")]//控制器关联的界面
    [WinformView(Name = "frmShowReport", DllName = "base_reportmanage.winform.dll", ViewTypeName = "base_reportmanage.winform.ViewForm.frmShowReport")]//控制器关联的界面
    [WinformView(Name = "frmEditField", DllName = "base_reportmanage.winform.dll", ViewTypeName = "base_reportmanage.winform.ViewForm.frmEditField")]//控制器关联的界面
    [WinformView(Name = "frmAddReport", DllName = "base_reportmanage.winform.dll", ViewTypeName = "base_reportmanage.winform.ViewForm.frmAddReport")]//控制器关联的界面
    [WinformView(Name = "FrmReportDesigner", DllName = "base_reportmanage.winform.dll", ViewTypeName = "base_reportmanage.winform.ViewForm.FrmReportDesigner")]//控制器关联的界面
    [WinformView(Name = "FrmUnitData", DllName = "base_reportmanage.winform.dll", ViewTypeName = "base_reportmanage.winform.ViewForm.FrmUnitData")]//控制器关联的界面
    public class reportController : WinformController
    {
        IfrmReportConfiguration frmConfig;
        IfrmAddReport frmAddReport;
        IfrmEditField frmeditField;
        public override void Init()
        {
            frmConfig = iBaseView["frmReportConfiguration"] as IfrmReportConfiguration;
            frmAddReport = iBaseView["frmAddReport"] as IfrmAddReport;
            frmeditField = iBaseView["frmEditField"] as IfrmEditField;
        }

        #region frmReportConfiguration
        [WinformMethod]
        public void LoadLayerList()
        {
            List<BaseReportLayer> layerList = NewObject<BaseReportLayer>().getlist<BaseReportLayer>();
            List<BaseReportTitle> titleList = NewObject<BaseReportTitle>().getlist<BaseReportTitle>();

            frmConfig.loadLayerTree(layerList, titleList);
        }
        [WinformMethod]
        public void LoadFieldList(int type, int titleId)
        {
            if (type == 0)//分类没有字段
            {
                frmConfig.loadFieldGrid(null);
            }
            else
            {
                List<BaseReportField> fieldlist = NewObject<ReportField>().GetFieldList(titleId);
                frmConfig.loadFieldGrid(fieldlist);
            }
        }

        [WinformMethod]
        public BaseReportLayer NewLayer(int pid)
        {
            BaseReportLayer layer = NewObject<BaseReportLayer>();
            layer.Name = "新建分类";
            layer.PLayerId = pid;
            layer.save();
            return layer;
        }
        [WinformMethod]
        public BaseReportLayer AlterLayer(BaseReportLayer layer)
        {
            layer.save();
            return layer;
        }
        [WinformMethod]
        public void DeleteLayer(int layerId)
        {
            NewObject<BaseReportLayer>().delete(layerId);
        }
        [WinformMethod]
        public void NewTitle(int layerId)
        {
            frmAddReport.loadsp(NewObject<ReportTitle>().GetDbProcedures());
            DataTable typerep = new DataTable();
            typerep.Columns.Add("id");
            typerep.Columns.Add("name");
            typerep.Rows.Add(0, "网格");
            typerep.Rows.Add(1, "交叉");
            typerep.Rows.Add(2, "参数");
            frmAddReport.loadreporttype(typerep);

            BaseReportTitle title = NewObject<BaseReportTitle>();
            title.LayerId = layerId;
            frmAddReport.currTitle = title;
            (frmAddReport as Form).Text = "添加报表";
            (frmAddReport as Form).ShowDialog();
        }
        [WinformMethod]
        public void AlterTitle(int titleId)
        {


            frmAddReport.loadsp(NewObject<ReportTitle>().GetDbProcedures());
            DataTable typerep = new DataTable();
            typerep.Columns.Add("id");
            typerep.Columns.Add("name");
            typerep.Rows.Add(0, "网格");
            typerep.Rows.Add(1, "交叉");
            typerep.Rows.Add(2, "参数");
            frmAddReport.loadreporttype(typerep);

            BaseReportTitle title = NewObject<BaseReportTitle>().getmodel(titleId) as BaseReportTitle;
            frmAddReport.currTitle = title;
            (frmAddReport as Form).Text = "修改报表";
            (frmAddReport as Form).ShowDialog();
        }
        [WinformMethod]
        public void SaveTitle()
        {
            frmAddReport.currTitle.save();
            LoadLayerList();
        }
        [WinformMethod]
        public void DeleteTitle(int titleId)
        {
            NewObject<BaseReportTitle>().delete(titleId);
            NewObject<ReportField>().DeleteField(titleId);
        }
        [WinformMethod]
        public void StartInitField(int titleId)
        {
            NewObject<ReportField>().InitFields(titleId);
            LoadFieldList(1, titleId);
        }
        [WinformMethod]
        public void AlterField(int fieldId)
        {
            DataTable uitype = new DataTable();
            uitype.Columns.Add("id");
            uitype.Columns.Add("name");
            uitype.Rows.Add(0, "hidden");
            uitype.Rows.Add(1, "Text");
            uitype.Rows.Add(2, "DateTime");
            uitype.Rows.Add(3, "Int");
            uitype.Rows.Add(4, "Double");
            uitype.Rows.Add(5, "combobox");
            uitype.Rows.Add(6, "checkbox");
            ((IfrmEditField)frmeditField).loadUitype(uitype);

            List<BaseGeneralDataUnit> unitList = NewObject<BaseGeneralDataUnit>().getlist<BaseGeneralDataUnit>();
            ((IfrmEditField)frmeditField).loadUnitType(unitList);

            BaseReportField field = NewObject<BaseReportField>().getmodel(fieldId) as BaseReportField;
            frmeditField.currField = field;
            ((Form)frmeditField).Text = "修改参数";
            ((Form)frmeditField).ShowDialog();
        }
        [WinformMethod]
        public void SaveField()
        {
            BaseReportField field = frmeditField.currField;
            field.save();
            LoadFieldList(1, field.TitleId);
        }

        #endregion

        #region frmGroupReport
        [WinformMethod]
        public void LoadGroupList()
        {
            List<BaseGroup> grouplist = NewObject<BaseGroup>().getlist<BaseGroup>();
            (iBaseView["frmGroupReport"] as IfrmGroupReport).loadGroupGrid(grouplist);
        }
        [WinformMethod]
        public void LoadGroupTitle(int groupId)
        {
            List<BaseReportLayer> layerList = NewObject<BaseReportLayer>().getlist<BaseReportLayer>();
            List<BaseReportTitle> titleList = NewObject<BaseReportTitle>().getlist<BaseReportTitle>();
            List<BaseReportTitle> grouptitleList = NewObject<ReportTitle>().GetGroupTitleList(groupId);

            (iBaseView["frmGroupReport"] as IfrmGroupReport).loadTableTree(layerList, titleList, grouptitleList);

        }
        [WinformMethod]
        public void SetGroupTitle(int groupId, int[] titleIds)
        {
            NewObject<ReportTitle>().SetGroupTitle(groupId, titleIds);
        }

        #endregion

        #region frmShowReport
        [WinformMethod]
        public void LoadShowLayerList()
        {
            List<BaseReportLayer> layerList = NewObject<BaseReportLayer>().getlist<BaseReportLayer>();
            List<BaseReportTitle> grouptitleList = NewObject<ReportTitle>().GetUserTitleList(LoginUserInfo.UserId);

            (iBaseView["frmShowReport"] as IfrmShowReport).loadLayerTree(layerList, grouptitleList);
        }
        [WinformMethod]
        public void ShowUnitData(int unitId, string SQL)
        {
            if (SQL == "")
            {
                SQL = "select DataVal as code,DataName as name from BaseGeneralStaticdData where DataUnitId=" + unitId;
            }
            DataTable dt = oleDb.GetDataTable(SQL);
            (iBaseView["FrmUnitData"] as IfrmUnitData).loadUnitData(dt);
            (iBaseView["FrmUnitData"] as IfrmUnitData).UnitDataShowDialog();
        }
        [WinformMethod]
        public void LoadReportQueryControl(int titleId)
        {
            List<BaseReportField> fieldlist = NewObject<ReportField>().GetFieldList(titleId);
            (iBaseView["frmShowReport"] as IfrmShowReport).loadQueryControl(fieldlist);
        }
        [WinformMethod]
        public DataTable GetComboData(int unitId, string SQL)
        {
            if (SQL == "")
            {
                SQL = "select DataVal as code,DataName as name from BaseGeneralStaticdData where DataUnitId=" + unitId;
            }
            return oleDb.GetDataTable(SQL);
        }
        [WinformMethod]
        public DataTable ExecReportResult(int titleId, List<object> paramList)
        {
            BaseReportTitle title = NewObject<BaseReportTitle>().getmodel(titleId) as BaseReportTitle;
            string spName = title.ProName;
            return oleDb.GetDataTable(spName, paramList.ToArray());
        }
        [WinformMethod]
        public void LookReportDataSource(int titleId, List<object> paramList)
        {
            BaseReportTitle title = NewObject<BaseReportTitle>().getmodel(titleId) as BaseReportTitle;
            string spName = title.ProName;
            DataTable dt = oleDb.GetDataTable(spName, paramList.ToArray());
            (iBaseView["FrmUnitData"] as IfrmUnitData).loadUnitData(dt);
            (iBaseView["FrmUnitData"] as IfrmUnitData).UnitDataShowDialog();
        }
        [WinformMethod]
        public void ReportDesigner(string reportfile)
        {
            (iBaseView["FrmReportDesigner"] as IFrmReportDesigner).loadreportfile(reportfile);
            (iBaseView["FrmReportDesigner"] as Form).ShowDialog();
        }

        #endregion
    }
}
