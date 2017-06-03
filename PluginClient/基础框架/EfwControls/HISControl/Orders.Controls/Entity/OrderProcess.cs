using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EfwControls.HISControl.Orders.Controls.Entity
{
    public class OrderProcess
    {
        public static IOrderDbHelper OrderDataSource;//数据
        /// <summary>
        /// 获取医嘱
        /// </summary>
        /// <param name="orderStyle"></param>
        /// <param name="patlitist"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public static DataTable GetOrderRecords(int orderStyle, int patlitist, int deptid,bool isShowAllOrder)
        {
            DataTable dtOrder = new DataTable();
            if (isShowAllOrder)
            {
                dtOrder = OrderDataSource.GetOrders(orderStyle, (int)OrderStatus.所有, patlitist, deptid);
            }
            else
            {
                dtOrder = OrderDataSource.GetOrders(orderStyle, (int)OrderStatus.有效医嘱, patlitist, deptid);
            }
            List<OrderRecord> records = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<OrderRecord>(dtOrder).OrderBy(p => p.OrderBdate).ThenBy(p => p.GroupID).ThenBy(p => p.OrderID).ToList();
            DataTable dt = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToDataTable(records);
            if (dt.Rows.Count > 0)
            {
                dt.Rows[0]["ShowOrderBdate"] = dt.Rows[0]["OrderBdate"];
                dt.Rows[0]["ShowDoseNum"] = dt.Rows[0]["DoseNum"];
                dt.Rows[0]["ShowChannel"] = dt.Rows[0]["ChannelName"];
                dt.Rows[0]["ShowFrency"] = dt.Rows[0]["Frequency"];
                dt.Rows[0]["ShowFirstNum"] = dt.Rows[0]["FirstNum"];
                dt.Rows[0]["ShowTeminalNum"] = dt.Rows[0]["TeminalNum"];
                dt.Rows[0]["GroupFlag"] = 1;
                dt.Rows[0]["ModifyFlag"] = 0;
                if (Convert.ToInt32(dt.Rows[0]["OrderStatus"]) <= 2)
                {
                    dt.Rows[0]["EOrderDate"] = DBNull.Value;
                    dt.Rows[0]["ShowTeminalNum"] = DBNull.Value;
                }
                if (Convert.ToInt32(dt.Rows[0]["ExecFlag"]) == 0)
                {
                    dt.Rows[0]["ExecDate"] = DBNull.Value;
                }
                int astFlag = Convert.ToInt32(dt.Rows[0]["AstFlag"]);
                if (astFlag == 3)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "(免试)";
                }
                else if (astFlag == 1)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "(阴性)";
                }
                else if (astFlag == 2)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "(阳性)";
                }
                int ordertype = Convert.ToInt32(dt.Rows[0]["OrderType"]);
                if (ordertype == 1)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "【交病人】";
                }
                else if (ordertype == 2)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "【自备】";
                }
                else if (ordertype == 3)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "【出院带药】";
                }
            }
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(dt.Rows[i + 1]["GroupID"]) != Convert.ToInt32(dt.Rows[i]["GroupID"]))
                {
                    dt.Rows[i + 1]["GroupFlag"] = 1;
                    dt.Rows[i + 1]["ShowOrderBdate"] = dt.Rows[i + 1]["OrderBdate"];
                    dt.Rows[i + 1]["ShowDoseNum"] = dt.Rows[i + 1]["DoseNum"];
                    dt.Rows[i + 1]["ShowChannel"] = dt.Rows[i + 1]["ChannelName"];
                    dt.Rows[i + 1]["ShowFrency"] = dt.Rows[i + 1]["Frequency"];
                    dt.Rows[i + 1]["ShowFirstNum"] = dt.Rows[i + 1]["FirstNum"];
                    dt.Rows[i + 1]["ShowTeminalNum"] = dt.Rows[i + 1]["TeminalNum"];
                    if (Convert.ToInt32(dt.Rows[i + 1]["OrderStatus"]) <= 2)
                    {
                        dt.Rows[i + 1]["EOrderDate"] = DBNull.Value;
                        dt.Rows[i + 1]["ShowTeminalNum"] = DBNull.Value;
                    }
                    if (Convert.ToInt32(dt.Rows[i + 1]["ExecFlag"]) == 0)
                    {
                        dt.Rows[i + 1]["ExecDate"] = DBNull.Value;
                    }
                }
                else
                {
                    dt.Rows[i + 1]["GroupFlag"] = 0;
                    dt.Rows[i + 1]["ShowOrderBdate"] = DBNull.Value;
                    dt.Rows[i + 1]["ShowDoseNum"] = DBNull.Value;
                    dt.Rows[i + 1]["ShowChannel"] = DBNull.Value;
                    dt.Rows[i + 1]["ShowFrency"] = DBNull.Value;
                    dt.Rows[i + 1]["ShowFirstNum"] = DBNull.Value;
                    dt.Rows[i + 1]["ShowTeminalNum"] = DBNull.Value;

                    dt.Rows[i + 1]["OrderDocName"] = DBNull.Value;
                    dt.Rows[i + 1]["ExecNurseName"] = DBNull.Value;
                    dt.Rows[i + 1]["EOrderDocName"] = DBNull.Value;
                    dt.Rows[i + 1]["EOrderDate"] = DBNull.Value;
                    dt.Rows[i + 1]["ExecDate"] = DBNull.Value;
                }
                dt.Rows[i + 1]["ModifyFlag"] = 0;
                int astFlag = Convert.ToInt32(dt.Rows[i + 1]["AstFlag"]);
                if (astFlag == 3)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "(免试)";
                }
                else if (astFlag == 1)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "(阴性)";
                }
                else if (astFlag == 2)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "(阳性)";
                }
                int ordertype = Convert.ToInt32(dt.Rows[i + 1]["OrderType"]);
                if (ordertype == 1)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "【交病人】";
                }
                else if (ordertype == 2)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "【自备】";
                }
                else if (ordertype == 3)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "【出院带药】";
                }
            }
            return dt;
        }

        public static DataTable GetNotStopLongOrders(int orderStyle, int patlitist, int deptid)
        {
            DataTable dtOrder = OrderDataSource.GetOrders(orderStyle, (int)OrderStatus.已经转抄, patlitist, deptid);
            List<OrderRecord> records = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<OrderRecord>(dtOrder).OrderBy(p => p.OrderBdate).ThenBy(p => p.GroupID).ThenBy(p => p.OrderID).ToList();
            DataTable dt = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToDataTable(records);
            if (dt.Rows.Count > 0)
            {
                dt.Rows[0]["ShowOrderBdate"] = dt.Rows[0]["OrderBdate"];
                dt.Rows[0]["ShowDoseNum"] = dt.Rows[0]["DoseNum"];
                dt.Rows[0]["ShowChannel"] = dt.Rows[0]["ChannelName"];
                dt.Rows[0]["ShowFrency"] = dt.Rows[0]["Frequency"];
                dt.Rows[0]["ShowFirstNum"] = dt.Rows[0]["FirstNum"];
                dt.Rows[0]["ShowTeminalNum"] = dt.Rows[0]["TeminalNum"];
                dt.Rows[0]["GroupFlag"] = 1;
                dt.Rows[0]["ModifyFlag"] = 0;
                if (Convert.ToInt32(dt.Rows[0]["OrderStatus"]) <= 2)
                {
                    dt.Rows[0]["EOrderDate"] = DBNull.Value;
                    dt.Rows[0]["ShowTeminalNum"] = DBNull.Value;
                }
                if (Convert.ToInt32(dt.Rows[0]["ExecFlag"]) == 0)
                {
                    dt.Rows[0]["ExecDate"] = DBNull.Value;
                }
                int astFlag = Convert.ToInt32(dt.Rows[0]["AstFlag"]);
                if (astFlag == 3)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "(免试)";
                }
                else if (astFlag == 1)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "(阴性)";
                }
                else if (astFlag == 2)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "(阳性)";
                }
                int ordertype = Convert.ToInt32(dt.Rows[0]["OrderType"]);
                if (ordertype == 1)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "【交病人】";
                }
                else if (ordertype == 2)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "【自备】";
                }
                else if (ordertype == 3)
                {
                    dt.Rows[0]["ItemName"] = dt.Rows[0]["ItemName"] + "【出院带药】";
                }
            }
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(dt.Rows[i + 1]["GroupID"]) != Convert.ToInt32(dt.Rows[i]["GroupID"]))
                {
                    dt.Rows[i + 1]["GroupFlag"] = 1;
                    dt.Rows[i + 1]["ShowOrderBdate"] = dt.Rows[i + 1]["OrderBdate"];
                    dt.Rows[i + 1]["ShowDoseNum"] = dt.Rows[i + 1]["DoseNum"];
                    dt.Rows[i + 1]["ShowChannel"] = dt.Rows[i + 1]["ChannelName"];
                    dt.Rows[i + 1]["ShowFrency"] = dt.Rows[i + 1]["Frequency"];
                    dt.Rows[i + 1]["ShowFirstNum"] = dt.Rows[i + 1]["FirstNum"];
                    dt.Rows[i + 1]["ShowTeminalNum"] = dt.Rows[i + 1]["TeminalNum"];
                    if (Convert.ToInt32(dt.Rows[i + 1]["OrderStatus"]) <= 2)
                    {
                        dt.Rows[i + 1]["EOrderDate"] = DBNull.Value;
                        dt.Rows[i + 1]["ShowTeminalNum"] = DBNull.Value;
                    }
                    
                }
                else
                {
                    dt.Rows[i + 1]["GroupFlag"] = 0;
                    dt.Rows[i + 1]["ShowOrderBdate"] = DBNull.Value;
                    dt.Rows[i + 1]["ShowDoseNum"] = DBNull.Value;
                    dt.Rows[i + 1]["ShowChannel"] = DBNull.Value;
                    dt.Rows[i + 1]["ShowFrency"] = DBNull.Value;
                    dt.Rows[i + 1]["ShowFirstNum"] = DBNull.Value;
                    dt.Rows[i + 1]["ShowTeminalNum"] = DBNull.Value;

                    dt.Rows[i + 1]["OrderDocName"] = DBNull.Value;
                    dt.Rows[i + 1]["ExecNurseName"] = DBNull.Value;
                    dt.Rows[i + 1]["EOrderDocName"] = DBNull.Value;
                    dt.Rows[i + 1]["EOrderDate"] = DBNull.Value;
                    // dt.Rows[i + 1]["ExecDate"] = DBNull.Value; //会导致保存的时候r执行时间变化
                }
                if (Convert.ToInt32(dt.Rows[i + 1]["ExecFlag"]) == 0)
                {
                    dt.Rows[i + 1]["ExecDate"] = DBNull.Value;
                }
                dt.Rows[i + 1]["ModifyFlag"] = 0;
                int astFlag = Convert.ToInt32(dt.Rows[i + 1]["AstFlag"]);
                if (astFlag == 3)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "(免试)";
                }
                else if (astFlag == 1)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "(阴性)";
                }
                else if (astFlag == 2)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "(阳性)";
                }
                int ordertype = Convert.ToInt32(dt.Rows[i + 1]["OrderType"]);
                if (ordertype == 1)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "【交病人】";
                }
                else if (ordertype == 2)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "【自备】";
                }
                else if (ordertype == 3)
                {
                    dt.Rows[i + 1]["ItemName"] = dt.Rows[i + 1]["ItemName"] + "【出院带药】";
                }
            }
            return dt;

        }
    }
}
