use Laplace_PRD;

-- 客户信息菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by, create_time,menuName_key) 
VALUES ('客户信息', 1095, 999, 'SdClient', 'sales/SdClient', 0, 0, 'C', '0', '0', 'sd:client:list', 'icon1', 'system', GETDATE(), 'menu.SdClient');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'sd:client:query', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'sd:client:add', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'sd:client:delete', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'sd:client:edit', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'sd:client:export', '', 'system', GETDATE());



-- 客户信息多语言
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('zh-cn', 'menu.SdClient', '客户信息', GETDATE());
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('en', 'menu.SdClient', '客户信息', GETDATE());
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('ja', 'menu.SdClient', '客户信息', GETDATE());

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;