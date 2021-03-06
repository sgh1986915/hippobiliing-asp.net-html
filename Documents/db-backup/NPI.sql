USE [master]
GO
/****** Object:  Database [NPI]    Script Date: 7/25/2014 6:52:36 AM ******/
CREATE DATABASE [NPI] ON  PRIMARY 
( NAME = N'NPI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NPI.mdf' , SIZE = 12352KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'NPI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\NPI_log.ldf' , SIZE = 2624KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NPI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NPI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NPI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NPI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NPI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NPI] SET ARITHABORT OFF 
GO
ALTER DATABASE [NPI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NPI] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [NPI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NPI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NPI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NPI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NPI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NPI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NPI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NPI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NPI] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NPI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NPI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NPI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NPI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NPI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NPI] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NPI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NPI] SET RECOVERY FULL 
GO
ALTER DATABASE [NPI] SET  MULTI_USER 
GO
ALTER DATABASE [NPI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NPI] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NPI', N'ON'
GO
USE [NPI]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 7/25/2014 6:52:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NPIRecords]    Script Date: 7/25/2014 6:52:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NPIRecords](
	[NPI] [nvarchar](128) NOT NULL,
	[Entity_Type_Code] [nvarchar](max) NULL,
	[Replacement_NPI] [nvarchar](max) NULL,
	[Employer_Identification_Number__EIN_] [nvarchar](max) NULL,
	[Provider_Organization_Name__Legal_Business_Name_] [nvarchar](max) NULL,
	[Provider_Last_Name__Legal_Name_] [nvarchar](max) NULL,
	[Provider_First_Name] [nvarchar](max) NULL,
	[Provider_Middle_Name] [nvarchar](max) NULL,
	[Provider_Name_Prefix_Text] [nvarchar](max) NULL,
	[Provider_Name_Suffix_Text] [nvarchar](max) NULL,
	[Provider_Credential_Text] [nvarchar](max) NULL,
	[Provider_Other_Organization_Name] [nvarchar](max) NULL,
	[Provider_Other_Organization_Name_Type_Code] [nvarchar](max) NULL,
	[Provider_Other_Last_Name] [nvarchar](max) NULL,
	[Provider_Other_First_Name] [nvarchar](max) NULL,
	[Provider_Other_Middle_Name] [nvarchar](max) NULL,
	[Provider_Other_Name_Prefix_Text] [nvarchar](max) NULL,
	[Provider_Other_Name_Suffix_Text] [nvarchar](max) NULL,
	[Provider_Other_Credential_Text] [nvarchar](max) NULL,
	[Provider_Other_Last_Name_Type_Code] [nvarchar](max) NULL,
	[Provider_First_Line_Business_Mailing_Address] [nvarchar](max) NULL,
	[Provider_Second_Line_Business_Mailing_Address] [nvarchar](max) NULL,
	[Provider_Business_Mailing_Address_City_Name] [nvarchar](max) NULL,
	[Provider_Business_Mailing_Address_State_Name] [nvarchar](max) NULL,
	[Provider_Business_Mailing_Address_Postal_Code] [nvarchar](max) NULL,
	[Provider_Business_Mailing_Address_Country_Code__If_outside_U_S__] [nvarchar](max) NULL,
	[Provider_Business_Mailing_Address_Telephone_Number] [nvarchar](max) NULL,
	[Provider_Business_Mailing_Address_Fax_Number] [nvarchar](max) NULL,
	[Provider_First_Line_Business_Practice_Location_Address] [nvarchar](max) NULL,
	[Provider_Second_Line_Business_Practice_Location_Address] [nvarchar](max) NULL,
	[Provider_Business_Practice_Location_Address_City_Name] [nvarchar](max) NULL,
	[Provider_Business_Practice_Location_Address_State_Name] [nvarchar](max) NULL,
	[Provider_Business_Practice_Location_Address_Postal_Code] [nvarchar](max) NULL,
	[Provider_Business_Practice_Location_Address_Country_Code__If_outside_U_S__] [nvarchar](max) NULL,
	[Provider_Business_Practice_Location_Address_Telephone_Number] [nvarchar](max) NULL,
	[Provider_Business_Practice_Location_Address_Fax_Number] [nvarchar](max) NULL,
	[Provider_Enumeration_Date] [nvarchar](max) NULL,
	[Last_Update_Date] [nvarchar](max) NULL,
	[NPI_Deactivation_Reason_Code] [nvarchar](max) NULL,
	[NPI_Deactivation_Date] [nvarchar](max) NULL,
	[NPI_Reactivation_Date] [nvarchar](max) NULL,
	[Provider_Gender_Code] [nvarchar](max) NULL,
	[Authorized_Official_Last_Name] [nvarchar](max) NULL,
	[Authorized_Official_First_Name] [nvarchar](max) NULL,
	[Authorized_Official_Middle_Name] [nvarchar](max) NULL,
	[Authorized_Official_Title_or_Position] [nvarchar](max) NULL,
	[Authorized_Official_Telephone_Number] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_1] [nvarchar](max) NULL,
	[Provider_License_Number_1] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_1] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_1] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_2] [nvarchar](max) NULL,
	[Provider_License_Number_2] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_2] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_2] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_3] [nvarchar](max) NULL,
	[Provider_License_Number_3] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_3] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_3] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_4] [nvarchar](max) NULL,
	[Provider_License_Number_4] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_4] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_4] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_5] [nvarchar](max) NULL,
	[Provider_License_Number_5] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_5] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_5] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_6] [nvarchar](max) NULL,
	[Provider_License_Number_6] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_6] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_6] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_7] [nvarchar](max) NULL,
	[Provider_License_Number_7] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_7] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_7] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_8] [nvarchar](max) NULL,
	[Provider_License_Number_8] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_8] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_8] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_9] [nvarchar](max) NULL,
	[Provider_License_Number_9] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_9] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_9] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_10] [nvarchar](max) NULL,
	[Provider_License_Number_10] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_10] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_10] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_11] [nvarchar](max) NULL,
	[Provider_License_Number_11] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_11] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_11] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_12] [nvarchar](max) NULL,
	[Provider_License_Number_12] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_12] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_12] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_13] [nvarchar](max) NULL,
	[Provider_License_Number_13] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_13] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_13] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_14] [nvarchar](max) NULL,
	[Provider_License_Number_14] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_14] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_14] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Code_15] [nvarchar](max) NULL,
	[Provider_License_Number_15] [nvarchar](max) NULL,
	[Provider_License_Number_State_Code_15] [nvarchar](max) NULL,
	[Healthcare_Provider_Primary_Taxonomy_Switch_15] [nvarchar](max) NULL,
	[Other_Provider_Identifier_1] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_1] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_1] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_1] [nvarchar](max) NULL,
	[Other_Provider_Identifier_2] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_2] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_2] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_2] [nvarchar](max) NULL,
	[Other_Provider_Identifier_3] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_3] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_3] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_3] [nvarchar](max) NULL,
	[Other_Provider_Identifier_4] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_4] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_4] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_4] [nvarchar](max) NULL,
	[Other_Provider_Identifier_5] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_5] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_5] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_5] [nvarchar](max) NULL,
	[Other_Provider_Identifier_6] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_6] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_6] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_6] [nvarchar](max) NULL,
	[Other_Provider_Identifier_7] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_7] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_7] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_7] [nvarchar](max) NULL,
	[Other_Provider_Identifier_8] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_8] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_8] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_8] [nvarchar](max) NULL,
	[Other_Provider_Identifier_9] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_9] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_9] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_9] [nvarchar](max) NULL,
	[Other_Provider_Identifier_10] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_10] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_10] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_10] [nvarchar](max) NULL,
	[Other_Provider_Identifier_11] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_11] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_11] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_11] [nvarchar](max) NULL,
	[Other_Provider_Identifier_12] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_12] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_12] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_12] [nvarchar](max) NULL,
	[Other_Provider_Identifier_13] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_13] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_13] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_13] [nvarchar](max) NULL,
	[Other_Provider_Identifier_14] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_14] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_14] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_14] [nvarchar](max) NULL,
	[Other_Provider_Identifier_15] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_15] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_15] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_15] [nvarchar](max) NULL,
	[Other_Provider_Identifier_16] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_16] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_16] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_16] [nvarchar](max) NULL,
	[Other_Provider_Identifier_17] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_17] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_17] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_17] [nvarchar](max) NULL,
	[Other_Provider_Identifier_18] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_18] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_18] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_18] [nvarchar](max) NULL,
	[Other_Provider_Identifier_19] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_19] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_19] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_19] [nvarchar](max) NULL,
	[Other_Provider_Identifier_20] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_20] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_20] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_20] [nvarchar](max) NULL,
	[Other_Provider_Identifier_21] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_21] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_21] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_21] [nvarchar](max) NULL,
	[Other_Provider_Identifier_22] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_22] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_22] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_22] [nvarchar](max) NULL,
	[Other_Provider_Identifier_23] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_23] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_23] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_23] [nvarchar](max) NULL,
	[Other_Provider_Identifier_24] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_24] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_24] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_24] [nvarchar](max) NULL,
	[Other_Provider_Identifier_25] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_25] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_25] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_25] [nvarchar](max) NULL,
	[Other_Provider_Identifier_26] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_26] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_26] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_26] [nvarchar](max) NULL,
	[Other_Provider_Identifier_27] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_27] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_27] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_27] [nvarchar](max) NULL,
	[Other_Provider_Identifier_28] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_28] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_28] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_28] [nvarchar](max) NULL,
	[Other_Provider_Identifier_29] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_29] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_29] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_29] [nvarchar](max) NULL,
	[Other_Provider_Identifier_30] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_30] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_30] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_30] [nvarchar](max) NULL,
	[Other_Provider_Identifier_31] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_31] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_31] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_31] [nvarchar](max) NULL,
	[Other_Provider_Identifier_32] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_32] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_32] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_32] [nvarchar](max) NULL,
	[Other_Provider_Identifier_33] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_33] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_33] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_33] [nvarchar](max) NULL,
	[Other_Provider_Identifier_34] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_34] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_34] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_34] [nvarchar](max) NULL,
	[Other_Provider_Identifier_35] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_35] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_35] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_35] [nvarchar](max) NULL,
	[Other_Provider_Identifier_36] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_36] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_36] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_36] [nvarchar](max) NULL,
	[Other_Provider_Identifier_37] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_37] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_37] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_37] [nvarchar](max) NULL,
	[Other_Provider_Identifier_38] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_38] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_38] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_38] [nvarchar](max) NULL,
	[Other_Provider_Identifier_39] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_39] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_39] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_39] [nvarchar](max) NULL,
	[Other_Provider_Identifier_40] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_40] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_40] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_40] [nvarchar](max) NULL,
	[Other_Provider_Identifier_41] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_41] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_41] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_41] [nvarchar](max) NULL,
	[Other_Provider_Identifier_42] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_42] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_42] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_42] [nvarchar](max) NULL,
	[Other_Provider_Identifier_43] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_43] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_43] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_43] [nvarchar](max) NULL,
	[Other_Provider_Identifier_44] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_44] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_44] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_44] [nvarchar](max) NULL,
	[Other_Provider_Identifier_45] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_45] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_45] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_45] [nvarchar](max) NULL,
	[Other_Provider_Identifier_46] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_46] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_46] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_46] [nvarchar](max) NULL,
	[Other_Provider_Identifier_47] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_47] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_47] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_47] [nvarchar](max) NULL,
	[Other_Provider_Identifier_48] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_48] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_48] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_48] [nvarchar](max) NULL,
	[Other_Provider_Identifier_49] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_49] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_49] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_49] [nvarchar](max) NULL,
	[Other_Provider_Identifier_50] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Type_Code_50] [nvarchar](max) NULL,
	[Other_Provider_Identifier_State_50] [nvarchar](max) NULL,
	[Other_Provider_Identifier_Issuer_50] [nvarchar](max) NULL,
	[Is_Sole_Proprietor] [nvarchar](max) NULL,
	[Is_Organization_Subpart] [nvarchar](max) NULL,
	[Parent_Organization_LBN] [nvarchar](max) NULL,
	[Parent_Organization_TIN] [nvarchar](max) NULL,
	[Authorized_Official_Name_Prefix_Text] [nvarchar](max) NULL,
	[Authorized_Official_Name_Suffix_Text] [nvarchar](max) NULL,
	[Authorized_Official_Credential_Text] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_1] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_2] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_3] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_4] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_5] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_6] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_7] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_8] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_9] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_10] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_11] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_12] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_13] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_14] [nvarchar](max) NULL,
	[Healthcare_Provider_Taxonomy_Group_15] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [NPI] SET  READ_WRITE 
GO
