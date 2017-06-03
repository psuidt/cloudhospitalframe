using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_Entity.MIManage.Common
{
    public class Tools
    {
        public static DateTime ToDateTime(string s, DateTime dtime)
        {
            DateTime dateTime = dtime;
            try
            {
                dateTime = Convert.ToDateTime(s);
            }
            catch
            { }
            return dtime;
        }

        public static DateTime ToDateTime2(string s, DateTime dtime)
        {
            DateTime dateTime = dtime;
            if (s.Length == 14)
            {

                try
                {
                    string sTime = s.Substring(0, 4) + "-" + s.Substring(4, 2) + "-" + s.Substring(6, 2) + " " + s.Substring(8, 2) + ":" + s.Substring(10, 2) + ":" + s.Substring(12, 2);

                    dateTime = Convert.ToDateTime(sTime);
                }
                catch
                { }
            }
            return dtime;
        }

        public static decimal ToDecimal(string s, decimal d)
        {
            decimal dc = d;
            try
            {
                dc = Convert.ToDecimal(s);
            }
            catch
            { }
            return dc;
        }

        public static Int32 ToInt32(string s, Int32 i)
        {
            Int32 i32 = i;
            try
            {
                i32 = Convert.ToInt32(s);
            }
            catch
            { }
            return i32;
        }


    }
}
