using System;
using System.Data;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Dao;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.ObjectModel
{
    /// <summary>
    /// 频次维护
    /// </summary>
    public class FrequencyMrg : AbstractObjectModel
    {
        /// <summary>
        /// 获取频次信息
        /// </summary>
        /// <param name="name">频次名称</param>
        /// <param name="pyCode">拼音码</param>
        /// <param name="wbCode">五笔码</param>
        /// <param name="workID">医疗机构ID</param>
        /// <returns>频次信息</returns>
        public DataTable QueryFrequencyInfo(string name, string pyCode, string wbCode, int workID)
        {
            return NewDao<IBasicFrequencyDao>().QueryFrequencyInfo(name, pyCode, wbCode, workID);
        }

        /// <summary>
        /// 检查频次名称是否重名
        /// </summary>
        /// <param name="name">频次名称</param>
        /// <param name="workID">医疗机构ID</param>
        /// <param name="frequencyID">频次ID</param>
        /// <returns>false：重名</returns>
        public bool CheckFrequencyName(string name, int workID,int frequencyID)
        {
            DataTable dtCheckInfo= NewDao<IBasicFrequencyDao>().CheckFrequencyName(name, workID);

            if (dtCheckInfo.Rows.Count>0)
            {
                //FrequencyID>0 表示是修改名称时校验
                if (frequencyID>0)
                {
                   return (frequencyID == Convert.ToInt32(dtCheckInfo.Rows[0]["FrequencyID"]))? true : false;
                }
                else
                {
                    return false;   //false,频次名称重复不允许保存
                }
            }
            else
            {
                return true;  //true,频次名称没有重复可以保存
            }
        }

        /// <summary>
        /// 保存频次数据
        /// </summary>
        /// <param name="freqEntity">频次实体类</param>
        /// <param name="workID">医疗机构ID</param>
        /// <returns>保存成功的行数</returns>
        public int SaveFrequency(Basic_Frequency freqEntity,int workID)
        {
            this.BindDb(freqEntity);
            SetWorkId(workID);
            return freqEntity.save();
        }
    }
}
