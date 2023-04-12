import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 月度存货分页查询
* @param {查询条件} data
*/
export function listFicoMonthInventory(query) {
  return request({
    url: 'Financial/FicoMonthInventory/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增月度存货
* @param data
*/
export function addFicoMonthInventory(data) {
  return request({
    url: 'Financial/FicoMonthInventory',
    method: 'post',
    data: data,
  })
}

/**
* 修改月度存货
* @param data
*/
export function updateFicoMonthInventory(data) {
  return request({
    url: 'Financial/FicoMonthInventory',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取月度存货详情
* @param {Id}
*/
export function getFicoMonthInventory(id) {
  return request({
    url: 'Financial/FicoMonthInventory/' + id,
    method: 'get'
  })
}

/**
* 删除月度存货
* @param {主键} pid
*/
export function delFicoMonthInventory(pid) {
  return request({
    url: 'Financial/FicoMonthInventory/' + pid,
    method: 'delete'
  })
}

// 清空月度存货
export function clearFicoMonthInventory() {
  return request({
    url: 'Financial/FicoMonthInventory/clean',
    method: 'delete'
  })
}

// 导出月度存货
export async function exportFicoMonthInventory(query) {
  await downFile('Financial/FicoMonthInventory/export', { ...query })
}

