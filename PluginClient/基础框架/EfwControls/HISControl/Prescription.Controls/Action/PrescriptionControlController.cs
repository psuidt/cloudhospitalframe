using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using EfwControls.HISControl.Prescription.Controls.CommonMvc;
using EfwControls.HISControl.Prescription.Controls.Entity;
using EfwControls.Common;

namespace EfwControls.HISControl.Prescription.Controls.Action
{
    internal class PrescriptionControlController : BaseController<IPrescriptionControl>
    {
        private IPrescriptionControl iPrescriptionControl;//处方控件界面
        private DataSet CardDataSource;//选项卡数据源
        private List<Entity.Prescription> mCopyPres;
        public IPrescripttionDbHelper PrescripttionDataSource;//数据

        public PrescriptionControlController(IPrescriptionControl _PrescriptionControl)
        {
            iPrescriptionControl = _PrescriptionControl;
            bindView(_PrescriptionControl);
            //iPrescriptionControl.controller = this;
        }

        public override void InitLoad()
        {
            base.InitLoad();
            //iPrescriptionControl = IfrmView;
        }

        //绑定选项卡数据源
        public void BindCardDataSource(IPrescripttionDbHelper dbHelper)
        {
            PrescripttionDataSource = dbHelper;
            Entity.Prescription.PrescripttionDataSource = dbHelper;

            CardDataSource = new DataSet();

            int type = (int)iPrescriptionControl.PrescriptionStyle;

            DataTable dt1 = ConvertDataExtend.ToDataTable(PrescripttionDataSource.GetDrugItem(type, 1, 10, ""));
            dt1.TableName = "itemdrug";
            CardDataSource.Tables.Add(dt1);

            DataTable dt2 = new DataTable("execdept");
            CardDataSource.Tables.Add(dt2);

            List<CardDataSourceUnit> list_unit = new List<CardDataSourceUnit>();
            CardDataSourceUnit munit = new CardDataSourceUnit();
            list_unit.Add(munit);


            DataTable dt3 = ConvertDataExtend.ToDataTable(list_unit);
            dt3.TableName = "unitdic";
            dt3.Clear();
            CardDataSource.Tables.Add(dt3);

            DataTable dt4 = ConvertDataExtend.ToDataTable(PrescripttionDataSource.GetUsage());
            dt4.TableName = "usagedic";
            CardDataSource.Tables.Add(dt4);

            DataTable dt5 = ConvertDataExtend.ToDataTable(PrescripttionDataSource.GetFrequency());
            dt5.TableName = "frequencydic";
            CardDataSource.Tables.Add(dt5);

            DataTable dt6 = ConvertDataExtend.ToDataTable(list_unit);
            dt6.TableName = "packunitdic";
            dt6.Clear();
            CardDataSource.Tables.Add(dt6);

            DataTable dt7 = ConvertDataExtend.ToDataTable(PrescripttionDataSource.GetEntrust());
            dt7.TableName = "entrustdic";
            CardDataSource.Tables.Add(dt7);

            iPrescriptionControl.InitializeCardData(CardDataSource);
        }

        //过滤药品项目数据源
        public void FilterDrugItemDataSource(int pageNo, int pageSize, string fiterChar)
        {
            CardDataSource.Tables["itemdrug"].Clear();
            int type = (int)iPrescriptionControl.PrescriptionStyle;
            DataTable dt = ConvertDataExtend.ToDataTable(PrescripttionDataSource.GetDrugItem(type, pageNo, pageSize, fiterChar));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CardDataSource.Tables["itemdrug"].Rows.Add(dt.Rows[i].ItemArray);
            }
        }

