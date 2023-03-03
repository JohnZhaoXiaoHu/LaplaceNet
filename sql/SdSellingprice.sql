use Laplace_PRD;

-- 销售价格菜单
INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by, create_time,menuName_key) 
VALUES ('销售价格', 1095, 999, 'SdSellingprice', 'sales/SdSellingprice', 0, 0, 'C', '0', '0', 'sd:sellingprice:list', 'icon1', 'system', GETDATE(), 'menu.SdSellingprice');

-- 按钮父菜单id
declare @menuId int = @@identity


INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('查询', @menuId, 1, '#', NULL, 0, 0, 'F', '0', '0', 'sd:sellingprice:query', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('新增', @menuId, 2, '#', NULL, 0, 0, 'F', '0', '0', 'sd:sellingprice:add', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('删除', @menuId, 3, '#', NULL, 0, 0, 'F', '0', '0', 'sd:sellingprice:delete', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('修改', @menuId, 4, '#', NULL, 0, 0, 'F', '0', '0', 'sd:sellingprice:edit', '', 'system', GETDATE());

INSERT INTO sys_menu(menuName, parentId, orderNum, path, component, isFrame, isCache, menuType, visible, status, perms, icon, create_by,create_time) 
VALUES ('导出', @menuId, 5, '#', NULL, 0, 0, 'F', '0', '0', 'sd:sellingprice:export', '', 'system', GETDATE());


SELECT * FROM sys_menu WHERE parentId = @menuId;
SELECT * FROM sys_menu WHERE menuId = @menuId;



-- 销售价格多语言
INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331095001,'zh-cn', 'menu.SdSellingprice', '销售价格', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331095002,'en', 'menu.SdSellingprice', '销售价格', GETDATE());

INSERT INTO sys_common_lang(id,lang_code, lang_key, lang_name, addtime) 
VALUES (1631535213331095003,'ja', 'menu.SdSellingprice', '销售价格', GETDATE());