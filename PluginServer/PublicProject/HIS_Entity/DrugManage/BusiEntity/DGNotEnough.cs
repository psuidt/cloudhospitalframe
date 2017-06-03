using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.DrugManage
{
    /// <summary>
    /// 库存不足药品信息
    /// </summary>
    public class DGNotEnough
    {
        /// <summary>
        /// 药品ID
        /// </summary>
        private int drugID;
        /// <summary>
        /// 科室ID
        /// </summary>
        private int deptID;
        /// <summary>
        /// 药品信息
        /// </summary>
        private string drugInfo;
        /// <summary>
        /// 缺少数量
        /// </summary>
        private decimal lackAmount;
        /// <summary>
        /// 药品ID
        /// </summary>
        public int DrugID
        {
            get
            {
                return drugID;
            }

            set
            {
                drugID = value;
            }
        }
        /// <summary>
        /// 科室ID
        /// </summary>
        public int DeptID
        {
            get
            {
                return deptID;
            }

            set
            {
                deptID = value;
            }
        }
        /// <summary>
        /// 药品信息
        /// </summary>
        public string DrugInfo
        {
            get
            {
                return drugInfo;
            }

            set
            {
                drugInfo = value;
            }
        }
        /// <summary>
        /// 缺少数量
        /// </summary>
        public decimal LackAmount
        {
            get
            {
                return lackAmount;
            }

            set
            {
                lackAmount = value;
            }
        }
    }
}
