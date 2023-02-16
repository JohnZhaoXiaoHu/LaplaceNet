import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* 会计科目分页查询
* @param {查询条件} data
*/
export function listFicoTitle(query) {
  return request({
    url: 'financial/FicoTitle/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增会计科目
* @param data
*/
export function addFicoTitle(data) {
  return request({
    url: 'financial/FicoTitle',
    method: 'post',
    data: data,
  })
}

/**
* 修改会计科目
* @param data
*/
export function updateFicoTitle(data) {
  return request({
    url: 'financial/FicoTitle',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取会计科目详情
* @param {Id}
*/
export function getFicoTitle(id) {
  return request({
    url: 'financial/FicoTitle/' + id,
    method: 'get'
  })
}

/**
* 删除会计科目
* @param {主键} pid
*/
export function delFicoTitle(pid) {
  return request({
    url: 'financial/FicoTitle/' + pid,
    method: 'delete'
  })
}

// 清空会计科目
export function clearFicoTitle() {
  return request({
    url: 'financial/FicoTitle/clean',
    method: 'delete'
  })
}

// 导出会计科目
export async function exportFicoTitle(query) {
  await downFile('financial/FicoTitle/export', { ...query })
}

