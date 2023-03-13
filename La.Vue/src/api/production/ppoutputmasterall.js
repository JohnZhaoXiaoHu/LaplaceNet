import request from '@/utils/request'

/**
* oph主表分页查询
* @param {查询条件} data
*/

export function listPpOutputMasterAll() {
  return request({
    url: 'production/PpOutputMaster/list',
    method: 'get',

  })
}

