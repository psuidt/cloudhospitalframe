using EFWCoreLib.CoreFrame.Business;
using HIS_PublicManage.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_PublicManage.ObjectModel
{
    /// <summary>
    /// 基础数据处理
    /// </summary>
    public class BasicDataManagement:AbstractObjectModel
    {
        /// <summary>
        /// 获取基础字典 
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public DataTable GetBasicData(BasicDictType dataType, bool IsAll)
        {
            DataTable dt = new DataTable();
            switch (dataType)
            {
                case BasicDictType.医生职称:
                    dt = NewDao<IPublicManageDao>().GetDictData(1022);
                    break;
                case BasicDictType.护士职称:
                    dt = NewDao<IPublicManageDao>().GetDictData(1023);
                    break;
                case BasicDictType.技术职称:
                    dt = NewDao<IPublicManageDao>().GetDictData(1025);
                    break;
                case BasicDictType.岗位分类:
                    dt = NewDao<IPublicManageDao>().GetDictData(1026);
                    break;
                case BasicDictType.政治面貌:
                    dt = NewDao<IPublicManageDao>().GetDictData(1027);
                    break;

            }
            if (IsAll)
            {
                DataTable _dt = dt.Clone();
                DataRow _dr = _dt.NewRow();
                _dr["Code"] = "-1";
                _dr["Name"] = "全部";
                _dr["Pym"] = "";
                _dr["Wbm"] = "";
                _dr["Szm"] = "";
                _dr["Memo"] = "";
                _dt.Rows.Add(_dr);
                foreach (DataRow dr in dt.Rows)
                {
                    _dt.Rows.Add(dr.ItemArray);
                }
                return _dt;
            }
            else
                return dt;
        }  

        /// <summary>
        /// 病人信息相关
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public DataTable GetBasicData(PatientInfoDataSourceType dataType)
        {
            return GetBasicData(dataType, false);
        }

        /// <summary>
        /// 病人信息相关，带“全部”项的下拉选项
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public DataTable GetBasicData(PatientInfoDataSourceType dataType, bool IsAll)
        {
            DataTable dt = new DataTable();
            switch (dataType)
            {
                case PatientInfoDataSourceType.国籍:
                    dt = NewDao<IPublicManageDao>().GetNationality();
                    break;
                case PatientInfoDataSourceType.民族:
                    dt = NewDao<IPublicManageDao>().GetNation();
                    break;
                case PatientInfoDataSourceType.职业:
                    dt = NewDao<IPublicManageDao>().GetOccupation();
                    break;
                case PatientInfoDataSourceType.教育程度:
                    dt = NewDao<IPublicManageDao>().GetEducation();
                    break;
                case PatientInfoDataSourceType.婚姻状况:
                    dt = NewDao<IPublicManageDao>().GetMatrimony();
                    break;
                case PatientInfoDataSourceType.关系:
                    dt = NewDao<IPublicManageDao>().GetRelation();
                    break;
                case PatientInfoDataSourceType.性别:
                    dt = NewDao<IPublicManageDao>().GetSex();
                    break;
                case PatientInfoDataSourceType.血型:
                    dt = NewDao<IPublicManageDao>().GetBloodType();
                    break;
                case PatientInfoDataSourceType.入院情况:
                    dt = NewDao<IPublicManageDao>().GetIPSituation();
                    break;
                case PatientInfoDataSourceType.麻醉方式:
                    dt = NewDao<IPublicManageDao>().GetAnesthesia();
                    break;
                case PatientInfoDataSourceType.地区编码:
                    dt = NewDao<IPublicManageDao>().GetDistriceCoding();
                    break;
                case PatientInfoDataSourceType.病人来源:
                    dt = NewDao<IPublicManageDao>().GetDictData(1020);
                    break;
                case PatientInfoDataSourceType.预交金支付方式:
                    dt = NewDao<IPublicManageDao>().GetDictData(1021);
                    break;
                case PatientInfoDataSourceType.挂号支付方式:
                    dt = NewDao<IPublicManageDao>().GetDictData(1024);
                    break;
                case PatientInfoDataSourceType.护理级别:
                    dt = NewDao<IPublicManageDao>().GetDictData(1039);
                    break;
                case PatientInfoDataSourceType.饮食种类:
                    dt = NewDao<IPublicManageDao>().GetDictData(1040);
                    break;
            }
            if (IsAll)
            {
                DataTable _dt = dt.Clone();
                DataRow _dr = _dt.NewRow();
                _dr["Code"] = "-1";
                _dr["Name"] = "全部";
                _dr["Pym"] = "";
                _dr["Wbm"] = "";
                _dr["Szm"] = "";
                _dr["Memo"] = "";
                _dt.Rows.Add(_dr);
                foreach(DataRow dr in dt.Rows)
                {
                    _dt.Rows.Add(dr.ItemArray);
                }
                return _dt;
            }
            else
                return dt;
        }
        /// <summary>
        /// 科室数据相关
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public DataTable GetBasicData(DeptDataSourceType dataType)
        {
            return GetBasicData(dataType, false);
        }
        /// <summary>
        /// 科室数据相关，带“全部”项的下拉选项
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public DataTable GetBasicData(DeptDataSourceType dataType, bool IsAll)
        {
            DataTable dt = new DataTable();
            switch (dataType)
            {
                case DeptDataSourceType.全部科室:
                    dt = NewDao<IPublicManageDao>().GetAllDept();
                    break;
                case DeptDataSourceType.门诊临床科室:
                    dt = NewDao<IPublicManageDao>().GetOPClinicalDept();
                    break;
                case DeptDataSourceType.住院临床科室:
                    dt = NewDao<IPublicManageDao>().GetIPClinicalDept();
                    break;
                case DeptDataSourceType.药剂科室:
                    dt = NewDao<IPublicManageDao>().GetDrugDept();
                    break;
                case DeptDataSourceType.药房科室:
                    dt = NewDao<IPublicManageDao>().GetPharmacyDept();
                    break;
                case DeptDataSourceType.药库科室:
                    dt = NewDao<IPublicManageDao>().GetDrugStorageDept();
                    break;
                case DeptDataSourceType.物资科室:
                    dt = NewDao<IPublicManageDao>().GetMaterialsDept();
                    break;
                case DeptDataSourceType.住院病区:
                    dt = NewDao<IPublicManageDao>().GetWardDept();
                    break;
            }
            if (IsAll)
            {
                DataTable _dt = dt.Clone();
                DataRow _dr = _dt.NewRow();
                _dr["DeptId"] = -1;
                _dr["Name"] = "全部";
                _dr["Pym"] = "";
                _dr["Wbm"] = "";
                _dr["Szm"] = "";
                _dr["Memo"] = "";
                _dt.Rows.Add(_dr);
                foreach (DataRow dr in dt.Rows)
                {
                    _dt.Rows.Add(dr.ItemArray);
                }
                return _dt;
            }
            else
                return dt;
        }

        #region 用户相关
        /// <summary>
        /// 用户数据相关
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public DataTable GetBasicData(EmpDataSourceType dataType)
        {
            return GetBasicData(dataType,false);
        }
        /// <summary>
        /// 用户数据相关，带“全部”项的下拉选项
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public DataTable GetBasicData(EmpDataSourceType dataType, bool IsAll)
        {
            int iWorkId = -1;
            DataTable dt = new DataTable();
            switch (dataType)
            {
                case EmpDataSourceType.全部用户:
                    dt = NewDao<IPublicManageDao>().GetEmpAll(iWorkId);
                    break;
                case EmpDataSourceType.收费员:
                    dt = NewDao<IPublicManageDao>().GetCashier(iWorkId);
                    break;
                case EmpDataSourceType.医生:
                    dt = NewDao<IPublicManageDao>().GetDoctor(iWorkId);
                    break;
                case EmpDataSourceType.护士:
                    dt = NewDao<IPublicManageDao>().GetNurse(iWorkId);
                    break;
                case EmpDataSourceType.药剂:
                    dt = NewDao<IPublicManageDao>().GetPharmacist(iWorkId);
                    break;
                case EmpDataSourceType.医生和科室:
                    dt = NewDao<IPublicManageDao>().GetDoctorAndDept(iWorkId);
                    break;
            }
            if (IsAll)
            {
                DataTable _dt = dt.Clone();
                DataRow _dr = _dt.NewRow();
                _dr["EmpId"] = -1;
                _dr["Name"] = "全部";
                _dr["Pym"] = "";
                _dr["Wbm"] = "";
                _dr["Szm"] = "";
                _dt.Rows.Add(_dr);
                foreach (DataRow dr in dt.Rows)
                {
                    _dt.Rows.Add(dr.ItemArray);
                }
                return _dt;
            }
            else
                return dt;
        }

        /// <summary>
        /// 用户数据相关
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public DataTable GetBasicData(EmpDataSourceType dataType,int iWorkId)
        {
            return GetBasicData(dataType, iWorkId, false);
        }
        /// <summary>
        /// 用户数据相关，带“全部”项的下拉选项
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public DataTable GetBasicData(EmpDataSourceType dataType, int iWorkId, bool IsAll)
        {
            DataTable dt = new DataTable();
            switch (dataType)
            {
                case EmpDataSourceType.全部用户:
                    dt = NewDao<IPublicManageDao>().GetEmpAll(iWorkId);
                    break;
                case EmpDataSourceType.收费员:
                    dt = NewDao<IPublicManageDao>().GetCashier(iWorkId);
                    break;
                case EmpDataSourceType.医生:
                    dt = NewDao<IPublicManageDao>().GetDoctor(iWorkId);
                    break;
                case EmpDataSourceType.护士:
                    dt = NewDao<IPublicManageDao>().GetNurse(iWorkId);
                    break;
                case EmpDataSourceType.药剂:
                    dt = NewDao<IPublicManageDao>().GetPharmacist(iWorkId);
                    break;
            }
            if (IsAll)
            {
                DataTable _dt = dt.Clone();
                DataRow _dr = _dt.NewRow();
                _dr["EmpId"] = -1;
                _dr["Name"] = "全部";
                _dr["Pym"] = "";
                _dr["Wbm"] = "";
                _dr["Szm"] = "";
                _dt.Rows.Add(_dr);
                foreach (DataRow dr in dt.Rows)
                {
                    _dt.Rows.Add(dr.ItemArray);
                }
                return _dt;
            }
            else
                return dt;
        }
        #endregion



        public DataTable GetBasicData(WorkDataSourceType dataType,bool IsAll)
        {
            DataTable dt = new DataTable();
            switch (dataType)
            {
                case WorkDataSourceType.医疗机构等级:
                    dt = NewDao<IPublicManageDao>().GetDictData(1018);
                    break;
                case WorkDataSourceType.医疗机构级别:
                    dt = NewDao<IPublicManageDao>().GetDictData(1019);
                    break;
            }
            if (IsAll)
            {
                DataTable _dt = dt.Clone();
                DataRow _dr = _dt.NewRow();
                _dr["Code"] = "-1";
                _dr["Name"] = "全部";
                _dr["Pym"] = "";
                _dr["Wbm"] = "";
                _dr["Szm"] = "";
                _dr["Memo"] = "";
                _dt.Rows.Add(_dr);
                foreach (DataRow dr in dt.Rows)
                {
                    _dt.Rows.Add(dr.ItemArray);
                }
                return _dt;
            }
            else
                return dt;
        }

        /// <summary>
        /// 获取所有有效机构数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetWorkers()
        {
            return GetWorkers(false);
        }
        /// <summary>
        /// 获取所有有效机构数据，带“全部”项的下拉选项
        /// </summary>
        /// <returns></returns>
        public DataTable GetWorkers(bool IsAll)
        {
            DataTable dt = new DataTable();
            dt = NewDao<IPublicManageDao>().GetWorkers();
            if (IsAll)
            {
                DataTable _dt = dt.Clone();
                DataRow _dr = _dt.NewRow();
                _dr["WorkId"] = -1;
                _dr["WorkNo"] = "";
                _dr["WorkName"] = "全部";
                _dr["Memo"] = "";
                _dt.Rows.Add(_dr);
                foreach (DataRow dr in dt.Rows)
                {
                    _dt.Rows.Add(dr.ItemArray);
                }
                return _dt;
            }
            else
                return dt;
        }

        /// <summary>
        /// 获取病人类型，带“全部”项的下拉选项
        /// </summary>
        /// <returns></returns>
        public DataTable GetPatType()
        {
            return GetPatType(false);
        }

        /// <summary>
        /// 获取病人类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetPatType(bool IsAll)
        {
            DataTable dt = new DataTable();
            dt = NewDao<IPublicManageDao>().GetPatType();
            if (IsAll)
            {
                DataTable _dt = dt.Clone();
                DataRow _dr = _dt.NewRow();
                _dr["PatTypeID"] = -1;
                _dr["PatTypeCode"] = "";
                _dr["PatTypeName"] = "全部";
                _dr["PYCode"] = "";
                _dr["WBCode"] = "";
                _dt.Rows.Add(_dr);
                foreach (DataRow dr in dt.Rows)
                {
                    _dt.Rows.Add(dr.ItemArray);
                }
                return _dt;
            }
            else
                return dt;
        }
        /// <summary>
        /// 获取诊断
        /// </summary>
        /// <returns></returns>
        public DataTable GetDisease()
        {
            DataTable dt= NewDao<IPublicManageDao>().GetDisease();
            return dt;
        }
        /// <summary>
        /// 获取用户名称
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public string GetEmpName(int empId)
        {
            return NewDao<IPublicManageDao>().GetEmpName(empId);
        }
        /// <summary>
        /// 获取科室名称
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public string GetDeptName(int deptId)
        {
            return NewDao<IPublicManageDao>().GetDeptName(deptId);
        }
        /// <summary>
        /// 获取病区名称
        /// </summary>
        /// <param name="wardId"></param>
        /// <returns></returns>
        public string GetWardName(int wardId)
        {
            return NewDao<IPublicManageDao>().GetWardName(wardId);
        }
        /// <summary>
        /// 获取机构名称
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public string GetWorkName(int workId)
        {
            return NewDao<IPublicManageDao>().GetWorkName(workId);
        }
        /// <summary>
        /// 获取字典内容名称
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetDictContent(PatientInfoDataSourceType dataType,string code)
        {
            switch (dataType)
            {
                case PatientInfoDataSourceType.性别:
                    return NewDao<IPublicManageDao>().GetDictContent(1001, code);
                case PatientInfoDataSourceType.入院情况:
                    return NewDao<IPublicManageDao>().GetDictContent(1017, code);
                case PatientInfoDataSourceType.血型:
                    return NewDao<IPublicManageDao>().GetDictContent(1009, code);
            }
            return null;
        }
        /// <summary>
        /// 病人类型名称
        /// </summary>
        /// <param name="patTypeId"></param>
        /// <returns></returns>
        public string GetPatTypeName(int patTypeId)
        {
            return NewDao<IPublicManageDao>().GetPatTypeName(patTypeId);
        }
        /// <summary>
        /// 获取大项目代码
        /// </summary>
        /// <param name="IsAll"></param>
        /// <returns></returns>
        public DataTable GetStatItem(bool IsAll)
        {
            DataTable dt = new DataTable();
            dt = NewDao<IPublicManageDao>().GetStatItem();
            if (IsAll)
            {
                DataTable _dt = dt.Clone();
                DataRow _dr = _dt.NewRow();
                _dr["StatID"] = -1;
                _dr["StatName"] = "全部";
                _dr["NumCode"] = "";
                _dr["PYCode"] = "";
                _dr["WBCode"] = "";
                _dt.Rows.Add(_dr);
                foreach (DataRow dr in dt.Rows)
                {
                    _dt.Rows.Add(dr.ItemArray);
                }
                return _dt;
            }
            else
                return dt;
        }

        /// <summary>
        /// 获取医保类型
        /// </summary>
        /// <returns></returns>
        public DataTable GetMedicareDic()
        {
            return NewDao<IPublicManageDao>().GetUnit();
        }

        /// <summary>
        /// 获取药品单位
        /// </summary>
        /// <returns></returns>
        public DataTable GetUnit()
        {
            return NewDao<IPublicManageDao>().GetUnit();
        }

        /// <summary>
        /// 获取员工关联科室
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="IsOut">0：门诊科室 1：住院科室</param>
        /// <returns></returns>
        public DataTable GetUserDept(int empId,int IsOut)
        {
            return NewDao<IPublicManageDao>().GetUserDept(empId, IsOut);
        }
        /// <summary>
        /// 获取员工关联病区
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public DataTable GetUserWard(int empId)
        {
            return NewDao<IPublicManageDao>().GetUserWard(empId);
        }
    }

    /// <summary>
    /// 基础字典类型
    /// </summary>
    public enum BasicDictType
    {
        医生职称,护士职称, 技术职称, 岗位分类, 政治面貌
    }

    /// <summary>
    /// 病人信息数据源类型
    /// </summary>
    public enum PatientInfoDataSourceType
    {
        国籍,教育程度,民族,婚姻状况,职业,关系,性别,血型,入院情况,麻醉方式,地区编码,病人来源,预交金支付方式,挂号支付方式,护理级别,饮食种类
    }
    /// <summary>
    /// 科室数据源类型
    /// </summary>
    public enum DeptDataSourceType
    {
        全部科室,门诊临床科室,住院临床科室,药剂科室,药房科室,药库科室,物资科室,住院病区
    }
    /// <summary>
    /// 用户数据源类型
    /// </summary>
    public enum EmpDataSourceType
    {
        全部用户,医生,护士,收费员,药剂,医生和科室
    }
    /// <summary>
    /// 机构数据源类型
    /// </summary>
    public enum WorkDataSourceType
    {
        医疗机构等级=0, 医疗机构级别=1
    }
}
