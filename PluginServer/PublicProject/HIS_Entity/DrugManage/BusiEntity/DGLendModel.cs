using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.DrugManage
{
    /// <summary>
    /// 借方实体
    /// </summary>
    public class DGLendModel
    {
        /// <summary>
        /// 借方名称
        /// </summary>
        public string LendName
        {
            get;
            set;
        }

        /// <summary>
        /// 零售金额
        /// </summary>
        public decimal RetailFee
        {
            get;
            set;
        }

        /// <summary>
        /// 进货金额
        /// </summary>
        public decimal StockFee
        {
            get;
            set;
        }
    }
}
