<template>
  <view class="container">
    <view class="search-bar">
      <u-button type="primary" size="small" shape="circle" icon="plus" v-if="checkPermi(['sd:client:add'])"
        @click="handleAdd" :customStyle="{'width': '80px', 'margin': '10px'}">新增</u-button>
      <u-search :disabled="true" placeholder="请输入要搜索的内容" @click="show=true"></u-search>
    </view>
    <u-line dashed></u-line>
    <view class="info-item" v-for="(item,index) in dataList" :key="index">

      <view class="info-line">
        <text class="label-name">ID</text>
        <text>{{item.scId}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">销售组织</text>
        <text>{{item.scOrg}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">销售工厂</text>
        <text>{{item.scPlant}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">行业类别</text>
        <dict-tag :options=" scIndustryTypeOptions" :value="item.scIndustryType" />
      </view>

      <view class="info-line">
        <text class="label-name">企业性质</text>
        <text>{{item.scEnterpriseNature}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">客户代码</text>
        <text>{{item.scCode}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">客户简称</text>
        <text>{{item.scAbbr}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">客户名称</text>
        <text>{{item.scName}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">企业法人</text>
        <text>{{item.scEbe}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">营业执照</text>
        <text>{{item.scBusinessNo}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">税号</text>
        <text>{{item.scTaxNo}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">税别</text>
        <dict-tag :options=" scTaxTypeOptions" :value="item.scTaxType" />
      </view>

      <view class="info-line">
        <text class="label-name">主营业务</text>
        <text>{{item.scMainBusiness}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">交易币种</text>
        <text>{{item.scCcy}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">付款条件</text>
        <text>{{item.scPayTerms}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">付款方式</text>
        <text>{{item.scPayMethod}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">统驭科目</text>
        <text>{{item.scRecAccount}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">贸易条件</text>
        <text>{{item.scTradeTerms}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">装运条件</text>
        <text>{{item.scShippingTerms}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">客户等级</text>
        <text>{{item.scCustomerGrade}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">客户信用</text>
        <text>{{item.scCustomerCredit}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">首次交易</text>
        <text>{{item.scFirstTransDate}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">最近交易</text>
        <text>{{item.scLastTransDate}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">银行代码</text>
        <text>{{item.scBankCode}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">银行名称</text>
        <text>{{item.scBankName}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">分行名称</text>
        <text>{{item.scBranchName}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">银行所在国</text>
        <text>{{item.scBankCountry}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">银行所在州省</text>
        <dict-tag :options=" scBankStateOptions" :value="item.scBankState" />
      </view>

      <view class="info-line">
        <text class="label-name">银行所在市</text>
        <text>{{item.scBankCity}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">银行所在县</text>
        <text>{{item.scBankCounty}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">银行地址</text>
        <text>{{item.scBankAddr}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">银行地址1</text>
        <text>{{item.scBankAddr1}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">银行地址2</text>
        <text>{{item.scBankAddr2}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">银行账号</text>
        <text>{{item.scBankAccount}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">SWIFT代码</text>
        <text>{{item.scBankSwiftNo}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">国家地区</text>
        <text>{{item.scRegionCode}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">州省</text>
        <dict-tag :options=" scStateOptions" :value="item.scState" />
      </view>

      <view class="info-line">
        <text class="label-name">市</text>
        <text>{{item.scCity}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">县</text>
        <text>{{item.scCounty}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">地址</text>
        <text>{{item.scAddr}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">地址1</text>
        <text>{{item.scAddr1}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">地址2</text>
        <text>{{item.scAddr2}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">联系人</text>
        <text>{{item.scContacts}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">电邮</text>
        <text>{{item.scEmail}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">电话</text>
        <text>{{item.scTelNo}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">传真</text>
        <text>{{item.scFaxNp}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">手机</text>
        <text>{{item.scPhoneNo}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">冻结标记</text>
        <dict-tag :options=" isFrozeOptions" :value="item.isFroze" />
      </view>

      <view class="info-line">
        <text class="label-name">说明</text>
        <text>{{item.reMark}}</text>
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
            v-if="checkPermi(['sd:client:query'])"></u-tag>
        </view>
        <view class="tag-item">
          <u-tag text="编辑" plain shape="circle" icon="edit-pen" @click="handleEdit(item)"
            v-if="checkPermi(['sd:client:edit'])"></u-tag>
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
    listSdClient,
    delSdClient,
} 
  from '@/api/sales/sdclient.js'

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
        },
        total: 0,
        show: false,
        loading: false,
        // 行业类别选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
        scIndustryTypeOptions: [],
        // 税别选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
        scTaxTypeOptions: [],
        // 银行所在州省选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
        scBankStateOptions: [],
        // 州省选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
        scStateOptions: [],
        // 冻结标记选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
        isFrozeOptions: [],
        // 软删除选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
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
        listSdClient(this.queryParams).then(res => {
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
        this.$tab.navigateTo('./edit?opertype=2&scId=' + e.id)
      },
      handleView(e) {
        this.$tab.navigateTo('./edit?opertype=3&scId=' + e.id)
      },
      handleDelete(row) {
        const Ids = row.scId;
        
        this.$modal.confirm('你确定要删除吗?').then(() => {
          return delSdClient(Ids);
        })
        .then(() => {
          this.handleQuery();
          this.$modal.msgSuccess("删除成功");
        })
        .catch(() => {});
      },
      resetQuery() {
        this.$refs.uForm.resetFields()
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