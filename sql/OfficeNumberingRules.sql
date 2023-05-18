use Laplace_PRD;

-- 单据编码菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by, create_time,menuName_key) 
VALUES ('单据编码', 1212, 999, lower('OfficeNumberingRules'), 'office/OfficeNumberingRules', 0, 0, 'C', '0', '0', 'office:numberingrules:list', 'icon1', 'system', GETDATE(), 'menu.OfficeNumberingRules');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'office:numberingrules:query', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'office:numberingrules:add', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'office:numberingrules:delete', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'office:numberingrules:edit', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'office:numberingrules:export', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('导入', @menuId, 6, '#', NULL, 0, 0, 'F', '0', '0', 'office:numberingrules:import', '', 'system', GETDATE());

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;



-- 单据编码多语言
INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331212001,'zh-cn', 'menu.OfficeNumberingRules', '单据编码', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331212002,'en', 'menu.OfficeNumberingRules', '单据编码', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331212003,'ja', 'menu.OfficeNumberingRules', '单据编码', GETDATE());