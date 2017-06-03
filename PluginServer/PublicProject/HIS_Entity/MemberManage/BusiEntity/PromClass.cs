using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.MemberManage
{
    public class PromClass
    {
        private int _classID;
        /// <summary>
        /// 费用明细表ID
        /// </summary>
        public int  ClassID
        {
            get { return _classID; }
            set { _classID = value; }
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
