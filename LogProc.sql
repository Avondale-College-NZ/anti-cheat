USE [Anticheat]
GO
/****** Object:  StoredProcedure [dbo].[LogProc]    Script Date: 18/09/2020 1:55:01 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROC [dbo].[LogProc] 
@ProcessName varchar(50),
@ProcessID varchar(50),
@ProcessHandle varchar(50)
AS
INSERT INTO tblProcesses(ProcessName,ProcessID,ProcessHandle)
VALUES (@ProcessName,@ProcessID,@ProcessHandle)
