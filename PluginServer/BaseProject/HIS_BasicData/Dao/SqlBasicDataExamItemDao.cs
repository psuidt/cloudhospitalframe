using System.Data;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_BasicData.Dao
{
    /// <summary>
    /// 组合项目数据访问对象
    /// </summary>
    public class SqlBasicDataExamItemDao : AbstractDao, IBasicDataExamItemDao
    {
        /// <summary>
        /// 删除组合项目关联费用
        /// </summary>
        /// <param name="examitemId">组合项目ID</param>
        /// <returns>true删除成功</returns>
        public bool DeleteExamFee(int examitemId)
        {
            oleDb.DoCommand(@"DELETE FROM Basic_ExamItemFee WHERE ExamItemID="+examitemId);
            return true;
        }

        /// <summary>
        /// 删除组合项目
        /// </summary>
        /// <param name="examitemId">组合项目ID</param>
        /// <returns>true删除成功</returns>
        public bool DeleteExamItem(int examitemId)
        {
            oleDb.DoCommand(@"UPDATE Basic_ExamItem SET DelFlag=1 WHERE ExamItemID=" + examitemId);
            return true;
        }

        /// <summary>
        /// 删除组合项目类型
        /// </summary>
        /// <param name="examtypeId">组合项目类型ID</param>
        /// <returns>true：删除成功</returns>
        public bool DeleteExamType(int examtypeId)
        {
            oleDb.DoCommand(@"UPDATE Basic_ExamType SET DelFlag=1 WHERE ExamTypeID="+examtypeId);
            return true;
        }

        /// <summary>
        /// 获取分类
        /// </summary>
        /// <returns>组合项目分类</returns>
        public DataTable GetExamClass()
        {
            return oleDb.GetDataTable(@"SELECT 1 ID,'检查' Name
                                        UNION ALL
                                        SELECT 2 ID,'检验' Name
                                        UNION ALL
                                        SELECT 3 ID,'手术' Name
                                        UNION ALL
                                        SELECT 4 ID,'治疗' Name");
        }

        /// <summary>
        /// 获取组合项目费用
        /// </summary>
        /// <param name="examitemId">组合项目ID</param>
        /// <returns>组合项目费用列表</returns>
        public DataTable GetExamFee(int examitemId)
        {
            string strsql = @"SELECT ID,ExamItemID, a.FeeClass,a.ItemID,a.ItemName,ItemUnit,b.SellPrice,ItemAmount
                                ,(CASE a.FeeClass WHEN 1 THEN '药品' WHEN 2 THEN '材料' WHEN 3 THEN '项目' END)  FeeClassName
                                FROM Basic_ExamItemFee a LEFT JOIN ViewFeeItem_SimpleList b ON a.ItemID=b.ItemID 
                                WHERE a.ExamItemID={0}";
            strsql = string.Format(strsql, examitemId);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取组合项目
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="examtypeId">组合项目类型ID</param>
        /// <param name="searchStr">检索条件</param>
        /// <returns>组合项目列表</returns>
        public DataTable GetExamItem(int workId, int examtypeId, string searchStr)
        {
            string strsql = @"SELECT ExamItemID,(CASE b.ExamClass WHEN 1 THEN '检查' WHEN 2 THEN '检验' WHEN 3 THEN '治疗' WHEN 4 THEN '手术' END) ExamClassName,a.ExamTypeID,b.ExamTypeName,StatID,dbo.fnGetStatItemName(StatID) StatName,ExamItemName,ItemShortName,a.DelFlag,(CASE  a.DelFlag WHEN 1 THEN '已停用' ELSE '已启用' END) StopState 
                                FROM Basic_ExamItem a INNER JOIN Basic_ExamType b ON a.ExamTypeID=b.ExamTypeID
                                WHERE a.WorkID={0} AND (a.ExamTypeID={1} OR -1={1}) AND a.ExamItemName LIKE '%{2}%'";
            strsql = string.Format(strsql, workId, examtypeId, searchStr);
            return oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取组合项目类型列表
        /// </summary>
        /// <param name="workId">机构ID</param>
        /// <param name="examclass">分类</param>
        /// <returns>组合项目类型列表</returns>
        public DataTable GetExamType(int workId, int examclass)
        {
            string strsql = @"SELECT ReportNo,SampleID,ExamTypeID,ExamClass,ExamTypeName,dbo.fnGetDeptName(ExecDeptID) ExecDeptName,ExecDeptID,MergeResult,ExamFormID,DeptDescript,DelFlag,(CASE  DelFlag WHEN 1 THEN '已停用' ELSE '已启用' END) StopState FROM Basic_ExamType WHERE WorkID={0} AND ExamClass={1}";
            strsql = string.Format(strsql, workId, examclass);
            return oleDb.GetDataTable(strsql);
        }
    }
}
