﻿using Newtonsoft.Json;
using SqlSugar;
using System;

namespace La.Model.System
{
    /// <summary>
    /// 文件
    /// </summary>
    [Tenant("0")]
    [SugarTable("sys_file")]
    public class SysFile
    {
        /// <summary>
        /// 描述 : 自增id
        /// 空值 : false  
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true)]
        public long Id { get; set; }
        /// <summary>
        /// 文件原名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 描述 : 存储文件名
        /// 空值 : true  
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 描述 : 文件存储地址 eg：/uploads/20220202
        /// 空值 : true  
        /// </summary>
        public string FileUrl { get; set; }
        /// <summary>
        /// 描述 : 仓库位置 eg：/uploads
        /// 空值 : true  
        /// </summary>
        public string StorePath { get; set; }
        /// <summary>
        /// 描述 : 文件大小
        /// 空值 : true  
        /// </summary>
        public string FileSize { get; set; }
        /// <summary>
        /// 描述 : 文件扩展名
        /// 空值 : true  
        /// </summary>
        public string FileExt { get; set; }
        /// <summary>
        /// 描述 : 创建人
        /// 空值 : true  
        /// </summary>
        public string create_by { get; set; }
        /// <summary>
        /// 描述 : 上传时间
        /// 空值 : true  
        /// </summary>
        public DateTime? create_time { get; set; }
        /// <summary>
        /// 描述 : 存储类型
        /// 空值 : true  
        /// </summary>
        public int? StoreType { get; set; }
        /// <summary>
        /// 描述 : 访问路径
        /// 空值 : true  
        /// </summary>
        public string AccessUrl { get; set; }
        /// <summary>
        /// 文件
        /// </summary>
        public SysFile() { }
        /// <summary>
        /// 文件
        /// </summary>
        /// <param name="originFileName"></param>
        /// <param name="fileName"></param>
        /// <param name="ext"></param>
        /// <param name="fileSize"></param>
        /// <param name="storePath"></param>
        /// <param name="create_by"></param>
        public SysFile(string originFileName, string fileName, string ext, string fileSize, string storePath, string create_by)
        {
            StorePath = storePath;
            RealName = originFileName;
            FileName = fileName;
            FileExt = ext;
            FileSize = fileSize;
            create_by = create_by;
            create_time = DateTime.Now;
        }
    }
}