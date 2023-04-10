import request from '@/utils/request'

/**
* 从设变信息表分页查询
* @param {查询条件} data
*/
export function listPpEcSlave(query) {
  return request({
    url: 'production/PpEcSlave/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增从设变信息表
* @param data
*/
export function addPpEcSlave(data) {
  return request({
    url: 'production/PpEcSlave',
    method: 'post',
    data: data,
  })
}

/**
* 修改从设变信息表
* @param data
*/
export function updatePpEcSlave(data) {
  return request({
    url: 'production/PpEcSlave',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取从设变信息表详情
* @param {Id}
*/
export function getPpEcSlave(id) {
  return request({
    url: 'production/PpEcSlave/' + id,
    method: 'get'
  })
}

/**
* 删除从设变信息表
* @param {主键} pid
*/
export function delPpEcSlave(pid) {
  return request({
    url: 'production/PpEcSlave/' + pid,
    method: 'delete'
  })
}

// 清空从设变信息表
export function clearPpEcSlave() {
  return request({
    url: 'production/PpEcSlave/clean',
    method: 'delete'
  })
}

// 导出从设变信息表
export async function exportPpEcSlave(query) {
  await downFile('production/PpEcSlave/export', { ...query })
}

