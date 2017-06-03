using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Reflection;

namespace EfwControls.Common
{
    //数据转换
    public class ConvertDataExtend
    {
        /// <summary>
        /// 将Null值转换为指定值
        /// </summary>
        /// <param name="obj">待判断的值</param>
        /// <param name="nValue">指定值</param>
        /// <returns></returns>
        public static string IsNull(object obj, string nValue)
        {
            try
            {
                return Convert.ToString(obj).Trim() == "" ? nValue : obj.ToString().Trim();
            }
            catch (System.InvalidCastException err)
            {
                err.ToString();
                return "";
            }
            catch (System.Exception err)
            {
                err.ToString();
                return "";
            }
        }

        /// <summary>
        ///判断输入字符串是否为数字
        /// </summary>
        /// <param name="nValue">字符串</param>
        /// <returns></returns>
        public static bool IsNumeric(string nValue)
        {
            int i, iAsc, idecimal = 0;
            if (nValue.Trim() == "") return false;
            for (i = 0; i <= nValue.Length - 1; i++)
            {
                iAsc = (int)Convert.ToChar(nValue.Substring(i, 1));
                //'-'45 '.'46 '''0-9' 48-57
                if (iAsc == 45)
                {
                    if (nValue.Length == 1)//不能只有一个负号
                    {
                        return false;
                    }
                    if (i != 0)			//'-'不能在字符串中间
                    {
                        return false;
                    }
                }
                else if (iAsc == 46)
                {
                    idecimal++;
                    if (idecimal > 1)		//如果有两个以上的小数点
                        return false;
                }
                else if (iAsc < 48 || iAsc > 57)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///判断输入字符串是否为整数
        /// </summary>
        /// <param name="nValue">字符串</param>
        /// <returns></returns>
        public static bool IsInteger(string nValue)
        {
            int i, iAsc;
            if (nValue.Trim() == "") return false;
            for (i = 0; i <= nValue.Length - 1; i++)
            {
                iAsc = (int)Convert.ToChar(nValue.Substring(i, 1));
                //'-' 45 '0-9' 48-57
                if (iAsc == 45)
                {
                    if (nValue.Length == 1)//不能只有一个负号
                    {
                        return false;
                    }
                    if (i != 0)			//'-'不能在字符串中间
                    {
                        return false;
                    }
                }
                else if (iAsc < 48 || iAsc > 57)
                {
                    return false;
                }
            }
            return true;
        }

        public static string ToString(object val, string defaultVal)
        {
            if (val == null || val.Equals(DBNull.Value))
                return defaultVal;

            if (val.ToString() == "")
                return defaultVal;

            return val.ToString();
        }

        public static int ToInt32(object val, int defaultVal)
        {
            if (val == null || val.Equals(DBNull.Value))
                return defaultVal;

            if (val.ToString() == "")
                return defaultVal;

            return Convert.ToInt32(Convert.ToDecimal(val));
        }

        public static decimal ToDecimal(object val, decimal defaultVal)
        {
            if (val.Equals(DBNull.Value) || val == null)
                return defaultVal;

            if (val.ToString() == "")
                return defaultVal;

            return Convert.ToDecimal(val);
        }

        public static decimal ToDecimal(object val, decimal replace, decimal result)
        {
            if (val == null)
                val = "";
            if (decimal.TryParse(val.ToString(), out result))
                return result;
            else
                return replace;
        }


        protected static object ConvertValue(string PropertyType, object value)
        {
            if (value.GetType().FullName == "System.Guid")
            {
                return value.ToString();
            }

            switch (PropertyType)
            {
                case "System.DBNull":
                    return null;
                case "System.Int32":
                    value = value == DBNull.Value ? 0 : value;
                    value = value == null ? 0 : value;
                    value = value.ToString().Trim() == "" ? 0 : value;
                    return Convert.ToInt32(value);
                case "System.Int64":
                    value = value == DBNull.Value ? 0 : value;
                    value = value == null ? 0 : value;
                    value = value.ToString().Trim() == "" ? 0 : value;
                    return Convert.ToInt64(value);
                case "System.Decimal":
                    value = value == DBNull.Value ? 0 : value;
                    value = value == null ? 0 : value;
                    value = value.ToString().Trim() == "" ? 0 : value;
                    return Convert.ToDecimal(value);
                case "System.DateTime":
                    value = value == DBNull.Value ? new DateTime() : value;
                    value = value == null ? new DateTime() : value;
                    value = value.ToString().Trim() == "" ? new DateTime() : value;
                    return Convert.ToDateTime(value);
            }


            value = value == DBNull.Value ? null : value;
            return value;
        }
        public static List<T> ToList<T>(DataTable table)
        {
            List<T> list = new List<T>();
            //T obj = (T)System.Activator.CreateInstance(typeof(T));

            //列名
            string columnName;
            //属性名
            //string propertyName;
            //列数量
            int column = table.Columns.Count;
            //属性数量
            //int propertyNum = obj.GetType().GetProperties().Length;

            for (int m = 0; m < table.Rows.Count; m++)
            {
                T newobj = (T)System.Activator.CreateInstance(typeof(T));

                //遍历所有列
                for (int i = 0; i < column; i++)
                {
                    columnName = table.Columns[i].ColumnName;
                    object objectValue = table.Rows[m][i];
                    objectValue = objectValue == DBNull.Value ? null : objectValue;
                    newobj.GetType().GetProperty(columnName).SetValue(newobj, objectValue, null);
                }

                list.Add(newobj);

            }

            return list;
        }


        public static DataTable ToDataTable(IList list)
        {
            DataTable result = new DataTable();

            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        public static DataTable ToDataTableS<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                T obj = (T)System.Activator.CreateInstance(typeof(T));
                list.Add(obj);
                DataTable dt = ToDataTable(list);
                dt.Clear();
                return dt;
            }
            else
                return ToDataTable(list);
        }

        public static DataRow ToDataRow(Object in_obj)
        {
            DataTable result = new DataTable();
            PropertyInfo[] propertys = in_obj.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                result.Columns.Add(pi.Name, pi.PropertyType);
            }

            ArrayList tempList = new ArrayList();
            foreach (PropertyInfo pi in propertys)
            {
                object obj = pi.GetValue(in_obj, null);
                tempList.Add(obj);
            }
            object[] array = tempList.ToArray();
            result.LoadDataRow(array, true);

            return result.Rows[0];
        }

