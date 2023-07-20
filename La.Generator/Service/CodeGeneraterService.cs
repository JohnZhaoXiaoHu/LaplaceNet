﻿using La.Infra;
using SqlSugar;
using System.Collections.Generic;
using System.Linq;
using La.Generator.Model;
using La.Model;

namespace La.Generator.Service
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
            //string connStr = AppSettings.GetConfig(GenConstants.Gen_conn);
            //string[] AppSettoArrey = connStr.Split(';'); //字符串转数组
            //string AppSetName = AppSettoArrey[4];
            //int sindex = AppSettoArrey[4].IndexOf('=') + 1;
            //int eindex = AppSettoArrey[4].Length - AppSettoArrey[4].IndexOf('=') - 1;
            //var AppSetDataBase = AppSetName.Substring(sindex, eindex);
            //读取配置文件中数据库名称
            string connDbName = AppSettings.GetConfig(GenConstants.Gen_dbname); 

            var db = GetSugarDbContext();
            //Oracle库特殊处理
            DbConfigs configs = AppSettings.Get<DbConfigs>(nameof(GlobalConstant.CodeGenDbConfig));
            if (configs.DbType == 3)
            {
                return new List<string>() { configs?.DbName };
            }
            var templist = db.DbMaintenance.GetDataBaseList(db);

            //return templist.FindAll(f => !f.Contains("schema"));

            //只读取当前数据库
            var Currentdatabase = (from s in templist
                                   where s.Contains(connDbName)
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

        /// <summary>
        /// 获取Oracle所有序列
        /// </summary>
        /// <param name="dbName"></param>
        /// <returns></returns>
        public List<OracleSeq> GetAllOracleSeqs(string dbName)
        {
            string sql = "SELECT * FROM USER_SEQUENCES";
            var seqs = GetSugarDbContext(dbName).Ado.SqlQuery<OracleSeq>(sql);

            return seqs.ToList();
        }
    }
}
