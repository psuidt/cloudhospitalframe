using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfwControls.HISControl.Orders.Controls.IView
{
    /// <summary>
    /// 医嘱费用控件控制器接口
    /// </summary>
    public interface IOrderFeeControlView
    {
        /// <summary>
        /// 病人登记ID
        /// </summary>
        int PatListID { get; set; }

        /// <summary>
        /// 医嘱组号ID
        /// </summary>
        int GroupID { get; set; }

        /// <summary>
        /// 绑定医嘱关联费用数据
        /// </summary>
        /// <param name="OrderFeeList">医嘱关联费用数据列表</param>
        //void bind_OrderRelationFeeList(DataTable OrderFeeList);

        /// <summary>
        /// 绑定医嘱费用数据弹出网格源数据
        /// </summary>
        /// <param name="ShowCardDataList">费用源数据列表</param>
        //void bind_OrderFeeShowCardData(DataTable ShowCardDataList);
    }
}
