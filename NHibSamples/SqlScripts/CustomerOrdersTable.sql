--drop table dbo.CustomerOrders;
--go

create table dbo.CustomerOrders
(
    OrderId bigint primary key identity
    ,Comments varchar(max) not null default ''
    ,[Status] int not null default 0
    ,DatePlaced datetime not null default getdate()
    ,LastModified timestamp not null
);
go

insert into dbo.CustomerOrders (Comments, [Status])
values ('First', 0), ('Second', 0), ('Third', 0);
go

--select * from CustomerOrders;
--go
