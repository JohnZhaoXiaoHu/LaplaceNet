import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 从源设变分页查询
* @param {查询条件} data
*/
export function listPpEcSlvSource(query) {
  return request({
    url: 'Production/PpEcSlvSource/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增从源设变
* @param data
*/
export function addPpEcSlvSource(data) {
  return request({
    url: 'Production/PpEcSlvSource',
    method: 'post',
    data: data,
  })
}

/**
* 修改从源设变
* @param data
*/
export function updatePpEcSlvSource(data) {
  return request({
    url: 'Production/PpEcSlvSource',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取从源设变详情
* @param {Id}
*/
export function getPpEcSlvSource(id) {
  return request({
    url: 'Production/PpEcSlvSource/' + id,
    method: 'get'
  })
}

/**
* 删除从源设变
* @param {主键} pid
*/
export function delPpEcSlvSource(pid) {
  return request({
    url: 'Production/PpEcSlvSource/' + pid,
    method: 'delete'
  })
}

// 清空从源设变
export function clearPpEcSlvSource() {
  return request({
    url: 'Production/PpEcSlvSource/clean',
    method: 'delete'
  })
}

// 导出从源设变
export async function exportPpEcSlvSource(query) {
  await downFile('Production/PpEcSlvSource/export', { ...query })
}

