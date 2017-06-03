using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.ClientController;
using EFWCoreLib.WcfFrame.DataSerialize;
using HIS_BasicData.Winform.IView.MessageManage;

namespace HIS_BasicData.Winform.Controller
{
    /// <summary>
    /// 消息订阅控制器
    /// </summary>
    [WinformController(DefaultViewName = "FrmMessageSubscribe")]
    [WinformView(Name = "FrmMessageSubscribe", DllName = "HIS_BasicData.Winform.dll", ViewTypeName = "HIS_BasicData.Winform.ViewForm.MessageManage.FrmMessageSubscribe")]
    public class MessageSubscribeController : WcfClientController
    {
        /// <summary>
        /// 消息订阅接口
        /// </summary>
        IMessageSubscribe messageSubscribe;

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init()
        {
            messageSubscribe = (IMessageSubscribe)iBaseView["FrmMessageSubscribe"];
        }

        /// <summary>
        /// 获取消息类型列表
        /// </summary>
        [WinformMethod]
        public void GetSubscribeMsgList()
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(LoginUserInfo.EmpId);
            });

            ServiceResponseData retdata = InvokeWcfService("BaseProject.Service", "MsgTypeManageController", "GetSubscribeMsgList", requestAction);
            DataTable msgList = retdata.GetData<DataTable>(0);
            messageSubscribe.Bind_MsgTypeList(msgList);
        }

        /// <summary>
        /// 订阅消息/取消消息订阅
        /// </summary>
        /// <param name="subscribeDt">待订阅或取消订阅的消息列表</param>
        /// <param name="isSubscribe">true：订阅/false：取消订阅</param>
        [WinformMethod]
        public void SaveMessageTypeUserData(DataTable subscribeDt, bool isSubscribe)
        {
            string showMsg = string.Empty;
            if (isSubscribe)
            {
                showMsg = "订阅";
            }
            else
            {
                showMsg = "取消订阅";
            }

            if (MessageBoxShowYesNo(string.Format("确定要{0}所选消息类型吗？", showMsg)) != DialogResult.Yes)
            {
                return;
            }

            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(subscribeDt);
                request.AddData(isSubscribe);
                request.AddData(LoginUserInfo.EmpId);
            });

            ServiceResponseData retdata = InvokeWcfService("BaseProject.Service", "MsgTypeManageController", "SaveMessageTypeUserData", requestAction);
            bool result = retdata.GetData<bool>(0);
            if (result)
            {
                string msg = retdata.GetData<string>(1);
                if (string.IsNullOrEmpty(msg))
                {
                    MessageBoxShowSimple(showMsg + "成功！");
                }
                else
                {
                    StringBuilder showMessage = new StringBuilder();
                    showMessage.AppendFormat("{0}成功！其中", showMsg);
                    msg = msg.Substring(0, msg.Length - 1);
                    showMessage.Append(msg);
                    showMessage.AppendFormat("已{0}。", showMsg);
                    MessageBoxShowSimple(showMessage.ToString());
                }

                GetSubscribeMsgList();
            }
            else
            {
                MessageBoxShowSimple(string.Format("所选数据已全部{0},请不要重复操作！", showMsg));
            }
        }

        #region "共用方法"

        /// <summary>
        /// 提示消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        [WinformMethod]
        public void MessageShow(string msg)
        {
            MessageBoxShowSimple(msg);
        }

        #endregion
    }
}
