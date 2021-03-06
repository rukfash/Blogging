/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.4001)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/
USE [Blogging]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 05.02.2019 16:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[PostPk] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedAt] [datetime] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostTag]    Script Date: 05.02.2019 16:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostTag](
	[PostTagPk] [int] IDENTITY(1,1) NOT NULL,
	[PostFk] [int] NOT NULL,
	[TagFk] [int] NOT NULL,
 CONSTRAINT [PK_PostTag] PRIMARY KEY CLUSTERED 
(
	[PostTagPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 05.02.2019 16:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[TagPk] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[TagPk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([PostPk], [Slug], [Title], [Description], [Body], [CreatedAt], [UpdatedAt]) VALUES (1, N'augmented-reality-ios-application', N'Augmented Reality iOS Application', N'Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.', N'The app is simple to use, and will help you decide on your best furniture fit.', CAST(N'2019-02-05T14:57:49.430' AS DateTime), CAST(N'2019-02-05T16:36:36.980' AS DateTime))
INSERT [dbo].[Post] ([PostPk], [Slug], [Title], [Description], [Body], [CreatedAt], [UpdatedAt]) VALUES (2, N'augmented-reality-ios-application-2', N'Augmented Reality iOS Application 2', N'Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.', N'The app is simple to use, and will help you decide on your best furniture fit.', CAST(N'2019-02-05T14:56:49.430' AS DateTime), NULL)
INSERT [dbo].[Post] ([PostPk], [Slug], [Title], [Description], [Body], [CreatedAt], [UpdatedAt]) VALUES (30, N'Augmented-Reality-iOS-Application-3', N'Augmented Reality iOS Application', N'Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.', N'The app is simple to use, and will help you decide on your best furniture fit.', CAST(N'2019-02-05T16:37:41.273' AS DateTime), NULL)
INSERT [dbo].[Post] ([PostPk], [Slug], [Title], [Description], [Body], [CreatedAt], [UpdatedAt]) VALUES (31, N'augmented-reality-ios-application-4', N'Augmented Reality iOS Application', N'Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.', N'The app is simple to use, and will help you decide on your best furniture fit.', CAST(N'2019-02-05T16:38:24.953' AS DateTime), NULL)
INSERT [dbo].[Post] ([PostPk], [Slug], [Title], [Description], [Body], [CreatedAt], [UpdatedAt]) VALUES (32, N'augmented-reality-ios-application-5', N'Augmented Reality iOS Application', N'Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.', N'The app is simple to use, and will help you decide on your best furniture fit.', CAST(N'2019-02-05T16:39:22.067' AS DateTime), NULL)
INSERT [dbo].[Post] ([PostPk], [Slug], [Title], [Description], [Body], [CreatedAt], [UpdatedAt]) VALUES (33, N'augmented-reality-ios-application-6', N'Augmented Reality iOS Application', N'Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.', N'The app is simple to use, and will help you decide on your best furniture fit.', CAST(N'2019-02-05T16:39:38.110' AS DateTime), NULL)
INSERT [dbo].[Post] ([PostPk], [Slug], [Title], [Description], [Body], [CreatedAt], [UpdatedAt]) VALUES (34, N'augmented-reality-ios-application-7', N'Augmented Reality iOS Application', N'Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.', N'The app is simple to use, and will help you decide on your best furniture fit.', CAST(N'2019-02-05T16:39:40.413' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Post] OFF
SET IDENTITY_INSERT [dbo].[PostTag] ON 

INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (3, 2, 1)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (4, 2, 2)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (5, 2, 3)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (24, 1, 3)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (94, 1, 1)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (95, 30, 1)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (96, 30, 10)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (97, 31, 1)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (98, 31, 10)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (99, 32, 1)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (100, 32, 10)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (101, 33, 1)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (102, 33, 10)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (103, 34, 1)
INSERT [dbo].[PostTag] ([PostTagPk], [PostFk], [TagFk]) VALUES (104, 34, 10)
SET IDENTITY_INSERT [dbo].[PostTag] OFF
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([TagPk], [TagName]) VALUES (1, N'iOS')
INSERT [dbo].[Tag] ([TagPk], [TagName]) VALUES (2, N'AR')
INSERT [dbo].[Tag] ([TagPk], [TagName]) VALUES (3, N'Gazzda')
INSERT [dbo].[Tag] ([TagPk], [TagName]) VALUES (10, N'VR')
SET IDENTITY_INSERT [dbo].[Tag] OFF
ALTER TABLE [dbo].[PostTag]  WITH CHECK ADD  CONSTRAINT [FK_PostTag_Post] FOREIGN KEY([PostFk])
REFERENCES [dbo].[Post] ([PostPk])
GO
ALTER TABLE [dbo].[PostTag] CHECK CONSTRAINT [FK_PostTag_Post]
GO
ALTER TABLE [dbo].[PostTag]  WITH CHECK ADD  CONSTRAINT [FK_PostTag_Tag] FOREIGN KEY([TagFk])
REFERENCES [dbo].[Tag] ([TagPk])
GO
ALTER TABLE [dbo].[PostTag] CHECK CONSTRAINT [FK_PostTag_Tag]
GO
