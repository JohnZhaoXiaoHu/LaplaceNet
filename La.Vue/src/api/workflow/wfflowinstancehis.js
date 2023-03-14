import request from '@/utils/request'

/**
* 工作流实例流转历史记录分页查询
* @param {查询条件} data
*/
export function listWfFlowinstancehis(query) {
  return request({
    url: 'workflow/WfFlowinstancehis/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增工作流实例流转历史记录
* @param data
*/
export function addWfFlowinstancehis(data) {
  return request({
    url: 'workflow/WfFlowinstancehis',
    method: 'post',
    data: data,
  })
}

/**
* 修改工作流实例流转历史记录
* @param data
*/
export function updateWfFlowinstancehis(data) {
  return request({
    url: 'workflow/WfFlowinstancehis',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取工作流实例流转历史记录详情
* @param {Id}
*/
export function getWfFlowinstancehis(id) {
  return request({
    url: 'workflow/WfFlowinstancehis/' + id,
    method: 'get'
  })
}

/**
* 删除工作流实例流转历史记录
* @param {主键} pid
*/
export function delWfFlowinstancehis(pid) {
  return request({
    url: 'workflow/WfFlowinstancehis/' + pid,
    method: 'delete'
  })
}

// 清空工作流实例流转历史记录
export function clearWfFlowinstancehis() {
  return request({
    url: 'workflow/WfFlowinstancehis/clean',
    method: 'delete'
  })
}

// 导出工作流实例流转历史记录
export async function exportWfFlowinstancehis(query) {
  await downFile('workflow/WfFlowinstancehis/export', { ...query })
}

