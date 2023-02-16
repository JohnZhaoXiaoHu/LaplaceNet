import request from '@/utils/request'
import { downFile } from '@/utils/request'

/**
* bom成本核算分页查询
* @param {查询条件} data
*/
export function listFicoBomCosting(query) {
  return request({
    url: 'financial/FicoBomCosting/list',
    method: 'get',
    params: query,
  })
}


/**
* 新增bom成本核算
* @param data
*/
export function addFicoBomCosting(data) {
  return request({
    url: 'financial/FicoBomCosting',
    method: 'post',
    data: data,
  })
}

/**
* 修改bom成本核算
* @param data
*/
export function updateFicoBomCosting(data) {
  return request({
    url: 'financial/FicoBomCosting',
    method: 'PUT',
    data: data,
  })
}

/**
* 获取bom成本核算详情
* @param {Id}
*/
export function getFicoBomCosting(id) {
  return request({
    url: 'financial/FicoBomCosting/' + id,
    method: 'get'
  })
}

/**
* 删除bom成本核算
* @param {主键} pid
*/
export function delFicoBomCosting(pid) {
  return request({
    url: 'financial/FicoBomCosting/' + pid,
    method: 'delete'
  })
}

// 清空bom成本核算
export function clearFicoBomCosting() {
  return request({
    url: 'financial/FicoBomCosting/clean',
    method: 'delete'
  })
}

// 导出bom成本核算
export async function exportFicoBomCosting(query) {
  await downFile('financial/FicoBomCosting/export', { ...query })
}

