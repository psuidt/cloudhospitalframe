using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books_Wcf.Entity;
using EFWCoreLib.CoreFrame.DbProvider.SqlPagination;

namespace Books_Wcf.UnitTest.TestEntity
{
    public class UnBooks : Books
    {
        public override int save(string alias)
        {
            if (this.Flag == 1)
                throw new Exception("数据状态不对");
            return 1;
        }

        public override int delete(object key, string alias)
        {
            return 1;
        }

        public override object getmodel(object key, string alias)
        {
            return this;
        }

        public override List<T> getlist<T>(PageInfo pageInfo, string where, string alias)
        {
            List<T> resultList = new List<T>();
            return resultList;
        }

        public override DataTable gettable(PageInfo pageInfo, string where, string alias)
        {
            return new DataTable();
        }

    }
}
