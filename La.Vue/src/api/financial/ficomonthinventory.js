import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 月度存货明细分页查询
* @param {查询条件} data
*/
export function listFicoMonthInventory(query) {
  return request({
    url: 'financial/FicoMonthInventory/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增月度存货明细
* @param data
*/
export function addFicoMonthInventory(data) {
  return request({
    url: 'financial/FicoMonthInventory',
    method: 'post',
    data: data,
  })
}

/**
* 修改月度存货明细
* @param data
*/
export function updateFicoMonthInventory(data) {
  return request({
    url: 'financial/FicoMonthInventory',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取月度存货明细详情
* @param {Id}
*/
export function getFicoMonthInventory(id) {
  return request({
    url: 'financial/FicoMonthInventory/' + id,
    method: 'get'
  })
}

/**
* 删除月度存货明细
* @param {主键} pid
*/
export function delFicoMonthInventory(pid) {
  return request({
    url: 'financial/FicoMonthInventory/' + pid,
    method: 'delete'
  })
}

// 清空月度存货明细
export function clearFicoMonthInventory() {
  return request({
    url: 'financial/FicoMonthInventory/clean',
    method: 'delete'
  })
}

// 导出月度存货明细
export async function exportFicoMonthInventory(query) {
  await downFile('financial/FicoMonthInventory/export', { ...query })
}

