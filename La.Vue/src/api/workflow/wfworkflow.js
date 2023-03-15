import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 审批流程分页查询
* @param {查询条件} data
*/
export function listWfWorkflow(query) {
  return request({
    url: 'workflow/WfWorkflow/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增审批流程
* @param data
*/
export function addWfWorkflow(data) {
  return request({
    url: 'workflow/WfWorkflow',
    method: 'post',
    data: data,
  })
}

/**
* 修改审批流程
* @param data
*/
export function updateWfWorkflow(data) {
  return request({
    url: 'workflow/WfWorkflow',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取审批流程详情
* @param {Id}
*/
export function getWfWorkflow(id) {
  return request({
    url: 'workflow/WfWorkflow/' + id,
    method: 'get'
  })
}

/**
* 删除审批流程
* @param {主键} pid
*/
export function delWfWorkflow(pid) {
  return request({
    url: 'workflow/WfWorkflow/' + pid,
    method: 'delete'
  })
}

// 清空审批流程
export function clearWfWorkflow() {
  return request({
    url: 'workflow/WfWorkflow/clean',
    method: 'delete'
  })
}

// 导出审批流程
export async function exportWfWorkflow(query) {
  await downFile('workflow/WfWorkflow/export', { ...query })
}

