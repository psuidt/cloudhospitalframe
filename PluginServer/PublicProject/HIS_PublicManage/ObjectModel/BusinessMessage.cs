using EFWCoreLib.CoreFrame.Business;
using EFWCoreLib.CoreFrame.Common;
using HIS_Entity.BasicData;
using HIS_Entity.MIManage.Common;
using HIS_PublicManage.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_PublicManage.ObjectModel
{
    /// <summary>
    /// 业务消息处理
    /// </summary>
    public class BusinessMessage : AbstractObjectModel
    {
        /// <summary>
        /// 生成业务消息
        /// </summary>
        /// <param name="msgType">消息类型</param>
        /// <param name="msgDic">消息生成参数</param>
        /// <returns></returns>
        public bool GenerateBizMessage(MessageType msgType, Dictionary<string, string> msgDic)
        {
            // 设置WorkID
            SetWorkId(Tools.ToInt32(msgDic["WorkID"], 0));
            BaseMessage mesage = NewObject<BaseMessage>();
            mesage.SendEmpID = Tools.ToInt32(msgDic["SendUserId"], 0);
            mesage.SendDept = Tools.ToInt32(msgDic["SendDeptId"], 0);
            mesage.SendTime = DateTime.Now;
            bool isCheck = true;
            switch (msgType)
            {
                case MessageType.门诊新处方:
                    // 验证消息类型是否存在或是否被停用
                    isCheck = CheckMsgTypeIsStop("MZCF001", Tools.ToInt32(msgDic["WorkID"], 0), mesage);
                    // 消息类型存在未停用
                    if (isCheck)
                    {
                        // 获取业务消息包含的科室以及病人信息
                        mesage.MessageTitle = string.Format("【{0}药房有新处方】", msgDic["ExecDeptName"]);
                        DataTable patDt = NewDao<IPublicManageDao>().GetOpPatlist(Tools.ToInt32(msgDic["PatListID"], 0));
                        mesage.MessageContent = string.Format("已收到{0}患者(科室：{1},{0}医生)的处方，请及时配药发药！",
                            patDt.Rows[0]["PatName"], patDt.Rows[0]["DeptName"], patDt.Rows[0]["DortorName"]);
                        // 保存Message数据
                        this.BindDb(mesage);
                        mesage.save();
                        // 生成读取记录数据
                        SaveBaseMessageReadData(mesage.MessagetypeID, Tools.ToInt32(msgDic["WorkID"], 0),
                            mesage.Id, Tools.ToInt32(patDt.Rows[0]["CureDeptID"].ToString(), 0));
                    }
                    break;
                case MessageType.住院新医嘱:
                    // 验证消息类型是否存在或是否被停用
                    isCheck = CheckMsgTypeIsStop("ZYYZ001", Tools.ToInt32(msgDic["WorkID"], 0), mesage);
                    // 消息类型存在未停用
                    if (isCheck)
                    {
                        // 获取业务消息包含的科室以及病人信息
                        DataTable patDt = NewDao<IPublicManageDao>().GetPatientInfo(Tools.ToInt32(msgDic["PatListID"], 0));
                        mesage.MessageTitle = string.Format("【{0}有新医嘱】", patDt.Rows[0]["DeptName"]);
                        mesage.MessageContent = string.Format("已收到患者{0}(住院号：{1}/床号：{2})的新医嘱，请及时转抄执行！",
                            patDt.Rows[0]["PatName"], patDt.Rows[0]["SerialNumber"], patDt.Rows[0]["BedNo"]);
                        mesage.ReceivingDept = Tools.ToInt32(patDt.Rows[0]["CurrDeptID"].ToString(), 0); // 接收科室
                        // 保存Message数据
                        this.BindDb(mesage);
                        mesage.save();
                        // 生成读取记录数据
                        SaveBaseMessageReadData(mesage.MessagetypeID, Tools.ToInt32(msgDic["WorkID"], 0),
                            mesage.Id, Tools.ToInt32(patDt.Rows[0]["CurrDeptID"].ToString(), 0));
                    }
                    break;
                case MessageType.药品统领:
                    // 验证消息类型是否存在或是否被停用
                    isCheck = CheckMsgTypeIsStop("YPTL001", Tools.ToInt32(msgDic["WorkID"], 0), mesage);
                    // 消息类型存在未停用
                    if (isCheck)
                    {
                        // 获取业务消息包含的药品统领信息
                        DataTable drugDt = NewDao<IPublicManageDao>().GetDrugBillDetailData(Tools.ToInt32(msgDic["BillHeadID"], 0), MessageType.药品统领);
                        mesage.MessageTitle = string.Format("【{0}有新药单】", drugDt.Rows[0]["ExecDeptName"]);
                        mesage.MessageContent = string.Format("已收到{0}的{1}药单(单号：{2})，请及时处理",
                            drugDt.Rows[0]["PresDeptName"], drugDt.Rows[0]["BillTypeName"], drugDt.Rows[0]["BillHeadID"]);
                        mesage.ReceivingDept = Tools.ToInt32(drugDt.Rows[0]["ExecDeptID"].ToString(), 0); // 接收科室
                        // 保存Message数据
                        this.BindDb(mesage);
                        mesage.save();
                        // 生成读取记录数据
                        SaveBaseMessageReadData(mesage.MessagetypeID, Tools.ToInt32(msgDic["WorkID"], 0),
                            mesage.Id, Tools.ToInt32(drugDt.Rows[0]["ExecDeptID"].ToString(), 0));
                    }
                    break;
                case MessageType.药房缺药:
                    // 验证消息类型是否存在或是否被停用
                    isCheck = CheckMsgTypeIsStop("YFQY001", Tools.ToInt32(msgDic["WorkID"], 0), mesage);
                    // 消息类型存在未停用
                    if (isCheck)
                    {
                        // 获取业务消息包含的药品缺药信息
                        DataTable drugDt = NewDao<IPublicManageDao>().GetDrugBillDetailData(Tools.ToInt32(msgDic["BillDetailID"], 0), MessageType.药房缺药);
                        mesage.MessageTitle = string.Format("【{0}有新缺药】", drugDt.Rows[0]["PresDeptName"]);
                        mesage.MessageContent = string.Format("已收到{0}已缺{1}药(单号：{2})，请及时处理！",
                            drugDt.Rows[0]["ExecDeptName"], drugDt.Rows[0]["ItemName"], drugDt.Rows[0]["BillHeadID"]);
                        mesage.ReceivingDept = Tools.ToInt32(drugDt.Rows[0]["PresDeptID"].ToString(), 0); // 接收科室
                        // 保存Message数据
                        this.BindDb(mesage);
                        mesage.save();
                        // 生成读取记录数据
                        SaveBaseMessageReadData(mesage.MessagetypeID, Tools.ToInt32(msgDic["WorkID"], 0),
                            mesage.Id, Tools.ToInt32(drugDt.Rows[0]["PresDeptID"].ToString(), 0));
                    }
                    break;
                case MessageType.护理级别:
                    // 验证消息类型是否存在或是否被停用
                    isCheck = CheckMsgTypeIsStop("HLJB001", Tools.ToInt32(msgDic["WorkID"], 0), mesage);
                    // 消息类型存在未停用
                    if (isCheck)
                    {
                        // 获取业务消息包含的科室以及病人信息
                        DataTable patDt = NewDao<IPublicManageDao>().GetPatientInfo(Tools.ToInt32(msgDic["PatListID"], 0));
                        mesage.MessageTitle = string.Format("【{0}病人护理级别变更】", patDt.Rows[0]["PatName"]);
                        mesage.MessageContent = string.Format("已收到{0}患者{1}(住院号：{2}/床号：{3})变更了护理基本，请及时处理",
                            patDt.Rows[0]["DeptName"], patDt.Rows[0]["PatName"], patDt.Rows[0]["SerialNumber"], patDt.Rows[0]["BedNo"]);
                        mesage.ReceivingDept = Tools.ToInt32(patDt.Rows[0]["CurrDeptID"].ToString(), 0); // 接收科室
                        // 保存Message数据
                        this.BindDb(mesage);
                        mesage.save();
                        // 生成读取记录数据
                        SaveBaseMessageReadData(mesage.MessagetypeID, Tools.ToInt32(msgDic["WorkID"], 0),
                            mesage.Id, Tools.ToInt32(patDt.Rows[0]["CurrDeptID"].ToString(), 0));
                    }
                    break;
                case MessageType.病人新入院:
                    // 验证消息类型是否存在或是否被停用
                    isCheck = CheckMsgTypeIsStop("BRXRY001", Tools.ToInt32(msgDic["WorkID"], 0), mesage);
                    // 消息类型存在未停用
                    if (isCheck)
                    {
                        // 获取业务消息包含的科室以及病人信息
                        DataTable patDt = NewDao<IPublicManageDao>().GetPatientInfo(Tools.ToInt32(msgDic["PatListID"], 0));
                        mesage.MessageTitle = string.Format("【{0}有新病人】", patDt.Rows[0]["DeptName"]);
                        mesage.MessageContent = string.Format("已收到{0}新入院患者{1}(住院号：{2})，请及时分配床位！",
                            patDt.Rows[0]["DeptName"], patDt.Rows[0]["PatName"], patDt.Rows[0]["SerialNumber"]);
                        mesage.ReceivingDept = Tools.ToInt32(patDt.Rows[0]["CurrDeptID"].ToString(), 0); // 接收科室
                        // 保存Message数据
                        this.BindDb(mesage);
                        mesage.save();
                        // 生成读取记录数据
                        SaveBaseMessageReadData(mesage.MessagetypeID, Tools.ToInt32(msgDic["WorkID"], 0),
                            mesage.Id, Tools.ToInt32(patDt.Rows[0]["CurrDeptID"].ToString(), 0));
                    }
                    break;
            }
            return true;
        }

        /// <summary>
        /// 生成业务消息读取记录数据
        /// </summary>
        /// <param name="messageTypeId">消息类型ID</param>
        /// <param name="workID">机构ID</param>
        /// <param name="messageId">消息ID</param>
        /// <param name="receivingDept">接收科室ID</param>
        private void SaveBaseMessageReadData(int messageTypeId, int workID, int messageId, int receivingDept)
        {
            // 生成读取记录数据
            // 获取业务消息订阅数据
            List<BaseMessageTypeUser> messageReadList =
                NewObject<BaseMessageTypeUser>().getlist<BaseMessageTypeUser>("MessageTypeId=" + messageTypeId + " AND WorkID=" + workID);
            if (messageReadList.Count > 0)
            {
                foreach (BaseMessageTypeUser mtu in messageReadList)
                {
                    // 判断用户是否关联了科室
                    List<BaseEmpDept> baseEmpDeptList =
                        NewObject<BaseEmpDept>().getlist<BaseEmpDept>(string.Format("EmpId = {0} AND DeptId= {1}", mtu.EmpId, receivingDept));
                    if (baseEmpDeptList.Count > 0)
                    {
                        BaseMessageRead messageRead = NewObject<BaseMessageRead>();
                        messageRead.MessageId = messageId;
                        messageRead.EmpId = mtu.EmpId;
                        messageRead.SendTime = DateTime.Now;
                        messageRead.ReadTime = DateTime.Now;
                        messageRead.IsRead = 0;
                        this.BindDb(messageRead);
                        messageRead.save();
                    }
                }
            }
        }

        /// <summary>
        /// 验证消息类型是否存在或是否被停用
        /// </summary>
        /// <param name="msgCode">消息代码</param>
        /// <param name="workId">机构ID</param>
        /// <param name="mesage">消息内容</param>
        /// <returns>true：存在未停用/false：不存在或被停用</returns>
        private bool CheckMsgTypeIsStop(string msgCode, int workId, BaseMessage mesage)
        {
            // 验证消息类型是否被停用
            DataTable msgDt = NewDao<IPublicManageDao>().GetMsgType(msgCode, workId);
            if (msgDt != null && msgDt.Rows.Count > 0)
            {
                if (Tools.ToInt32(msgDt.Rows[0]["Status"].ToString(), 0) == 0)
                {
                    mesage.MessagetypeID = Tools.ToInt32(msgDt.Rows[0]["Id"].ToString(), 0);
                    mesage.MessageTypeCode = msgDt.Rows[0]["Code"].ToString();
                    mesage.Limittime = Tools.ToInt32(msgDt.Rows[0]["Limittime"].ToString(), 0);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 按角色一键订阅业务消息
        /// </summary>
        /// <param name="messageTypeUserDt">订阅数据列表</param>
        /// <param name="megTypeId">消息类型ID</param>
        /// <returns></returns>
        public bool OneKeySubscribeMsg(DataTable messageTypeUserDt,int megTypeId)
        {
            if (messageTypeUserDt != null && messageTypeUserDt.Rows.Count > 0)
            {
                for (int i = 0; i < messageTypeUserDt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(messageTypeUserDt.Rows[i]["CheckFlag"]) == 1)
                    {
                        // 订阅消息
                        BaseMessageTypeUser msgTypeUser = NewObject<BaseMessageTypeUser>();
                        msgTypeUser.EmpId = Convert.ToInt32(messageTypeUserDt.Rows[i]["EmpID"]);
                        msgTypeUser.MessageTypeId = megTypeId;
                        msgTypeUser.ReceiveTime = DateTime.Now;
                        this.BindDb(msgTypeUser);
                        msgTypeUser.save();
                    }
                    else
                    {
                        // 取消订阅
                        NewDao<IPublicManageDao>().CancelOneKeySubscribeMsg(megTypeId, Convert.ToInt32(messageTypeUserDt.Rows[i]["EmpID"]));
                    }
                }
            }
            return true;
        }

    }

    public enum MessageType
    {
        门诊新处方, 住院新医嘱, 药品统领, 药房缺药, 护理级别, 病人新入院
    }
}
