import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* OA流程模板表分页查询
* @param {查询条件} data
*/
export function listWfFlowTmpl(query) {
  return request({
    url: 'workflow/WfFlowTmpl/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增OA流程模板表
* @param data
*/
export function addWfFlowTmpl(data) {
  return request({
    url: 'workflow/WfFlowTmpl',
    method: 'post',
    data: data,
  })
}

/**
* 修改OA流程模板表
* @param data
*/
export function updateWfFlowTmpl(data) {
  return request({
    url: 'workflow/WfFlowTmpl',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取OA流程模板表详情
* @param {Id}
*/
export function getWfFlowTmpl(id) {
  return request({
    url: 'workflow/WfFlowTmpl/' + id,
    method: 'get'
  })
}

/**
* 删除OA流程模板表
* @param {主键} pid
*/
export function delWfFlowTmpl(pid) {
  return request({
    url: 'workflow/WfFlowTmpl/' + pid,
    method: 'delete'
  })
}

// 清空OA流程模板表
export function clearWfFlowTmpl() {
  return request({
    url: 'workflow/WfFlowTmpl/clean',
    method: 'delete'
  })
}

// 导出OA流程模板表
export async function exportWfFlowTmpl(query) {
  await downFile('workflow/WfFlowTmpl/export', { ...query })
}

