using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.BasicData.BusiEntity
{
    public class Constants
    {
    }

    /// <summary>
    /// 是否审核
    /// </summary>
    public enum AuditType
    {
        /// <summary>
        /// 未审核
        /// </summary>
        [Display(Name = "未审核")]
        UnAudit,
        /// <summary>
        /// 已审核
        /// </summary>
        [Display(Name = "已审核")]
        Audited,
        /// <summary>
        /// 全部
        /// </summary>
        [Display(Name = "全部")]
        Default = 9
    }

    /// <summary>
    /// 是否停用
    /// </summary>
    public enum IsStopType
    {
        /// <summary>
        /// 已启用
        /// </summary>
        [Display(Name = "已启用")]
        Enabled,
        /// <summary>
        /// 已停用
        /// </summary>
        [Display(Name = "已停用")]
        Disabled,
        /// <summary>
        /// 全部
        /// </summary>
        [Display(Name = "全部")]
        Default = 9
    }

    /// <summary>
    /// 医保类型
    /// </summary>
    public enum MreTypes
    {
        /// <summary>
        /// 否
        /// </summary>
        [Display(Name = "否")]
        Default,
        /// <summary>
        /// 甲类
        /// </summary>
        [Display(Name = "甲类")]
        A,
        /// <summary>
        /// 乙类
        /// </summary>
        [Display(Name = "乙类")]
        B,
        /// <summary>
        /// 丙类
        /// </summary>
        [Display(Name = "丙类")]
        C
    }
}
