select * from Categories;

select distinct SalesChannel from StagingSales;

select * from Brands;

insert into SalesChannels (SalesChannelName) (select distinct SalesChannel from StagingSales);
