using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using linh.controls;
using linh.core.dal;
using System.Data;
using System.Data.SqlClient;
using linh.core;
namespace linh.frm
{
    public class frameworks
    {
        public static void setup()
        {
            #region sql
            string sql = @"
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Delete_DeleteById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Delete_DeleteById_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPage_Delete_DeleteById_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Update_UpdateNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Update_UpdateNormal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPage_Update_UpdateNormal_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Insert_InsertNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Insert_InsertNormal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPage_Insert_InsertNormal_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Select_SelectById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Select_SelectById_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPage_Select_SelectById_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Select_SelectAll_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Select_SelectAll_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPage_Select_SelectAll_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Select_SelectByAlias_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Select_SelectByAlias_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPage_Select_SelectByAlias_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Delete_DeleteById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Delete_DeleteById_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayout_Delete_DeleteById_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Update_UpdateNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Update_UpdateNormal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayout_Update_UpdateNormal_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Insert_InsertNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Insert_InsertNormal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayout_Insert_InsertNormal_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Select_SelectById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Select_SelectById_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayout_Select_SelectById_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Select_SelectAll_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Select_SelectAll_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayout_Select_SelectAll_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Delete_DeleteById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Delete_DeleteById_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPlug_Delete_DeleteById_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Update_UpdateNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Update_UpdateNormal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPlug_Update_UpdateNormal_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Insert_InsertNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Insert_InsertNormal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPlug_Insert_InsertNormal_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Select_SelectById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Select_SelectById_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPlug_Select_SelectById_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Select_SelectAll_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Select_SelectAll_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPlug_Select_SelectAll_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Select_SelectByLayoutId_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Select_SelectByLayoutId_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPlug_Select_SelectByLayoutId_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Delete_DeleteById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Delete_DeleteById_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayoutPlug_Delete_DeleteById_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Update_UpdateNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Update_UpdateNormal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayoutPlug_Update_UpdateNormal_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Insert_InsertNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Insert_InsertNormal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayoutPlug_Insert_InsertNormal_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Select_SelectById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Select_SelectById_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayoutPlug_Select_SelectById_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Select_SelectAll_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Select_SelectAll_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayoutPlug_Select_SelectAll_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Select_SelectByPageAlias_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Select_SelectByPageAlias_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayout_Select_SelectByPageAlias_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Update_Reorder_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Update_Reorder_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayoutPlug_Update_Reorder_linhnx]
GO
/****** Object:  Table [dbo].[tbllinhPage]    Script Date: 09/16/2010 06:05:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbllinhPage]') AND type in (N'U'))
DROP TABLE [dbo].[tbllinhPage]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_convertStringToTable_linhnx]    Script Date: 09/16/2010 06:05:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_convertStringToTable_linhnx]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fn_convertStringToTable_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Pager_Normal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Pager_Normal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPlug_Pager_Normal_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Pager_Normal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Pager_Normal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhPage_Pager_Normal_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Pager_Normal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Pager_Normal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayoutPlug_Pager_Normal_linhnx]
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Pager_Normal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Pager_Normal_linhnx]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_tbllinhLayout_Pager_Normal_linhnx]
GO
/****** Object:  Table [dbo].[tbllinhLayout]    Script Date: 09/16/2010 06:05:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbllinhLayout]') AND type in (N'U'))
DROP TABLE [dbo].[tbllinhLayout]
GO
/****** Object:  Table [dbo].[tbllinhPlug]    Script Date: 09/16/2010 06:05:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbllinhPlug]') AND type in (N'U'))
DROP TABLE [dbo].[tbllinhPlug]
GO
/****** Object:  Table [dbo].[tbllinhLayoutPlug]    Script Date: 09/16/2010 06:05:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbllinhLayoutPlug]') AND type in (N'U'))
DROP TABLE [dbo].[tbllinhLayoutPlug]
GO
/****** Object:  Table [dbo].[tbllinhLayoutPlug]    Script Date: 09/16/2010 06:05:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbllinhLayoutPlug]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbllinhLayoutPlug](
	[LP_ID] [int] IDENTITY(1,1) NOT NULL,
	[LP_LAY_ID] [int] NULL,
	[LP_PLG_ID] [int] NULL,
	[LP_ThuTu] [int] NULL,
	[LP_Doc] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbllinhLayoutPlug] PRIMARY KEY CLUSTERED 
(
	[LP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tbllinhLayoutPlug] ON
INSERT [dbo].[tbllinhLayoutPlug] ([LP_ID], [LP_LAY_ID], [LP_PLG_ID], [LP_ThuTu], [LP_Doc]) VALUES (1, 4, 8, 0, N'<Plugin PluginType=""plugin.demo.Class1,plugin.demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"" ID=""b585a8e4-e07c-4c9d-a866-108d0f2f795a"" PluginClientId=""dbf9efbf-3270-4f64-aa1b-996d19860926"" PluginIndex=""1"" ZoneIndex=""1"" Title=""Nội dung"" PluginIcon="""" Display=""True"" ShowBorder=""True"" ShowHeader=""True"" ShowFoot=""True"" Public=""True"" XmlSourcePath=""~/tempData/Plugin/Class1.xml"" IsCached=""False"" IsCp=""False"" IsInvisible=""False"" IsShared=""False"">
  <ModuleSettings>
    <ModuleSettingTabs ID=""50f48b08-826a-4295-8985-26f85244055b"" Name=""Khác"" Index=""1"">
      <ModuleSetting Key=""TargetPage"" Title=""Trang đích"" Type=""String""><![CDATA[]]></ModuleSetting>
      <ModuleSetting Key=""html"" Title=""Nội dung"" Type=""String""><![CDATA[Nguyễn Xuân Linh]]></ModuleSetting>
    </ModuleSettingTabs>
  </ModuleSettings>
</Plugin>')
INSERT [dbo].[tbllinhLayoutPlug] ([LP_ID], [LP_LAY_ID], [LP_PLG_ID], [LP_ThuTu], [LP_Doc]) VALUES (2, 4, 9, 2, N'<Plugin PluginType=""plugin.demo.Class1,plugin.demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"" ID=""72da3d7c-efd1-4959-98d1-717f5a9179e5"" PluginClientId=""7176cf15-d4ed-486f-af13-66ba0f50b1d0"" PluginIndex=""0"" ZoneIndex=""2"" Title=""Nội dung"" PluginIcon="""" Display=""True"" ShowBorder=""True"" ShowHeader=""True"" ShowFoot=""True"" Public=""True"" XmlSourcePath=""~/tempData/Plugin/Class1.xml"" IsCached=""False"" IsCp=""False"" IsInvisible=""False"" IsShared=""False""><ModuleSettings><ModuleSettingTabs ID=""eb7ad770-b98c-4cca-a16f-c08741aa6f27"" Name=""Khác"" Index=""1""><ModuleSetting Key=""TargetPage"" Title=""Trang đích"" Type=""String""><![CDATA[zindex]]></ModuleSetting><ModuleSetting Key=""html"" Title=""Nội dung"" Type=""String""><![CDATA[1]]></ModuleSetting></ModuleSettingTabs></ModuleSettings></Plugin>')
INSERT [dbo].[tbllinhLayoutPlug] ([LP_ID], [LP_LAY_ID], [LP_PLG_ID], [LP_ThuTu], [LP_Doc]) VALUES (3, 4, 8, 1, N'<Plugin PluginType=""plugin.demo.Class1,plugin.demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"" ID=""b585a8e4-e07c-4c9d-a866-108d0f2f795a"" PluginClientId=""dbf9efbf-3270-4f64-aa1b-996d19860926"" PluginIndex=""1"" ZoneIndex=""1"" Title=""Nội dung"" PluginIcon="""" Display=""True"" ShowBorder=""True"" ShowHeader=""True"" ShowFoot=""True"" Public=""True"" XmlSourcePath=""~/tempData/Plugin/Class1.xml"" IsCached=""False"" IsCp=""False"" IsInvisible=""False"" IsShared=""False"">
  <ModuleSettings>
    <ModuleSettingTabs ID=""50f48b08-826a-4295-8985-26f85244055b"" Name=""Khác"" Index=""1"">
      <ModuleSetting Key=""TargetPage"" Title=""Trang đích"" Type=""String""><![CDATA[]]></ModuleSetting>
      <ModuleSetting Key=""html"" Title=""Nội dung"" Type=""String""><![CDATA[Nguyễn Xuân Linh]]></ModuleSetting>
    </ModuleSettingTabs>
  </ModuleSettings>
</Plugin>')
INSERT [dbo].[tbllinhLayoutPlug] ([LP_ID], [LP_LAY_ID], [LP_PLG_ID], [LP_ThuTu], [LP_Doc]) VALUES (4, 2, 9, 0, N'<Plugin PluginType=""plugin.demo.Class1,plugin.demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"" ID=""4a6f60a1-5229-46ec-acf0-352fe659f9e9"" PluginClientId=""01915f67-1c85-4827-813f-a92ba049baf7"" PluginIndex=""0"" ZoneIndex=""2"" Title=""Nội dung"" PluginIcon="""" Display=""True"" ShowBorder=""True"" ShowHeader=""True"" ShowFoot=""True"" Public=""True"" XmlSourcePath=""~/tempData/Plugin/Class1.xml"" IsCached=""False"" IsCp=""False"" IsInvisible=""False"" IsShared=""False""><ModuleSettings><ModuleSettingTabs ID=""e43911b4-13b2-49cd-8c50-7ecc6070e0d8"" Name=""Khác"" Index=""1""><ModuleSetting Key=""TargetPage"" Title=""Trang đích"" Type=""String""><![CDATA[]]></ModuleSetting><ModuleSetting Key=""html"" Title=""Nội dung"" Type=""String""><![CDATA[23]]></ModuleSetting></ModuleSettingTabs></ModuleSettings></Plugin>')
SET IDENTITY_INSERT [dbo].[tbllinhLayoutPlug] OFF
/****** Object:  Table [dbo].[tbllinhPlug]    Script Date: 09/16/2010 06:05:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbllinhPlug]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbllinhPlug](
	[PLG_ID] [int] IDENTITY(1,1) NOT NULL,
	[PLG_DM] [nvarchar](250) NULL,
	[PLG_Ten] [nvarchar](500) NULL,
	[PLG_Alias] [nvarchar](250) NULL,
	[PLG_Anh] [nvarchar](50) NULL,
	[PLG_Doc] [nvarchar](max) NULL,
	[PLG_Admin] [bit] NULL,
	[PLG_Active] [bit] NULL,
 CONSTRAINT [PK_tbllinhPlug] PRIMARY KEY CLUSTERED 
(
	[PLG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tbllinhPlug] ON
INSERT [dbo].[tbllinhPlug] ([PLG_ID], [PLG_DM], [PLG_Ten], [PLG_Alias], [PLG_Anh], [PLG_Doc], [PLG_Admin], [PLG_Active]) VALUES (8, N'Demo', N'demo', N'demo', N'', N'<Plugin PluginType=""plugin.demo.Class1,plugin.demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"" ID=""b585a8e4-e07c-4c9d-a866-108d0f2f795a"" PluginClientId=""dbf9efbf-3270-4f64-aa1b-996d19860926"" PluginIndex=""1"" ZoneIndex=""1"" Title=""Nội dung"" PluginIcon="""" Display=""True"" ShowBorder=""True"" ShowHeader=""True"" ShowFoot=""True"" Public=""True"" XmlSourcePath=""~/tempData/Plugin/Class1.xml"" IsCached=""False"" IsCp=""False"" IsInvisible=""False"" IsShared=""False""><ModuleSettings><ModuleSettingTabs ID=""50f48b08-826a-4295-8985-26f85244055b"" Name=""Khác"" Index=""1""><ModuleSetting Key=""TargetPage"" Title=""Trang đích"" Type=""String""><![CDATA[]]></ModuleSetting><ModuleSetting Key=""html"" Title=""Nội dung"" Type=""String""><![CDATA[Nguyễn Xuân Linh]]></ModuleSetting></ModuleSettingTabs></ModuleSettings></Plugin>', 0, 1)
INSERT [dbo].[tbllinhPlug] ([PLG_ID], [PLG_DM], [PLG_Ten], [PLG_Alias], [PLG_Anh], [PLG_Doc], [PLG_Admin], [PLG_Active]) VALUES (9, N'Demo', N'demo', N'demo1', N'', N'<Plugin PluginType=""plugin.demo.Class1,plugin.demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"" ID=""b585a8e4-e07c-4c9d-a866-108d0f2f795a"" PluginClientId=""dbf9efbf-3270-4f64-aa1b-996d19860926"" PluginIndex=""1"" ZoneIndex=""1"" Title=""Nội dung"" PluginIcon="""" Display=""True"" ShowBorder=""True"" ShowHeader=""True"" ShowFoot=""True"" Public=""True"" XmlSourcePath=""~/tempData/Plugin/Class1.xml"" IsCached=""False"" IsCp=""False"" IsInvisible=""False"" IsShared=""False""><ModuleSettings><ModuleSettingTabs ID=""50f48b08-826a-4295-8985-26f85244055b"" Name=""Khác"" Index=""1""><ModuleSetting Key=""TargetPage"" Title=""Trang đích"" Type=""String""><![CDATA[]]></ModuleSetting><ModuleSetting Key=""html"" Title=""Nội dung"" Type=""String""><![CDATA[Zinedine Zidane]]></ModuleSetting></ModuleSettingTabs></ModuleSettings></Plugin>', 0, 1)
SET IDENTITY_INSERT [dbo].[tbllinhPlug] OFF
/****** Object:  Table [dbo].[tbllinhLayout]    Script Date: 09/16/2010 06:05:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbllinhLayout]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbllinhLayout](
	[LAY_ID] [int] IDENTITY(1,1) NOT NULL,
	[LAY_PG_ID] [int] NULL,
	[LAY_Ten] [nvarchar](50) NULL,
	[LAY_Width] [nvarchar](10) NULL,
	[LAY_Show] [bit] NULL,
	[LAY_ThuTu] [int] NULL,
 CONSTRAINT [PK_tbllinhLayout] PRIMARY KEY CLUSTERED 
(
	[LAY_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tbllinhLayout] ON
INSERT [dbo].[tbllinhLayout] ([LAY_ID], [LAY_PG_ID], [LAY_Ten], [LAY_Width], [LAY_Show], [LAY_ThuTu]) VALUES (1, 1, N'Banner', N'100%', 1, 1)
INSERT [dbo].[tbllinhLayout] ([LAY_ID], [LAY_PG_ID], [LAY_Ten], [LAY_Width], [LAY_Show], [LAY_ThuTu]) VALUES (2, 1, N'Left', N'40%', 1, 2)
INSERT [dbo].[tbllinhLayout] ([LAY_ID], [LAY_PG_ID], [LAY_Ten], [LAY_Width], [LAY_Show], [LAY_ThuTu]) VALUES (3, 2, N'Main', N'40%', 1, 3)
INSERT [dbo].[tbllinhLayout] ([LAY_ID], [LAY_PG_ID], [LAY_Ten], [LAY_Width], [LAY_Show], [LAY_ThuTu]) VALUES (4, 1, N'Right', N'60%', 1, 4)
INSERT [dbo].[tbllinhLayout] ([LAY_ID], [LAY_PG_ID], [LAY_Ten], [LAY_Width], [LAY_Show], [LAY_ThuTu]) VALUES (5, 1, N'Foot', N'100%', 1, 5)
SET IDENTITY_INSERT [dbo].[tbllinhLayout] OFF
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Pager_Normal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Pager_Normal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhLayout_Pager_Normal_linhnx]
	(@PageSize int,@PageIndex int,@Sort nvarchar(500))
	as
	declare @l nvarchar(max);
	set @l=''
	declare @Total bigint;
	set @Total=(select count(*) from tbllinhLayout);
	select * from
	(
		SELECT  ROW_NUMBER() OVER (ORDER BY '' + ISNULL(@Sort,''LAY_ID DESC'') + '') AS STT,*,@Total as Total
		FROM   tbllinhLayout
	)
	as temp where (STT between ('' + convert(nvarchar(20),(@PageIndex  - 1)) + '') * '' + convert(nvarchar(20),(@PageSize + 1)) + '' and '' + convert(nvarchar(20),@PageIndex*@PageSize) + '')'';
	exec(@l)
	--tbllinhLayout_StoreEnd    
    
	--tbllinhLayoutPlug_Store
    
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Pager_Normal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Pager_Normal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhLayoutPlug_Pager_Normal_linhnx]
	(@PageSize int,@PageIndex int,@Sort nvarchar(500))
	as
	declare @l nvarchar(max);
	set @l=''
	declare @Total bigint;
	set @Total=(select count(*) from tbllinhLayoutPlug);
	select * from
	(
		SELECT  ROW_NUMBER() OVER (ORDER BY '' + ISNULL(@Sort,''LP_ID DESC'') + '') AS STT,*,@Total as Total
		FROM   tbllinhLayoutPlug
	)
	as temp where (STT between ('' + convert(nvarchar(20),(@PageIndex  - 1)) + '') * '' + convert(nvarchar(20),(@PageSize + 1)) + '' and '' + convert(nvarchar(20),@PageIndex*@PageSize) + '')'';
	exec(@l)
	--tbllinhLayoutPlug_StoreEnd    
    
	--tbllinhPage_Store
    
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Pager_Normal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Pager_Normal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhPage_Pager_Normal_linhnx]
	(@PageSize int,@PageIndex int,@Sort nvarchar(500))
	as
	declare @l nvarchar(max);
	set @l=''
	declare @Total bigint;
	set @Total=(select count(*) from tbllinhPage);
	select * from
	(
		SELECT  ROW_NUMBER() OVER (ORDER BY '' + ISNULL(@Sort,''PG_ID DESC'') + '') AS STT,*,@Total as Total
		FROM   tbllinhPage
	)
	as temp where (STT between ('' + convert(nvarchar(20),(@PageIndex  - 1)) + '') * '' + convert(nvarchar(20),(@PageSize + 1)) + '' and '' + convert(nvarchar(20),@PageIndex*@PageSize) + '')'';
	exec(@l)
	--tbllinhPage_StoreEnd    
    
	--tbllinhPlug_Store
    
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Pager_Normal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Pager_Normal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhPlug_Pager_Normal_linhnx]
	(@PageSize int,@PageIndex int,@Sort nvarchar(500))
	as
	declare @l nvarchar(max);
	set @l=''
	declare @Total bigint;
	set @Total=(select count(*) from tbllinhPlug);
	select * from
	(
		SELECT  ROW_NUMBER() OVER (ORDER BY '' + ISNULL(@Sort,''PLG_ID DESC'') + '') AS STT,*,@Total as Total
		FROM   tbllinhPlug
	)
	as temp where (STT between ('' + convert(nvarchar(20),(@PageIndex  - 1)) + '') * '' + convert(nvarchar(20),(@PageSize + 1)) + '' and '' + convert(nvarchar(20),@PageIndex*@PageSize) + '')'';
	exec(@l)
	--tbllinhPlug_StoreEnd    
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fn_convertStringToTable_linhnx]    Script Date: 09/16/2010 06:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fn_convertStringToTable_linhnx]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'create FUNCTION [dbo].[fn_convertStringToTable_linhnx]
    (
      @ParamaterList NVARCHAR(MAX),
      @Delimiter CHAR(1)
    )
RETURNS @ReturnList TABLE
    (
      v NVARCHAR(MAX)
    )
WITH EXECUTE AS CALLER

AS 

BEGIN
    DECLARE @ArrayList TABLE
        (
          FieldValue NVARCHAR(MAX)
        )
    DECLARE @Value NVARCHAR(MAX)
    DECLARE @CurrentPosition INT
 
    SET @ParamaterList = LTRIM(RTRIM(@ParamaterList))
        + CASE WHEN RIGHT(@ParamaterList, 1) = @Delimiter THEN ''''
               ELSE @Delimiter
          END
    SET @CurrentPosition = ISNULL(CHARINDEX(@Delimiter, @ParamaterList, 1), 0)  

    IF @CurrentPosition = 0
        INSERT  INTO @ArrayList ( FieldValue )
                SELECT  @ParamaterList
    ELSE
        BEGIN
            WHILE @CurrentPosition > 0
                BEGIN
                    SET @Value = LTRIM(RTRIM(LEFT(@ParamaterList,
                                                  @CurrentPosition - 1))) --make sure a value exists between the delimiters
                    IF LEN(@ParamaterList) > 0
                        AND @CurrentPosition <= LEN(@ParamaterList)
                        BEGIN
							if(len(@Value) >0)
								begin
									INSERT  INTO @ArrayList ( FieldValue )
                                    SELECT  @Value
								end                            
                        END
                    SET @ParamaterList = SUBSTRING(@ParamaterList,
                                                   @CurrentPosition
                                                   + LEN(@Delimiter),
                                                   LEN(@ParamaterList))
                    SET @CurrentPosition = CHARINDEX(@Delimiter,
                                                     @ParamaterList, 1)
                END
        END
    INSERT  @ReturnList ( v )
            SELECT  FieldValue
            FROM    @ArrayList
    RETURN
   END


	



' 
END
GO
/****** Object:  Table [dbo].[tbllinhPage]    Script Date: 09/16/2010 06:05:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tbllinhPage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbllinhPage](
	[PG_ID] [int] IDENTITY(1,1) NOT NULL,
	[PG_Ten] [nvarchar](500) NULL,
	[PG_Alias] [nvarchar](500) NULL,
	[PG_Keywords] [nvarchar](500) NULL,
	[PG_Description] [nvarchar](500) NULL,
	[PG_Active] [bit] NULL,
 CONSTRAINT [PK_tbllinhPage] PRIMARY KEY CLUSTERED 
(
	[PG_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[tbllinhPage] ON
INSERT [dbo].[tbllinhPage] ([PG_ID], [PG_Ten], [PG_Alias], [PG_Keywords], [PG_Description], [PG_Active]) VALUES (1, N'Trang chủ', N'home', N'', N'', 1)
SET IDENTITY_INSERT [dbo].[tbllinhPage] OFF
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Update_Reorder_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Update_Reorder_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[sp_tbllinhLayoutPlug_Update_Reorder_linhnx]
	(
		
		@List nvarchar(500)
	)
	as
	
update tbllinhLayoutPlug set tbllinhLayoutPlug.LP_ThuTu=B.ThuTu
from tbllinhLayoutPlug A
inner join
(select left(v,charindex('','',v)-1) as ID,Substring(v,charindex('','',v)+1,len(v)) as ThuTu from dbo.fn_convertStringToTable_linhnx(@List,'';'')) as B
on A.LP_ID=B.ID' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Select_SelectByPageAlias_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Select_SelectByPageAlias_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [dbo].[sp_tbllinhLayout_Select_SelectByPageAlias_linhnx]
(@Alias nvarchar(250))
as
select * from tbllinhLayoutPlug
where LP_LAY_ID in (select LAY_ID from tbllinhLayout where LAY_PG_ID in (select PG_ID from tbllinhpage where PG_Alias=@Alias))
order by LP_ThuTu asc' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Select_SelectAll_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Select_SelectAll_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'		create proc [dbo].[sp_tbllinhLayoutPlug_Select_SelectAll_linhnx]
		as
		SELECT *
		FROM  tbllinhLayoutPlug		
		order by LP_ID desc
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Select_SelectById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Select_SelectById_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'		create proc [dbo].[sp_tbllinhLayoutPlug_Select_SelectById_linhnx]
        (
        @LP_ID int
        )
		as
		SELECT *
		FROM  tbllinhLayoutPlug		
		where (LP_ID=@LP_ID)
    
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Insert_InsertNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Insert_InsertNormal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhLayoutPlug_Insert_InsertNormal_linhnx]
		(
			
			@LP_LAY_ID int,
			@LP_PLG_ID int,
			@LP_ThuTu int,
			@LP_Doc nvarchar(MAX)
		)
		as
		insert into  dbo.tbllinhLayoutPlug		
		 (  LP_LAY_ID,  LP_PLG_ID,  LP_ThuTu,  LP_Doc )
		values
		(  @LP_LAY_ID,  @LP_PLG_ID,  @LP_ThuTu,  @LP_Doc )
		select  *
		FROM  tbllinhLayoutPlug
		where (LP_ID=scope_identity())

	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Update_UpdateNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Update_UpdateNormal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhLayoutPlug_Update_UpdateNormal_linhnx]
		(
			
			@LP_ID int,
			@LP_LAY_ID int,
			@LP_PLG_ID int,
			@LP_ThuTu int,
			@LP_Doc nvarchar(MAX)
		)
		as
		UPDATE tbllinhLayoutPlug SET LP_LAY_ID = ISNULL(@LP_LAY_ID,LP_LAY_ID),LP_PLG_ID = ISNULL(@LP_PLG_ID,LP_PLG_ID),LP_ThuTu = ISNULL(@LP_ThuTu,LP_ThuTu),LP_Doc = ISNULL(@LP_Doc,LP_Doc) where LP_ID= @LP_ID
		SELECT *
		from tbllinhLayoutPlug 
		where (LP_ID=@LP_ID)
	
	
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayoutPlug_Delete_DeleteById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayoutPlug_Delete_DeleteById_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhLayoutPlug_Delete_DeleteById_linhnx]
	(
	@LP_ID int
	)
	as
	delete tbllinhLayoutPlug
	where (LP_ID=@LP_ID)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Select_SelectByLayoutId_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Select_SelectByLayoutId_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'		create proc [dbo].[sp_tbllinhPlug_Select_SelectByLayoutId_linhnx]
		(@LAY_ID int)
		as
SELECT     tbllinhPlug.PLG_ID, tbllinhPlug.PLG_DM, tbllinhPlug.PLG_Ten, tbllinhPlug.PLG_Alias, tbllinhPlug.PLG_Anh, tbllinhPlug.PLG_Doc, 
                      tbllinhPlug.PLG_Admin, tbllinhPlug.PLG_Active
FROM         tbllinhPlug INNER JOIN
                      tbllinhLayoutPlug ON tbllinhPlug.PLG_ID = tbllinhLayoutPlug.LP_PLG_ID
WHERE     (tbllinhLayoutPlug.LP_LAY_ID = @LAY_ID)
ORDER BY tbllinhLayoutPlug.LP_ThuTu' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Select_SelectAll_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Select_SelectAll_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'		create proc [dbo].[sp_tbllinhPlug_Select_SelectAll_linhnx]
		as
		SELECT *
		FROM  tbllinhPlug		
		order by PLG_ID desc
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Select_SelectById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Select_SelectById_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'		create proc [dbo].[sp_tbllinhPlug_Select_SelectById_linhnx]
        (
        @PLG_ID int
        )
		as
		SELECT *
		FROM  tbllinhPlug		
		where (PLG_ID=@PLG_ID)
    
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Insert_InsertNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Insert_InsertNormal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhPlug_Insert_InsertNormal_linhnx]
		(
			
			@PLG_DM nvarchar(250),
			@PLG_Ten nvarchar(500),
			@PLG_Alias nvarchar(250),
			@PLG_Anh nvarchar(50),
			@PLG_Doc nvarchar(MAX),
			@PLG_Admin bit,
			@PLG_Active bit
		)
		as
		insert into  dbo.tbllinhPlug		
		 (  PLG_DM,  PLG_Ten,  PLG_Alias,  PLG_Anh,  PLG_Doc,  PLG_Admin,  PLG_Active )
		values
		(  @PLG_DM,  @PLG_Ten,  @PLG_Alias,  @PLG_Anh,  @PLG_Doc,  @PLG_Admin,  @PLG_Active )
		select  *
		FROM  tbllinhPlug
		where (PLG_ID=scope_identity())

	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Update_UpdateNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Update_UpdateNormal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhPlug_Update_UpdateNormal_linhnx]
		(
			
			@PLG_ID int,
			@PLG_DM nvarchar(250),
			@PLG_Ten nvarchar(500),
			@PLG_Alias nvarchar(250),
			@PLG_Anh nvarchar(50),
			@PLG_Doc nvarchar(MAX),
			@PLG_Admin bit,
			@PLG_Active bit
		)
		as
		UPDATE tbllinhPlug SET PLG_DM = ISNULL(@PLG_DM,PLG_DM),PLG_Ten = ISNULL(@PLG_Ten,PLG_Ten),PLG_Alias = ISNULL(@PLG_Alias,PLG_Alias),PLG_Anh = ISNULL(@PLG_Anh,PLG_Anh),PLG_Doc = ISNULL(@PLG_Doc,PLG_Doc),PLG_Admin = ISNULL(@PLG_Admin,PLG_Admin),PLG_Active = ISNULL(@PLG_Active,PLG_Active) where PLG_ID= @PLG_ID
		SELECT *
		from tbllinhPlug 
		where (PLG_ID=@PLG_ID)
	
	
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPlug_Delete_DeleteById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPlug_Delete_DeleteById_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhPlug_Delete_DeleteById_linhnx]
	(
	@PLG_ID int
	)
	as
	delete tbllinhPlug
	where (PLG_ID=@PLG_ID)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Select_SelectAll_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Select_SelectAll_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'		create proc [dbo].[sp_tbllinhLayout_Select_SelectAll_linhnx]
		as
		SELECT *
		FROM  tbllinhLayout		
		order by LAY_ID desc
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Select_SelectById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Select_SelectById_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'		create proc [dbo].[sp_tbllinhLayout_Select_SelectById_linhnx]
        (
        @LAY_ID int
        )
		as
		SELECT *
		FROM  tbllinhLayout		
		where (LAY_ID=@LAY_ID)
    
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Insert_InsertNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Insert_InsertNormal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhLayout_Insert_InsertNormal_linhnx]
		(
			
			@LAY_PG_ID int,
			@LAY_Ten nvarchar(50),
			@LAY_Width nvarchar(10),
			@LAY_Show bit,
			@LAY_ThuTu int
		)
		as
		insert into  dbo.tbllinhLayout		
		 (  LAY_PG_ID,  LAY_Ten,  LAY_Width,  LAY_Show,  LAY_ThuTu )
		values
		(  @LAY_PG_ID,  @LAY_Ten,  @LAY_Width,  @LAY_Show,  @LAY_ThuTu )
		select  *
		FROM  tbllinhLayout
		where (LAY_ID=scope_identity())

	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Update_UpdateNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Update_UpdateNormal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhLayout_Update_UpdateNormal_linhnx]
		(
			
			@LAY_ID int,
			@LAY_PG_ID int,
			@LAY_Ten nvarchar(50),
			@LAY_Width nvarchar(10),
			@LAY_Show bit,
			@LAY_ThuTu int
		)
		as
		UPDATE tbllinhLayout SET LAY_PG_ID = ISNULL(@LAY_PG_ID,LAY_PG_ID),LAY_Ten = ISNULL(@LAY_Ten,LAY_Ten),LAY_Width = ISNULL(@LAY_Width,LAY_Width),LAY_Show = ISNULL(@LAY_Show,LAY_Show),LAY_ThuTu = ISNULL(@LAY_ThuTu,LAY_ThuTu) where LAY_ID= @LAY_ID
		SELECT *
		from tbllinhLayout 
		where (LAY_ID=@LAY_ID)
	
	
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhLayout_Delete_DeleteById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhLayout_Delete_DeleteById_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhLayout_Delete_DeleteById_linhnx]
	(
	@LAY_ID int
	)
	as
	delete tbllinhLayout
	where (LAY_ID=@LAY_ID)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Select_SelectByAlias_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Select_SelectByAlias_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [dbo].[sp_tbllinhPage_Select_SelectByAlias_linhnx]
        (
        @PG_Alias nvarchar(500)
        )
		as
	SELECT     tbllinhPage.PG_ID, tbllinhPage.PG_Ten, tbllinhPage.PG_Alias, tbllinhPage.PG_Keywords, tbllinhPage.PG_Description, tbllinhPage.PG_Active, 
                      tbllinhLayout.LAY_ID, tbllinhLayout.LAY_PG_ID, tbllinhLayout.LAY_Ten, tbllinhLayout.LAY_Width, tbllinhLayout.LAY_Show, 
                      tbllinhLayout.LAY_ThuTu
FROM         tbllinhPage INNER JOIN
                      tbllinhLayout ON tbllinhPage.PG_ID = tbllinhLayout.LAY_PG_ID
WHERE     (tbllinhPage.PG_Alias = @PG_Alias)
ORDER BY tbllinhLayout.LAY_ThuTu' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Select_SelectAll_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Select_SelectAll_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'		create proc [dbo].[sp_tbllinhPage_Select_SelectAll_linhnx]
		as
		SELECT *
		FROM  tbllinhPage		
		order by PG_ID desc
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Select_SelectById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Select_SelectById_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'		create proc [dbo].[sp_tbllinhPage_Select_SelectById_linhnx]
        (
        @PG_ID int
        )
		as
		SELECT *
		FROM  tbllinhPage		
		where (PG_ID=@PG_ID)
    
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Insert_InsertNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Insert_InsertNormal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhPage_Insert_InsertNormal_linhnx]
		(
			
			@PG_Ten nvarchar(500),
			@PG_Alias nvarchar(500),
			@PG_Keywords nvarchar(500),
			@PG_Description nvarchar(500),
			@PG_Active bit
		)
		as
		insert into  dbo.tbllinhPage		
		 (  PG_Ten,  PG_Alias,  PG_Keywords,  PG_Description,  PG_Active )
		values
		(  @PG_Ten,  @PG_Alias,  @PG_Keywords,  @PG_Description,  @PG_Active )
		select  *
		FROM  tbllinhPage
		where (PG_ID=scope_identity())

	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Update_UpdateNormal_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Update_UpdateNormal_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhPage_Update_UpdateNormal_linhnx]
		(
			
			@PG_ID int,
			@PG_Ten nvarchar(500),
			@PG_Alias nvarchar(500),
			@PG_Keywords nvarchar(500),
			@PG_Description nvarchar(500),
			@PG_Active bit
		)
		as
		UPDATE tbllinhPage SET PG_Ten = ISNULL(@PG_Ten,PG_Ten),PG_Alias = ISNULL(@PG_Alias,PG_Alias),PG_Keywords = ISNULL(@PG_Keywords,PG_Keywords),PG_Description = ISNULL(@PG_Description,PG_Description),PG_Active = ISNULL(@PG_Active,PG_Active) where PG_ID= @PG_ID
		SELECT *
		from tbllinhPage 
		where (PG_ID=@PG_ID)
	
	
	
' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_tbllinhPage_Delete_DeleteById_linhnx]    Script Date: 09/16/2010 06:05:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_tbllinhPage_Delete_DeleteById_linhnx]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'	create proc [dbo].[sp_tbllinhPage_Delete_DeleteById_linhnx]
	(
	@PG_ID int
	)
	as
	delete tbllinhPage
	where (PG_ID=@PG_ID)
' 
END
GO
";
            #endregion
            string[] commands = sql.Split(new string[] { "GO\r\n", "GO ", "GO\t" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string l in commands)
            {
                SqlHelper.ExecuteNonQuery(DAL.con(), System.Data.CommandType.Text, l);
            }
        }
    }
}
