USE [Extrupet]
GO
/****** Object:  Table [dbo].[CompanySetup]    Script Date: 16-08-2021 7.06.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanySetup](
	[CompanyId] [tinyint] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Tel] [nvarchar](50) NOT NULL,
	[Fax] [nvarchar](50) NULL,
	[LastUpdatedOnUTC] [datetime] NOT NULL,
	[LastUpdatedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_CompanySetup] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeMaster]    Script Date: 16-08-2021 7.06.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeMaster](
	[GradeId] [tinyint] IDENTITY(1,1) NOT NULL,
	[GradeName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastUpdatedOnUTC] [datetime] NOT NULL,
	[LastUpdatedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_GradeMaster] PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeTypeMaster]    Script Date: 16-08-2021 7.06.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeTypeMaster](
	[GradeTypeId] [tinyint] IDENTITY(1,1) NOT NULL,
	[GradeType] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_GradeTypeMaster] PRIMARY KEY CLUSTERED 
(
	[GradeTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GradeWiseQualityParameterBaseData]    Script Date: 16-08-2021 7.06.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GradeWiseQualityParameterBaseData](
	[BaseDataId] [int] IDENTITY(1,1) NOT NULL,
	[GradeId] [tinyint] NOT NULL,
	[QualityParameterId] [smallint] NOT NULL,
	[BaseValue] [nvarchar](50) NOT NULL,
	[TestMethodId] [tinyint] NULL,
	[LastUpdatedOnUTC] [datetime] NOT NULL,
	[LastUpdatedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_GradeWiseQualityParameterBaseData] PRIMARY KEY CLUSTERED 
(
	[BaseDataId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductMaster]    Script Date: 16-08-2021 7.06.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductMaster](
	[ProductId] [uniqueidentifier] NOT NULL,
	[ProductName] [nvarchar](500) NOT NULL,
	[LastUpdatedOnUTC] [datetime] NOT NULL,
	[GradeTypeId] [tinyint] NOT NULL,
	[LastUpdatedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ProductMaster_1] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QualityMeasurementUnitMaster]    Script Date: 16-08-2021 7.06.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QualityMeasurementUnitMaster](
	[QualityMeasurementUnitId] [tinyint] IDENTITY(1,1) NOT NULL,
	[QualityMeasurementUnitName] [nvarchar](20) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_QualityMeasurementUnitMaster] PRIMARY KEY CLUSTERED 
(
	[QualityMeasurementUnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QualityParameterMaster]    Script Date: 16-08-2021 7.06.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QualityParameterMaster](
	[QualityParameterId] [smallint] IDENTITY(1,1) NOT NULL,
	[QualityParameterName] [nvarchar](50) NOT NULL,
	[QualityMeasurementUnitId] [tinyint] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastUpdatedOnUTC] [datetime] NOT NULL,
	[LastUpdatedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_QualityParameterMaster] PRIMARY KEY CLUSTERED 
(
	[QualityParameterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestMethodMaster]    Script Date: 16-08-2021 7.06.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestMethodMaster](
	[TestMethodId] [tinyint] IDENTITY(1,1) NOT NULL,
	[TestMethodName] [nvarchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TestMethodMaster] PRIMARY KEY CLUSTERED 
(
	[TestMethodId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMaster]    Script Date: 16-08-2021 7.06.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [tinyint] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[EmailId] [nvarchar](50) NULL,
	[EmployeeId] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastUpdatedOnUTC] [datetime] NOT NULL,
	[LastUpdatedBy] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_UserMaster_1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoleMaster]    Script Date: 16-08-2021 7.06.53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoleMaster](
	[RoleId] [tinyint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[RoleAlias] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserRoleMaster] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CompanySetup] ON 

INSERT [dbo].[CompanySetup] ([CompanyId], [CompanyName], [Address], [Tel], [Fax], [LastUpdatedOnUTC], [LastUpdatedBy]) VALUES (1, N'Extrupet', N'Test address', N'123456', N'123456', CAST(N'2021-08-16T00:00:00.000' AS DateTime), N'63c8fc78-59d2-418a-9b98-3c774d42b965')
SET IDENTITY_INSERT [dbo].[CompanySetup] OFF
GO
INSERT [dbo].[UserMaster] ([UserId], [RoleId], [FirstName], [LastName], [EmailId], [EmployeeId], [Password], [IsActive], [LastUpdatedOnUTC], [LastUpdatedBy]) VALUES (N'63c8fc78-59d2-418a-9b98-3c774d42b965', 1, N'Admin', N'Admin', N'a@a.com', N'AD001', N'1234', 1, CAST(N'2021-08-16T00:00:00.000' AS DateTime), N'63c8fc78-59d2-418a-9b98-3c774d42b965')
GO
SET IDENTITY_INSERT [dbo].[UserRoleMaster] ON 

INSERT [dbo].[UserRoleMaster] ([RoleId], [RoleName], [RoleAlias], [IsActive]) VALUES (1, N'Admin', N'Admin', 1)
INSERT [dbo].[UserRoleMaster] ([RoleId], [RoleName], [RoleAlias], [IsActive]) VALUES (2, N'Operator', N'Operator', 1)
INSERT [dbo].[UserRoleMaster] ([RoleId], [RoleName], [RoleAlias], [IsActive]) VALUES (3, N'LabTechnician', N'Lab Technician', 1)
SET IDENTITY_INSERT [dbo].[UserRoleMaster] OFF
GO
ALTER TABLE [dbo].[GradeMaster] ADD  CONSTRAINT [DF_GradeMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[QualityMeasurementUnitMaster] ADD  CONSTRAINT [DF_QualityMeasurementUnitMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[QualityParameterMaster] ADD  CONSTRAINT [DF_QualityParameterMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[TestMethodMaster] ADD  CONSTRAINT [DF_TestMethodMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[UserRoleMaster] ADD  CONSTRAINT [DF_UserRoleMaster_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GradeWiseQualityParameterBaseData]  WITH CHECK ADD  CONSTRAINT [FK_GradeWiseQualityParameterBaseData_GradeMaster] FOREIGN KEY([GradeId])
REFERENCES [dbo].[GradeMaster] ([GradeId])
GO
ALTER TABLE [dbo].[GradeWiseQualityParameterBaseData] CHECK CONSTRAINT [FK_GradeWiseQualityParameterBaseData_GradeMaster]
GO
ALTER TABLE [dbo].[GradeWiseQualityParameterBaseData]  WITH CHECK ADD  CONSTRAINT [FK_GradeWiseQualityParameterBaseData_QualityParameterMaster] FOREIGN KEY([QualityParameterId])
REFERENCES [dbo].[QualityParameterMaster] ([QualityParameterId])
GO
ALTER TABLE [dbo].[GradeWiseQualityParameterBaseData] CHECK CONSTRAINT [FK_GradeWiseQualityParameterBaseData_QualityParameterMaster]
GO
ALTER TABLE [dbo].[GradeWiseQualityParameterBaseData]  WITH CHECK ADD  CONSTRAINT [FK_GradeWiseQualityParameterBaseData_TestMethodMaster] FOREIGN KEY([TestMethodId])
REFERENCES [dbo].[TestMethodMaster] ([TestMethodId])
GO
ALTER TABLE [dbo].[GradeWiseQualityParameterBaseData] CHECK CONSTRAINT [FK_GradeWiseQualityParameterBaseData_TestMethodMaster]
GO
ALTER TABLE [dbo].[ProductMaster]  WITH CHECK ADD  CONSTRAINT [FK_ProductMaster_GradeTypeMaster] FOREIGN KEY([GradeTypeId])
REFERENCES [dbo].[GradeTypeMaster] ([GradeTypeId])
GO
ALTER TABLE [dbo].[ProductMaster] CHECK CONSTRAINT [FK_ProductMaster_GradeTypeMaster]
GO
ALTER TABLE [dbo].[QualityParameterMaster]  WITH CHECK ADD  CONSTRAINT [FK_QualityParameterMaster_QualityMeasurementUnitMaster] FOREIGN KEY([QualityMeasurementUnitId])
REFERENCES [dbo].[QualityMeasurementUnitMaster] ([QualityMeasurementUnitId])
GO
ALTER TABLE [dbo].[QualityParameterMaster] CHECK CONSTRAINT [FK_QualityParameterMaster_QualityMeasurementUnitMaster]
GO
ALTER TABLE [dbo].[UserMaster]  WITH CHECK ADD  CONSTRAINT [FK_UserMaster_UserRoleMaster] FOREIGN KEY([RoleId])
REFERENCES [dbo].[UserRoleMaster] ([RoleId])
GO
ALTER TABLE [dbo].[UserMaster] CHECK CONSTRAINT [FK_UserMaster_UserRoleMaster]
GO
