using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.DrugManage
{
    /// <summary>
    /// 药品单据处理结果
    /// </summary>
    public class DGBillResult
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
        private List<DGNotEnough> lstNotEnough;

        private int iDispHeadID;
        /// <summary>
        /// 发药头表id
        /// </summary>
        public int DispHeadID
        {
            get
            {
                return iDispHeadID;
            }

            set
            {
                iDispHeadID = value;
            }
        }
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
        public List<DGNotEnough> LstNotEnough
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
    public class DgSpResult
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
