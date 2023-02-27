import request from '@/utils/request'
import { downFile } from '@/utils/request'


export function genCode(initNumber) {
  return request({
    url: '/system/SysRefStrategy/get/' + initNumber,
    method: 'get'
  })
}


/**
* 单据编码分页查询
* @param {查询条件} data
*/
export function listSysRefStrategy(query) {
  return request({
    url: 'system/SysRefStrategy/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增单据编码
* @param data
*/
export function addSysRefStrategy(data) {
  return request({
    url: 'system/SysRefStrategy',
    method: 'post',
    data: data,
  })
}

/**
* 修改单据编码
* @param data
*/
export function updateSysRefStrategy(data) {
  return request({
    url: 'system/SysRefStrategy',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取单据编码详情
* @param {Id}
*/
export function getSysRefStrategy(id) {
  return request({
    url: 'system/SysRefStrategy/' + id,
    method: 'get'
  })
}

/**
* 删除单据编码
* @param {主键} pid
*/
export function delSysRefStrategy(pid) {
  return request({
    url: 'system/SysRefStrategy/' + pid,
    method: 'delete'
  })
}

// 清空单据编码
export function clearSysRefStrategy() {
  return request({
    url: 'system/SysRefStrategy/clean',
    method: 'delete'
  })
}

// 导出单据编码
export async function exportSysRefStrategy(query) {
  await downFile('system/SysRefStrategy/export', { ...query })
}

