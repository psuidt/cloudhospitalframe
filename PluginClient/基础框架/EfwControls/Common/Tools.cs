using Microsoft.Win32;
using System;
using System.Windows.Forms;
using System.Collections.Specialized;

using System.Data;
using System.Management;
using System.Runtime.InteropServices;
using System.Net;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace EfwControls.Common
{
    public class Tools
    {
        public static byte[] StringToBytes(string str)
        {
            byte[] bytes = new byte[(int)(str.Length / 3)];
            for (int i = 0; i < str.Length; i++)
            {
                bytes[i] = (byte)Int32.Parse(str.Substring(i * 3, 3));// (byte)str[i];//(byte)(char)((int)str[i]-48);
            }
            return bytes;
        }

        public static string BytesToString(byte[] bytes)
        {
            string buff = string.Empty;

            for (int i = 0; i < bytes.Length; i++)
            {
                buff = buff + bytes[i].ToString("d3");
            }
            return buff;

        }

        public static bool IsNumberic(object sText)
        {
            try
            {
                decimal var1 = Convert.ToDecimal(sText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDateTime(object sText)
        {
            try
            {
                DateTime Nd = Convert.ToDateTime(sText);
                return true;
            }
            catch
            {
                return false;
            }

        }
        #region 对象值转换函数
        public static String ToString(Object Value)
        {
            if (Value == null)
                return "";
            else
                return Convert.ToString(Value);
        }
        public static int ToInt32(Object Value)
        {
            if (Value == null) return 0;
            String S = Value.ToString();
            int i = 0;
            if (Int32.TryParse(S, out i))
                return i;
            else
                return 0;
        }
        public static decimal ToDecimal(Object Value)
        {
            if (Value == null) return 0;
            String S = Value.ToString();
            Decimal i = 0;
            if (Decimal.TryParse(S, out i))
                return i;
            else
                return 0;
        }
        //自定义转换失败后的默认值,Rao
        public static int ToInt32(Object Value, int DefaultValue)
        {
            string sTemp = Convert.ToString(Value);
            int iResult = 0;
            if (int.TryParse(sTemp, out iResult))
            {
                return iResult;
            }
            else
            {
                if (DefaultValue != 0)
                {
                    return DefaultValue;
                }
                else
                {
                    return iResult;
                }
            }
        }
        //转换后字符串为“”,是否自定义默认值
        public static string ToString(Object Value, bool Translation, string DefaultValue)
        {
            string sResult = "";
            sResult = Convert.ToString(Value);
            if (Translation && sResult == "")
            {
                return DefaultValue;
            }
            else
            {
                return sResult;
            }
        }
        public static int ToInt32(String Value)
        {
            if (Value == null || Value == "")
                return 0;
            else
            {
                int iResult = 0;
                if (int.TryParse(Value, out iResult))
                    return iResult;
                else
                    return 0;
            }
        }
        public static char ToChar(Object Value)
        {
            if (Value == null)
                return '\0';
            else
            {
                String sValue = Convert.ToString(Value);
                if (sValue.Length > 0)
                    return Convert.ToString(Value)[0];
                else
                    return '\0';
            }
        }
        #endregion

        /// <summary>
        /// 将DataTable里面时间类型列的初始化值改为NULL
        /// </summary>
        /// <param name="dtSource">需要改的DataTable</param>
        /// <param name="colNames">时间类型列集合</param>
        public static void ChangeDateTimeNullValue(ref DataTable dtSource, List<string> colNames)
        {
            foreach (DataRow dr in dtSource.Rows)
            {
                foreach (string colName in colNames)
                {
                    dr[colName] = (dr[colName].ToString().Trim().Contains("0001") || dr[colName].ToString().Trim().Contains("1900")) ? DBNull.Value : dr[colName];
                }
            }
        }
    }
}
