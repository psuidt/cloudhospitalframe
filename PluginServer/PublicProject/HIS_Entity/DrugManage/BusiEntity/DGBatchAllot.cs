using System;

namespace HIS_Entity.DrugManage
{
    /// <summary>
    /// 库存批次分配实体
    /// </summary>
    public class DGBatchAllot
    {
        /// <summary>
        /// 批次编码
        /// </summary>
        private string batchNO;
        /// <summary>
        /// 零售价
        /// </summary>
        private decimal retailPrice;
        /// <summary>
        /// 进货价
        /// </summary>
        private decimal stockPrice;
        /// <summary>
        /// 剩余数
        /// </summary>
        private decimal storeAmount;
        /// <summary>
        /// 发退药数
        /// </summary>
        private decimal dispAmount;
        /// <summary>
        /// 库存ID
        /// </summary>
        private int storageID;
        /// <summary>
        /// 有效日期
        /// </summary>
        private DateTime validityDate;
        /// <summary>
        /// 盘存数
        /// </summary>
        private decimal factAmount;
        /// <summary>
        /// 盘存进货金额
        /// </summary>
        private decimal factStockFee;
        /// <summary>
        /// 盘存零售金额
        /// </summary>
        private decimal factRetailFee;
        /// <summary>
        /// 账存数
        /// </summary>
        private decimal actAmount;
        /// <summary>
        /// 账存进货金额
        /// </summary>
        private decimal actStockFee;
        /// <summary>
        /// 账存零售金额
        /// </summary>
        private decimal actRetailFee;

        /// <summary>
        /// 批次编码
        /// </summary>
        public string BatchNO
        {
            get
            {
                return batchNO;
            }

            set
            {
                batchNO = value;
            }
        }
        /// <summary>
        /// 零售价
        /// </summary>
        public decimal RetailPrice
        {
            get
            {
                return retailPrice;
            }

            set
            {
                retailPrice = value;
            }
        }
        /// <summary>
        /// 进货价
        /// </summary>
        public decimal StockPrice
        {
            get
            {
                return stockPrice;
            }

            set
            {
                stockPrice = value;
            }
        }
        /// <summary>
        /// 剩余数
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
        /// 发退药数
        /// </summary>
        public decimal DispAmount
        {
            get
            {
                return dispAmount;
            }

            set
            {
                dispAmount = value;
            }
        }
        /// <summary>
        /// 有效日期
        /// </summary>
        public DateTime ValidityDate
        {
            get
            {
                return validityDate;
            }

            set
            {
                validityDate = value;
            }
        }
        /// <summary>
        /// 盘存数
        /// </summary>
        public decimal FactAmount
        {
            get
            {
                return factAmount;
            }

            set
            {
                factAmount = value;
            }
        }
        /// <summary>
        /// 盘存进货金额
        /// </summary>
        public decimal FactStockFee
        {
            get
            {
                return factStockFee;
            }

            set
            {
                factStockFee = value;
            }
        }
        /// <summary>
        /// 盘存零售金额
        /// </summary>
        public decimal FactRetailFee
        {
            get
            {
                return factRetailFee;
            }

            set
            {
                factRetailFee = value;
            }
        }
        /// <summary>
        /// 账存数
        /// </summary>
        public decimal ActAmount
        {
            get
            {
                return actAmount;
            }

            set
            {
                actAmount = value;
            }
        }
        /// <summary>
        /// 账存进货金额
        /// </summary>
        public decimal ActStockFee
        {
            get
            {
                return actStockFee;
            }

            set
            {
                actStockFee = value;
            }
        }
        /// <summary>
        /// 账存零售金额
        /// </summary>
        public decimal ActRetailFee
        {
            get
            {
                return actRetailFee;
            }

            set
            {
                actRetailFee = value;
            }
        }

        /// <summary>
        /// 发药零售金额
        /// </summary>
        public decimal DispRetailFee
        {
            get;
            set;
        }

        /// <summary>
        /// 退药进货金额
        /// </summary>
        public decimal DispStockFee
        {
            get;
            set;
        }

        /// <summary>
        /// 单位数量
        /// </summary>
        public int UnitAmount
        {
            get;
            set;
        }

        /// <summary>
        /// 计算金额
        /// </summary>
        /// <param name="price">包装单位价格</param>
        /// <param name="unitAmount">包装系数</param>
        /// <param name="amount">基本单位数量</param>
        /// <returns></returns>
        public decimal CalFee(decimal price, decimal unitAmount, decimal amount)
        {
            decimal dResult = Math.Round((price / unitAmount) * amount,2);
            return dResult;
        }
    }
}
