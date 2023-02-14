import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 标准工时分页查询
* @param {查询条件} data
*/
export function listPpManhours(query) {
  return request({
    url: 'production/PpManhours/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增标准工时
* @param data
*/
export function addPpManhours(data) {
  return request({
    url: 'production/PpManhours',
    method: 'post',
    data: data,
  })
}

/**
* 修改标准工时
* @param data
*/
export function updatePpManhours(data) {
  return request({
    url: 'production/PpManhours',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取标准工时详情
* @param {Id}
*/
export function getPpManhours(id) {
  return request({
    url: 'production/PpManhours/' + id,
    method: 'get'
  })
}

/**
* 删除标准工时
* @param {主键} pid
*/
export function delPpManhours(pid) {
  return request({
    url: 'production/PpManhours/' + pid,
    method: 'delete'
  })
}

// 清空标准工时
export function clearPpManhours() {
  return request({
    url: 'production/PpManhours/clean',
    method: 'delete'
  })
}

// 导出标准工时
export async function exportPpManhours(query) {
  await downFile('production/PpManhours/export', { ...query })
}

