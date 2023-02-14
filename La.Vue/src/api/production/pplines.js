import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 生产班组分页查询
* @param {查询条件} data
*/
export function listPpLines(query) {
  return request({
    url: 'Production/PpLines/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增生产班组
* @param data
*/
export function addPpLines(data) {
  return request({
    url: 'Production/PpLines',
    method: 'post',
    data: data,
  })
}

/**
* 修改生产班组
* @param data
*/
export function updatePpLines(data) {
  return request({
    url: 'Production/PpLines',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取生产班组详情
* @param {Id}
*/
export function getPpLines(id) {
  return request({
    url: 'Production/PpLines/' + id,
    method: 'get'
  })
}

/**
* 删除生产班组
* @param {主键} pid
*/
export function delPpLines(pid) {
  return request({
    url: 'Production/PpLines/' + pid,
    method: 'delete'
  })
}

// 清空生产班组
export function clearPpLines() {
  return request({
    url: 'Production/PpLines/clean',
    method: 'delete'
  })
}

// 导出生产班组
export async function exportPpLines(query) {
  await downFile('Production/PpLines/export', { ...query })
}

