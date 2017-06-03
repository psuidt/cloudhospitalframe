using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.MemberManage
{
    public class PromDetail
    {
        private int _feeID;
        /// <summary>
        /// 费用明细表ID
        /// </summary>
        public int FeeID
        {
            get { return _feeID; }
             set {_feeID = value;}
        }

        private int _itemID;
        /// <summary>
        /// 收费项目ID
        /// </summary>
        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }

        private decimal _itemAmount;
        /// <summary>
        /// 收费项目金额
        /// </summary>
        public decimal ItemAmount
        {
            get { return _itemAmount; }
            set { _itemAmount = value; }
        }
        private int _discountAmount;
        /// <summary>
        /// 优惠金额
        /// </summary>
        public int DiscountAmount
        {
            get { return _discountAmount; }
            set { _discountAmount = value; }
        }

    }
}
