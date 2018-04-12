IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'wms_dts_DataReturn')
	BEGIN
		DROP  Procedure  wms_dts_DataReturn
	END

GO

CREATE Procedure wms_dts_DataReturn
(
	@pch varchar(200)
)

AS
BEGIN TRAN
	INSERT INTO  [Acctrue_WMS].[dbo].WMS_Pic_Doc select * from [Acctrue_WMSBACK].[dbo].WMS_Pic_Doc  where [Acctrue_WMSBACK].[dbo].WMS_Pic_Doc.pch=@pch --迁回入库库流水帐
	delete from [Acctrue_WMSBACK].[dbo].WMS_Pic_Doc where [Acctrue_WMSBACK].[dbo].WMS_Pic_Doc.pch=@pch
	IF (@@ERROR <> 0) 
		GOTO QuitWithRollback
	
	
	INSERT INTO  [Acctrue_WMS].[dbo].WMS_Rev_Doc select * from [Acctrue_WMSBACK].[dbo].WMS_Rev_Doc  where [Acctrue_WMSBACK].[dbo].WMS_Rev_Doc.pch=@pch --迁回出库流水帐
	delete from [Acctrue_WMSBACK].[dbo].WMS_Rev_Doc where [Acctrue_WMSBACK].[dbo].WMS_Rev_Doc.pch=@pch
	IF (@@ERROR <> 0) 
		GOTO QuitWithRollback
		
	INSERT into [Acctrue_WMS].[dbo].WMS_Bms_Pic_FYD select * from [Acctrue_WMSBACK].[dbo].[WMS_Bms_Pic_FYD] where [Acctrue_WMSBACK].[dbo].[WMS_Bms_Pic_FYD].FYDH IN (SELECT FYDH FROM [Acctrue_WMSBACK].[dbo].[WMS_Bms_Inv_OutInfo] WHERE [Acctrue_WMSBACK].[dbo].[WMS_Bms_Inv_OutInfo].pch=@pch) --迁回发运单信息
	DELETE FROM  [Acctrue_WMSBACK].[dbo].[WMS_Bms_Pic_FYD] where [Acctrue_WMSBACK].[dbo].[WMS_Bms_Pic_FYD].FYDH IN (SELECT FYDH FROM [Acctrue_WMSBACK].[dbo].[WMS_Bms_Inv_OutInfo] WHERE [Acctrue_WMSBACK].[dbo].[WMS_Bms_Inv_OutInfo].pch=@pch)
	IF (@@ERROR <> 0) 
		GOTO QuitWithRollback
		
	INSERT INTO  [Acctrue_WMS].[dbo].WMS_Bms_Inv_OutInfo select * from [Acctrue_WMSBACK].[dbo].WMS_Bms_Inv_OutInfo  where [Acctrue_WMSBACK].[dbo].WMS_Bms_Inv_OutInfo.pch=@pch --迁回出库流水帐
	delete from [Acctrue_WMSBACK].[dbo].WMS_Bms_Inv_OutInfo where [Acctrue_WMSBACK].[dbo].WMS_Bms_Inv_OutInfo.pch=@pch
	IF (@@ERROR <> 0) 
		GOTO QuitWithRollback
		
	
	INSERT INTO  [Acctrue_WMS].[dbo].WMS_Bms_Rec_WGD select * from [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD WHERE [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD.pch=@pch --迁回完工单信息
	delete from [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD where [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD.pch=@pch
	IF (@@ERROR <> 0) 
		GOTO QuitWithRollback
		
	INSERT INTO  [Acctrue_WMS].[dbo].WMS_Bms_Rec_WGD_Item select * from [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_Item WHERE [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_Item.pch=@pch --迁回完工单详细信息
	delete from [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_Item where [Acctrue_WMSBACK].[dbo].WMS_Bms_Rec_WGD_Item.pch=@pch
	IF (@@ERROR <> 0) 
		GOTO QuitWithRollback
		
	insert into [Acctrue_WMS].[dbo].WMS_CHE_QTCK select * from [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK where [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK.CKDH IN (SELECT CKDH FROM [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_ITEM WHERE [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_ITEM.pch=@pch) --迁回其他出库信息
	delete from [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK where [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK.CKDH IN (SELECT CKDH FROM [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_ITEM WHERE [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_ITEM.pch=@pch)
	IF (@@ERROR <> 0) 
		GOTO QuitWithRollback
		
		
	INSERT INTO  [Acctrue_WMS].[dbo].WMS_CHE_QTCK_DETAIL select * from [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_DETAIL WHERE [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_DETAIL.pch=@pch --迁回其他出库详细信息
	delete from [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_DETAIL where [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_DETAIL.pch=@pch
	IF (@@ERROR <> 0) 
		GOTO QuitWithRollback
	
	INSERT INTO  [Acctrue_WMS].[dbo].WMS_CHE_QTCK_ITEM select * from [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_ITEM WHERE [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_ITEM.pch=@pch --迁回其他出库详细明细信息
	delete from [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_ITEM where [Acctrue_WMSBACK].[dbo].WMS_CHE_QTCK_ITEM.pch=@pch
	IF (@@ERROR <> 0) 
		GOTO QuitWithRollback
COMMIT TRAN

QuitWithRollback:
	IF (@@TRANCOUNT > 0)
	BEGIN 
		ROLLBACK TRANSACTION
		RETURN -1
	END
GO

/*
GRANT EXEC ON Stored_Procedure_Name TO PUBLIC

GO
*/

