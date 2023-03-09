import request from '@/utils/request'

/**
* 工作流分页查询
* @param {查询条件} data
*/
export function listSysWflow(query) {
  return request({
    url: 'workflow/SysWflow/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增工作流
* @param data
*/
export function addSysWflow(data) {
  return request({
    url: 'workflow/SysWflow',
    method: 'post',
    data: data,
  })
}

/**
* 修改工作流
* @param data
*/
export function updateSysWflow(data) {
  return request({
    url: 'workflow/SysWflow',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取工作流详情
* @param {Id}
*/
export function getSysWflow(id) {
  return request({
    url: 'workflow/SysWflow/' + id,
    method: 'get'
  })
}

/**
* 删除工作流
* @param {主键} pid
*/
export function delSysWflow(pid) {
  return request({
    url: 'workflow/SysWflow/' + pid,
    method: 'delete'
  })
}

// 清空工作流
export function clearSysWflow() {
  return request({
    url: 'workflow/SysWflow/clean',
    method: 'delete'
  })
}

// 导出工作流
export async function exportSysWflow(query) {
  await downFile('workflow/SysWflow/export', { ...query })
}

