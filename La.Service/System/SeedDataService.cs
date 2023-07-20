﻿using La.Infra.Extensions;
using MiniExcelLibs;
using SqlSugar.IOC;
using System.Collections.Generic;
using System.Linq;
using La.Common;
using La.Model.System;

namespace La.Service.System
{
    /// <summary>
    /// 种子数据处理
    /// </summary>
    public class SeedDataService
    {
        /// <summary>
        /// 初始化用户数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (string, object, object) InitUserData(List<SysUser> data)
        {
            data.ForEach(x =>
            {
                x.Password = "E10ADC3949BA59ABBE56E057F20F883E";
            });
            var db = DbScoped.SugarScope;
            db.Ado.BeginTran();
            //db.Ado.ExecuteCommand("SET IDENTITY_INSERT sys_user ON");
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .SplitError(x => x.Item.UserName.IsEmpty(), "用户名不能为空")
                .SplitError(x => !Tools.CheckUserName(x.Item.UserName), "用户名不符合规范")
                .WhereColumns(it => it.UserId)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.OffIdentity().ExecuteCommand();//插入可插入部分;
            //db.Ado.ExecuteCommand("SET IDENTITY_INSERT sys_user OFF");
            db.Ado.CommitTran();

            string msg = $"[用户数据] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 菜单数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (string, object, object) InitMenuData(List<SysMenu> data)
        {
            var db = DbScoped.SugarScope;
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .WhereColumns(it => it.MenuId)//如果不是主键可以这样实现（多字段it=>new{it.x1,it.x2}）
                .ToStorage();
            var result = x.AsInsertable.OffIdentity().ExecuteCommand();//插入可插入部分;
            
            string msg = $"[菜单数据] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }
        /// <summary>
        /// 角色菜单数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (string, object, object) InitRoleMenuData(List<SysRoleMenu> data)
        {
            var db = DbScoped.SugarScope;
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .WhereColumns(it => new { it.Menu_id, it.Role_id })
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();//插入可插入部分;

            string msg = $"[角色菜单] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }
        /// <summary>
        /// 初始化部门数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (string, object, object) InitDeptData(List<SysDept> data)
        {
            var db = DbScoped.SugarScope;
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .WhereColumns(it => it.DeptId)
                .ToStorage();
            var result = x.AsInsertable.OffIdentity().ExecuteCommand();

            string msg = $"[部门数据] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }

        public (string, object, object) InitPostData(List<SysPost> data)
        {
            var db = DbScoped.SugarScope;
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .WhereColumns(it => it.PostCode)
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();

            string msg = $"[岗位数据] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }

        public (string, object, object) InitRoleData(List<SysRole> data)
        {
            var db = DbScoped.SugarScope;
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .WhereColumns(it => it.RoleKey)
                .ToStorage();
            var result = x.AsInsertable.OffIdentity().ExecuteCommand();

            string msg = $"[角色数据] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }

        public (string, object, object) InitUserRoleData(List<SysUserRole> data)
        {
            var db = DbScoped.SugarScope;
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .WhereColumns(it => new { it.RoleId, it.UserId })
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();

            string msg = $"[用户角色] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 系统配置
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (string, object, object) InitConfigData(List<SysConfig> data)
        {
            var db = DbScoped.SugarScope;
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .WhereColumns(it => it.ConfigKey)
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();

            string msg = $"[系统配置] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 字典
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (string, object, object) InitDictType(List<SysDictType> data)
        {
            var db = DbScoped.SugarScope;
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .WhereColumns(it => it.DictType)
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();

            string msg = $"[字典管理] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 字典数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (string, object, object) InitDictData(List<SysDictData> data)
        {
            var db = DbScoped.SugarScope;
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .WhereColumns(it => new { it.DictType, it.DictValue })
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();

            string msg = $"[字典数据] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 文章目录
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (string, object, object) InitArticleCategoryData(List<ArticleCategory> data)
        {
            var db = DbScoped.SugarScope;
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .WhereColumns(it => it.Name)
                .ToStorage();
            var result = x.AsInsertable.OffIdentity().ExecuteCommand();

            string msg = $"[字典数据] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 任务
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public (string, object, object) InitTaskData(List<SysTasks> data)
        {
            var db = DbScoped.SugarScope;
            var x = db.Storageable(data)
                .SplitInsert(it => it.NotAny())
                .WhereColumns(it => it.Name)
                .ToStorage();
            var result = x.AsInsertable.ExecuteCommand();

            string msg = $"[任务数据] 插入{x.InsertList.Count} 错误数据{x.ErrorList.Count} 总共{x.TotalList.Count}";
            return (msg, x.ErrorList, x.IgnoreList);
        }

        /// <summary>
        /// 初始化种子数据
        /// </summary>
        /// <param name="path"></param>
        /// <param name="clean"></param>
        /// <returns></returns>
        public List<string> InitSeedData(string path, bool clean)
        {
            List<string> result = new();

            var db = DbScoped.SugarScope;
            if (clean)
            {
                db.DbMaintenance.TruncateTable<SysRoleDept>();
                db.DbMaintenance.TruncateTable<SysRoleMenu>();
                db.DbMaintenance.TruncateTable<SysMenu>();
                db.DbMaintenance.TruncateTable<SysRole>();
                db.DbMaintenance.TruncateTable<SysUser>();
                db.DbMaintenance.TruncateTable<SysDept>();
                db.DbMaintenance.TruncateTable<SysPost>();
            }

            var sysUser = MiniExcel.Query<SysUser>(path, sheetName: "user").ToList();
            var result1 = InitUserData(sysUser);
            result.Add(result1.Item1);

            var sysPost = MiniExcel.Query<SysPost>(path, sheetName: "post").ToList();
            var result2 = InitPostData(sysPost);
            result.Add(result2.Item1);

            var sysRole = MiniExcel.Query<SysRole>(path, sheetName: "role").ToList();
            var result3 = InitRoleData(sysRole);
            result.Add(result3.Item1);

            var sysUserRole = MiniExcel.Query<SysUserRole>(path, sheetName: "user_role").ToList();
            var result4 = InitUserRoleData(sysUserRole);
            result.Add(result4.Item1);

            var sysMenu = MiniExcel.Query<SysMenu>(path, sheetName: "menu").ToList();
            var result5 = InitMenuData(sysMenu);
            result.Add(result5.Item1);

            var sysConfig = MiniExcel.Query<SysConfig>(path, sheetName: "config").ToList();
            var result6 = InitConfigData(sysConfig);
            result.Add(result6.Item1);

            var sysRoleMenu = MiniExcel.Query<SysRoleMenu>(path, sheetName: "role_menu").ToList();
            var result7 = InitRoleMenuData(sysRoleMenu);
            result.Add(result7.Item1);

            var sysDict = MiniExcel.Query<SysDictType>(path, sheetName: "dict_type").ToList();
            var result8 = InitDictType(sysDict);
            result.Add(result8.Item1);

            var sysDictData = MiniExcel.Query<SysDictData>(path, sheetName: "dict_data").ToList();
            var result9 = InitDictData(sysDictData);
            result.Add(result9.Item1);

            var sysDept = MiniExcel.Query<SysDept>(path, sheetName: "dept").ToList();
            var result10 = InitDeptData(sysDept);
            result.Add(result10.Item1);

            var sysArticleCategory = MiniExcel.Query<ArticleCategory>(path, sheetName: "article_category").ToList();
            var result11 = InitArticleCategoryData(sysArticleCategory);
            result.Add(result11.Item1);

            return result;
        }
    }
}