        //更新数据源
        public void UploadCardDataSource(int rowIndex, int colIndex)
        {
            //int rowIndex = iPrescriptionControl.GridRowIndex;
            if (iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Status"] == DBNull.Value)
                return;
            PresStatus presstatus = (PresStatus)(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Status"]);
            int itemId = Convert.ToInt32(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Item_Id"]);

            if (presstatus == PresStatus.编辑状态)
            {
                if (itemId > 0 && Convert.ToBoolean(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["IsDrug"]))
                {
                    if (colIndex == iPrescriptionControl.AllColumnIndex.UsageUnitIndex)
                    {
                        CardDataSource.Tables["unitdic"].Clear();
                        DataTable dt1 = ConvertDataExtend.ToDataTable(PrescripttionDataSource.GetUnit(itemId, 0));
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            CardDataSource.Tables["unitdic"].Rows.Add(dt1.Rows[i].ItemArray);
                        }
                    }
                    else if (colIndex == iPrescriptionControl.AllColumnIndex.ItemUnitIndex)
                    {
                        CardDataSource.Tables["packunitdic"].Clear();
                        DataTable dt2 = ConvertDataExtend.ToDataTable(PrescripttionDataSource.GetUnit(itemId, 1));
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            CardDataSource.Tables["packunitdic"].Rows.Add(dt2.Rows[i].ItemArray);
                        }
                    }
                }
            }

        }

        //绑定处方数据
        public void BindPresData()
        {
            int type = (int)iPrescriptionControl.PrescriptionStyle;
            DataTable dt = Entity.Prescription.GetPrescriptionData(type, iPrescriptionControl.CurrPatListId);

            iPrescriptionControl.LoadGridPresData(dt);

            //for (int index = 0; index < iPrescriptionControl.PresGridDataSource.Rows.Count; index++)
            //{
            //    SetCellColor(index, -1);
            //}
        }


        #region 处方外观
        //绘制组线和删除线
        public void PresPaintLine(Graphics graphics, PrescriptionStyle PresStyle)
        {
            if (iPrescriptionControl.PresGridDataSource == null) return;
            int penWidth = 2;

            if (PresStyle == PrescriptionStyle.西药与中成药 || PresStyle == PrescriptionStyle.全部)
            {
                //循环遍历所有记录
                for (int index = 0; index < iPrescriptionControl.PresGridDataSource.Rows.Count; index++)
                {
                    Color penColer = Color.Black;
                    switch ((PresStatus)iPrescriptionControl.PresGridDataSource.Rows[index]["Status"])
                    {
                        case PresStatus.编辑状态:
                            penColer = Color.Blue;
                            break;
                        case PresStatus.收费状态:
                            penColer = Color.Orange;
                            break;
                        case PresStatus.退费状态:
                            penColer = Color.Fuchsia;
                            //PaintDelLine(graphics, index, new Pen(penColer, 1));
                            break;
                        default:
                            break;
                    }

                    int groupFlag = getGroupFlag(index);
                    if (groupFlag > 0)
                    {
                        PaintGroupLine(groupFlag, graphics, new Pen(penColer, penWidth), index);
                    }
                }
            }

            //循环遍历所有记录
            for (int index = 0; index < iPrescriptionControl.PresGridDataSource.Rows.Count; index++)
            {
                if ((PresStatus)iPrescriptionControl.PresGridDataSource.Rows[index]["Status"] == PresStatus.退费状态)
                {
                    Color penColer = Color.Fuchsia;
                    PaintDelLine(graphics, index, new Pen(penColer, 1));
                }
            }

        }

        //获取分组标志
        private int getGroupFlag(int rowIndex)
        {
            int groupFlag = 0;
            int listId = Convert.ToInt32(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["PresNo"]);
            int groupId = Convert.ToInt32(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Group_Id"]);
            if (listId == 0)
                return 0;

            List<int> listCount = new List<int>();
            for (int index = 0; index < iPrescriptionControl.PresGridDataSource.Rows.Count; index++)
            {
                if (Convert.ToInt32(iPrescriptionControl.PresGridDataSource.Rows[index]["PresNo"]) == listId && Convert.ToInt32(iPrescriptionControl.PresGridDataSource.Rows[index]["Group_Id"]) == groupId)
                {
                    listCount.Add(index);
                }
            }

            for (int i = 0; i < listCount.Count; i++)
            {
                if (rowIndex == listCount[i] && i == 0)
                {
                    groupFlag = 1;
                    break;
                }
                else if (rowIndex == listCount[i] && i == listCount.Count - 1)
                {
                    groupFlag = 3;
                    break;
                }
                else
                {
                    groupFlag = 2;
                }
            }

            if (listCount.Count == 1)
                return 0;
            else
                return groupFlag;
        }

        //绘制组线
        private void PaintGroupLine(int groupFlag, Graphics graphics, System.Drawing.Pen pen, int rowIndex)
        {
            //定义坐标变量
            int startPointX, startPointY, endPointX, endPointY;
            int firstLineWidth = 6;
            int firstLineHeight = iPrescriptionControl.GridCellBounds(rowIndex).Height / 2;
            switch (groupFlag)
            {
                case 1:
                    //小横线
                    startPointX = iPrescriptionControl.GridCellBounds(rowIndex).Left - firstLineWidth;
                    startPointY = iPrescriptionControl.GridCellBounds(rowIndex).Bottom - firstLineHeight;
                    endPointX = iPrescriptionControl.GridCellBounds(rowIndex).Left;
                    endPointY = iPrescriptionControl.GridCellBounds(rowIndex).Bottom - firstLineHeight;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    //小竖线
                    startPointX = iPrescriptionControl.GridCellBounds(rowIndex).Left - firstLineWidth;
                    startPointY = iPrescriptionControl.GridCellBounds(rowIndex).Bottom - firstLineHeight;
                    endPointX = iPrescriptionControl.GridCellBounds(rowIndex).Left - firstLineWidth;
                    endPointY = iPrescriptionControl.GridCellBounds(rowIndex).Bottom;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    break;
                case 2:
                    startPointX = iPrescriptionControl.GridCellBounds(rowIndex).Left - firstLineWidth;
                    startPointY = iPrescriptionControl.GridCellBounds(rowIndex).Top;
                    endPointX = iPrescriptionControl.GridCellBounds(rowIndex).Left - firstLineWidth;
                    endPointY = iPrescriptionControl.GridCellBounds(rowIndex).Bottom;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    break;
                case 3:
                    //小竖线
                    startPointX = iPrescriptionControl.GridCellBounds(rowIndex).Left - firstLineWidth;
                    startPointY = iPrescriptionControl.GridCellBounds(rowIndex).Top;
                    endPointX = iPrescriptionControl.GridCellBounds(rowIndex).Left - firstLineWidth;
                    endPointY = iPrescriptionControl.GridCellBounds(rowIndex).Top + firstLineHeight;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    //小横线
                    startPointX = iPrescriptionControl.GridCellBounds(rowIndex).Left - firstLineWidth;
                    startPointY = iPrescriptionControl.GridCellBounds(rowIndex).Top + firstLineHeight;
                    endPointX = iPrescriptionControl.GridCellBounds(rowIndex).Left;
                    endPointY = iPrescriptionControl.GridCellBounds(rowIndex).Top + firstLineHeight;
                    graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
                    break;
                default:
                    break;
            }
        }

        //绘制删除线
        private void PaintDelLine(Graphics graphics, int rowIndex, System.Drawing.Pen pen)
        {
            //定义坐标变量
            int startPointX, startPointY, endPointX, endPointY;

            startPointX = iPrescriptionControl.GridCellBounds(rowIndex).Left;
            startPointY = iPrescriptionControl.GridCellBounds(rowIndex).Top + iPrescriptionControl.GridCellBounds(rowIndex).Height / 2;
            endPointX = iPrescriptionControl.GridCellBounds(rowIndex).Right;
            endPointY = startPointY;
            graphics.DrawLine(pen, startPointX, startPointY, endPointX, endPointY);
        }

        //设置网格列只读状态
        public void SettingReadOnly(int rowIndex)
        {
            try
            {
                if (rowIndex >= iPrescriptionControl.PresGridDataSource.Rows.Count) return;
                if (iPrescriptionControl.PresGridDataSource == null || iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Status"] == DBNull.Value)
                {
                    //新行
                    iPrescriptionControl.CellReadOnly = PresCellReadOnlyStatus.新行;
                    return;
                }

                else if (Convert.ToInt32(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["SkinTest_Flag"]) == 1 && iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Usage_Name"].ToString().Contains("皮试"))
                {
                    if ((PresStatus)(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Status"]) != PresStatus.编辑状态)
                    {
                        //全部设为只读
                        iPrescriptionControl.CellReadOnly = PresCellReadOnlyStatus.全部只读;
                    }
                    else
                    {
                        //皮试
                        iPrescriptionControl.CellReadOnly = PresCellReadOnlyStatus.皮试;
                    }
                    return;
                }
                if ((PresStatus)(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Status"]) != PresStatus.编辑状态
                    || iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Item_Name"].ToString() == "小计：")
                {
                    //全部设为只读
                    iPrescriptionControl.CellReadOnly = PresCellReadOnlyStatus.全部只读;

                }
                else if (Convert.ToBoolean(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["IsHerb"]) == true)
                {
                    //中药处方
                    iPrescriptionControl.CellReadOnly = PresCellReadOnlyStatus.中药处方;
                }
                else if (Convert.ToBoolean(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["IsDrug"]))
                {
                    if (Convert.ToInt32(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["MedicareID"]) == 1)
                    {
                        //甲类药品处方
                        iPrescriptionControl.CellReadOnly = PresCellReadOnlyStatus.甲类药品处方;
                    }
                    else
                    {
                        //药品处方
                        iPrescriptionControl.CellReadOnly = PresCellReadOnlyStatus.药品处方;
                    }
                }
                else if (Convert.ToInt32(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Item_Id"]) <= 0)
                {
                    //新行
                    iPrescriptionControl.CellReadOnly = PresCellReadOnlyStatus.新行;
                }
                else
                {
                    //项目
                    iPrescriptionControl.CellReadOnly = PresCellReadOnlyStatus.项目;
                }
            }
            catch { }
        }

        //设置网格单元格颜色
        public void SetCellColor(int rowid, int colid)
        {
            PresStatus status = (PresStatus)iPrescriptionControl.PresGridDataSource.Rows[rowid]["Status"];
            PresColor presColor = new PresColor();
            presColor.rowIndex = rowid;
            presColor.colIndex = colid;
            presColor.ForeColor = PresColor.GetPresForeColor(status);
            presColor.BackColor = PresColor.GetPresBackColor(Convert.ToInt32(iPrescriptionControl.PresGridDataSource.Rows[rowid]["Item_Id"]), status);
            iPrescriptionControl.CellColor = presColor;
        }
        #endregion

        #region 处方操作

        //计算新行的处方号与分组号
        private void calculateNewListNoAndGroupNo(DataTable dt, int rowIndex, out int PresNo, out int GroupNo, out int OrderNO)
        {
            if (rowIndex < 0)
            {
                PresNo = 1;
                GroupNo = 1;
                OrderNO = 1;
            }
            else if (dt.Rows[rowIndex]["Item_Name"].ToString().Trim() == "小计：")
            {
                PresNo = Convert.ToInt32(dt.Rows[rowIndex - 1]["PresNo"]) + 1;
                GroupNo = 1;
                OrderNO = 1;
            }
            else
            {
                PresNo = Convert.ToInt32(dt.Rows[rowIndex]["PresNo"]);
                GroupNo = Convert.ToInt32(dt.Rows[rowIndex]["Group_Id"]) + 1;
                OrderNO = Convert.ToInt32(dt.Rows[rowIndex]["OrderNo"]) + 1;
            }
        }

        //追加新处方
        private void additionalNewPresNew(List<Entity.Prescription> newlistPres)
        {
            if (newlistPres.Count == 0) return;

            List<Entity.Prescription> errlistPres = new List<Entity.Prescription>();
            //检查药品是否有库存
            if (PrescripttionDataSource.IsDrugStore(newlistPres, errlistPres) == false)
            {
                string errDrugName = null;
                for (int i = 0; i < errlistPres.Count; i++)
                {
                    errDrugName += errlistPres[i].Item_Name + "\t" + errlistPres[i].Standard + "\t" + errlistPres[i].Item_Amount_S + errlistPres[i].Item_Unit_S + "\n";
                }

                IfrmView.PromptController("下列这些药品库存不足或已停用，不能开出！\n" + errDrugName);
            }

            for (int i = 0; i < errlistPres.Count; i++)
            {
                newlistPres.Remove(errlistPres[i]);
            }

            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            int _presNo = 0;
            //移除最后一行空白行
            if (listPres.Count > 0 && string.IsNullOrEmpty(listPres[listPres.Count - 1].Item_Name))
            {
                listPres.RemoveAt(listPres.Count - 1);
                _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo);
                if (newlistPres.Count > 0)
                {
                    if (listPres.Count == 0)
                    {
                        Entity.Prescription.CalculateSubtotal(ref listPres);
                        _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo) + 1;
                    }
                    else
                    {
                        if (listPres[listPres.Count - 1].Dept_Id != newlistPres[0].Dept_Id)
                        {
                            Entity.Prescription.CalculateSubtotal(ref listPres);
                            _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo) + 1;
                        }
                    }
                }
            }
            else
            {
                Entity.Prescription.CalculateSubtotal(ref listPres);
                _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo) + 1;
            }
            int diffNo = 0;
            if (newlistPres.Count > 0)
                diffNo = newlistPres[0].PresNo - 0;
            int oldPresNo = 0;
            for (int i = 0; i < newlistPres.Count; i++)
            {

                Entity.Prescription mPres = (Entity.Prescription)newlistPres[i].Clone();
                oldPresNo = mPres.PresNo;
                mPres.PresNo = mPres.PresNo + _presNo- diffNo;
                mPres.PresHeadId = 0;
                mPres.PresListId = 0;
                mPres.SelfDrug_Flag = Convert.ToInt32(0);//自备
                mPres.Pres_Date = Convert.ToDateTime(DateTime.Now);
                mPres.Pres_Doc = iPrescriptionControl.PresDoctorId;
                mPres.Pres_DocName = iPrescriptionControl.PresDoctorName;
                mPres.Pres_Dept = iPrescriptionControl.PresDeptCode;
                mPres.Pres_DeptName = iPrescriptionControl.PresDeptName;

                mPres.Status = PresStatus.编辑状态;

                listPres.Add(mPres);

                //添加小计
                Entity.Prescription.CalculateSubtotal(ref listPres);
                //皮试药品
                CardDataSourceDrugItem drugCard = PrescripttionDataSource.GetDrugItem(mPres.Item_Id);
                if (drugCard!=null&&PrescripttionDataSource.GetDrugItem(mPres.Item_Id).SkinTestFlag == 1)
                {
                    int oldCnt = listPres.Count;
                    SkinTestDrugTpl(listPres, mPres.PresNo, mPres);
                    int newCnt = listPres.Count;
                    if (newCnt > oldCnt)
                    {
                        if (i+1  < newlistPres.Count)
                        {
                            for (int j = i+1 ; j < newlistPres.Count; j++)
                            {
                                if (newlistPres[j].PresNo == oldPresNo && newlistPres[j].Group_Id == mPres.Group_Id)
                                {
                                    newlistPres[j].PresNo = mPres.PresNo - (_presNo - 1);
                                }
                                else
                                {
                                    newlistPres[j].PresNo += 1;
                                }
                            }
                        }
                    }

                }
                
            }

            Entity.Prescription.CalculateAllNo(listPres);

            //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
            ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                SetCellColor(index, -1);
            }

            iPrescriptionControl.SetGridCurrentCell(listPres.Count == 0 ? 0 : listPres.Count - 1, iPrescriptionControl.AllColumnIndex.ItemNameIndex);

        }

        //追加新处方
        private void additionalNewPres(List<Entity.Prescription> newlistPres)
        {
            if (newlistPres.Count == 0) return;

            List<Entity.Prescription> errlistPres = new List<Entity.Prescription>();
            //检查药品是否有库存
            if (PrescripttionDataSource.IsDrugStore(newlistPres, errlistPres) == false)
            {
                string errDrugName = null;
                for (int i = 0; i < errlistPres.Count; i++)
                {
                    errDrugName += errlistPres[i].Item_Name + "\t" + errlistPres[i].Standard + "\t" + errlistPres[i].Item_Amount_S + errlistPres[i].Item_Unit_S + "\n";
                }

                IfrmView.PromptController("下列这些药品库存不足或已停用，不能开出！\n" + errDrugName);
            }

            for (int i = 0; i < errlistPres.Count; i++)
            {
                newlistPres.Remove(errlistPres[i]);
            }

            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            int _presNo = 0;
            //移除最后一行空白行
            if (listPres.Count > 0 && string.IsNullOrEmpty(listPres[listPres.Count - 1].Item_Name))
            {
                listPres.RemoveAt(listPres.Count - 1);
                _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo);
                if (newlistPres.Count > 0)
                {
                    if (listPres[listPres.Count - 1].Dept_Id != newlistPres[0].Dept_Id)
                    {
                        Entity.Prescription.CalculateSubtotal(ref listPres);
                        _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo) + 1;
                    }
                }
            }
            else
            {
                Entity.Prescription.CalculateSubtotal(ref listPres);
                _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo) + 1;
            }
            for (int i = 0; i < newlistPres.Count; i++)
            {

                Entity.Prescription mPres = (Entity.Prescription)newlistPres[i].Clone();
                mPres.PresNo = _presNo;
                mPres.PresHeadId = 0;
                mPres.PresListId = 0;
                mPres.SelfDrug_Flag = Convert.ToInt32(0);//自备
                mPres.Pres_Date = Convert.ToDateTime(DateTime.Now);
                mPres.Pres_Doc = iPrescriptionControl.PresDoctorId;
                mPres.Pres_DocName = iPrescriptionControl.PresDoctorName;
                mPres.Pres_Dept = iPrescriptionControl.PresDeptCode;
                mPres.Pres_DeptName = iPrescriptionControl.PresDeptName;

                mPres.Status = PresStatus.编辑状态;

                listPres.Add(mPres);

                //皮试药品
                if (PrescripttionDataSource.GetDrugItem(mPres.Item_Id).SkinTestFlag == 1)
                {
                    SkinTestDrug(listPres, _presNo, mPres);
                }
            }

            Entity.Prescription.CalculateAllNo(listPres);

            //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
            ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                SetCellColor(index, -1);
            }

            iPrescriptionControl.SetGridCurrentCell(listPres.Count == 0 ? 0 : listPres.Count - 1, iPrescriptionControl.AllColumnIndex.ItemNameIndex);

        }

        //追加模板明细
        private void AddPresTplRow(List<Entity.Prescription> newlistPres)
        {
            if (newlistPres.Count == 0) return;

            List<Entity.Prescription> errlistPres = new List<Entity.Prescription>();
            //检查药品是否有库存
            if (PrescripttionDataSource.IsDrugStore(newlistPres, errlistPres) == false)
            {
                string errDrugName = null;
                for (int i = 0; i < errlistPres.Count; i++)
                {
                    errDrugName += errlistPres[i].Item_Name + "\t" + errlistPres[i].Standard + "\t" + errlistPres[i].Item_Amount_S + errlistPres[i].Item_Unit_S + "\n";
                }

                IfrmView.PromptController("下列这些药品库存不足或已停用，不能开出！\n" + errDrugName);
            }

            for (int i = 0; i < errlistPres.Count; i++)
            {
                newlistPres.Remove(errlistPres[i]);
            }
            if (newlistPres.Count == 0)
                return;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            int _presNo = 0;
            int groupId = 0;
            //移除最后一行空白行
            if (listPres.Count > 0 && string.IsNullOrEmpty(listPres[listPres.Count - 1].Item_Name))
            {
                listPres.RemoveAt(listPres.Count - 1);
                _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo);
                if (newlistPres.Count > 0)
                {
                    if (listPres.Count == 0)
                    {
                        _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo) + 1;
                    }
                    else if (listPres[listPres.Count - 1].Dept_Id != newlistPres[0].Dept_Id)
                    {
                        Entity.Prescription.CalculateSubtotal(ref listPres);
                        _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo) + 1;
                    }
                }
            }
            else
            {
                if (listPres.Count > 0 && listPres[listPres.Count - 1].Item_Name == "小计：")
                {
                    Entity.Prescription.CalculateSubtotal(ref listPres);
                    _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo) + 1;
                }
                else
                {
                    if(listPres.Count==0)
                    {
                        _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo) + 1;
                    }
                    else if (listPres[listPres.Count - 1].Dept_Id != newlistPres[0].Dept_Id)
                    {
                        Entity.Prescription.CalculateSubtotal(ref listPres);
                        _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo) + 1;
                    }
                    else
                    {
                        _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo);
                        groupId = listPres[listPres.Count - 1].Group_Id + 1;
                        int presType = (int)iPrescriptionControl.PrescriptionStyle;
                        if (presType == 1)
                        {
                            int presCount = iPrescriptionControl.PresCount;
                            if (listPres.Count(x => x.PresNo == _presNo) == presCount)
                            {
                                Entity.Prescription.CalculateSubtotal(ref listPres);
                                _presNo = listPres.Count == 0 ? 1 : listPres.Max(x => x.PresNo) + 1;
                                groupId = 0;
                            }
                        }
                    }

                }
            }
            for (int i = 0; i < newlistPres.Count; i++)
            {

                Entity.Prescription mPres = (Entity.Prescription)newlistPres[i].Clone();
                mPres.PresNo = _presNo;
                if (groupId != 0)
                    mPres.Group_Id = groupId;
                mPres.PresHeadId = 0;
                mPres.PresListId = 0;
                mPres.SelfDrug_Flag = Convert.ToInt32(0);//自备
                mPres.Pres_Date = Convert.ToDateTime(DateTime.Now);
                mPres.Pres_Doc = iPrescriptionControl.PresDoctorId;
                mPres.Pres_DocName = iPrescriptionControl.PresDoctorName;
                mPres.Pres_Dept = iPrescriptionControl.PresDeptCode;
                mPres.Pres_DeptName = iPrescriptionControl.PresDeptName;

                mPres.Status = PresStatus.编辑状态;

                listPres.Add(mPres);

                //皮试药品
                if (PrescripttionDataSource.GetDrugItem(mPres.Item_Id).SkinTestFlag == 1)
                {
                    SkinTestDrug(listPres, _presNo, mPres);
                }
            }

            Entity.Prescription.CalculateAllNo(listPres);

            //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
            ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                SetCellColor(index, -1);
            }

            iPrescriptionControl.SetGridCurrentCell(listPres.Count == 0 ? 0 : listPres.Count - 1, iPrescriptionControl.AllColumnIndex.ItemNameIndex);

        }

        //1.新开处方
        public void PresAddRow()
        {
            DataTable dt = iPrescriptionControl.PresGridDataSource;

            int rowid;
            rowid = dt.Rows.Count - 1;
            if (rowid > -1 && dt.Rows[rowid]["Item_Name"].ToString().Trim() == "")	//最后一行不为空才允许新增一行
            {
                iPrescriptionControl.SetGridCurrentCell(rowid, iPrescriptionControl.AllColumnIndex.ItemIdIndex);
                return;
            }
            int maxPresNo;
            int groupId;
            int maxOrderNO;

            calculateNewListNoAndGroupNo(dt, rowid, out maxPresNo, out groupId, out maxOrderNO);

            Entity.Prescription mPres = Entity.Prescription.AddPresNewRow(maxPresNo, groupId, maxOrderNO, iPrescriptionControl.PresDoctorId, iPrescriptionControl.PresDoctorName, iPrescriptionControl.PresDeptCode, iPrescriptionControl.PresDeptName);


            dt.Rows.Add(ConvertDataExtend.ToDataRow(mPres).ItemArray);

            SettingReadOnly(dt.Rows.Count - 1);
            iPrescriptionControl.SetGridCurrentCell(dt.Rows.Count - 1, iPrescriptionControl.AllColumnIndex.ItemIdIndex);
            return;
        }

        #region  2.编辑处方网格赋值

        public void PresSelectCard(int colIndex, Object data)
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            DataRow row = (DataRow)data;
            
            if (colIndex == iPrescriptionControl.AllColumnIndex.ItemIdIndex)//药品项目
            {
                if (iPrescriptionControl.DrugRepeatWarn == 0)
                {
                    DataRow[] drArrs = dt.Select("Item_Id='" + row["ItemId"].ToString() + "'");
                    if (drArrs.Length > 0)
                    {
                        iPrescriptionControl.ShowMessage("您输入了重复的药品：" + row["ItemName"].ToString() + "  " + row["Standard"].ToString());
                    }
                }
                ItemWriteRowValue(dt, rowIndex, row);
            }
            else if (colIndex == iPrescriptionControl.AllColumnIndex.DeptNameIndex)//执行科室
            {
            }
            else if (colIndex == iPrescriptionControl.AllColumnIndex.UsageAmountIndex)//用量
            {
                Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(dt, rowIndex);

                mPres.Usage_Amount_S = dt.Rows[rowIndex]["Usage_Amount_S"].ToString();
                mPres.CalculateAmount(null);//计算数量 和 金额
                //mPres.Status = PresStatus.编辑状态;
                ConvertDataExtend.UpdateDataTable(dt, rowIndex, mPres);
            }
            else if (colIndex == iPrescriptionControl.AllColumnIndex.UsageUnitIndex)//用量单位
            {
                UsageUnitRowValue(dt, rowIndex, row);
            }
            else if (colIndex == iPrescriptionControl.AllColumnIndex.UsageIndex)//用法
            {
                Entity.Prescription mPres = UsageRowValue(dt, rowIndex, row);
                DataRow[] drs;
                if (Entity.Prescription.IsGroup(dt, mPres.PresNo, mPres.Group_Id, out drs))
                {
                    for (int i = 0; i < drs.Length; i++)
                    {
                        drs[i]["Usage_Id"] = mPres.Usage_Id;
                        drs[i]["Usage_Name"] = mPres.Usage_Name;
                        drs[i]["ExecNum"] = drs[0]["ExecNum"];
                        drs[i]["Memo"] = drs[0]["Memo"];
                    }
                }
            }
            else if (colIndex == iPrescriptionControl.AllColumnIndex.FrequencyIndex)//频次
            {
                Entity.Prescription mPres = FrequencyRowValue(dt, rowIndex, row);
                DataRow[] drs;
                if (Entity.Prescription.IsGroup(dt, mPres.PresNo, mPres.Group_Id, out drs))
                {
                    for (int i = 0; i < drs.Length; i++)
                    {
                        Entity.Prescription _pres = ConvertDataExtend.ToObject<Entity.Prescription>(drs[i]);
                        _pres.Frequency_Id = mPres.Frequency_Id;
                        _pres.Frequency_Name = mPres.Frequency_Name;
                        _pres.Frequency_Caption = mPres.Frequency_Caption;
                        _pres.Frequency_ExecNum = mPres.Frequency_ExecNum;
                        _pres.Frequency_CycleDay = mPres.Frequency_CycleDay;
                        drs[i]["ExecNum"] = drs[0]["ExecNum"];
                        drs[i]["Memo"] = drs[0]["Memo"];

                        _pres.CalculateAmount(null);//计算数量 和 金额

                        ConvertDataExtend.UpdateDataTable(drs[i], _pres);
                    }
                }
            }
            else if (colIndex == iPrescriptionControl.AllColumnIndex.DosageIndex)//中药剂数
            {
                Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(dt, rowIndex);

                mPres.Dosage_S = dt.Rows[rowIndex]["Dosage_S"].ToString();
                mPres.CalculateAmount(null);//计算数量 和 金额
                //mPres.Status = PresStatus.编辑状态;
                ConvertDataExtend.UpdateDataTable(dt, rowIndex, mPres);

                DataRow[] drs = dt.Select("PresNo=" + mPres.PresNo + " and Item_Name<>'小计：'");
                for (int i = 0; i < drs.Length; i++)
                {
                    Entity.Prescription _pres = ConvertDataExtend.ToObject<Entity.Prescription>(drs[i]);
                    _pres.Dosage_S = mPres.Dosage.ToString();
                    _pres.CalculateAmount(null);//计算数量 和 金额
                    ConvertDataExtend.UpdateDataTable(drs[i], _pres);
                }
            }
            else if (colIndex == iPrescriptionControl.AllColumnIndex.DaysIndex)//天数
            {
                Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(dt, rowIndex);

                mPres.Days_S = dt.Rows[rowIndex]["Days_S"].ToString();
                mPres.CalculateAmount(null);//计算数量 和 金额
                //mPres.Status = PresStatus.编辑状态;
                ConvertDataExtend.UpdateDataTable(dt, rowIndex, mPres);

                DataRow[] drs;
                if (Entity.Prescription.IsGroup(dt, mPres.PresNo, mPres.Group_Id, out drs))
                {
                    for (int i = 0; i < drs.Length; i++)
                    {
                        Entity.Prescription _pres = ConvertDataExtend.ToObject<Entity.Prescription>(drs[i]);
                        _pres.Days_S = mPres.Days.ToString();
                        drs[i]["ExecNum"] = drs[0]["ExecNum"];
                        drs[i]["Memo"] = drs[0]["Memo"];
                        _pres.CalculateAmount(null);//计算数量 和 金额

                        ConvertDataExtend.UpdateDataTable(drs[i], _pres);
                    }
                }
            }
            else if (colIndex == iPrescriptionControl.AllColumnIndex.ItemAmountIndex)//开药数量
            {
                Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(dt, rowIndex);

                mPres.Item_Amount_S = dt.Rows[rowIndex]["Item_Amount_S"].ToString();

                ////甲类药品
                //if (mPres.MedicareID == 1)
                //{
                //    //计算天数
                //    mPres.CalculateDays();
                //}

                mPres.CalculateItemMoney();//计算数量 和 金额
                //mPres.Status = PresStatus.编辑状态;
                ConvertDataExtend.UpdateDataTable(dt, rowIndex, mPres);
            }
            else if (colIndex == iPrescriptionControl.AllColumnIndex.ItemUnitIndex)//开药单位
            {
                ItemUnitRowValue(dt, rowIndex, row);
            }
            else if (colIndex == iPrescriptionControl.AllColumnIndex.EntrustIndex)//嘱托
            {
                dt.Rows[rowIndex]["Entrust"] = ConvertDataExtend.ToString(row["Name"], "");
            }
            int presNo = Convert.ToInt32(dt.Rows[rowIndex]["PresNo"]);
            dt = ReCaclSmallSum(presNo, dt);
        }

        //自动换方规则(保存就会换方)
        private void AutoChangePresRule()
        {
            //执行科室发生变更，是否更换处方
            //处方类型发生变更，是否更换处方
            //五种药品自动换方
        }

        private DataTable ReCaclSmallSum(int presNo, DataTable dtPres)
        {
            DataRow[] drArrDetail = dtPres.Select("PresNo=" + presNo + " and Item_Name<>'小计：'");
            decimal moneySum = 0;
            foreach (DataRow row in drArrDetail)
            {
                decimal money = 0;
                if (decimal.TryParse(row["Item_Money"].ToString(), out money)) { }
                moneySum += money;
            }
            DataRow[] drArr = dtPres.Select("PresNo=" + presNo + " and Item_Name='小计：'");
            if (drArr.Length > 0)
            {
                drArr[0]["Item_Money"] = moneySum;
            }
            return dtPres;
        }

        //科室不同换方处理
        private bool AutoChangePres(int presNo, Entity.Prescription DrugPres, DataTable presdt, int rowIndex, out int newIndex)
        {
            bool bRtn = false;
            int prescriptionStyle = (int)iPrescriptionControl.PrescriptionStyle;
            int presCount = iPrescriptionControl.PresCount;
            int execDeptId = DrugPres.Dept_Id;
            int listNo = presNo;
            newIndex = rowIndex;
            if (prescriptionStyle == 1)//西药处方
            {
                //根据当前方号过滤本张处方数据
                DataTable dtTemp = presdt.Copy();
                DataView dv = dtTemp.DefaultView;
                dv.RowFilter = "PresNo=" + listNo + "";
                DataTable dtPres = dv.ToTable();
                if (dtPres.Rows.Count > 1)
                {
                    int preExecId = Convert.ToInt32(dtPres.Rows[0]["Dept_Id"]);
                    if (preExecId != execDeptId)
                    {
                        if (rowIndex == presdt.Rows.Count - 1)
                        {
                            //if (iPrescriptionControl.PromptController("执行科室发生变更，是否更换处方？") == true)
                            //{
                            bRtn = true;
                            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(presdt);//这段代码太耗时  
                                                                                                                       //添加小计
                                                                                                                       //计算小计
                            decimal moneySum = 0;
                            foreach (DataRow row in dtPres.Rows)
                            {
                                decimal money = 0;
                                if (decimal.TryParse(row["Item_Money"].ToString(), out money)) { }
                                moneySum += money;
                            }

                            Entity.Prescription prescription0 = Entity.Prescription.AddPresSubtotal(DrugPres.PresNo, 2, moneySum.ToString(), PresStatus.编辑状态);
                            listPres[rowIndex] = prescription0;
                            DrugPres.PresNo = DrugPres.PresNo + 1;
                            listPres.Add(DrugPres);

                            Entity.Prescription.CalculateAllNo(listPres);

                            ConvertDataExtend.UpdateDataTable<Entity.Prescription>(presdt, listPres);

                            iPrescriptionControl.SetGridCurrentCell(rowIndex + 1, iPrescriptionControl.AllColumnIndex.ItemIdIndex);
                            for (int index = 0; index < presdt.Rows.Count; index++)
                            {
                                SetCellColor(index, -1);
                            }
                            newIndex = rowIndex + 1;
                            //}
                            //else
                            //{
                            //    bRtn = true;
                            //    ConvertDataExtend.UpdateDataTable(presdt, rowIndex, DrugPres);
                            //}
                        }
                        else
                        {
                            throw new Exception("执行科室不同不能插入！");
                        }
                    }
                }
            }
            return bRtn;
        }


        //科室医保类型不同换方处理
        private bool AutoChangePresByMedicareType(int presNo, Entity.Prescription DrugPres, DataTable presdt, int rowIndex, out int newIndex)
        {
            bool bRtn = false;
            int prescriptionStyle = (int)iPrescriptionControl.PrescriptionStyle;
            int listNo = presNo;
            newIndex = rowIndex;
            if (prescriptionStyle == 1)//西药处方
            {
                //根据当前方号过滤本张处方数据
                DataTable dtTemp = presdt.Copy();
                DataView dv = dtTemp.DefaultView;
                dv.RowFilter = "PresNo=" + listNo + " and medicareID in(1,2,3)";
                DataTable dtPres = dv.ToTable();
                if (dtPres.Rows.Count > 0)
                {
                    int medicareID = Convert.ToInt32(dtPres.Rows[0]["MedicareID"]);
                    if ((medicareID==1|| medicareID==2) && DrugPres.MedicareID == 3|| (medicareID==3&& (DrugPres.MedicareID==1|| DrugPres.MedicareID==2)))
                    {
                        if (rowIndex == presdt.Rows.Count - 1)
                        {
                            //if (iPrescriptionControl.PromptController("执行科室发生变更，是否更换处方？") == true)
                            //{
                            bRtn = true;
                            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(presdt);//这段代码太耗时  
                                                                                                                       //添加小计
                                                                                                                       //计算小计
                            decimal moneySum = 0;
                            foreach (DataRow row in dtPres.Rows)
                            {
                                decimal money = 0;
                                if (decimal.TryParse(row["Item_Money"].ToString(), out money)) { }
                                moneySum += money;
                            }

                            Entity.Prescription prescription0 = Entity.Prescription.AddPresSubtotal(DrugPres.PresNo, 2, moneySum.ToString(), PresStatus.编辑状态);
                            listPres[rowIndex] = prescription0;
                            DrugPres.PresNo = DrugPres.PresNo + 1;
                            listPres.Add(DrugPres);

                            Entity.Prescription.CalculateAllNo(listPres);

                            ConvertDataExtend.UpdateDataTable<Entity.Prescription>(presdt, listPres);

                            iPrescriptionControl.SetGridCurrentCell(rowIndex + 1, iPrescriptionControl.AllColumnIndex.ItemIdIndex);
                            for (int index = 0; index < presdt.Rows.Count; index++)
                            {
                                SetCellColor(index, -1);
                            }
                            newIndex = rowIndex + 1;
                            //}
                            //else
                            //{
                            //    bRtn = true;
                            //    ConvertDataExtend.UpdateDataTable(presdt, rowIndex, DrugPres);
                            //}
                        }
                        else
                        {
                            throw new Exception("医保甲乙类和丙类不同不能插入！");
                        }
                    }
                }
            }
            return bRtn;
        }

        //皮试药品处理
        private void SkinTestDrug(List<Entity.Prescription> listPres, int presNo, Entity.Prescription SkinTestDrugPres)
        {
            //提示皮试药品
            if (iPrescriptionControl.PromptController("【" + SkinTestDrugPres.Item_Name + "】是皮试药品，是否需要皮试？") == true)
            {
                Entity.Prescription mPres = (Entity.Prescription)SkinTestDrugPres.Clone();
                mPres.PresNo = listPres.Max(x => x.PresNo) + 1;
                mPres.OrderNo = 1;
                mPres.Group_Id = 1;
                mPres.GroupSortNO = 1;
                mPres.Status = PresStatus.编辑状态;

                mPres.SkinTest_Flag = 1;
                SkinTestDrugPres.SkinTest_Flag = 1;
                //皮试药品默认用量、用法、频次
                mPres.Usage_Amount = 0.01M;

                DataRow[] drsU = CardDataSource.Tables["usagedic"].Select("UsageName like '%皮试%'");
                if (drsU.Length > 0)
                {
                    mPres.Usage_Id = Convert.ToInt32(drsU[0]["UsageId"]);
                    mPres.Usage_Name = drsU[0]["UsageName"].ToString();
                }
                else
                {
                    mPres.Usage_Id = 0;
                    mPres.Usage_Name = "";
                }
                DataRow[] drsF = CardDataSource.Tables["frequencydic"].Select("Name like '%st%'");
                if (drsF.Length > 0)
                {
                    mPres.Frequency_Id = Convert.ToInt32(drsF[0]["FrequencyId"]);
                    mPres.Frequency_Name = drsF[0]["Name"].ToString();
                }
                else
                {
                    mPres.Frequency_Id = 0;
                    mPres.Frequency_Name = "";
                }
                mPres.Frequency_Caption = "";//频次名称
                mPres.Frequency_ExecNum = 1;//执行次数
                mPres.Frequency_CycleDay = 1;//执行周期
                mPres.Item_Amount = 1;
                List<CardDataSourceUnit> unitList = PrescripttionDataSource.GetUnit(mPres.Item_Id, 1);
                foreach (CardDataSourceUnit m in unitList)
                {
                    if (m.Factor == 1)
                    {
                        mPres.Item_Unit = m.UnitName;
                        mPres.Item_Rate = (int)m.Factor;
                        break;
                    }
                }
                mPres.CalculateItemMoney();
                //添加盐水
                int actDrugid = PrescripttionDataSource.GetActDrugID();
                if (actDrugid > 0)
                {
                    CardDataSourceDrugItem drugItemsModel = PrescripttionDataSource.GetDrugItem(actDrugid);

                    if (drugItemsModel != null)
                    {
                        Entity.Prescription SaltPres = (Entity.Prescription)mPres.Clone();
                        DataRow row = ConvertDataExtend.ToDataRow(drugItemsModel);
                        SaltPres.PresNo = mPres.PresNo;
                        SaltPres.PresHeadId = 0;
                        SaltPres.PresListId = 0;
                        SaltPres.Group_Id = 1;
                        mPres.OrderNo = 2;
                        SaltPres.GroupSortNO = 2;
                        SaltPres.SelfDrug_Flag = Convert.ToInt32(0);//自备
                        SaltPres.Pres_Date = Convert.ToDateTime(DateTime.Now);
                        SaltPres.Pres_Doc = iPrescriptionControl.PresDoctorId;
                        SaltPres.Pres_DocName = iPrescriptionControl.PresDoctorName;
                        SaltPres.Pres_Dept = iPrescriptionControl.PresDeptCode;
                        SaltPres.Pres_DeptName = iPrescriptionControl.PresDeptName;
                        SaltPres.Item_Id = ConvertDataExtend.ToInt32(row["ItemId"], -1);
                        SaltPres.Item_Name = ConvertDataExtend.ToString(row["ItemName"], "");
                        SaltPres.Item_Type = Convert.ToInt32(row["ItemType"]);//1西药 2中药 3项目材料
                        SaltPres.StatItem_Code = ConvertDataExtend.ToString(row["StatItemCode"], ""); ;
                        SaltPres.Sell_Price = ConvertDataExtend.ToDecimal(row["SellPrice"], 0);
                        SaltPres.Buy_Price = ConvertDataExtend.ToDecimal(row["BuyPrice"], 0);
                        SaltPres.Item_Price = ConvertDataExtend.ToDecimal(row["SellPrice"], 0);
                        SaltPres.Standard = ConvertDataExtend.ToString(row["Standard"], "");
                        SaltPres.Usage_Amount = ConvertDataExtend.ToDecimal(row["default_Usage_Amount"], 1);//剂量
                        SaltPres.Usage_Unit = ConvertDataExtend.ToString(row["DoseUnitName"], "");//剂量单位
                        SaltPres.Usage_Rate = Convert.ToDecimal(row["DoseConvertNum"]);//剂量系数
                        SaltPres.Dept_Name = ConvertDataExtend.ToString(row["ExecDeptName"], "");
                        SaltPres.Dept_Id = Convert.ToInt32(row["ExecDeptId"]);
                        SaltPres.Dosage = 0;
                        SaltPres.Usage_Id = Convert.ToInt32(row["default_Usage_Id"]);
                        SaltPres.Days = Convert.ToInt32(1);

                        SaltPres.Unit = ConvertDataExtend.ToString(row["UnPickUnit"], "");//发药单位

                        SaltPres.Item_Amount = Convert.ToInt32(1);//开药数量
                        SaltPres.Item_Unit = ConvertDataExtend.ToString(row["UnPickUnit"], "");//开药单位
                        SaltPres.Item_Rate = Convert.ToInt32(1);//系数

                        SaltPres.SkinTest_Flag = (int)SkinTestStatus.需要皮试;//皮试
                        SaltPres.SelfDrug_Flag = Convert.ToInt32(0);//自备
                        SaltPres.Entrust = "";//嘱托

                        SaltPres.FootNote = "";
                        SaltPres.Tc_Flag = 0;//套餐

                        SaltPres.Pres_Date = Convert.ToDateTime(DateTime.Now);



                        SaltPres.IsFloat = true;//row["RoundingMode"]

                        SaltPres.Usage_Amount = SaltPres.Usage_Amount <= 0 ? 1 : SaltPres.Usage_Amount;
                        SaltPres.CalculateAmount(ConvertDataExtend.ToString(row["UnPickUnit"], ""));//计算数量 和 金额
                        SaltPres.Status = PresStatus.编辑状态;


                        SaltPres.Usage_Id = mPres.Usage_Id;
                        SaltPres.Usage_Name = mPres.Usage_Name;

                        SaltPres.Frequency_Id = mPres.Frequency_Id;
                        SaltPres.Frequency_Name = mPres.Frequency_Name;

                        SaltPres.Frequency_Caption = "";//频次名称
                        SaltPres.Frequency_ExecNum = 1;//执行次数
                        SaltPres.Frequency_CycleDay = 1;//执行周期
                        SaltPres.Item_Amount = 1;
                        SaltPres.CalculateItemMoney();
                        decimal totalMoney = Convert.ToDecimal(SaltPres.Item_Money) + Convert.ToDecimal(mPres.Item_Money);
                        //添加小计
                        Entity.Prescription prescription0 = Entity.Prescription.AddPresSubtotal(mPres.PresNo, 3, totalMoney.ToString(), PresStatus.编辑状态);

                        int pos = listPres.FindIndex(x => x.PresNo == presNo);
                        listPres.Insert(pos, mPres);
                        listPres.Insert(pos + 1, SaltPres);
                        listPres.Insert(pos + 2, prescription0);
                    }
                    else
                    {
                        //添加小计
                        Entity.Prescription prescription0 = Entity.Prescription.AddPresSubtotal(mPres.PresNo, 2, mPres.Item_Money, PresStatus.编辑状态);

                        int pos = listPres.FindIndex(x => x.PresNo == presNo);
                        listPres.Insert(pos, mPres);
                        listPres.Insert(pos + 1, prescription0);
                    }
                }
                else
                {

                    //添加小计
                    Entity.Prescription prescription0 = Entity.Prescription.AddPresSubtotal(mPres.PresNo, 2, mPres.Item_Money, PresStatus.编辑状态);

                    int pos = listPres.FindIndex(x => x.PresNo == presNo);
                    listPres.Insert(pos, mPres);
                    listPres.Insert(pos + 1, prescription0);
                }
            }
            else
            {
                SkinTestDrugPres.SkinTest_Flag = 4;
            }
            //两种情况，在现有处方中插入皮试药品，还有新开皮试药品
        }

        //皮试药品处理
        private void SkinTestDrugTpl(List<Entity.Prescription> listPres, int presNo, Entity.Prescription SkinTestDrugPres)
        {
            //提示皮试药品
            if (iPrescriptionControl.PromptController("【" + SkinTestDrugPres.Item_Name + "】是皮试药品，是否需要皮试？") == true)
            {
                Entity.Prescription mPres = (Entity.Prescription)SkinTestDrugPres.Clone();
                mPres.PresNo = presNo + 1;
                mPres.OrderNo = 1;
                mPres.Group_Id = 1;
                mPres.GroupSortNO = 1;
                mPres.Status = PresStatus.编辑状态;

                mPres.SkinTest_Flag = 1;
                SkinTestDrugPres.SkinTest_Flag = 1;
                //皮试药品默认用量、用法、频次
                mPres.Usage_Amount = 0.01M;

                DataRow[] drsU = CardDataSource.Tables["usagedic"].Select("UsageName like '%皮试%'");
                if (drsU.Length > 0)
                {
                    mPres.Usage_Id = Convert.ToInt32(drsU[0]["UsageId"]);
                    mPres.Usage_Name = drsU[0]["UsageName"].ToString();
                }
                else
                {
                    mPres.Usage_Id = 0;
                    mPres.Usage_Name = "";
                }
                DataRow[] drsF = CardDataSource.Tables["frequencydic"].Select("Name like '%st%'");
                if (drsF.Length > 0)
                {
                    mPres.Frequency_Id = Convert.ToInt32(drsF[0]["FrequencyId"]);
                    mPres.Frequency_Name = drsF[0]["Name"].ToString();
                }
                else
                {
                    mPres.Frequency_Id = 0;
                    mPres.Frequency_Name = "";
                }
                mPres.Frequency_Caption = "";//频次名称
                mPres.Frequency_ExecNum = 1;//执行次数
                mPres.Frequency_CycleDay = 1;//执行周期
                mPres.Item_Amount = 1;
                List<CardDataSourceUnit> unitList = PrescripttionDataSource.GetUnit(mPres.Item_Id, 1);
                foreach (CardDataSourceUnit m in unitList)
                {
                    if (m.Factor == 1)
                    {
                        mPres.Item_Unit = m.UnitName;
                        mPres.Item_Rate = (int)m.Factor;
                        break;
                    }
                }
                mPres.CalculateItemMoney();
                //添加盐水
                int actDrugid = PrescripttionDataSource.GetActDrugID();
                if (actDrugid > 0)
                {
                    CardDataSourceDrugItem drugItemsModel = PrescripttionDataSource.GetDrugItem(actDrugid);

                    if (drugItemsModel != null)
                    {
                        Entity.Prescription SaltPres = (Entity.Prescription)mPres.Clone();
                        DataRow row = ConvertDataExtend.ToDataRow(drugItemsModel);
                        SaltPres.PresNo = mPres.PresNo;
                        SaltPres.PresHeadId = 0;
                        SaltPres.PresListId = 0;
                        SaltPres.Group_Id = 1;
                        mPres.OrderNo = 2;
                        SaltPres.GroupSortNO = 2;
                        SaltPres.SelfDrug_Flag = Convert.ToInt32(0);//自备
                        SaltPres.Pres_Date = Convert.ToDateTime(DateTime.Now);
                        SaltPres.Pres_Doc = iPrescriptionControl.PresDoctorId;
                        SaltPres.Pres_DocName = iPrescriptionControl.PresDoctorName;
                        SaltPres.Pres_Dept = iPrescriptionControl.PresDeptCode;
                        SaltPres.Pres_DeptName = iPrescriptionControl.PresDeptName;
                        SaltPres.Item_Id = ConvertDataExtend.ToInt32(row["ItemId"], -1);
                        SaltPres.Item_Name = ConvertDataExtend.ToString(row["ItemName"], "");
                        SaltPres.Item_Type = Convert.ToInt32(row["ItemType"]);//1西药 2中药 3项目材料
                        SaltPres.StatItem_Code = ConvertDataExtend.ToString(row["StatItemCode"], ""); ;
                        SaltPres.Sell_Price = ConvertDataExtend.ToDecimal(row["SellPrice"], 0);
                        SaltPres.Buy_Price = ConvertDataExtend.ToDecimal(row["BuyPrice"], 0);
                        SaltPres.Item_Price = ConvertDataExtend.ToDecimal(row["SellPrice"], 0);
                        SaltPres.Standard = ConvertDataExtend.ToString(row["Standard"], "");
                        SaltPres.Usage_Amount = ConvertDataExtend.ToDecimal(row["default_Usage_Amount"], 1);//剂量
                        SaltPres.Usage_Unit = ConvertDataExtend.ToString(row["DoseUnitName"], "");//剂量单位
                        SaltPres.Usage_Rate = Convert.ToDecimal(row["DoseConvertNum"]);//剂量系数
                        SaltPres.Dept_Name = ConvertDataExtend.ToString(row["ExecDeptName"], "");
                        SaltPres.Dept_Id = Convert.ToInt32(row["ExecDeptId"]);
                        SaltPres.Dosage = 0;
                        SaltPres.Usage_Id = Convert.ToInt32(row["default_Usage_Id"]);
                        SaltPres.Days = Convert.ToInt32(1);

                        SaltPres.Unit = ConvertDataExtend.ToString(row["UnPickUnit"], "");//发药单位

                        SaltPres.Item_Amount = Convert.ToInt32(1);//开药数量
                        SaltPres.Item_Unit = ConvertDataExtend.ToString(row["UnPickUnit"], "");//开药单位
                        SaltPres.Item_Rate = Convert.ToInt32(1);//系数

                        SaltPres.SkinTest_Flag = (int)SkinTestStatus.需要皮试;//皮试
                        SaltPres.SelfDrug_Flag = Convert.ToInt32(0);//自备
                        SaltPres.Entrust = "";//嘱托

                        SaltPres.FootNote = "";
                        SaltPres.Tc_Flag = 0;//套餐

                        SaltPres.Pres_Date = Convert.ToDateTime(DateTime.Now);



                        SaltPres.IsFloat = true;//row["RoundingMode"]

                        SaltPres.Usage_Amount = SaltPres.Usage_Amount <= 0 ? 1 : SaltPres.Usage_Amount;
                        SaltPres.CalculateAmount(ConvertDataExtend.ToString(row["UnPickUnit"], ""));//计算数量 和 金额
                        SaltPres.Status = PresStatus.编辑状态;


                        SaltPres.Usage_Id = mPres.Usage_Id;
                        SaltPres.Usage_Name = mPres.Usage_Name;

                        SaltPres.Frequency_Id = mPres.Frequency_Id;
                        SaltPres.Frequency_Name = mPres.Frequency_Name;

                        SaltPres.Frequency_Caption = "";//频次名称
                        SaltPres.Frequency_ExecNum = 1;//执行次数
                        SaltPres.Frequency_CycleDay = 1;//执行周期
                        SaltPres.Item_Amount = 1;
                        SaltPres.CalculateItemMoney();
                        decimal totalMoney = Convert.ToDecimal(SaltPres.Item_Money) + Convert.ToDecimal(mPres.Item_Money);
                        //添加小计
                        Entity.Prescription prescription0 = Entity.Prescription.AddPresSubtotal(mPres.PresNo, 3, totalMoney.ToString(), PresStatus.编辑状态);

                        int pos = listPres.FindIndex(x => x.PresNo == presNo);
                        listPres.Insert(pos, mPres);
                        listPres.Insert(pos + 1, SaltPres);
                        listPres.Insert(pos + 2, prescription0);
                    }
                    else
                    {
                        //添加小计
                        Entity.Prescription prescription0 = Entity.Prescription.AddPresSubtotal(mPres.PresNo, 2, mPres.Item_Money, PresStatus.编辑状态);

                        int pos = listPres.FindIndex(x => x.PresNo == presNo);
                        listPres.Insert(pos, mPres);
                        listPres.Insert(pos + 1, prescription0);
                    }
                }
                else
                {

                    //添加小计
                    Entity.Prescription prescription0 = Entity.Prescription.AddPresSubtotal(mPres.PresNo, 2, mPres.Item_Money, PresStatus.编辑状态);

                    int pos = listPres.FindIndex(x => x.PresNo == presNo);
                    listPres.Insert(pos, mPres);
                    listPres.Insert(pos + 1, prescription0);
                }
            }
            else
            {
                SkinTestDrugPres.SkinTest_Flag = 4;
            }
            //两种情况，在现有处方中插入皮试药品，还有新开皮试药品
        }
        //写行记录(药品项目)
        private void ItemWriteRowValue(DataTable presdt, int rowIndex, DataRow row)
        {

            //赋值
            Entity.Prescription mPres = ItemWritePresRowValue(presdt, rowIndex, row);


            //设置网格内容样式和只读
            SetCellColor(iPrescriptionControl.GridRowIndex, -1);
            SettingReadOnly(iPrescriptionControl.GridRowIndex);


            //对于项目，当上一个行的执行科室是它的可执行科室，则沿用上一行的执行科室

            //药品取同组上一条的频次和用法，中药去同处方的付数、频次和用法
            if (rowIndex - 1 >= 0 && Convert.ToInt32(presdt.Rows[rowIndex - 1]["PresNo"]) == mPres.PresNo && Convert.ToInt32(presdt.Rows[rowIndex - 1]["Group_Id"]) == mPres.Group_Id)
            {
                Entity.Prescription mPres_head = ConvertDataExtend.ToObject<Entity.Prescription>(presdt, rowIndex - 1);
                mPres.Usage_Id = mPres_head.Usage_Id;
                mPres.Usage_Name = mPres_head.Usage_Name;
                mPres.Frequency_Id = mPres_head.Frequency_Id;
                mPres.Frequency_Name = mPres_head.Frequency_Name;
                mPres.Frequency_Caption = mPres_head.Frequency_Caption;
                mPres.Frequency_CycleDay = mPres_head.Frequency_CycleDay;
                mPres.Frequency_ExecNum = mPres_head.Frequency_ExecNum;

                mPres.Days = mPres_head.Days;

                mPres.CalculateAmount(null);

                ConvertDataExtend.UpdateDataTable(presdt, rowIndex, mPres);
            }

        }

        //为处方行赋值
        private Entity.Prescription ItemWritePresRowValue(DataTable presdt, int rowIndex, DataRow row)
        {


            Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(presdt, rowIndex);

            mPres.Item_Id = ConvertDataExtend.ToInt32(row["ItemId"], -1);
            mPres.Item_Name = ConvertDataExtend.ToString(row["ItemName"], "");
            mPres.Item_Type = Convert.ToInt32(row["ItemType"]);//1西药 2中药 3项目材料
            mPres.StatItem_Code = ConvertDataExtend.ToString(row["StatItemCode"], ""); ;
            mPres.Sell_Price = ConvertDataExtend.ToDecimal(row["SellPrice"], 0);
            mPres.Buy_Price = ConvertDataExtend.ToDecimal(row["BuyPrice"], 0);
            mPres.Item_Price = ConvertDataExtend.ToDecimal(row["SellPrice"], 0);
            mPres.Standard = ConvertDataExtend.ToString(row["Standard"], "");
            mPres.Usage_Amount = ConvertDataExtend.ToDecimal(row["default_Usage_Amount"], 0);//剂量
            mPres.Usage_Unit = ConvertDataExtend.ToString(row["DoseUnitName"], "");//剂量单位
            mPres.Usage_Rate = Convert.ToDecimal(row["DoseConvertNum"]);//剂量系数
            mPres.Dept_Name = ConvertDataExtend.ToString(row["ExecDeptName"], "");
            mPres.Dept_Id = Convert.ToInt32(row["ExecDeptId"]);
            mPres.MedicareID = Convert.ToInt32(row["MedicareID"]);
            if (ConvertDataExtend.ToInt32(row["VirulentFlag"], 0) == 1 || ConvertDataExtend.ToInt32(row["LunacyFlag"], 0) == 1)
            {
                mPres.IsLunacyPosion = 1;
            }
            else
            {
                mPres.IsLunacyPosion = 0;
            }
            if (mPres.IsHerb)
            {
                mPres.Dosage = 1;//付数
                if (rowIndex > 0)
                {
                    int preRowIndex = rowIndex - 1;
                    Entity.Prescription prePres = ConvertDataExtend.ToObject<Entity.Prescription>(presdt, preRowIndex);
                    if (prePres.PresNo == mPres.PresNo)
                    {
                        mPres.Dosage = prePres.Dosage;
                    }
                }

            }

            else
                mPres.Dosage = 0;
            mPres.Usage_Id = Convert.ToInt32(row["default_Usage_Id"]);
            mPres.Frequency_Id = Convert.ToInt32(row["default_Frequency_Id"]);
            mPres.Days = Convert.ToInt32(1);

            //mPres.Amount = 0;//发药数量
            mPres.Unit = ConvertDataExtend.ToString(row["MiniUnit"], "");//发药单位

            mPres.Item_Amount = Convert.ToInt32(1);//开药数量
            if (mPres.Item_Type == 2)
            {
                if (Convert.ToInt32(row["ResolveFlag"]) == 1)
                {
                    mPres.Item_Unit = ConvertDataExtend.ToString(row["MiniUnit"], "");//开药单位
                    mPres.Item_Rate = 1;//系数
                }
                else
                {
                    mPres.Item_Unit = ConvertDataExtend.ToString(row["UnPickUnit"], "");//开药单位
                    mPres.Item_Rate = Convert.ToInt32(row["PresFactor"]);//系数
                }
            }
            else
            {
                mPres.Item_Unit = ConvertDataExtend.ToString(row["UnPickUnit"], "");//开药单位
                mPres.Item_Rate = Convert.ToInt32(row["PresFactor"]);//系数
            }
           

            mPres.SkinTest_Flag = (int)SkinTestStatus.不需要皮试;//皮试
            mPres.SelfDrug_Flag = Convert.ToInt32(0);//自备
            mPres.Entrust = "";//嘱托

            mPres.FootNote = "";
            mPres.Tc_Flag = 0;//套餐

            mPres.Pres_Date = Convert.ToDateTime(DateTime.Now);

            mPres.Usage_Name = ConvertDataExtend.ToString(row["default_Usage_Name"], "");//用法名称
            mPres.Frequency_Name = ConvertDataExtend.ToString(row["default_Frequency_Name"], "");//频次名称

            string _caption = "";
            DataRow[] drs = CardDataSource.Tables["frequencydic"].Select("FrequencyId=" + mPres.Usage_Id);
            if (drs.Length > 0)
                _caption = drs[0]["Caption"].ToString();

            //string _caption = CardDataSource.Tables["frequencydic"].Select("FrequencyId=" + mPres.Usage_Id)[0]["Caption"].ToString();
            mPres.Frequency_Caption = _caption;//频次名称

            int _execNum, _cycleDay;
            CardDataSourceFrequency.Calculate(_caption, out _execNum, out _cycleDay);
            mPres.Frequency_ExecNum = _execNum;//执行次数
            mPres.Frequency_CycleDay = _cycleDay;//执行周期
            if (ConvertDataExtend.ToInt32(row["FloatFlag"], 0) == 0)
            {
                mPres.IsFloat = true;
            }
            else
            {
                mPres.IsFloat = false;
            }

            mPres.Usage_Amount = mPres.Usage_Amount <= 0 ? 0 : mPres.Usage_Amount;
            if (mPres.Item_Type == 2)
            {
                if (Convert.ToInt32(row["ResolveFlag"]) == 1)
                {
                    mPres.CalculateAmount(ConvertDataExtend.ToString(row["MiniUnit"], ""));//计算数量 和 金额
                }
                else
                {
                    mPres.CalculateAmount(ConvertDataExtend.ToString(row["UnPickUnit"], ""));//计算数量 和 金额
                }
            }
            else
            {
                mPres.CalculateAmount(ConvertDataExtend.ToString(row["UnPickUnit"], ""));//计算数量 和 金额
            }

            //mPres.Status = PresStatus.编辑状态;

            int newIndex = 0;
            bool bChangePres = false;
            bool bchangePresMedicare = false;
            bchangePresMedicare = AutoChangePresByMedicareType(mPres.PresNo, mPres, presdt, rowIndex, out newIndex);
            bChangePres = AutoChangePres(mPres.PresNo, mPres, presdt, rowIndex, out newIndex);

            //自动生成皮试处方
            if (Convert.ToInt32(row["SkinTestFlag"]) == 1)
            {
                List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(presdt);//这段代码太耗时
                listPres[newIndex] = mPres;
                SkinTestDrug(listPres, mPres.PresNo, mPres);

                if (mPres.SkinTest_Flag == 1)
                {
                    Entity.Prescription.CalculateAllNo(listPres);

                    //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
                    //iPrescriptionControl.SetGridCurrentCell(rowIndex + 2, iPrescriptionControl.AllColumnIndex.UsageAmountIndex);
                    ConvertDataExtend.UpdateDataTable<Entity.Prescription>(presdt, listPres);

                    iPrescriptionControl.SetGridCurrentCell(newIndex + 2, iPrescriptionControl.AllColumnIndex.ItemIdIndex);
                    for (int index = 0; index < presdt.Rows.Count; index++)
                    {
                        SettingReadOnly(index);
                        SetCellColor(index, -1);
                    }
                }
                else
                {
                    ConvertDataExtend.UpdateDataTable(presdt, newIndex, mPres);
                }
            }
            else
            {
                if (bChangePres != true&& bchangePresMedicare!=true)
                {
                    ConvertDataExtend.UpdateDataTable(presdt, rowIndex, mPres);
                }
            }
            return mPres;
        }

        private void UsageUnitRowValue(DataTable presdt, int rowIndex, DataRow row)
        {
            Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(presdt, rowIndex);

            mPres.Usage_Unit = ConvertDataExtend.ToString(row["UnitName"], "");
            mPres.Usage_Rate = ConvertDataExtend.ToDecimal(row["Factor"], 1);

            mPres.CalculateAmount(null);//计算数量 和 金额

            //mPres.Status = PresStatus.编辑状态;

            ConvertDataExtend.UpdateDataTable(presdt, rowIndex, mPres);
        }

        private Entity.Prescription UsageRowValue(DataTable presdt, int rowIndex, DataRow row)
        {
            Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(presdt, rowIndex);

            mPres.Usage_Id = ConvertDataExtend.ToInt32(row["UsageId"], 0);
            mPres.Usage_Name = ConvertDataExtend.ToString(row["UsageName"], "");

            //mPres.CalculateAmount(null);//计算数量 和 金额
            //mPres.Status = PresStatus.编辑状态;
            ConvertDataExtend.UpdateDataTable(presdt, rowIndex, mPres);

            return mPres;
        }

        private Entity.Prescription FrequencyRowValue(DataTable presdt, int rowIndex, DataRow row)
        {
            Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(presdt, rowIndex);

            mPres.Frequency_Id = ConvertDataExtend.ToInt32(row["FrequencyId"], 0);
            mPres.Frequency_Name = ConvertDataExtend.ToString(row["Name"], "");
            mPres.Frequency_Caption = ConvertDataExtend.ToString(row["Caption"], "");
            int _execNum, _cycleDay;
            CardDataSourceFrequency.Calculate(mPres.Frequency_Caption, out _execNum, out _cycleDay);
            mPres.Frequency_ExecNum = _execNum;// ConvertDataExtend.ToInt32(row["ExecNum"], 1);
            mPres.Frequency_CycleDay = _cycleDay;// ConvertDataExtend.ToInt32(row["CycleDay"], 1);

            mPres.CalculateAmount(null);//计算数量 和 金额
            //mPres.Status = PresStatus.编辑状态;
            ConvertDataExtend.UpdateDataTable(presdt, rowIndex, mPres);
            return mPres;
        }

        private void ItemUnitRowValue(DataTable presdt, int rowIndex, DataRow row)
        {
            Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(presdt, rowIndex);
            //自动换方 执行科室不同，条数超过最大数 在中间插入的执行科室不同给予提示

            int prescriptionStyle = (int)iPrescriptionControl.PrescriptionStyle;
            int presCount = iPrescriptionControl.PresCount;
            int execDeptId = mPres.Dept_Id;
            int listNo = mPres.PresNo;

            mPres.Item_Unit = ConvertDataExtend.ToString(row["UnitName"], "");
            mPres.Item_Rate = ConvertDataExtend.ToInt32(row["Factor"], 1);

            mPres.CalculateItemMoney();//计算金额
            //mPres.Status = PresStatus.编辑状态;
            ConvertDataExtend.UpdateDataTable(presdt, rowIndex, mPres);
            
            if (presCount > 0)
            {
                if (prescriptionStyle == 1)//西药处方
                {
                    //根据当前方号过滤本张处方数据
                    DataTable dtTemp = presdt.Copy();
                    DataView dv = dtTemp.DefaultView;
                    dv.RowFilter = "PresNo=" + listNo + "";
                    DataTable dtPres = dv.ToTable();
                    if (dtPres.Rows.Count > 1)
                    {

                        //大于最大条数自动换方
                        if (dtPres.Rows.Count >= presCount)
                        {
                            PresChange();
                        }

                    }
                }
            }
            if (presdt.Rows.Count > 0)
            {
                DataRow[] drArr = presdt.Select("MedicareID=1");
                if (drArr.Length > 2)
                {
                    decimal ItemSum = 0;
                    //求总金额
                    foreach (DataRow r in drArr)
                    {
                        ItemSum += Convert.ToDecimal(r["Item_Money"]);
                    }
                    if (ItemSum > 500)
                    {
                        PresChange();
                    }
                }
            }
        }
        #endregion

        //3.保存处方
        public void PresSave()
        {
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            //去掉空白行、小计行、处方状态除新建和修改之外
            listPres.RemoveAll(x => x.Item_Name == "" || x.Item_Name == null || x.Item_Name == "小计：" || (int)x.Status < 4);
            //判断是否还有数据
            if (listPres.Count == 0)
            {
                BindPresData();
                return;
            }

            //检查是否有下诊断
            if (iPrescriptionControl.CheckDisease() == false)
                return;

            //检查已经收费或退费的处方不能保存
            if (PrescripttionDataSource.IsCostPres(listPres.FindAll(x => x.Status == PresStatus.编辑状态)))
            {
                throw new Exception("处方已经收费不能再修改，请刷新病人处方！");
            }
            //检查药品库存是否足够
            List<Entity.Prescription> errlistPres = new List<Entity.Prescription>();
            if (PrescripttionDataSource.IsDrugStore(listPres.FindAll(x => x.IsDrug == true), errlistPres) == false)
            {
                string errDrugName = null;
                for (int i = 0; i < errlistPres.Count; i++)
                {
                    errDrugName += errlistPres[i].Item_Name + "\t" + errlistPres[i].Standard + "\t" + errlistPres[i].Item_Amount_S + errlistPres[i].Item_Unit_S + "\n";
                }

                throw new Exception("下列这些药品库存不够，请修改药品开药数量！\n\t" + errDrugName);
            }
            //检查药品的用法与频次不能为空
            List<Entity.Prescription> druglistPres = listPres.FindAll(x => x.IsDrug == true);
            string errDrugNameFD = null;
            for (int i = 0; i < druglistPres.Count; i++)
            {
                if (druglistPres[i].Usage_Id <= 0 || druglistPres[i].Frequency_Id <= 0)
                {
                    errDrugNameFD += druglistPres[i].Item_Name + "\t" + druglistPres[i].Standard + "\t" + druglistPres[i].Item_Amount_S + druglistPres[i].Item_Unit_S + "\n";
                }
            }
            if (errDrugNameFD != null)
            {
                throw new Exception("下列这些药品的用法与频次不能为空，请修改药品的用法与频次！\n\t" + errDrugNameFD);
            }

            errDrugNameFD = null;
            for (int i = 0; i < druglistPres.Count; i++)
            {
                if (druglistPres[i].Usage_Amount <= 0)
                {
                    errDrugNameFD += druglistPres[i].Item_Name + "\t" + druglistPres[i].Standard + "\t" + druglistPres[i].Item_Amount_S + druglistPres[i].Item_Unit_S + "\n";
                }
            }
            if (errDrugNameFD != null)
            {
                throw new Exception("下列这些药品的用量不能为空，请修改药品的用量！\n\t" + errDrugNameFD);
            }
            //检查甲类药品天数大于30天，不能保存
            if (iPrescriptionControl.DayGreater30 == 0)
            {                
                List<Entity.Prescription> druglistPres2 = listPres.FindAll(x => x.IsDrug == true);
                string errDrugNameFD2 = null;
                for (int i = 0; i < druglistPres2.Count; i++)
                {
                    //所有药品都反算天数
                    druglistPres2[i].CalculateDays();
                    //if (druglistPres2[i].MedicareID == 1)
                    //{
                    //    druglistPres2[i].CalculateDays();
                    //    //1.用实际天数，算出来是多少就是多少！
                    //    //2.如果一包可以满足30天或已经超30  第二包就提示不让开
                    //    //3.如果一包换算是不拆零 超过30天，可以提示
                    //    //if (druglistPres2[i].Days > 30)
                    //    //{
                    //    //    druglistPres2[i].Days = 30;
                    //    //}
                    //}
                    if (druglistPres2[i].MedicareID == 1 && druglistPres2[i].Days > 30)
                    {
                        errDrugNameFD2 += druglistPres2[i].Item_Name + "\t" + druglistPres2[i].Standard + "\t" + druglistPres2[i].Item_Amount_S + druglistPres2[i].Item_Unit_S + "\n";
                    }
                }
                if (errDrugNameFD2 != null)
                {
                    if (iPrescriptionControl.PromptController("【" + "下列这些药品的处方天数大于30天！\n\t" + errDrugNameFD2 + "】，是否确定开此药") == true)
                    {
                        //throw new Exception("下列这些药品的处方天数大于30天，不能保存处方！\n\t" + errDrugNameFD2);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            //保存数据
            List<Entity.Prescription> savelistPres = listPres.FindAll(x => (int)x.Status >= 4 && x.Item_Id > 0);

            int type = (int)iPrescriptionControl.PrescriptionStyle;
            Entity.Prescription.SavePrescriptionData(type, iPrescriptionControl.CurrPatListId, savelistPres);
            //累计常用药品项目
            //保存后调用处方联动费用
            iPrescriptionControl.SaveCostoflinkage(savelistPres);

            BindPresData();
        }

        //4.换方
        public void PresChange()
        {            
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);

            //如果没有记录返回
            if (listPres.Count == 0)
                return;
            //移除最后一行空白行
            if (string.IsNullOrEmpty(listPres[listPres.Count - 1].Item_Name))
                listPres.RemoveAt(listPres.Count - 1);

            Entity.Prescription.CalculateSubtotal(ref listPres);

            //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
            ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                SetCellColor(index, -1);
            }

            PresAddRow();
        }

        //5.删除处方
        public void PresDeleteRow()
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            //List删除一行
            if (iPrescriptionControl.PresDoctorId != listPres[rowIndex].Pres_Doc)//add by yjb 20161026
            {
                iPrescriptionControl.ShowMessage("不能删除其他医生的处方");
                return;
            }
            if (Convert.ToInt32(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["SkinTest_Flag"]) == 1 && iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Usage_Name"].ToString().Contains("皮试"))
            {
                iPrescriptionControl.ShowMessage("不能删除皮试处方的一行");
                return;
            }
            int presNo = Convert.ToInt32(dt.Rows[rowIndex]["PresNo"]);
            if (listPres[rowIndex].Status == PresStatus.收费状态 || listPres[rowIndex].Status == PresStatus.退费状态)
            {
                throw new Exception("处方已收费不能删除！");
            }
            if (PrescripttionDataSource.IsCostPres(listPres.FindAll(x => x.PresListId > 0 && x.PresListId == listPres[rowIndex].PresListId)))
            {
                throw new Exception("处方已经收费不能再删除，请刷新病人处方！");
            }

            if (iPrescriptionControl.PromptController("是否继续删除选定处方？") == true)
            {

                if (listPres[rowIndex].PresListId > 0)
                {
                    Entity.Prescription.DeletePrescriptionData(listPres[rowIndex].PresListId);

                }
                listPres.RemoveAt(rowIndex);

                //重新计算所有处方号与组号[方号与组号的设计不应该把序号保存到数据库，给程序设计带来麻烦]
                Entity.Prescription.CalculateAllNo(listPres);

                //List更新 DT
                //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
                ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    SetCellColor(index, -1);
                }
                iPrescriptionControl.SetGridCurrentCell(rowIndex - 1, iPrescriptionControl.AllColumnIndex.ItemNameIndex);

                dt = ReCaclSmallSum(presNo, dt);
                iPrescriptionControl.ShowMessage("删除处方成功");
            }
        }
        public void PresDeleteRowForChange(int rowNo)
        {
            int rowIndex = rowNo;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            if (iPrescriptionControl.PresDoctorId != listPres[rowIndex].Pres_Doc)//add by yjb 20161026
            {
                iPrescriptionControl.ShowMessage("不能删除其他医生的处方");
                return;
            }

            if (listPres[rowIndex].PresListId > 0)
            {
                Entity.Prescription.DeletePrescriptionData(listPres[rowIndex].PresListId);
            }
            listPres.RemoveAt(rowIndex);

            //重新计算所有处方号与组号[方号与组号的设计不应该把序号保存到数据库，给程序设计带来麻烦]
            Entity.Prescription.CalculateAllNo(listPres);

            //List更新 DT
            //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
            ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                SetCellColor(index, -1);
            }
            iPrescriptionControl.SetGridCurrentCell(rowIndex - 1, iPrescriptionControl.AllColumnIndex.ItemNameIndex);

        }
        //5.删除处方
        public void PresDeleteRow(int rowNo)
        {
            int rowIndex = rowNo;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            if (iPrescriptionControl.PresDoctorId != listPres[rowIndex].Pres_Doc)//add by yjb 20161026
            {
                iPrescriptionControl.ShowMessage("不能删除其他医生的处方");
                return;
            }
            //List删除一行
            if (listPres[rowIndex].Status == PresStatus.收费状态 || listPres[rowIndex].Status == PresStatus.退费状态)
            {
                throw new Exception("处方已收费不能删除！");
            }
            if (PrescripttionDataSource.IsCostPres(listPres.FindAll(x => x.PresListId > 0 && x.PresListId == listPres[rowIndex].PresListId)))
            {
                throw new Exception("处方已经收费不能再删除，请刷新病人处方！");
            }

            if (iPrescriptionControl.PromptController("是否继续删除选定处方？") == true)
            {

                if (listPres[rowIndex].PresListId > 0)
                {
                    Entity.Prescription.DeletePrescriptionData(listPres[rowIndex].PresListId);
                }
                listPres.RemoveAt(rowIndex);

                //重新计算所有处方号与组号[方号与组号的设计不应该把序号保存到数据库，给程序设计带来麻烦]
                Entity.Prescription.CalculateAllNo(listPres);

                //List更新 DT
                //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
                ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    SetCellColor(index, -1);
                }
                iPrescriptionControl.SetGridCurrentCell(rowIndex - 1, iPrescriptionControl.AllColumnIndex.ItemNameIndex);
            }
        }
        //删除整张处方
        public void PresDeleteNo()
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            if (iPrescriptionControl.PresDoctorId != listPres[rowIndex].Pres_Doc)//add by yjb 20161026
            {
                iPrescriptionControl.ShowMessage("不能删除其他医生的处方");
                return;
            }
            //List删除一行
            if (listPres[rowIndex].Status == PresStatus.收费状态 || listPres[rowIndex].Status == PresStatus.退费状态)
            {
                throw new Exception("处方已收费不能删除！");
            }
            if (PrescripttionDataSource.IsCostPres(listPres.FindAll(x => x.PresListId > 0 && x.PresNo == listPres[rowIndex].PresNo)))
            {
                throw new Exception("处方已经收费不能再删除，请刷新病人处方！");
            }

            if (iPrescriptionControl.PromptController("是否继续整张删除选定处方？") == true)
            {
                List<Entity.Prescription> _list = listPres.FindAll(x => x.PresListId > 0 && x.PresNo == listPres[rowIndex].PresNo);
                for (int i = 0; i < _list.Count; i++)
                {
                    Entity.Prescription.DeletePrescriptionData(_list[i].PresListId);
                }
                int _presno = listPres[rowIndex].PresNo;
                for (int i = 0; i < listPres.Count;)
                {
                    if (listPres[i].PresNo == _presno)
                    {
                        listPres.RemoveAt(i);
                    }
                    else
                        i++;
                }
                //重新计算所有处方号与组号[方号与组号的设计不应该把序号保存到数据库，给程序设计带来麻烦]
                Entity.Prescription.CalculateAllNo(listPres);

                //List更新 DT
                //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
                ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    SetCellColor(index, -1);
                }
                int _index = listPres.Count == 0 ? 0 : listPres.Count - 1;
                iPrescriptionControl.SetGridCurrentCell(_index, iPrescriptionControl.AllColumnIndex.ItemNameIndex);
                iPrescriptionControl.ShowMessage("删除处方成功");
            }
        }
        //6.插入
        public void PresInsertRow()
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            //List删除一行
            if (iPrescriptionControl.PresDoctorId != listPres[rowIndex].Pres_Doc)//add by yjb 20161026
            {
                iPrescriptionControl.ShowMessage("不能插入其他医生的处方");
                return;
            }
            if (Convert.ToInt32(iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["SkinTest_Flag"]) == 1 && iPrescriptionControl.PresGridDataSource.Rows[rowIndex]["Usage_Name"].ToString().Contains("皮试"))
            {
                iPrescriptionControl.ShowMessage("不能在皮试处方上插入");
                return;
            }
                int prescriptionStyle = (int)iPrescriptionControl.PrescriptionStyle;
            if (iPrescriptionControl.PresCount > 0)
            {
                if (prescriptionStyle == 1)//西药处方
                {
                    int presNo = listPres[rowIndex].PresNo;
                    List<Entity.Prescription> tempList = listPres.FindAll(x => x.PresNo == presNo);
                    if (tempList.Count > iPrescriptionControl.PresCount)
                    {
                        throw new Exception("处方已达最大数不能插入！");
                    }
                }
            }
            if (listPres[rowIndex].Status == PresStatus.收费状态 || listPres[rowIndex].Status == PresStatus.退费状态)
            {
                throw new Exception("处方已收费不能插入！");
            }
            if (PrescripttionDataSource.IsCostPres(listPres.FindAll(x => x.PresListId > 0 && x.PresNo == listPres[rowIndex].PresNo)))
            {
                throw new Exception("处方已经收费不能再插入，请刷新病人处方！");
            }

            int maxPresNo;
            int groupId;
            int maxOrderNO;

            Entity.Prescription.CalculateNewNo(listPres, rowIndex, out maxPresNo, out groupId, out maxOrderNO);
            if(dt.Rows.Count==1)
            {
                groupId = 2;
            }
            Entity.Prescription prescriptionNew = Entity.Prescription.AddPresNewRow(maxPresNo, groupId, maxOrderNO, iPrescriptionControl.PresDoctorId, iPrescriptionControl.PresDoctorName, iPrescriptionControl.PresDeptCode, iPrescriptionControl.PresDeptName);

            listPres.Insert(rowIndex + 1, prescriptionNew);
            //重新计算所有处方号与组号[方号与组号的设计不应该把序号保存到数据库，给程序设计带来麻烦]
            Entity.Prescription.CalculateAllNo(listPres);

            List<Entity.Prescription> _listAlter = listPres.FindAll(x => x.PresNo == maxPresNo);
            for (int i = 0; i < _listAlter.Count; i++)
            {
                //更新状态
                _listAlter[i].Status = PresStatus.编辑状态;
            }

            //List更新 DT
            //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
            ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                SetCellColor(index, -1);
            }
            SettingReadOnly(rowIndex + 1);
            iPrescriptionControl.SetGridCurrentCell(rowIndex + 1, iPrescriptionControl.AllColumnIndex.ItemIdIndex);
        }
        //7.合并组
        public void PresMergeGroup()
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);

            int[] rowIds = iPrescriptionControl.GridSelectedRows;
            if (rowIds.Length < 2)
                throw new Exception("处方合组必须两条记录以上才能合组！");

            int _presNo = listPres[rowIds[0]].PresNo;//合组方号
            int _groupNo = listPres[rowIds[0]].Group_Id;//合组方号
            if (iPrescriptionControl.PresDoctorId != listPres[rowIndex].Pres_Doc)//add by yjb 20161026
            {
                iPrescriptionControl.ShowMessage("不能合组其他医生的处方");
                return;
            }
            List<Entity.Prescription> _list = new List<Entity.Prescription>();
            //不能跨多张处方
            //只有西药才能分组
            for (int i = 0; i < rowIds.Length; i++)
            {
                if (listPres[rowIds[i]].PresNo != _presNo)
                    throw new Exception("处方合组不能跨多张处方！");

                if (listPres[rowIds[i]].IsDrug == false)
                    throw new Exception("处方合组只能是药品！");

                _list.Add(listPres[rowIds[i]]);
            }

            List<Entity.Prescription> _listGroup = _list.FindAll(x => x.Item_Name != "小计：");
            //分组必须两条以上
            if (_listGroup.Count < 2)
                throw new Exception("处方合组必须两条记录以上才能合组！");

            //List删除一行
            if (listPres[rowIndex].Status == PresStatus.收费状态 || listPres[rowIndex].Status == PresStatus.退费状态)
            {
                throw new Exception("处方已收费不能合组！");
            }

            if (PrescripttionDataSource.IsCostPres(_listGroup.FindAll(x => x.PresListId > 0)))
            {
                throw new Exception("处方已经收费不能再合组，请刷新病人处方！");
            }

            //取消原有合组
            List<Entity.Prescription> _cancellistGroup = listPres.FindAll(x => x.PresNo == _presNo && x.Group_Id == _groupNo);
            int index = 80;
            for (int i = 0; i < _cancellistGroup.Count; i++)
            {
                _cancellistGroup[i].Group_Id = index;
                index += 1;
            }
            //合组
            for (int i = 0; i < _listGroup.Count; i++)
            {
                _listGroup[i].Group_Id = 99;

                //统一用法、频次和天数
                _listGroup[i].Usage_Id = _listGroup[0].Usage_Id;
                _listGroup[i].Usage_Name = _listGroup[0].Usage_Name;
                _listGroup[i].Frequency_Id = _listGroup[0].Frequency_Id;
                _listGroup[i].Frequency_Name = _listGroup[0].Frequency_Name;
                _listGroup[i].Frequency_Caption = _listGroup[0].Frequency_Caption;
                _listGroup[i].Frequency_CycleDay = _listGroup[0].Frequency_CycleDay;
                _listGroup[i].Frequency_ExecNum = _listGroup[0].Frequency_ExecNum;
                _listGroup[i].GroupSortNO = i + 1;
                _listGroup[i].Days = _listGroup[0].Days;

                _listGroup[i].CalculateAmount(null);

                //_listGroup[i].Status = PresStatus.编辑状态;
            }

            //更新整张处方的状态
            List<Entity.Prescription> _listAlter = listPres.FindAll(x => x.PresNo == _presNo);
            for (int i = 0; i < _listAlter.Count; i++)
            {
                //更新状态
                _listAlter[i].Status = PresStatus.编辑状态;
            }


            //重新计算所有处方号与组号
            Entity.Prescription.CalculateAllNo(listPres);
            //List更新 DT
            //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
            ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);
            for (int _index = 0; _index < dt.Rows.Count; _index++)
            {
                SetCellColor(_index, -1);
            }
            iPrescriptionControl.SetGridCurrentCell(rowIndex, iPrescriptionControl.AllColumnIndex.ItemNameIndex);
        }
        //下移
        public void PresDownRow()
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            if (rowIndex < 0)
                return;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);

            int _presNo = listPres[rowIndex].PresNo;//合组方号
            int _groupNo = listPres[rowIndex].Group_Id;//合组组号
            int groupSortNo = listPres[rowIndex].GroupSortNO;//组内序号
            //不同医生不能修改
            if (iPrescriptionControl.PresDoctorId != listPres[rowIndex].Pres_Doc)//add by yjb 20161026
            {
                iPrescriptionControl.ShowMessage("不能移动其他医生的处方");
                return;
            }

            if (listPres[rowIndex].Status == PresStatus.收费状态 || listPres[rowIndex].Status == PresStatus.退费状态)
            {
                throw new Exception("处方已收费不能重整！");
            }

            //原有合组
            List<Entity.Prescription> listGroup = listPres.FindAll(x => x.PresNo == _presNo && x.Group_Id == _groupNo);
            if (listGroup.Count < 2)
                return;
            if (groupSortNo == listGroup[listGroup.Count - 1].GroupSortNO)
                return;
            int index = 0;

            for (int i = 0; i < listGroup.Count; i++)
            {
                if (listGroup[i].GroupSortNO == groupSortNo)
                {
                    index = i;
                    break;
                }
            }
            Entity.Prescription currentPres = listGroup[index];
            listGroup[index] = listGroup[index + 1];
            listGroup[index + 1] = currentPres;


            for (int i = 0; i < listGroup.Count; i++)
            {
                listGroup[i].GroupSortNO = i + 1;
            }

            //更新整张处方的状态
            int sortNo = 0;
            for (int i = 0; i < listPres.Count; i++)
            {
                if (listPres[i].PresNo == _presNo && listPres[i].Group_Id == _groupNo)
                {
                    listPres[i] = listGroup[sortNo];
                    sortNo = sortNo + 1;
                }
                if (listPres[i].PresNo == _presNo)
                {
                    //更新状态
                    listPres[i].Status = PresStatus.编辑状态;
                }
            }


            //重新计算所有处方号与组号
            Entity.Prescription.CalculateAllNo(listPres);
            ConvertDataExtend.UpdateDataTableForSort<Entity.Prescription>(dt, listPres);
            for (int _index = 0; _index < dt.Rows.Count; _index++)
            {
                SetCellColor(_index, -1);
            }
            iPrescriptionControl.SetGridCurrentCell(rowIndex + 1, iPrescriptionControl.AllColumnIndex.ItemNameIndex);
        }
        //上移
        public void PresUpRow()
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            if (rowIndex < 0)
                return;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);

            int _presNo = listPres[rowIndex].PresNo;//合组方号
            int _groupNo = listPres[rowIndex].Group_Id;//合组组号
            int groupSortNo = listPres[rowIndex].GroupSortNO;//组内序号
            //不同医生不能修改
            if (iPrescriptionControl.PresDoctorId != listPres[rowIndex].Pres_Doc)//add by yjb 20161026
            {
                iPrescriptionControl.ShowMessage("不能移动其他医生的处方");
                return;
            }

            if (listPres[rowIndex].Status == PresStatus.收费状态 || listPres[rowIndex].Status == PresStatus.退费状态)
            {
                throw new Exception("处方已收费不能重整！");
            }

            //原有合组
            List<Entity.Prescription> listGroup = listPres.FindAll(x => x.PresNo == _presNo && x.Group_Id == _groupNo);
            if (listGroup.Count < 2)
                return;
            if (groupSortNo == listGroup[0].GroupSortNO)
                return;
            int index = 0;

            for (int i = 0; i < listGroup.Count; i++)
            {
                if (listGroup[i].GroupSortNO == groupSortNo)
                {
                    index = i;
                    break;
                }
            }
            Entity.Prescription currentPres = listGroup[index];
            listGroup[index] = listGroup[index - 1];
            listGroup[index - 1] = currentPres;


            for (int i = 0; i < listGroup.Count; i++)
            {
                listGroup[i].GroupSortNO = i + 1;
            }

            //更新整张处方的状态
            int sortNo = 0;
            for (int i = 0; i < listPres.Count; i++)
            {
                if (listPres[i].PresNo == _presNo && listPres[i].Group_Id == _groupNo)
                {
                    listPres[i] = listGroup[sortNo];
                    sortNo = sortNo + 1;
                }
                if (listPres[i].PresNo == _presNo)
                {
                    //更新状态
                    listPres[i].Status = PresStatus.编辑状态;
                }
            }


            //重新计算所有处方号与组号
            Entity.Prescription.CalculateAllNo(listPres);
            ConvertDataExtend.UpdateDataTableForSort<Entity.Prescription>(dt, listPres);
            for (int _index = 0; _index < dt.Rows.Count; _index++)
            {
                SetCellColor(_index, -1);
            }
            iPrescriptionControl.SetGridCurrentCell(rowIndex - 1, iPrescriptionControl.AllColumnIndex.ItemNameIndex);
        }
        public void PresCancelGroup()
        {

            int rowIndex = iPrescriptionControl.GridRowIndex;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);

            int _presNo = listPres[rowIndex].PresNo;//合组方号
            int _groupNo = listPres[rowIndex].Group_Id;//合组方号

            List<Entity.Prescription> _cancellistGroup;
            if (Entity.Prescription.IsGroup(listPres, _presNo, _groupNo, out _cancellistGroup) == false)
                return;
            if (iPrescriptionControl.PresDoctorId != listPres[rowIndex].Pres_Doc)//add by yjb 20161026
            {
                iPrescriptionControl.ShowMessage("不能取消分组其他医生的处方");
                return;
            }
            //取消原有合组
            int index = 80;
            for (int i = 0; i < _cancellistGroup.Count; i++)
            {
                _cancellistGroup[i].Group_Id = index;
                index += 1;
                //更新状态
                _cancellistGroup[i].Status = PresStatus.编辑状态;
            }

            //重新计算所有处方号与组号
            Entity.Prescription.CalculateAllNo(listPres);
            //List更新 DT
            //iPrescriptionControl.LoadGridPresData(ConvertDataExtend.ToDataTableS<Entity.Prescription>(listPres));
            ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);
            for (int _index = 0; _index < dt.Rows.Count; _index++)
            {
                //更新状态
                SetCellColor(_index, -1);
            }
            if (listPres[rowIndex].PresListId > 0)
            {
                PresSave();
            }
            iPrescriptionControl.SetGridCurrentCell(rowIndex, iPrescriptionControl.AllColumnIndex.ItemNameIndex);
        }
        //8.复制处方
        public void PresCopy()
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            //检索处方list存入变量
            mCopyPres = listPres.FindAll(x => x.PresNo == listPres[rowIndex].PresNo && x.Item_Name != "小计：" && x.Item_Id != 0);

        }
        //9.粘贴处方
        public void PresPaste()
        {
            //判断待复制药品的转换系数是否已修改
            //判断皮试药品

            if (mCopyPres == null) return;
            additionalNewPres(mCopyPres);

            mCopyPres = null;
        }
        //处方另存为模板
        public List<Entity.Prescription> PresAsSaveModule()
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            //DT 转 List
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            //
            return listPres.FindAll(x => x.PresNo == listPres[rowIndex].PresNo && x.Item_Name != "小计：" && x.Item_Id != 0);
        }
        //10.自备
        public void PresSelfDrug(int currentColIndex)
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            //判断是否已收费
            Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(dt, rowIndex);
            int _selfFlag = mPres.SelfDrug_Flag;
            if (iPrescriptionControl.PresDoctorId != mPres.Pres_Doc)//add by yjb 20161101
            {
                return;
            }
            if (mPres.IsDrug == false)
            {
                throw new Exception("非药品处方不能自备！");
            }

            if (mPres.Status == PresStatus.收费状态 || mPres.Status == PresStatus.退费状态)
            {
                string errText = "处方已收费不能操作！";
                throw new Exception(errText);
            }
            List<Entity.Prescription> _list = new List<Entity.Prescription>();
            _list.Add(mPres);
            if (PrescripttionDataSource.IsCostPres(_list))
            {
                throw new Exception("处方已经收费不能再自备，请刷新病人处方！");
            }

            //更新状态
            mPres.SelfDrug_Flag = _selfFlag == 0 ? 1 : 0;
            mPres.CalculateItemMoney();//计算金额
            //mPres.Status = PresStatus.编辑状态;
            //直接更新到数据库
            if (mPres.PresListId > 0)
            {
                Entity.Prescription.UpdatePresSelfDrugFlag(mPres.PresListId, mPres.SelfDrug_Flag);

            }
            ConvertDataExtend.UpdateDataTable(dt, rowIndex, mPres);
            if (currentColIndex == iPrescriptionControl.AllColumnIndex.ItemNameIndex)
            {
                iPrescriptionControl.SetGridCurrentCell(rowIndex, iPrescriptionControl.AllColumnIndex.ItemNameIndex + 1);
            }
            else
            {
                iPrescriptionControl.SetGridCurrentCell(rowIndex, iPrescriptionControl.AllColumnIndex.ItemNameIndex);
            }
            int presNo = Convert.ToInt32(dt.Rows[rowIndex]["PresNo"]);
            dt = ReCaclSmallSum(presNo, dt);
            if (_selfFlag == 0)
            {
                iPrescriptionControl.ShowMessage("自备成功");
            }
            else
            {
                iPrescriptionControl.ShowMessage("取消自备成功");
            }

        }

        //医保保外用
        public void PresReimbursement(int currentColIndex)
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            //判断是否已收费
            Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(dt, rowIndex);
            int isReimbursement = mPres.IsReimbursement;
            if (iPrescriptionControl.PresDoctorId != mPres.Pres_Doc)//add by yjb 20161101
            {
                return;
            }
            if (mPres.IsDrug == false)
            {
                throw new Exception("非药品处方不能设置医保报销标识！");
            }
            //if (mPres.MedicareID == 0 || mPres.MedicareID == 3)
            //{
            //    throw new Exception("非甲乙类药品处方不能设置保外用标识！");
            //} 
            if (mPres.Status == PresStatus.收费状态 || mPres.Status == PresStatus.退费状态)
            {
                string errText = "处方已收费不能操作！";
                throw new Exception(errText);
            }
            List<Entity.Prescription> _list = new List<Entity.Prescription>();
            _list.Add(mPres);
            if (PrescripttionDataSource.IsCostPres(_list))
            {
                throw new Exception("处方已经收费不能再设置保外用，请刷新病人处方！");
            }
            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);
            //检索处方list存入变量
            List<Entity.Prescription> mdicarePresList = listPres.FindAll(x => x.PresNo == listPres[rowIndex].PresNo && x.Item_Name != "小计：" && x.Item_Id != 0);
            mPres.IsReimbursement = isReimbursement == 0 ? 1 : 0;
            for (int i=0;i< listPres.Count;i++)
            {
                //更新状态
                if (listPres[i].PresNo == listPres[rowIndex].PresNo && listPres[i].Item_Name != "小计：" && listPres[i].Item_Id != 0)
                {
                    listPres[i].IsReimbursement = isReimbursement == 0 ? 1 : 0;
                    listPres[i].CalculateItemMoney();//计算金额
                    
                    ConvertDataExtend.UpdateDataTable(dt, i, listPres[i]);
                }
            }
            if (mdicarePresList.Count > 0)
            {
                Entity.Prescription.UpdatePresReimbursement(mdicarePresList, mPres.IsReimbursement);
            }

            if (currentColIndex == iPrescriptionControl.AllColumnIndex.ItemNameIndex)
            {
                iPrescriptionControl.SetGridCurrentCell(rowIndex, iPrescriptionControl.AllColumnIndex.ItemNameIndex + 1);
            }
            else
            {
                iPrescriptionControl.SetGridCurrentCell(rowIndex, iPrescriptionControl.AllColumnIndex.ItemNameIndex);
            }
            int presNo = Convert.ToInt32(dt.Rows[rowIndex]["PresNo"]);
            dt = ReCaclSmallSum(presNo, dt);
            if (isReimbursement == 0)
            {
                iPrescriptionControl.ShowMessage("保外用设置成功");
            }
            else
            {
                iPrescriptionControl.ShowMessage("取消保外用成功");
            }

        }
        //11.打印处方
        public void PresPrint()
        {

        }
        //12.导入模板
        public void PresLoadTemplate(int tplId)
        {
            int type = (int)iPrescriptionControl.PrescriptionStyle;
            List<Entity.Prescription> list = PrescripttionDataSource.GetPresTemplate(type, tplId);
            additionalNewPresNew(list);
        }
        //导入多条
        public void PresLoadTemplateRow(int[] tpldetailIds)
        {
            int type = (int)iPrescriptionControl.PrescriptionStyle;
            List<Entity.Prescription> list = PrescripttionDataSource.GetPresTemplateRow(type, tpldetailIds);
            AddPresTplRow(list);
            //additionalNewPres(list);
        }
        //13.修改
        public void PresAlter()
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            if (rowIndex <= -1)
                return; 
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            //判断是否已收费
            Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(dt, rowIndex);

            if (mPres.Status == PresStatus.收费状态 || mPres.Status == PresStatus.退费状态)
            {
                return;
            }
            List<Entity.Prescription> _list = new List<Entity.Prescription>();
            _list.Add(mPres);
            if (PrescripttionDataSource.IsCostPres(_list))
            {
                throw new Exception("处方已经收费不能再修改，请刷新病人处方！");
            }

            List<Entity.Prescription> listPres = ConvertDataExtend.ToList<Entity.Prescription>(dt);

            List<Entity.Prescription> _listAlter = listPres.FindAll(x => x.PresNo == mPres.PresNo);
            for (int i = 0; i < _listAlter.Count; i++)
            {
                if (iPrescriptionControl.PresDoctorId == _listAlter[i].Pres_Doc)
                {
                    //更新状态
                    _listAlter[i].Status = PresStatus.编辑状态;
                }
            }


            ConvertDataExtend.UpdateDataTable<Entity.Prescription>(dt, listPres);

            for (int index = 0; index < dt.Rows.Count; index++)
            {
                SettingReadOnly(index);
                SetCellColor(index, -1);
            }
        }
        //本院注射次数
        public void PresInjectTimes(string menuText, int execTimes)
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            //判断是否已收费
            Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(dt, rowIndex);
            int _selfFlag = mPres.SelfDrug_Flag;
            if (iPrescriptionControl.PresDoctorId != mPres.Pres_Doc)//add by yjb 20161101
            {
                return;
            }
            if (mPres.IsDrug == false)
            {
                throw new Exception("非药品处方不能修改注射次数！");
            }

            if (mPres.Status == PresStatus.收费状态 || mPres.Status == PresStatus.退费状态)
            {
                string errText = "处方已收费不能操作！";
                throw new Exception(errText);
            }
            List<Entity.Prescription> _list = new List<Entity.Prescription>();
            _list.Add(mPres);
            if (PrescripttionDataSource.IsCostPres(_list))
            {
                throw new Exception("处方已经收费不能操作，请刷新病人处方！");
            }

            //更新本院注射次数
            mPres.Memo = menuText;
            mPres.ExecNum = execTimes;
            DataRow[] drs;
            if (Entity.Prescription.IsGroup(dt, mPres.PresNo, mPres.Group_Id, out drs))
            {
                for (int i = 0; i < drs.Length; i++)
                {
                    drs[i]["ExecNum"] = mPres.ExecNum;
                    drs[i]["Memo"] = mPres.Memo;
                }
            }
            //直接更新到数据库
            if (mPres.PresListId > 0)
            {
                Entity.Prescription.UpdatePresInjectTimes(mPres.PresListId, menuText, execTimes);
                iPrescriptionControl.ShowMessage("本院注射次数保存成功");
            }
            ConvertDataExtend.UpdateDataTable(dt, rowIndex, mPres);

        }
        /// <summary>
        /// 处方退费
        /// </summary>
        /// <param name="currentColIndex"></param>
        public void RefundFee(int currentColIndex)
        {
            int rowIndex = iPrescriptionControl.GridRowIndex;
            DataTable dt = iPrescriptionControl.PresGridDataSource;
            //判断是否已收费
            Entity.Prescription mPres = ConvertDataExtend.ToObject<Entity.Prescription>(dt, rowIndex);
            int _selfFlag = mPres.SelfDrug_Flag;
            //if (iPrescriptionControl.PresDoctorId != mPres.Pres_Doc)
            //{
            //    return;
            //} 
            if (mPres.Status != PresStatus.收费状态 )
            {
                string errText = "只有收费状态处方才能退费";
                throw new Exception(errText);
            }
            int presNO = mPres.PresNo;
            int presHeadID = mPres.PresHeadId;
            PrescripttionDataSource.RefundPresFee(presHeadID, presNO);
        }
        /// <summary>
        /// 获取节点头信息
        /// </summary>
        /// <returns></returns>
        public List<Entity.OPD_PresMouldHead> PresLoadTemplate(int intLevel, int presType)
        {
            return PrescripttionDataSource.LoadTemplateHead(intLevel, presType);
        }
        //另存处方为模板
        public void AsSavePresTemplate(int pId, int level, string mName, int presType, List<Entity.Prescription> data)
        {
            PrescripttionDataSource.AsSavePresTemplate(pId, level, mName, presType, iPrescriptionControl.PresDeptCode, iPrescriptionControl.PresDoctorId, data);
        }
        /// <summary>
        /// 设置选中的药房id
        /// </summary>
        /// <param name="deptID">药房Id</param>
        public DataTable SetSeletedDrugRoomID(int deptID)
        {
            PrescripttionDataSource.SelectedDrugRoomID = deptID;
            int type = (int)iPrescriptionControl.PrescriptionStyle;

            DataTable dt1 = ConvertDataExtend.ToDataTable(PrescripttionDataSource.GetDrugItem(type, 1, 10, ""));

            CardDataSource.Tables["itemdrug"].Clear();

            if (CardDataSource.Tables["itemdrug"] == null || CardDataSource.Tables["itemdrug"].Rows.Count==0)
            {
                DataTable dtitemdrug = dt1.Clone();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    dtitemdrug.Rows.Add(dt1.Rows[i].ItemArray);
                }
                CardDataSource.Tables.Remove("itemdrug");
                dtitemdrug.TableName = "itemdrug";
                CardDataSource.Tables.Add(dtitemdrug.Copy());

            }
            else
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    CardDataSource.Tables["itemdrug"].Rows.Add(dt1.Rows[i].ItemArray);
                }
            }
            int rowIndex = iPrescriptionControl.GridRowIndex;
            if (rowIndex >= 0)
            {
                iPrescriptionControl.SetGridCurrentCell(rowIndex, iPrescriptionControl.AllColumnIndex.ItemNameIndex);
            }
            return dt1;
        }
        /// <summary>
        /// 刷新药品ShowCard
        /// </summary>
        /// <returns></returns>
        public DataTable RefreshDrugData()
        {
            PrescripttionDataSource.RefreshDrugData();
            int type = (int)iPrescriptionControl.PrescriptionStyle;
            DataTable dt1 = ConvertDataExtend.ToDataTable(PrescripttionDataSource.GetDrugItem(type, 1, 10, ""));
            
            CardDataSource.Tables["itemdrug"].Clear();
            
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                CardDataSource.Tables["itemdrug"].Rows.Add(dt1.Rows[i].ItemArray);
            }
            int rowIndex = iPrescriptionControl.GridRowIndex;
            if (rowIndex >= 0)
            {
                iPrescriptionControl.SetGridCurrentCell(rowIndex, iPrescriptionControl.AllColumnIndex.ItemNameIndex);
            }
            return dt1;
        }
        #endregion
    }
}
