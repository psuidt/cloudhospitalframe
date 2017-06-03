using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.IPManage
{
    /// <summary>
    /// 药品库存类
    /// </summary>
    public class IP_DrugStore
    {
        private int _drugID;
        /// <summary>
        /// 药品ID
        /// </summary>
        public int DrugID
        {
            get { return _drugID; }
            set { _drugID = value; }
        }

        private int _execDeptId;
        /// <summary>
        /// 药房ID
        /// </summary>
        public int ExecDeptId
        {
            get { return _execDeptId; }
            set { _execDeptId = value; }
        }

        private string _execDeptName;
        /// <summary>
        /// 药房ID
        /// </summary>
        public string ExecDeptName
        {
            get { return _execDeptName; }
            set { _execDeptName = value; }
        }

        private decimal _storeAmount;
        /// <summary>
        /// 库存量
        /// </summary>
        public decimal StoreAmount
        {
            get { return _storeAmount; }
            set { _storeAmount = value; }
        }

    }

    /// <summary>
    /// 发送异常类
    /// </summary>
    public class IP_OrderCheckError
    {
        //床号 | 组号 | 医嘱号 | 医嘱名 |  所需数量 | 药房名
        private string _bedNo;
        /// <summary>
        /// 床号
        /// </summary>
        public string BedNo
        {
            get { return _bedNo; }
            set { _bedNo = value; }
        }

        private int _groupId;
        /// <summary>
        /// 医嘱组号ID
        /// </summary>
        public int GroupID
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        private int _orderId;
        /// <summary>
        /// 医嘱ID
        /// </summary>
        public int OrderID
        {
            get { return _orderId; }
            set { _orderId = value; }
        }        

        private string _orderName;
        /// <summary>
        /// 医嘱名
        /// </summary>
        public string OrderName
        {
            get { return _orderName; }
            set { _orderName = value; }
        }        

        private decimal _needAmount;
        /// <summary>
        /// 所需数量
        /// </summary>
        public decimal NeedAmount
        {
            get { return _needAmount; }
            set { _needAmount = value; }
        }

        private string _errorMessage;
        /// <summary>
        /// 异常信息
        /// </summary>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }
    }

}
