using System;
using System.Collections.Generic;
using System.Data;
using EFWCoreLib.CoreFrame.Business;
using HIS_BasicData.Dao;
using HIS_Entity.ClinicManage;

namespace HIS_BasicData.ObjectModel
{
    /// <summary>
    /// 执行单配置
    /// </summary>
    public class ExexBillMrg: AbstractObjectModel
    {
        /// <summary>
        /// 获取执行单配置列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">执行单名</param>
        /// <param name="py">拼音码</param>
        /// <param name="wb">五笔码</param>
        /// <returns>执行单配置列表</returns>
        public DataTable GetExecBillInfo(int workID, string name, string py, string wb)
        {
            return NewDao<IBasicDataExceBillDao>().GetExecBillInfo(workID, name, py, wb);        
        }

        /// <summary>
        /// 验证执行单名是否重复
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">执行单名</param>
        /// <returns>执行单信息</returns>
        public DataTable CheckExecBillName(int workID, string name)
        {
            return NewDao<IBasicDataExceBillDao>().CheckExecBillName(workID, name);
        }

        /// <summary>
        /// 获取用法列表
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <returns>用法列表</returns>
        public DataTable GetChannelInfo(int workID)
        {
            return NewDao<IBasicDataExceBillDao>().GetChannelInfo(workID);
        }

        /// <summary>
        /// 获取执行单关联的用法列表
        /// </summary>
        /// <param name="billID">执行单ID</param>
        /// <param name="workID">机构ID</param>
        /// <returns>执行单关联的用法列表</returns>
        public DataTable GetExecuteBillChannel(int billID, int workID)
        {
            return NewDao<IBasicDataExceBillDao>().GetExecuteBillChannel(billID,workID);
        }

        /// <summary>
        /// 验证执行单名是否重复
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="name">执行单名</param>
        /// <param name="id">ID</param>
        /// <returns>false：重复</returns>
        public bool CheckName(int workID, string name,int id)
        {
            DataTable dt = NewDao<IBasicDataExceBillDao>().CheckExecBillName(workID, name);
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
        /// 保存执行单配置信息
        /// </summary>
        /// <param name="workID">机构ID</param>
        /// <param name="billEntity">执行单信息</param>
        /// <param name="channelList">用法信息</param>
        /// <param name="delList">执行单关联用法信息</param>
        /// <returns>true：保存成功</returns>
        public int SaveBillChannelInfo(int workID, Basic_ExecuteBills billEntity, List<Basic_ExecuteBillChannel> channelList, List<Basic_ExecuteBillChannel> delList)
        {
            try
            {
                int res = 1;
                this.BindDb(billEntity);
                res=billEntity.save();

                foreach (Basic_ExecuteBillChannel temp in channelList) 
                {
                    this.BindDb(temp);
                    temp.ExecBillID = billEntity.ID;
                    res = temp.save();
                }

                foreach (Basic_ExecuteBillChannel temp in delList)
                {
                    this.BindDb(temp);
                    res = temp.delete();
                }

                return res;
            }
            catch
            {
                return -1;
            }
        }
    }
}
