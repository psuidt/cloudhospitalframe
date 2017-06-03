using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.MaterialManage
{
    /// <summary>
    /// 库存不足物资信息
    /// </summary>

    public class MWNotEnoughInfo
    {
        /// <summary>
        ///物资ID
        /// </summary>
        private int materialId;
        /// <summary>
        /// 科室ID
        /// </summary>
        private int deptID;
        /// <summary>
        ///物资信息
        /// </summary>
        private string materialInfo;
        /// <summary>
        /// 缺少数量
        /// </summary>
        private decimal lackAmount;
        /// <summary>
        ///物资ID
        /// </summary>
        public int MaterialId
        {
            get
            {
                return materialId;
            }

            set
            {
                materialId = value;
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
        ///物资信息
        /// </summary>
        public string MaterialInfo
        {
            get
            {
                return materialInfo;
            }

            set
            {
                materialInfo = value;
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
