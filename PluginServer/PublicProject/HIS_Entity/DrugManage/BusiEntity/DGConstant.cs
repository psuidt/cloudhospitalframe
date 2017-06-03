using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.DrugManage
{
    /// <summary>
    /// 药品常量
    /// </summary>
    public class DGConstant
    {
        public const string OP_DS_SYSTEM = "01";
        public const string OP_DW_SYSTEM = "02";

        #region 药房系统业务参数
        /// <summary>
        /// 药房入库业务【无需单号】
        /// </summary>
        public const string OP_DS_INSTORE = "010";

        /// <summary>
        /// 药房采购入库业务
        /// </summary>
        public const string OP_DS_BUYINSTORE = "011";

        /// <summary>
        /// 药房期初入库业务
        /// </summary>
        public const string OP_DS_FIRSTIN = "012";

        /// <summary>
        /// 药房流通入库业务
        /// </summary>
        public const string OP_DS_CIRCULATEIN = "013";

        /// <summary>
        /// 药房申请单业务
        /// </summary>
        public const string OP_DS_APPLYPLAN = "014";

        /// <summary>
        /// 药房返库业务
        /// </summary>
        public const string OP_DS_RETURNSOTRE = "015";

        /// <summary>
        /// 药房内耗出库业务类型
        /// </summary>
        public const string OP_DS_DEPTDRAW = "021";

        /// <summary>
        /// 药房报损出库业务类型
        /// </summary>
        public const string OP_DS_REPORTLOSS = "022";



        /// <summary>
        /// 药房门诊发药
        /// </summary>
        public const string OP_DS_OPDISPENSE = "031";

        /// <summary>
        /// 药房门诊退药
        /// </summary>
        public const string OP_DS_OPREFUND = "032";

        /// <summary>
        /// 药房住院发药
        /// </summary>
        public const string OP_DS_IPDISPENSE = "033";



        /// <summary>
        /// 药房盘点业务类型
        /// </summary>
        public const string OP_DS_CHECK = "041";

        /// <summary>
        /// 药房盘点审核业务类型
        /// </summary>
        public const string OP_DS_AUDITCHECK = "042";


        /// <summary>
        /// 药房调价业务
        /// </summary>
        public const string OP_DS_ADJPRICE = "051";

        /// <summary>
        /// 药房月结业务类型
        /// </summary>
        public const string OP_DS_MONTHACCOUNT = "052";




        #endregion

        #region 药库系统业务参数
        /// <summary>
        /// 药库入库业务【无需单号】
        /// </summary>
        public const string OP_DW_INSTORE = "110";
        /// <summary>
        /// 药库采购入库类型
        /// </summary>
        public const string OP_DW_BUYINSTORE = "111";

        /// <summary>
        /// 药库期初入库类型
        /// </summary>
        public const string OP_DW_FIRSTIN = "112";

        /// <summary>
        /// 药库退货类型
        /// </summary>
        public const string OP_DW_BACKSTORE = "113";

        /// <summary>
        /// 药库流通出库类型
        /// </summary>
        public const string OP_DW_CIRCULATEOUT = "121";

        /// <summary>
        /// 药库内耗出库业务类型
        /// </summary>
        public const string OP_DW_DEPTDRAW = "122";

        /// <summary>
        /// 药库报损出库业务类型
        /// </summary>
        public const string OP_DW_REPORTLOSS = "123";

        /// <summary>
        /// 药库退库业务
        /// </summary>
        public const string OP_DW_RETURNSTORE = "124";

        /// <summary>
        /// 药库盘点业务
        /// </summary>
        public const string OP_DW_CHECK = "141";

        /// <summary>
        /// 药库盘点审核业务
        /// </summary>
        public const string OP_DW_AUDITCHECK = "142";



        /// <summary>
        /// 药库调价业务
        /// </summary>
        public const string OP_DW_ADJPRICE = "151";


        /// <summary>
        /// 药库月结业务
        /// </summary>
        public const string OP_DW_MONTHACCOUNT = "152";

        /// <summary>
        /// 药库采购计划
        /// </summary>
        public const string OP_DW_STOCKPLAN = "153";

        #endregion
    }
}
