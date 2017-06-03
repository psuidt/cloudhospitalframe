using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EfwControls.HISControl.Prescription.Controls.CommonMvc;
using EfwControls.HISControl.Prescription.Controls.Entity;

namespace EfwControls.HISControl.Prescription.Controls.Action
{
    internal interface IPrescriptionControl : IBaseView
    {
        /// <summary>
        /// 处方类型
        /// </summary>
        PrescriptionStyle PrescriptionStyle { get; set; }
        /// <summary>
        /// 当前病人
        /// </summary>
        int CurrPatListId { get; set; }

        int PresDeptCode { get; set; }
        string PresDeptName { get; set; }
        int PresDoctorId { get; set; }
        string PresDoctorName { get; set; }
        int PresCount { get; set;}
        int DrugRepeatWarn { get; set; }
        int DayGreater30 { get; set; }

        /// <summary>
        /// 初始化选项卡数据源
        /// </summary>
        /// <param name="cardDataSource"></param>
        void InitializeCardData(DataSet cardDataSource);

        /// <summary>
        /// 加载处方数据
        /// </summary>
        /// <param name="presData"></param>
        void LoadGridPresData(DataTable presData);

        /// <summary>
        /// 处方数据源
        /// </summary>
        DataTable PresGridDataSource { get; }

        /// <summary>
        /// 处方网格选择的行，合并分组
        /// </summary>
        int[] GridSelectedRows { get; }
       
        /// <summary>
        /// 画组线 
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        System.Drawing.Rectangle GridCellBounds(int rowIndex);

        /// <summary>
        /// Grid当前行号
        /// </summary>
        int GridRowIndex { get; }

        /// <summary>
        /// 设置网格当前单元格
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="column"></param>
        void SetGridCurrentCell(int rowIndex, int colIndex);

        /// <summary>
        /// 设置单元格只读
        /// </summary>
        PresCellReadOnlyStatus CellReadOnly { set; }

        /// <summary>
        /// 设置单元格颜色
        /// </summary>
        PresColor CellColor { set; }
        /// <summary>
        /// 处方网格列的索引
        /// </summary>
        PresColumnIndex AllColumnIndex { get; }

        /// <summary>
        /// 保存处方的时候必须检查处方诊断
        /// </summary>
        bool CheckDisease();
        /// <summary>
        /// 保存处方生成联动费用
        /// </summary>
        /// <param name="data"></param>
        void SaveCostoflinkage(List<Entity.Prescription> data);
        /// <summary>
        /// 弹出消息框
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message);
    }



    public enum PresCellReadOnlyStatus
    {
        全部只读, 药品处方, 中药处方, 项目, 新行,皮试, 甲类药品处方
    }

}
