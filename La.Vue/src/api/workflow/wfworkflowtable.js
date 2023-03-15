import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 审批流程分页查询
* @param {查询条件} data
*/
export function listWfWorkflowtable(query) {
  return request({
    url: 'workflow/WfWorkflowtable/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增审批流程
* @param data
*/
export function addWfWorkflowtable(data) {
  return request({
    url: 'workflow/WfWorkflowtable',
    method: 'post',
    data: data,
  })
}

/**
* 修改审批流程
* @param data
*/
export function updateWfWorkflowtable(data) {
  return request({
    url: 'workflow/WfWorkflowtable',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取审批流程详情
* @param {Id}
*/
export function getWfWorkflowtable(id) {
  return request({
    url: 'workflow/WfWorkflowtable/' + id,
    method: 'get'
  })
}

/**
* 删除审批流程
* @param {主键} pid
*/
export function delWfWorkflowtable(pid) {
  return request({
    url: 'workflow/WfWorkflowtable/' + pid,
    method: 'delete'
  })
}

// 清空审批流程
export function clearWfWorkflowtable() {
  return request({
    url: 'workflow/WfWorkflowtable/clean',
    method: 'delete'
  })
}

// 导出审批流程
export async function exportWfWorkflowtable(query) {
  await downFile('workflow/WfWorkflowtable/export', { ...query })
}

