<template>
  <div class="dashboard-editor-container home">
    <!-- 用户信息 -->
    <el-row :gutter="15">
      <el-col :md="24" :lg="12" :xl="12" class="mb10">
        <el-card shadow="hover">
          <template #header>
            <span>{{ $t('layout.myWorkbench') }}</span>
          </template>
          <div class="user-item">
            <div class="user-item-left">
              <img :src="userInfo.avatar" />
            </div>

            <div class="user-item-right overflow">
              <el-row>
                <el-col :xs="24" :md="24" class="right-title mb20 one-text-overflow">
                  {{ userInfo.welcomeMessage + ',' + userInfo.nickName + ' ,' + userInfo.welcomeContent }}
                </el-col>
                <el-col :xs="24" :sm="24" :md="24">
                  <el-row>
                    <el-col :xs="24" :lg="8" class="right-l-v">
                      <div class="right-label">{{ $t('common.nickName') }}：</div>
                      <div class="right-value">{{ userInfo.nickName }}</div>
                    </el-col>
                    <el-col :xs="24" :lg="16" class="right-l-v">
                      <div class="right-label">{{ $t('layout.identity') }}：</div>
                      <div class="right-value">
                        <span v-for="item in userInfo.roles" :key="item.roleId">
                          {{ item.roleName }}
                        </span>
                      </div>
                    </el-col>
                  </el-row>
                </el-col>
                <el-col :md="24" class="mt10">
                  <el-row>
                    <el-col :xs="24" :sm="12" :md="8" class="right-l-v">
                      <div class="right-label one-text-overflow">IP：</div>
                      <div class="right-value one-text-overflow">
                        {{ userInfo.loginIP }}
                      </div>
                    </el-col>
                    <el-col :xs="24" :sm="12" :md="16" class="right-l-v">
                      <div class="right-label one-text-overflow">{{ $t('common.time') }}：</div>
                      <div class="right-value one-text-overflow">
                        {{ currentTime }}
                      </div>
                    </el-col>
                  </el-row>
                </el-col>
                <el-col :lg="24" class="mt10">
                  <el-button size="small" icon="edit">
                    <router-link to="/user/profile">{{ $t('layout.modifyInformation') }}</router-link>
                  </el-button>
                </el-col>
              </el-row>
            </div>
          </div>
        </el-card>
      </el-col>
      <el-col :md="24" :lg="12" :xl="12" class="mb10">
        <el-card shadow="hover">
          <template #header>
            <div>
              <span>{{ $t('layout.onlineUsers') }}({{useSocketStore().onlineNum}})</span>
              <el-button class="home-card-more" text>
                <router-link to="monitor/online">{{ $t('btn.more') }}</router-link>
              </el-button>
            </div>
          </template>
          <div class="info">
            <!-- <P>{{onlineUsers}}</P> -->
            <el-scrollbar wrap-class="scrollbar-wrapper">
              <div class="info-scroll">
                <ul class="info-ul">
                  <li v-for="(v, k) in onlineUsers" :key="k" class="info-item">
                    <div class="info-item-left">{{ v.userName }}({{ v.connnectionId }})</div>
                    <div>{{ v.ipaddr }}({{ v.loginLocation }})</div>
                    <div class="info-item-right" v-text="dayjs(v.loginTime).format('YYYY-MM-DD HH:mm:ss')"></div>
                    <el-button text @click="onChat(v)" icon="bell" type="success" v-hasRole="['admin']">{{
                      $t('layout.notice') }}</el-button>
                  </li>
                </ul>
              </div>
            </el-scrollbar>
          </div>
        </el-card>
      </el-col>
    </el-row>
    <div class="gva-card-box">
      <el-card class="gva-card quick-entrance">
        <template #header>
          <div class="card-header">
            <span>快捷入口</span>
          </div>
        </template>
        <el-row :gutter="20">
          <el-col v-for="(card, key) in toolCards" :key="key" :span="4" :xs="8" class="quick-entrance-items"
            @click="toTarget(card.name)">
            <div class="quick-entrance-item">
              <div class="quick-entrance-item-icon" :style="{ backgroundColor: card.bg }">
                <el-icon>
                  <component :is="card.icon" :style="{ color: card.color }" />
                </el-icon>
              </div>
              <p>{{ card.label }}</p>
            </div>
          </el-col>
        </el-row>
      </el-card>
      <!-- <div class="quick-entrance-title"></div> -->
    </div>
    <panel-group @handleSetLineChartData="handleSetLineChartData" />

    <el-row :gutter="32">
      <el-col :xs="24" :sm="24" :lg="24">
        <div class="chart-wrapper">
          <line-chart :chart-data="lineChartData" :key="dataType" />
        </div>
      </el-col>
    </el-row>

    <el-row :gutter="32">
      <el-col :xs="24" :sm="24" :lg="8">
        <div class="chart-wrapper">
          <raddar-chart />
        </div>
      </el-col>
      <el-col :xs="24" :sm="24" :lg="8">
        <div class="chart-wrapper">
          <pie-chart />
        </div>
      </el-col>
      <el-col :xs="24" :sm="24" :lg="8">
        <div class="chart-wrapper">
          <bar-chart />
        </div>
      </el-col>
    </el-row>
    <el-row :gutter="32">
      <el-col :xs="24" :sm="24" :lg="24">
        <div class="chart-wrapper">
          <WordCloudChat :data="data.wordCloud" />
        </div>
      </el-col>
    </el-row>
  </div>
</template>

