﻿using La.Infra;
using La.Infra.Extensions;
using JinianNet.JNTemplate;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using La.CodeGenerator.Model;
using La.Common;
using La.Model.System.Generate;

namespace La.CodeGenerator
{
    /// <summary>
    /// 代码生成器
    /// </remarks>
    /// </summary>
    public class CodeGeneratorTool
    {
        private static readonly string CodeTemplateDir = "CodeGenTemplate";

        /// <summary>
        /// 代码生成器入口方法
        /// </summary>
        /// <param name="dto"></param>
        public static void Generate(GenerateDto dto)
        {
            var vuePath = AppSettings.GetConfig("gen:vuePath");
            dto.VueParentPath = dto.VueVersion == 3 ? "La.vue" : "La.Vue";
            if (!vuePath.IsEmpty())
            {
                dto.VueParentPath = vuePath;
            }
            dto.GenOptions = GenerateOption(dto.GenTable);
            if (dto.GenTable.SubTable != null)
            {
                dto.SubTableOptions = GenerateOption(dto.GenTable.SubTable);
            }

            ReplaceDto replaceDto = new()
            {
                ModelTypeName = dto.GenTable.ClassName,//表名对应C# 实体类名
                PermissionPrefix = dto.GenTable?.Options?.PermissionPrefix,
                Author = dto.GenTable.FunctionAuthor,
                ShowBtnAdd = dto.GenTable.Options.CheckedBtn.Any(f => f == 1),
                ShowBtnEdit = dto.GenTable.Options.CheckedBtn.Any(f => f == 2),
                ShowBtnDelete = dto.GenTable.Options.CheckedBtn.Any(f => f == 3),
                ShowBtnExport = dto.GenTable.Options.CheckedBtn.Any(f => f == 4),
                ShowBtnView = dto.GenTable.Options.CheckedBtn.Any(f => f == 5),
                ShowBtnTruncate = dto.GenTable.Options.CheckedBtn.Any(f => f == 6),
                ShowBtnMultiDel = dto.GenTable.Options.CheckedBtn.Any(f => f == 7),
                ShowBtnImport = dto.GenTable.Options.CheckedBtn.Any(f => f == 8),
            };
            var columns = dto.GenTable.Columns;

            replaceDto.PKName = columns.Find(f => f.IsPk || f.IsIncrement)?.CsharpField ?? "Id";
            replaceDto.PKType = columns.Find(f => f.IsPk || f.IsIncrement)?.CsharpType ?? "int";

            replaceDto.UploadFile = columns.Any(f => f.HtmlType.Equals(GenConstants.HTML_IMAGE_UPLOAD) || f.HtmlType.Equals(GenConstants.HTML_FILE_UPLOAD)) ? 1 : 0;
            replaceDto.SelectMulti = columns.Any(f => f.HtmlType.Equals(GenConstants.HTML_SELECT_MULTI)) ? 1 : 0;
            replaceDto.ShowEditor = columns.Any(f => f.HtmlType.Equals(GenConstants.HTML_EDITOR)) ? 1 : 0;
            replaceDto.FistLowerPk = replaceDto.PKName.FirstLowerCase();
            InitJntTemplate(dto, replaceDto);

            GenerateModels(replaceDto, dto);
            GenerateService(replaceDto, dto);
            GenerateControllers(replaceDto, dto);
            if (dto.VueVersion == 3)
            {
                GenerateVue3Views(dto);
            }
            else
            {
                GenerateVueViews(replaceDto, dto);
            }
            if (dto.GenTable.Options.GenerateRepo == 1)
            {
                GenerateRepository(replaceDto, dto);
            }
            GenerateVueJs(dto);
            GenerateSql(dto);

            if (dto.IsPreview) return;

            foreach (var item in dto.GenCodes)
            {
                item.Path = Path.Combine(dto.GenCodePath, item.Path);
                FileUtil.WriteAndSave(item.Path, item.Content);
            }
        }

