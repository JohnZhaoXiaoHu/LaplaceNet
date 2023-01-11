import request from '@/utils/request'

/**
* 利润中心分页查询
* @param {查询条件} data
*/
export function listFicoPrctr(query) {
  return request({
    url: 'financial/FicoPrctr/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增利润中心
* @param data
*/
export function addFicoPrctr(data) {
  return request({
    url: 'financial/FicoPrctr',
    method: 'post',
    data: data,
  })
}

/**
* 修改利润中心
* @param data
*/
export function updateFicoPrctr(data) {
  return request({
    url: 'financial/FicoPrctr',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取利润中心详情
* @param {Id}
*/
export function getFicoPrctr(id) {
  return request({
    url: 'financial/FicoPrctr/' + id,
    method: 'get'
  })
}

/**
* 删除利润中心
* @param {主键} pid
*/
export function delFicoPrctr(pid) {
  return request({
    url: 'financial/FicoPrctr/' + pid,
    method: 'delete'
  })
}

// 清空利润中心
export function clearFicoPrctr() {
  return request({
    url: 'financial/FicoPrctr/clean',
    method: 'delete'
  })
}

// 导出利润中心
export async function exportFicoPrctr(query) {
  await downFile('financial/FicoPrctr/export', { ...query })
}

