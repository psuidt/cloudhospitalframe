using EMR_Entity.BasicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfwControls.HISControl.Emr.Controls.IView
{
    public interface IMedicalCaseControlView
    {
        /// <summary>
        /// 当前病人
        /// </summary>
        int CurrPatListId { get; set; }

        /// <summary>
        /// 病人科室ID
        /// </summary>
        int PatDeptID { get; set; }
     
        /// <summary>
        /// 病人科室名称
        /// </summary>
        string PatDeptName { get; set; }

        /// <summary>
        /// 操作员ID
        /// </summary>
        int EmpId { get; set; }

        /// <summary>
        /// 操作员姓名
        /// </summary>
        string EmpName { get; set; }

        /// <summary>
        /// 当前病案记录
        /// </summary>
        Emr_CaseRecord curCaseRecord { get; set; }
    }
}
