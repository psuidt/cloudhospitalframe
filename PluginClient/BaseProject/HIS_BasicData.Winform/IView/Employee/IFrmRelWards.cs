using System.Data;
using EFWCoreLib.WinformFrame.Controller;

namespace HIS_BasicData.Winform.ViewForm.Employee
{
    /// <summary>
    /// 人员关联病区接口
    /// </summary>
    public interface IFrmRelWards : IBaseView
    {
        /// <summary>
        /// 当前人员ID
        /// </summary>
        int EmpId { get; set; }

        /// <summary>
        /// 当前机构ID
        /// </summary>
        int WorkId { get; set; }

        /// <summary>
        /// 加载病区列表与人员关联关系
        /// </summary>
        /// <param name="depts">科室列表</param>
        void LoadRelWards(DataTable depts);

        /// <summary>
        /// 返回结果
        /// </summary>
        bool Result { get; set; }
    }
}
