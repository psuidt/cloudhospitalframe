using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.MaterialManage
{
    /// <summary>
    /// 物资枚举对象
    /// </summary>
   public class MWEnum
    {
        /// <summary>
        /// 单据编辑状态
        /// </summary>
        public enum BillEditStatus
        {
            ADD_STATUS = 0,
            UPDATE_STATUS = 1
        }

        /// <summary>
        /// 单据网格明细编辑状态
        /// </summary>
        public enum DetailsEditiStatus
        {
            UPDATING,
            SELECTING
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
    }
}
