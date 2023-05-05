import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 人事信息分页查询
* @param {查询条件} data
*/
export function listEhrEmployee(query) {
  return request({
    url: 'Office/EhrEmployee/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增人事信息
* @param data
*/
export function addEhrEmployee(data) {
  return request({
    url: 'Office/EhrEmployee',
    method: 'post',
    data: data,
  })
}

/**
* 修改人事信息
* @param data
*/
export function updateEhrEmployee(data) {
  return request({
    url: 'Office/EhrEmployee',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取人事信息详情
* @param {Id}
*/
export function getEhrEmployee(id) {
  return request({
    url: 'Office/EhrEmployee/' + id,
    method: 'get'
  })
}

/**
* 删除人事信息
* @param {主键} pid
*/
export function delEhrEmployee(pid) {
  return request({
    url: 'Office/EhrEmployee/' + pid,
    method: 'delete'
  })
}

// 清空人事信息
export function clearEhrEmployee() {
  return request({
    url: 'Office/EhrEmployee/clean',
    method: 'delete'
  })
}

// 导出人事信息
export async function exportEhrEmployee(query) {
  await downFile('Office/EhrEmployee/export', { ...query })
}

