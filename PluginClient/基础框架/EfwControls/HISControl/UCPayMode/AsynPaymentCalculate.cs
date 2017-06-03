using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfwControls.HISControl.UCPayMode
{
    /// <summary>
    /// 异步支付方式计算
    /// </summary>
    public abstract class AsynPaymentCalculate
    {
        private int patListID;
        /// <summary>
        /// 病人ID
        /// </summary>
        public int PatListID {
            get { return patListID; }
            set { patListID = value; }
        }

        private int iPatType;
        /// <summary>
        /// 病人类型
        /// </summary>
        public int PatType
        {
            get
            {
                return iPatType;
            }

            set
            {
                iPatType = value;
            }
        }

        int[] feeIDs;
        /// <summary>
        /// 费用ID
        /// </summary>
        public int[] FeeIDs
        {
            get
            {
                return feeIDs;
            }

            set
            {
                feeIDs = value;
            }
        }

        public AsynPaymentCalculate(int _patListID,int _iPatType,int[] _feeIDs)
        {
            patListID = _patListID;
            iPatType = _iPatType;
            feeIDs = _feeIDs;
        }
        /// <summary>
        /// 优惠计算
        /// </summary>
        /// <returns></returns>
        public virtual decimal FavorableCalculate(out string ticketNo,out PAY_PROCSTEP procStep)
        {
            ticketNo = "";
            procStep = PAY_PROCSTEP.ppsHandFinsed;
            return 0;
        }
        /// <summary>
        /// 医保计算报销
        /// </summary>
        /// <returns></returns>
        public virtual decimal MedicalinsuranceCalculate(out string ticketNo,out PAY_PROCSTEP procStep)
        {
            ticketNo = "";
            procStep = PAY_PROCSTEP.ppsHandFinsed;
            return 0;
        }
        /// <summary>
        /// 医保刷卡报销
        /// </summary>
        /// <returns></returns>
        public virtual decimal MedicalinsuranceCalculatePers(out string ticketNo, out PAY_PROCSTEP procStep)
        {
            ticketNo = "";
            procStep = PAY_PROCSTEP.ppsHandFinsed;
            return 0;
        }
    }
}
