use Laplace_PRD;

-- 主设变信息表菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by, create_time,menuName_key) 
VALUES ('主设变信息表', 1169, 999, 'PpEcMaster', 'production/PpEcMaster', 0, 0, 'C', '0', '0', 'pp:ecmaster:list', 'icon1', 'system', GETDATE(), 'menu.PpEcMaster');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecmaster:query', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecmaster:add', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecmaster:delete', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecmaster:edit', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'pp:ecmaster:export', '', 'system', GETDATE());



-- 主设变信息表多语言
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('zh-cn', 'menu.PpEcMaster', '主设变信息表', GETDATE());
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('en', 'menu.PpEcMaster', '主设变信息表', GETDATE());
INSERT INTO sys_common_lang(lang_code, lang_key, lang_name, addtime) 
VALUES ('ja', 'menu.PpEcMaster', '主设变信息表', GETDATE());

SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;