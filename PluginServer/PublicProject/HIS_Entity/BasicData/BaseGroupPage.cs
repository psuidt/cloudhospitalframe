using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFWCoreLib.CoreFrame.Orm;
using EFWCoreLib.CoreFrame.Business;

namespace HIS_Entity.BasicData
{
    [Serializable]
    [Table(TableName = "BaseGroupPage", EntityType = EntityType.Table, IsGB = false)]
    public class BaseGroupPage:AbstractEntity
    {
        private int  _id;
        /// <summary>
        /// 
        /// </summary>
        [Column(FieldName = "Id", DataKey = true, Match = "", IsInsert = false)]
        public int Id
        {
            get { return  _id; }
            set {  _id = value; }
        }

        private int  _groupid;
        /// <summary>
        /// 分组角色ID
        /// </summary>
        [Column(FieldName = "GroupId", DataKey = false, Match = "", IsInsert = true)]
        public int GroupId
        {
            get { return  _groupid; }
            set {  _groupid = value; }
        }

        private int  _pageid;
        /// <summary>
        /// 页面ID
        /// </summary>
        [Column(FieldName = "PageId", DataKey = false, Match = "", IsInsert = true)]
        public int PageId
        {
            get { return  _pageid; }
            set {  _pageid = value; }
        }

    }
}
