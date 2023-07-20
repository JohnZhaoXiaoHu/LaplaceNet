<template>
  <view class="container">
    <view class="search-bar">
      <u-button type="primary" size="small" shape="circle" icon="plus" v-if="checkPermi(['inst:formula:add'])"
        @click="handleAdd" :customStyle="{'width': '80px', 'margin': '10px'}">新增</u-button>
      <u-search :disabled="true" placeholder="请输入要搜索的内容" @click="show=true"></u-search>
    </view>
    <u-line dashed></u-line>
    <view class="info-item" v-for="(item,index) in dataList" :key="index">

      <view class="info-line">
        <text class="label-name">Guid</text>
        <text>{{item.ifGuid}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">类别</text>
        <dict-tag :options=" ifTypeOptions" :value="item.ifType" />
      </view>

      <view class="info-line">
        <text class="label-name">语言</text>
        <text>{{item.ifLangKey}}</text>
      </view>

      <view class="info-line">
        <text class="label-name">公式</text>
        <text>{{item.ifFormula}}</text>
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
            v-if="checkPermi(['inst:formula:query'])"></u-tag>
        </view>
        <view class="tag-item">
          <u-tag text="编辑" plain shape="circle" icon="edit-pen" @click="handleEdit(item)"
            v-if="checkPermi(['inst:formula:edit'])"></u-tag>
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
    listInstFormula,
    delInstFormula,
} 
  from '@/api/office/instformula.js'

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
        // 类别选项列表 格式 eg:{ dictLabel: '标签', dictValue: '0'}
        ifTypeOptions: [],
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
        listInstFormula(this.queryParams).then(res => {
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
        this.$tab.navigateTo('./edit?opertype=2&ifGuid=' + e.id)
      },
      handleView(e) {
        this.$tab.navigateTo('./edit?opertype=3&ifGuid=' + e.id)
      },
      handleDelete(row) {
        const Ids = row.ifGuid;
        
        this.$modal.confirm('你确定要删除吗?').then(() => {
          return delInstFormula(Ids);
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