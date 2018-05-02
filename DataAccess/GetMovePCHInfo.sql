--创建需要迁移出的批次信息
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'wms_dts_getpchinfo')
	BEGIN
		DROP  Procedure  wms_dts_getpchinfo
	END
GO

CREATE Procedure wms_dts_getpchinfo
(@dtsdate DateTime)
AS
DECLARE @logid int
DECLARE @cCount int
INSERT INTO WMS_Pub_DataMoveLog VALUES('wms_pub_dts_pch',getDate(),NULL,@dtsdate,0,0)
SET @logid=@@IDENTITY
BEGIN TRAN
	DECLARE @err int
	TRUNCATE table wms_pub_dts_pch;
	insert into wms_pub_dts_pch (pch) SELECT PCH FROM WMS_Bms_Inv_OutInfo outinfo WHERE (NOT EXISTS (SELECT 1 FROM wms_bms_inv_info info WHERE info.pch = outinfo.pch)) GROUP BY PCH HAVING (MAX(RQ) <@dtsdate)
	SET @cCount=@@rowcount
	SET @err=@@error
	IF(@err!=0)
	BEGIN 
		ROLLBACK TRAN
		UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=0 WHERE ID=@logid
		RETURN -1;
	END
COMMIT TRAN
UPDATE WMS_Pub_DataMoveLog SET End_Time=getDate(),Record_Count=@cCount,IsSuccess=1 WHERE ID=@logid
GO

