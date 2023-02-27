import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 主设变信息表分页查询
* @param {查询条件} data
*/
export function listPpEcMaster(query) {
  return request({
    url: 'production/PpEcMaster/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增主设变信息表
* @param data
*/
export function addPpEcMaster(data) {
  return request({
    url: 'production/PpEcMaster',
    method: 'post',
    data: data,
  })
}

/**
* 修改主设变信息表
* @param data
*/
export function updatePpEcMaster(data) {
  return request({
    url: 'production/PpEcMaster',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取主设变信息表详情
* @param {Id}
*/
export function getPpEcMaster(id) {
  return request({
    url: 'production/PpEcMaster/' + id,
    method: 'get'
  })
}

/**
* 删除主设变信息表
* @param {主键} pid
*/
export function delPpEcMaster(pid) {
  return request({
    url: 'production/PpEcMaster/' + pid,
    method: 'delete'
  })
}

// 清空主设变信息表
export function clearPpEcMaster() {
  return request({
    url: 'production/PpEcMaster/clean',
    method: 'delete'
  })
}

// 导出主设变信息表
export async function exportPpEcMaster(query) {
  await downFile('production/PpEcMaster/export', { ...query })
}

