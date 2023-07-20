import request from '@/utils/request'

/**
* 客户信息分页查询
* @param {查询条件} data
*/
export function listSdClient(query) {
  return request({
    url: '/sales/SdClient/list',
    method: 'get',
    data: query,
  })
}

/**
* 新增客户信息
* @param data
*/
export function addSdClient(data) {
  return request({
    url: '/sales/SdClient',
    method: 'post',
    data: data,
  })
}
/**
* 修改客户信息
* @param data
*/
export function updateSdClient(data) {
  return request({
    url: '/sales/SdClient',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取客户信息详情
* @param {Id}
*/
export function getSdClient(id) {
  return request({
    url: '/sales/SdClient/' + id,
    method: 'get'
  })
}

/**
* 删除客户信息
* @param {主键} pid
*/
export function delSdClient(pid) {
  return request({
    url: '/sales/SdClient/' + pid,
    method: 'delete'
  })
}
// 清空客户信息
export function clearSdClient() {
  return request({
    url: '/sales/SdClient/clean',
    method: 'delete'
  })
}
// 导出客户信息
export async function exportSdClient(query) {
  await downFile('$/{genTable.ModuleName}/SdClient/export', { ...query })
}
