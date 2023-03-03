use Laplace_PRD;

-- 顾客信息菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by, create_time,menuName_key) 
VALUES ('顾客信息', 1095, 999, 'SdCustomer', 'sales/SdCustomer', 0, 0, 'C', '0', '0', 'sd:customer:list', 'icon1', 'system', GETDATE(), 'menu.SdCustomer');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'sd:customer:query', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'sd:customer:add', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'sd:customer:delete', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'sd:customer:edit', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'sd:customer:export', '', 'system', GETDATE());



-- 顾客信息多语言
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('zh-cn', 'menu.SdCustomer', '顾客信息', GETDATE());
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('en', 'menu.SdCustomer', '顾客信息', GETDATE());
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('ja', 'menu.SdCustomer', '顾客信息', GETDATE());

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;