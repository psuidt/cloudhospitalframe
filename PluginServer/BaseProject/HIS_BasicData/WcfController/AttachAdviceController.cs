using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.ObjectModel;
using HIS_Entity.ClinicManage;
using HIS_PublicManage.ObjectModel;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 说明性医嘱服务端控制器
    /// </summary>
    [WCFController]
    public class AttachAdviceController: WcfServerController
    {
        /// <summary>
        /// 获取说明性医嘱列表
        /// </summary>
        /// <returns>说明性医嘱列表</returns>
        [WCFMethod]
        public ServiceResponseData GetAttachAdviceList()
        {
            var workerId = requestData.GetData<int>(0);
            var searchText = requestData.GetData<string>(1);
            var dt = NewObject<AttachAdviceMrg>().GetAttachAdviceInfo(workerId, searchText);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 获取单位列表
        /// </summary>
        /// <returns>单位列表</returns>
        [WCFMethod]
        public ServiceResponseData GetUintList()
        {
            var dt = NewObject<BasicDataManagement>().GetUnit();
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 验证说明性医嘱是否重复
        /// </summary>
        /// <returns>false：重复</returns>
        [WCFMethod]
        public ServiceResponseData CheckAttachAdviceInfo()
        {
            var id = requestData.GetData<int>(0);
            var searchText = requestData.GetData<string>(1);
            var workerId = requestData.GetData<int>(2);
            var res = NewObject<AttachAdviceMrg>().CheckAttachAdviceInfo(id, searchText, workerId);
            responseData.AddData(res);
            return responseData;
        }

        /// <summary>
        /// 保存说明性医嘱数据
        /// </summary>
        /// <returns>保存成功的行数</returns>
        [WCFMethod]
        public ServiceResponseData SaveAttachAdviceInfo()
        {
            var enti= requestData.GetData<Basic_AttachAdvice>(0);
            var workID = requestData.GetData<int>(1);
            SetWorkId(workID);
            var res = NewObject<AttachAdviceMrg>().SaveAttachAdivce(enti);
            responseData.AddData(res);
            return responseData;
        }
    }
}
