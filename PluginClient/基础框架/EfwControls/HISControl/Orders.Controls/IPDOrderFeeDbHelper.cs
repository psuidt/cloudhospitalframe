using EFWCoreLib.WcfFrame.ClientController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EFWCoreLib.WcfFrame.DataSerialize;

namespace EfwControls.HISControl.Orders.Controls
{
    public class IPDOrderFeeDbHelper : WcfClientController, IOrderFeeDbHelper
    {
        /// <summary>
        /// 删除选中医嘱费用数据
        /// </summary>
        /// <param name="GenerateID">选中医嘱费用数据ID</param>
        public void DelFeeItemData(int GenerateID)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(GenerateID);
            });
            ServiceResponseData retdata = InvokeWcfService("IPProject.Service", "DoctorManagementController", "DelFeeItemData", requestAction);
        }

        /// <summary>
        /// 获取弹出网格费用项目列表
        /// </summary>
        /// <returns>弹出网格费用项目列表</returns>
        public DataTable GetDocFeeItemList()
        {
            ServiceResponseData retdata = InvokeWcfService("IPProject.Service", "DoctorManagementController", "GetDocFeeList");
            DataTable FeeItemDt = retdata.GetData<DataTable>(0);
            return FeeItemDt;
        }

        /// <summary>
        /// 加载医嘱关联费用列表
        /// </summary>
        /// <param name="PatListID">病人登记ID</param>
        /// <param name="GroupID">医嘱组号ID</param>
        /// <returns>医嘱关联费用数据列表</returns>
        public DataTable LoadOrderFeeData(int PatListID, int GroupID)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(PatListID);
                request.AddData(GroupID);
            });
            ServiceResponseData retdata = InvokeWcfService("IPProject.Service", "DoctorManagementController", "GetPatDocRelationFeeList", requestAction);
            return retdata.GetData<DataTable>(0);
        }

        /// <summary>
        /// 提示Msg
        /// </summary>
        /// <param name="Msg">消息内容</param>
        public void MessageShow(string Msg)
        {
            MessageBoxShowSimple(Msg);
        }

        /// <summary>
        /// 保存医嘱费用数据
        /// </summary>
        /// <param name="FeeDt">待保存的医嘱费用数据</param>
        /// <param name="PatListID">病人登记ID</param>
        /// <param name="GroupID">医嘱分组ID</param>
        /// <returns>保存成功或失败</returns>
        public bool SaveFeeItemData(DataTable FeeDt, int PatListID, int GroupID)
        {
            // 去空白行
            RemoveEmpty(FeeDt);
            DataRow[] dr = FeeDt.Select("UpdFlg=1");
            if (dr.Length <= 0)
            {
                MessageBoxShowSimple("没有需要保存的费用数据！");
                return false;
            }

            DataRow[] arrayDr = FeeDt.Select("Amount<=0");
            if (arrayDr.Length > 0)
            {
                string msg = string.Empty;
                for (int i = 0; i < arrayDr.Length; i++)
                {
                    msg += "[" + arrayDr[i]["ItemName"] + "]、";
                }
                msg = msg.Substring(0, msg.Length - 1);
                msg += "等项目数量小于或等于0，请输入正确数量！";
                MessageBoxShowSimple(msg);
                return false;
            }

            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(FeeDt);
                request.AddData(PatListID);
                request.AddData(GroupID);
                request.AddData(LoginUserInfo.EmpId);
                request.AddData(LoginUserInfo.DeptId);
            });
            ServiceResponseData retdata = InvokeWcfService("IPProject.Service", "DoctorManagementController", "SaveFeeItemData", requestAction);
            return retdata.GetData<bool>(0);
        }

        /// <summary>
        /// 去除DataTable中的完全空白行
        /// </summary>
        /// <param name="dt"></param>
        private void RemoveEmpty(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsNull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j == 0 || j == 2)
                    {
                        continue;
                    }
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        IsNull = false;
                    }
                }
                if (IsNull)
                {
                    removelist.Add(dt.Rows[i]);
                }
            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
            dt.AcceptChanges();
        }

        /// <summary>
        /// 验证医嘱是否已转抄，已转抄的医嘱不允许补录费用
        /// </summary>
        /// <param name="patListID">病人ID</param>
        /// <param name="groupID">组号ID</param>
        /// <returns>true：已转抄</returns>
        public bool CheckOrderStatus(int patListID, int groupID)
        {
            Action<ClientRequestData> requestAction = ((ClientRequestData request) =>
            {
                request.AddData(patListID);
                request.AddData(groupID);
            });

            ServiceResponseData retdata = InvokeWcfService("IPProject.Service", "DoctorManagementController", "CheckOrderStatus", requestAction);
            return retdata.GetData<bool>(0);
        }
    }
}
