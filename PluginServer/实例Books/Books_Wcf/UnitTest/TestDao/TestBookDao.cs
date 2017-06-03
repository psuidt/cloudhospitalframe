using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books_Wcf.Dao;
using EFWCoreLib.UnitTestFrame;

namespace Books_Wcf.UnitTest.TestDao.Dao
{
    public class TestBookDao : BaseDaoUnitTest,IBookDao
    {

        public DataTable GetBooks(string searchChar, int flag)
        {
            DataTable dt = new DataTable();
            createDataTable(dt, "Id|int,BookName|string,BuyPrice|decimal,BuyDate|DateTime,Flag|int");
            adddataDataTable(dt, "1,人月神话,10.00,2016-01-01,0");
            return dt;
        }
    }
}
