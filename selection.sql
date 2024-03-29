USE [Selection]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2019/5/13 11:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] NOT NULL,
	[CourseName] [nvarchar](50) NULL,
	[CourseType] [nvarchar](50) NULL,
	[IsEnd] [bit] NULL,
	[CourseTotal] [int] NULL,
	[CourseSel] [int] NULL,
	[CourseRemark] [nvarchar](50) NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SelCourse]    Script Date: 2019/5/13 11:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SelCourse](
	[SelId] [int] NOT NULL,
	[StuId] [int] NULL,
	[CourseId] [int] NULL,
	[Remark] [nvarchar](50) NULL,
 CONSTRAINT [PK_SelCourse] PRIMARY KEY CLUSTERED 
(
	[SelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentInfo]    Script Date: 2019/5/13 11:36:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentInfo](
	[StuId] [int] NOT NULL,
	[StuName] [nvarchar](50) NULL,
	[StuSex] [nvarchar](5) NULL,
	[StuAge] [int] NULL,
	[Profession] [nvarchar](50) NULL,
	[IsAdmin] [int] NULL,
	[StuIphone] [nvarchar](50) NULL,
	[StuQq] [nvarchar](50) NULL,
	[Remark] [nvarchar](50) NULL,
 CONSTRAINT [PK_StudentInfo] PRIMARY KEY CLUSTERED 
(
	[StuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [CourseType], [IsEnd], [CourseTotal], [CourseSel], [CourseRemark]) VALUES (0, N'net', N'keyi de kecheng ', NULL, 20, NULL, N'jisuanji')
INSERT [dbo].[Course] ([CourseId], [CourseName], [CourseType], [IsEnd], [CourseTotal], [CourseSel], [CourseRemark]) VALUES (1, N'java', N'jisuanji', NULL, 30, NULL, N'keyi de kecheng ')
INSERT [dbo].[Course] ([CourseId], [CourseName], [CourseType], [IsEnd], [CourseTotal], [CourseSel], [CourseRemark]) VALUES (2, N'大数据', N'地方', NULL, 10, NULL, N'数据')
INSERT [dbo].[Course] ([CourseId], [CourseName], [CourseType], [IsEnd], [CourseTotal], [CourseSel], [CourseRemark]) VALUES (3, N'Sql Server数据库', N'数据库相关', NULL, 10, NULL, N'数据')
INSERT [dbo].[SelCourse] ([SelId], [StuId], [CourseId], [Remark]) VALUES (0, 2, 1, NULL)
INSERT [dbo].[SelCourse] ([SelId], [StuId], [CourseId], [Remark]) VALUES (2, 2, 2, NULL)
INSERT [dbo].[SelCourse] ([SelId], [StuId], [CourseId], [Remark]) VALUES (3, 2, 2, NULL)
INSERT [dbo].[StudentInfo] ([StuId], [StuName], [StuSex], [StuAge], [Profession], [IsAdmin], [StuIphone], [StuQq], [Remark]) VALUES (1, N'wrx', N'man', 11, N'computer', 1, N'18813048831', N'627730788', N'remark')
INSERT [dbo].[StudentInfo] ([StuId], [StuName], [StuSex], [StuAge], [Profession], [IsAdmin], [StuIphone], [StuQq], [Remark]) VALUES (2, N'ft', N'wo', 12, N'manger', 0, N'18813048831', N'627730788', N'remark')
