using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfwControls.HISControl.PrescriptionTmp.Controls.Entity
{
    /// <summary>
    /// 当前状态
    /// </summary>
    public enum CurrentStatus
    {
        /// <summary>
        /// 查询状态
        /// </summary>
        查询状态 = 0,
        /// <summary>
        /// 新建状态
        /// </summary>
        新建状态 = 1,
        /// <summary>
        /// 修改状态
        /// </summary>
        修改状态 = 2
    };

    /// <summary>
    /// 处方状态
    /// </summary>
    public enum PresStatus
    {
        /// <summary>
        /// 保存状态
        /// </summary>
        保存状态 = 0,
        /// <summary>
        /// 收费状态
        /// </summary>
        收费状态 = 1,
        /// <summary>
        /// 退费状态
        /// </summary>
        退费状态 = 2,
        /// <summary>
        /// 删除状态
        /// </summary>
        删除状态 = 3,
        /// <summary>
        /// 新建状态
        /// </summary>
        编辑状态 = 4
    };



    /// <summary>
    /// 医技申请类型
    /// </summary>
    public enum MedicalApplyType
    {
        /// <summary>
        /// 医技化验申请
        /// </summary>
        医技化验申请 = 0,
        /// <summary>
        /// 医技检查申请
        /// </summary>
        医技检查申请 = 1,
        /// <summary>
        /// 医技治疗申请
        /// </summary>
        医技治疗申请 = 2
    };



    /// <summary>
    /// 处方皮试状态
    /// </summary>
    public enum SkinTestStatus
    {
        /// <summary>
        /// 不需要皮试
        /// </summary>
        不需要皮试 = 0,
        /// <summary>
        /// 需要皮试
        /// </summary>
        需要皮试 = 1,
        /// <summary>
        /// 皮试阴性
        /// </summary>
        皮试阴性 = 2,
        /// <summary>
        /// 皮试阳性
        /// </summary>
        皮试阳性 = 3,
        /// <summary>
        /// 免试
        /// </summary>
        免试 = 4
    };

    /// <summary>
    /// 处方颜色
    /// </summary>
    public class PresColor
    {
        /// <summary>
        /// 行号
        /// </summary>
        public int rowIndex;
        /// <summary>
        /// 列号
        /// </summary>
        public int colIndex;
        /// <summary>
        /// 行字体颜色
        /// </summary>
        public System.Drawing.Color ForeColor;
        /// <summary>
        /// 行背景颜色
        /// </summary>
        public System.Drawing.Color BackColor;


        /// <summary>
        /// 获得处方字体的颜色
        /// </summary>
        /// <param name="status">处方状态</param>
        /// <returns></returns>
        public static System.Drawing.Color GetPresForeColor(PresStatus status)
        {
            switch (status)
            {
                case PresStatus.编辑状态:
                    return System.Drawing.Color.Blue;
                case PresStatus.收费状态:
                    return System.Drawing.Color.Orange;
                case PresStatus.退费状态:
                    return System.Drawing.Color.Fuchsia;
                default:
                    return System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// 获得处方背景的颜色
        /// </summary>
        /// <param name="itemId">处方项目ID</param>
        /// <param name="status">处方状态</param>
        /// <returns></returns>
        public static System.Drawing.Color GetPresBackColor(int itemId, PresStatus status)
        {
            return itemId <= 0 ? System.Drawing.Color.Ivory
                : (status == PresStatus.编辑状态 ? System.Drawing.Color.Moccasin : System.Drawing.Color.White);
        }
    }


    /// <summary>
    /// 处方列序号
    /// </summary>
    public struct PresColumnIndex
    {
        /// <summary>
        /// 项目编码列序号
        /// </summary>
        public int ItemIdIndex;
        /// <summary>
        /// 项目名称
        /// </summary>
        public int ItemNameIndex;
        /// <summary>
        /// 科室名称列序号
        /// </summary>
        public int DeptNameIndex;
        /// <summary>
        /// 每次用量列序号
        /// </summary>
        public int UsageAmountIndex;
        /// <summary>
        /// 用量单位列序号
        /// </summary>
        public int UsageUnitIndex;
        /// <summary>
        /// 剂数列序号
        /// </summary>
        public int DosageIndex;
        /// <summary>
        /// 用法列序号
        /// </summary>
        public int UsageIndex;
        /// <summary>
        /// 频次列序号
        /// </summary>
        public int FrequencyIndex;
        /// <summary>
        /// 天数列序号
        /// </summary>
        public int DaysIndex;
        /// <summary>
        /// 开药数量列序号
        /// </summary>
        public int ItemAmountIndex;
        /// <summary>
        /// 开药单位列序号
        /// </summary>
        public int ItemUnitIndex;
        /// <summary>
        /// 嘱托列序号
        /// </summary>
        public int EntrustIndex;
    }
}
