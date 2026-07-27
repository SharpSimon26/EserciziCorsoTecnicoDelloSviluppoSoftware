insert into SalesAreas (SalesAreaName) (select distinct SalesArea from StagingSales);
insert into PaymentMethods (PaymentMethodName) (select distinct PaymentMethod from StagingSales);
insert into Regions (RegionName) (select distinct CustomerRegion from StagingSales);
insert into CustomerSegments (CustomerSegmentName) (select distinct CustomerSegment from StagingSales);
insert into OrderStatuses (OrderStatusName) (select distinct OrderStatus from StagingSales);
insert into Brands (BrandName) (select distinct Brand from StagingSales);
insert into Categories (CategoryName) (select distinct Category from StagingSales);
insert into SalesChannels (SalesChannelName) (select distinct SalesChannel from StagingSales);
