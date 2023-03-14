import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 表单分页查询
* @param {查询条件} data
*/
export function listWfForm(query) {
  return request({
    url: 'workflow/WfForm/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增表单
* @param data
*/
export function addWfForm(data) {
  return request({
    url: 'workflow/WfForm',
    method: 'post',
    data: data,
  })
}

/**
* 修改表单
* @param data
*/
export function updateWfForm(data) {
  return request({
    url: 'workflow/WfForm',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取表单详情
* @param {Id}
*/
export function getWfForm(id) {
  return request({
    url: 'workflow/WfForm/' + id,
    method: 'get'
  })
}

/**
* 删除表单
* @param {主键} pid
*/
export function delWfForm(pid) {
  return request({
    url: 'workflow/WfForm/' + pid,
    method: 'delete'
  })
}

// 清空表单
export function clearWfForm() {
  return request({
    url: 'workflow/WfForm/clean',
    method: 'delete'
  })
}

// 导出表单
export async function exportWfForm(query) {
  await downFile('workflow/WfForm/export', { ...query })
}

