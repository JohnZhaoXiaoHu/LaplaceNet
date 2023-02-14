using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La.Common
{
    public class ToPivotHelper
    {
        public static DataTable RevertRowToColumn(DataTable sourcedt)
        {
            DataTable dt = new DataTable();
            //转换后的第一列名，以后此列每行存放sourcedt对应对应的每列列名
            dt.Columns.Add("COLUMN_NAME", typeof(string));

            //第二行及以后，转换后重命名的列名，列数等于sourcedt行数
            string[] aa = new string[sourcedt.Rows.Count];
            //string[] aa = { "VLAUE_1", "VLAUE_2", "VLAUE_3", "VLAUE_4", "VLAUE_5", "VLAUE_6", "VLAUE_7", "VLAUE_8", "VLAUE_9", "VLAUE_10" };
            for (int i = 0; i < sourcedt.Rows.Count; i++)
            {
                aa[i] = "VLAUE_" + (i + 1);
            }

            //dt添加Columns
            for (int i = 0; i < aa.Length; i++)
            {
                dt.Columns.Add(aa[i].ToString(), typeof(string));//统一按照string类型进行存放
            }

            //对sourcedt进行转换
            for (int j = 0; j < sourcedt.Columns.Count; j++)
            {
                DataRow dr = dt.NewRow();
                string column_name = sourcedt.Columns[j].ColumnName;
                dr["COLUMN_NAME"] = column_name;//把source的列名赋值给转换成行的第一列值
                for (int i = 0; i < sourcedt.Rows.Count; i++)
                {
                    string cell_value = sourcedt.Rows[i][column_name].ToString();
                    dr[i + 1] = cell_value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        /// <summary>
        /// 将DataTable的第二列的值转化为列
        //（即将原来的行表，转化成交叉表，没有对应值则默认"0"）
        /// </summary>
        /// <param name="dt">必须三列，第三列为值</param>
        /// <returns></returns>
        public static DataTable GetCrossTable(DataTable dt)
        {
            if (dt == null || dt.Columns.Count != 3 || dt.Rows.Count == 0)
            {
                return dt;
            }
            else
            {
                DataTable result = new DataTable();
                result.Columns.Add(dt.Columns[0].ColumnName);
                DataTable dtColumns = dt.DefaultView.ToTable("dtColumns", true, dt.Columns[1].ColumnName);
                for (int i = 0; i < dtColumns.Rows.Count; i++)
                {
                    string colName;
                    if (dtColumns.Rows[1][0] is DateTime)
                    {
                        colName = Convert.ToDateTime(dtColumns.Rows[i][0]).ToString();
                    }
                    else
                    {
                        colName = dtColumns.Rows[i][0].ToString();
                    }
                    result.Columns.Add(colName);
                    result.Columns[i + 1].DefaultValue = "0";
                }
                DataRow drNew = result.NewRow();
                drNew[0] = dt.Rows[0][0];
                string rowName = drNew[0].ToString();
                foreach (DataRow dr in dt.Rows)
                {
                    string colName = dr[1].ToString();
                    double dValue = Convert.ToDouble(dr[2]);
                    if (dr[0].ToString().Equals(rowName, StringComparison.CurrentCultureIgnoreCase))
                    {
                        drNew[colName] = dValue.ToString();
                    }
                    else
                    {
                        result.Rows.Add(drNew);
                        drNew = result.NewRow();
                        drNew[0] = dr[0];
                        rowName = drNew[0].ToString();
                        drNew[colName] = dValue.ToString();
                    }
                }
                result.Rows.Add(drNew);
                return result;
            }
        }
    }
}
