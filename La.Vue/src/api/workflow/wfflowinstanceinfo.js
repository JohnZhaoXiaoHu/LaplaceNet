import request from '@/utils/request'

/**
* 工作流实例操作记录分页查询
* @param {查询条件} data
*/
export function listWfFlowinstanceinfo(query) {
  return request({
    url: 'workflow/WfFlowinstanceinfo/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增工作流实例操作记录
* @param data
*/
export function addWfFlowinstanceinfo(data) {
  return request({
    url: 'workflow/WfFlowinstanceinfo',
    method: 'post',
    data: data,
  })
}

/**
* 修改工作流实例操作记录
* @param data
*/
export function updateWfFlowinstanceinfo(data) {
  return request({
    url: 'workflow/WfFlowinstanceinfo',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取工作流实例操作记录详情
* @param {Id}
*/
export function getWfFlowinstanceinfo(id) {
  return request({
    url: 'workflow/WfFlowinstanceinfo/' + id,
    method: 'get'
  })
}

/**
* 删除工作流实例操作记录
* @param {主键} pid
*/
export function delWfFlowinstanceinfo(pid) {
  return request({
    url: 'workflow/WfFlowinstanceinfo/' + pid,
    method: 'delete'
  })
}

// 清空工作流实例操作记录
export function clearWfFlowinstanceinfo() {
  return request({
    url: 'workflow/WfFlowinstanceinfo/clean',
    method: 'delete'
  })
}

// 导出工作流实例操作记录
export async function exportWfFlowinstanceinfo(query) {
  await downFile('workflow/WfFlowinstanceinfo/export', { ...query })
}

