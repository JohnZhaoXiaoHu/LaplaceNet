<template>
  <el-table :data="details" style="width: 100%">
    <el-table-column prop="productId" label="产品编号"></el-table-column>
    <el-table-column prop="productName" label="产品名称"></el-table-column>
    <el-table-column prop="price" label="单价"></el-table-column>
    <el-table-column prop="quantity" label="数量"></el-table-column>
    <el-table-column prop="subtotal" label="小计"></el-table-column>
  </el-table>
</template>

<script setup>
  import { ref } from 'vue'

  const orderId = ref('001')
  const details = [
    {
      orderId: '001',
      productId: '001-001',
      productName: '商品1',
      price: 100,
      quantity: 5,
      subtotal: 500
    },
    {
      orderId: '001',
      productId: '001-002',
      productName: '商品2',
      price: 200,
      quantity: 3,
      subtotal: 600
    },
    {
      orderId: '002',
      productId: '002-001',
      productName: '商品3',
      price: 300,
      quantity: 4,
      subtotal: 1200
    }
  ]

  const filteredDetails = ref(details.filter(item => item.orderId === orderId.value))
</script>