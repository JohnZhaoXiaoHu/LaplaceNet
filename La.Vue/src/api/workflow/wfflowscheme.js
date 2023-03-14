import request from '@/utils/request'

/**
* 流程分页查询
* @param {查询条件} data
*/
export function listWfFlowscheme(query) {
  return request({
    url: 'workflow/WfFlowscheme/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增流程
* @param data
*/
export function addWfFlowscheme(data) {
  return request({
    url: 'workflow/WfFlowscheme',
    method: 'post',
    data: data,
  })
}

/**
* 修改流程
* @param data
*/
export function updateWfFlowscheme(data) {
  return request({
    url: 'workflow/WfFlowscheme',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取流程详情
* @param {Id}
*/
export function getWfFlowscheme(id) {
  return request({
    url: 'workflow/WfFlowscheme/' + id,
    method: 'get'
  })
}

/**
* 删除流程
* @param {主键} pid
*/
export function delWfFlowscheme(pid) {
  return request({
    url: 'workflow/WfFlowscheme/' + pid,
    method: 'delete'
  })
}

// 清空流程
export function clearWfFlowscheme() {
  return request({
    url: 'workflow/WfFlowscheme/clean',
    method: 'delete'
  })
}

// 导出流程
export async function exportWfFlowscheme(query) {
  await downFile('workflow/WfFlowscheme/export', { ...query })
}

