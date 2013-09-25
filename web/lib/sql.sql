create proc dbo.sp_tblAuto_Question_Select_SelectByGameId_linhnx
@G_ID uniqueidentifier = null
as
select * from tblAuto_Question
where Q_G_ID=@G_ID
order by Q_ThuTu desc