<script setup name="index">
  import PanelGroup from './dashboard/PanelGroup'
  import LineChart from './dashboard/LineChart'
  import RaddarChart from './dashboard/RaddarChart'
  import PieChart from './dashboard/PieChart'
  import BarChart from './dashboard/BarChart'
  import WordCloudChat from './dashboard/WordCloud.vue'

  import dayjs from 'dayjs'

  import useUserStore from '@/store/modules/user'
  import useSocketStore from '@/store/modules/socket'
  const toolCards = ref([
    {
      label: '用户管理',
      icon: 'monitor',
      name: 'user',
      color: '#ff9c6e',
      bg: 'rgba(255, 156, 110,.3)'
    },
    {
      label: '角色管理',
      icon: 'setting',
      name: 'authority',
      color: '#69c0ff',
      bg: 'rgba(105, 192, 255,.3)'
    },
    {
      label: '菜单管理',
      icon: 'menu',
      name: 'menu',
      color: '#b37feb',
      bg: 'rgba(179, 127, 235,.3)'
    },
    {
      label: '代码生成器',
      icon: 'cpu',
      name: 'autoCode',
      color: '#ffd666',
      bg: 'rgba(255, 214, 102,.3)'
    },
    {
      label: '表单生成器',
      icon: 'document-checked',
      name: 'formCreate',
      color: '#ff85c0',
      bg: 'rgba(255, 133, 192,.3)'
    },
    {
      label: '关于我们',
      icon: 'user',
      name: 'about',
      color: '#5cdbd3',
      bg: 'rgba(92, 219, 211,.3)'
    }
  ])
  const data = {
    newVisitis: {
      expectedData: [100, 120, 161, 134, 105, 160, 165],
      actualData: [120, 82, 91, 154, 162, 140, 145]
    },
    users: {
      expectedData: [200, 192, 120, 144, 160, 130, 140],
      actualData: [180, 160, 151, 106, 145, 150, 130]
    },
    purchases: {
      expectedData: [80, 100, 121, 104, 105, 90, 100],
      actualData: [120, 90, 100, 138, 142, 130, 130]
    },
    shoppings: {
      expectedData: [130, 140, 141, 142, 145, 150, 160],
      actualData: [120, 82, 91, 154, 162, 140, 130]
    },
    wordCloud: [
      {
        name: 'Vue3',
        value: 144
      },
      {
        name: '.net6',
        value: 928
      },
      {
        name: 'Sqlsugar',
        value: 906
      },
      {
        name: 'Redis',
        value: 825
      },
      {
        name: '代码生成',
        value: 514
      },
      {
        name: '开源免费',
        value: 486
      },
      {
        name: '代码简单',
        value: 53
      },
      {
        name: '打赏',
        value: 163
      },
      {
        name: '国际化',
        value: 163
      },
      {
        name: 'Composition api',
        value: 1163
      },
      {
        name: 'Quartz.Net',
        value: 190
      },
      {
        name: 'Element UI',
        value: 190
      }
    ]
  }
  const { proxy } = getCurrentInstance()
  const userInfo = computed(() => {
    return useUserStore().userInfo
  })
  const currentTime = computed(() => {
    return proxy.parseTime(new Date())
  })
  const onlineUsers = computed(() => {
    return useSocketStore().onlineUsers
  })

  let lineChartData = reactive([])
  const dataType = ref(null)
  function handleSetLineChartData(type) {
    dataType.value = type
    lineChartData = data[type]
  }
  handleSetLineChartData('newVisitis')
  function onOpenOnline() {
    let routeData = this.$router.resolve({
      name: "monitor/online/index",
      query: params,
      params: { catId: params.catId }
    });
    window.open(routeData.href, '_blank')
  }

  function onChat(item) {
    proxy
      .$prompt('请输入通知内容', '', {
        confirmButtonText: '发送',
        cancelButtonText: '取消',
        inputPattern: /\S/,
        inputErrorMessage: '消息内容不能为空'
      })
      .then(({ value }) => {
        proxy.signalr.SR.invoke('SendMessage', item.connnectionId, item.name, value).catch(function (err) {
          console.error(err.toString())
        })
      })
      .catch(() => { })
  }

</script>

<style lang="scss" scoped>
  .home {

    overflow: hidden;

    .home-card-more {
      float: right;
      padding: 3px 0;
      font-size: 13px;
    }

    .user-item {
      height: 198px;
      display: flex;
      align-items: center;

      .user-item-left {
        width: 60px;
        height: 60px;
        border-radius: 50%;
        overflow: hidden;

        img {
          width: 100%;
          height: 100%;
        }
      }

      .user-item-right {
        flex: 1;
        padding: 15px;

        .right-title {
          font-size: 20px;
        }

        .right-l-v {
          font-size: 13px;
          display: flex;

          .right-label {
            color: gray;
            width: 75px;
          }

          .right-value {
            flex: 1;
          }
        }
      }
    }

    .info {
      height: 189px;

      // overflow-y: scroll;
      .info-scroll {
        height: 100%;
        overflow: auto;

        .info-ul {
          list-style: none;
          padding: 0;

          .info-item {
            display: flex;
            font-size: 13px;
            color: gray;
            height: 28px;
            line-height: 28px;

            &:hover {
              color: var(--color-primary);
              cursor: pointer;
            }

            .info-item-left {
              flex: 1;
              flex-shrink: 0;
              text-overflow: ellipsis;
              white-space: nowrap;
              overflow: hidden;
            }

            .info-item-right {
              width: 140px;
              text-align: right;
              padding-right: 10px;
            }
          }
        }
      }
    }
  }

  .dashboard-editor-container {
    background-color: var(--base-bg-main);
    position: relative;

    .chart-wrapper {
      background: var(--base-bg-main);
      padding: 16px 16px 0;
      margin-bottom: 32px;
    }
  }

  @media (max-width: 1024px) {
    .chart-wrapper {
      padding: 8px;
    }
  }
</style>