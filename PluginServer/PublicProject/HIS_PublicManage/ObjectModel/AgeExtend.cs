using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_PublicManage.ObjectModel
{
    /// <summary>
    /// 年龄扩展类
    /// </summary>
    public class AgeExtend
    {
        /// <summary>
        /// 将年龄转换为出生日期
        /// </summary>
        /// <param name="age">年龄</param>
        /// <returns>出生日期</returns>
        public static DateTime GetDateTime(AgeValue age)
        {
            System.DateTime date = DateTime.Now;

            date = date.AddYears((-1) * age.Y_num);

            date = date.AddMonths((-1) * age.M_num);

            date = date.AddDays((-1) * age.D_num);

            date = date.AddHours((-1) * age.H_num);

            return date;
        }
        /// <summary>
        /// 将年龄转换为出生日期
        /// </summary>
        /// <param name="AgeStrEN">年龄字符串</param>
        /// <returns></returns>
        public static DateTime GetDateTime(string AgeStrEN)
        {
            return GetDateTime(new AgeValue(AgeStrEN));
        }
        /// <summary>
        /// 将出生日期转换为年龄
        /// </summary>
        /// <param name="birthday">出生日期</param>
        /// <returns>年龄</returns>
        public static AgeValue GetAgeValue(DateTime birthday)
        {
            AgeValue age = new AgeValue();
            System.DateTime current = DateTime.Now;

            int _year = current.Year - birthday.Year;
            int _month = current.Month - birthday.Month;
            int _day = current.Day - birthday.Day;
            int _hour = current.Hour - birthday.Hour;
            int _minute = current.Minute - birthday.Minute;

            if (_minute < 0)
            {
                _hour = _hour - 1;
                _minute = _minute + 60;
            }
            if (_hour < 0)
            {
                _day = _day - 1;
                _hour = _hour + 24;
            }
            if (_day < 0)
            {
                _month = _month - 1;
                _day = _day + DateTime.DaysInMonth(birthday.Year, birthday.Month);
            }
            if (_month < 0)
            {
                _year = _year - 1;
                _month = _month + 12;
            }

            age.Y_num = _year;
            age.M_num = _month;
            age.D_num = _day;
            age.H_num = _hour;

            if (_year >= 15)
            {
                age.M_num = 0;
                age.D_num = 0;
                age.H_num = 0;
            }
            else if (_year >= 1)
            {
                age.D_num = 0;
                age.H_num = 0;
            }
            else if (_month >= 1)
            {
                age.H_num = 0;
            }
            return age;
        }
    }
    /// <summary>
    /// 年龄
    /// </summary>
    public class AgeValue
    {
        public int Y_num;
        public int M_num;
        public int D_num;
        public int H_num;

        public AgeValue()
        {
        }
        /// <summary>
        /// 实列化
        /// </summary>
        /// <param name="AgeStrEN">如：Y12</param>
        public AgeValue(string AgeStrEN)
        {
            try
            {
                string type = AgeStrEN.Substring(0, 1);
                string num = AgeStrEN.Substring(1, AgeStrEN.Length - 1);
                Y_num = 0;
                M_num = 0;
                D_num = 0;
                H_num = 0;
                switch (type)
                {
                    case "Y":
                        Y_num = Convert.ToInt32(num);
                        break;
                    case "M":
                        M_num= Convert.ToInt32(num);
                        break;
                    case "D":
                        D_num = Convert.ToInt32(num);
                        break;
                    case "H":
                        H_num = Convert.ToInt32(num);
                        break;
                }
            }
            catch
            {
                Y_num = 0;
                M_num = 0;
                D_num = 0;
                H_num = 0;
            }
        }
        /// <summary>
        /// 返回汉字年龄格式，如：2岁3月20天
        /// </summary>
        /// <returns></returns>
        public string ReturnAgeStr_CH()
        {
            return Y_num.ToString().PadLeft(3, '0') + "岁" + M_num.ToString().PadLeft(2, '0') + "月" + D_num.ToString().PadLeft(2, '0') + "天" + H_num.ToString().PadLeft(2, '0') + "时";
        }
        /// <summary>
        /// 返回英文存储格式，如：Y2
        /// </summary>
        /// <returns></returns>
        public string ReturnAgeStr_EN()
        {
            if (Y_num > 0)
                return "Y" + Y_num;
            else if (M_num > 0)
                return "M" + M_num;
            else if (D_num > 0)
                return "D" + D_num;
            else if (H_num > 0)
                return "H" + H_num;
            else
                return "D1";
        }
    }

   
}
