using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Dao;
using HIS_Entity.BasicData;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.ObjectModel
{
    /// <summary>
    /// 用法维护
    /// </summary>
    public class ChannelMrg : AbstractObjectModel
    {
        /// <summary>
        /// 保存用法信息
        /// </summary>
        /// <param name="bchannel">用法信息</param>
        /// <param name="feelist">费用列表</param>
        /// <param name="workid">机构ID</param>
        /// <returns>保存成功或失败</returns>
        public int SaveChannel(Basic_Channel bchannel, List<Basic_ChannelFee> feelist, int workid)
        {
            int result = bchannel.save();
            int isdel = NewDao<IBasicDataChannelDao>().DeleteChannelFees(bchannel.ID);
            foreach (Basic_ChannelFee bfee in feelist)
            {
                this.BindDb(bfee);
                bfee.save();
            }

            return result;
        }

        /// <summary>
        /// 检查是否存在相同名称的用法
        /// </summary>
        /// <param name="bchannel">用法信息</param>
        /// <param name="channels">已存在的用法列表</param>
        /// <returns>true：存在</returns>
        public bool CheckisExit(Basic_Channel bchannel, DataTable channels)
        {
            DataRow dr = channels.Select("ChannelName='" + bchannel.ChannelName + "' and ID<>" + bchannel.ID + string.Empty).FirstOrDefault();
            if (dr == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
