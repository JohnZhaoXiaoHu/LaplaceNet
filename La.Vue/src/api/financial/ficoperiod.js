import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 财务期间分页查询
* @param {查询条件} data
*/
export function listFicoPeriod(query) {
  return request({
    url: 'Financial/FicoPeriod/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增财务期间
* @param data
*/
export function addFicoPeriod(data) {
  return request({
    url: 'Financial/FicoPeriod',
    method: 'post',
    data: data,
  })
}

/**
* 修改财务期间
* @param data
*/
export function updateFicoPeriod(data) {
  return request({
    url: 'Financial/FicoPeriod',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取财务期间详情
* @param {Id}
*/
export function getFicoPeriod(id) {
  return request({
    url: 'Financial/FicoPeriod/' + id,
    method: 'get'
  })
}

/**
* 删除财务期间
* @param {主键} pid
*/
export function delFicoPeriod(pid) {
  return request({
    url: 'Financial/FicoPeriod/' + pid,
    method: 'delete'
  })
}

// 清空财务期间
export function clearFicoPeriod() {
  return request({
    url: 'Financial/FicoPeriod/clean',
    method: 'delete'
  })
}

// 导出财务期间
export async function exportFicoPeriod(query) {
  await downFile('Financial/FicoPeriod/export', { ...query })
}

