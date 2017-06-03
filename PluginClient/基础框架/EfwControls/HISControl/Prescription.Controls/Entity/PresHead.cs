using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfwControls.HISControl.Prescription.Controls.Entity
{
    public class PresHead
    {
        //方号
        public int PresNo { get; set; }
        //
        public int PresHeadId { get; set; }

        public int PatId { get; set; }
        //就诊病人ID
        public int PatListId { get; set; }
        //处方类型
        public string PresType { get; set; }
        //开方科室
        public int Pres_Dept { get; set; }
        //开方医生
        public int Pres_Doc { get; set; }

        //执行科室
        public int Pres_ExeDept { get; set; }
        //执行日期
        public DateTime Pres_Date { get; set; }


        //处方状态(0:正常,1:已收费,2:已退费,3:已删除)
        public PresStatus Pres_Flag { get; set; }
        
        //费用表反写费用主表ID
        public int PresMasterId { get; set; }
        
    }
}
