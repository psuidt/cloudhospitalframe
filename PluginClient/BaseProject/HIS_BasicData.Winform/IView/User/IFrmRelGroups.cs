using System.Data;
using EFWCoreLib.WinformFrame.Controller;

namespace HIS_BasicData.Winform.ViewForm.User
{
    /// <summary>
    /// 用户关联角色接口
    /// </summary>
    public interface IFrmRelGroups : IBaseView
    {
        /// <summary>
        /// 当前用户ID
        /// </summary>
        int UserId { get; set; }

        /// <summary>
        /// 当前机构ID
        /// </summary>
        int WorkId { get; set; }

        /// <summary>
        /// 绑定角色列表
        /// </summary>
        /// <param name="groups">角色列表</param>
        void LoadRelGroups(DataTable groups);

        /// <summary>
        /// 返回结果
        /// </summary>
        bool Result { get; set; }
    }
}
