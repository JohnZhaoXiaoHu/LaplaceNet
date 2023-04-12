﻿using La.Infra.Attribute;
using La.Infra.Extensions;
using SqlSugar;
using System.Collections.Generic;
using La.Model;
using La.Model.System;
using La.Model.System.Dto;
using La.Repository;
using La.Service.System.IService;

namespace La.Service.System
{
    /// <summary>
    /// 用户角色
    /// </summary>
    [AppService(ServiceType = typeof(ISysUserRoleService), ServiceLifetime = LifeTime.Transient)]
    public class SysUserRoleService : BaseService<SysUserRole>, ISysUserRoleService
    {
        //public SysUserRoleRepository SysUserRoleRepository;

        //public SysUserRoleService(SysUserRoleRepository sysUserRoleRepository)
        //{
        //    SysUserRoleRepository = sysUserRoleRepository;
        //}

        /// <summary>
        /// 通过角色ID查询角色使用数量
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int CountUserRoleByRoleId(long roleId)
        {
            return Count(it => it.RoleId == roleId);
        }

        /// <summary>
        /// 删除用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteUserRoleByUserId(int userId)
        {
            return Delete(it => it.UserId == userId) ? 1 : 0;
        }

        /// <summary>
        /// 批量删除角色对应用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public int DeleteRoleUserByUserIds(long roleId, List<long> userIds)
        {
            return Delete(it => it.RoleId == roleId && userIds.Contains(it.UserId)) ? 1 : 0;
        }

        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="sysUserRoles"></param>
        /// <returns></returns>
        public int AddUserRole(List<SysUserRole> sysUserRoles)
        {
            return Insert(sysUserRoles);
        }

        /// <summary>
        /// 获取用户数据根据角色id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<SysUser> GetSysUsersByRoleId(long roleId)
        {
            return Context.Queryable<SysUserRole, SysUser > ((t1, u) => new JoinQueryInfos(
                   JoinType.Left, t1.UserId == u.UserId))
                 .Where((t1, u) => t1.RoleId == roleId && u.IsDeleted == "0")
                 .Select((t1, u) => u)
                 .ToList();
        }

        /// <summary>
        /// 获取用户数据根据角色id
        /// </summary>
        /// <param name="roleUserQueryDto"></param>
        /// <returns></returns>
        public PagedInfo<SysUser> GetSysUsersByRoleId(RoleUserQueryDto roleUserQueryDto)
        {
            //return SysUserRoleRepository.GetSysUsersByRoleId(roleUserQueryDto);
            var query = Context.Queryable<SysUserRole, SysUser>((t1, u) => new JoinQueryInfos(
                JoinType.Left, t1.UserId == u.UserId))
                .Where((t1, u) => t1.RoleId == roleUserQueryDto.RoleId && u.IsDeleted == "0");
            if (!string.IsNullOrEmpty(roleUserQueryDto.UserName))
            {
                query = query.Where((t1, u) => u.UserName.Contains(roleUserQueryDto.UserName));
            }
            return query.Select((t1, u) => u).ToPage(roleUserQueryDto);
        }

        /// <summary>
        /// 获取尚未指派的用户数据根据角色id
        /// </summary>
        /// <param name="roleUserQueryDto"></param>
        /// <returns></returns>
        public PagedInfo<SysUser> GetExcludedSysUsersByRoleId(RoleUserQueryDto roleUserQueryDto)
        {
            var query = Context.Queryable<SysUser>()
                .Where(it => it.IsDeleted == "0")
                .Where(it => SqlFunc.Subqueryable<SysUserRole>().Where(s => s.UserId == it.UserId && s.RoleId == roleUserQueryDto.RoleId).NotAny())
                .WhereIF(roleUserQueryDto.UserName.IsNotEmpty(), it => it.UserName.Contains(roleUserQueryDto.UserName));

            return query.ToPage(roleUserQueryDto);
        }

        /// <summary>
        /// 新增用户角色信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int InsertUserRole(SysUser user)
        {
            List<SysUserRole> userRoles = new();
            foreach (var item in user.RoleIds)
            {
                userRoles.Add(new SysUserRole() { RoleId = item, UserId = user.UserId });
            }

            return userRoles.Count > 0 ? AddUserRole(userRoles) : 0;
        }

        /// <summary>
        /// 新增加角色用户
        /// </summary>
        /// <param name="roleUsersCreateDto"></param>
        /// <returns></returns>
        public int InsertRoleUser(RoleUsersCreateDto roleUsersCreateDto)
        {
            List<SysUserRole> userRoles = new();
            foreach (var item in roleUsersCreateDto.UserIds)
            {
                userRoles.Add(new SysUserRole() { RoleId = roleUsersCreateDto.RoleId, UserId = item });
            }

            return userRoles.Count > 0 ? AddUserRole(userRoles) : 0;
        }
    }
}
