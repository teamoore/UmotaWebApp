use UmoYAPI
go

alter table dbo.sis_kullanici
add WebSifre varchar(50) null;

use UmoYAPI_001
go

alter table dbo.proje
alter column [status] tinyint null;

