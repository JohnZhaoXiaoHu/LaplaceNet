<template>
  <div class="app-container">
  </div>
  <div>
    <el-table :data="userData" border stripe height="150" style="width: 100%" :cell-style="cellStyle">
      <el-table-column prop="name1"></el-table-column>
      <el-table-column prop="value1">
      </el-table-column>
      <el-table-column prop="name2"></el-table-column>
      <el-table-column prop="value2">
      </el-table-column>
    </el-table>
  </div>
  <div ref="chartRef" :class="className" :style="{ height: height, width: width }" />
</template>
<script setup>

  import * as echarts from 'echarts'
  import { listUser } from '@/api/system/user'
  import useSocketStore from '@/store/modules/socket'
  //computed是vue的计算属性，是根据依赖关系进行缓存的计算，只有在它的相关依赖发生改变时才会进行更新
  const onlineUsers = computed(() => {
    return useSocketStore().onlineNum
  })
  const { proxy } = getCurrentInstance()

  //总行数
  const totalUsers = ref(30)
  const userData = [
    {
      name1: proxy.$t('layout.resisterUsers'),
      value1: totalUsers,

      name2: proxy.$t('layout.onlineUsers'),
      value2: onlineUsers,
    }]
  // 数据集合 reactive数据被重新赋值后无法双向绑定


  const userPie = reactive([
    {
      value: totalUsers,
      name: 'total',
    },
    {
      value: onlineUsers,
      name: 'online',

    }])



  /** 查询用户列表 */


  let chart = null
  const animationDuration = 6000
  const props = defineProps({
    className: {
      type: String,
      default: 'chart',
    },
    width: {
      type: String,
      default: '100%',
    },
    height: {
      type: String,
      default: '300px',
    },
  })

  function initChart() {
    //this.option.series[0].data = this.userPie;
    chart = echarts.init(proxy.$refs.chartRef)
    chart.setOption({
      title: {
        text: '用户图表',
        subtext: '在线统计',
        left: 'center'
      },
      tooltip: {
        trigger: 'item',
        formatter: '{a} <br/>{b} : {c} ({d}%)',
      },
      toolbox: {
        show: true,
        feature: {
          mark: { show: true },
          //数据视图
          dataView: {
            show: true,
            //只读设置
            readOnly: true,
            //lang: ['数据视图', '关闭', '刷新'],
            //小图标的文本提示，配合showTitle使用
            title: "数据视图",
            optionToContent: function (opt) {
              var otc = 'graph.html?formData=yuYueData&title=预约日报表';
              return otc;
            },
            //html格式转化
            optionToContent: function (opt) {
              var series = opt.series;
              var table = '<table border="1" style="width:50%;user-select:text;text-align:center;border-collapse:collapse;"><thead style="font-weight:bold;">'
                + '<tr>';
              for (var i = 0, l = series.length; i < l; i++) {
                table += '<td>' + series[i].name + '-Type</td><td>Qty</td>';
              }
              table += '</tr></thead><tbody>';
              for (var i = 0, l = series.length; i < l; i++) {
                console.log(series[i].data);
                for (var j = 0; j < series[i].data.length; j++) {
                  table += '<tr><td>' + series[i].data[j].name + '</td>'
                    + '<td>' + series[i].data[j].value + '</td></tr>';
                }
                table += '</tr>';
              }
              table += '</tbody></table>';
              return table;
            },

          },
          restore: { show: true },
          saveAsImage: { show: true, }
        }
      },
      legend: {
        left: 'center',
        top: 'bottom',
        bottom: '10',
        data: userPie,
      },
      color: ['#00a0ff', '#ff6020'],
      series: [
        {
          name: 'User',
          type: 'pie',
          roseType: 'area',
          radius: [20, 100],
          center: ['50%', '50%'],
          data: userPie,
          label: {
            alignTo: 'edge',
            formatter: '{name|{b}}\n{用户|{c} }',
            minMargin: 5,
            edgeDistance: 10,
            lineHeight: 15,
            rich: {
              用户: {
                fontSize: 10,
                color: '#999'
              }
            }
          },
          labelLine: {
            length: 15,
            length2: 0,
            maxSurfaceAngle: 80
          },
          labelLayout: function (params) {
            const isLeft = params.labelRect.x < chart.getWidth() / 2;
            const points = params.labelLinePoints;
            // Update the end point.
            points[2][0] = isLeft
              ? params.labelRect.x
              : params.labelRect.x + params.labelRect.width;
            return {
              labelLinePoints: points
            };
          },
          left: '33.3333%',
          right: '33.3333%',
          top: '33.3333%',
          bottom: '33.3333%',
          animationEasing: 'cubicInOut',
          animationDuration: 2600,
          itemStyle: {
            borderRadius: 8
          },
        },
      ],
    })
  }


  //组件挂载完成后执行
  onMounted(() => {


    initChart()
  })


</script>