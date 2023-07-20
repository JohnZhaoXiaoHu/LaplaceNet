<template>
  <view class="edit-form">
    <u--form labelPosition="left" :model="form" labelWidth="90px" :rules="rules" ref="uForm">
        
            <u-form-item label="ID" prop="scId" v-if="opertype != 1">
              <u--input type="number" v-model.number="form.scId" placeholder="请输入ID" :disabled="true"/>
            </u-form-item>

            <u-form-item label="销售组织" prop="scOrg">
              <u--input v-model="form.scOrg" placeholder="请输入销售组织" />
            </u-form-item>

            <u-form-item label="销售工厂" prop="scPlant">
              <u--input v-model="form.scPlant" placeholder="请输入销售工厂" />
            </u-form-item>

            <u-form-item label="行业类别" prop="scIndustryType">
              <uni-data-select v-model="form.scIndustryType" :clear="true" :localdata="scIndustryTypeOptions"
              format="{label} - {value}"></uni-data-select>
            </u-form-item>

            <u-form-item label="企业性质" prop="scEnterpriseNature">
              <u--input v-model="form.scEnterpriseNature" placeholder="请输入企业性质" />
            </u-form-item>

            <u-form-item label="客户代码" prop="scCode">
              <u--input v-model="form.scCode" placeholder="请输入客户代码" />
            </u-form-item>

            <u-form-item label="客户简称" prop="scAbbr">
              <u--input v-model="form.scAbbr" placeholder="请输入客户简称" />
            </u-form-item>

            <u-form-item label="客户名称" prop="scName">
              <u--input v-model="form.scName" placeholder="请输入客户名称" />
            </u-form-item>

            <u-form-item label="企业法人" prop="scEbe">
              <u--input v-model="form.scEbe" placeholder="请输入企业法人" />
            </u-form-item>

            <u-form-item label="营业执照" prop="scBusinessNo">
              <u--input v-model="form.scBusinessNo" placeholder="请输入营业执照" />
            </u-form-item>

            <u-form-item label="税号" prop="scTaxNo">
              <u--input v-model="form.scTaxNo" placeholder="请输入税号" />
            </u-form-item>

            <u-form-item label="税别" prop="scTaxType">
              <uni-data-select v-model="form.scTaxType" :clear="true" :localdata="scTaxTypeOptions"
              format="{label} - {value}"></uni-data-select>
            </u-form-item>

            <u-form-item label="主营业务" prop="scMainBusiness">
              <u--input v-model="form.scMainBusiness" placeholder="请输入主营业务" />
            </u-form-item>

            <u-form-item label="交易币种" prop="scCcy">
              <u--input v-model="form.scCcy" placeholder="请输入交易币种" />
            </u-form-item>

            <u-form-item label="付款条件" prop="scPayTerms">
              <u--input v-model="form.scPayTerms" placeholder="请输入付款条件" />
            </u-form-item>

            <u-form-item label="付款方式" prop="scPayMethod">
              <u--input v-model="form.scPayMethod" placeholder="请输入付款方式" />
            </u-form-item>

            <u-form-item label="统驭科目" prop="scRecAccount">
              <u--input v-model="form.scRecAccount" placeholder="请输入统驭科目" />
            </u-form-item>

            <u-form-item label="贸易条件" prop="scTradeTerms">
              <u--input v-model="form.scTradeTerms" placeholder="请输入贸易条件" />
            </u-form-item>

            <u-form-item label="装运条件" prop="scShippingTerms">
              <u--input v-model="form.scShippingTerms" placeholder="请输入装运条件" />
            </u-form-item>

            <u-form-item label="客户等级" prop="scCustomerGrade">
              <u--input v-model="form.scCustomerGrade" placeholder="请输入客户等级" />
            </u-form-item>

            <u-form-item label="客户信用" prop="scCustomerCredit">
              <u--input v-model="form.scCustomerCredit" placeholder="请输入客户信用" />
            </u-form-item>

      <u-form-item label="首次交易" prop="scFirstTransDate">
              <uni-datetime-picker v-model="form.scFirstTransDate" />
      </u-form-item>

      <u-form-item label="最近交易" prop="scLastTransDate">
              <uni-datetime-picker v-model="form.scLastTransDate" />
      </u-form-item>

            <u-form-item label="银行代码" prop="scBankCode">
              <u--input v-model="form.scBankCode" placeholder="请输入银行代码" />
            </u-form-item>

            <u-form-item label="银行名称" prop="scBankName">
              <u--input v-model="form.scBankName" placeholder="请输入银行名称" />
            </u-form-item>

            <u-form-item label="分行名称" prop="scBranchName">
              <u--input v-model="form.scBranchName" placeholder="请输入分行名称" />
            </u-form-item>

            <u-form-item label="银行所在国" prop="scBankCountry">
              <u--input v-model="form.scBankCountry" placeholder="请输入银行所在国" />
            </u-form-item>

      <u-form-item label="银行所在州省" prop="scBankState">
            <u-radio-group v-model="form.scBankState">
              <u-radio v-for="item in scBankStateOptions" :name="item.value" class="margin-right-xl">{{item.label}}</u-radio>
            </u-radio-group>
      </u-form-item>

            <u-form-item label="银行所在市" prop="scBankCity">
              <u--input v-model="form.scBankCity" placeholder="请输入银行所在市" />
            </u-form-item>

            <u-form-item label="银行所在县" prop="scBankCounty">
              <u--input v-model="form.scBankCounty" placeholder="请输入银行所在县" />
            </u-form-item>

            <u-form-item label="银行地址" prop="scBankAddr">
              <u--input v-model="form.scBankAddr" placeholder="请输入银行地址" />
            </u-form-item>

            <u-form-item label="银行地址1" prop="scBankAddr1">
              <u--input v-model="form.scBankAddr1" placeholder="请输入银行地址1" />
            </u-form-item>

            <u-form-item label="银行地址2" prop="scBankAddr2">
              <u--input v-model="form.scBankAddr2" placeholder="请输入银行地址2" />
            </u-form-item>

            <u-form-item label="银行账号" prop="scBankAccount">
              <u--input v-model="form.scBankAccount" placeholder="请输入银行账号" />
            </u-form-item>

            <u-form-item label="SWIFT代码" prop="scBankSwiftNo">
              <u--input v-model="form.scBankSwiftNo" placeholder="请输入SWIFT代码" />
            </u-form-item>

            <u-form-item label="国家地区" prop="scRegionCode">
              <u--input v-model="form.scRegionCode" placeholder="请输入国家地区" />
            </u-form-item>

      <u-form-item label="州省" prop="scState">
            <u-radio-group v-model="form.scState">
              <u-radio v-for="item in scStateOptions" :name="item.value" class="margin-right-xl">{{item.label}}</u-radio>
            </u-radio-group>
      </u-form-item>

            <u-form-item label="市" prop="scCity">
              <u--input v-model="form.scCity" placeholder="请输入市" />
            </u-form-item>

            <u-form-item label="县" prop="scCounty">
              <u--input v-model="form.scCounty" placeholder="请输入县" />
            </u-form-item>

            <u-form-item label="地址" prop="scAddr">
              <u--input v-model="form.scAddr" placeholder="请输入地址" />
            </u-form-item>

            <u-form-item label="地址1" prop="scAddr1">
              <u--input v-model="form.scAddr1" placeholder="请输入地址1" />
            </u-form-item>

            <u-form-item label="地址2" prop="scAddr2">
              <u--input v-model="form.scAddr2" placeholder="请输入地址2" />
            </u-form-item>

            <u-form-item label="联系人" prop="scContacts">
              <u--input v-model="form.scContacts" placeholder="请输入联系人" />
            </u-form-item>

            <u-form-item label="电邮" prop="scEmail">
              <u--input v-model="form.scEmail" placeholder="请输入电邮" />
            </u-form-item>

            <u-form-item label="电话" prop="scTelNo">
              <u--input v-model="form.scTelNo" placeholder="请输入电话" />
            </u-form-item>

            <u-form-item label="传真" prop="scFaxNp">
              <u--input v-model="form.scFaxNp" placeholder="请输入传真" />
            </u-form-item>

            <u-form-item label="手机" prop="scPhoneNo">
              <u--input v-model="form.scPhoneNo" placeholder="请输入手机" />
            </u-form-item>

      <u-form-item label="冻结标记" prop="isFroze">
            <u-radio-group v-model="form.isFroze">
              <u-radio v-for="item in isFrozeOptions" :name="item.value" class="margin-right-xl">{{item.label}}</u-radio>
            </u-radio-group>
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

            <u-form-item label="说明" prop="reMark">
              <u--input v-model="form.reMark" placeholder="请输入说明" />
            </u-form-item>

      <u-form-item label="软删除" prop="isDeleted">
            <u-radio-group v-model="form.isDeleted">
              <u-radio v-for="item in isDeletedOptions" :name="item.value" class="margin-right-xl">{{item.label}}</u-radio>
            </u-radio-group>
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
    getSdClient,
 
    addSdClient,
 
    updateSdClient,
}
from '@/api/sales/sdclient.js'

  export default {
    dicts: [
    ],
    data() {
      return {
        form: {},
        rules: {
          xxx: {},
          scOrg: [{
            required: true, 
            message: "销售组织不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scPlant: [{
            required: true, 
            message: "销售工厂不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scIndustryType: [{
            required: true, 
            message: "行业类别不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scEnterpriseNature: [{
            required: true, 
            message: "企业性质不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scCode: [{
            required: true, 
            message: "客户代码不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scAbbr: [{
            required: true, 
            message: "客户简称不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scName: [{
            required: true, 
            message: "客户名称不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scEbe: [{
            required: true, 
            message: "企业法人不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scBusinessNo: [{
            required: true, 
            message: "营业执照不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scTaxNo: [{
            required: true, 
            message: "税号不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scTaxType: [{
            required: true, 
            message: "税别不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scMainBusiness: [{
            required: true, 
            message: "主营业务不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scCcy: [{
            required: true, 
            message: "交易币种不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scPayTerms: [{
            required: true, 
            message: "付款条件不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scPayMethod: [{
            required: true, 
            message: "付款方式不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scRecAccount: [{
            required: true, 
            message: "统驭科目不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scTradeTerms: [{
            required: true, 
            message: "贸易条件不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scShippingTerms: [{
            required: true, 
            message: "装运条件不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scBankCode: [{
            required: true, 
            message: "银行代码不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scBankName: [{
            required: true, 
            message: "银行名称不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scBankCountry: [{
            required: true, 
            message: "银行所在国不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scBankState: [{
            required: true, 
            message: "银行所在州省不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scBankCity: [{
            required: true, 
            message: "银行所在市不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scBankCounty: [{
            required: true, 
            message: "银行所在县不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scBankAddr: [{
            required: true, 
            message: "银行地址不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scBankAccount: [{
            required: true, 
            message: "银行账号不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          scAddr: [{
            required: true, 
            message: "地址不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          isFroze: [{
            required: true, 
            message: "冻结标记不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
        },
        opertype: 0,
        // 行业类别选项列表 格式 eg:{ label: '标签', value: '0'}
        scIndustryTypeOptions: [],
        // 税别选项列表 格式 eg:{ label: '标签', value: '0'}
        scTaxTypeOptions: [],
        // 银行所在州省选项列表 格式 eg:{ label: '标签', value: '0'}
        scBankStateOptions: [],
        // 州省选项列表 格式 eg:{ label: '标签', value: '0'}
        scStateOptions: [],
        // 冻结标记选项列表 格式 eg:{ label: '标签', value: '0'}
        isFrozeOptions: [],
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
        getSdClient(e.id).then(res => {
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
        scId: undefined,
        scOrg: undefined,
        scPlant: undefined,
        scIndustryType: undefined,
        scEnterpriseNature: undefined,
        scCode: undefined,
        scAbbr: undefined,
        scName: undefined,
        scEbe: undefined,
        scBusinessNo: undefined,
        scTaxNo: undefined,
        scTaxType: undefined,
        scMainBusiness: undefined,
        scCcy: undefined,
        scPayTerms: undefined,
        scPayMethod: undefined,
        scRecAccount: undefined,
        scTradeTerms: undefined,
        scShippingTerms: undefined,
        scCustomerGrade: undefined,
        scCustomerCredit: undefined,
        scFirstTransDate: undefined,
        scLastTransDate: undefined,
        scBankCode: undefined,
        scBankName: undefined,
        scBranchName: undefined,
        scBankCountry: undefined,
        scBankState: undefined,
        scBankCity: undefined,
        scBankCounty: undefined,
        scBankAddr: undefined,
        scBankAddr1: undefined,
        scBankAddr2: undefined,
        scBankAccount: undefined,
        scBankSwiftNo: undefined,
        scRegionCode: undefined,
        scState: undefined,
        scCity: undefined,
        scCounty: undefined,
        scAddr: undefined,
        scAddr1: undefined,
        scAddr2: undefined,
        scContacts: undefined,
        scEmail: undefined,
        scTelNo: undefined,
        scFaxNp: undefined,
        scPhoneNo: undefined,
        isFroze: undefined,
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
        reMark: undefined,
        isDeleted: undefined,
        createBy: undefined,
        createTime: undefined,
        updateBy: undefined,
        updateTime: undefined,
      };
    },
      submit() {
        this.$refs.uForm.validate().then(res => {
          this.$modal.msg('表单校验通过')

                    if (this.form.scId != undefined && this.opertype == 2) {
            updateSdClient(this.form).then((res) => {
                this.$modal.msgSuccess("修改成功")
            })
              .catch(() => {})
          } else {
            addSdClient(this.form).then((res) => {
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