        public static T ToObject<T>(DataRow dr)
        {
            T obj = (T)System.Activator.CreateInstance(typeof(T));
            //列名
            string columnName;
            //列数量
            int column = dr.Table.Columns.Count;
            //遍历所有列
            for (int i = 0; i < column; i++)
            {
                columnName = dr.Table.Columns[i].ColumnName;
                object objectValue = dr[i];
                objectValue = objectValue == DBNull.Value ? null : objectValue;
                obj.GetType().GetProperty(columnName).SetValue(obj, objectValue, null);
            }

            return obj;
        }

        public static void ToObject(DataRow dr, object obj)
        {
            //列名
            string columnName;
            //列数量
            int column = dr.Table.Columns.Count;
            //遍历所有列
            for (int i = 0; i < column; i++)
            {
                columnName = dr.Table.Columns[i].ColumnName;
                object objectValue = dr[i];
                objectValue = objectValue == DBNull.Value ? null : objectValue;
                if (obj.GetType().GetProperty(columnName) != null)
                {
                    if (obj.GetType().GetProperty(columnName).PropertyType == typeof(Int32))
                        objectValue = ConvertDataExtend.ToInt32(objectValue,0);
                    if (obj.GetType().GetProperty(columnName).PropertyType == typeof(Decimal))
                        objectValue = ConvertDataExtend.ToDecimal(objectValue,0);
                    if (obj.GetType().GetProperty(columnName).PropertyType == typeof(DateTime))
                        objectValue = Convert.ToDateTime(objectValue);
                    obj.GetType().GetProperty(columnName).SetValue(obj, objectValue, null);
                }
            }
        }

        public static T ToObject<T>(DataTable dt, int Rowindex)
        {
            T obj = (T)System.Activator.CreateInstance(typeof(T));

            if (Rowindex >= dt.Rows.Count)
            {
                return obj;
            }
            //列名
            string columnName;
            //列数量
            int column = dt.Columns.Count;


            //遍历所有列
            for (int i = 0; i < column; i++)
            {
                columnName = dt.Columns[i].ColumnName;
                object objectValue = dt.Rows[Rowindex][i];
                objectValue = objectValue == DBNull.Value ? null : objectValue;
                obj.GetType().GetProperty(columnName).SetValue(obj, objectValue, null);
            }

            return obj;
        }

        public static T ToObject<T>(Object in_obj)
        {
            T out_obj = (T)System.Activator.CreateInstance(typeof(T));

            int in_propertyNum = in_obj.GetType().GetProperties().Length;
            int out_propertyNum = out_obj.GetType().GetProperties().Length;
            string in_propertyName, out_propertyName;
            for (int i = 0; i < in_propertyNum; i++)
            {
                for (int j = 0; j < out_propertyNum; j++)
                {
                    in_propertyName = in_obj.GetType().GetProperties()[i].Name;
                    out_propertyName = out_obj.GetType().GetProperties()[j].Name;

                    if (in_propertyName == out_propertyName)
                    {
                        object obj = in_obj.GetType().GetProperties()[i].GetValue(in_obj, null);
                        out_obj.GetType().GetProperties()[j].SetValue(out_obj, obj, null);
                    }
                }
            }

            return out_obj;
        }

        public static void UpdateDataTable(DataTable dt, int rowIndex, Object in_obj)
        {
            DataRow dr = dt.Rows[rowIndex];
            PropertyInfo[] propertys = in_obj.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                object obj = pi.GetValue(in_obj, null);
                dr[pi.Name] = obj;
            }
        }

        public static void UpdateDataTable(DataRow dr, Object in_obj)
        {
            PropertyInfo[] propertys = in_obj.GetType().GetProperties();
            foreach (PropertyInfo pi in propertys)
            {
                object obj = pi.GetValue(in_obj, null);
                dr[pi.Name] = obj;
            }
        }

        public static void UpdateDataTableForSort<T>(DataTable dt, List<T> list)
        {
            dt.Rows.Clear();
            int num = list.Count;
            for (int i = 0; i < num; i++)
            {
                T _obj = (T)System.Activator.CreateInstance(typeof(T));
                dt.Rows.Add(ConvertDataExtend.ToDataRow(_obj).ItemArray);
            }
            for (int i = 0; i < list.Count; i++)
            {
                UpdateDataTable(dt, i, list[i]);
            }
        }

        public static void UpdateDataTable<T>(DataTable dt, List<T> list)
        {
            if (list.Count == 0)
            {
                dt.Rows.Clear();
            }
            else if (dt.Rows.Count > list.Count)
            {
                int num = dt.Rows.Count - list.Count;
                for (int i = 0; i < num; i++)
                    dt.Rows.RemoveAt(list.Count - 1);
            }

            if (list.Count > dt.Rows.Count)
            {
                int num = list.Count - dt.Rows.Count;
                for (int i = 0; i < num; i++)
                {
                    T _obj = (T)System.Activator.CreateInstance(typeof(T));
                    dt.Rows.Add(ConvertDataExtend.ToDataRow(_obj).ItemArray);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                UpdateDataTable(dt, i, list[i]);
            }
        }
    }
}
