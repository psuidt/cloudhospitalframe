using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.BasicData.BusiEntity
{
    public class InpatientWorkLoadEnum
    {
    }
    /// <summary>
    /// 医生类型
    /// </summary>
    public enum DocType
    {    
        经治医生,
        开方医生  
    }

    /// <summary>
    /// 时间类型
    /// </summary>
    public enum TimeType
    {
        记帐时间,
        结算时间,
        缴款时间
    }
}
