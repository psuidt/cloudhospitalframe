using System.Collections.Generic;
using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.Winform.ViewForm.Channel
{
    /// <summary>
    /// 用法接口
    /// </summary>
    public interface IFrmChannel : IBaseView
    {
        /// <summary>
        /// 用法对象
        /// </summary>
        Basic_Channel CurrentData { get; set; }

        /// <summary>
        /// 用法关联费用列表
        /// </summary>
        List<Basic_ChannelFee> ChannelFeeList { get; set; }

        /// <summary>
        /// 加载机构下拉框
        /// </summary>
        /// <param name="workers">机构列表</param>
        void LoadBasicWorkers(List<BaseWorkers> workers);

        /// <summary>
        /// 加载用法信息
        /// </summary>
        /// <param name="channels">用法列表</param>
        void LoadChannel(DataTable channels);

        /// <summary>
        /// 保存完成后执行的方法
        /// </summary>
        /// <param name="result">大于0保存成功</param>
        void SaveComplete(int result);

        /// <summary>
        /// 加载用法联动费用信息
        /// </summary>
        /// <param name="channelFees">用法联动费用列表</param>
        void LoadChannelFee(DataTable channelFees);

        /// <summary>
        /// 加载用法联动费用信息
        /// </summary>
        /// <param name="channelFees">用法联动费用列表</param>
        void LoadChannelFeeDt(DataTable channelFees);

        /// <summary>
        /// 绑定费用联动录入ShowCard
        /// </summary>
        /// <param name="dtFeeInfo">费用联动信息</param>
        void BindFeeInfoCard(DataTable dtFeeInfo);
    }
}
