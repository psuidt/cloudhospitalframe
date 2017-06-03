using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.WinformFrame.Controller;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using base_dictionarymanage.winform.IView;
using base_dictionarymanage.Entity;
using System.Data;
using System.Windows.Forms;
//using WinMainUIFrame.Entity;
using base_dictionarymanage.ObjectModel;

namespace base_dictionarymanage.winform.Controller
{
    [WinformController(DefaultViewName = "frmGeneralConfiguration")]//在菜单上显示
    [WinformView(Name = "frmGeneralConfiguration", DllName = "base_dictionarymanage.winform.dll", ViewTypeName = "base_dictionarymanage.winform.ViewForm.frmGeneralConfiguration")]//控制器关联的界面
    [WinformView(Name = "frmGroupGeneral", DllName = "base_dictionarymanage.winform.dll", ViewTypeName = "base_dictionarymanage.winform.ViewForm.frmGroupGeneral")]//控制器关联的界面
    [WinformView(Name = "frmShowGeneral", DllName = "base_dictionarymanage.winform.dll", ViewTypeName = "base_dictionarymanage.winform.ViewForm.frmShowGeneral")]//控制器关联的界面
    [WinformView(Name = "frmEditField", DllName = "base_dictionarymanage.winform.dll", ViewTypeName = "base_dictionarymanage.winform.ViewForm.frmEditField")]//控制器关联的界面
    [WinformView(Name = "frmAddTable", DllName = "base_dictionarymanage.winform.dll", ViewTypeName = "base_dictionarymanage.winform.ViewForm.frmAddTable")]//控制器关联的界面
    [WinformView(Name = "FrmUnitData", DllName = "base_dictionarymanage.winform.dll", ViewTypeName = "base_dictionarymanage.winform.ViewForm.FrmUnitData")]//控制器关联的界面
    public class dictionaryController : WinformController
    {
        IfrmGeneralConfiguration frmConfig;
        IfrmAddTable frmAddTable;
        IfrmEditField frmeditField;
        public override void Init()
        {
            frmConfig = iBaseView["frmGeneralConfiguration"] as IfrmGeneralConfiguration;
            frmAddTable = iBaseView["frmAddTable"] as IfrmAddTable;
            frmeditField = iBaseView["frmEditField"] as IfrmEditField;
        }

        [WinformMethod]
        public void LoadLayerList()
        {
            List<BaseGeneralLayer> layerList = NewObject<BaseGeneralLayer>().getlist<BaseGeneralLayer>();
            List<BaseGeneralTitle> titleList = NewObject<BaseGeneralTitle>().getlist<BaseGeneralTitle>();

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
                List<BaseGeneralField> fieldlist = NewObject<GeneralField>().GetFieldList(titleId);
                frmConfig.loadFieldGrid(fieldlist);
            }
        }

