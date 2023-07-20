<template>
  <view class="edit-form">
    <u--form labelPosition="left" :model="form" labelWidth="90px" :rules="rules" ref="uForm">

            <u-form-item label="Guid" prop="ifGuid">
              <u--input type="number" v-model.number="form.ifGuid" placeholder="请输入Guid" :disabled="opertype != 1"></u--input>
            </u-form-item>

            <u-form-item label="类别" prop="ifType">
              <uni-data-select v-model="form.ifType" :clear="true" :localdata="ifTypeOptions"
              format="{label} - {value}"></uni-data-select>
            </u-form-item>

            <u-form-item label="语言" prop="ifLangKey">
              <u--input v-model="form.ifLangKey" placeholder="请输入语言" />
            </u-form-item>

            <u-form-item label="公式" prop="ifFormula">
              <u--input v-model="form.ifFormula" placeholder="请输入公式" />
            </u-form-item>

      <u-form-item label="软删除" prop="isDeleted">
            <u-radio-group v-model="form.isDeleted">
              <u-radio v-for="item in isDeletedOptions" :name="item.value" class="margin-right-xl">{{item.label}}</u-radio>
            </u-radio-group>
      </u-form-item>

            <u-form-item label="Remark" prop="remark">
              <u--input v-model="form.remark" placeholder="请输入Remark" />
            </u-form-item>

            <u-form-item label="CreateBy" prop="createBy">
              <u--input v-model="form.createBy" placeholder="请输入CreateBy" />
            </u-form-item>

      <u-form-item label="CreateTime" prop="createTime">
              <uni-datetime-picker v-model="form.createTime" />
      </u-form-item>

            <u-form-item label="UpdateBy" prop="updateBy">
              <u--input v-model="form.updateBy" placeholder="请输入UpdateBy" />
            </u-form-item>

      <u-form-item label="UpdateTime" prop="updateTime">
              <uni-datetime-picker v-model="form.updateTime" />
      </u-form-item>

    </u--form>

    <view class="btn-group">
      <view class="btn-item">
        <u-button text="取消" shape="circle" icon="close" type="info" @click="handleCancel"></u-button>
      </view>
      <view class="btn-item" v-if="opertype != 3">
        <u-button text="确定" shape="circle" icon="checkmark" type="primary" @click="submit"></u-button>
      </view>
    </view>
  </view>
</template>

<script>
  import "@/static/scss/page.scss";
  import {
    getInstFormula,
 
    addInstFormula,
 
    updateInstFormula,
}
from '@/api/office/instformula.js'

  export default {
    dicts: [
    ],
    data() {
      return {
        form: {},
        rules: {
          xxx: {},
          ifGuid: [{
            required: true, 
            message: "Guid不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          ifType: [{
            required: true, 
            message: "类别不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          ifLangKey: [{
            required: true, 
            message: "语言不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          ifFormula: [{
            required: true, 
            message: "公式不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
        },
        opertype: 0,
        // 类别选项列表 格式 eg:{ label: '标签', value: '0'}
        ifTypeOptions: [],
        // 软删除选项列表 格式 eg:{ label: '标签', value: '0'}
        isDeletedOptions: [],
      }
    },
    onReady() {
      // 需要在onReady中设置规则
      setTimeout(() => {
        this.$refs.uForm.setRules(this.rules)
      }, 300)
    },
    onLoad(e) {
      this.opertype = e.opertype
      if (e.id) {
        getInstFormula(e.id).then(res => {
          const {
            code,
            data
          } = res
          if (code == 200) {
            this.form = {
              ...data,
                          }
          }
        })
      } else {
        this.reset()
      }
    },
    methods: {
      reset(){
      this.form = {
        ifGuid: undefined,
        ifType: undefined,
        ifLangKey: undefined,
        ifFormula: undefined,
        isDeleted: undefined,
        remark: undefined,
        createBy: undefined,
        createTime: undefined,
        updateBy: undefined,
        updateTime: undefined,
      };
    },
      submit() {
        this.$refs.uForm.validate().then(res => {
          this.$modal.msg('表单校验通过')

                    if (this.form.ifGuid != undefined && this.opertype == 2) {
            updateInstFormula(this.form).then((res) => {
                this.$modal.msgSuccess("修改成功")
            })
              .catch(() => {})
          } else {
            addInstFormula(this.form).then((res) => {
                this.$modal.msgSuccess("新增成功")
              })
              .catch(() => {})
          }
        }).catch(errors => {
          this.$modal.msg('表单校验失败')
        })
      },
      handleCancel() {
        uni.navigateBack()
      }
    }
  }
</script>

<style scoped>
  .btn-wrap {
    margin: 150rpx auto 0 auto;
    width: 80%
  }
</style>