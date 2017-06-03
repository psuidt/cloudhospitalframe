using System.Collections.Generic;
using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 统计大类服务控制器
    /// </summary>
    [WCFController]
    public class StatItemController : WcfServerController
    {
        /// <summary>
        /// 获取中心的统计分类
        /// </summary>
        /// <returns>统计分类列表</returns>
        [WCFMethod]
        public ServiceResponseData GetStatItemData()
        {
            int isShowStop = requestData.GetData<int>(0);
            string where = isShowStop == 1 ? string.Empty : "DelFlag=0";
            List<Basic_CenterStatItem> listStat = NewObject<Basic_CenterStatItem>().getlist<Basic_CenterStatItem>(where);
            responseData.AddData(listStat);
            return responseData;
        }

        /// <summary>
        /// 保存统计大类
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        public ServiceResponseData SaveStatItem()
        {
            Basic_CenterStatItem statitem = requestData.GetData<Basic_CenterStatItem>(0);
            this.BindDb(statitem);
            statitem.save();
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 停用启用大类
        /// </summary>
        /// <returns>true：操作成功</returns>
        [WCFMethod]
        public ServiceResponseData SwitchStatItem()
        {
            int statID = requestData.GetData<int>(0);
            int val = requestData.GetData<int>(1);
            NewDao<IBasicDataStatItemDao>().SwitchStatItem(statID, val);
            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 获取机构数据
        /// </summary>
        /// <returns>机构列表</returns>
        [WCFMethod]
        public ServiceResponseData GetWorkerData()
        {
            //机构
            List<BaseWorkers> workers = NewObject<BaseWorkers>()
                .getlist<BaseWorkers>(" DelFlag = 0 ");
            responseData.AddData(workers);
            return responseData;
        }

        /// <summary>
        /// 获取本院的统计大类
        /// </summary>
        /// <returns>统计大类列表</returns>
        [WCFMethod]
        public ServiceResponseData GetHostStatItemData()
        {
            int workID = requestData.GetData<int>(0);
            int isShowStop = requestData.GetData<int>(1);
            string where = isShowStop == 1 ? string.Empty : "DelFlag=0";
            List<Basic_CenterStatItem> listStat = NewObject<Basic_CenterStatItem>().getlist<Basic_CenterStatItem>(where);
            responseData.AddData(listStat);

            List<Basic_StatItem> listItem = NewDao<IBasicDataStatItemDao>().GetHostStatItemData(workID);
            responseData.AddData(listItem);
            return responseData;
        }

        /// <summary>
        /// 获取统计明细分类
        /// </summary>
        /// <returns>明细分类列表</returns>
        [WCFMethod]
        public ServiceResponseData GetSubClassData()
        {
            int workID = requestData.GetData<int>(0);
            int subtype = requestData.GetData<int>(1);
            List<Basic_StatItemSubclass> listsubclass = NewDao<IBasicDataStatItemDao>().GetSubClassData(workID, subtype);
            responseData.AddData(listsubclass);
            return responseData;
        }

        /// <summary>
        /// 保存本院统计分类
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        public ServiceResponseData SaveHostStatItem()
        {
            int workID = requestData.GetData<int>(0);
            Basic_StatItem statitem = requestData.GetData<Basic_StatItem>(1);

            SetWorkId(workID);
            this.BindDb(statitem);
            statitem.save();

            //还需要保存分类节点下面的子节点中，如果没有设置数据的默认同父节点一致
            List<Basic_CenterStatItem> listStat = NewObject<Basic_CenterStatItem>().getlist<Basic_CenterStatItem>();
            List<Basic_StatItem> listItem = NewDao<IBasicDataStatItemDao>().GetHostStatItemData(workID);
            savechildstatitem(statitem, listStat, listItem);

            responseData.AddData(true);
            return responseData;
        }

        /// <summary>
        /// 保存子节点下的统计分类
        /// </summary>
        /// <param name="statitem">统计大类信息</param>
        /// <param name="listStat">中心统计大类信息</param>
        /// <param name="listItem">本院统计大类</param>
        private void savechildstatitem(Basic_StatItem statitem, List<Basic_CenterStatItem> listStat, List<Basic_StatItem> listItem)
        {
            foreach (Basic_CenterStatItem item in listStat.FindAll(x => x.PStatID == statitem.StatID))
            {
                Basic_StatItem childitem = listItem.Find(x => x.StatID == item.StatID);
                if (childitem == null)
                {
                    childitem = NewObject<Basic_StatItem>();
                }

                childitem.StatID = item.StatID;
                childitem.StatName = item.StatName;
                childitem.AccItemID = childitem.AccItemID == 0 ? statitem.AccItemID : childitem.AccItemID;
                childitem.CostItemID = childitem.CostItemID == 0 ? statitem.CostItemID : childitem.CostItemID;
                childitem.BaItemID = childitem.BaItemID == 0 ? statitem.BaItemID : childitem.BaItemID;
                childitem.PoItemID = childitem.PoItemID == 0 ? statitem.PoItemID : childitem.PoItemID;
                childitem.OutFpItemID = childitem.OutFpItemID == 0 ? statitem.OutFpItemID : childitem.OutFpItemID;
                childitem.InFpItemID = childitem.InFpItemID == 0 ? statitem.InFpItemID : childitem.InFpItemID;
                childitem.save();
                savechildstatitem(childitem, listStat, listItem);
            }
        }

        /// <summary>
        /// 保存统计明细分类
        /// </summary>
        /// <returns>明细分类列表</returns>
        [WCFMethod]
        public ServiceResponseData SaveSubClass()
        {
            int workID = requestData.GetData<int>(0);
            Basic_StatItemSubclass subclass = requestData.GetData<Basic_StatItemSubclass>(1);

            SetWorkId(workID);
            this.BindDb(subclass);
            subclass.save();
            responseData.AddData(true);
            return responseData;
        }
    }
}
