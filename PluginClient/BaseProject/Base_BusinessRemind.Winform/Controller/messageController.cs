using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using base_businessremind.Entity;
using base_businessremind.ObjectModel;
using base_businessremind.winform.IView;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WinformFrame.Controller;

namespace base_businessremind.winform.Controller
{
    [WinformController(DefaultViewName = "frmLookMessage")]//在菜单上显示
    [WinformView(Name = "frmLookMessage", DllName = "base_businessremind.winform.dll", ViewTypeName = "base_businessremind.winform.ViewForm.frmLookMessage")]//控制器关联的界面
    [WinformView(Name = "frmMessageSubscribe", DllName = "base_businessremind.winform.dll", ViewTypeName = "base_businessremind.winform.ViewForm.frmMessageSubscribe")]//控制器关联的界面
    [WinformView(Name = "frmMessageType", DllName = "base_businessremind.winform.dll", ViewTypeName = "base_businessremind.winform.ViewForm.frmMessageType")]//控制器关联的界面
    public class messageController : WinformController
    {
        IfrmMessageType frmMessageType;
        IfrmLookMessage frmLookMessage;
        IfrmMessageSubscribe frmMessageSubscribe;

        public override void Init()
        {

            frmMessageType = (IfrmMessageType)iBaseView["frmMessageType"];
            frmMessageSubscribe = (IfrmMessageSubscribe)iBaseView["frmMessageSubscribe"];
            frmLookMessage = (IfrmLookMessage)iBaseView["frmLookMessage"];
        }
        [WinformMethod]
        public void LoadMessageTypeData()
        {
            List<BaseMessageType> messagetypeList = NewObject<BaseMessageType>().getlist<BaseMessageType>();
            List<BaseGroup> groupList = NewObject<BaseGroup>().getlist<BaseGroup>();
            DataTable dt = NewObject<Message>().GetLimitTimeType();

            frmMessageType.loadGroupList(groupList);
            frmMessageType.loadLimittimeData(dt);
            frmMessageType.loadMessageTypeGrid(messagetypeList);

        }
        [WinformMethod]
        public void GetCurrMessageType(int Id)
        {
            BaseMessageType type = (BaseMessageType)NewObject<BaseMessageType>().getmodel(Id);
            frmMessageType.currMessageType = type;
        }
        [WinformMethod]
        public void NewMessageType()
        {
            BaseMessageType type = NewObject<BaseMessageType>();
            frmMessageType.currMessageType = type;
        }
        [WinformMethod]
        public void SaveMessageType()
        {
            BaseMessageType type = frmMessageType.currMessageType;
            type.save();

            List<BaseMessageType> messagetypeList = NewObject<BaseMessageType>().getlist<BaseMessageType>();
            frmMessageType.loadMessageTypeGrid(messagetypeList);
        }
        [WinformMethod]
        public void DeleteMessageType(int Id)
        {
            NewObject<BaseMessageType>().delete(Id);
            List<BaseMessageType> messagetypeList = NewObject<BaseMessageType>().getlist<BaseMessageType>();
            frmMessageType.loadMessageTypeGrid(messagetypeList);
        }
        [WinformMethod]
        public void LoadMessageList(int type, DateTime date)
        {
            List<BaseMessage> messageList = null;
            if (type == 0)
            {
                messageList = NewObject<Message>().GetNotReadMessages(LoginUserInfo.UserId, LoginUserInfo.DeptId, LoginUserInfo.WorkId);
            }
            else if (type == 1)
            {
                messageList = NewObject<Message>().GetIsReadMessages(LoginUserInfo.UserId, date);
            }
            else if (type == 2)
            {
                messageList = NewObject<Message>().GetSendMessages(LoginUserInfo.UserId, date);
            }

            frmLookMessage.loadMessageList(messageList);
        }
        [WinformMethod]
        public void SetMessageRead(int[] messageIds)
        {
            foreach (int id in messageIds)
            {
                NewObject<Message>().MessageRead(id, LoginUserInfo.UserId);
            }
        }

        #region 订阅消息
        [WinformMethod]
        public void GetMessageTypeData()
        {
            string strsql = @"SELECT   Id ,Code ,Name ,Limittime ,Memo ,
                                        (CASE WHEN (select COUNT(*) FROM BaseMessageTypeUser WHERE UserId={0} AND MessageTypeId=BaseMessageType.Id)>0 THEN 1 ELSE 0 END) IsUse
                                        FROM BaseMessageType";
            strsql = string.Format(strsql, LoginUserInfo.UserId);
            DataTable dt = oleDb.GetDataTable(strsql);
            frmMessageSubscribe.loadMessageTypeDt(dt);
        }
        [WinformMethod]
        public void GetUserTime(int mstypeId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("colbegin");
            dt.Columns.Add("colend");

            string strsql = @"SELECT TOP 1 ReceiveTime FROM 
                                        BaseMessageTypeUser
                                        WHERE UserId={0} AND MessageTypeId={1}";
            strsql = string.Format(strsql, LoginUserInfo.UserId, mstypeId);
            object val = oleDb.GetDataResult(strsql);
            if (val != null)
            {
                string[] segments = val.ToString().Split(new char[] { '|' });
                for (int i = 0; i < segments.Length; i++)
                {
                    string[] times = segments[i].Split(new char[] { '-' });
                    if (times.Length == 2)
                    {
                        dt.Rows.Add(times[0], times[1]);
                    }
                }
            }

            frmMessageSubscribe.loadTime(dt);
        }

        //订阅
        [WinformMethod]
        public void Subscribe(int mstypeId, DataTable times)
        {
            string time_str = "";
            for (int i = 0; i < times.Rows.Count; i++)
            {
                time_str = time_str + times.Rows[i][0].ToString();
                time_str = time_str + "-";
                time_str = time_str + times.Rows[i][1].ToString();

                if (i < times.Rows.Count - 1)
                    time_str = time_str + "|";
            }

            string strsql = @"delete from BaseMessageTypeUser where MessageTypeId=" + mstypeId;
            oleDb.DoCommand(strsql);

            strsql = @"insert into BaseMessageTypeUser(MessageTypeId,UserId,ReceiveTime) values({0},{1},'{2}')";
            strsql = string.Format(strsql, mstypeId, LoginUserInfo.UserId, time_str);
            oleDb.DoCommand(strsql);

            GetMessageTypeData();
        }
        //取消订阅
        [WinformMethod]
        public void CancelSubscribe(int mstypeId)
        {
            string strsql = @"delete from BaseMessageTypeUser where MessageTypeId=" + mstypeId;
            oleDb.DoCommand(strsql);
            GetMessageTypeData();
        }
        #endregion

    }
}
