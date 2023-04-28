import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 电子辞典分页查询
* @param {查询条件} data
*/
export function listSysEtDict(query) {
  return request({
    url: 'System/SysEtDict/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增电子辞典
* @param data
*/
export function addSysEtDict(data) {
  return request({
    url: 'System/SysEtDict',
    method: 'post',
    data: data,
  })
}

/**
* 修改电子辞典
* @param data
*/
export function updateSysEtDict(data) {
  return request({
    url: 'System/SysEtDict',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取电子辞典详情
* @param {Id}
*/
export function getSysEtDict(id) {
  return request({
    url: 'System/SysEtDict/' + id,
    method: 'get'
  })
}

/**
* 删除电子辞典
* @param {主键} pid
*/
export function delSysEtDict(pid) {
  return request({
    url: 'System/SysEtDict/' + pid,
    method: 'delete'
  })
}

// 清空电子辞典
export function clearSysEtDict() {
  return request({
    url: 'System/SysEtDict/clean',
    method: 'delete'
  })
}

// 导出电子辞典
export async function exportSysEtDict(query) {
  await downFile('System/SysEtDict/export', { ...query })
}

