using System.Collections.Generic;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.CoreFrame.DbProvider.Transaction;
using EFWCoreLib.CoreFrame.EntLib.Aop;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_BasicData.ObjectModel;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 执行单配置控制器
    /// </summary>
    [WCFController]
    public class ExceBillController : WcfServerController
    {
        /// <summary>
        /// 获取执行单配置列表
        /// </summary>
        /// <returns>执行单配置列表</returns>
        [WCFMethod]
        public ServiceResponseData GetExecBillInfo()
        {
            var workerId = requestData.GetData<int>(0);
            var queryStr = requestData.GetData<string>(1);
            var dt = NewObject<ExexBillMrg>().GetExecBillInfo(workerId, queryStr, queryStr, queryStr);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 验证执行单名是否重复
        /// </summary>
        /// <returns>执行单信息</returns>
        [WCFMethod]
        public ServiceResponseData CheckExecBillName()
        {
            var workerId = requestData.GetData<int>(0);
            var name = requestData.GetData<string>(1);
            var dt = NewObject<ExexBillMrg>().CheckExecBillName(workerId, name);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 获取执行单信息
        /// </summary>
        /// <returns>执行单信息</returns>
        [WCFMethod]
        public ServiceResponseData GetChannelInfo()
        {
            var workerId = requestData.GetData<int>(0);
            var dt = NewObject<ExexBillMrg>().GetChannelInfo(workerId);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 获取执行单关联的用法列表
        /// </summary>
        /// <returns>用法列表</returns>
        [WCFMethod]
        public ServiceResponseData GetExecuteBillChannel()
        {
            var workerId = requestData.GetData<int>(0);
            var billid = requestData.GetData<int>(1);
            var dt = NewObject<ExexBillMrg>().GetExecuteBillChannel(billid, workerId);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 验证执行单名是否重复
        /// </summary>
        /// <returns>false：重复</returns>
        [WCFMethod]
        public ServiceResponseData CheckName()
        {
            var workerId = requestData.GetData<int>(0);
            var billid = requestData.GetData<int>(1);
            var name = requestData.GetData<string>(2);
            var dt = NewObject<ExexBillMrg>().CheckName(workerId, name, billid);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 保存执行单配置信息
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        [AOP(typeof(AopTransaction))]
        public ServiceResponseData SaveBillChannelInfo()
        {
            var workerId = requestData.GetData<int>(0);
            var billEntity = requestData.GetData<Basic_ExecuteBills>(1);
            var channelList = requestData.GetData<List<Basic_ExecuteBillChannel>>(2);
            var delList = requestData.GetData<List<Basic_ExecuteBillChannel>>(3);
            SetWorkId(workerId);
            var dt = NewObject<ExexBillMrg>().SaveBillChannelInfo(workerId, billEntity, channelList, delList);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 更新执行单使用状态
        /// </summary>
        /// <returns>true：更新成功</returns>
        [WCFMethod]
        public ServiceResponseData UpdateFlag()
        {
            var workerId = requestData.GetData<int>(0);
            var id = requestData.GetData<int>(1);
            var useFlag = requestData.GetData<int>(2);
            var res = NewDao<IBasicDataExceBillDao>().UpdateUseFlag(id, useFlag, workerId);
            responseData.AddData(res);
            return responseData;
        }
    }
}