        private static CodeGenerateOption GenerateOption(GenTable genTable)
        {
            CodeGenerateOption _option = new()
            {
                BaseNamespace = genTable.BaseNameSpace,
                SubNamespace = genTable.ModuleName.FirstUpperCase()
            };
            _option.DtosNamespace = _option.BaseNamespace + "Model.Dto";
            _option.ModelsNamespace = _option.BaseNamespace + "Model";
            _option.RepositoriesNamespace = _option.BaseNamespace + "Repository";
            //_option.IRepositoriesNamespace = _option.BaseNamespace + "Repository";
            _option.IServicsNamespace = _option.BaseNamespace + "Service";
            _option.ServicesNamespace = _option.BaseNamespace + "Service";
            _option.ApiControllerNamespace = _option.BaseNamespace + "WebApi";
            return _option;
        }

        #region 读取模板

        /// <summary>
        /// 生成实体类Model
        /// </summary>
        /// <param name="generateDto"></param>
        /// <param name="replaceDto">替换实体</param>
        private static void GenerateModels(ReplaceDto replaceDto, GenerateDto generateDto)
        {
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, "TplModel.txt");
            var tplDto = JnHelper.ReadTemplate(CodeTemplateDir, "TplDto.txt");

            string fullPath = Path.Combine(generateDto.GenOptions.ModelsNamespace, "Models", generateDto.GenOptions.SubNamespace, replaceDto.ModelTypeName + ".cs");
            string fullPathDto = Path.Combine(generateDto.GenOptions.ModelsNamespace, "Dto", generateDto.GenOptions.SubNamespace, replaceDto.ModelTypeName + "Dto.cs");

            generateDto.GenCodes.Add(new GenCode(1, "Model.cs", fullPath, tpl.Render()));
            generateDto.GenCodes.Add(new GenCode(2, "Dto.cs", fullPathDto, tplDto.Render()));
        }

        /// <summary>
        /// 生成Repository层代码文件
        /// </summary>
        /// <param name="generateDto"></param>
        /// <param name="replaceDto">替换实体</param>
        private static void GenerateRepository(ReplaceDto replaceDto, GenerateDto generateDto)
        {
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, "TplRepository.txt");
            var result = tpl.Render();
            var fullPath = Path.Combine(generateDto.GenOptions.RepositoriesNamespace, generateDto.GenOptions.SubNamespace, $"{replaceDto.ModelTypeName}Repository.cs");

