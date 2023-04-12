import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 预算实际分页查询
* @param {查询条件} data
*/
export function listFicoBudgetactualCost(query) {
  return request({
    url: 'Financial/FicoBudgetactualCost/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增预算实际
* @param data
*/
export function addFicoBudgetactualCost(data) {
  return request({
    url: 'Financial/FicoBudgetactualCost',
    method: 'post',
    data: data,
  })
}

/**
* 修改预算实际
* @param data
*/
export function updateFicoBudgetactualCost(data) {
  return request({
    url: 'Financial/FicoBudgetactualCost',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取预算实际详情
* @param {Id}
*/
export function getFicoBudgetactualCost(id) {
  return request({
    url: 'Financial/FicoBudgetactualCost/' + id,
    method: 'get'
  })
}

/**
* 删除预算实际
* @param {主键} pid
*/
export function delFicoBudgetactualCost(pid) {
  return request({
    url: 'Financial/FicoBudgetactualCost/' + pid,
    method: 'delete'
  })
}

// 清空预算实际
export function clearFicoBudgetactualCost() {
  return request({
    url: 'Financial/FicoBudgetactualCost/clean',
    method: 'delete'
  })
}

// 导出预算实际
export async function exportFicoBudgetactualCost(query) {
  await downFile('Financial/FicoBudgetactualCost/export', { ...query })
}

