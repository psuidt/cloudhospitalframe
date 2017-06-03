using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.MaterialManage
{
    [Serializable]
    [Table(TableName = "MW_SupportDic", EntityType = EntityType.Table, IsGB = false)]
    public class MW_SupportDic:AbstractEntity
    {
        private int  _supplierid;
        /// <summary>
        /// 供应商标识ID
        /// </summary>
        [Column(FieldName = "SupplierID", DataKey = true, Match = "", IsInsert = false)]
        public int SupplierID
        {
            get { return  _supplierid; }
            set {  _supplierid = value; }
        }

        private string  _supportname;
        /// <summary>
        /// 厂家名称
        /// </summary>
        [Column(FieldName = "SupportName", DataKey = false, Match = "", IsInsert = true)]
        public string SupportName
        {
            get { return  _supportname; }
            set {  _supportname = value; }
        }

        private string  _pycode;
        /// <summary>
        /// 拼音码
        /// </summary>
        [Column(FieldName = "PYCode", DataKey = false, Match = "", IsInsert = true)]
        public string PYCode
        {
            get { return  _pycode; }
            set {  _pycode = value; }
        }

        private string  _wbcode;
        /// <summary>
        /// 五笔码
        /// </summary>
        [Column(FieldName = "WBCode", DataKey = false, Match = "", IsInsert = true)]
        public string WBCode
        {
            get { return  _wbcode; }
            set {  _wbcode = value; }
        }

        private string  _phoneno;
        /// <summary>
        /// 联系电话
        /// </summary>
        [Column(FieldName = "PhoneNO", DataKey = false, Match = "", IsInsert = true)]
        public string PhoneNO
        {
            get { return  _phoneno; }
            set {  _phoneno = value; }
        }

        private string  _linkman;
        /// <summary>
        /// 联系人
        /// </summary>
        [Column(FieldName = "LinkMan", DataKey = false, Match = "", IsInsert = true)]
        public string LinkMan
        {
            get { return  _linkman; }
            set {  _linkman = value; }
        }

        private string  _address;
        /// <summary>
        /// 地址
        /// </summary>
        [Column(FieldName = "Address", DataKey = false, Match = "", IsInsert = true)]
        public string Address
        {
            get { return  _address; }
            set {  _address = value; }
        }

        private int  _delflag;
        /// <summary>
        /// 删除标识
        /// </summary>
        [Column(FieldName = "DelFlag", DataKey = false, Match = "", IsInsert = true)]
        public int DelFlag
        {
            get { return  _delflag; }
            set {  _delflag = value; }
        }

    }
}
