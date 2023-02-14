import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 生产工单分页查询
* @param {查询条件} data
*/
export function listPpMfgOrder(query) {
  return request({
    url: 'production/PpMfgOrder/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增生产工单
* @param data
*/
export function addPpMfgOrder(data) {
  return request({
    url: 'production/PpMfgOrder',
    method: 'post',
    data: data,
  })
}

/**
* 修改生产工单
* @param data
*/
export function updatePpMfgOrder(data) {
  return request({
    url: 'production/PpMfgOrder',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取生产工单详情
* @param {Id}
*/
export function getPpMfgOrder(id) {
  return request({
    url: 'production/PpMfgOrder/' + id,
    method: 'get'
  })
}

/**
* 删除生产工单
* @param {主键} pid
*/
export function delPpMfgOrder(pid) {
  return request({
    url: 'production/PpMfgOrder/' + pid,
    method: 'delete'
  })
}

// 清空生产工单
export function clearPpMfgOrder() {
  return request({
    url: 'production/PpMfgOrder/clean',
    method: 'delete'
  })
}

// 导出生产工单
export async function exportPpMfgOrder(query) {
  await downFile('production/PpMfgOrder/export', { ...query })
}

