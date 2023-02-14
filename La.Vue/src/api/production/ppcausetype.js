import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 原因类别分页查询
* @param {查询条件} data
*/
export function listPpCauseType(query) {
  return request({
    url: 'production/PpCauseType/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增原因类别
* @param data
*/
export function addPpCauseType(data) {
  return request({
    url: 'production/PpCauseType',
    method: 'post',
    data: data,
  })
}

/**
* 修改原因类别
* @param data
*/
export function updatePpCauseType(data) {
  return request({
    url: 'production/PpCauseType',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取原因类别详情
* @param {Id}
*/
export function getPpCauseType(id) {
  return request({
    url: 'production/PpCauseType/' + id,
    method: 'get'
  })
}

/**
* 删除原因类别
* @param {主键} pid
*/
export function delPpCauseType(pid) {
  return request({
    url: 'production/PpCauseType/' + pid,
    method: 'delete'
  })
}

// 清空原因类别
export function clearPpCauseType() {
  return request({
    url: 'production/PpCauseType/clean',
    method: 'delete'
  })
}

// 导出原因类别
export async function exportPpCauseType(query) {
  await downFile('production/PpCauseType/export', { ...query })
}

