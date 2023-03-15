import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 审批节点分页查询
* @param {查询条件} data
*/
export function listWfWorkflowtablestep(query) {
  return request({
    url: 'workflow/WfWorkflowtablestep/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增审批节点
* @param data
*/
export function addWfWorkflowtablestep(data) {
  return request({
    url: 'workflow/WfWorkflowtablestep',
    method: 'post',
    data: data,
  })
}

/**
* 修改审批节点
* @param data
*/
export function updateWfWorkflowtablestep(data) {
  return request({
    url: 'workflow/WfWorkflowtablestep',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取审批节点详情
* @param {Id}
*/
export function getWfWorkflowtablestep(id) {
  return request({
    url: 'workflow/WfWorkflowtablestep/' + id,
    method: 'get'
  })
}

/**
* 删除审批节点
* @param {主键} pid
*/
export function delWfWorkflowtablestep(pid) {
  return request({
    url: 'workflow/WfWorkflowtablestep/' + pid,
    method: 'delete'
  })
}

// 清空审批节点
export function clearWfWorkflowtablestep() {
  return request({
    url: 'workflow/WfWorkflowtablestep/clean',
    method: 'delete'
  })
}

// 导出审批节点
export async function exportWfWorkflowtablestep(query) {
  await downFile('workflow/WfWorkflowtablestep/export', { ...query })
}

