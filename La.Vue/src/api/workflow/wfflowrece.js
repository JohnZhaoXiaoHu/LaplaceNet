import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 流程使用记录分页查询
* @param {查询条件} data
*/
export function listWfFlowRece(query) {
  return request({
    url: 'workflow/WfFlowRece/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增流程使用记录
* @param data
*/
export function addWfFlowRece(data) {
  return request({
    url: 'workflow/WfFlowRece',
    method: 'post',
    data: data,
  })
}

/**
* 修改流程使用记录
* @param data
*/
export function updateWfFlowRece(data) {
  return request({
    url: 'workflow/WfFlowRece',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取流程使用记录详情
* @param {Id}
*/
export function getWfFlowRece(id) {
  return request({
    url: 'workflow/WfFlowRece/' + id,
    method: 'get'
  })
}

/**
* 删除流程使用记录
* @param {主键} pid
*/
export function delWfFlowRece(pid) {
  return request({
    url: 'workflow/WfFlowRece/' + pid,
    method: 'delete'
  })
}

// 清空流程使用记录
export function clearWfFlowRece() {
  return request({
    url: 'workflow/WfFlowRece/clean',
    method: 'delete'
  })
}

// 导出流程使用记录
export async function exportWfFlowRece(query) {
  await downFile('workflow/WfFlowRece/export', { ...query })
}

