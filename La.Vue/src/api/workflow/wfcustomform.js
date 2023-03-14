import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 自定义表单分页查询
* @param {查询条件} data
*/
export function listWfCustomform(query) {
  return request({
    url: 'workflow/WfCustomform/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增自定义表单
* @param data
*/
export function addWfCustomform(data) {
  return request({
    url: 'workflow/WfCustomform',
    method: 'post',
    data: data,
  })
}

/**
* 修改自定义表单
* @param data
*/
export function updateWfCustomform(data) {
  return request({
    url: 'workflow/WfCustomform',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取自定义表单详情
* @param {Id}
*/
export function getWfCustomform(id) {
  return request({
    url: 'workflow/WfCustomform/' + id,
    method: 'get'
  })
}

/**
* 删除自定义表单
* @param {主键} pid
*/
export function delWfCustomform(pid) {
  return request({
    url: 'workflow/WfCustomform/' + pid,
    method: 'delete'
  })
}

// 清空自定义表单
export function clearWfCustomform() {
  return request({
    url: 'workflow/WfCustomform/clean',
    method: 'delete'
  })
}

// 导出自定义表单
export async function exportWfCustomform(query) {
  await downFile('workflow/WfCustomform/export', { ...query })
}

