using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.MessageManage
{
    /// <summary>
    /// 消息类型维护接口
    /// </summary>
    public interface IMsgTypeManage: IBaseView
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        int WorkID { get; }

        /// <summary>
        /// 业务消息类型名
        /// </summary>
        string MsgTypeName { get; }

        /// <summary>
        /// 消息类型
        /// </summary>
        BaseMessageType MessageType { get; set; }

        /// <summary>
        /// 绑定业务消息类型列表
        /// </summary>
        /// <param name="msgTypeList">业务消息类型列表</param>
        /// <param name="isAdd">是否为新增后重新加载</param>
        void Bind_MsgTypeList(DataTable msgTypeList, bool isAdd);

        /// <summary>
        /// 加载机构下拉框数据
        /// </summary>
        /// <param name="workDt">机构列表</param>
        /// <param name="defaultWorkID">默认选中的机构ID</param>
        void loadWorkerDataBox(DataTable workDt, int defaultWorkID);
    }
}
