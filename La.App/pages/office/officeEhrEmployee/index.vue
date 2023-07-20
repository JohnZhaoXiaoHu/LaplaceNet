<template>
  <view class="container">
    <view class="search-bar">
      <u-button type="primary" size="small" shape="circle" icon="plus" v-if="checkPermi(['office:ehremployee:add'])"
        @click="handleAdd" :customStyle="{'width': '80px', 'margin': '10px'}">新增</u-button>
      <u-search :disabled="true" placeholder="请输入要搜索的内容" @click="show=true"></u-search>
    </view>
    <u-line dashed></u-line>
    <view class="info-item" v-for="(item,index) in dataList" :key="index">

      <view class="info-line">
        <text class="label-name">ID</text>
        <text>{{item.eeId}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">姓名</text>
        <text>{{item.eeName}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">曾用名</text>
        <text>{{item.eeNameUsed}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">昵称</text>
        <text>{{item.eeNickName}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">英文名</text>
        <text>{{item.eeEnglishName}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">性别</text>
        <dict-tag :options=" eeGenderOptions" :value="item.eeGender" />
      </view>

      <view class="info-line">
        <text class="label-name">出生日期</text>
        <text>{{item.eeBirthday}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">身份证号</text>
        <text>{{item.eeIdentityCard}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">婚姻状态</text>
        <text>{{item.eeWedlock}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">民族</text>
        <text>{{item.eeNationId}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">籍贯</text>
        <text>{{item.eeNativePlace}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">政治面貌</text>
        <text>{{item.eePoliticId}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">邮件</text>
        <text>{{item.eeEmail}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">电话</text>
        <text>{{item.eePhone}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">国家/地区</text>
        <text>{{item.eeCountry}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">省区</text>
        <text>{{item.eeProvince}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">市区</text>
        <text>{{item.eeCity}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">县区</text>
        <text>{{item.eeCounty}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">家庭住址</text>
        <text>{{item.eeHomeAddress}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">邮编</text>
        <text>{{item.eePostCode}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">户口性质</text>
        <dict-tag :options=" eeHouseholdTypeOptions" :value="item.eeHouseholdType" />
      </view>

      <view class="info-line">
        <text class="label-name">暂住地址</text>
        <text>{{item.eeStayAddress}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">部门</text>
        <text>{{item.eeDepartmentId}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">职称</text>
        <text>{{item.eeTitlesId}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">岗位</text>
        <text>{{item.eePostId}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">等级</text>
        <text>{{item.eePostLevel}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">职务</text>
        <text>{{item.eeDutyName}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">招聘来源</text>
        <text>{{item.eeRecruited}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">聘用形式</text>
        <text>{{item.eeEngageForm}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">学历</text>
        <text>{{item.eeTiptopDegrEe}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">专业</text>
        <text>{{item.eeSpecialty}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">院校</text>
        <text>{{item.eeSchool}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">工号</text>
        <text>{{item.eeWorkID}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">入职日期</text>
        <text>{{item.eeBeginDate}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">在职状态</text>
        <dict-tag :options=" eeWorkStateOptions" :value="item.eeWorkState" />
      </view>

      <view class="info-line">
        <text class="label-name">试用期</text>
        <text>{{item.eeProbation}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">合同期限</text>
        <text>{{item.eeContractTerm}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">转正日期</text>
        <text>{{item.eeConversionTime}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">离职日期</text>
        <text>{{item.eeLeaveDate}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">合同起始日</text>
        <text>{{item.eeBeginContract}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">合同终止晶</text>
        <text>{{item.eeBndContract}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">工龄</text>
        <text>{{item.eeWorkAge}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">头像</text>
        <ImagePreview :src="item.eeAvatar"></ImagePreview>
      </view>

      <view class="info-line">
        <text class="label-name">学历附件</text>
        <text>{{item.eeQualificationAffix}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">职称附件</text>
        <text>{{item.eeTitleAffix}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">Remark</text>
        <text>{{item.remark}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">CreateBy</text>
        <text>{{item.createBy}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">CreateTime</text>
        <text>{{item.createTime}}</text>
      </view>
      <view class="info-btn-wrap justify-end">
        <view class="tag-item">
          <u-tag text="详情" plain shape="circle" type="info" icon="eye" @click="handleView(item)"
            v-if="checkPermi(['office:ehremployee:query'])"></u-tag>
        </view>
        <view class="tag-item">
          <u-tag text="编辑" plain shape="circle" icon="edit-pen" @click="handleEdit(item)"
            v-if="checkPermi(['office:ehremployee:edit'])"></u-tag>
        </view>
        <view class="tag-item">
          <u-tag text="删除" class="tag-item" plain shape="circle" type="error" icon="trash"
            v-if="checkPermi(['userinfo:delete'])" @click="handleDelete(item)"></u-tag>
        </view>
      </view>
      <u-line dashed></u-line>
    </view>
    <view class="page-footer">
      <u-empty mode="list" :marginTop="140" v-if="total == 0"></u-empty>
      <uni-pagination v-else show-icon="true" :total="total" :pageSize="queryParams.pageSize"
        :current="queryParams.pageNum" @change="getData"></uni-pagination>
      <view class="text-grey padding text-center"> 共 {{ total }}条数据 </view>
    </view>

    <u-popup :show="show" mode="bottom" @close="show = false" @open="show = true">
      <view class="search-form">
        <view class="search-title">搜索</view>
        <u--form labelPosition="left" :model="queryParams" labelWidth="100px" ref="uForm">
          <u-form-item label="排序字段" prop="sort" borderBottom>
            <uni-data-select v-model="queryParams.sort" :clear="true" :localdata="sortOptions"
              format="{label}"></uni-data-select>
          </u-form-item>

          <u-form-item label="排序方式" prop="sortType" borderBottom ref="item1">
            <u-radio-group v-model="queryParams.sortType">
              <u-radio label="升序" name="asc" :customStyle="{marginRight: '20px'}"></u-radio>
              <u-radio label="倒序" name="desc"></u-radio>
            </u-radio-group>
          </u-form-item>
          <u-gap height="30"></u-gap>
    
          <u-form-item label="姓名" prop="eeName" borderBottom ref="item1">
            <u--input v-model="queryParams.eeName" border="none" placeholder="请输入姓名"></u--input>
          </u-form-item>
    
          <u-form-item label="时间查询">
            <uni-datetime-picker :border="false" v-model="dateRangeEeBirthday" type="daterange" @change="eeBirthdaySelect" />
          </u-form-item>
    
          <u-form-item label="工号" prop="eeWorkID" borderBottom ref="item1">
            <u--input v-model="queryParams.eeWorkID" border="none" placeholder="请输入工号"></u--input>
          </u-form-item>
        </u--form>

        <view class="btn-group">
          <u-button text="重置" icon="reload" :customStyle="{marginRight: '10px'}" shape="circle" type="success"
            @click="resetQuery"></u-button>
          <u-button text="搜索" icon="search" shape="circle" type="primary" @click="handleQuery"></u-button>
        </view>
      </view>
    </u-popup>
    <u-back-top :scroll-top="scrollTop" :bottom="150"></u-back-top>
  </view>
</template>

<script>
  import {
    checkPermi
  } from '@/utils/permission.js'
  import "@/static/scss/page.scss";
  import { 
    listOfficeEhrEmployee,
    delOfficeEhrEmployee,
} 
  from '@/api/office/officeehremployee.js'

  import {
    getDate
  } from '@/utils/common.js'
  export default {
    dicts: [
    ],
    data() {
      return {
        scrollTop: 0,
        dataList: [],
        queryParams: {
          pageNum: 1,
          pageSize: 20,
          sortType: 'desc',
          sort: undefined,
          eeName: undefined,
          eeBirthday: undefined,
          eeWorkID: undefined,
        },
        total: 0,
        show: false,
        loading: false,
        // 性别选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
        eeGenderOptions: [],
        //出生日期时间范围
        dateRangeEeBirthday: [],
        // 户口性质选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
        eeHouseholdTypeOptions: [],
        // 在职状态选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
        eeWorkStateOptions: [],
        // IsDeleted选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
        isDeletedOptions: [],
        sortOptions: [
        ]
      }
    },
    onLoad() {
      this.getList()
    },
    methods: {
      checkPermi,
      getList() {
      this.addDateRange(this.queryParams, this.dateRangeEeBirthday, 'EeBirthday');
        listOfficeEhrEmployee(this.queryParams).then(res => {
         if (res.code == 200) {
           this.dataList = res.data.result;
           this.total = res.data.totalNum;
           this.loading = false;
          }
        })
      },
      handleAdd() {
        this.$tab.navigateTo('./edit?opertype=1')
      },
      handleEdit(e) {
        this.$tab.navigateTo('./edit?opertype=2&eeId=' + e.id)
      },
      handleView(e) {
        this.$tab.navigateTo('./edit?opertype=3&eeId=' + e.id)
      },
      handleDelete(row) {
        const Ids = row.eeId;
        
        this.$modal.confirm('你确定要删除吗?').then(() => {
          return delOfficeEhrEmployee(Ids);
        })
        .then(() => {
          this.handleQuery();
          this.$modal.msgSuccess("删除成功");
        })
        .catch(() => {});
      },
      resetQuery() {
        this.$refs.uForm.resetFields()
        this.dateRangeEeBirthday = []
      },
      handleQuery() {
        this.queryParams.pageNum = 1;
        this.dataList = []
        uni.startPullDownRefresh();
        this.getList()
        this.show = false
      },
      getData(e) {
        this.queryParams.pageNum = e.current
        this.getList()
      },
      onPullDownRefresh() {
        uni.stopPullDownRefresh()
        this.handleQuery()
      },
      eeBirthdaySelect(e) {
        this.eeBirthday = e
      },
      onPageScroll(e) {
        this.scrollTop = e.scrollTop;
      }
    }
  }
</script>

<style lang="scss">
  .container {
    padding-bottom: 20px;
  }
</style>