using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EfwControls.HISControl.Orders.Controls.Entity;

namespace EfwControls.HISControl.Orders.Controls.IView
{
    public interface IOrdersControlView
    {
        #region 基本属性
        /// <summary>
        /// 医嘱类别
        /// </summary>
        OrderCategory OrderStyle { get; set; }
        /// <summary>
        /// 当前病人
        /// </summary>
        int CurrPatListId { get; set; }
        int PatDeptID { get; set; }//病人科室
        int PresDeptId { get; set; }//开方科室ID
        string PresDeptName { get; set; }//开方科室名称
        int PresDoctorId { get; set; }//开方医生ID
        string PresDoctorName { get; set; }//医生医生姓名
         int IsLeaveHosOrder { get; set; }//病人是否开出院医嘱
        bool HasNotFinishTrans { get; set; }//是否存在未完成转科
        bool IsShowAllOrder { get; set; }
        #endregion

        #region 医嘱数据源
        /// <summary>
        /// 初始化选项卡数据源
        /// </summary>
        /// <param name="cardDataSource"></param>
        void InitializeCardData();
        /// <summary>
        /// 药品项目选项卡数据源
        /// </summary>
        /// <param name="dtItemDrug"></param>
        void ShowCardItemDrugSet(DataTable dtItemDrug);
        /// <summary>
        /// 加载医嘱数据
        /// </summary>
        /// <param name="presData"></param>
        void LoadGridOrderData(DataTable orderData);
        //嘱托数据源
        void ShowCardEntrustSet(DataTable dtEntrust);
        #endregion
        /// <summary>
        /// 获取界面医嘱数据源
        /// </summary>
        DataTable GetGridOrder { get; }
        #region 网格属性
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
        #endregion

        void SetGridColor(); //设置网颜色
        void SetReadOnly(ReadOnlyType readonlyType);     
        /// <summary>
        /// 保存医嘱生成联动费用
        /// </summary>
        /// <param name="data"></param>
        void SaveCostoflinkage(List<Entity.OrderRecord> data);
        void ShowCardUnitSet(DataTable dtUnit);
        void SetGridCurrentCell(int rowIndex, string colName);
        void ShowMessage(string message);
        /// <summary>
        /// 开皮试医嘱时保存
        /// </summary>
        /// <param name="data"></param>
        void SaveAstoflinkage(List<Entity.OrderRecord> data);
        /// <summary>
        /// 医嘱保存时错误定位
        /// </summary>
        /// <param name="orderCategory"></param>
        /// <param name="rowindex"></param>
        /// <param name="colName"></param>
        void SaveOrderCheckoflinkage(int orderCategory, int rowindex, string colName);
    }

    public enum ReadOnlyType
    { 
        项目 ,
        中草药 ,
        药品非中草药,
        新开,
        不能修改,
        全部只读,
        同组增加,
        出院带药,
        皮试医嘱,
        皮试生成医嘱,
        自由录入
    }
}
