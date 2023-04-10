import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* OA流程分类表分页查询
* @param {查询条件} data
*/
export function listWfFlowCate(query) {
  return request({
    url: 'workflow/WfFlowCate/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增OA流程分类表
* @param data
*/
export function addWfFlowCate(data) {
  return request({
    url: 'workflow/WfFlowCate',
    method: 'post',
    data: data,
  })
}

/**
* 修改OA流程分类表
* @param data
*/
export function updateWfFlowCate(data) {
  return request({
    url: 'workflow/WfFlowCate',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取OA流程分类表详情
* @param {Id}
*/
export function getWfFlowCate(id) {
  return request({
    url: 'workflow/WfFlowCate/' + id,
    method: 'get'
  })
}

/**
* 删除OA流程分类表
* @param {主键} pid
*/
export function delWfFlowCate(pid) {
  return request({
    url: 'workflow/WfFlowCate/' + pid,
    method: 'delete'
  })
}

// 清空OA流程分类表
export function clearWfFlowCate() {
  return request({
    url: 'workflow/WfFlowCate/clean',
    method: 'delete'
  })
}

// 导出OA流程分类表
export async function exportWfFlowCate(query) {
  await downFile('workflow/WfFlowCate/export', { ...query })
}

