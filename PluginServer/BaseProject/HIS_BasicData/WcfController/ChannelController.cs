using System.Collections.Generic;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_BasicData.ObjectModel;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 用法维护控制器
    /// </summary>
    [WCFController]
    public class ChannelController : WcfServerController
    {
        /// <summary>
        /// 根据机构ID获取用法信息
        /// </summary>
        /// <returns>用法信息</returns>
        [WCFMethod]
        public ServiceResponseData LoadChannel()
        {
            var workerId = requestData.GetData<int>(0);
            var searchText = requestData.GetData<string>(1);
            var channels = NewDao<IBasicDataChannelDao>().GetChannels(workerId, searchText);
            responseData.AddData(channels);
            return responseData;
        }

        /// <summary>
        /// 保存用法信息
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        public ServiceResponseData SaveChannel()
        {
            var bchannel = requestData.GetData<Basic_Channel>(0);
            var workid = requestData.GetData<int>(1);
            var feelist = requestData.GetData<List<Basic_ChannelFee>>(2);
            int result = -1;
            var channels = NewDao<IBasicDataChannelDao>().GetChannels(workid, string.Empty);
            if (!new ChannelMrg().CheckisExit(bchannel, channels))
            {
                this.BindDb(bchannel);
                SetWorkId(workid);
                result = bchannel.save();
                int isdel = NewDao<IBasicDataChannelDao>().DeleteChannelFees(bchannel.ID);
                foreach (Basic_ChannelFee bfee in feelist)
                {
                    bfee.ChannelID = bchannel.ID;
                    this.BindDb(bfee);
                    SetWorkId(workid);
                    bfee.save();
                }
            }

            responseData.AddData(result);
            return responseData;
        }

        /// <summary>
        /// 根据用法ID获取用法费用信息
        /// </summary>
        /// <returns>用法费用信息</returns>
        [WCFMethod]
        public ServiceResponseData LoadChannelFee()
        {
            var channelId = requestData.GetData<int>(0);
            var channelFees = NewDao<IBasicDataChannelDao>().GetChannelFees(channelId);
            responseData.AddData(channelFees);
            return responseData;
        }

        /// <summary>
        /// 启用停用用法信息
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        public ServiceResponseData StopChannel()
        {
            var channelId = requestData.GetData<string>(0);
            var status = requestData.GetData<int>(1);
            var result = NewDao<IBasicDataChannelDao>().StopChannel(channelId, status);
            responseData.AddData(result);
            return responseData;
        }

        /// <summary>
        /// 获取费用联动showcard
        /// </summary>
        /// <returns>费用基础数据</returns>
        [WCFMethod]
        public ServiceResponseData LoadFeeInfoCard()
        {
            var workerId = requestData.GetData<int>(0);
            var channelFees = NewDao<IBasicDataChannelDao>().LoadFeeInfoCard(workerId);
            responseData.AddData(channelFees);
            return responseData;
        }
    }
}
