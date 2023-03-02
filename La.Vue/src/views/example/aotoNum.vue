<!--
 * @Descripttion: (物料信息/mm_mats)
 * @version: (1.0)
 * @Author: (Laplace.Net:Davis.Cheng)
 * @Date: (2023-02-25)
 * @LastEditors: (Laplace.Net:Davis.Cheng)
 * @LastEditTime: (2023-02-25)
-->
<template>
  <div>

    <el-form ref="formRef" :model="form" :rules="rules" label-width="100px">
      <el-row :gutter="20">

        <el-form-item :label="$t('showWay')">
          <el-radio-group v-model="queryParams.showMode">
            <el-radio-button label="1">自动</el-radio-button>
            <el-radio-button label="2">手动</el-radio-button>
          </el-radio-group>
        </el-form-item>

        <el-col :lg="24">
          <el-form-item label="单据" prop="mmMatItem">
            <el-select v-model="form.mmMatTypes" :placeholder="$t('btn.select')+'单据'" clearable filterable
              :disabled="title==$t('btn.edit')" @change="AutoCodeassignment">
              <el-option v-for="item in  options.sql_auto_number " :key="item.dictValue" :label="item.dictLabel"
                :value="item.dictValue"></el-option>
            </el-select>
            <el-input v-model="form.mmMatItem" :placeholder="$t('btn.enter')+'初始编码'" :disabled="title==$t('btn.edit')">
            </el-input>
            <div style="color:Coral; font-weight:bolder">
              {{matscode}}
            </div>
          </el-form-item>
        </el-col>

        <el-col :lg="24">
          <el-form-item label="编码文本" prop="mmMatDes">
            <el-input v-model="form.mmMatDes" :placeholder="$t('btn.enter')+'编码文本'" />
          </el-form-item>
        </el-col>
        <el-col :span="8">
          <el-form-item label="工单编号" prop="workorderCode">
            <el-input v-model="form.workorderCode" placeholder="请输入工单编号" />
          </el-form-item>
        </el-col>
        <el-col :span="4">
          <el-form-item label-width="80">
            <el-switch v-model="autoGenFlag" active-color="#13ce66" active-text="自动生成"
              @change="handleAutoGenChange(autoGenFlag)">
            </el-switch>
          </el-form-item>
        </el-col>

      </el-row>
    </el-form>


  </div>
</template>

<script setup name="mmmats">
  // 引入 mmmats操作方法
  // 引入 sysrefstrategy操作方法
  import {
    genCode, listSysRefStrategy, addSysRefStrategy, delSysRefStrategy, updateSysRefStrategy, getSysRefStrategy,

  }
    from '@/api/system/sysrefstrategy.js'
  //获取当前组件实例
  const { proxy } = getCurrentInstance()
  //按物料编码获取物料号码
  const matscode = ref()
  const autoGenFlag = false;
  //利用物料现有编码计算出物料号

  var dictParams = [
    { dictType: "sql_auto_number" },

  ]
  //字典定义
  proxy.getDicts(dictParams).then((response) => {
    response.data.forEach((element) => {
      state.options[element.dictType] = element.list
    })
  })

  //reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
  const state = reactive({
    form: {},
    rules: {},
    options: {
      // 物料编码 选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
      sql_auto_number: [],
    }
  })
  //将响应式对象转换成普通对象
  const { form, rules, options } = toRefs(state)
  function AutoCodeassignment(val) {
    form.value.mmMatItem = val.split(",").slice(0, 1).join()
    matscode.value = val
  }
  //使用reactive()定义响应式变量,仅支持对象、数组、Map、Set等集合类型有效
  const queryParams = reactive({
    refName: '国内客户',

  })
  //自动生成编码
  function handleAutoGenChange(autoGenFlag) {
    debugger;
    if (autoGenFlag) {
      listSysRefStrategy(queryParams).then(res => {
        matscode.value = res.data.result
        form.value.workorderCode = res.data.result
      })
    } else {
      form.value.workorderCode = null;
    }
  }
  handleAutoGenChange()
</script>

<style lang="scss" scoped>
</style>