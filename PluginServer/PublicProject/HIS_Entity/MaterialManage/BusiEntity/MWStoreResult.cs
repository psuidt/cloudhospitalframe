using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.MaterialManage
{
    /// <summary>
    /// 物资库存处理结果
    /// </summary>
   public class MWStoreResult
    {

        public MWStoreResult()
        {
            batchAllotList = new List<MWBatchAllot>();
        }
        /// <summary>
        /// 处理结果
        /// </summary>
        private int result;
        /// <summary>
        /// 结余数量
        /// </summary>
        private decimal storeAmount;
        /// <summary>
        /// 库存ID
        /// </summary>
        private int storageID;
        /// <summary>
        /// 单位系数
        /// </summary>
        private int unitAmount;
        /// <summary>
        /// 批次分配表
        /// </summary>
        private MWBatchAllot[] batchAllot;
        /// <summary>
        /// 批次分配列表
        /// </summary>
        private List<MWBatchAllot> batchAllotList;
        /// <summary>
        /// 结余数量
        /// </summary>
        public decimal StoreAmount
        {
            get
            {
                return storeAmount;
            }

            set
            {
                storeAmount = value;
            }
        }
        /// <summary>
        /// 库存ID
        /// </summary>
        public int StorageID
        {
            get
            {
                return storageID;
            }

            set
            {
                storageID = value;
            }
        }
        /// <summary>
        /// 单位系数
        /// </summary>
        public int UnitAmount
        {
            get
            {
                return unitAmount;
            }

            set
            {
                unitAmount = value;
            }
        }
        /// <summary>
        /// 批次分配表
        /// </summary>
        public MWBatchAllot[] BatchAllot
        {
            get
            {
                return batchAllot;
            }

            set
            {
                batchAllot = value;
            }
        }
        /// <summary>
        /// 处理结果:0成功；1库存不足；2异常
        /// </summary>
        public int Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
            }
        }

        /// <summary>
        /// 批次列表
        /// </summary>
        public List<MWBatchAllot> BatchAllotList
        {
            get
            {
                return batchAllotList;
            }

            set
            {
                batchAllotList = value;
            }
        }
    }



   
}
