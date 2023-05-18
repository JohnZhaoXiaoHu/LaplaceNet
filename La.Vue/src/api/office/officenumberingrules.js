import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 单据编码分页查询
* @param {查询条件} data
*/
export function listOfficeNumberingRules(query) {
  return request({
    url: 'Office/OfficeNumberingRules/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增单据编码
* @param data
*/
export function addOfficeNumberingRules(data) {
  return request({
    url: 'Office/OfficeNumberingRules',
    method: 'post',
    data: data,
  })
}

/**
* 修改单据编码
* @param data
*/
export function updateOfficeNumberingRules(data) {
  return request({
    url: 'Office/OfficeNumberingRules',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取单据编码详情
* @param {Id}
*/
export function getOfficeNumberingRules(id) {
  return request({
    url: 'Office/OfficeNumberingRules/' + id,
    method: 'get'
  })
}

/**
* 删除单据编码
* @param {主键} pid
*/
export function delOfficeNumberingRules(pid) {
  return request({
    url: 'Office/OfficeNumberingRules/' + pid,
    method: 'delete'
  })
}

// 清空单据编码
export function clearOfficeNumberingRules() {
  return request({
    url: 'Office/OfficeNumberingRules/clean',
    method: 'delete'
  })
}

// 导出单据编码
export async function exportOfficeNumberingRules(query) {
  await downFile('Office/OfficeNumberingRules/export', { ...query })
}

