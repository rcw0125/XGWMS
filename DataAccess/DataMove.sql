IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'DataMove')
	BEGIN
		DROP  Procedure  DataMove
	END
GO

CREATE Procedure DataMove
AS
--计算出当前日期前三个月的第一天，保证导出的数据为整月:如当前日期为2007-11-12，则迁出的数据为2007-8-1之前的数据 
DECLARE @dataturnDate datetime
DECLARE @returnResult int
DECLARE @err int
DECLARE @logid int
DECLARE @cCount int


select @dataturnDate=(select DATEADD(mm,datediff(mm,0,DATEADD(mm,-3,getdate())),0))

exec @returnResult=wms_dts_getpchinfo @dataturnDate --生成要导出的批次信息
IF(@returnResult=-1)
		RETURN -1



INSERT INTO WMS_Pub_DataMoveLog VALUES('wms_bms_inv_info',getDate(),NULL,@dataturnDate,0,0)
SET @logid=@@IDENTITY 
BEGIN TRAN
	TRUNCATE table [Acctrue_WMSBACK].[dbo].wms_bms_inv_info
	insert into [Acctrue_WMSBACK].[dbo].wms_bms_inv_info select * from wms_bms_inv_info --导出库存表信息
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Pic_FYD',getDate(),NULL,@dataturnDate,0,0) --导出发运单信息
SET @logid=@@IDENTITY
BEGIN TRAN
	INSERT into [Acctrue_WMSBACK].[dbo].WMS_Bms_Pic_FYD select * from WMS_Bms_Pic_FYD where nczdrq <@dataturnDate AND (Status = 4 or (yslb=1 and Status = 3) or (yslb=2 and Status = 2))
	DELETE FROM  WMS_Bms_Pic_FYD where (nczdrq < @dataturnDate AND (Status = 4 or (yslb=1 and Status = 3) or (yslb=2 and Status = 2)))
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_Log_Print',getDate(),NULL,@dataturnDate,0,0) --导出打印日志
SET @logid=@@IDENTITY
BEGIN TRAN
	INSERT INTO  [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_Log_Print select * from WMS_Bms_Rec_Log_Print where Usertime<@dataturnDate
	DELETE FROM  WMS_Bms_Rec_Log_Print where Usertime<@dataturnDate
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_WGD',getDate(),NULL,@dataturnDate,0,0) --导出完工单信息
SET @logid=@@IDENTITY
BEGIN TRAN
	INSERT INTO  [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD select * from WMS_Bms_Rec_WGD  where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD.pch)
	delete from WMS_Bms_Rec_WGD where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_WGD_CKCXH',getDate(),NULL,@dataturnDate,0,0) --导出信息表WMS_Bms_Rec_WGD_CKCXH（出口材序列号）
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_CKCXH
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_CKCXH select * from WMS_Bms_Rec_WGD_CKCXH 
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_WGD_Item',getDate(),NULL,@dataturnDate,0,0)--导出完工单详细信息
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_Item select * from WMS_Bms_Rec_WGD_Item where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_Item.pch) 
	delete from WMS_Bms_Rec_WGD_Item where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_Item.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_WGD_Liquid',getDate(),NULL,@dataturnDate,0,0)--导出完工单附表
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_Liquid select * from WMS_Bms_Rec_WGD_Liquid where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_Liquid.pch)
	delete from WMS_Bms_Rec_WGD_Liquid where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_Liquid.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_WGD_Manage',getDate(),NULL,@dataturnDate,0,0)--导出完工单管理权限表
SET @logid=@@IDENTITY
BEGIN TRAN
	delete from  [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_Manage
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_Manage select * from WMS_Bms_Rec_WGD_Manage
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_WGD_ManageLog',getDate(),NULL,@dataturnDate,0,0)--导出完工单管理日志表
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into  [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_ManageLog select * from WMS_Bms_Rec_WGD_ManageLog where (opetime <@dataturnDate) 
	delete from  WMS_Bms_Rec_WGD_ManageLog where (opetime < @dataturnDate)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_WGD_PaoGou',getDate(),NULL,@dataturnDate,0,0)--导出完工跑钩记录
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_PaoGou select * from WMS_Bms_Rec_WGD_PaoGou where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_PaoGou.pch)
	delete from WMS_Bms_Rec_WGD_PaoGou where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_PaoGou.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_WGD_Result',getDate(),NULL,@dataturnDate,0,0)--导出完工跑钩记录
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_Result select * from WMS_Bms_Rec_WGD_Result where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_Result.pch)
	delete from WMS_Bms_Rec_WGD_Result where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_Result.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;



INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_WGD_Free',getDate(),NULL,@dataturnDate,0,0)--导出完工单自由项
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_Free select * from WMS_Bms_Rec_WGD_Free where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_Free.pch)
	delete from WMS_Bms_Rec_WGD_Free where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_Free.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_WGD_Item_Free',getDate(),NULL,@dataturnDate,0,0)--完工单明细自由项表
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_Item_Free select * from WMS_Bms_Rec_WGD_Item_Free where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_Item_Free.pch)
	delete from WMS_Bms_Rec_WGD_Item_Free where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Rec_WGD_Item_Free.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Rec_WGD_NC_Free_Relations',getDate(),NULL,@dataturnDate,0,0)--完工单自由项与NC完工单字段对应关系表
SET @logid=@@IDENTITY
BEGIN TRAN
	delete from [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_NC_Free_Relations
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_NC_Free_Relations select * from WMS_Bms_Rec_WGD_NC_Free_Relations
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;



INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Shi_YWD',getDate(),NULL,@dataturnDate,0,0)--导出移位单信息
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Shi_YWD SELECT * FROM WMS_Bms_Shi_YWD WHERE EXISTS (SELECT 1 FROM (SELECT ywdh FROM WMS_Bms_Shi_YWD_item WHERE (EXISTS (SELECT 1 FROM wms_pub_dts_pch dtspch WHERE dtspch.pch = WMS_Bms_Shi_YWD_item.pch))) t WHERE t.ywdh = WMS_Bms_Shi_YWD.ywdh) 
	delete from WMS_Bms_Shi_YWD  WHERE EXISTS (SELECT 1 FROM (SELECT ywdh FROM WMS_Bms_Shi_YWD_item  WHERE EXISTS (select 1 FROM wms_pub_dts_pch dtspch WHERE dtspch.pch = WMS_Bms_Shi_YWD_item.pch)) t WHERE t.ywdh = WMS_Bms_Shi_YWD.ywdh)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Shi_YWD_item',getDate(),NULL,@dataturnDate,0,0)--导出移位单明细信息
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Shi_YWD_item select * from WMS_Bms_Shi_YWD_item  where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Shi_YWD_item.pch) 
	delete from WMS_Bms_Shi_YWD_item where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Shi_YWD_item.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Tra_ZKD',getDate(),NULL,@dataturnDate,0,0)--导出转库单信息
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Tra_ZKD select * from WMS_Bms_Tra_ZKD where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Tra_ZKD.pch)
	delete from WMS_Bms_Tra_ZKD where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Tra_ZKD.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Tra_ZKD_Detail',getDate(),NULL,@dataturnDate,0,0)--导出转库单详细信息
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Tra_ZKD_Detail select * from WMS_Bms_Tra_ZKD_Detail where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Tra_ZKD_Detail.pch)
	delete from WMS_Bms_Tra_ZKD_Detail where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Tra_ZKD_Detail.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;

INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Tra_ZKD_Item',getDate(),NULL,@dataturnDate,0,0)--导出转库单明细信息
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Tra_ZKD_Item select * from WMS_Bms_Tra_ZKD_Item where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Tra_ZKD_Item.pch)
	delete from WMS_Bms_Tra_ZKD_Item where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Tra_ZKD_Item.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Tra_ZKD_Total',getDate(),NULL,@dataturnDate,0,0)--导出转库单总计信息
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Tra_ZKD_Total select * from WMS_Bms_Tra_ZKD_Total where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Tra_ZKD_Total.pch)
	delete from WMS_Bms_Tra_ZKD_Total where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Tra_ZKD_Total.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_BMS_WL_SX',getDate(),NULL,@dataturnDate,0,0)--导出物料属性表
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table [Acctrue_WMSBACK].[dbo].WMS_BMS_WL_SX
	insert into [Acctrue_WMSBACK].[dbo].WMS_BMS_WL_SX select * from WMS_BMS_WL_SX
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Cha_XTZHD_Item',getDate(),NULL,@dataturnDate,0,0)--导出形态转换单
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Cha_XTZHD_Item SELECT * FROM WMS_Cha_XTZHD_Item WHERE EXISTS (SELECT 1 FROM (SELECT zhdh FROM WMS_Cha_XTZHD WHERE EXISTS (SELECT 1 FROM wms_pub_dts_pch dtspch WHERE dtspch.pch = WMS_Cha_XTZHD.pch)) t  WHERE t.zhdh = WMS_Cha_XTZHD_Item.zhdh)
	delete from WMS_Cha_XTZHD_Item WHERE EXISTS (SELECT 1 FROM (SELECT zhdh FROM WMS_Cha_XTZHD WHERE EXISTS (SELECT 1 FROM wms_pub_dts_pch dtspch WHERE dtspch.pch = WMS_Cha_XTZHD.pch)) t  WHERE t.zhdh = WMS_Cha_XTZHD_Item.zhdh)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Cha_XTZHD_Result',getDate(),NULL,@dataturnDate,0,0)--导出形态转换结果
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Cha_XTZHD_Result SELECT * FROM WMS_Cha_XTZHD_Result WHERE EXISTS (SELECT 1 FROM (SELECT zhdh FROM WMS_Cha_XTZHD WHERE EXISTS (SELECT 1 FROM wms_pub_dts_pch dtspch WHERE dtspch.pch = WMS_Cha_XTZHD.pch)) t  WHERE t.zhdh = WMS_Cha_XTZHD_Result.zhdh)
	delete from WMS_Cha_XTZHD_Result WHERE EXISTS (SELECT 1 FROM (SELECT zhdh FROM WMS_Cha_XTZHD WHERE EXISTS (SELECT 1 FROM wms_pub_dts_pch dtspch WHERE dtspch.pch = WMS_Cha_XTZHD.pch)) t WHERE t.zhdh = WMS_Cha_XTZHD_Result.zhdh)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Cha_XTZHD',getDate(),NULL,@dataturnDate,0,0)--导出形态转换单
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Cha_XTZHD select * from WMS_Cha_XTZHD where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Cha_XTZHD.pch)
	delete from WMS_Cha_XTZHD where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Cha_XTZHD.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Che_PDD',getDate(),NULL,@dataturnDate,0,0)--导出盘点单
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Che_PDD SELECT * FROM WMS_Che_PDD WHERE EXISTS (SELECT 1 FROM (SELECT PDDH FROM WMS_Che_PDD_DETAIL WHERE EXISTS (SELECT 1 FROM wms_pub_dts_pch dtspch  WHERE dtspch.pch = WMS_Che_PDD_DETAIL.pch)) t WHERE t.pddh = WMS_Che_PDD.pddh)
	delete from WMS_Che_PDD  WHERE EXISTS (SELECT 1 FROM (SELECT PDDH FROM WMS_Che_PDD_DETAIL WHERE EXISTS (SELECT 1 FROM wms_pub_dts_pch dtspch  WHERE dtspch.pch = WMS_Che_PDD_DETAIL.pch)) t  WHERE t.pddh = WMS_Che_PDD.pddh)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Che_PDD_DETAIL',getDate(),NULL,@dataturnDate,0,0)--导出盘点详细单
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Che_PDD_DETAIL select * from WMS_Che_PDD_DETAIL where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Che_PDD_DETAIL.pch)
	delete from WMS_Che_PDD_DETAIL where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Che_PDD_DETAIL.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_CHE_PDD_DJDETAIL',getDate(),NULL,@dataturnDate,0,0)--导出盘点详细单
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_CHE_PDD_DJDETAIL select * from WMS_CHE_PDD_DJDETAIL where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_CHE_PDD_DJDETAIL.pch)
	delete from WMS_CHE_PDD_DJDETAIL where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_CHE_PDD_DJDETAIL.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_CHE_PDDNC',getDate(),NULL,@dataturnDate,0,0)--导出盘点NC单
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_CHE_PDDNC SELECT * FROM WMS_CHE_PDDNC WHERE EXISTS (SELECT 1 FROM (SELECT ysdh FROM WMS_CHE_PDDNC_DETAIL WHERE EXISTS (SELECT 1 FROM wms_pub_dts_pch dtspch  WHERE dtspch.pch = WMS_CHE_PDDNC_DETAIL.pch)) t WHERE t.ysdh = WMS_CHE_PDDNC.ysdh)
	delete from WMS_CHE_PDDNC  WHERE EXISTS (SELECT 1 FROM (SELECT ysdh FROM WMS_CHE_PDDNC_DETAIL WHERE EXISTS  (SELECT 1 FROM wms_pub_dts_pch dtspch  WHERE dtspch.pch = WMS_CHE_PDDNC_DETAIL.pch)) t WHERE t.ysdh = WMS_CHE_PDDNC.ysdh)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_CHE_PDDNC_DETAIL',getDate(),NULL,@dataturnDate,0,0)--导出盘点NC单详细
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_CHE_PDDNC_DETAIL select * from WMS_CHE_PDDNC_DETAIL where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_CHE_PDDNC_DETAIL.pch)
	delete from WMS_CHE_PDDNC_DETAIL where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_CHE_PDDNC_DETAIL.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_CHE_QTCK',getDate(),NULL,@dataturnDate,0,0)--导出其它出库
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK SELECT * FROM WMS_CHE_QTCK WHERE EXISTS (SELECT 1 FROM (SELECT DISTINCT CKDH FROM WMS_CHE_QTCK_ITEM  WHERE EXISTS (SELECT 1 FROM wms_pub_dts_pch dtspch  WHERE dtspch.pch = WMS_CHE_QTCK_ITEM.pch)) t WHERE t.ckdh = WMS_CHE_QTCK.ckdh)
	delete from WMS_CHE_QTCK  WHERE EXISTS (SELECT 1 FROM (SELECT DISTINCT CKDH FROM WMS_CHE_QTCK_ITEM WHERE EXISTS (SELECT 1 FROM wms_pub_dts_pch dtspch WHERE dtspch.pch = WMS_CHE_QTCK_ITEM.pch)) t WHERE t.ckdh = WMS_CHE_QTCK.ckdh)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_CHE_QTCK_DETAIL',getDate(),NULL,@dataturnDate,0,0)--导出其它出库详细
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_DETAIL select * from WMS_CHE_QTCK_DETAIL where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_CHE_QTCK_DETAIL.pch)
	delete from WMS_CHE_QTCK_DETAIL where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_CHE_QTCK_DETAIL.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_CHE_QTCK_ITEM',getDate(),NULL,@dataturnDate,0,0)--导出其它出库明细
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_ITEM select * from WMS_CHE_QTCK_ITEM where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_CHE_QTCK_ITEM.pch)
	delete from WMS_CHE_QTCK_ITEM where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_CHE_QTCK_ITEM.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Com_Log',getDate(),NULL,@dataturnDate,0,0)--NC交互日志
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into  [Acctrue_WMSBACK].[dbo].WMS_Com_Log select * from WMS_Com_Log where comtime < @dataturnDate
	delete from  WMS_Com_Log where comtime < @dataturnDate
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pic_Doc',getDate(),NULL,@dataturnDate,0,0)--出库流水帐
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pic_Doc select * from WMS_Pic_Doc where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Pic_Doc.pch) 
	delete from WMS_Pic_Doc where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Pic_Doc.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_Customer',getDate(),NULL,@dataturnDate,0,0)--客户数据
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Pub_Customer 
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pub_Customer select * from WMS_Pub_Customer
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_HuiChuan',getDate(),NULL,@dataturnDate,0,0)--回传记录
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into  [Acctrue_WMSBACK].[dbo].WMS_Pub_HuiChuan select * from WMS_Pub_HuiChuan where (CONVERT(datetime, rec_time,100) < @dataturnDate) 
	delete from  WMS_Pub_HuiChuan where (CONVERT(datetime, rec_time,100) < @dataturnDate) 
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_HW',getDate(),NULL,@dataturnDate,0,0)--货位信息
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Pub_HW
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pub_HW select * from WMS_Pub_HW 
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;



INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_IC',getDate(),NULL,@dataturnDate,0,0)--IC卡信息
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Pub_IC
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pub_IC select * from WMS_Pub_IC
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_PUB_ORDERLIST',getDate(),NULL,@dataturnDate,0,0)--Order列表
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_PUB_ORDERLIST
	insert into [Acctrue_WMSBACK].[dbo].WMS_PUB_ORDERLIST select * from WMS_PUB_ORDERLIST
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_Param',getDate(),NULL,@dataturnDate,0,0)--系统参数
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Pub_Param
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pub_Param select * from WMS_Pub_Param
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_PerStd',getDate(),NULL,@dataturnDate,0,0)--规格标准
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Pub_PerStd
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pub_PerStd select * from WMS_Pub_PerStd
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_Role',getDate(),NULL,@dataturnDate,0,0)--角色
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Pub_Role
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pub_Role select * from WMS_Pub_Role
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_SCX',getDate(),NULL,@dataturnDate,0,0)--生产线
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Pub_SCX
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pub_SCX select * from WMS_Pub_SCX
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_Store',getDate(),NULL,@dataturnDate,0,0)--仓库
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Pub_Store
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pub_Store select * from WMS_Pub_Store
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_SX',getDate(),NULL,@dataturnDate,0,0)--属性
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Pub_SX
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pub_SX select * from WMS_Pub_SX
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;



INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_PUB_SX_HPReason',getDate(),NULL,@dataturnDate,0,0)--原因
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_PUB_SX_HPReason
	insert into [Acctrue_WMSBACK].[dbo].WMS_PUB_SX_HPReason select * from WMS_PUB_SX_HPReason
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_PUB_SX_LXBHGPReason',getDate(),NULL,@dataturnDate,0,0)--原因
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_PUB_SX_LXBHGPReason
	insert into [Acctrue_WMSBACK].[dbo].WMS_PUB_SX_LXBHGPReason select * from WMS_PUB_SX_LXBHGPReason
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_Users',getDate(),NULL,@dataturnDate,0,0)--用户
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Pub_Users
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pub_Users select * from WMS_Pub_Users
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_PUB_LISTCONFIG',getDate(),NULL,@dataturnDate,0,0)--列表配置
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_PUB_LISTCONFIG
	insert into [Acctrue_WMSBACK].[dbo].WMS_PUB_LISTCONFIG select * from WMS_PUB_LISTCONFIG
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;

INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Pub_Affiche',getDate(),NULL,@dataturnDate,0,0)--系统公告
SET @logid=@@IDENTITY
BEGIN TRAN
	TRUNCATE table  [Acctrue_WMSBACK].[dbo].WMS_Pub_Affiche
	insert into [Acctrue_WMSBACK].[dbo].WMS_Pub_Affiche select * from WMS_Pub_Affiche
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_PUB_WorkLoad',getDate(),NULL,@dataturnDate,0,0)--操作日志
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into  [Acctrue_WMSBACK].[dbo].WMS_PUB_WorkLoad  select * from WMS_PUB_WorkLoad where (opedate < @dataturnDate)
	delete from  WMS_PUB_WorkLoad where (opedate < @dataturnDate)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Rev_Doc',getDate(),NULL,@dataturnDate,0,0)--出库流水
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Rev_Doc select * from WMS_Rev_Doc  where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Rev_Doc.pch)
	delete from WMS_Rev_Doc where exists  (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Rev_Doc.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;



INSERT INTO WMS_Pub_DataMoveLog VALUES('xtzhtemp',getDate(),NULL,@dataturnDate,0,0)--形态转换临时
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].xtzhtemp select * from xtzhtemp  where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=xtzhtemp.pch)
	delete from xtzhtemp where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=xtzhtemp.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;


INSERT INTO WMS_Pub_DataMoveLog VALUES('WMS_Bms_Inv_OutInfo',getDate(),NULL,@dataturnDate,0,0)--出入库流水
SET @logid=@@IDENTITY
BEGIN TRAN
	insert into [Acctrue_WMSBACK].[dbo].WMS_Bms_Inv_OutInfo select * from WMS_Bms_Inv_OutInfo where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Inv_OutInfo.pch)
	delete from WMS_Bms_Inv_OutInfo where exists (select 1 from wms_pub_dts_pch dtspch where dtspch.pch=WMS_Bms_Inv_OutInfo.pch)
	set @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid;

update WMS_Pub_Param set CS_Value=getDate() where (CS_Name = 'LastLoadOuttime')
GO

/*
GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
*/

