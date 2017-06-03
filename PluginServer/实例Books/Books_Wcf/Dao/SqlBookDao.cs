using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business;

namespace Books_Wcf.Dao
{
    public class SqlBookDao : AbstractDao, IBookDao
    {
        public DataTable GetBooks(string searchChar, int flag)
        {
            string strsql = @"SELECT * FROM Books WHERE BookName LIKE '%{0}%' AND Flag={1}";
            strsql = string.Format(strsql, searchChar, flag);
            return oleDb.GetDataTable(strsql);
        }
    }
}
