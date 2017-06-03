using EFWCoreLib.CoreFrame.Business;
using HIS_PublicManage.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_PublicManage.ObjectModel
{
    /// <summary>
    /// 流水号来源处理
    /// </summary>
    public class SerialNumberSource : AbstractObjectModel
    {
        /// <summary>
        /// 获取流水号,门诊、住院、病案号
        /// </summary>
        /// <param name="snType"></param>
        /// <returns></returns>
        public string GetSerialNumber(SnType snType)
        {
            return GetSerialNumber(snType, 0, "");
        }
        /// <summary>
        /// 得到当前序号,需要自己构造显示流水号
        /// </summary>
        /// <param name="snType">流水号类型</param>
        /// <returns></returns>
        public int GetCurrSequence(SnType snType, int deptId, string type)
        {
            //1.先对数据库序号+1
            //1.1如果Basic_SerialNumberSource表中没有此类型，则创建此类型的序号记录
            //1.2如果CurrDate的日期跟当前不一致，则更改为当前，并将序号重置为1
            //2.再取最新的序号
            IPublicManageDao pmDao = NewDao<IPublicManageDao>();
            switch (snType)
            {
                case SnType.门诊流水号:
                case SnType.住院流水号:
                case SnType.药品:
                case SnType.物资:
                    if (pmDao.IsExistSNType((int)snType, deptId, type))
                    {
                        if (pmDao.IsTodaySNType((int)snType, deptId, type))
                        {
                            return pmDao.UpdateTodaySerialNumber((int)snType, deptId, type);
                        }
                        else
                        {
                            return pmDao.UpdateNoTodaySerialNumber((int)snType, deptId, type);
                        }
                    }
                    else
                    {
                        return pmDao.InsertSerialNumber((int)snType, deptId, type);
                    }
                case SnType.病案号:
                case SnType.医嘱组号:
                    if (pmDao.IsExistSNType((int)snType, deptId, type))
                    {
                        return pmDao.UpdateTodaySerialNumber((int)snType, deptId, type);
                    }
                    else
                    {
                        return pmDao.InsertSerialNumber((int)snType, deptId, type);
                    }
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 药品物资获取业务类型
        /// </summary>
        /// <param name="snType"></param>
        /// <param name="deptId"></param>
        /// <param name="type"></param>
        public string GetSerialNumber(SnType snType, int deptId, string type)
        {
            string number = "";
            switch (snType)
            {
                case SnType.门诊流水号:
                case SnType.住院流水号://20160701001
                    number = DateTime.Now.ToString("yyyyMMdd") + GetCurrSequence(snType, deptId, type).ToString("000");
                    return number;
                case SnType.病案号:
                    number = GetCurrSequence(snType, deptId, type).ToString("00000000");
                    return number;
                case SnType.药品:
                case SnType.物资://0012016082201
                    number = type + DateTime.Now.ToString("yyyyMMdd") + GetCurrSequence(snType, deptId, type).ToString("00");
                    return number;
                case SnType.医嘱组号:
                    return GetCurrSequence(snType, deptId, type).ToString();
                default:
                    return number;
            }
        }
    }
    /// <summary>
    /// 流水号类型
    /// </summary>
    public enum SnType
    {
        门诊流水号 = 0, 住院流水号 = 1, 病案号 = 2, 药品 = 3, 物资 = 4, 医嘱组号 = 5
    }
}
