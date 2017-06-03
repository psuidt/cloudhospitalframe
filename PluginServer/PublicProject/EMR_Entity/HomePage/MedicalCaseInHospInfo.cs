using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMR_Entity.HomePage
{
    /// <summary>
    /// 入出院信息
    /// </summary>
    public class MedicalCaseInHospInfo
    {
        private DateTime _enterhdate;
        /// <summary>
        /// 入院日期
        /// </summary>
        public DateTime EnterHDate
        {
            get { return _enterhdate; }
            set { _enterhdate = value; }
        }

        private string _enterdeptName;
        /// <summary>
        /// 入院科室
        /// </summary>
        public string EnterDeptName
        {
            get { return _enterdeptName; }
            set { _enterdeptName = value; }
        }

        private int _enterwardName;
        /// <summary>
        /// 入院病区
        /// </summary>
        public int EnterWardName
        {
            get { return _enterwardName; }
            set { _enterwardName = value; }
        }

        private string _transdeptName;
        /// <summary>
        /// 转科科室
        /// </summary>
        public string TransDeptName
        {
            get { return _transdeptName; }
            set { _transdeptName = value; }
        }

        private DateTime _leavehdate;
        /// <summary>
        /// 出院日期
        /// </summary>
        public DateTime LeaveHDate
        {
            get { return _leavehdate; }
            set { _leavehdate = value; }
        }

        private string _currdeptName;
        /// <summary>
        /// 当前科室
        /// </summary>
        public string CurrDeptName
        {
            get { return _currdeptName; }
            set { _currdeptName = value; }
        }

        private string _currwardName;
        /// <summary>
        /// 当前病区
        /// </summary>
        public string CurrwardName
        {
            get { return _currwardName; }
            set { _currwardName = value; }
        }

        private int _inHospDays;
        /// <summary>
        /// 住院天数
        /// </summary>
        public int InHospDays
        {
            get { return _inHospDays; }
            set { _inHospDays = value; }
        }
        private int _status;
        /// <summary>
        /// 病人状态
        /// </summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
