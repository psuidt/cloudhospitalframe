using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfwControls.HISControl.Orders.Controls
{
    /// <summary>
    /// 医嘱费用控件数据库操作接口
    /// </summary>
    public interface IOrderFeeDbHelper
    {
        /// <summary>
        /// 加载医嘱关联费用列表
        /// </summary>
        /// <param name="PatListID">病人登记ID</param>
        /// <param name="GroupID">医嘱组号ID</param>
        /// <returns>医嘱关联费用数据列表</returns>
        DataTable LoadOrderFeeData(int PatListID, int GroupID);

        /// <summary>
        /// 获取弹出网格费用项目列表
        /// </summary>
        /// <returns>弹出网格费用项目列表</returns>
        DataTable GetDocFeeItemList();

        /// <summary>
        /// 提示Msg事件
        /// </summary>
        /// <param name="Msg">Msg内容</param>
        void MessageShow(string Msg);

        /// <summary>
        /// 保存医嘱费用数据
        /// </summary>
        /// <param name="FeeDt">待保存的医嘱费用数据</param>
        /// <param name="PatListID">病人登记ID</param>
        /// <param name="GroupID">医嘱分组ID</param>
        /// <returns>保存成功或失败</returns>
        bool SaveFeeItemData(DataTable FeeDt, int PatListID, int GroupID);

        /// <summary>
        /// 删除选中医嘱费用数据
        /// </summary>
        /// <param name="GenerateID">选中医嘱费用数据ID</param>
        void DelFeeItemData(int GenerateID);

        /// <summary>
        /// 验证医嘱是否已转抄，已转抄的医嘱不允许补录费用
        /// </summary>
        /// <param name="patListID">病人ID</param>
        /// <param name="groupID">组号ID</param>
        /// <returns>true：已转抄</returns>
        bool CheckOrderStatus(int patListID, int groupID);
    }
}
