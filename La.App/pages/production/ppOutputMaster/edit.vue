<template>
  <view class="edit-form">
    <u--form labelPosition="left" :model="form" labelWidth="90px" :rules="rules" ref="uForm">
        
            <u-form-item label="ID" prop="pomId" v-if="opertype != 1">
              <u--input type="number" v-model.number="form.pomId" placeholder="请输入ID" :disabled="true"/>
            </u-form-item>

            <u-form-item label="GUID" prop="pomGuid">
              <u--input v-model="form.pomGuid" placeholder="请输入GUID" />
            </u-form-item>

            <u-form-item label="生产工单" prop="pomOrder">
              <u--input v-model="form.pomOrder" placeholder="请输入生产工单" />
            </u-form-item>

            <u-form-item label="工单数量" prop="pomOrderQty">
              <u--input v-model="form.pomOrderQty" placeholder="请输入工单数量" />
            </u-form-item>

            <u-form-item label="管理序列号" prop="pomOrderSerial">
              <u--input v-model="form.pomOrderSerial" placeholder="请输入管理序列号" />
            </u-form-item>

            <u-form-item label="生产批次" prop="pomMflot">
              <u--input v-model="form.pomMflot" placeholder="请输入生产批次" />
            </u-form-item>

            <u-form-item label="机种名" prop="pomModelName">
              <u--input v-model="form.pomModelName" placeholder="请输入机种名" />
            </u-form-item>

            <u-form-item label="物料" prop="pomMfItem">
              <u--input v-model="form.pomMfItem" placeholder="请输入物料" />
            </u-form-item>

      <u-form-item label="生产日期" prop="pomMfDate">
              <uni-datetime-picker v-model="form.pomMfDate" />
      </u-form-item>

            <u-form-item label="生产班组" prop="pomLineName">
              <u--input v-model="form.pomLineName" placeholder="请输入生产班组" />
            </u-form-item>
        
            <u-form-item label="直接人数" prop="pomDirect">
              <u--input v-model.number="form.pomDirect" placeholder="请输入直接人数" />
            </u-form-item>
        
            <u-form-item label="间接人数" prop="pomIndirect">
              <u--input v-model.number="form.pomIndirect" placeholder="请输入间接人数" />
            </u-form-item>

            <u-form-item label="标准工时" prop="pomStdTime">
              <u--input v-model="form.pomStdTime" placeholder="请输入标准工时" />
            </u-form-item>

            <u-form-item label="标准产能" prop="pomStdOutput">
              <u--input v-model="form.pomStdOutput" placeholder="请输入标准产能" />
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

      <u-form-item label="备注" prop="reMark">
        <u--textarea v-model="form.reMark" placeholder="请输入内容" count ></u--textarea>
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
    getPpOutputMaster,
 
    addPpOutputMaster,
 
    updatePpOutputMaster,
}
from '@/api/production/ppoutputmaster.js'

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
            message: "GUID不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          pomOrder: [{
            required: true, 
            message: "生产工单不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          pomOrderQty: [{
            required: true, 
            message: "工单数量不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          pomOrderSerial: [{
            required: true, 
            message: "管理序列号不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          pomMflot: [{
            required: true, 
            message: "生产批次不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          pomModelName: [{
            required: true, 
            message: "机种名不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          pomMfItem: [{
            required: true, 
            message: "物料不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          pomMfDate: [{
            required: true, 
            message: "生产日期不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          pomLineName: [{
            required: true, 
            message: "生产班组不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          pomDirect: [{
            required: true, 
            message: "直接人数不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
          pomIndirect: [{
            required: true, 
            message: "间接人数不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
          pomStdTime: [{
            required: true, 
            message: "标准工时不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          pomStdOutput: [{
            required: true, 
            message: "标准产能不能为空", 
            trigger: [ 'change', 'blur' ],
 
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
        getPpOutputMaster(e.id).then(res => {
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
        pomId: undefined,
        pomGuid: undefined,
        pomOrder: undefined,
        pomOrderQty: undefined,
        pomOrderSerial: undefined,
        pomMflot: undefined,
        pomModelName: undefined,
        pomMfItem: undefined,
        pomMfDate: undefined,
        pomLineName: undefined,
        pomDirect: undefined,
        pomIndirect: undefined,
        pomStdTime: undefined,
        pomStdOutput: undefined,
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
        reMark: undefined,
        createBy: undefined,
        createTime: undefined,
        updateBy: undefined,
        updateTime: undefined,
      };
    },
      submit() {
        this.$refs.uForm.validate().then(res => {
          this.$modal.msg('表单校验通过')

                    if (this.form.pomId != undefined && this.opertype == 2) {
            updatePpOutputMaster(this.form).then((res) => {
                this.$modal.msgSuccess("修改成功")
            })
              .catch(() => {})
          } else {
            addPpOutputMaster(this.form).then((res) => {
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