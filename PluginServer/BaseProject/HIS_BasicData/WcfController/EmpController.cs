using System.Collections.Generic;
using System.Data;
using System.Linq;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.CoreFrame.DbProvider.Transaction;
using EFWCoreLib.CoreFrame.EntLib.Aop;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;
using HIS_PublicManage.ObjectModel;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 人员维护控制器
    /// </summary>
    [WCFController]
    public class EmpController : WcfServerController
    {
        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <returns>科室列表</returns>
        [WCFMethod]
        public ServiceResponseData GetDepts()
        {
            var workerId = requestData.GetData<int>(0);
            SetWorkId(workerId);
            DataTable dt = NewObject<BasicDataManagement>().GetBasicData(DeptDataSourceType.全部科室, true);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 根据机构ID,科室ID获取人员列表
        /// </summary>
        /// <returns>人员列表</returns>
        [WCFMethod]
        public ServiceResponseData GetEmps()
        {
            var workerId = requestData.GetData<int>(0);
            var deptId = requestData.GetData<int>(1);
            var name = requestData.GetData<string>(2);
            var showAll = requestData.GetData<bool>(3);
            var defaultDept = requestData.GetData<bool>(4);
            var depts = NewDao<IBasicDataEmpDao>().GetEmpList(name, workerId, deptId, showAll, defaultDept);
            responseData.AddData(depts);
            return responseData;
        }

        /// <summary>
        /// 获取基础数据
        /// </summary>
        /// <returns>基础数据列表</returns>
        [WCFMethod]
        public ServiceResponseData GetBasicData()
        {
            var manage = NewObject<BasicDataManagement>();
            var dtSex = manage.GetBasicData(PatientInfoDataSourceType.性别, false);
            responseData.AddData(dtSex);

            var dtDegree = manage.GetBasicData(PatientInfoDataSourceType.教育程度, false);
            responseData.AddData(dtDegree);

            var dtNation = manage.GetBasicData(PatientInfoDataSourceType.民族, false);
            responseData.AddData(dtNation);

            var dtMatrimony = manage.GetBasicData(PatientInfoDataSourceType.婚姻状况, false);
            responseData.AddData(dtMatrimony);

            var dtTitleCode = manage.GetBasicData(BasicDictType.技术职称, false);
            responseData.AddData(dtTitleCode);

            var dtPoliticalStatus = manage.GetBasicData(BasicDictType.政治面貌, false);
            responseData.AddData(dtPoliticalStatus);

            var dtJobClassifi = manage.GetBasicData(BasicDictType.岗位分类, false);
            responseData.AddData(dtJobClassifi);

            return responseData;
        }

        /// <summary>
        /// 获取人员详情
        /// </summary>
        /// <returns>人员详情</returns>
        [WCFMethod]
        public ServiceResponseData GetEmpDetail()
        {
            var empId = requestData.GetData<int>(0);
            var empDetail = NewObject<IBasicDataEmpDao>().GetEmpDetail(empId);
            responseData.AddData(empDetail);
            return responseData;
        }

        /// <summary>
        /// 保存人员信息
        /// </summary>
        /// <returns>OK保存成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveEmpAndDetail()
        {
            var workID = requestData.GetData<int>(0);
            var emp = requestData.GetData<BaseEmployee>(1);
            var empDetail = requestData.GetData<BaseEmployeeDetails>(2);

            SetWorkId(workID);
            emp.Szm = string.Empty;
            emp.Pym = SpellAndWbCode.GetSpellCode(emp.Name);
            emp.Wbm = SpellAndWbCode.GetWBCode(emp.Name);
            //empDetail.WorkId = emp.WorkId;
            this.BindDb(emp);
            emp.save();
            this.BindDb(empDetail);
            empDetail.EmpID = emp.EmpId;
            empDetail.save();
            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 启用或停用人员
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData FlagEmpAndDetail()
        {
            var empId = requestData.GetData<int>(0);
            var delFlag = requestData.GetData<int>(1);
            NewDao<IBasicDataEmpDao>().FlagEmpAndDetail(empId, delFlag);
            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 保存人员与科室关联关系
        /// </summary>
        /// <returns>OK操作成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveEmpRelDepts()
        {
            var relDepts = requestData.GetData<List<BaseEmpDept>>(0);
            foreach (var entity in relDepts.Where(n => n.Id > 0 && !n.IsRel))
            {
                BindDb(entity);
                entity.delete();
            }

            foreach (var entity in relDepts.Where(n => n.IsRel))
            {
                BindDb(entity);
                entity.save();
            }

            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 获取人员关联病区列表
        /// </summary>
        /// <returns>人员关联病区列表</returns>
        [WCFMethod]
        public ServiceResponseData GetEmpRelWards()
        {
            int workId = requestData.GetData<int>(0);
            int empId = requestData.GetData<int>(1);
            DataTable dt= NewDao<IBasicDataEmpDao>().GetEmpRelWards(workId, empId);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 保存人员关联病区数据
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        public ServiceResponseData SaveEmpRelWards()
        {
            int workId = requestData.GetData<int>(0);
            int empId = requestData.GetData<int>(1);
            List<BaseEmpWard> wards = requestData.GetData<List<BaseEmpWard>>(2);

            SetWorkId(workId);
            NewDao<IBasicDataEmpDao>().DelEmpRelWards(workId, empId);
            foreach(var item in wards)
            {
                this.BindDb(item);
                item.save();
            }

            responseData.AddData(true);
            return responseData;
        }
    }
}
