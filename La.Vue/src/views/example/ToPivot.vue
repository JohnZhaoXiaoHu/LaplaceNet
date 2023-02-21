<template>
  <el-table :data="resultList" style="width: 100%" :header-cell-class-name="handleCellclass"
    :cell-class-name="handleCellclass">
    <el-table-column prop="title" label="" width="100">
      <template slot-scope="scope">
        <span>{{identifyResultList[scope.$index].title}}</span>
      </template>
    </el-table-column>
    <el-table-column v-for="(item,index) in tableData" :key="index" :label="'识别结果'+(index+1)"
      :width="tableDataTopWidth(index)">
      <template slot-scope="scope">
        <span>{{item[scope.row.label] || '-'}}</span>
      </template>
    </el-table-column>
  </el-table>
</template>
<script>
  export default {
    data() {
      return {
        tableData: [
          {
            batchNo: "2020102801",
            createDate: "2020-10-28 19:21:56",
            id: 5062,
            aaa: 'asdsd',
            bbb: '2432',
            ccc: 'aaaawewewqccc'
          },
          {
            batchNo: "2020102801",
            createDate: "2020-10-28 19:21:56",
            id: 5062,
            aaa: 'asdsd',
            bbb: '2432',
            ccc: 'aaaawewewqccc'
          }
        ],
        resultList: [
          { title: '批次号', label: 'batchNo' },
          { title: 'id', label: 'id' },
          { title: 'aaa', label: 'aaa' },
          { title: 'bbb', label: 'bbb' },
          { title: 'ccc', label: 'ccc' },
          { title: '时间', label: 'createDate' },
        ],
      }
    }
  }
  methods: {
    handleCellclass({ column, columnIndex }) {
      if (columnIndex !== 0 && column.label.indexOf("识别结果") !== -1) {
        return "tableColumnClass"
      } else {
        return ''
      }
    }
  }

</script>