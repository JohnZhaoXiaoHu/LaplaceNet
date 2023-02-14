import request from '@/utils/request'

/**
* 电子技术辞典分页查询
* @param {查询条件} data
*/
export function listSysEtDict(query) {
  return request({
    url: 'system/EtDict/list',
    method: 'get',
    params: query,
  })
}
/**
 * 多语言配置查询
 * @param {查询条件} data
 */
export function listSysEtDictByLocale(locale) {
  return request({
    url: 'system/EtDict/list/' + locale,
    method: 'get',
  })
}

/**
* 新增电子技术辞典
* @param data
*/
export function addSysEtDict(data) {
  return request({
    url: 'system/SysEtDict',
    method: 'post',
    data: data,
  })
}

/**
* 修改电子技术辞典
* @param data
*/
export function updateSysEtDict(data) {
  return request({
    url: 'system/SysEtDict',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取电子技术辞典详情
* @param {Id}
*/
export function getSysEtDict(id) {
  return request({
    url: 'system/EtDict/' + id,
    method: 'get'
  })
}
/**
 * 获取多语言配置详情
 * @param {key}
 */
export function getSysEtDictByKey(key) {
  return request({
    url: 'system/EtDict/key/' + key,
    method: 'get'
  })
}
/**
* 删除电子技术辞典
* @param {主键} pid
*/
export function delSysEtDict(pid) {
  return request({
    url: 'system/EtDict/' + pid,
    method: 'delete'
  })
}

// 清空电子技术辞典
export function clearSysEtDict() {
  return request({
    url: 'system/EtDict/clean',
    method: 'delete'
  })
}

// 导出电子技术辞典
export async function exportSysEtDict(query) {
  await downFile('system/EtDict/export', { ...query })
}

