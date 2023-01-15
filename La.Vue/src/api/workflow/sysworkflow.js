import request from '@/utils/request'

/**
* 工作流分页查询
* @param {查询条件} data
*/
export function listSysWorkFlow(query) {
  return request({
    url: 'workflow/SysWorkFlow/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增工作流
* @param data
*/
export function addSysWorkFlow(data) {
  return request({
    url: 'workflow/SysWorkFlow',
    method: 'post',
    data: data,
  })
}

/**
* 修改工作流
* @param data
*/
export function updateSysWorkFlow(data) {
  return request({
    url: 'workflow/SysWorkFlow',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取工作流详情
* @param {Id}
*/
export function getSysWorkFlow(id) {
  return request({
    url: 'workflow/SysWorkFlow/' + id,
    method: 'get'
  })
}

/**
* 删除工作流
* @param {主键} pid
*/
export function delSysWorkFlow(pid) {
  return request({
    url: 'workflow/SysWorkFlow/' + pid,
    method: 'delete'
  })
}

// 清空工作流
export function clearSysWorkFlow() {
  return request({
    url: 'workflow/SysWorkFlow/clean',
    method: 'delete'
  })
}

// 导出工作流
export async function exportSysWorkFlow(query) {
  await downFile('workflow/SysWorkFlow/export', { ...query })
}

