import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 工厂工资率分页查询
* @param {查询条件} data
*/
export function listFicoWagerates(query) {
  return request({
    url: 'Financial/FicoWagerates/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增工厂工资率
* @param data
*/
export function addFicoWagerates(data) {
  return request({
    url: 'Financial/FicoWagerates',
    method: 'post',
    data: data,
  })
}

/**
* 修改工厂工资率
* @param data
*/
export function updateFicoWagerates(data) {
  return request({
    url: 'Financial/FicoWagerates',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取工厂工资率详情
* @param {Id}
*/
export function getFicoWagerates(id) {
  return request({
    url: 'Financial/FicoWagerates/' + id,
    method: 'get'
  })
}

/**
* 删除工厂工资率
* @param {主键} pid
*/
export function delFicoWagerates(pid) {
  return request({
    url: 'Financial/FicoWagerates/' + pid,
    method: 'delete'
  })
}

// 清空工厂工资率
export function clearFicoWagerates() {
  return request({
    url: 'Financial/FicoWagerates/clean',
    method: 'delete'
  })
}

// 导出工厂工资率
export async function exportFicoWagerates(query) {
  await downFile('Financial/FicoWagerates/export', { ...query })
}

