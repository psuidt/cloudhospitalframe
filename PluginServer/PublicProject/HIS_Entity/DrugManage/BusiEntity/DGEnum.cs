using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.DrugManage
{
    /// <summary>
    /// 药品枚举
    /// </summary>
    public class DGEnum
    {
        /// <summary>
        /// 单据编辑状态
        /// </summary>
        public enum BillEditStatus
        {
            ADD_STATUS = 0,
            UPDATE_STATUS=1
        }
        /// <summary>
        /// 单据网格明细编辑状态
        /// </summary>
        public enum DetailsEditiStatus
        {
            UPDATING,
            SELECTING,
            LoadBuyBill
        }

        /// <summary>
        /// 进销存统计类型
        /// </summary>
        public enum StatisticType
        {
            /// <summary>
            /// 借方
            /// </summary>
            Lend,
            /// <summary>
            /// 贷方
            /// </summary>
            Debit,
            /// <summary>
            /// 借贷都有
            /// </summary>
            LendAndDebit
        }
        /// <summary>
        /// 药品报表打印
        /// </summary>
        public enum PrintReport
        {
            新药统计 = 4029
        }
    }
}
