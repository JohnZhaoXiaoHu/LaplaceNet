using SqlSugar;
using System.Collections.Generic;
using System.Linq;
using La.Model;
using JinianNet.JNTemplate;
using La.Infra;
using Org.BouncyCastle.Asn1.Pkcs;

namespace La.CodeGenerator.Service
{
    public class CodeGeneraterService : DbProvider
    {
        /// <summary>
        /// 获取所有数据库名
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllDataBases()
        {
            //读取配置文件中数据库名称(AppSettings.json)
            string connStr = AppSettings.GetConfig(GenConstants.Gen_conn); 
            string[] AppSettoArrey = connStr.Split(';'); //字符串转数组
            string AppSetName = AppSettoArrey[4];
            int sindex = AppSettoArrey[4].IndexOf('=') + 1;
            int eindex = AppSettoArrey[4].Length - AppSettoArrey[4].IndexOf('=') - 1;
            var AppSetDataBase = AppSetName.Substring(sindex, eindex);

            //读取数据库名称
            var db = GetSugarDbContext();
            var templist = db.DbMaintenance.GetDataBaseList(db);

            //只读取当前数据库
            var Currentdatabase = (from s in templist
                           where s.Contains(AppSetDataBase)
                           select s).ToList();

            return Currentdatabase;
        }

        /// <summary>
        /// 获取所有表
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public List<DbTableInfo> GetAllTables(string dbName, string tableName, PagerInfo pager)
        {
            var tableList = GetSugarDbContext(dbName).DbMaintenance.GetTableInfoList(true);
            if (!string.IsNullOrEmpty(tableName))
            {
                tableList = tableList.Where(f => f.Name.ToLower().Contains(tableName.ToLower())).ToList();
            }
            //tableList = tableList.Where(f => !new string[] { "gen", "sys_" }.Contains(f.Name)).ToList();
            pager.TotalNum = tableList.Count;
            return tableList.Skip(pager.PageSize * (pager.PageNum - 1)).Take(pager.PageSize).OrderBy(f => f.Name).ToList();
        }

        /// <summary>
        /// 获取单表数据
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DbTableInfo GetTableInfo(string dbName, string tableName)
        {
            var tableList = GetSugarDbContext(dbName).DbMaintenance.GetTableInfoList(true);
            if (!string.IsNullOrEmpty(tableName))
            {
                return tableList.Where(f => f.Name.Equals(tableName, System.StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }

            return null;
        }
        /// <summary>
        /// 获取列信息
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<DbColumnInfo> GetColumnInfo(string dbName, string tableName)
        {
            return GetSugarDbContext(dbName).DbMaintenance.GetColumnInfosByTableName(tableName, true);
        }
    }
}
