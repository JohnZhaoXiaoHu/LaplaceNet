import request from '@/utils/request'

/**
* 计算公式分页查询
* @param {查询条件} data
*/
export function listInstFormula(query) {
  return request({
    url: '/office/InstFormula/list',
    method: 'get',
    data: query,
  })
}

/**
* 新增计算公式
* @param data
*/
export function addInstFormula(data) {
  return request({
    url: '/office/InstFormula',
    method: 'post',
    data: data,
  })
}
/**
* 修改计算公式
* @param data
*/
export function updateInstFormula(data) {
  return request({
    url: '/office/InstFormula',
    method: 'PUT',
    data: data,
  })
}
/**
* 获取计算公式详情
* @param {Id}
*/
export function getInstFormula(id) {
  return request({
    url: '/office/InstFormula/' + id,
    method: 'get'
  })
}

/**
* 删除计算公式
* @param {主键} pid
*/
export function delInstFormula(pid) {
  return request({
    url: '/office/InstFormula/' + pid,
    method: 'delete'
  })
}
// 清空计算公式
export function clearInstFormula() {
  return request({
    url: '/office/InstFormula/clean',
    method: 'delete'
  })
}
// 导出计算公式
export async function exportInstFormula(query) {
  await downFile('$/{genTable.ModuleName}/InstFormula/export', { ...query })
}
