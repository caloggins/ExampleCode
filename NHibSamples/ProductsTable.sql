--drop table dbo.Products;
--go

create table dbo.Products
(
	ProductId bigint primary key identity
	,[Name] varchar(255) not null default ''
	,[Description] varchar(max) not null default ''
	,[Type] int not null default 0
	,[IsActive] bit not null default 1
);
go

insert into dbo.Products ([Name], [Type])
values ('Coke', 1), ('Pepsi', 1), ('Orange Juice', 2);
go

select * from dbo.Products;
go