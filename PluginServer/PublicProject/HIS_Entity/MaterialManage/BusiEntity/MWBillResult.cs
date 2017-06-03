using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HIS_Entity.DrugManage;

namespace HIS_Entity.MaterialManage
{
    /// <summary>
    /// 物资单据处理结果类
    /// </summary>
    public class MWBillResult
    {
        /// <summary>
        /// 单据处理结果
        /// </summary>
        private int result;
        /// <summary>
        /// 错误异常信息
        /// </summary>
        private string errMsg;
        /// <summary>
        /// 库存不足药品
        /// </summary>
        private List<MWNotEnoughInfo> lstNotEnough;

        /// <summary>
        /// 单据处理结果 0:正常;1错误;2异常
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
        /// 错误信息
        /// </summary>
        public string ErrMsg
        {
            get
            {
                return errMsg;
            }

            set
            {
                errMsg = value;
            }
        }

        /// <summary>
        /// 库存不足药品信息
        /// </summary>
        public List<MWNotEnoughInfo> LstNotEnough
        {
            get
            {
                return lstNotEnough;
            }

            set
            {
                lstNotEnough = value;
            }
        }
    }

    /// <summary>
    /// 存储过程结果
    /// </summary>
    public class MWSpResult
    {
        /// 单据处理结果
        /// </summary>
        public int Result { set; get; }
        /// <summary>
        /// 错误异常信息
        /// </summary>
        public string ErrMsg { set; get; }

        /// <summary>
        /// 返回表
        /// </summary>
        public DataTable Table { set; get; }
    }
}
