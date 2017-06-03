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

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 病区维护控制器
    /// </summary>
    [WCFController]
    public class WardController : WcfServerController
    {
        /// <summary>
        /// 根据机构ID,科室ID获取病区列表
        /// </summary>
        /// <returns>病区列表</returns>
        [WCFMethod]
        public ServiceResponseData GetWards()
        {
            var workerId = requestData.GetData<int>(0);
            //var deptId = requestData.GetData<int>(1);
            var name = requestData.GetData<string>(1);
            var showAll = requestData.GetData<bool>(2);
            var wards = NewDao<IBasicDataWardDao>().GetWardList(name, workerId, showAll);
            responseData.AddData(wards);
            return responseData;
        }

        /// <summary>
        /// 保存病区
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveWard()
        {
            var workId = requestData.GetData<int>(0);
            var ward = requestData.GetData<BaseWard>(1);

            SetWorkId(workId);
            ward.Szm = string.Empty;
            ward.Pym = SpellAndWbCode.GetSpellCode(ward.WardName);
            ward.Wbm = SpellAndWbCode.GetWBCode(ward.WardName);
            BindDb(ward);
            ward.save();

            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 启用与停用病区
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        public ServiceResponseData FlagWard()
        {
            var wardId = requestData.GetData<int>(0);
            var delFlag = requestData.GetData<int>(1);
            NewDao<IBasicDataWardDao>().FlagWard(wardId, delFlag);
            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 加载病区关联的科室与人员
        /// </summary>
        /// <returns>病区关联的科室与人员</returns>
        [WCFMethod]
        public ServiceResponseData GetWardRelDeptAndEmps()
        {
            var workId = requestData.GetData<int>(0);
            var wardId = requestData.GetData<int>(1);
            var bFlag = requestData.GetData<bool>(2);
            var depts = NewDao<IBasicDataWardDao>().GetWardRelDepts(workId, wardId, bFlag);
            responseData.AddData(depts);
            var emps = NewDao<IBasicDataWardDao>().GetWardRelEmps(workId, wardId, bFlag);
            responseData.AddData(emps);
            return responseData;
        }

        /// <summary>
        /// 保存病区与科室关联关系
        /// </summary>
        /// <returns>OK：保存成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveWardRelDepts()
        {
            int workId = requestData.GetData<int>(0);
            var relDepts = requestData.GetData<List<BaseWardDept>>(1);

            SetWorkId(workId);
            foreach (var entity in relDepts.Where(n => n.ID > 0 && !n.IsRel))
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
    }
}