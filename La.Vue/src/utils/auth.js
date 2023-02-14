// import Cookies from 'js-cookie'

const TokenKey = 'La-Token'

export function getToken() {
  return localStorage.getItem(TokenKey)
}

export function setToken(token) {
  return localStorage.setItem(TokenKey, token)
}

export function removeToken() {
  return localStorage.removeItem(TokenKey)
}


import { TOKEN_TIME, TOKEN_TIME_VALUE } from './constant'

// 登录时设置时间
export const setTokenTime = () => {
  localStorage.setItem(TOKEN_TIME, Date.now())
}

// 获取
export const getTokenTime = () => {
  return localStorage.getItem(TOKEN_TIME)
}

// 是否已经过期
export const diffTokenTime = () => {
  const currentTime = Date.now()
  const tokenTime = getTokenTime()
  return currentTime - tokenTime > TOKEN_TIME_VALUE
}
