using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.MaterialManage
{
    /// <summary>
    /// 物资全局常量 对应 DG_BusiType
    /// </summary>
    public class MWConstant
    {
        public const string MW_IN_SYSTEM = "01";
        public const string MW_Out_SYSTEM = "02";

        #region 物资库系统业务参数


        /// <summary>
        /// 物资库入库业务【无需单号】
        /// </summary>
        public const string OP_MW_INSTORE = "210";

        /// <summary>
        /// 物资库采购入库类型
        /// </summary>
        public const string OP_MW_BUYINSTORE = "211";

        /// <summary>
        /// 物资库期初入库类型
        /// </summary>
        public const string OP_MW_FIRSTIN = "212";

        /// <summary>
        /// 物资库退货类型
        /// </summary>
        public const string OP_MW_BACKSTORE = "213";

        /// <summary>
        /// 物资库流通出库类型
        /// </summary>
        public const string OP_MW_CIRCULATEOUT = "221";

        /// <summary>
        /// 物资库内耗出库业务类型
        /// </summary>
        public const string OP_MW_DEPTDRAW = "222";

        /// <summary>
        /// 物资库报损出库业务类型
        /// </summary>
        public const string OP_MW_REPORTLOSS = "223";

        /// <summary>
        /// 物资库退库业务
        /// </summary>
        public const string OP_MW_RETURNSTORE = "224";

        /// <summary>
        /// 物资库盘点业务
        /// </summary>
        public const string OP_MW_CHECK = "241";

        /// <summary>
        /// 物资库盘点审核业务
        /// </summary>
        public const string OP_MW_AUDITCHECK = "242";

        /// <summary>
        /// 物资库调价业务
        /// </summary>
        public const string OP_MW_ADJPRICE = "251";

        /// <summary>
        /// 物资库月结业务
        /// </summary>
        public const string OP_MW_MONTHACCOUNT = "252";

        /// <summary>
        /// 物资库采购计划
        /// </summary>
        public const string OP_MW_STOCKPLAN = "253";

        #endregion
    }
}
