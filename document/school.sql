/****** Object:  Table [dbo].[Member]    Script Date: 1/21/2020 12:56:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[SchoolNo] [nvarchar](50) NULL,
	[ParentId] [int] NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberPost]    Script Date: 1/21/2020 12:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberPost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Type] [int] NOT NULL,
	[Content] [nvarchar](max) NULL,
	[MemberId] [int] NOT NULL,
 CONSTRAINT [PK_MemberPost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberSubPost]    Script Date: 1/21/2020 12:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberSubPost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Content] [nvarchar](max) NULL,
	[MemberPostId] [int] NOT NULL,
 CONSTRAINT [PK_MemberSubPost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parent]    Script Date: 1/21/2020 12:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
 CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParentSchool]    Script Date: 1/21/2020 12:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentSchool](
	[ParentId] [int] NOT NULL,
	[SchoolId] [int] NOT NULL,
 CONSTRAINT [PK_ParentSchool] PRIMARY KEY CLUSTERED 
(
	[ParentId] ASC,
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School]    Script Date: 1/21/2020 12:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Adress] [nvarchar](500) NULL,
	[Logo] [nvarchar](500) NULL,
 CONSTRAINT [PK_School] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchoolDocument]    Script Date: 1/21/2020 12:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolDocument](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NULL,
	[Location] [nvarchar](500) NULL,
	[Content] [nvarchar](max) NULL,
	[TypeId] [int] NULL,
	[SchoolId] [int] NULL,
 CONSTRAINT [PK_SchoolDocument] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchoolDocumentType]    Script Date: 1/21/2020 12:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolDocumentType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_SchoolDocumentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchoolPost]    Script Date: 1/21/2020 12:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolPost](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) NULL,
	[Content] [nvarchar](max) NULL,
	[SchoolId] [int] NULL,
	[TypeId] [int] NULL,
 CONSTRAINT [PK_SchoolPost] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchoolPostType]    Script Date: 1/21/2020 12:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolPostType](
	[int] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
 CONSTRAINT [PK_SchoolPostType] PRIMARY KEY CLUSTERED 
(
	[int] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/21/2020 12:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [int] NULL,
	[UserName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](250) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSchool]    Script Date: 1/21/2020 12:56:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSchool](
	[UserId] [int] NOT NULL,
	[SchoolId] [int] NOT NULL,
 CONSTRAINT [PK_UserSchool] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[School] ON 

INSERT [dbo].[School] ([Id], [Title], [Adress], [Logo]) VALUES (1, N'Test', N'TEst adres', N'asdlkalks')
SET IDENTITY_INSERT [dbo].[School] OFF
ALTER TABLE [dbo].[Member]  WITH CHECK ADD  CONSTRAINT [FK_Member_Parent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Parent] ([Id])
GO
ALTER TABLE [dbo].[Member] CHECK CONSTRAINT [FK_Member_Parent]
GO
ALTER TABLE [dbo].[MemberPost]  WITH CHECK ADD  CONSTRAINT [FK_MemberPost_Member] FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([Id])
GO
ALTER TABLE [dbo].[MemberPost] CHECK CONSTRAINT [FK_MemberPost_Member]
GO
ALTER TABLE [dbo].[MemberSubPost]  WITH CHECK ADD  CONSTRAINT [FK_MemberSubPost_MemberPost] FOREIGN KEY([MemberPostId])
REFERENCES [dbo].[MemberPost] ([Id])
GO
ALTER TABLE [dbo].[MemberSubPost] CHECK CONSTRAINT [FK_MemberSubPost_MemberPost]
GO
ALTER TABLE [dbo].[ParentSchool]  WITH CHECK ADD  CONSTRAINT [FK_ParentSchool_Parent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Parent] ([Id])
GO
ALTER TABLE [dbo].[ParentSchool] CHECK CONSTRAINT [FK_ParentSchool_Parent]
GO
ALTER TABLE [dbo].[ParentSchool]  WITH CHECK ADD  CONSTRAINT [FK_ParentSchool_School] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([Id])
GO
ALTER TABLE [dbo].[ParentSchool] CHECK CONSTRAINT [FK_ParentSchool_School]
GO
ALTER TABLE [dbo].[SchoolDocument]  WITH CHECK ADD  CONSTRAINT [FK_SchoolDocument_School] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([Id])
GO
ALTER TABLE [dbo].[SchoolDocument] CHECK CONSTRAINT [FK_SchoolDocument_School]
GO
ALTER TABLE [dbo].[SchoolDocument]  WITH CHECK ADD  CONSTRAINT [FK_SchoolDocument_SchoolDocumentType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[SchoolDocumentType] ([Id])
GO
ALTER TABLE [dbo].[SchoolDocument] CHECK CONSTRAINT [FK_SchoolDocument_SchoolDocumentType]
GO
ALTER TABLE [dbo].[SchoolPost]  WITH CHECK ADD  CONSTRAINT [FK_SchoolPost_School] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([Id])
GO
ALTER TABLE [dbo].[SchoolPost] CHECK CONSTRAINT [FK_SchoolPost_School]
GO
ALTER TABLE [dbo].[SchoolPost]  WITH CHECK ADD  CONSTRAINT [FK_SchoolPost_SchoolPostType] FOREIGN KEY([TypeId])
REFERENCES [dbo].[SchoolPostType] ([int])
GO
ALTER TABLE [dbo].[SchoolPost] CHECK CONSTRAINT [FK_SchoolPost_SchoolPostType]
GO
ALTER TABLE [dbo].[UserSchool]  WITH CHECK ADD  CONSTRAINT [FK_UserSchool_School] FOREIGN KEY([SchoolId])
REFERENCES [dbo].[School] ([Id])
GO
ALTER TABLE [dbo].[UserSchool] CHECK CONSTRAINT [FK_UserSchool_School]
GO
ALTER TABLE [dbo].[UserSchool]  WITH CHECK ADD  CONSTRAINT [FK_UserSchool_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserSchool] CHECK CONSTRAINT [FK_UserSchool_User]
GO
