<template>
  <div>
    <div ref="myChart" :class="chart" style="height:400px;width:100%" />
  </div>
</template>

<script>
  import { getArticleVisitRank } from "@/api/article";

  export default {
    name: "ArticleVisitRank",
    data() {
      return {
        chart: null,
        articleTitleList: [],
        viewList: []
      }
    },
    mounted() {
      this.getArticleVisitRank()

    },
    methods: {
      initChart() {
        this.chart = this.$echarts.init(this.$refs.myChart, 'macarons')
        this.setOptions(this.viewList, this.articleTitleList)
      },
      setOptions(viewList, articleTitleList) {
        console.log(viewList)
        console.log(articleTitleList)
        this.chart.setOption({
          title: {
            text: '文章浏览排行'
          },
          tooltip: {
            trigger: 'axis',
            axisPointer: {
              type: 'shadow'
            }
          },
          xAxis: {
            type: 'category',
            data: articleTitleList,
            axisTick: {
              alignWithLabel: true
            }
          },
          yAxis: {
            type: 'value'
          },
          series: [
            {
              data: viewList,
              type: 'bar',
              name: '数量'
            }
          ]
        })
      },
      getArticleVisitRank() {
        getArticleVisitRank().then(res => {
          this.articleTitleList = res.data.articleTitleList
          this.viewList = res.data.viewList
          console.log(this.viewList)
          console.log(this.articleTitleList)
          this.$nextTick(() => {
            this.initChart()
          })
        })
      }
    }
  }
</script>

<style scoped>

</style>