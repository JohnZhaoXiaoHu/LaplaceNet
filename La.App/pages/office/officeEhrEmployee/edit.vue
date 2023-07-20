<template>
  <view class="edit-form">
    <u--form labelPosition="left" :model="form" labelWidth="90px" :rules="rules" ref="uForm">

            <u-form-item label="ID" prop="eeId">
              <u--input type="number" v-model.number="form.eeId" placeholder="请输入ID" :disabled="opertype != 1"></u--input>
            </u-form-item>

            <u-form-item label="姓名" prop="eeName">
              <u--input v-model="form.eeName" placeholder="请输入姓名" />
            </u-form-item>

            <u-form-item label="曾用名" prop="eeNameUsed">
              <u--input v-model="form.eeNameUsed" placeholder="请输入曾用名" />
            </u-form-item>

            <u-form-item label="昵称" prop="eeNickName">
              <u--input v-model="form.eeNickName" placeholder="请输入昵称" />
            </u-form-item>

            <u-form-item label="英文名" prop="eeEnglishName">
              <u--input v-model="form.eeEnglishName" placeholder="请输入英文名" />
            </u-form-item>

            <u-form-item label="性别" prop="eeGender">
              <uni-data-select v-model="form.eeGender" :clear="true" :localdata="eeGenderOptions"
              format="{label} - {value}"></uni-data-select>
            </u-form-item>

      <u-form-item label="出生日期" prop="eeBirthday">
              <uni-datetime-picker v-model="form.eeBirthday" />
      </u-form-item>

            <u-form-item label="身份证号" prop="eeIdentityCard">
              <u--input v-model="form.eeIdentityCard" placeholder="请输入身份证号" />
            </u-form-item>

            <u-form-item label="婚姻状态" prop="eeWedlock">
              <u--input v-model="form.eeWedlock" placeholder="请输入婚姻状态" />
            </u-form-item>

            <u-form-item label="民族" prop="eeNationId">
              <u--input v-model="form.eeNationId" placeholder="请输入民族" />
            </u-form-item>

            <u-form-item label="籍贯" prop="eeNativePlace">
              <u--input v-model="form.eeNativePlace" placeholder="请输入籍贯" />
            </u-form-item>

            <u-form-item label="政治面貌" prop="eePoliticId">
              <u--input v-model="form.eePoliticId" placeholder="请输入政治面貌" />
            </u-form-item>

            <u-form-item label="邮件" prop="eeEmail">
              <u--input v-model="form.eeEmail" placeholder="请输入邮件" />
            </u-form-item>

            <u-form-item label="电话" prop="eePhone">
              <u--input v-model="form.eePhone" placeholder="请输入电话" />
            </u-form-item>

            <u-form-item label="国家/地区" prop="eeCountry">
              <u--input v-model="form.eeCountry" placeholder="请输入国家/地区" />
            </u-form-item>

            <u-form-item label="省区" prop="eeProvince">
              <u--input v-model="form.eeProvince" placeholder="请输入省区" />
            </u-form-item>

            <u-form-item label="市区" prop="eeCity">
              <u--input v-model="form.eeCity" placeholder="请输入市区" />
            </u-form-item>

            <u-form-item label="县区" prop="eeCounty">
              <u--input v-model="form.eeCounty" placeholder="请输入县区" />
            </u-form-item>

            <u-form-item label="家庭住址" prop="eeHomeAddress">
              <u--input v-model="form.eeHomeAddress" placeholder="请输入家庭住址" />
            </u-form-item>

            <u-form-item label="邮编" prop="eePostCode">
              <u--input v-model="form.eePostCode" placeholder="请输入邮编" />
            </u-form-item>

            <u-form-item label="户口性质" prop="eeHouseholdType">
              <uni-data-select v-model="form.eeHouseholdType" :clear="true" :localdata="eeHouseholdTypeOptions"
              format="{label} - {value}"></uni-data-select>
            </u-form-item>

            <u-form-item label="暂住地址" prop="eeStayAddress">
              <u--input v-model="form.eeStayAddress" placeholder="请输入暂住地址" />
            </u-form-item>
        
            <u-form-item label="部门" prop="eeDepartmentId">
              <u--input v-model.number="form.eeDepartmentId" placeholder="请输入部门" />
            </u-form-item>
        
            <u-form-item label="职称" prop="eeTitlesId">
              <u--input v-model.number="form.eeTitlesId" placeholder="请输入职称" />
            </u-form-item>
        
            <u-form-item label="岗位" prop="eePostId">
              <u--input v-model.number="form.eePostId" placeholder="请输入岗位" />
            </u-form-item>
        
            <u-form-item label="等级" prop="eePostLevel">
              <u--input v-model.number="form.eePostLevel" placeholder="请输入等级" />
            </u-form-item>
        
            <u-form-item label="职务" prop="eeDutyName">
              <u--input v-model.number="form.eeDutyName" placeholder="请输入职务" />
            </u-form-item>
        
            <u-form-item label="招聘来源" prop="eeRecruited">
              <u--input v-model.number="form.eeRecruited" placeholder="请输入招聘来源" />
            </u-form-item>

            <u-form-item label="聘用形式" prop="eeEngageForm">
              <u--input v-model="form.eeEngageForm" placeholder="请输入聘用形式" />
            </u-form-item>
        
            <u-form-item label="学历" prop="eeTiptopDegrEe">
              <u--input v-model.number="form.eeTiptopDegrEe" placeholder="请输入学历" />
            </u-form-item>
        
            <u-form-item label="专业" prop="eeSpecialty">
              <u--input v-model.number="form.eeSpecialty" placeholder="请输入专业" />
            </u-form-item>

            <u-form-item label="院校" prop="eeSchool">
              <u--input v-model="form.eeSchool" placeholder="请输入院校" />
            </u-form-item>

            <u-form-item label="工号" prop="eeWorkID">
              <u--input v-model="form.eeWorkID" placeholder="请输入工号" />
            </u-form-item>

      <u-form-item label="入职日期" prop="eeBeginDate">
              <uni-datetime-picker v-model="form.eeBeginDate" />
      </u-form-item>

      <u-form-item label="在职状态" prop="eeWorkState">
            <u-radio-group v-model="form.eeWorkState">
              <u-radio v-for="item in eeWorkStateOptions" :name="item.value" class="margin-right-xl">{{item.label}}</u-radio>
            </u-radio-group>
      </u-form-item>

            <u-form-item label="试用期" prop="eeProbation">
              <u--input v-model="form.eeProbation" placeholder="请输入试用期" />
            </u-form-item>

            <u-form-item label="合同期限" prop="eeContractTerm">
              <u--input v-model="form.eeContractTerm" placeholder="请输入合同期限" />
            </u-form-item>

      <u-form-item label="转正日期" prop="eeConversionTime">
              <uni-datetime-picker v-model="form.eeConversionTime" />
      </u-form-item>

      <u-form-item label="离职日期" prop="eeLeaveDate">
              <uni-datetime-picker v-model="form.eeLeaveDate" />
      </u-form-item>

      <u-form-item label="合同起始日" prop="eeBeginContract">
              <uni-datetime-picker v-model="form.eeBeginContract" />
      </u-form-item>

      <u-form-item label="合同终止晶" prop="eeBndContract">
              <uni-datetime-picker v-model="form.eeBndContract" />
      </u-form-item>
        
            <u-form-item label="工龄" prop="eeWorkAge">
              <u--input v-model.number="form.eeWorkAge" placeholder="请输入工龄" />
            </u-form-item>

      <u-form-item label="头像" prop="eeAvatar">
        <UploadFile v-model="form.eeAvatar"></UploadFile>
      </u-form-item>

            <u-form-item label="学历附件" prop="eeQualificationAffix">
              <u--input v-model="form.eeQualificationAffix" placeholder="请输入学历附件" />
            </u-form-item>

            <u-form-item label="职称附件" prop="eeTitleAffix">
              <u--input v-model="form.eeTitleAffix" placeholder="请输入职称附件" />
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

      <u-form-item label="IsDeleted" prop="isDeleted">
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
    getOfficeEhrEmployee,
 
    addOfficeEhrEmployee,
 
    updateOfficeEhrEmployee,
}
from '@/api/office/officeehremployee.js'

  export default {
    dicts: [
    ],
    data() {
      return {
        form: {},
        rules: {
          xxx: {},
          eeId: [{
            required: true, 
            message: "ID不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeName: [{
            required: true, 
            message: "姓名不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeGender: [{
            required: true, 
            message: "性别不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeBirthday: [{
            required: true, 
            message: "出生日期不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeIdentityCard: [{
            required: true, 
            message: "身份证号不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeWedlock: [{
            required: true, 
            message: "婚姻状态不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeNationId: [{
            required: true, 
            message: "民族不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeNativePlace: [{
            required: true, 
            message: "籍贯不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eePoliticId: [{
            required: true, 
            message: "政治面貌不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeCountry: [{
            required: true, 
            message: "国家/地区不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeProvince: [{
            required: true, 
            message: "省区不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeCity: [{
            required: true, 
            message: "市区不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeCounty: [{
            required: true, 
            message: "县区不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeHomeAddress: [{
            required: true, 
            message: "家庭住址不能为空", 
            trigger: [ 'change', 'blur' ],
 
          }],
          eeDepartmentId: [{
            required: true, 
            message: "部门不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
          eeTitlesId: [{
            required: true, 
            message: "职称不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
          eePostId: [{
            required: true, 
            message: "岗位不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
          eePostLevel: [{
            required: true, 
            message: "等级不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
          eeDutyName: [{
            required: true, 
            message: "职务不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
          eeRecruited: [{
            required: true, 
            message: "招聘来源不能为空", 
            trigger: [ 'change', 'blur' ],
            type: "number" 
          }],
        },
        opertype: 0,
        // 性别选项列表 格式 eg:{ label: '标签', value: '0'}
        eeGenderOptions: [],
        // 户口性质选项列表 格式 eg:{ label: '标签', value: '0'}
        eeHouseholdTypeOptions: [],
        // 在职状态选项列表 格式 eg:{ label: '标签', value: '0'}
        eeWorkStateOptions: [],
        // IsDeleted选项列表 格式 eg:{ label: '标签', value: '0'}
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
        getOfficeEhrEmployee(e.id).then(res => {
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
        eeId: undefined,
        eeName: undefined,
        eeNameUsed: undefined,
        eeNickName: undefined,
        eeEnglishName: undefined,
        eeGender: undefined,
        eeBirthday: undefined,
        eeIdentityCard: undefined,
        eeWedlock: undefined,
        eeNationId: undefined,
        eeNativePlace: undefined,
        eePoliticId: undefined,
        eeEmail: undefined,
        eePhone: undefined,
        eeCountry: undefined,
        eeProvince: undefined,
        eeCity: undefined,
        eeCounty: undefined,
        eeHomeAddress: undefined,
        eePostCode: undefined,
        eeHouseholdType: undefined,
        eeStayAddress: undefined,
        eeDepartmentId: undefined,
        eeTitlesId: undefined,
        eePostId: undefined,
        eePostLevel: undefined,
        eeDutyName: undefined,
        eeRecruited: undefined,
        eeEngageForm: undefined,
        eeTiptopDegrEe: undefined,
        eeSpecialty: undefined,
        eeSchool: undefined,
        eeWorkID: undefined,
        eeBeginDate: undefined,
        eeWorkState: undefined,
        eeProbation: undefined,
        eeContractTerm: undefined,
        eeConversionTime: undefined,
        eeLeaveDate: undefined,
        eeBeginContract: undefined,
        eeBndContract: undefined,
        eeWorkAge: undefined,
        eeAvatar: undefined,
        eeQualificationAffix: undefined,
        eeTitleAffix: undefined,
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

                    if (this.form.eeId != undefined && this.opertype == 2) {
            updateOfficeEhrEmployee(this.form).then((res) => {
                this.$modal.msgSuccess("修改成功")
            })
              .catch(() => {})
          } else {
            addOfficeEhrEmployee(this.form).then((res) => {
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