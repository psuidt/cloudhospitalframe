using EFWCoreLib.CoreFrame.Business.AttributeInfo;
using EFWCoreLib.WcfFrame.DataSerialize;
using EFWCoreLib.WcfFrame.ServerController;
using HIS_BasicData.ObjectModel;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.WcfController
{
    /// <summary>
    /// 频次维护控制器
    /// </summary>
    [WCFController]
    public class FrequencyController : WcfServerController
    {
        /// <summary>
        /// 获取频次信息
        /// </summary>
        /// <returns>频次信息</returns>
        [WCFMethod]
        public ServiceResponseData QueryFrequencyInfo()
        {
            var workerId = requestData.GetData<int>(0);
            var name = requestData.GetData<string>(1);
            var pyCode = requestData.GetData<string>(2);
            var wbCode = requestData.GetData<string>(3);
            var dt = NewObject<FrequencyMrg>().QueryFrequencyInfo(name, pyCode, wbCode, workerId);
            responseData.AddData(dt);
            return responseData;
        }

        /// <summary>
        /// 检查频次名称是否重复
        /// </summary>
        /// <returns>false：重复</returns>
        [WCFMethod]
        public ServiceResponseData CheckFrequencyName()
        {
            var workerID = requestData.GetData<int>(0);
            var name = requestData.GetData<string>(1);
            var frequencyID = requestData.GetData<int>(2);
            var res = NewObject<FrequencyMrg>().CheckFrequencyName(name, workerID, frequencyID);
            responseData.AddData(res);
            return responseData;
        }

        /// <summary>
        /// 保存频次信息
        /// </summary>
        /// <returns>true：保存成功</returns>
        [WCFMethod]
        public ServiceResponseData SaveFrequency()
        {
            var workerID = requestData.GetData<int>(0);
            var freqEntity = requestData.GetData<Basic_Frequency>(1);
            var res = NewObject<FrequencyMrg>().SaveFrequency(freqEntity, workerID);
            responseData.AddData(res);
            return responseData;
        }
    }
}
