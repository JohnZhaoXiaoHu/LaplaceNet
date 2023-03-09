using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using La.Model.System;

namespace La.Model.System.Vo
{
    /// <summary>
    /// Treeselect树结构实体类
    /// </summary>
    public class TreeSelectVo
    {
        /// <summary>
        /// 节点Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Treeselect树结构
        /// </summary>
        public TreeSelectVo() { }
        /// <summary>
        /// Treeselect树结构
        /// </summary>
        /// <param name="menu"></param>
        public TreeSelectVo(SysMenu menu)
        {
            Id = menu.MenuId;
            Label = menu.MenuName;

            //menu.getChildren().stream().map(TreeSelect::new).collect(Collectors.toList()); java写法
            List<TreeSelectVo> child = new List<TreeSelectVo>();
            foreach (var item in menu.Children)
            {
                child.Add(new TreeSelectVo(item));
            }

            Children = child;
        }

        /// <summary>
        /// Treeselect树结构
        /// </summary>
        /// <param name="dept"></param>
        public TreeSelectVo(SysDept dept)
        {
            Id = dept.DeptId;
            Label = dept.DeptName;

            //menu.getChildren().stream().map(TreeSelect::new).collect(Collectors.toList()); java写法
            List<TreeSelectVo> child = new List<TreeSelectVo>();
            foreach (var item in dept.children)
            {
                child.Add(new TreeSelectVo(item));
            }

            Children = child;
        }
        /// <summary>
        /// 子项
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]

        public List<TreeSelectVo> Children { get; set; }
    }
}
