import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 物料评估分页查询
* @param {查询条件} data
*/
export function listMmMbew(query) {
  return request({
    url: 'material/MmMbew/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增物料评估
* @param data
*/
export function addMmMbew(data) {
  return request({
    url: 'material/MmMbew',
    method: 'post',
    data: data,
  })
}

/**
* 修改物料评估
* @param data
*/
export function updateMmMbew(data) {
  return request({
    url: 'material/MmMbew',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取物料评估详情
* @param {Id}
*/
export function getMmMbew(id) {
  return request({
    url: 'material/MmMbew/' + id,
    method: 'get'
  })
}

/**
* 删除物料评估
* @param {主键} pid
*/
export function delMmMbew(pid) {
  return request({
    url: 'material/MmMbew/' + pid,
    method: 'delete'
  })
}

// 清空物料评估
export function clearMmMbew() {
  return request({
    url: 'material/MmMbew/clean',
    method: 'delete'
  })
}

// 导出物料评估
export async function exportMmMbew(query) {
  await downFile('material/MmMbew/export', { ...query })
}

