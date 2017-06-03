using System.Data;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Dao;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.ObjectModel
{
    /// <summary>
    /// 嘱托管理控制器
    /// </summary>
    public class EntrustMrg : AbstractObjectModel
    {
        /// <summary>
        /// 获取嘱托列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">检索条件</param>
        /// <returns>嘱托列表</returns>
        public DataTable GetEntrustList(int workID, string name)
        {
            return NewDao<IBasicDataEntrustDao>().GetEntrustList(workID, name);
        }

        /// <summary>
        /// 检查嘱托是否重复
        /// </summary>
        /// <param name="name">嘱托名</param>
        /// <param name="entrustID">嘱托ID</param>
        /// <param name="workID">机构ID</param>
        /// <returns>false：重复</returns>
        public bool CheckEntrustName(string name, int entrustID,int workID)
        {
            return NewDao<IBasicDataEntrustDao>().CheckEntrustName(name, entrustID, workID);
        }

        /// <summary>
        /// 保存嘱托
        /// </summary>
        /// <param name="entity">嘱托</param>
        /// <returns>保存成功行数</returns>
        public int SaveEntrust(Basic_Entrust entity)
        {
            this.BindDb(entity);
            return entity.save();
        }
    }
}
