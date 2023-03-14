import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 流程实例模板分页查询
* @param {查询条件} data
*/
export function listWfFlowinstance(query) {
  return request({
    url: 'workflow/WfFlowinstance/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增流程实例模板
* @param data
*/
export function addWfFlowinstance(data) {
  return request({
    url: 'workflow/WfFlowinstance',
    method: 'post',
    data: data,
  })
}

/**
* 修改流程实例模板
* @param data
*/
export function updateWfFlowinstance(data) {
  return request({
    url: 'workflow/WfFlowinstance',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取流程实例模板详情
* @param {Id}
*/
export function getWfFlowinstance(id) {
  return request({
    url: 'workflow/WfFlowinstance/' + id,
    method: 'get'
  })
}

/**
* 删除流程实例模板
* @param {主键} pid
*/
export function delWfFlowinstance(pid) {
  return request({
    url: 'workflow/WfFlowinstance/' + pid,
    method: 'delete'
  })
}

// 清空流程实例模板
export function clearWfFlowinstance() {
  return request({
    url: 'workflow/WfFlowinstance/clean',
    method: 'delete'
  })
}

// 导出流程实例模板
export async function exportWfFlowinstance(query) {
  await downFile('workflow/WfFlowinstance/export', { ...query })
}

