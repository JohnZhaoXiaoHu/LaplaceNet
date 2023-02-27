import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 物料信息分页查询
* @param {查询条件} data
*/
export function listMmMats(query) {
  return request({
    url: 'material/MmMats/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增物料信息
* @param data
*/
export function addMmMats(data) {
  return request({
    url: 'material/MmMats',
    method: 'post',
    data: data,
  })
}

/**
* 修改物料信息
* @param data
*/
export function updateMmMats(data) {
  return request({
    url: 'material/MmMats',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取物料信息详情
* @param {Id}
*/
export function getMmMats(id) {
  return request({
    url: 'material/MmMats/' + id,
    method: 'get'
  })
}

/**
* 删除物料信息
* @param {主键} pid
*/
export function delMmMats(pid) {
  return request({
    url: 'material/MmMats/' + pid,
    method: 'delete'
  })
}

// 清空物料信息
export function clearMmMats() {
  return request({
    url: 'material/MmMats/clean',
    method: 'delete'
  })
}

// 导出物料信息
export async function exportMmMats(query) {
  await downFile('material/MmMats/export', { ...query })
}

