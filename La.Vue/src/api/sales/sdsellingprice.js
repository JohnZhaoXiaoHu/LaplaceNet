import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 销售价格分页查询
* @param {查询条件} data
*/
export function listSdSellingprice(query) {
  return request({
    url: 'sales/SdSellingprice/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增销售价格
* @param data
*/
export function addSdSellingprice(data) {
  return request({
    url: 'sales/SdSellingprice',
    method: 'post',
    data: data,
  })
}

/**
* 修改销售价格
* @param data
*/
export function updateSdSellingprice(data) {
  return request({
    url: 'sales/SdSellingprice',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取销售价格详情
* @param {Id}
*/
export function getSdSellingprice(id) {
  return request({
    url: 'sales/SdSellingprice/' + id,
    method: 'get'
  })
}

/**
* 删除销售价格
* @param {主键} pid
*/
export function delSdSellingprice(pid) {
  return request({
    url: 'sales/SdSellingprice/' + pid,
    method: 'delete'
  })
}

// 清空销售价格
export function clearSdSellingprice() {
  return request({
    url: 'sales/SdSellingprice/clean',
    method: 'delete'
  })
}

// 导出销售价格
export async function exportSdSellingprice(query) {
  await downFile('sales/SdSellingprice/export', { ...query })
}

