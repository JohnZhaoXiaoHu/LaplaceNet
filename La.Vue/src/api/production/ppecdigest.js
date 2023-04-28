import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 新旧物料分页查询
* @param {查询条件} data
*/
export function listPpEcDigest(query) {
  return request({
    url: 'Production/PpEcDigest/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增新旧物料
* @param data
*/
export function addPpEcDigest(data) {
  return request({
    url: 'Production/PpEcDigest',
    method: 'post',
    data: data,
  })
}

/**
* 修改新旧物料
* @param data
*/
export function updatePpEcDigest(data) {
  return request({
    url: 'Production/PpEcDigest',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取新旧物料详情
* @param {Id}
*/
export function getPpEcDigest(id) {
  return request({
    url: 'Production/PpEcDigest/' + id,
    method: 'get'
  })
}

/**
* 删除新旧物料
* @param {主键} pid
*/
export function delPpEcDigest(pid) {
  return request({
    url: 'Production/PpEcDigest/' + pid,
    method: 'delete'
  })
}

// 清空新旧物料
export function clearPpEcDigest() {
  return request({
    url: 'Production/PpEcDigest/clean',
    method: 'delete'
  })
}

// 导出新旧物料
export async function exportPpEcDigest(query) {
  await downFile('Production/PpEcDigest/export', { ...query })
}

