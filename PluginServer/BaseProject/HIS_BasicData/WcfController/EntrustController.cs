using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.ObjectModel;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 嘱托维护服务端控制器
    /// </summary>
    [WCFController]
    public class EntrustController: WcfServerController
    {
        /// <summary>
        /// 获取嘱托列表
        /// </summary>
        /// <returns>嘱托列表</returns>
        [WCFMethod]
        public ServiceResponseData GetEntrustList()
        {
            var workerId = requestData.GetData<int>(0);
            var searchText = requestData.GetData<string>(1);
            var channels =NewObject<EntrustMrg>().GetEntrustList(workerId, searchText);
            responseData.AddData(channels);
            return responseData;
        }

        /// <summary>
        /// 检查嘱托名称是否有重复
        /// </summary>
        /// <returns>false：重复</returns>
        [WCFMethod]
        public ServiceResponseData CheckEntrustName()
        {
            var workerId = requestData.GetData<int>(2);
            var searchText = requestData.GetData<string>(1);
            var id = requestData.GetData<int>(0);
            var res = NewObject<EntrustMrg>().CheckEntrustName(searchText,id,workerId);
            responseData.AddData(res);
            return responseData;
        }

        /// <summary>
        /// 保存嘱托
        /// </summary>
        /// <returns>保存成功的行数</returns>
        [WCFMethod]
        public ServiceResponseData SaveEntrust()
        {
            var entrustInfo = requestData.GetData<Basic_Entrust>(0);
            var workID = requestData.GetData<int>(1);
            SetWorkId(workID);
            var res=NewObject<EntrustMrg>().SaveEntrust(entrustInfo);
            responseData.AddData(res);
            return responseData;
        }
    }
}
