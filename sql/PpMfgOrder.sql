use Laplace_PRD;

-- 生产工单菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by, create_time,menuName_key) 
VALUES ('生产工单', 1096, 999, 'PpMfgOrder', 'production/PpMfgOrder', 0, 0, 'C', '0', '0', 'pp:mfgorder:list', 'icon1', 'system', GETDATE(), 'menu.PpMfgOrder');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'pp:mfgorder:query', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'pp:mfgorder:add', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'pp:mfgorder:delete', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'pp:mfgorder:edit', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'pp:mfgorder:export', '', 'system', GETDATE());



-- 生产工单多语言
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('zh-cn', 'menu.PpMfgOrder', '生产工单', GETDATE());
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('en', 'menu.PpMfgOrder', '生产工单', GETDATE());
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('ja', 'menu.PpMfgOrder', '生产工单', GETDATE());

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;