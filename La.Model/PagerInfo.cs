﻿using System;
using System.Collections.Generic;
using System.Text;

namespace La.Model
{
    /// <summary>
    /// 页面信息
    /// </summary>
    public class PagerInfo
    {
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageNum { get; set; }
        /// <summary>
        /// 每页显示多少条
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalNum { get; set; }
        /// <summary>
        /// 总页码
        /// </summary>
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage
        {
            get
            {
                return TotalNum > 0 ? TotalNum % PageSize == 0 ? TotalNum / PageSize : TotalNum / PageSize + 1 : 0;
            }
        }
        
        /// <summary>
        /// 排序字段
        /// </summary>
        public string Sort { get; set; } = string.Empty;
        /// <summary>
        /// 排序类型,前端传入的是"ascending"，"descending"
        /// </summary>
        public string SortType { get; set; } = string.Empty;
        /// <summary>
        /// 页面信息
        /// </summary>
        public PagerInfo()
        {
            PageNum = 1;
            PageSize = 20;
        }
        /// <summary>
        /// 页面信息
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        public PagerInfo(int page = 1, int pageSize = 20)
        {
            PageNum = page;
            PageSize = pageSize;
        }
    }
}
