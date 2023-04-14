import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 主源设变分页查询
* @param {查询条件} data
*/
export function listPpEcMaSource(query) {
  return request({
    url: 'Production/PpEcMaSource/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增主源设变
* @param data
*/
export function addPpEcMaSource(data) {
  return request({
    url: 'Production/PpEcMaSource',
    method: 'post',
    data: data,
  })
}

/**
* 修改主源设变
* @param data
*/
export function updatePpEcMaSource(data) {
  return request({
    url: 'Production/PpEcMaSource',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取主源设变详情
* @param {Id}
*/
export function getPpEcMaSource(id) {
  return request({
    url: 'Production/PpEcMaSource/' + id,
    method: 'get'
  })
}

/**
* 删除主源设变
* @param {主键} pid
*/
export function delPpEcMaSource(pid) {
  return request({
    url: 'Production/PpEcMaSource/' + pid,
    method: 'delete'
  })
}

// 清空主源设变
export function clearPpEcMaSource() {
  return request({
    url: 'Production/PpEcMaSource/clean',
    method: 'delete'
  })
}

// 导出主源设变
export async function exportPpEcMaSource(query) {
  await downFile('Production/PpEcMaSource/export', { ...query })
}

