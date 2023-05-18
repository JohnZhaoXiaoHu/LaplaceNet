import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 人事信息分页查询
* @param {查询条件} data
*/
export function listOfficeEhrEmployee(query) {
  return request({
    url: 'Office/OfficeEhrEmployee/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增人事信息
* @param data
*/
export function addOfficeEhrEmployee(data) {
  return request({
    url: 'Office/OfficeEhrEmployee',
    method: 'post',
    data: data,
  })
}

/**
* 修改人事信息
* @param data
*/
export function updateOfficeEhrEmployee(data) {
  return request({
    url: 'Office/OfficeEhrEmployee',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取人事信息详情
* @param {Id}
*/
export function getOfficeEhrEmployee(id) {
  return request({
    url: 'Office/OfficeEhrEmployee/' + id,
    method: 'get'
  })
}

/**
* 删除人事信息
* @param {主键} pid
*/
export function delOfficeEhrEmployee(pid) {
  return request({
    url: 'Office/OfficeEhrEmployee/' + pid,
    method: 'delete'
  })
}

// 清空人事信息
export function clearOfficeEhrEmployee() {
  return request({
    url: 'Office/OfficeEhrEmployee/clean',
    method: 'delete'
  })
}

// 导出人事信息
export async function exportOfficeEhrEmployee(query) {
  await downFile('Office/OfficeEhrEmployee/export', { ...query })
}

