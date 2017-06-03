using EFWCoreLib.CoreFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.MIManage
{
    public class ResultClass
    {
        private bool _bSucess = false;
        /// <summary>
        /// 执行是否成功标志，如果false则查看sMome   如果True则取oResult
        /// </summary>
        public bool bSucess { set { _bSucess = value; } get { return _bSucess; } }

        private string _sRemarks = "";
        /// <summary>
        /// 返回的警告和错误信息
        /// </summary>
        public string sRemarks { set { _sRemarks = value; } get { return _sRemarks; } }

        private object _oResult = null;
        /// <summary>
        /// 返回的结果集
        /// </summary>
        public object oResult { set { _oResult = value; } get { return _oResult; } }
    }

    public class InputClass
    {
        private Dictionary<InputType, object> _SInput = null;
        public Dictionary<InputType, object> SInput
        {
            set
            {
                _SInput = value;
            }
            get
            {
                return _SInput;
            }
        }
    }

    public enum InputType
    {
        /// <summary>
        /// 医保卡号
        /// </summary>
        CardNo,
        /// <summary>
        /// 门诊号/住院号
        /// </summary>
        SerialNO,
        //DataTable
        DataTable,
        /// <summary>
        /// 登记ID
        /// </summary>
        RegisterId,
        /// <summary>
        /// 交易信息id
        /// </summary>
        TradeRecordId,
        /// <summary>
        /// 发票号
        /// </summary>
        InvoiceNo,

        /// <summary>
        /// 医保交易流水号
        /// </summary>
        TradeNo,

        MI_Register,

        MI_MedicalInsurancePayRecord,

        MI_MIPayRecordDetail,

        MI_MIPayRecordHead,

        MI_RegisterList,

        MI_MedicalInsurancePayRecordList,

        MI_MIPayRecordDetailList,

        MI_MIPayRecordHeadList,

        TradeData,

        Money,
        /// <summary>
        /// bool类型
        /// </summary>
        bFlag

    }
}
