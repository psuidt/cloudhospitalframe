using HIS_PublicManage.ObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_PublicManage.Dao
{
    public interface IPublicManageDao 
    {
        #region 病人信息相关
        /// <summary>
        /// 获取国籍
        /// </summary>
        /// <returns></returns>
        DataTable GetNationality();
        /// <summary>
        /// 获取民族
        /// </summary>
        /// <returns></returns>
        DataTable GetNation();
        /// <summary>
        /// 获取教育程度
        /// </summary>
        /// <returns></returns>
        DataTable GetEducation();
        /// <summary>
        /// 婚姻状况
        /// </summary>
        /// <returns></returns>
        DataTable GetMatrimony();
        /// <summary>
        /// 获取职业
        /// </summary>
        /// <returns></returns>
        DataTable GetOccupation();
        /// <summary>
        /// 获取关系
        /// </summary>
        /// <returns></returns>
        DataTable GetRelation();
        /// <summary>
        /// 获取性别
        /// </summary>
        /// <returns></returns>
        DataTable GetSex();
        /// <summary>
        /// 获取血型
        /// </summary>
        /// <returns></returns>
        DataTable GetBloodType();

        /// <summary>
        /// 病人情况
        /// </summary>
        /// <returns></returns>
        DataTable GetIPSituation();
        /// <summary>
        /// 麻醉方式
        /// </summary>
        /// <returns></returns>
        DataTable GetAnesthesia();
        /// <summary>
        /// 地区编码
        /// </summary>
        /// <returns></returns>
        DataTable GetDistriceCoding();

        /// <summary>
        /// 获取护理级别ClassId=1039
        /// </summary>
        /// <returns></returns>
        DataTable GetNusingLevel();
        /// <summary>
        /// 获取饮食级别ClassId=1040
        /// </summary>
        /// <returns></returns>
        DataTable GetDietType();
        #endregion

        #region 科室数据相关
        /// <summary>
        /// 所有科室
        /// </summary>
        /// <returns></returns>
        DataTable GetAllDept();
        /// <summary>
        /// 门诊临床科室
        /// </summary>
        /// <returns></returns>
        DataTable GetOPClinicalDept();
        /// <summary>
        /// 住院临床科室
        /// </summary>
        /// <returns></returns>
        DataTable GetIPClinicalDept();
        /// <summary>
        /// 药剂科室
        /// </summary>
        /// <returns></returns>
        DataTable GetDrugDept();
        /// <summary>
        /// 药房科室
        /// </summary>
        /// <returns></returns>
        DataTable GetPharmacyDept();
        /// <summary>
        /// 药库科室
        /// </summary>
        /// <returns></returns>
        DataTable GetDrugStorageDept();
        /// <summary>
        /// 物资科室
        /// </summary>
        /// <returns></returns>
        DataTable GetMaterialsDept();
        /// <summary>
        /// 获取病区科室
        /// </summary>
        /// <returns></returns>
        DataTable GetWardDept();
        #endregion

        #region 用户数据相关
        /// <summary>
        /// 所有人员
        /// </summary>
        /// <returns></returns>
        DataTable GetEmpAll(int iWorkId);
        /// <summary>
        /// 医生
        /// </summary>
        /// <returns></returns>
        DataTable GetDoctor(int iWorkId);
        /// <summary>
        /// 护士
        /// </summary>
        /// <returns></returns>
        DataTable GetNurse(int iWorkId);
        /// <summary>
        /// 收银员
        /// </summary>
        /// <returns></returns>
        DataTable GetCashier(int iWorkId);
        /// <summary>
        /// 药剂师
        /// </summary>
        /// <returns></returns>
        DataTable GetPharmacist(int iWorkId);
        /// <summary>
        /// 获取医生和医生科室信息
        /// </summary>
        /// <param name="iWorkId"></param>
        /// <returns></returns>
        DataTable GetDoctorAndDept(int iWorkId);
        #endregion

        #region 获取名称
        DataTable GetWorkers();
        DataTable GetPatType();
        /// <summary>
        /// 获取诊断
        /// </summary>
        /// <returns></returns>
        DataTable GetDisease();
        /// <summary>
        /// 获取大项目代码
        /// </summary>
        /// <returns></returns>
        DataTable GetStatItem();
        /// <summary>
        /// 获取单位
        /// </summary>
        /// <returns></returns>
        DataTable GetUnit();
        string GetEmpName(int empId);
        string GetDeptName(int deptId);
        string GetWardName(int wardId);
        string GetWorkName(int workId);
        string GetDictContent(int classId, string code);
        string GetPatTypeName(int patTypeId);
        #endregion

        #region 费用数据源
        /// <summary>
        /// 获取多个类别费用数据(临床用)
        /// </summary>
        /// <param name="itemclass"></param>
        /// <returns></returns>
        DataTable GetFeeItemData(int[] itemclass);
        /// <summary>
        /// 获取单个类别费用数据
        /// </summary>
        /// <param name="itemclass"></param>
        /// <returns></returns>
        DataTable GetSimpleFeeItemData(int itemclass);
        /// <summary>
        /// 获取多个类别费用数据
        /// </summary>
        /// <param name="itemclass"></param>
        /// <returns></returns>
        DataTable GetSimpleFeeItemData(int[] itemclass);

        /// <summary>
        /// 通过组合项目ID获取组合项目对应的收费明细数据
        /// </summary>
        /// <param name="ExamItemID"></param>
        /// <returns></returns>
        DataTable GetExamItemDetailDt(int ExamItemID);
        #endregion

        DataTable GetDictData(int classId);
        /// <summary>
        /// 是否存在此流水号类型
        /// </summary>
        /// <param name="snType">流水号类型</param>
        /// <returns></returns>
        bool IsExistSNType(int snType, int deptId, string type);
        /// <summary>
        /// 是否今日
        /// </summary>
        /// <param name="snType">流水号类型</param>
        /// <returns></returns>
        bool IsTodaySNType(int snType, int deptId, string type);
        /// <summary>
        /// 插入流水号
        /// </summary>
        /// <param name="snType">流水号类型</param>
        /// <returns></returns>
        int InsertSerialNumber(int snType, int deptId, string type);
        /// <summary>
        /// 更新流水号
        /// </summary>
        /// <param name="snType">流水号类型</param>
        /// <returns></returns>
        int UpdateTodaySerialNumber(int snType, int deptId, string type);
        /// <summary>
        /// 更新流水号
        /// </summary>
        /// <param name="snType">流水号类型</param>
        /// <returns></returns>
        int UpdateNoTodaySerialNumber(int snType, int deptId, string type);

        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="paraID"></param>
        /// <returns></returns>
        string GetSystemConfigValue(int deptID,string paraID);

        /// <summary>
        /// 医保类型
        /// </summary>
        /// <returns></returns>
        DataTable GetMedicareDic();
        /// <summary>
        /// 获取员工关联科室
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="IsOut"></param>
        /// <returns></returns>
        DataTable GetUserDept(int empId, int IsOut);
        /// <summary>
        /// 获取员工关联病区
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        DataTable GetUserWard(int empId);
        /// <summary>
        /// 获取执行代码
        /// </summary>
        /// <param name="frequencyID">频次ID</param>
        /// <returns></returns>
        string GetExecuteCode(int frequencyID);

        #region "业务消息数据相关"

        /// <summary>
        /// 验证消息类型是否被停用
        /// </summary>
        /// <param name="msgCode">消息代码</param>
        /// <param name="workId">机构ID</param>
        /// <returns></returns>
        DataTable GetMsgType(string msgCode, int workId);

        /// <summary>
        /// 获取业务消息中包含的病人信息
        /// </summary>
        /// <param name="patListID">病人登记信息</param>
        /// <returns></returns>
        DataTable GetPatientInfo(int patListID);

        /// <summary>
        /// 获取业务消息包含的药品统领信息
        /// </summary>
        /// <param name="billID">药品统领明细ID</param>
        /// <returns></returns>
        DataTable GetDrugBillDetailData(int billID, MessageType msgType);

        /// <summary>
        /// 获取门诊病人基本信息
        /// </summary>
        /// <param name="patListId">病人ID</param>
        /// <returns></returns>
        DataTable GetOpPatlist(int patListId);

        /// <summary>
        /// 取消一键消息订阅
        /// </summary>
        /// <param name="megTypeId">消息类型ID</param>
        /// <param name="empIdList">用户ID列表</param>
        /// <returns></returns>
        bool CancelOneKeySubscribeMsg(int megTypeId, int empIdList);

        #endregion
    }
}
