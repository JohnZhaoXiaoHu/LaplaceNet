﻿using Newtonsoft.Json;
using SqlSugar;
using System;
using System.ComponentModel.DataAnnotations;

namespace La.Model.System
{
    ///<summary>
    ///计划任务
    ///</summary>
    [SugarTable("sys_tasks")]
    [Tenant("0")]
    public class SysTasks
    {
        public SysTasks()
        {
        }

        /// <summary>
        /// 任务id
        /// </summary>
        [Display(Name = "任务id")]
        //[JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true)]
        public string ID { get; set; }

        /// <summary>
        /// 任务名称 
        /// </summary>
        [Display(Name = "任务名称")]
        public string Name { get; set; }

        /// <summary>
        /// 任务分组 
        /// </summary>
        [Display(Name = "任务分组")]
        public string JobGroup { get; set; }

        /// <summary>
        /// 运行时间表达式 
        /// </summary>
        [Display(Name = "运行时间表达式")]
        public string Cron { get; set; }

        /// <summary>
        /// 程序集名称 
        /// </summary>
        [Display(Name = "程序集名称")]
        public string AssemblyName { get; set; }

        /// <summary>
        /// 任务所在类 
        /// </summary>
        [Display(Name = "任务所在类")]
        public string ClassName { get; set; }

        /// <summary>
        /// 任务描述 
        /// </summary>
        [Display(Name = "任务描述")]
        public string ReMark { get; set; }

        /// <summary>
        /// 执行次数 
        /// </summary>
        [Display(Name = "执行次数")]
        public int RunTimes { get; set; }

        /// <summary>
        /// 开始时间 
        /// </summary>
        [Display(Name = "开始时间")]
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 结束时间 
        /// </summary>
        [Display(Name = "结束时间")]
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 触发器类型（0、simple 1、cron） 
        /// 默认 : 1
        /// </summary>
        [Display(Name = "触发器类型（0、simple 1、cron）")]
        public int TriggerType { get; set; }

        /// <summary>
        /// 执行间隔时间(单位:秒) 
        /// 默认 : 0
        /// </summary>
        [Display(Name = "执行间隔时间(单位:秒)")]
        public int IntervalSecond { get; set; }

        /// <summary>
        /// 是否启动
        /// 默认 : 0
        /// </summary>
        [Display(Name = "是否启动")]
        public bool IsStart { get; set; }

        /// <summary>
        /// 传入参数
        /// 默认 : 
        /// </summary>
        [Display(Name = "传入参数")]
        public string JobParams { get; set; }

        [SugarColumn(IsOnlyIgnoreUpdate = true)]//设置后修改不会有此字段
        [JsonProperty(propertyName: "CreateBy")]
        public string Create_by { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        //[Display(Name = "创建时间")]
        [SugarColumn(IsOnlyIgnoreUpdate = true)]//设置后修改不会有此字段
        [JsonProperty(propertyName: "CreateTime")]
        public DateTime Create_time { get; set; } = DateTime.Now;

        [JsonIgnore]
        [JsonProperty(propertyName: "UpdateBy")]
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public string Update_by { get; set; }

        [SugarColumn(IsOnlyIgnoreInsert = true)]//设置后插入数据不会有此字段
        [JsonProperty(propertyName: "UpdateTime")]
        public DateTime Update_time { get; set; } = DateTime.Now;
        /// <summary>
        /// 最后运行时间
        /// </summary>
        public DateTime? LastRunTime { get; set; }
        /// <summary>
        /// api执行地址
        /// </summary>
        public string ApiUrl { get; set; }
        /// <summary>
        /// 任务类型 1、程序集 2、网络请求 3、SQL语句
        /// </summary>
        public int TaskType { get; set; }

        /// <summary>
        /// SQL语句
        /// </summary>
        public string SqlText { get; set; }
        /// <summary>
        /// 网络请求方式
        /// </summary>
        public string RequestMethod { get; set; }
    }
}
