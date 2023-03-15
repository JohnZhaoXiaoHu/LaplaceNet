import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 审批节点配置分页查询
* @param {查询条件} data
*/
export function listWfWorkflowstep(query) {
  return request({
    url: 'workflow/WfWorkflowstep/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增审批节点配置
* @param data
*/
export function addWfWorkflowstep(data) {
  return request({
    url: 'workflow/WfWorkflowstep',
    method: 'post',
    data: data,
  })
}

/**
* 修改审批节点配置
* @param data
*/
export function updateWfWorkflowstep(data) {
  return request({
    url: 'workflow/WfWorkflowstep',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取审批节点配置详情
* @param {Id}
*/
export function getWfWorkflowstep(id) {
  return request({
    url: 'workflow/WfWorkflowstep/' + id,
    method: 'get'
  })
}

/**
* 删除审批节点配置
* @param {主键} pid
*/
export function delWfWorkflowstep(pid) {
  return request({
    url: 'workflow/WfWorkflowstep/' + pid,
    method: 'delete'
  })
}

// 清空审批节点配置
export function clearWfWorkflowstep() {
  return request({
    url: 'workflow/WfWorkflowstep/clean',
    method: 'delete'
  })
}

// 导出审批节点配置
export async function exportWfWorkflowstep(query) {
  await downFile('workflow/WfWorkflowstep/export', { ...query })
}

