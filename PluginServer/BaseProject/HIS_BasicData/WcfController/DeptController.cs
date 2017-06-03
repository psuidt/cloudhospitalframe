using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.DbProvider.Transaction;
using EFWCoreLib.CoreFrame.EntLib.Aop;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 科室维护控制器
    /// </summary>
    [WCFController]
    public class DeptController : WcfServerController
    {
        /// <summary>
        /// 根据机构ID获取科室分类树
        /// </summary>
        /// <returns>科室列表</returns>
        [WCFMethod]
        public ServiceResponseData GetDeptLayers()
        {
            var workerId = requestData.GetData<int>(0);
            var deptLayers = NewDao<IBasicDataDeptDao>()
                .GetDeptLayers(workerId);
            responseData.AddData(deptLayers);
            return responseData;
        }

        /// <summary>
        /// 根据机构ID获取科室列表
        /// </summary>
        /// <returns>科室列表</returns>
        [WCFMethod]
        public ServiceResponseData GetDeptList()
        {
            var workerId = requestData.GetData<int>(0);
            var layer = requestData.GetData<string>(1);
            var searchvalue = requestData.GetData<string>(2);
            var dept = NewDao<IBasicDataDeptDao>()
                .GetDeptList(workerId, layer, searchvalue);
            responseData.AddData(dept);
            return responseData;
        }

        /// <summary>
        /// 根据科室ID获取科室详细
        /// </summary>
        /// <returns>科室详细信息</returns>
        [WCFMethod]
        public ServiceResponseData GetDeptDetail()
        {
            var deptId = requestData.GetData<int>(0);
            var deptDetail = NewDao<IBasicDataDeptDao>()
                .GetDeptDetail(deptId);
            responseData.AddData(deptDetail);
            return responseData;
        }

        /// <summary>
        /// 根据科室ID删除科室
        /// </summary>
        /// <returns>操作结果</returns>
        [WCFMethod]
        public ServiceResponseData DeleteDept()
        {
            var deptId = requestData.GetData<int>(0);
            var status = requestData.GetData<int>(1);
            var deptDetail = NewDao<IBasicDataDeptDao>()
                .DeleteDept(deptId, status);
            responseData.AddData(deptDetail);
            return responseData;
        }

        /// <summary>
        /// 根据节点ID删除科室节点
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        public ServiceResponseData DelDeptLayer()
        {
            var layer = requestData.GetData<BaseDeptLayer>(0);
            this.BindDb(layer);
            layer.delete();
            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 保存科室详情
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveDeptDetail()
        {
            var deptDetail = requestData.GetData<BaseDeptDetails>(0);
            this.BindDb(deptDetail);
            deptDetail.save();
            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 保存科室
        /// </summary>
        /// <returns>OK：操作成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData AddDept()
        {
            var dept = requestData.GetData<BaseDept>(0);
            this.BindDb(dept);
            int deptid = dept.save();
            var deptDetail = requestData.GetData<BaseDeptDetails>(1);
            deptDetail.DeptID = deptid;
            deptDetail.ID = 0;
            var workId = requestData.GetData<int>(2);
            this.BindDb(deptDetail);
            SetWorkId(workId);
            deptDetail.save();
            responseData.AddData("OK");
            return responseData;
        }

        /// <summary>
        /// 保存科室节点
        /// </summary>
        /// <returns>操作结果</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveDeptLayer()
        {
            var deptlayer = requestData.GetData<BaseDeptLayer>(0);
            var workId = requestData.GetData<int>(1);
            this.BindDb(deptlayer);
            SetWorkId(workId);
            int layerid = deptlayer.save();
            responseData.AddData(layerid.ToString());
            return responseData;
        }

        /// <summary>
        /// 保存科室名称
        /// </summary>
        /// <returns>保存成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveDept()
        {
            var deptId = requestData.GetData<int>(0);
            var deptname = requestData.GetData<string>(1);
            var dept = NewDao<IBasicDataDeptDao>()
    .SaveDept(deptId, deptname);
            responseData.AddData(dept);
            return responseData;
        }

        /// <summary>
        /// 获取科室列表
        /// </summary>
        /// <returns>科室列表</returns>
        [WCFMethod]
        public ServiceResponseData GetDepts()
        {
            var workerId = requestData.GetData<int>(0);
            var strWhere = string.Format(" WorkId = {0} ", workerId);
            var depts = NewObject<BaseDept>().gettable(strWhere);
            responseData.AddData(depts);
            return responseData;
        }

        /// <summary>
        /// 获取科室列表与人员关联关系
        /// </summary>
        /// <returns>科室与人员关系列表</returns>
        [WCFMethod]
        public ServiceResponseData GetEmpRelDepts()
        {
            var workId = requestData.GetData<int>(0);
            var empId = requestData.GetData<int>(1);
            var depts = NewDao<IBasicDataDeptDao>().GetEmpRelDepts(workId, empId);
            responseData.AddData(depts);
            return responseData;
        }
    }
}
