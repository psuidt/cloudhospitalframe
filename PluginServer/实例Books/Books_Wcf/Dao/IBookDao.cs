using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Wcf.Dao
{
    public interface IBookDao
    {
        System.Data.DataTable GetBooks(string searchChar, int flag);
    }
}
