using EfwControls.HISControl.Orders.Controls.IView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EfwControls.HISControl.Orders.Controls.Entity;
using EFWCoreLib.CoreFrame.Common;
using System.Windows.Forms;

namespace EfwControls.HISControl.Orders.Controls.Controller
{
    public class OrdersControlController
    {
        private IOrdersControlView iview;
        public IOrderDbHelper OrderDataSource;//数据
        public DataSet CardDataSource;
        private DataTable dtItemDrug;
        private DataTable dtShowCard = new DataTable();
        public OrdersControlController(IOrdersControlView _view)
        {
            iview = _view;
        }
        #region 选项卡数据源
        //加载选项卡数据源
        public void BindCardDataSource(IOrderDbHelper dbHelper)
        {
            OrderDataSource = dbHelper;
            CardDataSource = new DataSet();
            int type = (int)iview.OrderStyle;
            Entity.OrderProcess.OrderDataSource = dbHelper;

            CardDataSource = OrderDataSource.OrderDataInit(type, 1, 10, "");
            dtItemDrug = CardDataSource.Tables["itemdrug"];

            if (!CardDataSource.Tables.Contains("unitdic"))
            {
                List<CardDataSourceUnit> unit = new List<Entity.CardDataSourceUnit>();
                DataTable dt5 = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToDataTable(unit);
                dt5.TableName = "unitdic";
                CardDataSource.Tables.Add(dt5);
            }           
        }
        /// <summary>
        /// 刷新选项卡数据源
        /// </summary>
        public void RefreshOrderShowCard(string yfIds, bool isGetAgain)
        {
            int type = (int)iview.OrderStyle;
            if (isGetAgain)//从数据库获取刷新
            {
                DataTable dt1 = OrderDataSource.GetDrugItem(type, 1, 10, "");// EFWCoreLib.CoreFrame.Common.ConvertExtend.ToDataTable(OrderDataSource.GetDrugItem(type, 1, 10, ""));
                dtItemDrug = dt1;
            }
            if (yfIds != "-1")
            {
                if(dtItemDrug==null)
                {
                    return;
                }
                dtShowCard = dtItemDrug.Clone();
                dtShowCard.Clear();
                DataRow[] dr = dtItemDrug.Select(" itemclass=1 and ExecDeptId in ( " + yfIds + ")");
                DataRow[] drItem = dtItemDrug.Select(" itemclass <>1");
                for (int i = 0; i < dr.Length; i++)
                {
                    dtShowCard.Rows.Add(dr[i].ItemArray);
                }
                for (int i = 0; i < drItem.Length; i++)
                {
                    dtShowCard.Rows.Add(drItem[i].ItemArray);
                }
                 iview.ShowCardItemDrugSet(dtShowCard);                
            }
            else
            {
                if (dtItemDrug == null)
                {
                    return;
                }
                iview.ShowCardItemDrugSet(dtItemDrug);
                dtShowCard = dtItemDrug.Copy();
            }            
        }
        public void GetRefreshEntrust()
        {
            DataTable dt1 = OrderDataSource.GetRefreshEntrust();
            iview.ShowCardEntrustSet(dt1);
        }
        /// <summary>
        ///新增一行时修改药品项目的选项卡数据源
        /// </summary>
        /// <param name="statid"></param>
        public void ShowCardItemDrugChange(int statid, int itemtype, string itemid, bool isGroupNew)
        {
            if (isGroupNew)
            {
                iview.ShowCardItemDrugSet(dtShowCard);
            }
            else
            {
                DataTable dtCopy = dtShowCard.Clone();
                dtCopy.Clear();
                DataRow[] rows;
                if (statid == 100 || statid == 101)
                {
                    rows = dtShowCard.Select(" statid in(100,101) and itemid not in " + itemid + "", "");
                }
                else if (statid == 102)
                {
                    rows = dtShowCard.Select(" statid =102 and itemid not in" + itemid + "", "");
                }
                else
                {
                    rows = dtShowCard.Select(" itemclass=" + itemtype + " and itemid not in" + itemid + " ");
                }
                foreach (DataRow dr in rows)
                {
                    dtCopy.Rows.Add(dr.ItemArray);
                }
                iview.ShowCardItemDrugSet(dtCopy);
            }
        }
        private string FindBeginEnd(int nrow, DataTable myTb)
        {
            string strItemids = "";
            if (myTb.Rows.Count > 0)
            {
                int groupid = Convert.ToInt32(myTb.Rows[nrow]["GroupID"] == DBNull.Value ? -1 : myTb.Rows[nrow]["GroupID"]);
                int i = 0;
                int beginNum = nrow;
                int endNum = nrow;
                for (i = nrow+1; i < myTb.Rows.Count - 1; i++)
                {
                    if (i + 1 == myTb.Rows.Count)
                    {
                        endNum = i;
                        break;
                    }
                    if (myTb.Rows[i + 1]["GroupID"].ToString() == groupid.ToString() && Convert.ToInt32(myTb.Rows[i + 1]["GroupFlag"]) == 0)
                    {
                        endNum = i + 1;
                    }
                    else break;
                }
                for (i = nrow; i >= 0; i--)
                {              
                    if (myTb.Rows[i]["GroupID"].ToString() == groupid.ToString() && Convert.ToInt32(myTb.Rows[i]["GroupFlag"]) == 1)
                    {
                        beginNum = i;
                        break;
                    }
                    
                }
                strItemids ="("+ myTb.Rows[beginNum]["ItemID"].ToString();
                for (int index = beginNum+1; index <= endNum; index++)
                {
                    strItemids +=","+ myTb.Rows[index]["ItemID"].ToString();
                }
                strItemids += ")";
            }
            return strItemids;
        }
        //获取药品明细信息
        public DataRow GetDrugDetail(int itemid)
        {
            if (dtItemDrug == null)
            {
                return null;
            }
            DataRow[] dr = dtItemDrug.Select("itemid=" + itemid + "");
            if (dr != null && dr.Length > 0)
            {
                return dr[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 根据病人状态判断是否可以修改医嘱
        /// </summary>
        /// <returns></returns>
        public bool CanEditOrder()
        {
            if (iview.IsLeaveHosOrder == 0  && !iview.HasNotFinishTrans)
            {
                return true;
            }
            else
            {
                iview.ShowMessage("该病人已经出院或者转科，不能操作医嘱");
                return false;
            }
        }
        /// <summary>
        /// 设置网格只读
        /// </summary>
        /// <param name="RowIndex"></param>
        public void SetReadOnly(int RowIndex)
        {
            try
            {
                DataTable tbPresc = iview.GetGridOrder;
                if (RowIndex >= tbPresc.Rows.Count)
                    return;
                //if (!CanEditOrder())
                //{
                //    iview.SetReadOnly(ReadOnlyType.全部只读);
                //}
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["OrderStatus"]) > (int)OrderStatus.医生发送)
                {
                    iview.SetReadOnly(ReadOnlyType.不能修改);
                    return;
                }
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["ModifyFlag"]) == 0)
                {
                    iview.SetReadOnly(ReadOnlyType.不能修改);
                    return;
                }
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["OrderStatus"])!=-1 &&  Convert.ToInt32(tbPresc.Rows[RowIndex]["ModifyFlag"]) == 1 && Convert.ToInt32(tbPresc.Rows[RowIndex]["AstFlag"]) == 0 && Convert.ToInt32(tbPresc.Rows[RowIndex]["AstOrderID"]) == 0)
                {
                    iview.SetReadOnly(ReadOnlyType.皮试医嘱);
                    return;
                }
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["ModifyFlag"]) == 1 && Convert.ToInt32(tbPresc.Rows[RowIndex]["AstOrderID"]) > 0)
                {
                    iview.SetReadOnly(ReadOnlyType.皮试生成医嘱);
                    return;
                }
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["ModifyFlag"]) == 1 && tbPresc.Rows[RowIndex]["Memo"].ToString().Trim()== "PsDrug")
                {
                    iview.SetReadOnly(ReadOnlyType.皮试生成医嘱);
                    return;
                }
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["ModifyFlag"]) == 1 && Convert.ToInt32(tbPresc.Rows[RowIndex]["OrderType"]) == (int)OrderType.出院带药医嘱)
                {
                    iview.SetReadOnly(ReadOnlyType.出院带药);
                    return;
                }
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["ModifyFlag"]) == 1 && Convert.ToInt32(tbPresc.Rows[RowIndex]["OrderType"]) == (int)OrderType.交病人医嘱)
                {
                    iview.SetReadOnly(ReadOnlyType.出院带药);
                    return;
                }
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["OrderStatus"]) != -1 && Convert.ToInt32(tbPresc.Rows[RowIndex]["OrderStatus"]) < (int)OrderStatus.医生发送)
                {
                    if (Convert.ToInt32(tbPresc.Rows[RowIndex]["ModifyFlag"]) == 0)
                    {
                        iview.SetReadOnly(ReadOnlyType.不能修改);
                    }
                }
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["ItemID"]) == 0 && Convert.ToInt32(tbPresc.Rows[RowIndex]["GroupFlag"]) == 1)
                {
                    iview.SetReadOnly(ReadOnlyType.新开);
                    return;
                }
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["ItemID"]) < 0 && Convert.ToInt32(tbPresc.Rows[RowIndex]["GroupFlag"]) == 1)
                {
                    iview.SetReadOnly(ReadOnlyType.自由录入);
                    return;
                }
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["ModifyFlag"]) == 1 && Convert.ToInt32(tbPresc.Rows[RowIndex]["GroupFlag"]) == 0)
                {
                    iview.SetReadOnly(ReadOnlyType.同组增加);
                    return;
                }
                if (Convert.ToInt32(tbPresc.Rows[RowIndex]["ModifyFlag"]) == 1 && Convert.ToInt32(tbPresc.Rows[RowIndex]["ItemID"]) != 0 && Convert.ToInt32(tbPresc.Rows[RowIndex]["GroupFlag"]) == 1)
                {
                    int statid = Convert.ToInt32(tbPresc.Rows[RowIndex]["statid"]);
                    if (statid != 100 && statid != 101 && statid != 102)
                    {
                        iview.SetReadOnly(ReadOnlyType.项目);
                        return;
                    }
                    if (statid == 102)
                    {
                        iview.SetReadOnly(ReadOnlyType.中草药);
                        return;
                    }
                    else
                    {
                        iview.SetReadOnly(ReadOnlyType.药品非中草药);
                        return;
                    }
                }
            }
            catch
            {
                iview.SetReadOnly(ReadOnlyType.新开);
                return;
            }
        }
        /// <summary>
        /// 根据剂量计算药品数量
        /// </summary>
        /// <param name="rowIndex"></param>
        public void CaculateTempOrderAmout(int rowIndex)
        {
            DataTable dt = iview.GetGridOrder;
            dt.Rows[rowIndex]["Amount"] = Math.Ceiling(Convert.ToDecimal(dt.Rows[rowIndex]["Dosage"]) / Convert.ToDecimal(dt.Rows[rowIndex]["Factor"]));
        }
        #region 一组医嘱用法，频率自动改变
        /// <summary>
        /// 当改变一组中第一个的频率，用法时这组的医嘱自动改变
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowindex"></param>
        /// <param name="colname"></param>
        public void ChangeValue(DataTable dt, int rowindex, string colname)
        {
            for (int i = rowindex + 1; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["GroupFlag"].ToString().Trim() == "0")
                {
                    dt.Rows[i]["OrderBdate"] = dt.Rows[rowindex]["OrderBdate"];
                    dt.Rows[i]["ChannelID"] = dt.Rows[rowindex]["ChannelID"];
                    dt.Rows[i]["ChannelName"] = dt.Rows[rowindex]["ChannelName"];
                    dt.Rows[i]["Frequency"] = dt.Rows[rowindex]["Frequency"];
                    dt.Rows[i]["FrenquencyID"] = dt.Rows[rowindex]["FrenquencyID"];
                    dt.Rows[i]["FirstNum"] = dt.Rows[rowindex]["FirstNum"];
                    dt.Rows[i]["DoseNum"] = dt.Rows[rowindex]["DoseNum"];
                    if (dt.Rows[i]["OrderStatus"].ToString().Trim() != "-1")
                    {
                        dt.Rows[i]["ModifyFlag"] = 1;
                    }
                }
                if (dt.Rows[i]["GroupFlag"].ToString().Trim() == "1")
                {
                    break;
                }
            }
        }
        #endregion

        /// <summary>
        /// 设置修改状态
        /// </summary>
        /// <param name="rowIndex"></param>
        public void SetOrderModifyStatus(int rowIndex)
        {
            DataTable tbPresc = iview.GetGridOrder;
            if (tbPresc.Rows.Count == 0)
                return;
            tbPresc.Rows[rowIndex]["ModifyFlag"] = (short)1;
            
            //if (Convert.ToInt32(tbPresc.Rows[rowIndex]["ItemType"]) == 1)
            //{
            //    GetUnit(Convert.ToInt32(tbPresc.Rows[rowIndex]["ItemId"]));
            //}
            iview.SetGridColor();
        }
        #endregion

        #region 网格事件
        /// <summary>
        /// 插入空行
        /// </summary>
        /// <param name="destRowIndex">插入处</param>
        /// <param name="type">0新开 1回车插入</param>
        public void AddEmptyRow(int destRowIndex, int type)
        {
            DataTable tbPresc = iview.GetGridOrder;
            DataRow dr = tbPresc.NewRow();
            if (type == 0)//新开时设置组头标记
            {
                dr["ShowOrderBdate"] = DateTime.Now;
                dr["OrderBdate"] = dr["ShowOrderBdate"];
                dr["GroupFlag"] = 1;               
                dr["ShowDoseNum"] = 1;
                dr["OrderStatus"] = (int)OrderStatus.医生新开;
                dr["GroupID"] = 0;
            }
            else
            {
                dr["ShowOrderBdate"] = DBNull.Value;
                dr["ShowDoseNum"] = DBNull.Value;
                dr["GroupFlag"] = 0;
            }           
            dr["ItemID"] = 0;//初始化为0
            dr["ItemName"] = "";
            dr["ShowChannel"] = "";
            dr["ShowFrency"] = "";
            dr["ChannelID"] = 0;
            dr["FrenquencyID"] = 0;
            dr["Dosage"] = 0;
            dr["Amount"] = 0;
            dr["ModifyFlag"] = 1;           
            dr["OrderCategory"] = (int)iview.OrderStyle;
            dr["PatListID"] = iview.CurrPatListId;
            dr["PresDeptID"] = iview.PresDeptId;
            dr["OrderDoc"] = iview.PresDoctorId;
            dr["OrderType"] = 0;
            dr["AstFlag"] = -1;
            dr["AstOrderID"] = 0;
            dr["Memo"] = "";
            dr["Factor"] = 1;
            dr["ItemType"] = 0;
            dr["StatID"] = 0;
            tbPresc.Rows.InsertAt(dr, destRowIndex);
            if (type == 1)//按回车增加行时，药品根据类型过滤，同组药品不能输入相同药品
            {
                string itemids = FindBeginEnd(destRowIndex-1, tbPresc);              
                int statid = Convert.ToInt32(tbPresc.Rows[destRowIndex - 1]["StatId"]);
                int itemtype = Convert.ToInt32(tbPresc.Rows[destRowIndex - 1]["ItemType"]);
                dr["GroupID"] = Convert.ToInt32(tbPresc.Rows[destRowIndex - 1]["GroupID"]);
                dr["OrderBdate"] = Convert.ToDateTime(tbPresc.Rows[destRowIndex - 1]["OrderBdate"]);
                dr["OrderStatus"] = Convert.ToInt32(tbPresc.Rows[destRowIndex - 1]["OrderStatus"]);
                if (Convert.ToInt32(tbPresc.Rows[destRowIndex - 1]["OrderType"]) != (int)OrderType.自备医嘱)
                {
                    dr["OrderType"] = Convert.ToInt32(tbPresc.Rows[destRowIndex - 1]["OrderType"]);
                }
                ShowCardItemDrugChange(statid, itemtype, itemids, false);
            }
            else
            {
                ShowCardItemDrugChange(0, 0, "0", true);
            }
        }
        /// <summary>
        /// 选项卡数据选择赋值
        /// </summary>
        /// <param name="rowid"></param>
        /// <param name="selectedRow"></param>
        /// <param name="columnName"></param>
        public void SelectCardBindData(int rowid, DataRow selectedRow, string columnName,ref bool result)
        {
             result = true;
            DataTable dt = null;
            dt = iview.GetGridOrder;         
            switch (columnName)
            {
                case "ItemName":
                    if (rowid>0 && dt.Rows[rowid]["ShowOrderBdate"] == DBNull.Value)
                    {
                        string itemids = FindBeginEnd(rowid-1, dt);
                        string selid = selectedRow["ItemId"].ToString().Trim();
                        if (itemids.Contains(selid))
                        {
                            iview.ShowMessage("这一组已经有" + selectedRow["ItemName"] + "药品，请重新选择");
                            iview.SetGridCurrentCell(rowid, "ItemName");
                            result= false;
                            break;                           
                        }
                    }
                    if (Convert.ToInt32(selectedRow["ItemClass"]) == 1 && Convert.ToDecimal(selectedRow["StoreAmount"]) <= 0)
                    {
                        iview.ShowMessage("" + selectedRow["ItemName"] + "库存为0");
                        iview.SetGridCurrentCell(rowid, "ItemName");
                        result = false;
                        break;
                    }
                    if (Convert.ToInt32(selectedRow["SkinTestFlag"]) == 1)//需要皮试
                    {
                        if (MessageBox.Show("该药品是需要皮试的药品，你要开‘皮试’医嘱吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {     
                            dt.Rows[rowid]["AstFlag"] = 0;
                            dt.Rows[rowid]["ItemName"] = selectedRow["ItemName"];
                        }
                        else
                        {
                            dt.Rows[rowid]["ItemName"] = selectedRow["ItemName"].ToString().Trim() + "(免试)";
                            dt.Rows[rowid]["AstFlag"] = 3;
                        }
                    }
                    else
                    {
                        dt.Rows[rowid]["AstFlag"] = -1;
                        dt.Rows[rowid]["AstOrderID"] = 0;
                        dt.Rows[rowid]["ItemName"] = selectedRow["ItemName"];
                    }
                    dt.Rows[rowid]["ItemID"] = selectedRow["ItemId"];
                    dt.Rows[rowid]["ItemPrice"] = selectedRow["SellPrice"];
                    dt.Rows[rowid]["ItemType"] = selectedRow["ItemClass"];
                    dt.Rows[rowid]["StatID"] = selectedRow["StatID"];
                    dt.Rows[rowid]["Spec"] = selectedRow["Standard"];
                    if (Convert.ToInt32(selectedRow["ExecDeptId"]) == 0)//执行科室为0的，默认为本科室
                    {
                        dt.Rows[rowid]["ExecDeptID"] = iview.PresDeptId;
                        dt.Rows[rowid]["ExecDeptName"] = iview.PresDeptName;
                    }
                    else
                    {
                        dt.Rows[rowid]["ExecDeptID"] = selectedRow["ExecDeptId"];
                        dt.Rows[rowid]["ExecDeptName"] = selectedRow["ExecDeptName"];
                    }
                    dt.Rows[rowid]["DosageUnit"] = selectedRow["DoseUnitName"];
                    dt.Rows[rowid]["Factor"] = selectedRow["DoseConvertNum"];
                    dt.Rows[rowid]["Unit"] = selectedRow["MiniUnitName"];
                    dt.Rows[rowid]["UnitNO"] = 1;
                    if (Convert.ToInt32(selectedRow["ItemClass"]) == 5)
                    {
                        dt.Rows[rowid]["OrderType"] = 4;
                    }
                    if (Convert.ToInt32(selectedRow["ItemClass"]) == 1)
                    {
                        if (Convert.ToInt32(selectedRow["StatID"]) == 100 || Convert.ToInt32(selectedRow["StatID"]) == 101 || Convert.ToInt32(selectedRow["StatID"]) == 102)
                        {
                            dt.Rows[rowid]["Dosage"] = 0;
                            dt.Rows[rowid]["Amount"] = 0;
                        }
                    }
                    else
                    {
                        dt.Rows[rowid]["Dosage"] = 1;
                        dt.Rows[rowid]["Amount"] = 1;
                    }
                    break;
                case "Entrust":
                    dt.Rows[rowid]["Entrust"] = selectedRow["NAME"].ToString();
                    break;
                case "ShowChannel":
                    dt.Rows[rowid]["ChannelID"] = selectedRow["UsageId"];
                    dt.Rows[rowid]["ChannelName"] = selectedRow["UsageName"];
                    if (Convert.ToInt32(dt.Rows[rowid]["GroupFlag"]) == 1)
                    {
                        dt.Rows[rowid]["ShowChannel"] = selectedRow["UsageName"];
                        this.ChangeValue(dt, rowid, "ShowChannel");//如果是第一组的每一项，则改变值的同时，这一组的同时改变
                    }
                    break;
                case "ShowFrency":
                    dt.Rows[rowid]["Frequency"] = selectedRow["Name"];
                    dt.Rows[rowid]["FrenquencyID"] = selectedRow["FrequencyId"];
                    if (iview.OrderStyle == OrderCategory.长期医嘱)//算出首次
                    {
                        dt.Rows[rowid]["ShowFirstNum"] = OrderDataSource.GetExecCount(0, Convert.ToInt32(selectedRow["FrequencyId"]),Convert.ToDateTime( dt.Rows[rowid]["ShowOrderBdate"]));
                    }
                    if (Convert.ToInt32(dt.Rows[rowid]["GroupFlag"]) == 1) //如果是第一组的每一项，则改变值的同时，这一组的同时改变
                    {
                        dt.Rows[rowid]["ShowFrency"] = selectedRow["Name"];
                        this.ChangeValue(dt, rowid, "ShowFrency");
                    }                   
                    break;
                default: break;
            }
            if (iview.OrderStyle == OrderCategory.临时医嘱 && columnName == "Unit") //只有临嘱里边可以修改单位
            {
                dt.Rows[rowid]["Unit"] = selectedRow["UnitName"];
                dt.Rows[rowid]["UnitNO"] = selectedRow["UnitNO"];
            }
            iview.LoadGridOrderData(dt);     
        }

        #region 增加皮试医嘱
        /// <summary>
        /// 增加皮试医嘱 
        /// </summary>
        /// <param name="itemtype"></param>
        /// <param name="itemname"></param>
        /// <param name="strDate"></param>
        /// <param name="ordertype"></param>
        /// <param name="rowid"></param>
        private int InsertPSYZ(DataRow row, decimal strDate, int rowid)
        {
            try
            {
                int rowindex = rowid;
                List<OrderRecord> data = new List<Entity.OrderRecord>();
                OrderRecord record = new OrderRecord();
                record.ItemID = Convert.ToInt32(row["itemid"]);
                record.ItemName = row["itemname"].ToString();
                record.ShowChannel = "皮试";
                record.ChannelName = "皮试";
                record.ChannelID = 34;
                record.FrenquencyID = 22;
                record.ShowFrency = "q.d.";
                record.Frequency = "q.d.";
                record.Amount = 1;
                record.Unit = row["MiniUnitName"].ToString();
                record.UnitNO = 1;
                record.StatID = Convert.ToInt32(row["StatID"]);
                record.DoseNum = 1;
                record.ShowDoseNum = 1;
                record.ShowOrderBdate = DateTime.Now;
                record.OrderBdate = record.ShowOrderBdate;
                record.OrderCategory = (int)OrderCategory.临时医嘱;
                record.OrderType = 0;
                record.GroupFlag = 1;
                record.Dosage = 1;
                record.AstOrderID = strDate;
                record.Factor = Convert.ToDecimal(row["DoseConvertNum"]);
                record.ItemType = Convert.ToInt32(row["ItemClass"]);
                record.ExecDeptID = Convert.ToInt32(row["ExecDeptId"]);
                record.AstFlag = -1;
                record.ModifyFlag = 1;
                record.ItemPrice = Convert.ToDecimal(row["SellPrice"]);
                record.OrderStatus = (int)OrderStatus.医生新开;
                record.PatListID = iview.CurrPatListId;
                record.PresDeptID = iview.PresDeptId;
                record.OrderDoc = iview.PresDoctorId;

                data.Add(record);
                int actDrugid = OrderDataSource.GetActDrugID();
                if (actDrugid != 0)
                {

                    DataRow[] rows = dtShowCard.Select("ItemID=" + actDrugid + "");
                    if (rows.Length <= 0)
                    {
                        rows = dtItemDrug.Select("ItemID=" + actDrugid + "");
                    }
                    if (rows.Length > 0)
                    {
                        OrderRecord recordDrug = new OrderRecord();
                        recordDrug.ItemID = Convert.ToInt32(rows[0]["itemid"]);
                        recordDrug.ItemName = rows[0]["itemname"].ToString();
                        recordDrug.ChannelName = "皮试";
                        recordDrug.ChannelID = 34;
                        recordDrug.FrenquencyID = 22;
                        recordDrug.OrderBdate = record.OrderBdate;
                        recordDrug.Frequency = record.Frequency;
                        recordDrug.Amount = 1;
                        recordDrug.Unit = rows[0]["MiniUnitName"].ToString();
                        recordDrug.UnitNO = 1;
                        recordDrug.StatID = Convert.ToInt32(rows[0]["StatID"]);
                        recordDrug.DoseNum = 1;
                        recordDrug.ShowDoseNum = 1;
                        recordDrug.OrderStatus = -1;
                        recordDrug.OrderCategory = 1;
                        recordDrug.OrderType = 0;
                        recordDrug.GroupFlag = 0;
                        recordDrug.Dosage = 1;
                        recordDrug.AstOrderID = 0;
                        recordDrug.Factor = Convert.ToDecimal(rows[0]["DoseConvertNum"]);
                        recordDrug.ItemType = Convert.ToInt32(rows[0]["ItemClass"]);
                        recordDrug.ExecDeptID = Convert.ToInt32(rows[0]["ExecDeptId"]);
                        recordDrug.ModifyFlag = 1;
                        recordDrug.AstFlag = -1;
                        recordDrug.ItemPrice = Convert.ToDecimal(rows[0]["SellPrice"]);

                        recordDrug.PatListID = iview.CurrPatListId;
                        recordDrug.PresDeptID = iview.PresDeptId;
                        recordDrug.OrderDoc = iview.PresDoctorId;
                        data.Add(recordDrug);
                    }
                    else
                    {
                        iview.ShowMessage("皮试药品不存在");
                        return -1;
                    }
                }
                if (iview.OrderStyle == OrderCategory.长期医嘱)
                {
                    iview.SaveAstoflinkage(data);
                    return rowid;
                }
                else
                {
                    DataTable orderData = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToDataTable(data);

                    DataTable tb = iview.GetGridOrder;
                    DataRow row1 = tb.NewRow();
                    row1.ItemArray = orderData.Rows[0].ItemArray;
                    row1["ExecDate"] = DBNull.Value;
                    DataRow row2 = tb.NewRow();
                    row2.ItemArray = orderData.Rows[1].ItemArray;
                    row2["ExecDate"] = DBNull.Value;
                    row2["ShowOrderBdate"] = DBNull.Value;
                    while (rowid >= 0)
                    {
                        if (tb.Rows[rowid]["ShowOrderBdate"] != DBNull.Value)
                        {
                            tb.Rows.InsertAt(row1, rowid); //在临嘱时，插入该医嘱上一行
                            tb.Rows.InsertAt(row2, rowid + 1);
                            return rowindex + 2;
                        }
                        rowid--;
                    }
                }
                return rowid;
            }
            catch (Exception err)
            {
                iview.ShowMessage(err.Message);
                return -1;
            }
        }
        #endregion

        /// <summary>
        /// 根据药品ID动态获取单位数据源
        /// </summary>
        /// <param name="itemid"></param>
        public void GetUnit(int itemid)
        {
            CardDataSource.Tables["unitdic"].Clear();
           
            DataRow[] dr = dtItemDrug.Select(" ItemID=" + itemid + "");
            if (dr.Length > 0)
            {
                DataRow row = CardDataSource.Tables["unitdic"].NewRow();
                row["UnitDicId"] = 1;
                row["UnitName"] = dr[0]["MiniUnitName"];
                row["UnitNO"] =1;
                row["Pym"] = 1;
                row["Wbm"] = 1;
                CardDataSource.Tables["unitdic"].Rows.Add(row.ItemArray);

                row = CardDataSource.Tables["unitdic"].NewRow();
                row["UnitDicId"] = 2;
                row["UnitName"] = dr[0]["UnPickUnit"];
                row["UnitNO"] = dr[0]["MiniConvertNum"];
                row["Pym"] = 2;
                row["Wbm"] = 2;
                CardDataSource.Tables["unitdic"].Rows.Add(row.ItemArray);              
            } 
        }
        #endregion

        #region 医嘱操作
        //查询医嘱,绑定医嘱数据
        public void BindOrderData()
        {
            int type = (int)iview.OrderStyle;
            DataTable dt = Entity.OrderProcess.GetOrderRecords(type, iview.CurrPatListId, iview.PresDeptId,iview.IsShowAllOrder);
            iview.LoadGridOrderData(dt);
            iview.SetGridColor();
        }
        /// <summary>
        /// 医嘱保存
        /// </summary>
        /// <param name="notSavedRecords"></param>
        public bool SaveRecores(List<OrderRecord> notSavedRecords)
        {
            if (notSavedRecords.Count == 0)
            {
                return false;
            }
            if (CheckOrders(notSavedRecords))
            {
                List<OrderRecord> groupRecords = notSavedRecords.Where(p => p.GroupFlag == 1).OrderBy(p => p.OrderBdate).ToList();
                foreach (OrderRecord groupRecord in groupRecords)
                {                   
                    groupRecord.FirstNum = groupRecord.ShowFirstNum;
                    groupRecord.TeminalNum = groupRecord.ShowTeminalNum;
                    groupRecord.DoseNum = groupRecord.ShowDoseNum;
                    List<OrderRecord> sameGroupRecords = notSavedRecords.Where(p => p.OrderBdate == groupRecord.OrderBdate && p.GroupID == groupRecord.GroupID && p.GroupFlag == 0).ToList();
                    if (groupRecord.GroupID == 0)
                    {
                        groupRecord.GroupID = OrderDataSource.GetGroupMax(groupRecord.PatListID, (int)iview.OrderStyle);
                    }
                    foreach (OrderRecord notsaveRecord in sameGroupRecords)
                    {
                        notsaveRecord.GroupID = groupRecord.GroupID;
                        notsaveRecord.FrenquencyID = groupRecord.FrenquencyID;
                        notsaveRecord.Frequency = groupRecord.Frequency;
                        notsaveRecord.ChannelID = groupRecord.ChannelID;
                        notsaveRecord.ChannelName = groupRecord.ChannelName;
                        notsaveRecord.FirstNum = groupRecord.FirstNum;
                        notsaveRecord.TeminalNum = groupRecord.TeminalNum;
                        notsaveRecord.DoseNum = groupRecord.DoseNum;//付数
                    }
                }
                foreach (OrderRecord record in notSavedRecords)
                {
                    if (record.OrderStatus == (int)OrderStatus.医生新开)
                    {
                        record.OrderStatus = (int)OrderStatus.医生保存;
                    }
                }
                if (OrderDataSource.Save(notSavedRecords))
                {
                    string strMes = null;
                    for (int i = 0; i < notSavedRecords.Count; i++)
                    {
                        strMes += notSavedRecords[i].ItemName + "\n";
                    }
                    iview.ShowMessage("下列" + iview.OrderStyle.ToString() + "已经保存！\n" + strMes);
                    BindOrderData();
                    DataTable dt = iview.GetGridOrder;
                    if (dt.Rows.Count > 0)
                    {
                        iview.SetGridCurrentCell(dt.Rows.Count - 1, "ItemName");
                    }
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 医嘱删除
        /// </summary>
        /// <param name="delRecords"></param>
        /// <returns></returns>
        public bool DeleteRecored(List<OrderRecord> delRecords)
        {
            if (OrderDataSource.OperatorOrder(delRecords,1,iview.PresDoctorId))
            {
                string strMes = null;
                for (int i = 0; i < delRecords.Count; i++)
                {
                    strMes += delRecords[i].ItemName + "\n";
                }
                iview.ShowMessage("下列" + iview.OrderStyle.ToString() + "已经删除！\n" + strMes);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 医嘱发送
        /// </summary>
        /// <returns></returns>
        public bool SendOrderRecord()
        {
            DataTable dt = iview.GetGridOrder;
            List<OrderRecord> sendRecords = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<OrderRecord>(dt);
            sendRecords = sendRecords.Where(p => p.OrderStatus == 0).ToList();
            if (sendRecords.Count == 0)
            {
                return true;
            }
            foreach (OrderRecord sendRecord in sendRecords)
            {
                if (sendRecord.ItemType != 5)
                {
                    sendRecord.ItemName = IsRightName(sendRecord.ItemName, sendRecord.ItemID);
                }
                sendRecord.OrderStatus = (int)OrderStatus.医生发送;                
            }
            if (OrderDataSource.OperatorOrder(sendRecords,2,iview.PresDoctorId))
            {
                string strMes = null;
                for (int i = 0; i < sendRecords.Count; i++)
                {
                    strMes += sendRecords[i].ItemName + "\n";
                }
                iview.ShowMessage("下列" + iview.OrderStyle.ToString() + "已经确认！\n" + strMes);
                return true;
            }
            return false; ;
        }
        //医嘱停嘱
        public bool StopOrderRecord(List<OrderRecord> stopRecords)
        {
            foreach (OrderRecord sendRecord in stopRecords)
            {
                if (sendRecord.ItemType != 5)
                {
                    sendRecord.ItemName = IsRightName(sendRecord.ItemName, sendRecord.ItemID);
                }                
            }
            if (OrderDataSource.OperatorOrder(stopRecords,3, iview.PresDoctorId))
            {
                string strMes = null;
                for (int i = 0; i < stopRecords.Count; i++)
                {
                    strMes += stopRecords[i].ItemName + "\n";
                }
                iview.ShowMessage("下列" + iview.OrderStyle.ToString() + "已经停嘱！\n" + strMes);
                return true;
            }
            return false;
        }
        //取消停嘱
        public bool CancelStopOrderRecord(List<OrderRecord> stopRecords)
        {
            foreach (OrderRecord sendRecord in stopRecords)
            {
                if (sendRecord.ItemType != 5)
                {
                    sendRecord.ItemName = IsRightName(sendRecord.ItemName, sendRecord.ItemID);
                }
            }
            if (OrderDataSource.OperatorOrder(stopRecords, 4, iview.PresDoctorId))
            {
                string strMes = null;
                for (int i = 0; i < stopRecords.Count; i++)
                {
                    strMes += stopRecords[i].ItemName + "\n";
                }
                iview.ShowMessage("下列" + iview.OrderStyle.ToString() + "已经取消停嘱！\n" + strMes);
                return true;
            }
            return false;
        }

        List<OrderRecord> copyRecords;
        //医嘱复制
        public void OrderCopy(List<OrderRecord> records)
        {
            copyRecords = records;
            iview.ShowMessage("医嘱复制成功");
        }
        public void OrderPaster()
        {
            if (copyRecords == null || copyRecords.Count==0)
            {
                return;
            }
            int _ordercategory = copyRecords[0].OrderCategory;
            if ((int)iview.OrderStyle != _ordercategory)// 只能长嘱复制到长嘱，临嘱复制到临嘱
            {
                return;
            }
            AddOrders(copyRecords);
            copyRecords = null;
        }
        //添加医嘱
        public void AddOrders(List<OrderRecord> newlistPres)
        {
            if (newlistPres.Count == 0) return;
            List<Entity.OrderRecord> errlistPres = new List<Entity.OrderRecord>();
            //检查药品是否有库存
            if (OrderDataSource.IsDrugStore(newlistPres, errlistPres) == false)
            {
                string errDrugName = null;
                for (int i = 0; i < errlistPres.Count; i++)
                {
                    errDrugName += errlistPres[i].ItemName + "\t" + errlistPres[i].Spec + "\t" + errlistPres[i].Amount + errlistPres[i].Unit + "\n";
                }
                iview.ShowMessage("下列这些药品库存不足或已停用，不能开出！\n" + errDrugName);
            }
            for (int i = 0; i < errlistPres.Count; i++)
            {
                newlistPres.Remove(errlistPres[i]);
            }
            //DT 转 List
            DataTable dt = iview.GetGridOrder;
            List<Entity.OrderRecord> listPres = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<Entity.OrderRecord>(dt);
            //移除最后一行空白行
            if (listPres.Count > 0 && string.IsNullOrEmpty(listPres[listPres.Count - 1].ItemName))
            {
                listPres.RemoveAt(listPres.Count - 1);
            }
            DateTime bdate = DateTime.Now;
            for (int i = 0; i < newlistPres.Count; i++)
            {
                Entity.OrderRecord mPres = (Entity.OrderRecord)newlistPres[i].Clone();
                mPres.OrderID = 0;
                if (newlistPres[i].GroupFlag == 1)
                {                  
                    mPres.ShowOrderBdate = bdate;
                    mPres.OrderDocName = iview.PresDoctorName;
                    mPres.ShowChannel = mPres.ChannelName;
                    mPres.ShowFrency = mPres.Frequency;
                    mPres.ShowDoseNum = mPres.DoseNum;
                }
                mPres.OrderBdate = bdate;
                mPres.GroupID = 0;
                mPres.OrderStatus = (int)OrderStatus.医生新开;
                mPres.PatListID = iview.CurrPatListId;
                mPres.ModifyFlag = 1;
                mPres.OrderDoc = iview.PresDoctorId;
                mPres.PresDeptID = iview.PresDeptId;
                mPres.ShowTeminalNum = 0;
                mPres.TeminalNum = 0;           
                mPres.ExecFlag = 0;
                mPres.ExecNurse = 0;
                mPres.OrderType = 0;
                mPres.AstFlag = -1;
                mPres.EOrderDocName = "";
                mPres.EOrderDoc = 0;
                mPres.Factor = 1;               
                if (mPres.ItemID > 0)
                {
                    DataRow[] dr = dtItemDrug.Select(" ItemID=" + mPres.ItemID + "");
                    if (dr.Length == 0)
                    {
                        iview.ShowMessage("下列这些药品已经不存在，不能开出！\n" + mPres.ItemName);
                        if (mPres.GroupFlag == 1)
                        {
                            if (i != newlistPres.Count - 1)
                            {
                                newlistPres[i + 1].GroupFlag = 1;
                            }
                        }
                        continue;
                    }
                    mPres.ItemName = dr[0]["ItemName"].ToString();
                    mPres.ItemPrice = Convert.ToDecimal(dr[0]["SellPrice"]);
                    if (Convert.ToInt32(dr[0]["SkinTestFlag"]) == 1)//需要皮试
                    {
                        if (MessageBox.Show(""+ mPres.ItemName+"是需要皮试的药品，你要开‘皮试’医嘱吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            mPres.AstFlag = 0;
                        }
                        else
                        {
                            mPres.AstFlag = 3;
                        }
                    }
                    mPres.DosageUnit = dr[0]["DoseUnitName"].ToString();
                    mPres.Factor = Convert.ToDecimal(dr[0]["DoseConvertNum"]);// selectedRow["DoseConvertNum"];
                    mPres.Unit = dr[0]["MiniUnitName"].ToString();
                    mPres.UnitNO = 1;
                    if (Convert.ToInt32(dr[0]["ItemClass"]) == 5)
                    {
                        mPres.OrderType = 4;
                    }
                    if (Convert.ToInt32(dr[0]["ItemClass"]) == 1)
                    {
                        mPres.Amount = Math.Ceiling(Convert.ToDecimal(mPres.Dosage) / Convert.ToDecimal(mPres.Factor));// mPres.Dosage;
                    }
                    else
                    {
                        mPres.Amount = mPres.Dosage;
                    }                           
                }
                listPres.Add(mPres);
            }
            DataTable newdt = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToDataTable(listPres);
            for (int i = 0; i < newdt.Rows.Count; i++)
            {
                if (Convert.ToInt32(newdt.Rows[i]["GroupFlag"]) == 0)
                {
                    newdt.Rows[i]["ShowOrderBdate"] = DBNull.Value;
                    newdt.Rows[i]["ShowFirstNum"] = DBNull.Value;
                    newdt.Rows[i]["ShowTeminalNum"] = DBNull.Value;
                    newdt.Rows[i]["ShowDoseNum"] = DBNull.Value;
                }
                if (Convert.ToInt32(newdt.Rows[i]["ExecFlag"]) == 0)
                {
                    newdt.Rows[i]["ExecDate"] = DBNull.Value;
                }
                if (Convert.ToInt32(newdt.Rows[i]["OrderStatus"]) < (int)OrderStatus.医生停嘱)
                {
                    newdt.Rows[i]["EOrderDate"] = DBNull.Value;
                }
            }
            iview.LoadGridOrderData(newdt);
            iview.SetGridCurrentCell(listPres.Count == 0 ? 0 : listPres.Count - 1, "Dosage");
            iview.SetGridColor();
        }
        #endregion

        #region 医嘱检查判断
        /// <summary>
        /// 医嘱保存判断
        /// </summary>
        /// <param name="notSavedRecords"></param>
        /// <returns></returns>
        private bool CheckOrders(List<OrderRecord> notSavedRecords)
        {
            foreach (OrderRecord nameRecord in notSavedRecords)
            {
                if (nameRecord.ItemType != 5)
                {
                    nameRecord.ItemName = IsRightName(nameRecord.ItemName, nameRecord.ItemID);
                }
            }
            DataTable dt = iview.GetGridOrder;
            List<OrderRecord> records = notSavedRecords.Where(p => p.ItemType == 1).ToList();
            List<OrderRecord> errRecords = new List<OrderRecord>();
            //判断库存
            if (records.Count>0 && OrderDataSource.IsDrugStore(records, errRecords) == false)
            {
                //检查药品是否有库存               
                string errDrugName = null;
                for (int i = 0; i < errRecords.Count; i++)
                {
                    errDrugName += errRecords[i].ItemName + "\t" + errRecords[i].Spec + "\t" + errRecords[i].Dosage + errRecords[i].DosageUnit + "\n";
                }
                iview.ShowMessage("下列这些药品库存不足或已停用，不能开出！\n" + errDrugName);
                return false;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["ModifyFlag"]) == 1)
                {
                    string itemName = dt.Rows[i]["ItemName"] == DBNull.Value ? "" : dt.Rows[i]["ItemName"].ToString();
                    if (itemName == "")
                    {
                        continue;
                    }
                    if (Convert.ToInt32(dt.Rows[i]["ItemType"]) == 5)
                    {
                        continue;
                    }           
                    int statid = Convert.ToInt32(dt.Rows[i]["StatID"]);
                    if (statid == 100 || statid == 101)
                    {
                        if (Convert.ToInt32(dt.Rows[i]["GroupFlag"]) == 1 && !CheckChannel(dt.Rows[i]["ShowChannel"].ToString(), Convert.ToInt32(dt.Rows[i]["ChannelID"])))
                        {
                            iview.ShowMessage("" + iview.OrderStyle.ToString() + "" + itemName + "的用法输入不正确，请重新输入");
                            iview.SaveOrderCheckoflinkage((int)iview.OrderStyle, i, "ShowChannel");
                            // iview.SetGridCurrentCell(i, "ShowChannel");
                            return false;
                        }
                    }                  
                    if ((statid == 100 || statid == 101) || (iview.OrderStyle == OrderCategory.长期医嘱))
                    {
                        if (Convert.ToDecimal(dt.Rows[i]["Dosage"]) <= 0)
                        {
                            iview.ShowMessage(""+ iview.OrderStyle.ToString()+"" + itemName + "的剂量输入不正确，请重新输入");
                            iview.SaveOrderCheckoflinkage((int)iview.OrderStyle, i, "Dosage");
                          //  iview.SetGridCurrentCell(i, "Dosage");
                            return false;
                        }                       
                        if (Convert.ToInt32(dt.Rows[i]["GroupFlag"]) == 1 && !CheckFrenquency(dt.Rows[i]["ShowFrency"].ToString(), Convert.ToInt32(dt.Rows[i]["FrenquencyID"])))
                        {
                            iview.ShowMessage("" + iview.OrderStyle.ToString() + "" + itemName + "的频次输入不正确，请重新输入");
                            iview.SaveOrderCheckoflinkage((int)iview.OrderStyle, i, "ShowFrency");
                            //  iview.SetGridCurrentCell(i, "ShowFrency");
                            return false;
                        }
                    }
                    if (iview.OrderStyle == OrderCategory.临时医嘱)
                    {
                        if (Convert.ToDecimal(dt.Rows[i]["Amount"]) <= 0)
                        {
                            iview.ShowMessage("" + iview.OrderStyle.ToString() + "" + itemName + "的数量输入不正确，请重新输入");
                            iview.SaveOrderCheckoflinkage((int)iview.OrderStyle, i, "Amount");
                            //  iview.SetGridCurrentCell(i, "Amount");
                            return false;
                        }
                        if (statid == 102)
                        {
                            if (Convert.ToDecimal(dt.Rows[i]["Dosage"]) <= 0)
                            {
                                iview.ShowMessage("" + iview.OrderStyle.ToString() + "" + itemName + "的剂量输入不正确，请重新输入");
                                iview.SaveOrderCheckoflinkage((int)iview.OrderStyle, i, "Dosage");
                                // iview.SetGridCurrentCell(i, "Dosage");
                                return false;
                            }
                            if (Convert.ToInt32(dt.Rows[i]["GroupFlag"]) == 1 && Convert.ToDecimal(dt.Rows[i]["ShowDoseNum"]) <= 0)
                            {
                                iview.ShowMessage("" + iview.OrderStyle.ToString() + "" + itemName + "的付数输入不正确，请重新输入");
                                iview.SaveOrderCheckoflinkage((int)iview.OrderStyle, i, "ShowDoseNum");
                                // iview.SetGridCurrentCell(i, "ShowDoseNum");
                                return false;
                            }
                        }
                    }
                    int orderType = Convert.ToInt32(dt.Rows[i]["OrderType"]);
                    if (statid>0 && orderType <= 3)
                    {
                        if (Convert.ToDecimal(dt.Rows[i]["Dosage"]) <= 0)
                        {
                            iview.ShowMessage("" + iview.OrderStyle.ToString() + "" + itemName + "的剂量输入不正确，请重新输入");
                            iview.SaveOrderCheckoflinkage((int)iview.OrderStyle, i, "Dosage");
                            //  iview.SetGridCurrentCell(i, "Dosage");
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 医嘱名称判断
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="itemid"></param>
        /// <returns></returns>
        private  string IsRightName(string itemname, int itemid)
        {
            if (itemname == null || itemname == "")
            {
                return "";
            }
            string itemname1 = itemname.Replace("'", "");
            string strName = "";
            DataRow[] dr = dtItemDrug.Select("itemid=" + itemid + "");
            if (dr.Length > 0)
            {
                strName = dr[0]["itemname"].ToString().Trim();               
            }
            else
            {
                strName = itemname;
            }
            //if (itemname1.IndexOf(strName, 0) < 0)
            //{
            //    return strName;
            //}
            return strName;
        }     
        /// <summary>
        /// 用法判断
        /// </summary>
        /// <param name="channelName"></param>
        /// <param name="channelID"></param>
        /// <returns></returns>
        private bool CheckChannel(string channelName, int channelID)
        {
            if (channelName == "")
            {
                return false;
            }
            DataTable dtUsage = CardDataSource.Tables["usagedic"];
            DataRow[] rows = dtUsage.Select("UsageName='"+channelName+ "' and UsageId="+channelID+"");
            if (rows == null || rows.Length == 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 频次判断
        /// </summary>
        /// <param name="frenquencyName"></param>
        /// <param name="frenquencyId"></param>
        /// <returns></returns>
        private bool CheckFrenquency(string frenquencyName, int frenquencyId)
        {
            if (frenquencyName == "")
            {
                return false;
            }   
            DataTable dtFrequency = CardDataSource.Tables["frequencydic"];
            DataRow[] rows = dtFrequency.Select("Name='" + frenquencyName + "' and FrequencyId=" + frenquencyId + "");
            if (rows == null || rows.Length == 0)
            {
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 获取末次默认执行次数
        /// </summary>
        /// <param name="frequencyId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int GetTeminalExecCount(int frequencyId, DateTime date)
        {
            return OrderDataSource.GetExecCount(1, frequencyId, date);
        }

        /// <summary>
        /// 转科，出院，死亡医嘱时判断是否有未执行的医嘱
        /// </summary>
        /// <returns></returns>
        public bool GetNotExsistOrders()
        {
            DataTable dt = OrderDataSource.getNotExsistOrders(iview.CurrPatListId);
            if (dt == null || dt.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                string str = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    str += "" + dt.Rows[i]["ItemName"] + "\n";
                }
                iview.ShowMessage("还有下列医嘱未发送或未执行" + str + "");
                return false;
            }
        }

        public DataTable getIpDepts()
        {
            DataTable dt = OrderDataSource.getIpDept();
            return dt;
        }
        //获取诊断
        public DataTable getDisease()
        {
            return OrderDataSource.getDisease();
        }
        //获取出院情况
        public DataTable getOutsituation()
        {
            return OrderDataSource.getOutSituation();
        }
        public DataTable GetNotStopLongOrders()
        {          
            DataTable dt = Entity.OrderProcess.GetNotStopLongOrders(0, iview.CurrPatListId, iview.PresDeptId);
            return dt;
        }
        //转科医嘱
        public bool SpeciOrder(DataTable dtStopLongOrders,OrderType ordertype,DateTime SpeciDate,int transDeptId,string memo)
        {
            //医嘱自动停嘱
            List<OrderRecord> list = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<OrderRecord>(dtStopLongOrders);
            foreach (OrderRecord record in list)
            {
                record.AutoEndFlag = 1;
                record.OrderStatus = (int)OrderStatus.医生停嘱;
                record.EOrderDate = SpeciDate;
                record.EOrderDoc = iview.PresDoctorId;
            }
            string content = "";
            //生成说明性临嘱
            if (ordertype == OrderType.转科医嘱)
            {
                 content = "病人" + SpeciDate.ToString("yyyy-MM-dd") + "转" + memo;
            }
            OrderRecord spciOrderRecord = GenerateRecord(content, ordertype);
            return OrderDataSource.TransDeptOrder(iview.CurrPatListId, list, SpeciDate, transDeptId, iview.PresDoctorId, spciOrderRecord);                    
        }
        //出院医嘱
        public bool OutHospOrder(DataTable dtStopLongOrders, OrderType ordertype, DateTime OutDate, string outDiseaseName, string outDiseaseCode,string outSituation)
        {
            //医嘱自动停嘱
            List<OrderRecord> list = EFWCoreLib.CoreFrame.Common.ConvertExtend.ToList<OrderRecord>(dtStopLongOrders);
            foreach (OrderRecord record in list)
            {
                record.AutoEndFlag = 1;
                record.OrderStatus = (int)OrderStatus.医生停嘱;
                record.EOrderDate = OutDate;
                record.EOrderDoc = iview.PresDoctorId;
            }
            string content = "";
            //生成说明性临嘱
            if (ordertype == OrderType.出院医嘱)
            {
                content = "病人" + OutDate.ToString("yyyy-MM-dd") + "出院";
            }
            if (ordertype == OrderType.死亡医嘱)
            {
                content = "病人" + OutDate.ToString("yyyy-MM-dd HH:mm:ss") + "死亡";
            }
            OrderRecord spciOrderRecord = GenerateRecord(content, ordertype);
            return OrderDataSource.OutHospOrder(iview.CurrPatListId, list, OutDate, outDiseaseName, outDiseaseCode, outSituation, iview.PresDoctorId, spciOrderRecord);
        }
        //特殊医嘱对象生成
        private OrderRecord GenerateRecord(string orderContent, OrderType ordertype)
        {
            OrderRecord recored = new Entity.OrderRecord();
            recored.ItemID = 0;
            recored.ItemName = orderContent;
            recored.GroupID = 0;
            recored.FrenquencyID = 0;
            recored.ChannelID = 0;
            recored.Dosage = 0;
            recored.OrderStatus = (int)OrderStatus.医生发送;
            recored.AstFlag = -1;
            recored.Factor = 1;
            recored.AstOrderID = 0;
            recored.OrderBdate = DateTime.Now;
            recored.PatListID = iview.CurrPatListId;
            recored.PresDeptID = iview.PresDeptId;
            recored.OrderDoc = iview.PresDoctorId;
            recored.Amount = 0;
            recored.GroupFlag = 1;
            recored.ItemType = 5;
            recored.OrderCategory = 1;
            recored.OrderType = (int)ordertype;
            return recored;
        }
    }
}
