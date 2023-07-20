<template>
  <view class="edit-form">
    <u--form labelPosition="left" :model="form" labelWidth="90px" :rules="rules" ref="uForm">
        
            <u-form-item label="ID" prop="posId" v-if="opertype != 1">
              <u--input type="number" v-model.number="form.posId" placeholder="请输入ID" :disabled="true"/>
            </u-form-item>

            <u-form-item label="父GUID" prop="pomGuid">
              <u--input v-model="form.pomGuid" placeholder="请输入父GUID" />
            </u-form-item>

            <u-form-item label="生产时段" prop="posStartEndTime">
              <u--input v-model="form.posStartEndTime" placeholder="请输入生产时段" />
            </u-form-item>
        
            <u-form-item label="实际产能" prop="posRealOutput">
              <u--input v-model.number="form.posRealOutput" placeholder="请输入实际产能" />
            </u-form-item>
        
            <u-form-item label="停线时间" prop="posLineStopTime">
              <u--input v-model.number="form.posLineStopTime" placeholder="请输入停线时间" />
            </u-form-item>

            <u-form-item label="停线原因" prop="posStopCause">
              <u--input v-model="form.posStopCause" placeholder="请输入停线原因" />
            </u-form-item>

            <u-form-item label="停线说明" prop="posStopMemo">
              <u--input v-model="form.posStopMemo" placeholder="请输入停线说明" />
            </u-form-item>

            <u-form-item label="未达成原因" prop="posBadCause">
              <u--input v-model="form.posBadCause" placeholder="请输入未达成原因" />
            </u-form-item>

            <u-form-item label="未达成说明" prop="posBadMemo">
              <u--input v-model="form.posBadMemo" placeholder="请输入未达成说明" />
            </u-form-item>
        
            <u-form-item label="实际工数" prop="posRealTime">
              <u--input v-model.number="form.posRealTime" placeholder="请输入实际工数" />
            </u-form-item>

            <u-form-item label="实际工时" prop="posRealWork">
              <u--input v-model="form.posRealWork" placeholder="请输入实际工时" />
            </u-form-item>

            <u-form-item label="工时差异" prop="posRealWorkDiff">
              <u--input v-model="form.posRealWorkDiff" placeholder="请输入工时差异" />
            </u-form-item>

            <u-form-item label="产能差异" prop="posRealOutputDiff">
              <u--input v-model="form.posRealOutputDiff" placeholder="请输入产能差异" />
            </u-form-item>
        
            <u-form-item label="达成率" prop="posAchRatio">
              <u--input v-model.number="form.posAchRatio" placeholder="请输入达成率" />
            </u-form-item>

            <u-form-item label="UDF01" prop="uDF01">
              <u--input v-model="form.uDF01" placeholder="请输入UDF01" />
            </u-form-item>

            <u-form-item label="UDF02" prop="uDF02">
              <u--input v-model="form.uDF02" placeholder="请输入UDF02" />
            </u-form-item>

            <u-form-item label="UDF03" prop="uDF03">
              <u--input v-model="form.uDF03" placeholder="请输入UDF03" />
            </u-form-item>

            <u-form-item label="UDF04" prop="uDF04">
              <u--input v-model="form.uDF04" placeholder="请输入UDF04" />
            </u-form-item>

            <u-form-item label="UDF05" prop="uDF05">
              <u--input v-model="form.uDF05" placeholder="请输入UDF05" />
            </u-form-item>

            <u-form-item label="UDF06" prop="uDF06">
              <u--input v-model="form.uDF06" placeholder="请输入UDF06" />
            </u-form-item>

            <u-form-item label="UDF51" prop="uDF51">
              <u--input v-model="form.uDF51" placeholder="请输入UDF51" />
            </u-form-item>

            <u-form-item label="UDF52" prop="uDF52">
              <u--input v-model="form.uDF52" placeholder="请输入UDF52" />
            </u-form-item>

            <u-form-item label="UDF53" prop="uDF53">
              <u--input v-model="form.uDF53" placeholder="请输入UDF53" />
            </u-form-item>

            <u-form-item label="UDF54" prop="uDF54">
              <u--input v-model="form.uDF54" placeholder="请输入UDF54" />
            </u-form-item>

            <u-form-item label="UDF55" prop="uDF55">
              <u--input v-model="form.uDF55" placeholder="请输入UDF55" />
            </u-form-item>

            <u-form-item label="UDF56" prop="uDF56">
              <u--input v-model="form.uDF56" placeholder="请输入UDF56" />
            </u-form-item>

      <u-form-item label="软删除" prop="isDeleted">
            <u-radio-group v-model="form.isDeleted">
              <u-radio v-for="item in isDeletedOptions" :name="item.value" class="margin-right-xl">{{item.label}}</u-radio>
            </u-radio-group>
      </u-form-item>

            <u-form-item label="说明" prop="remark">
              <u--input v-model="form.remark" placeholder="请输入说明" />
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
    getPpOutputSlave,
 
    addPpOutputSlave,
 
    updatePpOutputSlave,
}
from '@/api/production/ppoutputslave.js'

  export default {
    dicts: [
    ],
    data() {
      return {
        form: {},
        rules: {
          xxx: {},
          pomGuid: [{
            required: true, 
            message: "父GUID不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          posRealOutput: [{
            required: true, 
            message: "实际产能不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
          posLineStopTime: [{
            required: true, 
            message: "停线时间不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
          posRealTime: [{
            required: true, 
            message: "实际工数不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
          posRealWork: [{
            required: true, 
            message: "实际工时不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          posRealWorkDiff: [{
            required: true, 
            message: "工时差异不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          posRealOutputDiff: [{
            required: true, 
            message: "产能差异不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          posAchRatio: [{
            required: true, 
            message: "达成率不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
        },
        opertype: 0,
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
        getPpOutputSlave(e.id).then(res => {
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
        posId: undefined,
        pomGuid: undefined,
        posStartEndTime: undefined,
        posRealOutput: undefined,
        posLineStopTime: undefined,
        posStopCause: undefined,
        posStopMemo: undefined,
        posBadCause: undefined,
        posBadMemo: undefined,
        posRealTime: undefined,
        posRealWork: undefined,
        posRealWorkDiff: undefined,
        posRealOutputDiff: undefined,
        posAchRatio: undefined,
        uDF01: undefined,
        uDF02: undefined,
        uDF03: undefined,
        uDF04: undefined,
        uDF05: undefined,
        uDF06: undefined,
        uDF51: undefined,
        uDF52: undefined,
        uDF53: undefined,
        uDF54: undefined,
        uDF55: undefined,
        uDF56: undefined,
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

                    if (this.form.posId != undefined && this.opertype == 2) {
            updatePpOutputSlave(this.form).then((res) => {
                this.$modal.msgSuccess("修改成功")
            })
              .catch(() => {})
          } else {
            addPpOutputSlave(this.form).then((res) => {
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