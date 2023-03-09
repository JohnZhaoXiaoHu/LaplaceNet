﻿using System;
using System.ComponentModel.DataAnnotations;

namespace La.Model.System.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuDto
    {
        /// <summary>
        /// 菜单id
        /// </summary>
        //{"parentId":0,"menuName":"aaa","icon":"documentation","menuType":"M","orderNum":999,"visible":0,"status":0,"path":"aaa"}
        [Required(ErrorMessage = "菜单id不能为空")]
        public int MenuId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 父菜单ID
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 路由地址
        /// </summary>
        public string Path { get; set; } = "#";

        /// <summary>
        /// 组件路径
        /// </summary>
        public string Component { get; set; }

        /// <summary>
        /// 是否缓存（1缓存 0不缓存）
        /// </summary>
        [Required(ErrorMessage = "是否缓存不能为空")]
        public string IsCache { get; set; }
        /// <summary>
        /// 是否外链 1、是 0、否
        /// </summary>
        public string IsFrame { get; set; }

        /// <summary>
        /// 类型（M目录 C菜单 F按钮 L链接）
        /// </summary>
        [Required(ErrorMessage = "菜单类型不能为空")]
        public string MenuType { get; set; }

        /// <summary>
        /// 显示状态（0显示 1隐藏）
        /// </summary>
        [Required(ErrorMessage = "显示状态不能为空")]
        public string Visible { get; set; }

        /// <summary>
        /// 菜单状态（0正常 1停用）
        /// </summary>
        [Required(ErrorMessage = "菜单状态不能为空")]
        public string Status { get; set; }

        /// <summary>
        /// 权限字符串
        /// </summary>
        public string Perms { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; } = string.Empty;
        /// <summary>
        /// 翻译key
        /// </summary>
        public string MenuNameKey { get; set; }
    }
    /// <summary>
    /// 查询
    /// </summary>
    public class MenuQueryDto
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 显示
        /// </summary>
        public string Visible { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string MenuTypeIds { get; set; } = string.Empty;
        /// <summary>
        /// 父ID
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// 类型组
        /// </summary>
        public string[] MenuTypeIdArr
        {
            get
            {
                return MenuTypeIds.Split(',', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
