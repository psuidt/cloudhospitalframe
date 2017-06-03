using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfwControls.HISControl.PrescriptionTmp.Controls.Entity
{
    public class CardDataSourceUnit
    {
        public int UnitDicId { get; set; }
        public string UnitName { get; set; }
        public string Pym { get; set; }
        public string Wbm { get; set; }
        //单位系数
        public decimal Factor { get; set; }
    }
}