        [WinformMethod]
        public BaseGeneralLayer NewLayer(int pid)
        {
            BaseGeneralLayer layer = NewObject<BaseGeneralLayer>();
            layer.Name = "新建分类";
            layer.PId = pid;
            layer.save();
            return layer;
        }
        [WinformMethod]
        public BaseGeneralLayer AlterLayer(BaseGeneralLayer layer)
        {
            layer.save();
            return layer;
        }
        [WinformMethod]
        public void DeleteLayer(int layerId)
        {
            NewObject<BaseGeneralLayer>().delete(layerId);
        }
        [WinformMethod]
        public void NewTitle(int layerId)
        {
            frmAddTable.loadTable(NewObject<GeneralTitle>().GetDbTables());

            BaseGeneralTitle title = NewObject<BaseGeneralTitle>();
            title.LayerId = layerId;
            frmAddTable.currTitle = title;
            (frmAddTable as Form).Text = "添加表";
            (frmAddTable as Form).ShowDialog();
        }
        [WinformMethod]
        public void AlterTitle(int titleId)
        {
            frmAddTable.loadTable(NewObject<GeneralTitle>().GetDbTables());

            BaseGeneralTitle title = NewObject<BaseGeneralTitle>().getmodel(titleId) as BaseGeneralTitle;
            frmAddTable.currTitle = title;
            (frmAddTable as Form).Text = "修改表";
            (frmAddTable as Form).ShowDialog();
        }
        [WinformMethod]
        public void SaveTitle()
        {
            frmAddTable.currTitle.save();
            LoadLayerList();
        }
        [WinformMethod]
        public void DeleteTitle(int titleId)
        {
            NewObject<BaseGeneralTitle>().delete(titleId);
            NewObject<GeneralField>().DeleteField(titleId);
        }
        [WinformMethod]
        public void StartInitField(int titleId)
        {
            NewObject<GeneralField>().InitFields(titleId);
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
            //uitype.Rows.Add(2, "DateTime");
            //uitype.Rows.Add(3, "Int");
            //uitype.Rows.Add(4, "Double");
            uitype.Rows.Add(5, "combobox");
            uitype.Rows.Add(6, "checkbox");
            ((IfrmEditField)frmeditField).loadUitype(uitype);

            List<BaseGeneralDataUnit> unitList = NewObject<BaseGeneralDataUnit>().getlist<BaseGeneralDataUnit>();
            ((IfrmEditField)frmeditField).loadUnitType(unitList);

            BaseGeneralField field = NewObject<BaseGeneralField>().getmodel(fieldId) as BaseGeneralField;
            frmeditField.currField = field;
            ((Form)frmeditField).Text = "修改字段";
            ((Form)frmeditField).ShowDialog();
        }
        [WinformMethod]
        public void SaveField()
        {
            BaseGeneralField field = frmeditField.currField;
            field.save();
            LoadFieldList(1, field.TitleId);
        }

        [WinformMethod]
        public void LoadGroupList()
        {
            List<BaseGroup> grouplist = NewObject<BaseGroup>().getlist<BaseGroup>();
            (iBaseView["frmGroupGeneral"] as IfrmGroupGeneral).loadGroupGrid(grouplist);
        }
        [WinformMethod]
        public void LoadGroupTitle(int groupId)
        {
            List<BaseGeneralLayer> layerList = NewObject<BaseGeneralLayer>().getlist<BaseGeneralLayer>();
            List<BaseGeneralTitle> titleList = NewObject<BaseGeneralTitle>().getlist<BaseGeneralTitle>();
            List<BaseGeneralTitle> grouptitleList = NewObject<GeneralTitle>().GetGroupTitleList(groupId);

            (iBaseView["frmGroupGeneral"] as IfrmGroupGeneral).loadTableTree(layerList, titleList, grouptitleList);

        }

