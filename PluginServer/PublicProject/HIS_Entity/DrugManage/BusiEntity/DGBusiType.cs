using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.DrugManage
{
    /// <summary>
    /// 业务类型实体
    /// </summary>
    public class DGBusiType
    {
        /// <summary>
        /// 业务编码
        /// </summary>
        public string BusiCode
        {
            get;
            set;
        }

        /// <summary>
        /// 业务类型名称
        /// </summary>
        public string BusiTypeName
        {
            get;
            set;
        }

        /// <summary>
        /// 说明
        /// </summary>
        public string Remark
        {
            get;
            set;
        }

        /// <summary>
        /// 统计是否到科室
        /// </summary>
        public bool NeedToDept
        {
            get;
            set;
        }

        /// <summary>
        /// 头表名
        /// </summary>
        public string HeadTableName
        {
            get;
            set;
        }

        /// <summary>
        ///明细表名 
        /// </summary>
        public string DetailTableName
        {
            get;
            set;
        }

        /// <summary>
        /// 明细字段名称
        /// </summary>
        public string DetailIdFieldName
        {
            get;
            set;
        }

        /// <summary>
        /// 主表和明细表关联表达式
        /// </summary>
        public string JoinExpress
        {
            get;
            set;
        }

        /// <summary>
        /// 统计科室字段名称
        /// </summary>
        public string DeptFieldName
        {
            get;
            set;
        }

        /// <summary>
        /// 是否供应商
        /// </summary>
        public bool IsSupplier
        {
            get;
            set;
        }
        /// <summary>
        /// 统计类型0借方，1贷方
        /// </summary>
        public DGEnum.StatisticType STType
        {
            get;
            set;
        }
    }
}
