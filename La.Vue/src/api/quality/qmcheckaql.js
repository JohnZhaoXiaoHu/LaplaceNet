import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 抽样标准分页查询
* @param {查询条件} data
*/
export function listQmCheckAql(query) {
  return request({
    url: 'quality/QmCheckAql/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增抽样标准
* @param data
*/
export function addQmCheckAql(data) {
  return request({
    url: 'quality/QmCheckAql',
    method: 'post',
    data: data,
  })
}

/**
* 修改抽样标准
* @param data
*/
export function updateQmCheckAql(data) {
  return request({
    url: 'quality/QmCheckAql',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取抽样标准详情
* @param {Id}
*/
export function getQmCheckAql(id) {
  return request({
    url: 'quality/QmCheckAql/' + id,
    method: 'get'
  })
}

/**
* 删除抽样标准
* @param {主键} pid
*/
export function delQmCheckAql(pid) {
  return request({
    url: 'quality/QmCheckAql/' + pid,
    method: 'delete'
  })
}

// 清空抽样标准
export function clearQmCheckAql() {
  return request({
    url: 'quality/QmCheckAql/clean',
    method: 'delete'
  })
}

// 导出抽样标准
export async function exportQmCheckAql(query) {
  await downFile('quality/QmCheckAql/export', { ...query })
}