            generateDto.GenCodes.Add(new GenCode(3, "Repository.cs", fullPath, result));
        }

        /// <summary>
        /// 生成Service文件
        /// </summary>
        private static void GenerateService(ReplaceDto replaceDto, GenerateDto generateDto)
        {
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, "TplService.txt");
            var tpl2 = JnHelper.ReadTemplate(CodeTemplateDir, "TplIService.txt");

            var fullPath = Path.Combine(generateDto.GenOptions.ServicesNamespace, generateDto.GenOptions.SubNamespace, $"{replaceDto.ModelTypeName}Service.cs");
            var fullPath2 = Path.Combine(generateDto.GenOptions.IServicsNamespace, generateDto.GenOptions.SubNamespace, $"I{generateDto.GenOptions.SubNamespace}Service", $"I{replaceDto.ModelTypeName}Service.cs");

            generateDto.GenCodes.Add(new GenCode(4, "Service.cs", fullPath, tpl.Render()));
            generateDto.GenCodes.Add(new GenCode(4, "IService.cs", fullPath2, tpl2.Render()));
        }

        /// <summary>
        /// 生成控制器ApiControllers文件
        /// </summary>
        private static void GenerateControllers(ReplaceDto replaceDto, GenerateDto generateDto)
        {
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, "TplControllers.txt");
            tpl.Set("QueryCondition", replaceDto.QueryCondition);
            var result = tpl.Render();

            var fullPath = Path.Combine(generateDto.GenOptions.ApiControllerNamespace, "Controllers", generateDto.GenOptions.SubNamespace, $"{replaceDto.ModelTypeName}Controller.cs");
            generateDto.GenCodes.Add(new GenCode(5, "Controller.cs", fullPath, result));
        }

        /// <summary>
        /// 生成Vue页面
        private static void GenerateVueViews(ReplaceDto replaceDto, GenerateDto generateDto)
        {
            string fileName = generateDto.GenTable.TplCategory switch
            {
                "tree" => "TplTreeVue.txt",
                "select" => "TplVueSelect.txt",
                _ => "TplVue.txt",
            };
            replaceDto.VueViewListHtml = GenerateVueTableList();
            replaceDto.VueQueryFormHtml = GenerateVueQueryForm();
            replaceDto.VueViewFormHtml = GenerateCurdForm();

            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, fileName);
            var fullPath = Path.Combine(generateDto.VueParentPath, "src", "views", generateDto.GenTable.ModuleName.FirstLowerCase(), $"{generateDto.GenTable.BusinessName.FirstUpperCase()}.vue");

            generateDto.GenCodes.Add(new GenCode(6, "index.vue", fullPath, tpl.Render()));
        }

        /// <summary>
        /// vue3
        /// </summary>
        /// <param name="generateDto"></param>
        private static void GenerateVue3Views(GenerateDto generateDto)
        {
            string fileName = generateDto.GenTable.TplCategory switch
            {
                "tree" => "TreeVue.txt",
                _ => "Vue.txt",
            };
            fileName = Path.Combine("v3", fileName);
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, fileName);
            tpl.Set("treeCode", generateDto.GenTable?.Options?.TreeCode?.FirstLowerCase());
            tpl.Set("treeName", generateDto.GenTable?.Options?.TreeName?.FirstLowerCase());
            tpl.Set("treeParentCode", generateDto.GenTable?.Options?.TreeParentCode?.FirstLowerCase());
            tpl.Set("options", generateDto.GenTable?.Options);

            var result = tpl.Render();
            var fullPath = Path.Combine(generateDto.VueParentPath, "src", "views", generateDto.GenTable.ModuleName.FirstLowerCase(), $"{generateDto.GenTable.BusinessName.FirstUpperCase()}.vue");
            generateDto.GenCodes.Add(new GenCode(16, "index.vue", fullPath, result));
        }

        /// <summary>
        /// 生成vue页面api
        /// </summary>
        /// <param name="generateDto"></param>
        /// <returns></returns>
        public static void GenerateVueJs(GenerateDto generateDto)
        {
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, "TplVueApi.txt");
            var result = tpl.Render();

            string fileName;
            if (generateDto.VueVersion == 3)
            {
                fileName = generateDto.GenTable.BusinessName.ToLower() + ".js";//vue3 api引用目前只能小写
            }
            else
            {
                fileName = generateDto.GenTable.BusinessName.FirstLowerCase() + ".js";
            }
            string fullPath = Path.Combine(generateDto.VueParentPath, "src", "api", generateDto.GenTable.ModuleName.FirstLowerCase(), fileName);

            generateDto.GenCodes.Add(new GenCode(7, "api.js", fullPath, result));
        }

        /// <summary>
        /// 生成SQL
        /// </summary>
        /// <param name="generateDto"></param>
        public static void GenerateSql(GenerateDto generateDto)
        {
            var tempName = "";
            switch (generateDto.DbType)
            {
                case 0:
                    tempName = "MySqlTemplate";
                    break;
                case 1:
                    tempName = "SqlTemplate";
                    break;
                case 4:
                    tempName = "PgSql";
                    break;
                default:
                    break;
            }
            var tpl = JnHelper.ReadTemplate(CodeTemplateDir, Path.Combine("sql", $"{tempName}.txt"));
            tpl.Set("parentId", generateDto.GenTable?.Options?.ParentMenuId ?? 0);
            var result = tpl.Render();
            string fullPath = Path.Combine(generateDto.GenCodePath, "sql", generateDto.GenTable.BusinessName + ".sql");

            generateDto.GenCodes.Add(new GenCode(8, "sql", fullPath, result));
        }

        /// <summary>
        /// 生成vue页面查询form
        /// </summary>
        /// <returns></returns>
        public static string GenerateVueQueryForm()
        {
            return JnHelper.ReadTemplate(CodeTemplateDir, "QueryForm.txt").Render();
        }

        /// <summary>
        /// 生成vue页面table
        /// </summary>
        /// <returns></returns>
        public static string GenerateVueTableList()
        {
            return JnHelper.ReadTemplate(CodeTemplateDir, "TableList.txt").Render();
        }

        /// <summary>
        /// 生成vue表单
        /// </summary>
        /// <returns></returns>
        public static string GenerateCurdForm()
        {
            return JnHelper.ReadTemplate(CodeTemplateDir, "CurdForm.txt").Render();
        }
        #endregion

        #region 帮助方法

        /// <summary>
        /// 如果有前缀替换将前缀替换成空，替换下划线"_"为空再将首字母大写
        /// 表名转换成C#类名
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static string GetClassName(string tableName)
        {
            bool autoRemovePre = AppSettings.GetAppConfig(GenConstants.Gen_autoPre, false);
            string tablePrefix = AppSettings.GetAppConfig<string>(GenConstants.Gen_tablePrefix);

            if (!string.IsNullOrEmpty(tablePrefix) && autoRemovePre)
            {
                string[] prefixList = tablePrefix.Split(",", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < prefixList.Length; i++)
                {
                    if (!string.IsNullOrEmpty(prefixList[i].ToString()))
                    {
                        tableName = tableName.Replace(prefixList[i], "", StringComparison.OrdinalIgnoreCase);
                    }
                }
            }
            return tableName.UnderScoreToCamelCase();
        }

        /// <summary>
        /// 获取前端标签名
        /// </summary>
        /// <param name="columnDescription"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string GetLabelName(string columnDescription, string columnName)
        {
            return string.IsNullOrEmpty(columnDescription) ? columnName : columnDescription;
        }

        /// <summary>
        /// 首字母转小写,模板使用(勿删)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstLowerCase(string str)
        {
            try
            {
                return string.IsNullOrEmpty(str) ? str : str[..1].ToLower() + str[1..];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        /// <summary>
        /// 获取C# 类型
        /// </summary>
        /// <param name="sDatatype"></param>
        /// <returns></returns>
        public static string GetCSharpDatatype(string sDatatype)
        {
            sDatatype = sDatatype.ToLower();
            string sTempDatatype = sDatatype switch
            {
                "int" or "number" or "integer" or "smallint" => "int",
                "bigint" => "long",
                "tinyint" => "byte",
                "numeric" or "real" or "float" => "float",
                "decimal" or "numer(8,2)" or "numeric" => "decimal",
                "bit" => "bool",
                "date" or "datetime" or "datetime2" or "smalldatetime" or "timestamp" => "DateTime",
                "money" or "smallmoney" => "decimal",
                _ => "string",
            };
            return sTempDatatype;
        }

        #endregion

        #region 初始化信息

        /// <summary>
        /// 初始化表信息
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="userName"></param>
        /// <param name="tableName"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static GenTable InitTable(string dbName, string userName, string tableName, string desc)
        {
            //应用程序启动目录
            string StartupPathStr = Directory.GetCurrentDirectory();
            //返回上一层目录
            string CDUPStr = StartupPathStr.Substring(0, StartupPathStr.LastIndexOf("\\")); // 第一个\是转义符，所以要写两个
            GenTable genTable = new()
            {
                //数据库名称
                DbName = dbName,
                //导入默认命名空间前缀
                BaseNameSpace = "La.",
                //导入默认模块名，按需更改
                ModuleName = "La",
                //生成实体类名，首字大写
                ClassName = GetClassName(tableName).FirstUpperCase(),
                ////生成业务名，首字大写
                BusinessName = tableName.UnderScoreToCamelCase().FirstUpperCase(),
                //程序员
                FunctionAuthor = AppSettings.GetConfig(GenConstants.Gen_author),
                //表名
                TableName = tableName,
                //表描述
                TableComment = desc,
                //生成功能名
                FunctionName = desc,
                //创建者
                Create_by = userName,
                //基本信息备注
                ReMark = desc + "(" + tableName + ")",
                //自定义路径
                GenPath = CDUPStr,
                //生成代码方式：1为自定义路径，0为zip打包下载
                GenType="1",
                //显示按钮
                Options = new Options()
                {
                    SortType = "asc",
                    CheckedBtn = new int[] { 1, 2, 3, 4, 7, 8 }
                }
            };
            bool isContain = tableName.Contains("_");
            if (isContain)
            {
                //权限前缀，如表sys_user，前缀为sys:user
                genTable.Options.PermissionPrefix = tableName.ToLower().Substring(0, tableName.IndexOf("_")) + ":" + $"{genTable.ClassName.ToLower().Replace(tableName.ToLower().Substring(0, tableName.IndexOf("_")), "")}";//权限
            }
            else
            {
                //权限前缀，如表sysuser，前缀为la:sysuser
                genTable.Options.PermissionPrefix = $"{genTable.ModuleName.ToLower()}:{genTable.ClassName.ToLower()}";//权限

            }
            //genTable.Options.PermissionPrefix = $"{genTable.ModuleName.ToLower()}:{genTable.ClassName.ToLower()}";//权限

            return genTable;
        }

        /// <summary>
        /// 初始化列属性字段数据
        /// </summary>
        /// <param name="genTable"></param>
        /// <param name="dbColumnInfos"></param>
        public static List<GenTableColumn> InitGenTableColumn(GenTable genTable, List<DbColumnInfo> dbColumnInfos)
        {
            List<GenTableColumn> genTableColumns = new();
            foreach (var column in dbColumnInfos)
            {
                genTableColumns.Add(InitColumnField(genTable, column));
            }
            return genTableColumns;
        }

        /// <summary>
        /// 初始化表字段数据
        /// </summary>
        /// <param name="genTable"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private static GenTableColumn InitColumnField(GenTable genTable, DbColumnInfo column)
        {
            GenTableColumn genTableColumn = new()
            {
                ColumnName = column.DbColumnName.FirstLowerCase(),
                ColumnComment = column.ColumnDescription,
                IsPk = column.IsPrimarykey,
                ColumnType = column.DataType,
                TableId = genTable.TableId,
                TableName = genTable.TableName,
                CsharpType = GetCSharpDatatype(column.DataType),
                CsharpField = column.DbColumnName.ConvertToPascal("_"),
                IsRequired = !column.IsNullable,
                IsIncrement = column.IsIdentity,
                Create_by = genTable.Create_by,
                Create_time = DateTime.Now,
                //IsInsert = !column.IsIdentity || GenConstants.inputDtoNoField.Any(f => f.Contains(column.DbColumnName, StringComparison.OrdinalIgnoreCase)),//非自增字段都需要插入
                IsInsert = !column.IsIdentity || GenConstants.inputDtoNoField.Any(f => f.Contains(column.DbColumnName, StringComparison.OrdinalIgnoreCase)),//非自增字段都需要插入
                IsEdit = true,
                IsQuery = false,
                IsExport = true,
                HtmlType = GenConstants.HTML_INPUT,
            };
            //不输入字段
            if (GenConstants.inputDtoNoField.Any(f => column.DbColumnName.ToLower().Contains(f.ToLower())))
            {
                genTableColumn.IsInsert = false;
            }
            //必填字段
            if (GenConstants.COLUMNNAME_NOT_REQUIRED.Any(f => column.DbColumnName.ToLower().Contains(f.ToLower())))
            {
                genTableColumn.IsRequired = false;
            }
            //图片上传字段
            if (GenConstants.imageFiled.Any(f => column.DbColumnName.ToLower().Contains(f.ToLower())))
            {
                genTableColumn.HtmlType = GenConstants.HTML_IMAGE_UPLOAD;
            }
            //时间字段
            else if (GenConstants.COLUMNTYPE_TIME.Any(f => genTableColumn.CsharpType.ToLower().Contains(f.ToLower())))
            {
                genTableColumn.HtmlType = GenConstants.HTML_DATETIME;
            }
            //单选字段
            else if (GenConstants.radioFiled.Any(f => column.DbColumnName.EndsWith(f, StringComparison.OrdinalIgnoreCase)) ||
                GenConstants.radioFiled.Any(f => column.DbColumnName.StartsWith(f, StringComparison.OrdinalIgnoreCase)))
            {
                genTableColumn.HtmlType = GenConstants.HTML_RADIO;
            }
            //选择框字段
            else if (GenConstants.selectFiled.Any(f => column.DbColumnName == f) ||
                GenConstants.selectFiled.Any(f => column.DbColumnName.EndsWith(f, StringComparison.OrdinalIgnoreCase)))
            {
                genTableColumn.HtmlType = GenConstants.HTML_SELECT;
            }
            else if (column.Length > 500)
            {
                genTableColumn.HtmlType = GenConstants.HTML_TEXTAREA;
            }
            //编辑字段
            if (column.IsIdentity || column.IsPrimarykey || GenConstants.COLUMNNAME_NOT_EDIT.Any(f => column.DbColumnName.Contains(f)))
            {
                genTableColumn.IsEdit = false;
            }
            //列表字段
            if (!GenConstants.COLUMNNAME_NOT_LIST.Any(f => column.DbColumnName.Contains(f) && !column.IsPrimarykey))
            {
                genTableColumn.IsList = true;
            }
            //导出字段
            if (GenConstants.COLUMNNAME_NOT_EXPORT.Any(f => column.DbColumnName.ToLower().Contains(f.ToLower())))
            {
                genTableColumn.IsExport = false;
            }
            //时间类型初始化between范围查询
            if (genTableColumn.CsharpType == GenConstants.TYPE_DATE)
            {
                genTableColumn.QueryType = "BETWEEN";
            }

            return genTableColumn;
        }

        #endregion

        /// <summary>
        /// 初始化Jnt模板
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="replaceDto"></param>
        private static void InitJntTemplate(GenerateDto dto, ReplaceDto replaceDto)
        {
            Engine.Current.Clean();
            dto.GenTable.Columns = dto.GenTable.Columns.OrderBy(x => x.Sort).ToList();
            bool showCustomInput = dto.GenTable.Columns.Any(f => f.HtmlType.Equals(GenConstants.HTML_CUSTOM_INPUT, StringComparison.OrdinalIgnoreCase));
            //jnt模板引擎全局变量
            Engine.Configure((options) =>
            {
                options.TagPrefix = "${";
                options.TagSuffix = "}";
                options.TagFlag = '$';
                options.OutMode = OutMode.Auto;
                //options.DisableeLogogram = true;//禁用简写
                options.Data.Set("refs", "$");//特殊标签替换
                options.Data.Set("t", "$");//特殊标签替换
                options.Data.Set("modal", "$");//特殊标签替换
                options.Data.Set("index", "$");//特殊标签替换
                options.Data.Set("confirm", "$");//特殊标签替换
                options.Data.Set("nextTick", "$");
                options.Data.Set("replaceDto", replaceDto);
                options.Data.Set("options", dto.GenOptions);
                options.Data.Set("subTableOptions", dto.SubTableOptions);
                options.Data.Set("genTable", dto.GenTable);
                options.Data.Set("genSubTable", dto.GenTable?.SubTable);
                options.Data.Set("showCustomInput", showCustomInput);
                options.Data.Set("tool", new CodeGeneratorTool());
                options.Data.Set("codeTool", new CodeGenerateTemplate());
                options.EnableCache = true;
                //...其它数据
            });
        }

        #region 模板用
        /// <summary>
        /// 模板用
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckInputDtoNoField(string str)
        {
            return GenConstants.inputDtoNoField.Any(f => f.Contains(str, StringComparison.OrdinalIgnoreCase));
        }
        public static bool CheckTree(GenTable genTable, string csharpField)
        {
            return (genTable.TplCategory.Equals("tree", StringComparison.OrdinalIgnoreCase) && genTable?.Options?.TreeParentCode != null && csharpField.Equals(genTable?.Options?.TreeParentCode));
        }
        #endregion
    }
}
