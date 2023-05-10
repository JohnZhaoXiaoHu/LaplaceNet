<template>
  <div>
    <el-popover placement="bottom" trigger="hover" width="300px" popper-class="el-popover-pupop-user-news">
      <template #reference>
        <el-badge :is-dot="noticeDot" style="line-height: 18px">
          <svg-icon class-name="size-icon" name="bell" />
        </el-badge>
      </template>
      <div class="layout-navbars-breadcrumb-user-news">
        <div class="head-box">
          <div class="head-box-title">{{ $t('layout.messageList') }}</div>
          <div class="head-box-btn" v-if="noticeList.length > 0" @click="onAllReadClick">{{ $t('layout.allread') }}
          </div>
        </div>
        <div class="content-box">
          <template v-if="noticeList.length > 0">
            <div class="content-box-item" v-for="(v, k) in noticeList" :key="k">
              <div>{{ v.noticeTitle }}</div>
              <div class="content-box-msg" v-html="v.noticeContent"></div>
              <div class="content-box-time">{{ v.updateTime }}</div>
            </div>
          </template>
          <div class="content-box-empty" v-else>
            <div class="content-box-empty-margin">
              <el-icon>
                <Promotion />
              </el-icon>
              <div class="mt15">{{ $t('layout.allread') }}</div>
            </div>
          </div>
        </div>

        <div class="foot-box" @click="onGoToNoticeCenter" v-if="noticeList.length > 0">{{ $t('layout.noticenter') }}
        </div>
      </div>
    </el-popover>
  </div>
</template>

<script setup name="noticeIndex">
  import useSocketStore from '@/store/modules/socket'

  const { proxy } = getCurrentInstance()

  // 小红点
  const newsDot = ref(false)

  const noticeList = computed(() => {
    return useSocketStore().noticeList
  })
  const noticeDot = computed(() => {
    return useSocketStore().noticeDot
  })
  // 全部已读点击
  function onAllReadClick() {
    newsDot.value = false
    proxy.$modal.msg('请自行实现！！！')
  }
  // 前往通知中心点击
  function onGoToNoticeCenter() {

    //直接跳转
    proxy.$router.push('/system/notice');


    //window.open('https://gitee.com/izory/ZrAdminNetCore')
  }
</script>

<style lang="scss">
  /* //svg-icon修改颜色 */
  .svg-icon {
    height: 20px;
    width: 20px;
    fill: #484891;
    /* 宝蓝(#4b5cc4)：鲜艳明亮的蓝色 （注：英文中为 RoyalBlue 即皇家蓝色，是皇室选用的色彩，多和小面积纯黄色（金色）配合使用。） rgba(74, 74, 77, 0.65); */
  }

  .head-box {
    display: flex;
    border-bottom: 1px solid #ebeef5;
    box-sizing: border-box;
    color: #333333;
    justify-content: space-between;
    height: 35px;
    align-items: center;

    .head-box-btn {
      color: #1890ff;
      font-size: 13px;
      cursor: pointer;
      opacity: 0.8;

      &:hover {
        opacity: 1;
      }
    }
  }

  .content-box {
    font-size: 13px;

    .content-box-item {
      padding-top: 12px;

      &:last-of-type {
        padding-bottom: 12px;
      }

      .content-box-msg {
        color: #999999;
        margin-top: 5px;
        margin-bottom: 5px;
      }

      .content-box-time {
        color: #999999;
      }
    }

    .content-box-empty {
      height: 260px;
      display: flex;

      .content-box-empty-margin {
        margin: auto;
        text-align: center;

        i {
          font-size: 60px;
        }
      }
    }
  }

  .foot-box {
    height: 35px;
    color: #1890ff;
    font-size: 13px;
    cursor: pointer;
    opacity: 0.8;
    display: flex;
    align-items: center;
    justify-content: center;
    border-top: 1px solid #ebeef5;

    &:hover {
      opacity: 1;
    }
  }

  :deep(.el-empty__description p) {
    font-size: 13px;
  }

  .head-box-title {
    color: var(--base-color-white);
  }
</style>