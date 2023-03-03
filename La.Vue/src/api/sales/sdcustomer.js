import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 顾客信息分页查询
* @param {查询条件} data
*/
export function listSdCustomer(query) {
  return request({
    url: 'sales/SdCustomer/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增顾客信息
* @param data
*/
export function addSdCustomer(data) {
  return request({
    url: 'sales/SdCustomer',
    method: 'post',
    data: data,
  })
}

/**
* 修改顾客信息
* @param data
*/
export function updateSdCustomer(data) {
  return request({
    url: 'sales/SdCustomer',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取顾客信息详情
* @param {Id}
*/
export function getSdCustomer(id) {
  return request({
    url: 'sales/SdCustomer/' + id,
    method: 'get'
  })
}

/**
* 删除顾客信息
* @param {主键} pid
*/
export function delSdCustomer(pid) {
  return request({
    url: 'sales/SdCustomer/' + pid,
    method: 'delete'
  })
}

// 清空顾客信息
export function clearSdCustomer() {
  return request({
    url: 'sales/SdCustomer/clean',
    method: 'delete'
  })
}

// 导出顾客信息
export async function exportSdCustomer(query) {
  await downFile('sales/SdCustomer/export', { ...query })
}

