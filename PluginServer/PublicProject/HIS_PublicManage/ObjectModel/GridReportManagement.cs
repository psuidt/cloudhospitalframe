using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS_PublicManage.ObjectModel
{
    /*
    /// <summary>
    /// 报表处理
    /// </summary>
    public class GridReportManagement
    {

        private struct MatchFieldPairType
        {
            public IGRField grField;
            public int MatchColumnIndex;
        }
        /// <summary>
        /// 将 DataReader 的数据转储到 Grid++Report 的数据集中
        /// </summary>
        /// <param name="Report"></param>
        /// <param name="dr"></param>
        public static void FillRecordToReport(IGridppReport Report, IDataReader dr)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dr.FieldCount)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dr.FieldCount; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.RunningDBField, dr.GetName(i), true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }


            // Loop through the contents of the OleDbDataReader object.
            // 将 DataReader 中的每一条记录转储到Grid++Report 的数据集中去
            while (dr.Read())
            {
                Report.DetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsDBNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr.GetValue(MatchFieldPairs[i].MatchColumnIndex);
                }

                Report.DetailGrid.Recordset.Post();
            }
        }

        /// <summary>
        /// 将 DataTable 的数据转储到 Grid++Report 的数据集中
        /// </summary>
        /// <param name="Report"></param>
        /// <param name="dt"></param>
        public static void FillRecordToReport(IGridppReport Report, DataTable dt)
        {
            MatchFieldPairType[] MatchFieldPairs = new MatchFieldPairType[Math.Min(Report.DetailGrid.Recordset.Fields.Count, dt.Columns.Count)];

            //根据字段名称与列名称进行匹配，建立DataReader字段与Grid++Report记录集的字段之间的对应关系
            int MatchFieldCount = 0;
            for (int i = 0; i < dt.Columns.Count; ++i)
            {
                foreach (IGRField fld in Report.DetailGrid.Recordset.Fields)
                {
                    if (String.Compare(fld.Name, dt.Columns[i].ColumnName, true) == 0)
                    {
                        MatchFieldPairs[MatchFieldCount].grField = fld;
                        MatchFieldPairs[MatchFieldCount].MatchColumnIndex = i;
                        ++MatchFieldCount;
                        break;
                    }
                }
            }


            // 将 DataTable 中的每一条记录转储到 Grid++Report 的数据集中去
            foreach (DataRow dr in dt.Rows)
            {
                Report.DetailGrid.Recordset.Append();

                for (int i = 0; i < MatchFieldCount; ++i)
                {
                    if (!dr.IsNull(MatchFieldPairs[i].MatchColumnIndex))
                        MatchFieldPairs[i].grField.Value = dr[MatchFieldPairs[i].MatchColumnIndex];
                }

                Report.DetailGrid.Recordset.Post();
            }
        }

        /// <summary>
        /// 将 对象 的属性数据转储到 Grid++Report 的数据集中
        /// </summary>
        /// <param name="Report"></param>
        /// <param name="obj"></param>
        public static void FillRecordToReport(IGridppReport Report, Object obj)
        {
            int obj_propertyNum = obj.GetType().GetProperties().Length;
            int rpt_parmNum = Report.Parameters.Count;
            string propertyName, parmName;
            for (int i = 0; i < obj_propertyNum; i++)
            {
                for (int j = 1; j <= rpt_parmNum; j++)
                {
                    propertyName = obj.GetType().GetProperties()[i].Name;
                    parmName = Report.Parameters[j].Name;

                    if (propertyName == parmName)
                    {
                        object obj1 = obj.GetType().GetProperties()[i].GetValue(obj, null);
                        Report.Parameters[j].Value = obj1;
                    }
                }
            }
        }

        public static uint RGBToOleColor(byte r, byte g, byte b)
        {
            return ((uint)b) * 256 * 256 + ((uint)g) * 256 + r;
        }

        public static uint ColorToOleColor(System.Drawing.Color val)
        {
            return RGBToOleColor(val.R, val.G, val.B);
        }
    }

    */
}
