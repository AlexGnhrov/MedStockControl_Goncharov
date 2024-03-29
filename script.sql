USE [master]
GO
/****** Object:  Database [user85]    Script Date: 24.11.2022 10:27:14 ******/
CREATE DATABASE [user85]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'user85', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\user85.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'user85_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\user85_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [user85] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [user85].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [user85] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [user85] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [user85] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [user85] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [user85] SET ARITHABORT OFF 
GO
ALTER DATABASE [user85] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [user85] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [user85] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [user85] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [user85] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [user85] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [user85] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [user85] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [user85] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [user85] SET  ENABLE_BROKER 
GO
ALTER DATABASE [user85] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [user85] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [user85] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [user85] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [user85] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [user85] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [user85] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [user85] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [user85] SET  MULTI_USER 
GO
ALTER DATABASE [user85] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [user85] SET DB_CHAINING OFF 
GO
ALTER DATABASE [user85] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [user85] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [user85] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [user85] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [user85] SET QUERY_STORE = OFF
GO
USE [user85]
GO
/****** Object:  Table [dbo].[Stuff]    Script Date: 24.11.2022 10:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stuff](
	[StuffID] [int] IDENTITY(1,1) NOT NULL,
	[NameStuff] [nvarchar](50) NOT NULL,
	[ManufacterID] [int] NOT NULL,
	[Composition] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Indication] [nvarchar](max) NOT NULL,
	[Contraindication] [nvarchar](max) NOT NULL,
	[PharmacoGroupID] [int] NOT NULL,
	[MethodUsage] [nvarchar](max) NOT NULL,
	[SideEffects] [nvarchar](max) NOT NULL,
	[Overdose] [nvarchar](max) NOT NULL,
	[Interaction] [nvarchar](max) NOT NULL,
	[SpecInstruct] [nvarchar](max) NOT NULL,
	[StorageСondition] [nvarchar](max) NOT NULL,
	[ReleaseForm] [nvarchar](max) NOT NULL,
	[DateOfRelease] [date] NOT NULL,
	[ExpirationDate] [date] NULL,
	[СonditionDispensingID] [int] NOT NULL,
	[Amount] [int] NULL,
 CONSTRAINT [PK_Stuff] PRIMARY KEY CLUSTERED 
(
	[StuffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[СonditionDispensing]    Script Date: 24.11.2022 10:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[СonditionDispensing](
	[СonditionDispensingID] [int] IDENTITY(1,1) NOT NULL,
	[NameCondtion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_СonditionDispensing] PRIMARY KEY CLUSTERED 
(
	[СonditionDispensingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PharmacoGroup]    Script Date: 24.11.2022 10:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PharmacoGroup](
	[PharmacoGroupID] [int] IDENTITY(1,1) NOT NULL,
	[NameGroup] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PharmacoGroup] PRIMARY KEY CLUSTERED 
(
	[PharmacoGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacter]    Script Date: 24.11.2022 10:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacter](
	[ManufacterID] [int] IDENTITY(1,1) NOT NULL,
	[NameManufacter] [nvarchar](60) NOT NULL,
	[FirstNameResponPerson] [nvarchar](30) NOT NULL,
	[SecondNameResponPerson] [nvarchar](30) NOT NULL,
	[LastNameResponPerson] [nvarchar](30) NULL,
	[PhoneNumber] [nvarchar](17) NOT NULL,
 CONSTRAINT [PK_Manufacter] PRIMARY KEY CLUSTERED 
(
	[ManufacterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewStuff]    Script Date: 24.11.2022 10:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewStuff]
AS
SELECT        dbo.Stuff.StuffID, dbo.Stuff.NameStuff, dbo.Manufacter.NameManufacter, dbo.Stuff.Composition, dbo.Stuff.Description, dbo.Stuff.Indication, dbo.Stuff.Contraindication, dbo.PharmacoGroup.NameGroup, dbo.Stuff.MethodUsage, 
                         dbo.Stuff.SideEffects, dbo.Stuff.Overdose, dbo.Stuff.Interaction, dbo.Stuff.SpecInstruct, dbo.Stuff.StorageСondition, dbo.Stuff.ReleaseForm, dbo.Stuff.DateOfRelease, dbo.Stuff.ExpirationDate, 
                         dbo.СonditionDispensing.NameCondtion, dbo.Stuff.Amount
FROM            dbo.Manufacter INNER JOIN
                         dbo.Stuff ON dbo.Manufacter.ManufacterID = dbo.Stuff.ManufacterID INNER JOIN
                         dbo.PharmacoGroup ON dbo.Stuff.PharmacoGroupID = dbo.PharmacoGroup.PharmacoGroupID INNER JOIN
                         dbo.СonditionDispensing ON dbo.Stuff.СonditionDispensingID = dbo.СonditionDispensing.СonditionDispensingID
GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 24.11.2022 10:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[FirstNameStaff] [nvarchar](30) NOT NULL,
	[SecondNameStaff] [nvarchar](30) NOT NULL,
	[LastNameStaff] [nvarchar](30) NULL,
	[PhoneNumStaff] [nvarchar](17) NOT NULL,
	[PositionStaffID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_Staffs] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionStaff]    Script Date: 24.11.2022 10:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionStaff](
	[PositionStaffID] [int] IDENTITY(1,1) NOT NULL,
	[NamePosition] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_PositionStaff] PRIMARY KEY CLUSTERED 
(
	[PositionStaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 24.11.2022 10:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(4,1) NOT NULL,
	[Login_User] [nvarchar](30) NOT NULL,
	[Password_User] [nvarchar](50) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewStaff]    Script Date: 24.11.2022 10:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewStaff]
AS
SELECT        dbo.Staffs.StaffID, dbo.Staffs.FirstNameStaff, dbo.Staffs.SecondNameStaff, dbo.Staffs.LastNameStaff, dbo.Staffs.PhoneNumStaff, dbo.PositionStaff.NamePosition, dbo.[User].Login_User
FROM            dbo.Staffs INNER JOIN
                         dbo.PositionStaff ON dbo.Staffs.PositionStaffID = dbo.PositionStaff.PositionStaffID INNER JOIN
                         dbo.[User] ON dbo.Staffs.UserID = dbo.[User].UserID
GO
/****** Object:  Table [dbo].[Role]    Script Date: 24.11.2022 10:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Manufacter] ON 

INSERT [dbo].[Manufacter] ([ManufacterID], [NameManufacter], [FirstNameResponPerson], [SecondNameResponPerson], [LastNameResponPerson], [PhoneNumber]) VALUES (3, N'ТАТХИМФАРМПРЕПАРАТЫ ', N'Александр', N'Гончаров', N'Дмитриевич', N'8-800-555-35-35')
INSERT [dbo].[Manufacter] ([ManufacterID], [NameManufacter], [FirstNameResponPerson], [SecondNameResponPerson], [LastNameResponPerson], [PhoneNumber]) VALUES (4, N'ФАРМСТАНДАРТ-ЛЕКСРЕДСТВА', N'Алексей', N'Кановалов', N'', N'7-032-323-132-33')
INSERT [dbo].[Manufacter] ([ManufacterID], [NameManufacter], [FirstNameResponPerson], [SecondNameResponPerson], [LastNameResponPerson], [PhoneNumber]) VALUES (5, N'РЖАКАЭНТЕРПРАЙЗ', N'Илья', N'Балобанов', N'Юрьевич', N'7-432-423-32-12')
SET IDENTITY_INSERT [dbo].[Manufacter] OFF
GO
SET IDENTITY_INSERT [dbo].[PharmacoGroup] ON 

INSERT [dbo].[PharmacoGroup] ([PharmacoGroupID], [NameGroup]) VALUES (1, N'НПВП')
INSERT [dbo].[PharmacoGroup] ([PharmacoGroupID], [NameGroup]) VALUES (3, N'Анальгетическое ненаркотическое средство')
INSERT [dbo].[PharmacoGroup] ([PharmacoGroupID], [NameGroup]) VALUES (5, N'Анальгезирующее средство ')
SET IDENTITY_INSERT [dbo].[PharmacoGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[PositionStaff] ON 

INSERT [dbo].[PositionStaff] ([PositionStaffID], [NamePosition]) VALUES (1, N'Администратотр')
INSERT [dbo].[PositionStaff] ([PositionStaffID], [NamePosition]) VALUES (2, N'Работник')
INSERT [dbo].[PositionStaff] ([PositionStaffID], [NamePosition]) VALUES (3, N'Зам. Начальник')
SET IDENTITY_INSERT [dbo].[PositionStaff] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Администратор')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Работник')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([StaffID], [FirstNameStaff], [SecondNameStaff], [LastNameStaff], [PhoneNumStaff], [PositionStaffID], [UserID]) VALUES (1, N'Александр', N'Гончаров', N'Дмитриевич', N'7-916-866-38-19', 1, 1)
INSERT [dbo].[Staffs] ([StaffID], [FirstNameStaff], [SecondNameStaff], [LastNameStaff], [PhoneNumStaff], [PositionStaffID], [UserID]) VALUES (2, N'Олег', N'Олегов', N'Олегович', N'8-800-555-35-35', 3, 2)
INSERT [dbo].[Staffs] ([StaffID], [FirstNameStaff], [SecondNameStaff], [LastNameStaff], [PhoneNumStaff], [PositionStaffID], [UserID]) VALUES (3, N'Александр', N'Пистолетов', NULL, N'7-913-312-32-32', 2, 3)
INSERT [dbo].[Staffs] ([StaffID], [FirstNameStaff], [SecondNameStaff], [LastNameStaff], [PhoneNumStaff], [PositionStaffID], [UserID]) VALUES (4, N'Олег', N'Некрасов', N'Валентинович', N'7-322-222-11-31', 2, 6)
SET IDENTITY_INSERT [dbo].[Staffs] OFF
GO
SET IDENTITY_INSERT [dbo].[Stuff] ON 

INSERT [dbo].[Stuff] ([StuffID], [NameStuff], [ManufacterID], [Composition], [Description], [Indication], [Contraindication], [PharmacoGroupID], [MethodUsage], [SideEffects], [Overdose], [Interaction], [SpecInstruct], [StorageСondition], [ReleaseForm], [DateOfRelease], [ExpirationDate], [СonditionDispensingID], [Amount]) VALUES (1, N'Ибупрофен', 3, N'Вспомогательные вещества: крахмал картофельный 38 мг, магния стеарат 2 мг, кремния диоксид коллоидный (аэросил) 3.35 мг, ванилин 1.5 мкг, воск пчелиный 20 мкг, желатин пищевой 320 мкг, краситель азорубин 8.5 мкг, магния гидроксикарбонат 39.57 мг, мука пшеничная 17.37 мг, повидон низкомолекулярный 1.5 мг, сахароза 144.96 мг, титана диоксид 2.9 мг.', N'Известное обезболивающее', N'воспалительные заболевания суставов и позвоночника (в т.ч. ревматоидный артрит, анкилозирующий спондилоартрит, остеоартроз, подагрический артрит);
умеренный болевой синдром различной этиологии (в т.ч. головная боль, мигрень, зубная боль, невралгия, миалгия, послеоперационные боли, посттравматические боли, первичная альгодисменорея);
лихорадочный синдром при "простудных" и инфекционных заболеваниях;
предназначен для симптоматической терапии, уменьшения боли и воспаления на момент использования, на прогрессирование заболевания не влияет.П', N'гиперчувствительность к любому из ингредиентов, входящих в состав препарата. Гиперчувствительность к ацетилсалициловой кислоте или другим НПВП в т.ч. анамнестические данные о приступе бронхообструкции, ринита, крапивницы после приема ацетилсалициловой кислоты или иного НПВП; полный или неполный синдром непереносимости ацетилсалициловой кислоты (риносинусит, крапивница, полипы слизистой носа, бронхиальная астма);
эрозивно-язвенные заболевания органов желудочно-кишечного тракта в стадии обострения (в том числе язвенная болезнь желудка и двенадцатиперстной кишки, болезнь Крона, неспецифический язвенный колит);
воспалительные заболевания кишечника;
гемофилия и другие нарушения свертываемости крови (в том числе гипокоагуляция), геморрагические диатезы;
период после проведения аортокоронарного шунтирования;
желудочно-кишечные кровотечения и внутричерепные кровоизлияния;
выраженная печеночная недостаточность или активное заболевание печени;
прогрессирующие заболевания почек;
выраженная почечная недостаточность с клиренсом креатинина менее 30 мл/мин, подтвержденная гиперкалиемия;
беременность;
детский возраст до 6 лет.
С осторожностью. Пожилой возраст, сердечная недостаточность, артериальная гипертензия, ишемическая болезнь сердца, цереброваскулярные заболевания, дислипидемия, сахарный диабет, заболевания периферических артерий, курение, частое употребление алкоголя, цирроз печени с портальной гипертензией, печеночная и/или почечная недостаточность с клиренсом креатинина менее 60 мл/мин, нефротический синдром, гипербилирубинемия, язвенная болезнь желудка и двенадцатиперстной кишки (в анамнезе), наличие инфекции Н. Pylori, гастрит, энтерит, колит, заболевания крови неясной этиологии (лейкопения и анемия), период лактации, длительное использование НПВП, тяжелые соматические заболеваения, одновременный прием пероральных ГКС (в.т.ч преднизолон), антикоагулянтов (в т.ч. варфарин), антиагрегантов (в т.ч. ацетилсалициловая кислота, клопидогрел), селективных ингибиторов обратного захвата серотонина (в т.ч. циталопрам, флуоксетин, пароксетин, сертралин).', 1, N'Ибупрофен назначают взрослым и детям старше 12 лет внутрь, в таблетках по 200 мг 3-4 раза в сут. Для достижения быстрого терапевтического эффекта доза может быть увеличена до 400 мг (2 таблетки) 3 раза в сут. При достижении лечебного эффекта суточную дозу препарата уменьшают до 600-800 мг. Утреннюю дозу принимают до еды, запивая достаточным количеством воды (для более быстрого всасывания препарата). Остальные дозы принимают на протяжении дня после еды.

Максимальная суточная доза составляет 1200 мг (не принимать больше 6 таблеток за 24 ч). Повторную дозу принимать не чаще, чем через 4 ч. Длительность использования препарата без консультации врача не более 5 дней.

Не применять у детей моложе 12 лет без консультации врача.

Детям от 6 до 12 лет: по 1 таблетке не более 4 раз в день; препарат может использоваться только в случае массы тела ребенка более 20 кг. Интервал между приемом таблеток не менее 6 ч (суточная доза не более 30 мг/кг).', N'Желудочно-кишечный тракт (ЖКТ): НПВП-гастропатия (абдоминальные боли, тошнота, рвота, изжога, снижение аппетита, диарея, метеоризм, запор; редко - изъязвления слизистой оболочки ЖКТ, которые в ряде случаев осложняются перфорацией и кровотечениями); раздражение или сухость слизистой ротовой полости, боль во рту, изъязвление слизистой десен, афтозный стоматит, панкреатит.

Гепато-билиарная система: гепатит.

Дыхательная система: одышка, бронхоспазм.

Органы чувств: нарушения слуха: снижение слуха, звон или шум в ушах; нарушения зрения: токсическое поражение зрительного нерва, неясное зрение или двоение, скотома, сухость и раздражение глаз, отек конъюнктивы и век (аллергического генеза).

Центральная и периферическая нервная система: головная боль, головокружение, бессонница, тревожность, нервозность и раздражительность, психомоторное возбуждение, сонливость, депрессия, спутанность сознания, галлюцинации, редко - асептический менингит (чаще у пациентов с аутоиммунными заболеваниями).

Сердечно-сосудистая система: сердечная недостаточность, тахикардия, повышение артериального давления.

Мочевыделительная система: острая почечная недостаточность, аллергический нефрит, нефротический синдром (отеки), полиурия, цистит.

Аллергические реакции: кожная сыпь (обычно эритематозная или крапивница), кожный зуд, отек Квинке, анафилактоидные реакции, анафилактический шок, бронхоспазм или диспноэ, лихорадка, многоформная экссудативная эритема (в том числе синдром Стивенса-Джонсона), токсический эпидермальный некролиз (синдром Лайелла), эозинофилия, аллергический ринит.

Органы кроветворения: анемия (в т.ч. гемолитическая, апластическая), тромбоцитопения и тромбоцитопеническая пурпура, агранулоцитоз, лейкопения.

Прочие: усиление потоотделения.

Риск развития изъязвлений слизистой оболочки желудочно-кишечного тракта, кровотечения (желудочно-кишечного, десневого, маточного, геморроидального), нарушений зрения (нарушения цветового зрения, скотомы, амблиопии) возрастает при длительном применении в больших дозах.

Лабораторные показатели:

время кровотечения (может увеличиваться);
концентрация глюкозы в сыворотке (может снижаться);
клиренс креатинина (может уменьшаться);
гематокрит или гемоглобин (могут уменьшаться);
сывороточная концентрация креатинина (может увеличиваться);
активность «печеночных» трансаминаз (может повышаться).
При появлении побочных эффектов следует прекратить прием препарата и обратиться к врачу.

', N'Симптомы: боли в животе, тошнота, рвота, заторможенность, сонливость, депрессия, головная боль, шум в ушах, метаболический ацидоз, кома, острая почечная недостаточность, снижение артериального давления, брадикардия, тахикардия, фибрилляция предсердий, остановка дыхания.

Лечение: промывание желудка (только в течение 1 ч после приема), активированный уголь, щелочное питье, форсированный диурез, симптоматическая терапия.', N'Не рекомендуется одновременный прием ибупрофена с ацетилсалициловой кислотой и другими НПВП. При одновременном назначении ибупрофен снижает противовоспалительное и антиагрегантное действие ацетилсалициловой кислоты (возможно повышение частоты развития острой коронарной недостаточности у больных, получающих в качестве антиагрегантного средства малые дозы ацетилсалициловой кислоты, после начала приема ибупрофена). При назначении с антикоагулянтными и тромболитическими лекарственными средствами (алтеплазой, стрептокиназой, урокиназой) одновременно повышается риск развития кровотечений. Одновременный прием с ингибиторами обратного захвата серотонина (циталопрам, флуоксетин, пароксетин, сертралин) повышает риск развития серьезных ЖКТ кровотечений.

Цефамандол, цефаперазон, цефотетан, вальпроевая кислота, пликамицин, увеличивают частоту развития гипопротромбинемии. Циклоспорин и препараты золота усиливают влияние ибупрофена на синтез простагландинов в почках, что проявляется повышением нефротоксичности. Ибупрофен повышает плазменную концентрацию циклоспорина и вероятность развития его гепатотоксических эффектов. Лекарственные средства, блокирующие канальцевую секрецию, снижают выведение и повышают плазменную концентрацию ибупрофена. Индукторы микросомального окисления (фенитоин, этанол, барбитураты, рифампицин, фенилбутазон, трициклические антидепрессанты) увеличивают продукцию гидроксилированных активных метаболитов, повышая риск развития тяжелых интоксикаций. Ингибиторы микросомального окисления - снижают риск гепатотоксического действия. Снижает гипотензивную активность вазодилататоров, натрийуретическую и диуретическую активность у фуросемида и гидрохлортиазида. Снижает эффективность урикозурических препаратов, усиливает действие непрямых антикоагулянтов, антиагрегантов, фибринолитиков (повышение риска появления геморрагических расстройств), усиливает ульцерогенное действие с кровотечениями минералокортикостероидов, глюкокортикостероидов, колхицина, эстрогенов, этанола. Усиливает эффект пероральных гипогликемических лекарственных средств и инсулина, производных сульфонилмочевины. Антациды и колестирамин снижают абсорбцию. Увеличивает концентрацию в крови дигоксина, препаратов лития, метотрексата. Кофеин усиливает анальгезирующий эффект.', N'Лечение препаратом следует проводить в минимальной эффективной дозе, минимально возможным коротким курсом. Во время длительного лечения необходим контроль картины периферической крови и функционального состояния печени и почек. При появлении симптомов гастропатии показан тщательный контроль, включающий проведение эзофагогастродуоденоскопии, общий анализ крови (определение гемоглобина), анализ кала на скрытую кровь.

При необходимости определения 17-кетостероидов препарат следует отменить за 48 ч до исследования.

Больные должны воздерживаться от всех видов деятельности, требующих повышенного внимания, быстрой психической и двигательной реакции. В период лечения не рекомендуется прием этанола.', N'В сухом месте, при температуре не выше 25°С. Хранить в недоступном для детей месте!', N'Таблетки, покрытые оболочкой от светло-розового до розового цвета, круглые, двояковыпуклые; на поперечном разрезе видны два слоя: ядро белого цвета и оболочка от светло-розового до розового цвета.', CAST(N'2020-11-09' AS Date), CAST(N'2024-11-09' AS Date), 1, 40)
INSERT [dbo].[Stuff] ([StuffID], [NameStuff], [ManufacterID], [Composition], [Description], [Indication], [Contraindication], [PharmacoGroupID], [MethodUsage], [SideEffects], [Overdose], [Interaction], [SpecInstruct], [StorageСondition], [ReleaseForm], [DateOfRelease], [ExpirationDate], [СonditionDispensingID], [Amount]) VALUES (19, N'Пенталгин', 4, N'парацетамол 325 мг, напроксен 100 мг, кофеин 50 мг, дротаверина гидрохлорид 40 мг, фенирамина малеат 10 мг', N'Основано на официальной инструкции по применению препарата, утверждено компанией-производителем и подготовлено для печатного издания справочника Видаль 2017 года.', N'болевой синдром различного генеза, в т.ч. боли в суставах, мышцах, радикулит, альгодисменорея, невралгия, зубная боль, головная боль (в т.ч. обусловленная спазмом сосудов головного мозга);', N'эрозивно-язвенные поражения ЖКТ в фазе обострения', 5, N'Препарат назначают внутрь по 1 таб. 1-3 раза/сут. Максимальная суточная доза - 4 таб.', N'Аллергические реакции: кожная сыпь, зуд, крапивница, ангионевротический отек.', N'Симптомы: бледность кожных покровов, анорексия (отсутствие аппетита), боль в животе, тошнота, рвота, желудочно-кишечное кровотечение, возбуждение, двигательное беспокойство, спутанность сознания, тахикардия, аритмия, гипертермия (повышение температуры тела), учащенное мочеиспускание, головная боль, тремор или мышечные подергивания; эпилептические припадки, повышение активности печеночных трансаминаз, гепатонекроз, увеличение протромбинового времени. Симптомы нарушения функции печени могут появиться через 12-48 ч после передозировки. При тяжелой передозировке развивается печеночная недостаточность с прогрессирующей энцефалопатией, кома, летальный исход; острая почечная недостаточность с тубулярным некрозом; аритмия, панкреатит. При подозрении на передозировку необходимо немедленно обратиться за врачебной помощью.', N'При одновременном приеме препарата Пенталгин® с барбитуратами, трициклическими антидепрессантами, рифампицином, этанолом увеличивается риск гепатотоксического действия (данных комбинаций следует избегать).', N'Следует избегать одновременного применения препарата Пенталгин® с другими средствами, содержащими парацетамол и/или НПВС, а также со средствами для облегчения симптомов простуды, гриппа и заложенности носа.', N'Хранить при температуре не выше 25°С. Хранить в недоступном для детей месте', N'Таблетки, покрытые пленочной оболочкой от светло-зеленого до зеленого цвета, двояковыпуклые, в форме капсулы со скошенными краями, с риской на одной стороне и тиснением "PENTALGIN" - на другой; на срезе таблетка светло-зеленого с цвета с белыми вкраплениями.', CAST(N'2020-01-21' AS Date), CAST(N'2022-01-21' AS Date), 1, 16)
INSERT [dbo].[Stuff] ([StuffID], [NameStuff], [ManufacterID], [Composition], [Description], [Indication], [Contraindication], [PharmacoGroupID], [MethodUsage], [SideEffects], [Overdose], [Interaction], [SpecInstruct], [StorageСondition], [ReleaseForm], [DateOfRelease], [ExpirationDate], [СonditionDispensingID], [Amount]) VALUES (21, N'Анальгин', 3, N'Метамизол натрия', N'Препарат от головной боли', N'Болевой синдром различного генеза (почечная и желчная колика, невралгия, миалгия; при травмах, ожогах, после операций; головная боль, зубная боль, меналгии). Лихорадка при инфекционно-воспалительных заболеваниях.', N'Повышенная чувствительность к метамизолу натрия и другим производным пиразолона, а также к пиразолидинам, например, фенилбутазону (включая пациентов, перенесших агранулоцитоз вследствие применения этих препаратов); анальгетическая бронхиальная астма или непереносимость анальгетиков (по типу крапивница-ангионевротический отек), т.е. пациенты с бронхоспазмом или другими формами анафилактоидных реакций (например, крапивница, ринит, ангионевротический отек) в ответ на применение салицилатов, парацетамола или НПВС, таких как диклофенак, ибупрофен, индометацин или напроксен; нарушение костномозгового кроветворения (например, после цитостатической терапии) или заболевания органов кроветворения; наследственный дефицит глюкозо-6-фосфатдегидрогеназы (гемолиз); острая интермиттирующая печеночная порфирия (риск развития приступов порфирии); беременность (для парентерального применения - I и III триместр), период грудного вскармливания; детский возраст - различные возрастные категории в зависимости от лекарственной формы и способа введения; для парентерального применения - острая почечная или печеночная недостаточность.', 3, N'Применяют внутрь, в/м и в/в медленно. Дозу, способ и схему применения, длительность применения определяют индивидуально, в зависимости от показаний, клинической ситуации, лекарственной формы и возраста пациента.', N'Со стороны сердечно-сосудистой системы: нечасто - изолированная артериальная гипотензия. После приема метамизола натрия возможно изолированное транзиторное снижение АД (возможно фармакологически обусловленное и не сопровождающееся другими проявлениями анафилактических/анафилактоидных реакций); в редких случаях снижение АД может быть очень резко выраженным; при лихорадке также возможно дозозависимое резкое снижение АД без других признаков реакции гиперчувствительности; частота неизвестна - синдром Коуниса (аллергический коронарный синдром, проявляется клиническими и лабораторными признаками стенокардии, вызванной медиаторами воспаления).', N'Отсутствует', N'Метамизол натрия может вызывать снижение концентрации циклоспорина в плазме, поэтому при их одновременном применении следует контролировать концентрацию циклоспорина.', N'При лечении больных, получающих цитостатические средства, а также детей в возрасте до 5 лет, лечение метамизолом натрия должно проводиться только под наблюдением врача.', N'Хранить в сухом месте', N'10 шт. - упаковки ячейковые контурные.', CAST(N'2021-11-22' AS Date), CAST(N'2023-11-22' AS Date), 1, 30)
SET IDENTITY_INSERT [dbo].[Stuff] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [Login_User], [Password_User], [RoleID]) VALUES (1, N'Admin', N'123', 1)
INSERT [dbo].[User] ([UserID], [Login_User], [Password_User], [RoleID]) VALUES (2, N'Employee', N'321', 2)
INSERT [dbo].[User] ([UserID], [Login_User], [Password_User], [RoleID]) VALUES (3, N'Alex', N'777', 2)
INSERT [dbo].[User] ([UserID], [Login_User], [Password_User], [RoleID]) VALUES (4, N'Oleg', N'555', 2)
INSERT [dbo].[User] ([UserID], [Login_User], [Password_User], [RoleID]) VALUES (6, N'Oleg2', N'OlegKrut2', 2)
INSERT [dbo].[User] ([UserID], [Login_User], [Password_User], [RoleID]) VALUES (7, N'321', N'123', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[СonditionDispensing] ON 

INSERT [dbo].[СonditionDispensing] ([СonditionDispensingID], [NameCondtion]) VALUES (1, N'Препарат разрешен к применению в качестве средства безрецептурного отпуска.')
INSERT [dbo].[СonditionDispensing] ([СonditionDispensingID], [NameCondtion]) VALUES (2, N'Только по рецепту')
SET IDENTITY_INSERT [dbo].[СonditionDispensing] OFF
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_PositionStaff] FOREIGN KEY([PositionStaffID])
REFERENCES [dbo].[PositionStaff] ([PositionStaffID])
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_PositionStaff]
GO
ALTER TABLE [dbo].[Staffs]  WITH CHECK ADD  CONSTRAINT [FK_Staffs_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Staffs] CHECK CONSTRAINT [FK_Staffs_User]
GO
ALTER TABLE [dbo].[Stuff]  WITH CHECK ADD  CONSTRAINT [FK_Stuff_Manufacter] FOREIGN KEY([ManufacterID])
REFERENCES [dbo].[Manufacter] ([ManufacterID])
GO
ALTER TABLE [dbo].[Stuff] CHECK CONSTRAINT [FK_Stuff_Manufacter]
GO
ALTER TABLE [dbo].[Stuff]  WITH CHECK ADD  CONSTRAINT [FK_Stuff_PharmacoGroup] FOREIGN KEY([PharmacoGroupID])
REFERENCES [dbo].[PharmacoGroup] ([PharmacoGroupID])
GO
ALTER TABLE [dbo].[Stuff] CHECK CONSTRAINT [FK_Stuff_PharmacoGroup]
GO
ALTER TABLE [dbo].[Stuff]  WITH CHECK ADD  CONSTRAINT [FK_Stuff_СonditionDispensing] FOREIGN KEY([СonditionDispensingID])
REFERENCES [dbo].[СonditionDispensing] ([СonditionDispensingID])
GO
ALTER TABLE [dbo].[Stuff] CHECK CONSTRAINT [FK_Stuff_СonditionDispensing]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Staffs"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "PositionStaff"
            Begin Extent = 
               Top = 6
               Left = 260
               Bottom = 102
               Right = 434
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 6
               Left = 472
               Bottom = 136
               Right = 646
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStaff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStaff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Manufacter"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 273
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Stuff"
            Begin Extent = 
               Top = 190
               Left = 369
               Bottom = 320
               Right = 580
            End
            DisplayFlags = 280
            TopColumn = 15
         End
         Begin Table = "PharmacoGroup"
            Begin Extent = 
               Top = 141
               Left = 935
               Bottom = 237
               Right = 1122
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "СonditionDispensing"
            Begin Extent = 
               Top = 6
               Left = 536
               Bottom = 102
               Right = 747
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 20
         Width = 284
         Width = 2235
         Width = 1500
         Width = 2370
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStuff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStuff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewStuff'
GO
USE [master]
GO
ALTER DATABASE [user85] SET  READ_WRITE 
GO
