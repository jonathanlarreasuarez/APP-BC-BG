	CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NOT NULL
	)

	CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[SKU] [nvarchar](20) NULL,
	[Description] [nvarchar](250) NULL
	)

	CREATE TABLE [dbo].[ProductConfigs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[NetPrice] [decimal](18, 2) NOT NULL,
	[BatchDate] [datetime] NOT NULL,
	[Observation] [nvarchar](250) NULL)

    insert into Users values ('usuario_prueba','$2y$10$uA5eLAZ10XZ1AT.yRGBNVuc6LTdLEESu9MW30CNT3YUQKitPjmxgK','testuser@example.com',getdate())