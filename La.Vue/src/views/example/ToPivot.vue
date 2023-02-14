<template>
  <div class="warp">
    <el-card>
      <el-table :data="tableDataFirst" style="width: 100%" border>
        <el-table-column prop="brand" label="姓名" align="center"> </el-table-column>
        <el-table-column prop="weights" label="指标" align="center"> </el-table-column>
        <el-table-column :label="item" :prop="item" align="center" v-for="(item, i) in cloumnDataFirst" :key="i">
        </el-table-column>
      </el-table>

      <div style="margin: 20px 0; width: 100%; height: 10px; background: skyblue"></div>

      <el-table :data="tableDataSecond" style="width: 100%" border :span-method="tableSpanMethod">
        <el-table-column prop="brand" label="姓名" align="center"> </el-table-column>
        <el-table-column prop="names" label="指标" align="center"> </el-table-column>
        <el-table-column :label="item" :prop="item" align="center" v-for="(item, i) in cloumnDataFirst" :key="i">
        </el-table-column>
      </el-table>
    </el-card>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        tableDataFirst: [],
        tableDataSecond: [],
        cloumnDataFirst: [],
        cloumnDataSecond: [],
        result: {
          张三: [
            {
              age: "30岁",
              height: "110",
              weight: "82kg",
              beautify: "高",
            },
            {
              age: "21岁",
              height: "114",
              weight: "86kg",
              beautify: "美",
            },
            {
              age: "22岁",
              height: "121",
              weight: "83kg",
              beautify: "重",
            },
            {
              age: "23岁",
              height: "125",
              weight: "84kg",
              beautify: "帅",
            },
          ],
          李四: [
            {
              age: "30岁",
              height: "120",
              weight: "80kg",
              beautify: "美",
            },
            {
              age: "21岁",
              height: "123",
              weight: "81kg",
              beautify: "高",
            },
            {
              age: "22岁",
              height: "126",
              weight: "79kg",
              beautify: "重",
            },
            {
              age: "23岁",
              height: "130",
              weight: "84kg",
              beautify: "靓",
            },
            {
              age: "14岁",
              height: "125",
              weight: "83kg",
              beautify: "美",
            },
          ],
          王五: [
            {
              age: "30岁",
              height: "130",
              weight: "79kg",
              beautify: "帅",
            },
            {
              age: "21岁",
              height: "136",
              weight: "82kg",
              beautify: "好",
            },
            {
              age: "22岁",
              height: "138",
              weight: "83kg",
              beautify: "聪",
            },
            {
              age: "23岁",
              height: "142",
              weight: "87kg",
              beautify: "美",
            },
          ],
          赵六: [
            {
              age: "30岁",
              height: "140",
              weight: "76kg",
              beautify: "瘦",
            },
            {
              age: "21岁",
              height: "142",
              weight: "86kg",
              beautify: "胖",
            },
            {
              age: "22岁",
              height: "146",
              weight: "85kg",
              beautify: "瘦",
            },
            {
              age: "23岁",
              height: "152",
              weight: "89kg",
              beautify: "高",
            },
          ],
        },
      };
    },
    mounted() {
      this.initFirst();
      this.initSecond();
    },
    methods: {
      tableSpanMethod({ row, columnIndex }) {
        if (columnIndex == 0) {
          const tempRow = row.spans || 0;
          return { rowspan: tempRow, colspan: tempRow > 0 ? 1 : 0 };
        }
        return { rowspan: 1, colspan: 1 };
      },
      initFirst() {
        let temp = {},
          heightList = {},
          list = [],
          result = this.result;

        for (let key in result) {
          temp = { brand: key, weights: "体重" }; // weights 表示指标这一列都是体重文字
          result[key].forEach((item) => {
            temp[item.age] = item.weight;
            if (!this.cloumnDataFirst.includes(item.age)) {
              this.cloumnDataFirst.push(item.age);
            }
          });
          list.push(temp);
        }
        this.cloumnDataFirst = this.cloumnDataFirst.sort();
        this.tableDataFirst = list;
      },

      initSecond() {
        let temp = {},
          temp1 = {},
          temp2 = {},
          list = [],
          result = this.result;

        for (let key in result) {
          // spans是只体重这个单元要占用2行
          // temp1 temp2 表示 属性 weight height

          temp = { brand: key };
          temp1 = { ...temp, names: "体重", spans: 2 };
          temp2 = { ...temp, names: "身高" };

          // result[key] 表示数组
          result[key].forEach((item) => {
            // item每一项属性
            temp1[item.age] = item.weight;
            temp2[item.age] = item.height;

            if (!this.cloumnDataSecond.includes(item.age)) {
              // 把 age属性push进去数组里
              this.cloumnDataSecond.push(item.age);
            }
          });
          list.push(temp1, temp2);
        }
        console.log("list", list);
        this.tableDataSecond = this.tableDataSecond.sort();
        this.tableDataSecond = list;
      },
    },
  };
</script>

<style lang="scss" scoped>
  .warp {
    padding-top: 20px;
  }
</style>