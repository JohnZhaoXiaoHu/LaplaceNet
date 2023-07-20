import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* oph从表分页查询
* @param {查询条件} data
*/
export function listPpOutputSlave(query) {
  return request({
    url: 'production/PpOutputSlave/list',
    method: 'get',
    params: query,
  })
}

/**
* 新增oph从表
* @param data
*/
export function addPpOutputSlave(data) {
  return request({
    url: 'production/PpOutputSlave',
    method: 'post',
    data: data,
  })
}
/**
* 修改oph从表
* @param data
*/
export function updatePpOutputSlave(data) {
  return request({
    url: 'production/PpOutputSlave',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取oph从表详情
* @param {Id}
*/
export function getPpOutputSlave(id) {
  return request({
    url: 'production/PpOutputSlave/' + id,
    method: 'get'
  })
}

/**
* 删除oph从表
* @param {主键} pid
*/
export function delPpOutputSlave(pid) {
  return request({
    url: 'production/PpOutputSlave/' + pid,
    method: 'delete'
  })
}
// 清空oph从表
export function clearPpOutputSlave() {
  return request({
    url: 'production/PpOutputSlave/clean',
    method: 'delete'
  })
}
// 导出oph从表
export async function exportPpOutputSlave(query) {
  await downFile('production/PpOutputSlave/export', { ...query })
}
