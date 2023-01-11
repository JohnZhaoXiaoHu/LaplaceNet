﻿using System.Collections.Generic;
using La.Model;
using La.Model.System;

namespace La.Service.System.IService
{
    public interface ISysDictDataService : IBaseService<SysDictData>
    {
        public PagedInfo<SysDictData> SelectDictDataList(SysDictData dictData, PagerInfo pagerInfo);
        public List<SysDictData> SelectDictDataByType(string dictType);
        public List<SysDictData> SelectDictDataByTypes(string[] dictTypes);
        public SysDictData SelectDictDataById(long dictCode);
        public long InsertDictData(SysDictData dict);
        public long UpdateDictData(SysDictData dict);
        public int DeleteDictDataByIds(long[] dictCodes);
        int UpdateDictDataType(string old_dictType, string new_dictType);
        List<SysDictData> SelectDictDataByCustomSql(SysDictType sysDictType);
    }
}
