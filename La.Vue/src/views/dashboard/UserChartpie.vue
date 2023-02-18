<template>
  <div class="echart" id="applyChart" style="width:100%;height: 550px;"></div>

</template>


<script>
  import * as echarts from 'echarts'
  import { listUseAll } from '@/api/system/user'
  import useSocketStore from '@/store/modules/socket'
  export default {

    data() {
      return {
        applyChart: {},
        pieName: [],
        // 后台数据
        list: [],
        dataList: [],

      }
    },
    mounted() {
      this.initApplyCharts()
      this.initData()
    },

    //computed是vue的计算属性，是根据依赖关系进行缓存的计算，只有在它的相关依赖发生改变时才会进行更新

    methods: {
      // 初始化图表
      initApplyCharts() {
        this.applyChart = echarts.init(document.querySelector('#applyChart'))
        // 饼图
        this.applyChart.setOption({
          // 图例
          legend: {

            left: 'center',
            top: 'bottom',
            bottom: '10',
          },
          //提示条设置
          tooltip: {
            trigger: 'item',
            formatter: '{a} <br/>{b} : {c} ({d}%)'
          },
          // 设置饼图标题，位置设为顶部居中
          title: {
            text: '用户统计(User statistics)',
            subtext: '在线占比(Online percentage)',
            left: 'center'
          },
          // 设置工具箱，表格优化
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
          series: [
            {
              name: 'User',
              type: 'pie',
              radius: [20, 140],
              center: ['50%', '50%'],
              roseType: 'radius',
              label: {
                show: true,
                formatter: "{b} : {c} ({d}%)" // b代表名称，c代表对应值，d代表百分比
              },
              //radius: "50%", //饼图半径
              data: [],
              //每一个扇形的颜色
              itemStyle: {
                borderRadius: 5,
                normal: {
                  color: function (colors) {
                    let colorList = [
                      '#fc8251',
                      '#5470c6',
                      '#33FFDD',
                    ];
                    return colorList[colors.dataIndex];
                  }
                },
              }
            },

          ],
          emphasis: {
            itemStyle: {
              shadowBlur: 10,
              shadowOffsetX: 0,
              shadowColor: 'rgba(0, 0, 0, 0.5)'
            }
          }
        });
      },


      //  动态获取饼图数据 并对数据进行处理
      initData() {

        // 处理查询参数
        //let params = { ...this.queryParams };
        // 执行查询 查询工单运维表
        listUseAll().then((response) => {
          this.list = response.data.result;
          // 从后台返回的数据中(返回的数据格式[{...},{...}] ) 分离出图表展示需要的name字段
          let applyName = this.list.map(item => {
            return "TotalUsers"//返回行数
          })
          // 如果分离出来的字段存在重复的，需要计算重复字段出现的次数 ['A','B','C','A']
          let getData = applyName.reduce((obj, name) => {
            if (name in obj) {
              obj[name]++
            } else {
              obj[name] = 1
            }
            return obj //{'A':2,'B':1,'C':1}
          }, {})

          //存放形式为[{name1:value},{name2:value2}]  
          //let dataList = [];
          //计算完数组中每个元素出现的次数,得到一个对象 属性->name 属性值->value
          for (const key in getData) {
            let obj1 = { name: key, value: getData[key] }
            this.dataList.push(obj1)
            let obj2 = { name: "Online", value: useSocketStore().onlineNum }
            this.dataList.push(obj2)


          }
          this.applyChart.setOption({
            series: [{
              // 饼图的数据源
              data: this.dataList,
            }]
          });
        });
      },
    }
  }

</script>