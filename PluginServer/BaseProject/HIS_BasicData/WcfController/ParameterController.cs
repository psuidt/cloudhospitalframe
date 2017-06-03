using System;
using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 系统参数控制器
    /// </summary>
    [WCFController]
    public class ParameterController : WcfServerController
    {
        /// <summary>
        /// 获取机构数据
        /// </summary>
        /// <returns>机构数据</returns>
        [WCFMethod]
        public ServiceResponseData GetWorkerData()
        {
            //机构
            List<BaseWorkers> workers = NewObject<BaseWorkers>()
                .getlist<BaseWorkers>(" DelFlag = 0 ");
            responseData.AddData(workers);
            return responseData;
        }

        /// <summary>
        /// 获取系统参数类型数据
        /// </summary>
        /// <returns>系统参数类型</returns>
        [WCFMethod]
        public ServiceResponseData GetSystemTypeData()
        {
            DataTable dt = NewDao<IBasicDataParameterDao>().GetSystemTypeData();
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 获取系统参数配置数据
        /// </summary>
        /// <returns>系统参数配置数据</returns>
        [WCFMethod]
        public ServiceResponseData GetSystemConfigData()
        {
            int workId = requestData.GetData<int>(0);
            int sysType = requestData.GetData<int>(1);
            string searchStr = requestData.GetData<string>(2);

            DataTable dt = NewDao<IBasicDataParameterDao>().GetSystemConfigData(workId, sysType, searchStr);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 保存系统参数
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        public ServiceResponseData SaveSystemConfig()
        {
            int workId = requestData.GetData<int>(0);
            Basic_SystemConfig config = requestData.GetData<Basic_SystemConfig>(1);

            //新增参数才验证
            if (config.ID == 0 && NewDao<IBasicDataParameterDao>().ExistSystemConfig(config.ParaID, workId, config.DeptID, config.SystemType) == true)
            {
                throw new Exception("同机构、同业务系统、同科室的系统参数不能相同！");
            }

            SetWorkId(workId);
            this.BindDb(config);
            config.save();

            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 停用启用系统参数
        /// </summary>
        /// <returns>true：操作成功</returns>
        [WCFMethod]
        public ServiceResponseData SwitchSystemConfig()
        {
            int sysID = requestData.GetData<int>(0);
            int val = requestData.GetData<int>(1);
            NewDao<IBasicDataParameterDao>().SwitchSystemConfig(sysID, val);
            responseData.AddData(true);
            return responseData;
        }
    }
}
