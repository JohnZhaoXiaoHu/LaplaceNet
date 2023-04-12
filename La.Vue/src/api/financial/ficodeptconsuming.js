import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 部门消耗分页查询
* @param {查询条件} data
*/
export function listFicoDeptConsuming(query) {
  return request({
    url: 'Financial/FicoDeptConsuming/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增部门消耗
* @param data
*/
export function addFicoDeptConsuming(data) {
  return request({
    url: 'Financial/FicoDeptConsuming',
    method: 'post',
    data: data,
  })
}

/**
* 修改部门消耗
* @param data
*/
export function updateFicoDeptConsuming(data) {
  return request({
    url: 'Financial/FicoDeptConsuming',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取部门消耗详情
* @param {Id}
*/
export function getFicoDeptConsuming(id) {
  return request({
    url: 'Financial/FicoDeptConsuming/' + id,
    method: 'get'
  })
}

/**
* 删除部门消耗
* @param {主键} pid
*/
export function delFicoDeptConsuming(pid) {
  return request({
    url: 'Financial/FicoDeptConsuming/' + pid,
    method: 'delete'
  })
}

// 清空部门消耗
export function clearFicoDeptConsuming() {
  return request({
    url: 'Financial/FicoDeptConsuming/clean',
    method: 'delete'
  })
}

// 导出部门消耗
export async function exportFicoDeptConsuming(query) {
  await downFile('Financial/FicoDeptConsuming/export', { ...query })
}

