import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* OA流程实例表分页查询
* @param {查询条件} data
*/
export function listWfFlowMain(query) {
  return request({
    url: 'workflow/WfFlowMain/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增OA流程实例表
* @param data
*/
export function addWfFlowMain(data) {
  return request({
    url: 'workflow/WfFlowMain',
    method: 'post',
    data: data,
  })
}

/**
* 修改OA流程实例表
* @param data
*/
export function updateWfFlowMain(data) {
  return request({
    url: 'workflow/WfFlowMain',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取OA流程实例表详情
* @param {Id}
*/
export function getWfFlowMain(id) {
  return request({
    url: 'workflow/WfFlowMain/' + id,
    method: 'get'
  })
}

/**
* 删除OA流程实例表
* @param {主键} pid
*/
export function delWfFlowMain(pid) {
  return request({
    url: 'workflow/WfFlowMain/' + pid,
    method: 'delete'
  })
}

// 清空OA流程实例表
export function clearWfFlowMain() {
  return request({
    url: 'workflow/WfFlowMain/clean',
    method: 'delete'
  })
}

// 导出OA流程实例表
export async function exportWfFlowMain(query) {
  await downFile('workflow/WfFlowMain/export', { ...query })
}

