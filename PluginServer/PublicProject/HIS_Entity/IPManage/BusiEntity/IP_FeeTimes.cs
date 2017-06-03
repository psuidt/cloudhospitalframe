using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.IPManage
{
    /// <summary>
    /// 根据频次生成费用时间点
    /// </summary>
    public class IP_FeeTimes
    {
        private int _groupId;
        /// <summary>
        /// 医嘱组号ID
        /// </summary>
        public int GroupID
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        private DateTime _feeTimes;
        /// <summary>
        /// 费用时间
        /// </summary>
        public DateTime FeeTimes
        {
            get { return _feeTimes; }
            set { _feeTimes = value; }
        }

        private bool _isCurrentDateFirst;
        /// <summary>
        /// 是否周期第一条 该周期暂时定为一天
        /// </summary>
        public bool IsCurrentDateFirst
        {
            get { return _isCurrentDateFirst; }
            set { _isCurrentDateFirst = value; }
        }
    }
}
