using System;
using System.Data;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Dao;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.ObjectModel
{
    /// <summary>
    /// 说明性医嘱维护
    /// </summary>
    public class AttachAdviceMrg : AbstractObjectModel
    {
        /// <summary>
        /// 获取说明性医嘱列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">检索条件</param>
        /// <returns>说明性医嘱列表</returns>
        public DataTable GetAttachAdviceInfo(int workID, string name)
        {
            return NewDao<IBasicAttachAdviceDao>().GetAttachAdviceInfo(workID, name);
        }

        /// <summary>
        /// 检查说明性医嘱是否重复
        /// </summary>
        /// <param name="id">医嘱ID</param>
        /// <param name="name">医嘱名</param>
        /// <param name="workID">机构ID</param>
        /// <returns>false：重复</returns>
        public bool CheckAttachAdviceInfo(int id, string name,int workID)
        {
            DataTable dt = NewDao<IBasicAttachAdviceDao>().CheckAttachAdviceInfo(id, name,workID);
            if (dt.Rows.Count > 0)
            {
                if (id > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["ID"]) == id)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 保存说明性医嘱
        /// </summary>
        /// <param name="enti">说明性医嘱</param>
        /// <returns>保存成功的行数</returns>
        public int SaveAttachAdivce(Basic_AttachAdvice enti )
        {
            this.BindDb(enti);
           return  enti.save();
        }
    }
}
