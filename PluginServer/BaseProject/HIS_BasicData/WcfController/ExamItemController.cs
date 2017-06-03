using System.Collections.Generic;
using System.Data;
using System.Linq;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;
using HIS_PublicManage.ObjectModel;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 组合项目服务控制器
    /// </summary>
    [WCFController]
    public class ExamItemController : WcfServerController
    {
        /// <summary>
        /// 获取基础数据
        /// </summary>
        /// <returns>基础数据集合</returns>
        [WCFMethod]
        public ServiceResponseData InitLoadData()
        {
            //机构
            List<BaseWorkers> workers = NewObject<BaseWorkers>()
                .getlist<BaseWorkers>(" DelFlag = 0 ");
            responseData.AddData(workers);
            //分类
            DataTable dt = NewDao<IBasicDataExamItemDao>().GetExamClass();
            responseData.AddData(dt);
            //执行科室
            //DataTable deptdt = NewObject<BasicDataManagement>().GetBasicData(DeptDataSourceType.全部科室);
            //responseData.AddData(deptdt);
            //统计分类
            DataTable statdt = NewObject<BasicDataManagement>().GetStatItem(false);
            responseData.AddData(statdt);
            //费用项目
            //DataTable feedt = NewObject<FeeItemDataSource>().GetSimpleFeeItemDataDt(FeeBusinessType.基础业务);
            //responseData.AddData(feedt);
            return responseData;
        }

        /// <summary>
        /// 获取科室和费用数据
        /// </summary>
        /// <returns>科室和费用数据集合</returns>
        [WCFMethod]
        public ServiceResponseData ChangeWorker()
        {
            int workId = requestData.GetData<int>(0);
            SetWorkId(workId);

            //执行科室
            DataTable deptdt = NewObject<BasicDataManagement>().GetBasicData(DeptDataSourceType.全部科室);
            responseData.AddData(deptdt);
            //费用项目
            DataTable feedt = NewObject<FeeItemDataSource>().GetSimpleFeeItemDataDt(FeeBusinessType.基础业务);
            responseData.AddData(feedt);

            return responseData;
        }

        /// <summary>
        /// 获取组合项目类型列表
        /// </summary>
        /// <returns>组合项目类型列表</returns>
        [WCFMethod]
        public ServiceResponseData GetExamType()
        {
            int workId = requestData.GetData<int>(0);
            int examclass = requestData.GetData<int>(1);

            DataTable dt = NewDao<IBasicDataExamItemDao>().GetExamType(workId, examclass);
            responseData.AddData(dt);

            return responseData;
        }

        /// <summary>
        /// 获取组合项目列表
        /// </summary>
        /// <returns>组合项目列表</returns>
        [WCFMethod]
        public ServiceResponseData GetExamItem()
        {
            int workId = requestData.GetData<int>(0);
            int examtypeId = requestData.GetData<int>(1);
            string searchStr = requestData.GetData<string>(2);

            DataTable dt = NewDao<IBasicDataExamItemDao>().GetExamItem(workId, examtypeId, searchStr);
            responseData.AddData(dt);

            return responseData;
        }

        /// <summary>
        /// 获取组合项目关联费用
        /// </summary>
        /// <returns>组合项目关联费用</returns>
        [WCFMethod]
        public ServiceResponseData GetExamFee()
        {
            int examitemId = requestData.GetData<int>(0);
            DataTable dt = NewDao<IBasicDataExamItemDao>().GetExamFee(examitemId);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 保存组合项目类型
        /// </summary>
        /// <returns>组合项目类型</returns>
        [WCFMethod]
        public ServiceResponseData SaveExamType()
        {
            int workId = requestData.GetData<int>(0);
            int examtypeId = requestData.GetData<int>(1);
            int examclass = requestData.GetData<int>(2);
            string examtypeName = requestData.GetData<string>(3);
            int execdeptId = requestData.GetData<int>(4);
            int delflag = requestData.GetData<int>(5);
            int sampleId = requestData.GetData<int>(6);
            int reportNo = requestData.GetData<int>(7);
            SetWorkId(workId);
            Basic_ExamType examtype = NewObject<Basic_ExamType>();
            examtype.ExamTypeID = examtypeId;
            examtype.ExamTypeName = examtypeName;
            examtype.ExamClass = examclass;
            examtype.ExecDeptID = execdeptId;
            examtype.DelFlag = delflag;
            examtype.SampleID = sampleId;
            examtype.ReportNo = reportNo;

            examtype.save();
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 删除组合项目类型
        /// </summary>
        /// <returns>true：删除成功</returns>
        [WCFMethod]
        public ServiceResponseData DeleteExamType()
        {
            int examtypeId = requestData.GetData<int>(0);

            NewDao<IBasicDataExamItemDao>().DeleteExamType(examtypeId);
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 保存组合项目数据
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        public ServiceResponseData SaveExamItem()
        {
            int workId = requestData.GetData<int>(0);
            Basic_ExamItem examitem = requestData.GetData<Basic_ExamItem>(1);
            SetWorkId(workId);
            this.BindDb(examitem);
            examitem.save();
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 删除组合项目
        /// </summary>
        /// <returns>true：删除成功</returns>
        [WCFMethod]
        public ServiceResponseData DeleteExamItem()
        {
            int examitemId = requestData.GetData<int>(0);
            NewDao<IBasicDataExamItemDao>().DeleteExamItem(examitemId);
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 删除组合项目关联费用
        /// </summary>
        /// <returns>true：删除成功</returns>
        [WCFMethod]
        public ServiceResponseData SaveExamFee()
        {
            int workId = requestData.GetData<int>(0);
            int examitemId = requestData.GetData<int>(1);
            List<Basic_ExamItemFee> feelist = requestData.GetData<List<Basic_ExamItemFee>>(2);
            feelist = feelist.Where(item => item.FeeClass > 0).ToList();
            SetWorkId(workId);
            //1.删除原有的费用
            NewDao<IBasicDataExamItemDao>().DeleteExamFee(examitemId);
            //2.插入新的费用集合
            foreach (var item in feelist)
            {
                item.ID = 0;
                this.BindDb(item);
                item.save();
            }

            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 获取样本基础数据列表
        /// </summary>
        /// <returns>样本基础数据列表</returns>
        [WCFMethod]
        public ServiceResponseData GetSampleList()
        {
            int workID = requestData.GetData<int>(0);
            // 获取样本数据列表
            //List<BaseDictContent> sampleList = NewObject<BaseDictContent>().getlist<BaseDictContent>("ClassId=1030 AND　WorkID="+ workID);
            DataTable sampleDt = NewObject<BaseDictContent>().gettable("ClassId=1030 AND WorkID=" + workID);
            responseData.AddData(sampleDt);
            return responseData;
        }
    }
}
