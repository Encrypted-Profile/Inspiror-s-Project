USE [ProjectManagementDatabase]
GO
/****** Object:  Table [dbo].[CourseRegistration]    Script Date: 5/1/2019 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseRegistration](
	[Serial] [int] IDENTITY(1,1) NOT NULL,
	[registrationCode] [int] NULL,
	[courseCode] [nvarchar](30) NULL,
	[Fee] [float] NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_CourseRegistration] PRIMARY KEY CLUSTERED 
(
	[Serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 5/1/2019 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmpId] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [nvarchar](7) NULL,
	[Email] [nchar](50) NULL,
	[Mobile] [nvarchar](15) NULL,
	[Type] [nvarchar](15) NULL,
	[Qualification] [nvarchar](25) NULL,
	[Address] [nvarchar](50) NULL,
	[Photo] [nvarchar](100) NULL,
	[JoiningDate] [date] NULL,
	[LeavingDate] [date] NULL,
	[Status] [bit] NULL,
	[Designation] [nvarchar](20) NULL,
	[LoginId] [nvarchar](20) NULL,
	[LoginPwd] [nvarchar](50) NULL,
	[Grade] [nvarchar](10) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Employee] UNIQUE NONCLUSTERED 
(
	[LoginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Expenditure]    Script Date: 5/1/2019 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expenditure](
	[Id] [int] NOT NULL,
	[LedgerId] [int] NULL,
	[Amount] [float] NULL,
	[Reason] [nvarchar](20) NULL,
	[Date] [date] NULL,
	[Note] [nvarchar](50) NULL,
	[Attachment] [nvarchar](50) NULL,
 CONSTRAINT [PK_Expenditure] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_Expenditure] UNIQUE NONCLUSTERED 
(
	[LedgerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Installments]    Script Date: 5/1/2019 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Installments](
	[serial] [int] IDENTITY(1,1) NOT NULL,
	[registrationCode] [int] NULL,
	[installmentDate] [date] NULL,
	[installmentMonth] [nvarchar](15) NULL,
	[installmentYear] [int] NULL,
	[Fee] [float] NULL,
	[paid] [bit] NULL,
	[nextInstallmentDate] [date] NULL,
 CONSTRAINT [PK_Installemnts] PRIMARY KEY CLUSTERED 
(
	[serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ledger]    Script Date: 5/1/2019 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ledger](
	[LedgerId] [int] NOT NULL,
	[EmpId] [nvarchar](20) NULL,
	[Credit] [float] NULL,
	[Debit] [float] NULL,
	[TotalAmount] [float] NULL,
	[Reason] [nvarchar](20) NULL,
	[Date] [date] NULL,
	[Note] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ledger] PRIMARY KEY CLUSTERED 
(
	[LedgerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payroll]    Script Date: 5/1/2019 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payroll](
	[Serial] [int] IDENTITY(1,1) NOT NULL,
	[TeacherCode] [nvarchar](20) NULL,
	[Month] [nvarchar](50) NULL,
	[Year] [int] NULL,
	[CashIn] [float] NULL,
	[CashOut] [float] NULL,
	[Balance]  AS ([CashIn]-[CashOut]),
	[ReceivingDate] [date] NULL,
	[ReceivingTime] [nvarchar](20) NULL,
	[Received] [bit] NULL,
 CONSTRAINT [PK_Payroll] PRIMARY KEY CLUSTERED 
(
	[Serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Registration]    Script Date: 5/1/2019 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[registrationCode] [int] IDENTITY(1,1) NOT NULL,
	[studentCode] [nvarchar](13) NULL,
	[registrationDate] [date] NULL,
	[registrationTime] [nvarchar](20) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[registrationCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 5/1/2019 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[classCode] [nvarchar](50) NOT NULL,
	[className] [nvarchar](50) NULL,
	[classTiming] [nvarchar](50) NULL,
	[classSubject] [nvarchar](50) NULL,
	[classTeacher] [nvarchar](50) NULL,
	[classTeacherPercentage] [float] NULL,
	[classFee] [float] NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[classCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 5/1/2019 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[studentCode] [nvarchar](10) NOT NULL,
	[studentName] [nvarchar](40) NULL,
	[studentFather] [nvarchar](40) NULL,
	[studentGender] [nvarchar](10) NULL,
	[studentMobile] [nvarchar](20) NULL,
	[studentEmail] [nvarchar](50) NULL,
	[studentAddress] [nvarchar](150) NULL,
	[studentEmergency] [nvarchar](20) NULL,
	[studentActive] [bit] NULL,
	[studentRegistrationDate] [date] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[studentCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TeacherInstallment]    Script Date: 5/1/2019 2:00:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherInstallment](
	[Serial] [int] IDENTITY(1,1) NOT NULL,
	[TeacherCode] [nvarchar](15) NULL,
	[InstallmentDate] [date] NULL,
	[InstallmentTime] [nvarchar](15) NULL,
	[CashIn] [float] NULL,
	[CashOut] [float] NULL,
	[Reason] [nvarchar](200) NULL,
	[Confirmed] [bit] NULL,
 CONSTRAINT [PK_TeacherInstallment] PRIMARY KEY CLUSTERED 
(
	[Serial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Expenditure]  WITH CHECK ADD  CONSTRAINT [FK_Expenditure_Ledger] FOREIGN KEY([LedgerId])
REFERENCES [dbo].[Ledger] ([LedgerId])
GO
ALTER TABLE [dbo].[Expenditure] CHECK CONSTRAINT [FK_Expenditure_Ledger]
GO
ALTER TABLE [dbo].[Ledger]  WITH CHECK ADD  CONSTRAINT [FK_Ledger_Employee] FOREIGN KEY([EmpId])
REFERENCES [dbo].[Employee] ([EmpId])
GO
ALTER TABLE [dbo].[Ledger] CHECK CONSTRAINT [FK_Ledger_Employee]
GO
