use La;

-- 人事信息菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by, create_time,menuName_key) 
VALUES ('人事信息', 1090, 999, 'OfficeEhrEmployee', 'office/OfficeEhrEmployee', 0, 0, 'C', '0', '0', 'office:ehremployee:list', 'icon1', 'system', GETDATE(),'menu.OfficeEhrEmployee');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time,menuName_key) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'office:ehremployee:query', '', 'system', GETDATE(),'btn.search');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time,menuName_key) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'office:ehremployee:add', '', 'system', GETDATE(),'btn.add');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time,menuName_key) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'office:ehremployee:delete', '', 'system', GETDATE(),'btn.delete');

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time,menuName_key) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'office:ehremployee:edit', '', 'system', GETDATE(),'btn.edit');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time,menuName_key) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'office:ehremployee:export', '', 'system', GETDATE(),'btn.export');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time,menuName_key) 
VALUES ('导入', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'office:ehremployee:import', '', 'system', GETDATE(),'btn.import');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time,menuName_key) 
VALUES ('预览', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'office:ehremployee:view', '', 'system', GETDATE(),'btn.preview');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time,menuName_key) 
VALUES ('清空', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'office:ehremployee:truncate', '', 'system', GETDATE(),'btn.clean');
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time,menuName_key) 
VALUES ('批量删除', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'office:ehremployee:multidel', '', 'system', GETDATE(),'btn.multi');

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;

-- 人事信息多语言
INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331090001,'zh-cn', 'menu.OfficeEhrEmployee', '人事信息', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331090002,'en', 'menu.OfficeEhrEmployee', '人事信息', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331090003,'ja', 'menu.OfficeEhrEmployee', '人事信息', GETDATE());