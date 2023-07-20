﻿using SqlSugar.IOC;
using La.Model.Models;
using La.Model.System;
using La.Model.System.Generate;

namespace La.WebApi.Extensions
{
    /// <summary>
    /// 初始化表
    /// </summary>
    public class InitTable
    {
        /// <summary>
        /// 创建db、表
        /// </summary>
        public static void InitDb()
        {
            var db = DbScoped.SugarScope;
            //建库：如果不存在创建数据库存在不会重复创建 
            db.DbMaintenance.CreateDatabase();// 注意 ：Oracle和个别国产库需不支持该方法，需要手动建库 

            //var baseType = typeof(SysBase);
            //var entityes = AssemblyUtils.GetAllTypes().Where(p => !p.IsAbstract && p != baseType && p.GetCustomAttribute<SugarTable>() != null).ToArray();
            //db.CodeFirst.InitTables(entityes);

            //23个表,建议先使用下面方法初始化表，方便排查问题
            db.CodeFirst.InitTables(typeof(SysUser));
            db.CodeFirst.InitTables(typeof(SysRole));
            db.CodeFirst.InitTables(typeof(SysDept));
            db.CodeFirst.InitTables(typeof(SysPost));
            db.CodeFirst.InitTables(typeof(SysFile));
            db.CodeFirst.InitTables(typeof(SysConfig));
            db.CodeFirst.InitTables(typeof(SysNotice));
            db.CodeFirst.InitTables(typeof(SysLogininfor));
            db.CodeFirst.InitTables(typeof(SysOperLog));
            db.CodeFirst.InitTables(typeof(SysMenu));
            db.CodeFirst.InitTables(typeof(SysRoleMenu));
            db.CodeFirst.InitTables(typeof(SysRoleDept));
            db.CodeFirst.InitTables(typeof(SysUserRole));
            db.CodeFirst.InitTables(typeof(SysUserPost));
            db.CodeFirst.InitTables(typeof(SysTasks));
            db.CodeFirst.InitTables(typeof(SysTasksLog));
            db.CodeFirst.InitTables(typeof(CommonLang));
            db.CodeFirst.InitTables(typeof(GenTable));
            db.CodeFirst.InitTables(typeof(GenTableColumn));
            db.CodeFirst.InitTables(typeof(Article));
            db.CodeFirst.InitTables(typeof(ArticleCategory));
            db.CodeFirst.InitTables(typeof(SysDictData));
            db.CodeFirst.InitTables(typeof(SysDictType));
        }

    }
}
