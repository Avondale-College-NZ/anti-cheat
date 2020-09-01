CREATE PROC [dbo].[LogProc] 
@ProcessName varchar(50),
@ProcessID int,
@ProcessHandle int,
@DateLogged smalldatetime
AS
INSERT INTO tblProcesses(ProcessName,ProcessID,ProcessHandle,DateLogged)
VALUES (@ProcessName,@ProcessID,@ProcessHandle,@DateLogged)
