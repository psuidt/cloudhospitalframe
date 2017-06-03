using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using HIS_BasicData.Winform.ViewForm.Channel;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 用法维护控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmChannel")]//与系统菜单对应
    [WinformView(Name = "FrmChannel", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.Channel.FrmChannel")]
    public class ChannelController : WcfClientController
    {
        /// <summary>
        /// 用法维护接口
        /// </summary>
        IFrmChannel frmChannels;

        /// <summary>
        /// 控制器初始化
        /// </summary>
        public override void Init()
        {
            frmChannels = (IFrmChannel)DefaultView;
        }

        /// <summary>
        /// 加载机构下拉框
        /// </summary>
        [WinformMethod]
        public void LoadBasicWorkers()
        {
            var retdata = InvokeWcfService(
                "BaseProject.Service",
                "WorkerController",
                "GetWorkers",
                (request) =>
                {
                    request.AddData(false);
                });
            var workers = retdata.GetData<List<BaseWorkers>>(0);
            frmChannels.LoadBasicWorkers(workers);
        }

        /// <summary>
        /// 加载用法网格信息
        /// </summary>
        /// <param name="workerId">机构ID</param>
        /// <param name="searchText">检索条件</param>
        [WinformMethod]
        public void LoadChannel(int workerId, string searchText)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
            "ChannelController",
            "LoadChannel",
            (request) =>
            {
                request.AddData(workerId);
                request.AddData(searchText);
            });
            var channels = retdata.GetData<DataTable>(0);
            frmChannels.LoadChannel(channels);
        }

        /// <summary>
        /// 保存用法信息
        /// </summary>
        /// <param name="workerId">机构ID</param>
        [WinformMethod]
        public void SaveChannel(int workerId)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
            "ChannelController",
            "SaveChannel",
            (request) =>
            {
                request.AddData(frmChannels.CurrentData);
                request.AddData(workerId);
                request.AddData(frmChannels.ChannelFeeList);
            });
            var result = retdata.GetData<int>(0);
            frmChannels.SaveComplete(result);
        }

        /// <summary>
        /// 读取用法费用联动信息
        /// </summary>
        /// <param name="channelId">用法ID</param>
        /// <param name="type">类型</param>
        [WinformMethod]
        public void LoadChannelFee(int channelId, int type)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
            "ChannelController",
            "LoadChannelFee",
            (request) =>
            {
                request.AddData(channelId);
            });

            var channelFees = retdata.GetData<DataTable>(0);
            if (type == 0)
            {
                frmChannels.LoadChannelFee(channelFees);
            }
            else
            {
                frmChannels.LoadChannelFeeDt(channelFees);
            }
        }

        /// <summary>
        /// 启用停用用法信息
        /// </summary>
        /// <param name="channelId">用法ID</param>
        /// <param name="status">状态</param>
        [WinformMethod]
        public void StopChannel(string channelId, int status)
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
            "ChannelController",
            "StopChannel",
            (request) =>
            {
                request.AddData(channelId);
                request.AddData(status);
            });
        }

        /// <summary>
        /// 获取用法联动showcard信息
        /// </summary>
        [WinformMethod]
        public void LoadFeeInfoCard()
        {
            var retdata = InvokeWcfService(
            "BaseProject.Service",
            "ChannelController",
            "LoadFeeInfoCard",
            (request) =>
            {
                request.AddData(LoginUserInfo.WorkId);
            });
            var channelFees = retdata.GetData<DataTable>(0);
            frmChannels.BindFeeInfoCard(channelFees);
        }
    }
}
