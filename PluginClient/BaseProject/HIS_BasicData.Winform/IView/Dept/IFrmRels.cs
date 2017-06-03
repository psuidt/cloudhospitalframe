using System.Data;
using EFWCoreLib.WinformFrame.Controller;

namespace HIS_BasicData.Winform.ViewForm.Dept
{
    /// <summary>
    /// 关键接口
    /// </summary>
    public interface IFrmRels : IBaseView
    {
        /// <summary>
        /// 当前病区ID
        /// </summary>
        int WardId { get; set; }

        /// <summary>
        /// 当前机构ID
        /// </summary>
        int WorkId { get; set; }

        /// <summary>
        /// 加载科室列表与病区关联关系
        /// </summary>
        /// <param name="rels">科室列表与病区关联关系</param>
        void LoadRels(DataTable rels);

        /// <summary>
        /// 返回结果
        /// </summary>
        bool Result { get; set; }
    }
}
