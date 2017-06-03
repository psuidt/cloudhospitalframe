using System.Data;
using EFWCoreLib.WinformFrame.Controller;
using HIS_Entity.BasicData;

namespace HIS_BasicData.Winform.IView.ExamItem
{
    /// <summary>
    /// 组合项目维护接口
    /// </summary>
    public interface IFrmExamItem : IBaseView
    {
        /// <summary>
        /// 加载机构列表
        /// </summary>
        /// <param name="dt">机构列表</param>
        /// <param name="defaultWorkID">默认机构</param>
        void loadWorkerDataBox(DataTable dt,int defaultWorkID);

        /// <summary>
        /// 加载组合项目类型
        /// </summary>
        /// <param name="dt">组合项目类型列表</param>
        void loadExamClassBox(DataTable dt);

        /// <summary>
        /// 加载组合项目
        /// </summary>
        /// <param name="dt">组合项目列表</param>
        void loadDeptDataBox(DataTable dt);

        /// <summary>
        /// 绑定样本列表
        /// </summary>
        /// <param name="sampleDt">样本列表</param>
        void loadSampleList(DataTable sampleDt);

        /// <summary>
        /// 绑定组合项目类型
        /// </summary>
        /// <param name="dt">组合项目类型</param>
        void loadExamTypeGrid(DataTable dt);

        /// <summary>
        /// 绑定组合项目类型
        /// </summary>
        /// <param name="dt">组合项目类型</param>
        void loadExamTypeBox(DataTable dt);

        /// <summary>
        /// 绑定统计大类列表
        /// </summary>
        /// <param name="dt">统计大类列表</param>
        void loadStatItemBox(DataTable dt);

        /// <summary>
        /// 绑定组合项目列表
        /// </summary>
        /// <param name="dt">组合项目列表</param>
        void loadExamItemGrid(DataTable dt);

        /// <summary>
        /// 绑定组合项目费用列表
        /// </summary>
        /// <param name="dt">组合项目费用列表</param>
        void loadExamFeeGrid(DataTable dt);

        /// <summary>
        /// 绑定组合项目弹出网格费用数据源
        /// </summary>
        /// <param name="dt">弹出网格费用数据源</param>
        void loadExamFeeShowCard(DataTable dt);

        /// <summary>
        /// 当前组合项目
        /// </summary>
        Basic_ExamItem CurrExamItem
        {
            get; set;
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        void registerEvent();
    }
}
