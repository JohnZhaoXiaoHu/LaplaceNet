// import Cookies from 'js-cookie'
//token
const TokenKey = 'La-Token'
// 时间
const LoginKey = "hrsass_login_time";
//读取token
export function getToken() {
  return localStorage.getItem(TokenKey)
}

// 设置token  不要 return
export function setToken(token) {
  // 记录一下登录时候的时间戳
  localStorage.setItem(LoginKey, Date.now())
  //存储token
  localStorage.setItem(TokenKey, token)
}
//删除token
export function removeToken() {
  return localStorage.removeItem(TokenKey)
}
// 读取登录的时间
export const getLoginTime = () => {
  return localStorage.getItem(LoginKey);
};
// 读取登录的时间
export const clear = () => {
  return localStorage.clear();
};
