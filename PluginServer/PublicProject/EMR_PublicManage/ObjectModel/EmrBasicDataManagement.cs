using System.Data;
using EFWCoreLib.CoreFrame.Business;
using EMR_PublicManage.Dao;

namespace EMR_PublicManage.ObjectModel
{
    /// <summary>
    /// Emr基础数据处理
    /// </summary>
    public class EmrBasicDataManagement : AbstractObjectModel
    {
        /// <summary>
        /// 获取三测单时间管理类型数据
        /// </summary>
        /// <returns>时间类型列表</returns>
        public DataTable GetTimeManageData()
        {
            return NewDao<IEmrPublicManageDao>().GetTimeManageData();
        }
    }
}
