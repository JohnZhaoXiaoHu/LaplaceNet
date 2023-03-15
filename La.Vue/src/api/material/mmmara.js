import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 常规物料数据分页查询
* @param {查询条件} data
*/
export function listMmMara(query) {
  return request({
    url: 'material/MmMara/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增常规物料数据
* @param data
*/
export function addMmMara(data) {
  return request({
    url: 'material/MmMara',
    method: 'post',
    data: data,
  })
}

/**
* 修改常规物料数据
* @param data
*/
export function updateMmMara(data) {
  return request({
    url: 'material/MmMara',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取常规物料数据详情
* @param {Id}
*/
export function getMmMara(id) {
  return request({
    url: 'material/MmMara/' + id,
    method: 'get'
  })
}

/**
* 删除常规物料数据
* @param {主键} pid
*/
export function delMmMara(pid) {
  return request({
    url: 'material/MmMara/' + pid,
    method: 'delete'
  })
}

// 清空常规物料数据
export function clearMmMara() {
  return request({
    url: 'material/MmMara/clean',
    method: 'delete'
  })
}

// 导出常规物料数据
export async function exportMmMara(query) {
  await downFile('material/MmMara/export', { ...query })
}

