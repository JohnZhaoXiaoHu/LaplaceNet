import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 销售凭证分页查询
* @param {查询条件} data
*/
export function listSdSalesProof(query) {
  return request({
    url: 'sales/SdSalesProof/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增销售凭证
* @param data
*/
export function addSdSalesProof(data) {
  return request({
    url: 'sales/SdSalesProof',
    method: 'post',
    data: data,
  })
}

/**
* 修改销售凭证
* @param data
*/
export function updateSdSalesProof(data) {
  return request({
    url: 'sales/SdSalesProof',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取销售凭证详情
* @param {Id}
*/
export function getSdSalesProof(id) {
  return request({
    url: 'sales/SdSalesProof/' + id,
    method: 'get'
  })
}

/**
* 删除销售凭证
* @param {主键} pid
*/
export function delSdSalesProof(pid) {
  return request({
    url: 'sales/SdSalesProof/' + pid,
    method: 'delete'
  })
}

// 清空销售凭证
export function clearSdSalesProof() {
  return request({
    url: 'sales/SdSalesProof/clean',
    method: 'delete'
  })
}

// 导出销售凭证
export async function exportSdSalesProof(query) {
  await downFile('sales/SdSalesProof/export', { ...query })
}

