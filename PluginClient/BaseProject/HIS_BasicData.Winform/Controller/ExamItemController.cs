using System;
using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.Common;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.IView.ExamItem;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 组合项目维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmExamItem")]//与系统菜单对应
    [WinformView(Name = "FrmExamItem", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.ExamItem.FrmExamItem")]
    public class ExamItemController : WcfClientController
    {
        /// <summary>
        /// 组合项目维护接口
        /// </summary>
        IFrmExamItem frmExamItem;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmExamItem = (IFrmExamItem)iBaseView["FrmExamItem"];
        }

        /// <summary>
        /// 基础数据集
        /// </summary>
        private List<object> asynData = new List<object>();

        /// <summary>
        /// 异步加载基础数据
        /// </summary>
        public override void AsynInit()
        {
            var retdata = InvokeWcfService(
               "BaseProject.Service",
               "ExamItemController",
               "InitLoadData");
            List<BaseWorkers> workers = retdata.GetData<List<BaseWorkers>>(0);
            asynData.Add(workers);
            DataTable classdt = retdata.GetData<DataTable>(1);
            asynData.Add(classdt);
            DataTable statdt = retdata.GetData<DataTable>(2);
            asynData.Add(statdt);
        }

        /// <summary>
        /// 回调绑定基础数据
        /// </summary>
        public override void AsynInitCompleted()
        {
            List<BaseWorkers> workers = asynData[0] as List<BaseWorkers>;
            frmExamItem.loadWorkerDataBox(ConvertExtend.ToDataTable(workers), LoginUserInfo.WorkId);
            frmExamItem.loadExamClassBox(asynData[1] as DataTable);
            frmExamItem.loadStatItemBox(asynData[2] as DataTable);

            //获取组合类型
            GetExamTypeData(LoginUserInfo.WorkId, 1);
            ChangeWorker(LoginUserInfo.WorkId);
            GetSampleList(LoginUserInfo.WorkId);
            //
            //注册事件
            frmExamItem.registerEvent();
        }

        /// <summary>
        /// 获取科室和费用数据
        /// </summary>
        /// <param name="workId">机构ID</param>
        [WinformMethod]
        public void ChangeWorker(int workId)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "ExamItemController",
              "ChangeWorker",
              (request) =>
              {
                  request.AddData(workId);
              });

            DataTable deptdt = retdata.GetData<DataTable>(0);
            frmExamItem.loadDeptDataBox(deptdt);
            DataTable feedt = retdata.GetData<DataTable>(1);
            frmExamItem.loadExamFeeShowCard(feedt);
        }

        /// <summary>
        /// 获取组合项目类型
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="examClass">分类</param>
        [WinformMethod]
        public void GetExamTypeData(int workId, int examClass)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "ExamItemController",
              "GetExamType",
              (request) =>
              {
                  request.AddData(workId);
                  request.AddData(examClass);
              });

            DataTable dt = retdata.GetData<DataTable>(0);
            frmExamItem.loadExamTypeGrid(dt);
        }

        /// <summary>
        /// 获取组合项目列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="examtypeId">类型ID</param>
        /// <param name="searchStr">检索条件</param>
        [WinformMethod]
        public void GetExamItemData(int workId, int examtypeId, string searchStr)
        {
            var retdata = InvokeWcfService(
              "BaseProject.Service",
              "ExamItemController",
              "GetExamItem",
              (request) =>
              {
                  request.AddData(workId);
                  request.AddData(examtypeId);
                  request.AddData(searchStr);
              });

            DataTable dt = retdata.GetData<DataTable>(0);
            frmExamItem.loadExamItemGrid(dt);
        }

        /// <summary>
        /// 获取组合项目费用列表
        /// </summary>
        /// <param name="examitemId">组合项目ID</param>
        [WinformMethod]
        public void GetExamFeeData(int examitemId)
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "ExamItemController",
             "GetExamFee",
             (request) =>
             {
                 request.AddData(examitemId);
             });

            DataTable dt = retdata.GetData<DataTable>(0);
            frmExamItem.loadExamFeeGrid(dt);
        }

        /// <summary>
        /// 保存组合项目类型
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="examtypeId">组合项目类型ID</param>
        /// <param name="examclass">分类</param>
        /// <param name="examtypeName">名称</param>
        /// <param name="execdeptId">执行科室ID</param>
        /// <param name="delflag">删除标志</param>
        /// <param name="sampleId">样本ID</param>
        /// <param name="reportNo">报表编号</param>
        [WinformMethod]
        public void SaveExamType(int workId, int examtypeId, int examclass, string examtypeName, int execdeptId, int delflag, int sampleId, int reportNo)
        {
            try
            {
                var retdata = InvokeWcfService(
                 "BaseProject.Service",
                 "ExamItemController",
                 "SaveExamType",
                 (request) =>
                 {
                     request.AddData(workId);
                     request.AddData(examtypeId);
                     request.AddData(examclass);
                     request.AddData(examtypeName);
                     request.AddData(execdeptId);
                     request.AddData(delflag);
                     request.AddData(sampleId);
                     request.AddData(reportNo);
                 });

                MessageBoxShowSimple("保存组合项目类型成功！");
            }
            catch (Exception e)
            {
                MessageBoxShowError("保存组合项目类型失败！\n" + e.Message);
            }
        }

        /// <summary>
        /// 删除组合项目类型
        /// </summary>
        /// <param name="examtypeId">类型ID</param>
        [WinformMethod]
        public void DeleteExamType(int examtypeId)
        {
            try
            {
                var retdata = InvokeWcfService(
                 "BaseProject.Service",
                 "ExamItemController",
                 "DeleteExamType",
                 (request) =>
                 {
                     request.AddData(examtypeId);
                 });

                MessageBoxShowSimple("删除组合项目类型成功！");
            }
            catch (Exception e)
            {
                MessageBoxShowError("删除组合项目类型失败！\n" + e.Message);
            }
        }

        /// <summary>
        /// 保存组合项目
        /// </summary>
        /// <param name="workId">机构ID</param>
        [WinformMethod]
        public void SaveExamItem(int workId)
        {
            Basic_ExamItem examitem = frmExamItem.CurrExamItem;
            examitem.PYCode = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetSpellCode(examitem.ExamItemName, 0, 10);
            examitem.WBCode = EFWCoreLib.CoreFrame.Common.SpellAndWbCode.GetSpellCode(examitem.ExamItemName, 0, 10);

            try
            {
                var retdata = InvokeWcfService(
                 "BaseProject.Service",
                 "ExamItemController",
                 "SaveExamItem",
                 (request) =>
                 {
                     request.AddData(workId);
                     request.AddData(examitem);
                 });

                MessageBoxShowSimple("保存组合项目成功！");
            }
            catch (Exception e)
            {
                MessageBoxShowError("保存组合项目失败！\n" + e.Message);
            }
        }

        /// <summary>
        /// 保存组合项目费用
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="examitemId">组合项目ID</param>
        /// <param name="dt">费用列表</param>
        [WinformMethod]
        public void SaveExamFee(int workId, int examitemId, DataTable dt)
        {
            List<Basic_ExamItemFee> feelist = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<Basic_ExamItemFee>(dt);

            try
            {
                var retdata = InvokeWcfService(
                 "BaseProject.Service",
                 "ExamItemController",
                 "SaveExamFee",
                 (request) =>
                 {
                     request.AddData(workId);
                     request.AddData(examitemId);
                     request.AddData(feelist);
                 });

                MessageBoxShowSimple("保存费用明细成功！");
            }
            catch (Exception e)
            {
                MessageBoxShowError("保存费用明细失败！\n" + e.Message);
            }
        }

        /// <summary>
        /// 加载样本列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        [WinformMethod]
        public void GetSampleList(int workId)
        {
            var retdata = InvokeWcfService(
             "BaseProject.Service",
             "ExamItemController",
             "GetSampleList",
             (request) =>
             {
                 request.AddData(workId);
             });
            DataTable sampleDt = retdata.GetData<DataTable>(0);
            frmExamItem.loadSampleList(sampleDt);
        }
    }
}