        [WinformMethod]
        public void SetGroupTitle(int groupId, int[] titleIds)
        {
            NewObject<GeneralTitle>().SetGroupTitle(groupId, titleIds);
        }
        [WinformMethod]
        public void LoadShowLayerList()
        {
            List<BaseGeneralLayer> layerList = NewObject<BaseGeneralLayer>().getlist<BaseGeneralLayer>();
            List<BaseGeneralTitle> grouptitleList = NewObject<GeneralTitle>().GetUserTitleList(LoginUserInfo.UserId);

            (iBaseView["frmShowGeneral"] as IfrmShowGeneral).loadLayerTree(layerList, grouptitleList);
        }
        [WinformMethod]
        public void LoadShowFields(int type, int titleId)
        {
            if (type == 0)//分类没有字段
            {
                (iBaseView["frmShowGeneral"] as IfrmShowGeneral).loadfieldsCombo(new List<BaseGeneralField>());
            }
            else
            {
                List<BaseGeneralField> fieldlist = NewObject<GeneralField>().GetFieldList(titleId);
                (iBaseView["frmShowGeneral"] as IfrmShowGeneral).loadfieldsCombo(fieldlist);
                (iBaseView["frmShowGeneral"] as IfrmShowGeneral).createGridColumn(fieldlist);
            }


        }
        [WinformMethod]
        public void LoadShowSearchResult(int titleId, string field, string value)
        {
            BaseGeneralTitle title = NewObject<BaseGeneralTitle>().getmodel(titleId) as BaseGeneralTitle;
            //List<BaseGeneralField> fieldlist = NewObject<GeneralField>().GetFieldList(titleId);
            string strsql = "";
            if (field == "")
                strsql = @"select * from {0}";
            else
                strsql = @"select * from {0} where {1} like '%{2}%'";
            strsql = string.Format(strsql, title.TableName, field, value);
            DataTable dt = oleDb.GetDataTable(strsql);
            (iBaseView["frmShowGeneral"] as IfrmShowGeneral).resultGrid = dt;
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
        public DataTable GetGridColComboDataSource(int unitId, string SQL)
        {
            if (SQL == "")
            {
                SQL = "select DataVal as code,DataName as name from BaseGeneralStaticdData where DataUnitId=" + unitId;
            }
            DataTable dt = oleDb.GetDataTable(SQL);
            return dt;
        }
        [WinformMethod]
        private string ConvertDBValue(object value)
        {
            if (value == null || value.Equals(System.DBNull.Value)) return "NULL";

            string PropertyType = value.GetType().FullName;
            switch (PropertyType)
            {
                case "System.String":
                    return "'" + value.ToString() + "'";
                case "System.DateTime":
                    return "'" + value.ToString() + "'";
                case "System.Guid":
                    return "'" + value.ToString() + "'";
                case "System.Boolean":
                    return "'" + value.ToString() + "'";
            }

            return value.ToString();
        }
        [WinformMethod]
        public void AddResultDataTable()
        {
            DataTable dt = (iBaseView["frmShowGeneral"] as IfrmShowGeneral).resultGrid;
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
        }

        //保存数据
        [WinformMethod]
        public Object SaveResultDataTable(int titleId, string IdName, object IdValue, Dictionary<string, object> fieldAndValue)
        {
            if (IdValue.Equals(System.DBNull.Value) == true)//插入数据
            {
                string fields = "";
                string values = "";
                string strsql = "insert into {0} ({1}) values({2})";

                foreach (KeyValuePair<string, object> val in fieldAndValue)
                {
                    fields += (fields == "" ? "" : ",") + val.Key;
                    values += (values == "" ? "" : ",") + ConvertDBValue(val.Value);
                }

                BaseGeneralTitle title = NewObject<BaseGeneralTitle>().getmodel(titleId) as BaseGeneralTitle;
                IdValue = oleDb.InsertRecord(string.Format(strsql, title.TableName, fields, values));
            }
            else//更新数据
            {
                string field_values = "";

                string strsql = "update  {0} set {1} where {2}";

                foreach (KeyValuePair<string, object> val in fieldAndValue)
                {
                    field_values += (field_values == "" ? "" : ",") + val.Key + "=" + ConvertDBValue(val.Value);
                }

                BaseGeneralTitle title = NewObject<BaseGeneralTitle>().getmodel(titleId) as BaseGeneralTitle;
                oleDb.DoCommand(string.Format(strsql, title.TableName, field_values, IdName + "=" + ConvertDBValue(IdValue)));
            }

            return IdValue;
        }
        [WinformMethod]
        public void DeleteResultDataTable(int titleId, string IdName, object IdValue)
        {
            if (IdValue.Equals(System.DBNull.Value) == false)
            {
                string strsql = "delete from  {0}  where {1}";
                BaseGeneralTitle title = NewObject<BaseGeneralTitle>().getmodel(titleId) as BaseGeneralTitle;
                oleDb.DoCommand(string.Format(strsql, title.TableName, IdName + "=" + ConvertDBValue(IdValue)));
            }
        }
    }
}
