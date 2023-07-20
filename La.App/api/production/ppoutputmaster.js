import request from '@/utils/request'

/**
* oph主表分页查询
* @param {查询条件} data
*/
export function listPpOutputMaster(query) {
  return request({
    url: '/production/PpOutputMaster/list',
    method: 'get',
    data: query,
  })
}

/**
* 新增oph主表
* @param data
*/
export function addPpOutputMaster(data) {
  return request({
    url: '/production/PpOutputMaster',
    method: 'post',
    data: data,
  })
}
/**
* 修改oph主表
* @param data
*/
export function updatePpOutputMaster(data) {
  return request({
    url: '/production/PpOutputMaster',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取oph主表详情
* @param {Id}
*/
export function getPpOutputMaster(id) {
  return request({
    url: '/production/PpOutputMaster/' + id,
    method: 'get'
  })
}

/**
* 删除oph主表
* @param {主键} pid
*/
export function delPpOutputMaster(pid) {
  return request({
    url: '/production/PpOutputMaster/' + pid,
    method: 'delete'
  })
}
// 清空oph主表
export function clearPpOutputMaster() {
  return request({
    url: '/production/PpOutputMaster/clean',
    method: 'delete'
  })
}
// 导出oph主表
export async function exportPpOutputMaster(query) {
  await downFile('$/{genTable.ModuleName}/PpOutputMaster/export', { ...query })
}
