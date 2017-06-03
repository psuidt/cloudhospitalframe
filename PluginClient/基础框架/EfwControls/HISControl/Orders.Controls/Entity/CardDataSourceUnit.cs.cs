using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfwControls.HISControl.Orders.Controls.Entity
{
    public class CardDataSourceUnit
    {
        public int UnitDicId { get; set; }
        public string UnitName { get; set; }
        public string Pym { get; set; }
        public string Wbm { get; set; }
        //单位系数
        public decimal UnitNO { get; set; }
    }
}
