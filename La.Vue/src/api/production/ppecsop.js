import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* SOP确认分页查询
* @param {查询条件} data
*/
export function listPpEcSop(query) {
  return request({
    url: 'Production/PpEcSop/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增SOP确认
* @param data
*/
export function addPpEcSop(data) {
  return request({
    url: 'Production/PpEcSop',
    method: 'post',
    data: data,
  })
}

/**
* 修改SOP确认
* @param data
*/
export function updatePpEcSop(data) {
  return request({
    url: 'Production/PpEcSop',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取SOP确认详情
* @param {Id}
*/
export function getPpEcSop(id) {
  return request({
    url: 'Production/PpEcSop/' + id,
    method: 'get'
  })
}

/**
* 删除SOP确认
* @param {主键} pid
*/
export function delPpEcSop(pid) {
  return request({
    url: 'Production/PpEcSop/' + pid,
    method: 'delete'
  })
}

// 清空SOP确认
export function clearPpEcSop() {
  return request({
    url: 'Production/PpEcSop/clean',
    method: 'delete'
  })
}

// 导出SOP确认
export async function exportPpEcSop(query) {
  await downFile('Production/PpEcSop/export', { ...query })
}
