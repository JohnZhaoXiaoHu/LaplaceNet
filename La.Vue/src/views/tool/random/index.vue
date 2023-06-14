<template>
  <div>
    <el-card shadow="hover">
      <el-form label-width="100px">
        <el-row :gutter="12">
          <el-col :span="12">
            <el-form-item label="行数">
              <el-input-number v-model="rowCount" :min="0"></el-input-number>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="列数">
              <el-input-number v-model="colCount" :min="0"></el-input-number>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="大写字母">
              <el-input-number v-model="upperCaseCount" :min="0"></el-input-number>
              <el-tag class="ml-2" type="success">{{upperChar}}</el-tag>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="小写字母">
              <el-input-number v-model="lowerCaseCount" :min="0"></el-input-number>
              <el-tag class="ml-2" type="info">{{lowerChar}}</el-tag>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="数字个数">
              <el-input-number v-model="digitCount" :min="0"></el-input-number>
              <el-tag class="ml-2" type="warning">{{digitChar}}</el-tag>
            </el-form-item>
          </el-col>
          <el-col :span="12">
            <el-form-item label="特殊字符">
              <el-input-number v-model="specialCharCount" :min="0"></el-input-number>
              <el-tag class="ml-2" type="danger">{{specialChar}}</el-tag>
            </el-form-item>
          </el-col>

          <el-col :span="24">
            <el-form-item label="字符串长度">
              <el-input-number v-model="strLength" :min="0"></el-input-number>
            </el-form-item>
          </el-col>
        </el-row>
      </el-form>
    </el-card>
    <div style="display: flex;align-items: center;justify-content: center;height: 100px;">
      <el-button type="primary" @click="generateTable">生成表格</el-button>
    </div>

    <el-table :data="tableData" border highlight-current-row height="602" style="width: 100%">
      <el-table-column label="序号" type="index" width="60"></el-table-column>
      <el-table-column v-for="i in colCount" :key="i" :label="'列 ' + i" :prop="'col' + i"></el-table-column>
    </el-table>
  </div>
</template>

<script setup>
  import { ref } from 'vue';

  let tableData = ref([]);
  let rowCount = ref(5);
  let colCount = ref(5);
  let upperCaseCount = ref(2);
  let lowerCaseCount = ref(2);
  let digitCount = ref(2);
  let specialCharCount = ref(2);
  let strLength = ref(8);
  const upperChar = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
  const lowerChar = 'abcdefghijklmnopqrstuvwxyz'
  const digitChar = '0123456789'
  const specialChar = '~!@#$%^&*()_+-={}[]|\\:;"\',./<>?'
  function generateTable() {
    let newData = [];

    for (let i = 0; i < rowCount.value; i++) {
      let newRow = {
        index: i + 1,
      };

      for (let j = 1; j <= colCount.value; j++) {
        newRow['col' + j] = generateRandomString();
      }

      newData.push(newRow);
    }

    tableData.value = newData;
  }

  function generateRandomString() {
    let str = '';
    let charCount = strLength.value - digitCount.value - upperCaseCount.value - lowerCaseCount.value - specialCharCount.value;

    if (charCount < 0) {
      return '';
    }

    str += Array.from({ length: upperCaseCount.value }, () => randomUpperCase()).join('');
    str += Array.from({ length: lowerCaseCount.value }, () => randomLowerCase()).join('');
    str += Array.from({ length: digitCount.value }, () => randomDigit()).join('');
    str += Array.from({ length: specialCharCount.value }, () => randomSpecialChar()).join('');
    str += Array.from({ length: charCount }, () => randomChar()).join('');

    //return str;
    //随机排列
    let arr = str.split('');
    for (let i = arr.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [arr[i], arr[j]] = [arr[j], arr[i]];
    }
    return arr.join('');
  }

  function randomChar() {
    let chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789~!@#$%^&*()_+-={}[]|\\:;"\',./<>?';
    return chars.charAt(Math.floor(Math.random() * chars.length));
  }

  function randomUpperCase() {
    let chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    return chars.charAt(Math.floor(Math.random() * chars.length));
  }

  function randomLowerCase() {
    let chars = 'abcdefghijklmnopqrstuvwxyz';
    return chars.charAt(Math.floor(Math.random() * chars.length));
  }

  function randomDigit() {
    let chars = '0123456789';
    return chars.charAt(Math.floor(Math.random() * chars.length));
  }

  function randomSpecialChar() {
    let chars = '~!@#$%^&*()_+-={}[]|\\:;"\',./<>?';
    return chars.charAt(Math.floor(Math.random() * chars.length));
  }
</script>