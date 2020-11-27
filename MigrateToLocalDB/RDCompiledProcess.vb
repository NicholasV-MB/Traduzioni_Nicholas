Imports System
Imports System.Collections
Imports System.Reflection
Imports RuleDesigner.Configurator.Core.RDCoreCompiler
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.CompilerUtil
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.BasicFunctionsProxy

Public Module GlobalScope

    Public _CurrentNode As String = ""
    Public _ExitTarget As String = ""
    Public _ActionResult As ActionResult = Nothing

    Public ReadOnly Property _Main() As RDCompiledProcess
        Get
            Return CompiledProcessMain
        End Get
    End Property

    Public ReadOnly Property _Param() As RDFunctionParam
        Get
            Return CompiledProcessState.ParamVar
        End Get
    End Property

    Public ReadOnly Property _Me() As Object
        Get
            Return CompiledProcessState.MeVar
        End Get
    End Property

End Module

Public Class RDCompiledProcess
    Implements IRDCompiledProcess

#Region " --- STANDARD INFRASTRUCTURE "

    Public ReadOnly Property StaticExpressionsType As Type Implements IRDCompiledProcess.StaticExpressionsType
        Get
            Return GetType(StaticExpressions)
        End Get
    End Property

    Public ReadOnly Property GlobalVarsType As Type Implements IRDCompiledProcess.GlobalVarsType
        Get
            Return GetType(GlobalVars)
        End Get
    End Property

    'Public ReadOnly Property GetDLL As String Implements IRDCompiledProcess.GetDLL
    '    Get
    '        Return Assembly.GetExecutingAssembly().Location
    '    End Get
    'End Property

<RuleDesignerAttribute(IsSystem:=True)>
    Public Sub Main(ByVal Parameters As Generic.List(Of RDParamValue)) Implements IRDCompiledProcess.Main
        Try
			'Recompile removing this comment to debug in VisualStudio
			'Debugger.Launch
			''''
10:         CompilerUtil.ClearGlobalVars(Me)
30:         CompilerUtil.SetInputParameters(Me, Parameters)
			''''
40:         Call ProcessMain()
			''''
50:         CompilerUtil.SetOutputParameters(Me, Parameters)
60:         CompilerUtil.CheckExitTarget(_ExitTarget)
			''''
        Catch ex As Exception
			if _CurrentNode <> "" then
				CompilerUtil.RaiseException(_CurrentNode, ex)
			else
				CompilerUtil.RaiseException(ex.Message)
			end if
        End Try
    End Sub

#End Region

#Region " --- PROCESS DECLARATIONS "

    Private Sub ProcessMain()
		CreateCODVAL = EvalConstant(GetType(string),"CREATE TABLE [dbo].[CODVAL](ç§	[cvalID] [int] NOT NULL,ç§	[cpID] [int] NOT NULL,ç§	[cvalValore] [nvarchar](255) NOT NULL,ç§	[cvalCodice] [nvarchar](15) NULL,ç§	[cvalTags] [nvarchar](128) NULL,ç§	[cvalTrans1] [nvarchar](255) NULL,ç§	[cvalTrans2] [nvarchar](255) NULL,ç§	[cvalTrans3] [nvarchar](255) NULL,ç§	[cvalTrans4] [nvarchar](255) NULL,ç§	[cvalTrans5] [nvarchar](255) NULL,ç§	[cvalMountTime] [float] NULL,ç§	[cvalPos] [int] NOT NULL,ç§	[cvalImageUrl] [nvarchar](255) NULL,ç§PRIMARY KEY CLUSTERED ç§(ç§	[cvalID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]")
		PDMServer = "Provider=sqloledb;Initial Catalog=PDMtest;Data Source=192.168.0.27;User Id=SA;Password=Ruled2014;"
		PDMLocal = "Provider=sqloledb;Initial Catalog=PDMtest;Data Source=LAPT-IT07\RULEDESIGNER;User Id=SA;Password=MBOffline$;"
		FusionServer = "Provider=sqloledb;Initial Catalog=FUSIONTEST;Data Source=192.168.0.27;User Id=SA;Password=Ruled2014;"
		FusionLocal = "Provider=sqloledb;Initial Catalog=FUSIONTEST;Data Source=LAPT-IT07\RULEDESIGNER;User Id=SA;Password=MBOffline$;"
		dateformat = "SET DATEFORMAT dmy;"
		FusionTables = EvalConstant(FusionTables.GetType, "LIST { ç§""ba_activitytype"",ç§""ba_properties"",ç§""ba_prop_value"",ç§""ba_activity_category"",ç§""wo_state"",ç§""pr_item"",ç§""pr_type"",ç§""dm_class"",ç§""dm_folder_001"",ç§""ba_source"",ç§""LANGUAGE"",ç§""pr_project_001"",ç§""dm_folder_prop_001""ç§}")
		endwhile = false


        'CALL TO MAIN PROCESS
        Call Main_Group_K_0008()

    End Sub

#Region " --- PROCESS FUNCTIONS TABLE "



#End Region

#End Region

#Region " --- PROCESS CODE TABLE "

	'Main Group
	Private Sub Main_Group_K_0008()
		_CurrentNode = "RDK:0008"
		'PDM *LOG_DISABLED
		Call PDM_K_27()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'FUSION *LOG_DISABLED
		Call FUSION_K_75()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'PDM *LOG_DISABLED
	Private Sub PDM_K_27()
		_CurrentNode = "RDK:27"
		'Open DB Connection (PDM SERVER)
		_CurrentNode = "RDK:45"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_45 as New Generic.list(of object)
		ActionArgs_K_45.Add("PDMTest") 'ConnectionName IN
		ActionArgs_K_45.Add(EvalExpression("ConnectionString_K_45")) 'ConnectionString IN
		ActionArgs_K_45.Add(1) 'Transaction IN
		ActionArgs_K_45.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_45 As object() = ActionArgs_K_45.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_45)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Select DB Values
		_CurrentNode = "RDK:51"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_51 as New Generic.list(of object)
		ActionArgs_K_51.Add("PDMTest") 'ConnectionName IN
		ActionArgs_K_51.Add("SELECT * FROM CODVAL") 'SelectQuery IN
		ActionArgs_K_51.Add(2) 'SelectQueryType IN
		ActionArgs_K_51.Add(Nothing) 'FirstValue OUT
		ActionArgs_K_51.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_51.Add(table) 'AllRows OUT
		ActionArgs_K_51.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_51.Add(Nothing) 'NumRows OUT
		ActionArgs_K_51.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_51.Add(Nothing) 'ColumnHeaders OUT
		ActionArgs_K_51.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_51 As object() = ActionArgs_K_51.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_51)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		table = _ActionArgs_K_51(5)		'OUT
		
		'Close DB Connection (PDM SERVER)
		_CurrentNode = "RDK:52"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_52 as New Generic.list(of object)
		ActionArgs_K_52.Add("PDMTest") 'ConnectionName IN
		ActionArgs_K_52.Add(2) 'Transaction IN
		Dim _ActionArgs_K_52 As object() = ActionArgs_K_52.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_52)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Open DB Connection (PDM LOCAL)
		_CurrentNode = "RDK:46"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_46 as New Generic.list(of object)
		ActionArgs_K_46.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_46.Add(EvalExpression("ConnectionString_K_46")) 'ConnectionString IN
		ActionArgs_K_46.Add(-1) 'Transaction IN
		ActionArgs_K_46.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_46 As object() = ActionArgs_K_46.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_46)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Execute SQL Statement
		_CurrentNode = "RDK:44"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_44 as New Generic.list(of object)
		ActionArgs_K_44.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_44.Add(EvalExpression("SqlStatement_K_44")) 'SqlStatement IN
		ActionArgs_K_44.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_44.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_44 As object() = ActionArgs_K_44.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_44)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'FOREACH row IN table BYREF
		Call FOREACHLOOP_K_55()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Close DB Connection (PDM LOCAL)
		_CurrentNode = "RDK:65"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_65 as New Generic.list(of object)
		ActionArgs_K_65.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_65.Add(-1) 'Transaction IN
		Dim _ActionArgs_K_65 As object() = ActionArgs_K_65.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_65)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'FOREACH row IN table BYREF
	Private Sub FOREACHLOOP_K_55()
		_CurrentNode = "RDK:55"
		Dim Values_RDK_55 as object = table
		Dim Index_RDK_55 as integer
		Dim MaxCount_RDK_55 as integer = CompilerUtil.Count(Values_RDK_55)
		If MaxCount_RDK_55 <= 0 then return
		Index_RDK_55 = 0
	next_foreach:
		row = Values_RDK_55(Index_RDK_55)
		
		'Set query_insert = INSERT INTO CODVAL VALUES(
		_CurrentNode = "RDK:57"
		query_insert = EvalConstant(query_insert.GetType, "INSERT INTO CODVAL VALUES(")
		
		'FOREACH field IN row BYREF
		Call FOREACHLOOP_K_66()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set query_insert = query_insert+")"
		_CurrentNode = "RDK:288"
		query_insert = EvalExpression("Set_query_insert_K_288")
		
		'Execute SQL Statement
		_CurrentNode = "RDK:58"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_58 as New Generic.list(of object)
		ActionArgs_K_58.Add("PDM_Local") 'ConnectionName IN
		ActionArgs_K_58.Add(EvalExpression("SqlStatement_K_58")) 'SqlStatement IN
		ActionArgs_K_58.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_58.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_58 As object() = ActionArgs_K_58.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_58)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		Index_RDK_55 += 1
		If Index_RDK_55 >= MaxCount_RDK_55 then return
		goto next_foreach
	End Sub

	'FOREACH field IN row BYREF
	Private Sub FOREACHLOOP_K_66()
		_CurrentNode = "RDK:66"
		Dim Values_RDK_66 as object = row
		Dim Index_RDK_66 as integer
		Dim MaxCount_RDK_66 as integer = CompilerUtil.Count(Values_RDK_66)
		If MaxCount_RDK_66 <= 0 then return
		Index_RDK_66 = 0
		i = 1
	next_foreach:
		field = Values_RDK_66(Index_RDK_66)
		
		'If i>1 is True
		Call IFTHENELSE_K_258()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'If row[i-1]<>"" is True
		Call IFTHENELSE_K_236()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_66 += 1
		If Index_RDK_66 >= MaxCount_RDK_66 then return
		i += 1
		goto next_foreach
	End Sub

	'If i>1 is True
	Private Sub IFTHENELSE_K_258()
		_CurrentNode = "RDK:258"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_258")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If i>1 is True
			Call THENGROUP_K_259()

		End if
	End Sub

	'If i>1 is True
	Private Sub THENGROUP_K_259()
		_CurrentNode = "RDK:259"
		'Set query_insert = query_insert+","
		_CurrentNode = "RDK:268"
		query_insert = EvalExpression("Set_query_insert_K_268")
		
	End Sub

	'If row[i-1]<>"" is True
	Private Sub IFTHENELSE_K_236()
		_CurrentNode = "RDK:236"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_236")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If row[i-1]<>"" is True
			Call THENGROUP_K_237()

		else
			'Set query_insert = query_insert+"'"+StrSql(row[i-1])+"'"
			Call ELSEGROUP_K_238()

		End if
	End Sub

	'If row[i-1]<>"" is True
	Private Sub THENGROUP_K_237()
		_CurrentNode = "RDK:237"
		'Set query_insert = query_insert+"'"+StrSql(row[i-1])+"'"
		_CurrentNode = "RDK:246"
		query_insert = EvalExpression("Set_query_insert_K_246")
		
	End Sub

	'Set query_insert = query_insert+"'"+StrSql(row[i-1])+"'"
	Private Sub ELSEGROUP_K_238()
		_CurrentNode = "RDK:238"
		'Set query_insert = query_insert+"''"
		_CurrentNode = "RDK:257"
		query_insert = EvalExpression("Set_query_insert_K_257")
		
	End Sub

	'FUSION *LOG_DISABLED
	Private Sub FUSION_K_75()
		_CurrentNode = "RDK:75"
		'Open DB Connection (FUSION SERVER)
		_CurrentNode = "RDK:79"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_79 as New Generic.list(of object)
		ActionArgs_K_79.Add("FusionTest") 'ConnectionName IN
		ActionArgs_K_79.Add(EvalExpression("ConnectionString_K_79")) 'ConnectionString IN
		ActionArgs_K_79.Add(1) 'Transaction IN
		ActionArgs_K_79.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_79 As object() = ActionArgs_K_79.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_79)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Open DB Connection (FUSION LOCAL)
		_CurrentNode = "RDK:81"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_81 as New Generic.list(of object)
		ActionArgs_K_81.Add("Fusion_Local") 'ConnectionName IN
		ActionArgs_K_81.Add(EvalExpression("ConnectionString_K_81")) 'ConnectionString IN
		ActionArgs_K_81.Add(-1) 'Transaction IN
		ActionArgs_K_81.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_81 As object() = ActionArgs_K_81.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_81)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[ba_activitytype]( 	[ATTYPEID] [char](5) NOT NULL, 	[ATDESCRI] [varchar](5... (1575 chars)
		_CurrentNode = "RDK:137"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[ba_activitytype](ç§	[ATTYPEID] [char](5) NOT NULL,ç§	[ATDESCRI] [varchar](50) NULL,ç§	[ATINITIAL] [char](5) NULL,ç§	[ATIMAGE] [varchar](50) NULL,ç§	[ATCOLOR] [char](10) NULL,ç§	[ATSHOWTYPE] [char](1) NULL,ç§	[ATFLAGRES] [char](1) NULL,ç§	[ATFLAGPART] [char](1) NULL,ç§	[ATFLAGCOMPANY] [char](1) NULL,ç§	[ATFLAGOPPO] [char](1) NULL,ç§	[ATFLAGPERSON] [char](1) NULL,ç§	[ATFLAGPRJ] [char](1) NULL,ç§	[ATFLAGITEM] [char](1) NULL,ç§	[ATFLAGLOCATION] [char](1) NULL,ç§	[ATFLAGLOCK] [char](1) NULL,ç§	[ATFLAGTRAN] [char](1) NULL,ç§	[ATFLAGSTAT] [char](1) NULL,ç§	[ATSYSTEM] [char](1) NULL,ç§	[ATPRJTIME] [int] NULL,ç§	[ATPRJCOST] [int] NULL,ç§	[ATFLAGPRJTIME] [char](1) NULL,ç§	[ATNOCHECK] [char](1) NULL,ç§	[ATTASKOBJ] [varchar](50) NULL,ç§	[ATCATID] [char](3) NULL,ç§	[ATOBS] [char](1) NULL,ç§	[ATICAL] [char](1) NULL,ç§	[ATFLAGPROD] [char](1) NULL,ç§	[ATFLAGINCIDENT] [char](1) NULL,ç§	[cpccchk] [char](10) NULL,ç§	[ATDEFATTSEC] [char](1) NULL,ç§	[ATFLAGDEFNOTIFY] [char](1) NULL,ç§	[cpupdtms] [datetime] NULL,ç§	[ATDESCRI_ITA] [varchar](50) NULL,ç§	[ATDESCRI_ENG] [varchar](50) NULL,ç§	[ATDESCRI_FRA] [varchar](50) NULL,ç§	[ATDESCRI_DEU] [varchar](50) NULL,ç§	[ATDESCRI_ESP] [varchar](50) NULL,ç§	[ATFLAGMODIFY] [char](1) NULL,ç§	[ATFLAGLOCKRES] [char](1) NULL,ç§	[ATTASKNOTE] [text] NULL,ç§	[ATFLAGINITGROUP] [char](1) NULL,ç§ CONSTRAINT [pk_ba_activitytype] PRIMARY KEY CLUSTERED ç§(ç§	[ATTYPEID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]ç§")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[ba_properties]( 	[PRCODEID] [char](10) NOT NULL, 	[PRDESCRI] [varchar](20... (874 chars)
		_CurrentNode = "RDK:139"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[ba_properties](ç§	[PRCODEID] [char](10) NOT NULL,ç§	[PRDESCRI] [varchar](200) NULL,ç§	[PRTAG] [char](20) NULL,ç§	[PRSYSTEM] [char](1) NULL,ç§	[PRFORMAT] [char](1) NULL,ç§	[PRMODULE] [char](6) NULL,ç§	[PRFORM] [int] NULL,ç§	[PRLINKTO] [varchar](255) NULL,ç§	[PREDIT] [char](1) NULL,ç§	[PRTARGET] [char](20) NULL,ç§	[PRDECODED] [char](1) NULL,ç§	[PRDESEXT] [varchar](200) NULL,ç§	[cpccchk] [char](10) NULL,ç§	[cpupdtms] [datetime] NULL,ç§	[PRDESCRI_ITA] [varchar](200) NULL,ç§	[PRDESCRI_ENG] [varchar](200) NULL,ç§	[PRDESCRI_FRA] [varchar](200) NULL,ç§	[PRDESCRI_DEU] [varchar](200) NULL,ç§	[PRDESCRI_ESP] [varchar](200) NULL,ç§ CONSTRAINT [pk_ba_properties] PRIMARY KEY CLUSTERED ç§(ç§	[PRCODEID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]ç§")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[ba_prop_value]( 	[PVPROPID] [char](10) NOT NULL, 	[CPROWNUM] [int] NOT NU... (698 chars)
		_CurrentNode = "RDK:141"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[ba_prop_value](ç§	[PVPROPID] [char](10) NOT NULL,ç§	[CPROWNUM] [int] NOT NULL,ç§	[PVDEFAULT] [char](1) NULL,ç§	[PVVALUE] [varchar](50) NULL,ç§	[PVDESCRI] [varchar](200) NULL,ç§	[cpccchk] [char](10) NULL,ç§	[cpupdtms] [datetime] NULL,ç§	[PVDESCRI_ITA] [varchar](200) NULL,ç§	[PVDESCRI_ENG] [varchar](200) NULL,ç§	[PVDESCRI_FRA] [varchar](200) NULL,ç§	[PVDESCRI_DEU] [varchar](200) NULL,ç§	[PVDESCRI_ESP] [varchar](200) NULL,ç§ CONSTRAINT [pk_ba_prop_value] PRIMARY KEY CLUSTERED ç§(ç§	[PVPROPID] ASC,ç§	[CPROWNUM] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]ç§ç§")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[ba_activity_category]( 	[ACCATID] [char](3) NOT NULL, 	[ACDESCRI] [varcha... (654 chars)
		_CurrentNode = "RDK:143"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[ba_activity_category](ç§	[ACCATID] [char](3) NOT NULL,ç§	[ACDESCRI] [varchar](50) NULL,ç§	[ACSEQUENCE] [int] NULL,ç§	[cpccchk] [char](10) NULL,ç§	[cpupdtms] [datetime] NULL,ç§	[ACDESCRI_ENG] [varchar](50) NULL,ç§	[ACDESCRI_FRA] [varchar](50) NULL,ç§	[ACDESCRI_ITA] [varchar](50) NULL,ç§	[ACDESCRI_DEU] [varchar](50) NULL,ç§	[ACDESCRI_ESP] [varchar](50) NULL,ç§	[ACPARENTCAT] [char](3) NULL,ç§ CONSTRAINT [pk_ba_activity_category] PRIMARY KEY CLUSTERED ç§(ç§	[ACCATID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]ç§")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[wo_state]( 	[STCODEID] [char](5) NOT NULL, 	[STNAME] [char](20) NULL, 	[S... (1085 chars)
		_CurrentNode = "RDK:145"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[wo_state](ç§	[STCODEID] [char](5) NOT NULL,ç§	[STNAME] [char](20) NULL,ç§	[STDESCRI] [varchar](200) NULL,ç§	[STTYPE] [char](2) NULL,ç§	[STIMAGE] [varchar](100) NULL,ç§	[STDEFAULT] [char](1) NULL,ç§	[STCANCLOSE] [char](1) NULL,ç§	[STREFID] [decimal](10, 0) NULL,ç§	[STOBS] [char](1) NULL,ç§	[STPROCESS] [varchar](100) NULL,ç§	[STSYSTEM] [char](1) NULL,ç§	[STWARNING] [char](1) NULL,ç§	[STNOTIFY] [char](1) NULL,ç§	[cpccchk] [char](10) NULL,ç§	[STSEQUENCE] [int] NULL,ç§	[cpupdtms] [datetime] NULL,ç§	[STNAME_ITA] [char](20) NULL,ç§	[STDESCRI_ITA] [varchar](200) NULL,ç§	[STNAME_ENG] [char](20) NULL,ç§	[STDESCRI_ENG] [varchar](200) NULL,ç§	[STNAME_FRA] [char](20) NULL,ç§	[STDESCRI_FRA] [varchar](200) NULL,ç§	[STNAME_DEU] [char](20) NULL,ç§	[STNAME_ESP] [char](20) NULL,ç§	[STDESCRI_DEU] [varchar](200) NULL,ç§	[STDESCRI_ESP] [varchar](200) NULL,ç§ CONSTRAINT [pk_wo_state] PRIMARY KEY CLUSTERED ç§(ç§	[STCODEID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]ç§ç§")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[pr_item]( 	[ITITEMID] [char](10) NOT NULL, 	[ITDESCRI] [varchar](255) NUL... (774 chars)
		_CurrentNode = "RDK:147"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[pr_item](ç§	[ITITEMID] [char](10) NOT NULL,ç§	[ITDESCRI] [varchar](255) NULL,ç§	[ITNOTE] [text] NULL,ç§	[ITCAT] [char](3) NULL,ç§	[ITPRJTYPE] [char](5) NULL,ç§	[ITPLANNER] [char](1) NULL,ç§	[ITESTPLANNER] [char](1) NULL,ç§	[cpccchk] [char](10) NULL,ç§	[cpupdtms] [datetime] NULL,ç§	[ITDESCRI_ITA] [varchar](255) NULL,ç§	[ITDESCRI_ENG] [varchar](255) NULL,ç§	[ITDESCRI_FRA] [varchar](255) NULL,ç§	[ITDESCRI_DEU] [varchar](255) NULL,ç§	[ITDESCRI_ESP] [varchar](255) NULL,ç§	[ITNOTIFYGROUP] [char](1) NULL,ç§ CONSTRAINT [pk_pr_item] PRIMARY KEY CLUSTERED ç§(ç§	[ITITEMID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]ç§")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[pr_type]( 	[PTTYPEID] [char](5) NOT NULL, 	[PTDESCRI] [varchar](50) NULL,... (1009 chars)
		_CurrentNode = "RDK:149"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[pr_type](ç§	[PTTYPEID] [char](5) NOT NULL,ç§	[PTDESCRI] [varchar](50) NULL,ç§	[PTWORKFLOW] [char](2) NULL,ç§	[PTCODEGEN] [varchar](50) NULL,ç§	[PTFLAGGROUP] [char](1) NULL,ç§	[cpccchk] [char](10) NULL,ç§	[PTCOLOR] [char](10) NULL,ç§	[cpupdtms] [datetime] NULL,ç§	[PTDESCRI_ITA] [varchar](50) NULL,ç§	[PTDESCRI_ENG] [varchar](50) NULL,ç§	[PTDESCRI_FRA] [varchar](50) NULL,ç§	[PTDESCRI_DEU] [varchar](50) NULL,ç§	[PTDESCRI_ESP] [varchar](50) NULL,ç§	[PTRUNTYPE] [char](1) NOT NULL,ç§	[PTCODEGENJSP] [varchar](100) NULL,ç§	[PTBLOCKREAL] [char](1) NOT NULL,ç§	[PTBLOCKEST] [char](1) NULL,ç§	[PTEDITGROUP] [int] NULL,ç§	[PTEDITCODE] [char](1) NULL,ç§	[PTBLOCKDATEPH] [char](1) NULL,ç§	[PTNOTOPENPH] [char](1) NULL,ç§	[PTREPLAN] [char](1) NULL,ç§	[PTREPLANIF] [char](1) NULL,ç§ CONSTRAINT [pk_pr_type] PRIMARY KEY CLUSTERED ç§(ç§	[PTTYPEID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]ç§")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[dm_class]( 	[CDCLASSID] [char](10) NOT NULL, 	[CDDESCRI] [varchar](50) NU... (1391 chars)
		_CurrentNode = "RDK:151"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[dm_class](ç§	[CDCLASSID] [char](10) NOT NULL,ç§	[CDDESCRI] [varchar](50) NULL,ç§	[CDTYPE] [char](1) NULL,ç§	[CDFLGPATH] [char](1) NULL,ç§	[CDPATH] [decimal](10, 0) NULL,ç§	[CDTEMPLATE] [varchar](50) NULL,ç§	[CDVERSIONABLE] [char](1) NULL,ç§	[CDEDITPROP] [char](1) NULL,ç§	[CDIMAGE] [varchar](100) NULL,ç§	[CDPROTOCOL] [varchar](50) NULL,ç§	[CDDEFAULT] [char](1) NULL,ç§	[CDPDF] [char](1) NULL,ç§	[CDMERGE] [char](1) NULL,ç§	[CDSCRIPT] [varchar](50) NULL,ç§	[CDIMAGELINK] [varchar](100) NULL,ç§	[CDWORKFLOW] [char](2) NULL,ç§	[CDTAG] [text] NULL,ç§	[CDRESERVED] [int] NULL,ç§	[CDOBSOLETE] [char](1) NULL,ç§	[CDENTITYLINK] [char](1) NULL,ç§	[CDATTACH] [char](1) NULL,ç§	[CDMAILBCC] [char](1) NULL,ç§	[CDCANMODIFY] [char](1) NULL,ç§	[CDDOCTITLE] [varchar](50) NULL,ç§	[cpccchk] [char](10) NULL,ç§	[CDINHERITSEC] [char](1) NULL,ç§	[cpupdtms] [datetime] NULL,ç§	[CDDESCRI_ITA] [varchar](50) NULL,ç§	[CDDESCRI_ENG] [varchar](50) NULL,ç§	[CDDESCRI_FRA] [varchar](50) NULL,ç§	[CDDESCRI_GER] [varchar](50) NULL,ç§	[CDDESCRI_SPA] [varchar](50) NULL,ç§	[CDDESCRI_DEU] [varchar](50) NULL,ç§	[CDDESCRI_ESP] [varchar](50) NULL,ç§	[CDCAT] [char](5) NULL,ç§ CONSTRAINT [pk_dm_class] PRIMARY KEY CLUSTERED ç§(ç§	[CDCLASSID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[dm_folder_001]( 	[DMCODEID] [decimal](10, 0) NOT NULL, 	[DMVERID] [int] N... (1395 chars)
		_CurrentNode = "RDK:153"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[dm_folder_001](ç§	[DMCODEID] [decimal](10, 0) NOT NULL,ç§	[DMVERID] [int] NOT NULL,ç§	[DMDESCRI] [varchar](100) NULL,ç§	[DMTYPE] [char](1) NULL,ç§	[DMPROTOCOL] [char](20) NULL,ç§	[DMPARENT] [decimal](10, 0) NULL,ç§	[DMNUMELEMENT] [int] NULL,ç§	[DMKEYWORD] [varchar](100) NULL,ç§	[DMLINKTO] [decimal](10, 0) NULL,ç§	[DMCLASS] [char](10) NULL,ç§	[DMRESERVED] [int] NULL,ç§	[DMCREATE] [int] NULL,ç§	[DMCREATEAT] [datetime] NULL,ç§	[DMMODIFY] [int] NULL,ç§	[DMMODIFYAT] [datetime] NULL,ç§	[DMNOTE] [text] NULL,ç§	[DMSIZE] [decimal](12, 0) NULL,ç§	[DMSPECIAL] [char](1) NULL,ç§	[DMSTATEBY] [int] NULL,ç§	[DMSTATE] [char](5) NULL,ç§	[DMLASTVER] [char](1) NULL,ç§	[DMWORKFLOW] [char](2) NULL,ç§	[DMSECURITY] [char](1) NULL,ç§	[DMLANGUAGE] [char](3) NULL,ç§	[DMSTARTVALDT] [datetime] NULL,ç§	[DMENDVALDT] [datetime] NULL,ç§	[DMSOCKET] [char](1) NULL,ç§	[cpccchk] [char](10) NULL,ç§	[cpupdtms] [datetime] NULL,ç§	[offlineupd] [char](1) NULL,ç§	[DMDESCRI_DEU] [varchar](100) NULL,ç§	[DMDESCRI_ENG] [varchar](100) NULL,ç§	[DMDESCRI_ESP] [varchar](100) NULL,ç§	[DMDESCRI_FRA] [varchar](100) NULL,ç§	[DMDESCRI_ITA] [varchar](100) NULL,ç§ CONSTRAINT [pk_dm_folder_001] PRIMARY KEY CLUSTERED ç§(ç§	[DMCODEID] ASC,ç§	[DMVERID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]ç§")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[ba_source]( 	[SOID] [int] NOT NULL, 	[SODESCRI] [varchar](50) NULL, 	[cpc... (565 chars)
		_CurrentNode = "RDK:155"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[ba_source](ç§	[SOID] [int] NOT NULL,ç§	[SODESCRI] [varchar](50) NULL,ç§	[cpccchk] [char](10) NULL,ç§	[cpupdtms] [datetime] NULL,ç§	[SODESCRI_ITA] [varchar](50) NULL,ç§	[SODESCRI_ENG] [varchar](50) NULL,ç§	[SODESCRI_FRA] [varchar](50) NULL,ç§	[SODESCRI_ESP] [varchar](50) NULL,ç§	[SODESCRI_DEU] [varchar](50) NULL,ç§ CONSTRAINT [pk_ba_source] PRIMARY KEY CLUSTERED ç§(ç§	[SOID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]ç§")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[LANGUAGE]( 	[TAG] [varchar](255) NOT NULL, 	[ENG] [varchar](255) NULL, 	[... (444 chars)
		_CurrentNode = "RDK:157"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[LANGUAGE](ç§	[TAG] [varchar](255) NOT NULL,ç§	[ENG] [varchar](255) NULL,ç§	[ITA] [varchar](255) NULL,ç§	[ESP] [varchar](255) NULL,ç§	[FRA] [varchar](255) NULL,ç§	[DEU] [varchar](255) NULL,ç§	[cpupdtms] [datetime] NULL,ç§PRIMARY KEY CLUSTERED ç§(ç§	[TAG] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY]ç§")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[pr_project_001]( 	[PJPRJID] [char](10) NOT NULL, 	[PJDESCRI] [varchar](80... (1573 chars)
		_CurrentNode = "RDK:159"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[pr_project_001](ç§	[PJPRJID] [char](10) NOT NULL,ç§	[PJDESCRI] [varchar](80) NULL,ç§	[PJCREATE] [int] NULL,ç§	[PJCREATEAT] [datetime] NULL,ç§	[PJOBSOLETE] [char](1) NULL,ç§	[PJMANAGER] [int] NULL,ç§	[PJSTATE] [char](5) NULL,ç§	[PJPERCCOM] [int] NULL,ç§	[PJTYPE] [char](5) NULL,ç§	[PJTEXT] [text] NULL,ç§	[PJPRIORITY] [int] NULL,ç§	[PJBEGIN] [datetime] NULL,ç§	[PJEND] [datetime] NULL,ç§	[PJCOMPANY] [char](15) NULL,ç§	[PJOPPID] [char](10) NULL,ç§	[PJHOUR] [decimal](10, 0) NULL,ç§	[PJESTHOUR] [decimal](10, 0) NULL,ç§	[PJNOTE] [text] NULL,ç§	[PJTEMPLATE] [char](1) NULL,ç§	[PJTEMPID] [char](10) NULL,ç§	[PJOFFERHOUR] [decimal](10, 0) NULL,ç§	[PJMODIFY] [int] NULL,ç§	[PJMODIFYAT] [datetime] NULL,ç§	[PJESTBEGIN] [datetime] NULL,ç§	[PJESTEND] [datetime] NULL,ç§	[PJAMOUNT] [decimal](20, 4) NULL,ç§	[PJPREVPRJ] [char](10) NULL,ç§	[PJPREVITEM] [char](10) NULL,ç§	[PJPDMWORKFLOW] [char](2) NULL,ç§	[PJPDMECO] [char](1) NULL,ç§	[PJSECURITY] [char](1) NULL,ç§	[cpccchk] [char](10) NULL,ç§	[MBK_CODOFFER] [char](20) NULL,ç§	[pjdescr_good] [char](80) NULL,ç§	[PJCODE] [varchar](30) NOT NULL,ç§	[cpupdtms] [datetime] NULL,ç§	[offlineupd] [char](1) NULL,ç§	[MBLASTVER] [char](1) NULL,ç§	[PJICON] [varchar](100) NULL,ç§	[PJORIGID] [char](10) NULL,ç§	[PJSIMORIGID] [char](10) NULL,ç§	[PJBU] [int] NULL,ç§	[MB_STARTREPLAN] [char](1) NULL,ç§ CONSTRAINT [pk_pr_project_001] PRIMARY KEY CLUSTERED ç§(ç§	[PJPRJID] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")))
		'Add FusionCreateTables <-- CREATE TABLE [dbo].[dm_folder_prop_001]( 	[PPNODEID] [decimal](10, 0) NOT NULL, 	[PPVERID] [i... (589 chars)
		_CurrentNode = "RDK:168"
		FusionCreateTables.Add(CompilerUtil.Clone(EvalConstant(CompilerUtil.GetListItemType(FusionCreateTables.GetType), "CREATE TABLE [dbo].[dm_folder_prop_001](ç§	[PPNODEID] [decimal](10, 0) NOT NULL,ç§	[PPVERID] [int] NOT NULL,ç§	[CPROWNUM] [int] NOT NULL,ç§	[PPNAMEID] [char](10) NULL,ç§	[PPVALUE] [varchar](200) NULL,ç§	[PPVALUEHTML] [text] NULL,ç§	[cpccchk] [char](10) NULL,ç§	[cpupdtms] [datetime] NULL,ç§ CONSTRAINT [pk_dm_folder_prop_001] PRIMARY KEY CLUSTERED ç§(ç§	[PPNODEID] ASC,ç§	[PPVERID] ASC,ç§	[CPROWNUM] ASCç§)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]ç§) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]")))
		'FOREACH F_table IN FusionTables BYREF
		Call FOREACHLOOP_K_89()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Close DB Connection (FUSION SERVER)
		_CurrentNode = "RDK:85"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_85 as New Generic.list(of object)
		ActionArgs_K_85.Add("FusionTest") 'ConnectionName IN
		ActionArgs_K_85.Add(2) 'Transaction IN
		Dim _ActionArgs_K_85 As object() = ActionArgs_K_85.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_85)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Close DB Connection (FUSION LOCAL)
		_CurrentNode = "RDK:87"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_87 as New Generic.list(of object)
		ActionArgs_K_87.Add("Fusion_Local") 'ConnectionName IN
		ActionArgs_K_87.Add(-1) 'Transaction IN
		Dim _ActionArgs_K_87 As object() = ActionArgs_K_87.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_87)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'FOREACH F_table IN FusionTables BYREF
	Private Sub FOREACHLOOP_K_89()
		_CurrentNode = "RDK:89"
		Dim Values_RDK_89 as object = FusionTables
		Dim Index_RDK_89 as integer
		Dim MaxCount_RDK_89 as integer = CompilerUtil.Count(Values_RDK_89)
		If MaxCount_RDK_89 <= 0 then return
		Index_RDK_89 = 0
		i = 1
	next_foreach:
		F_table = Values_RDK_89(Index_RDK_89)
		
		'Execute SQL Statement
		_CurrentNode = "RDK:97"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_97 as New Generic.list(of object)
		ActionArgs_K_97.Add("Fusion_Local") 'ConnectionName IN
		ActionArgs_K_97.Add(EvalExpression("SqlStatement_K_97")) 'SqlStatement IN
		ActionArgs_K_97.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_97.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_97 As object() = ActionArgs_K_97.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_97)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'If F_table="dm_folder_001" is True OR ...
		Call IFTHENELSE_K_178()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_89 += 1
		If Index_RDK_89 >= MaxCount_RDK_89 then return
		i += 1
		goto next_foreach
	End Sub

	'If F_table="dm_folder_001" is True OR ...
	Private Sub IFTHENELSE_K_178()
		_CurrentNode = "RDK:178"
		'Group Conditions
		Dim _GroupExecute As Boolean = True
		if (EvalExpression("CondExp1_K_178") = True) then goto exec_group		'F_table="dm_folder_001"
		if NOT (EvalExpression("CondExp2_K_178") = True) then goto skip_group		'F_table="dm_folder_prop_001"
		GoTo exec_group
skip_group:
		_GroupExecute = False
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If F_table="dm_folder_001" is True OR ...
			Call THENGROUP_K_179()

		else
			'Execute SQL Statement
			Call ELSEGROUP_K_180()

		End if
	End Sub

	'If F_table="dm_folder_001" is True OR ...
	Private Sub THENGROUP_K_179()
		_CurrentNode = "RDK:179"
		'Set MinCounter = 0
		_CurrentNode = "RDK:346"
		MinCounter = EvalConstant(MinCounter.GetType, "0")
		
		'Set MaxCounter = 10000
		_CurrentNode = "RDK:348"
		MaxCounter = EvalConstant(MaxCounter.GetType, "10000")
		
		'Set endwhile = False
		_CurrentNode = "RDK:356"
		endwhile = EvalExpression("Set_endwhile_K_356")
		
		'While endwhile is False
		Call WHILELOOP_K_219()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'While endwhile is False
	Private Sub WHILELOOP_K_219()
next_iteration:
		_CurrentNode = "RDK:219"
		'Group Conditions
		Dim _GroupExecute As Boolean = NOT EvalExpression("CondExp1_K_219")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		
		'Select DB Values
		_CurrentNode = "RDK:91"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_91 as New Generic.list(of object)
		ActionArgs_K_91.Add("FusionTest") 'ConnectionName IN
		ActionArgs_K_91.Add(EvalExpression("SelectQuery_K_91")) 'SelectQuery IN
		ActionArgs_K_91.Add(2) 'SelectQueryType IN
		ActionArgs_K_91.Add(Nothing) 'FirstValue OUT
		ActionArgs_K_91.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_91.Add(table) 'AllRows OUT
		ActionArgs_K_91.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_91.Add(k) 'NumRows OUT
		ActionArgs_K_91.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_91.Add(Nothing) 'ColumnHeaders OUT
		ActionArgs_K_91.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_91 As object() = ActionArgs_K_91.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_91)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		table = _ActionArgs_K_91(5)		'OUT
		k = _ActionArgs_K_91(7)		'OUT
		
		'Set endwhile = IIF(k=0, True, False)
		_CurrentNode = "RDK:225"
		endwhile = EvalExpression("Set_endwhile_K_225")
		
		'Set MinCounter = MaxCounter
		_CurrentNode = "RDK:226"
		MinCounter = EvalExpression("Set_MinCounter_K_226")
		
		'Set MaxCounter = MaxCounter+10000
		_CurrentNode = "RDK:228"
		MaxCounter = EvalExpression("Set_MaxCounter_K_228")
		
		'FOREACH row IN table BYREF
		Call FOREACHLOOP_K_203()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		goto next_iteration
	End Sub

	'FOREACH row IN table BYREF
	Private Sub FOREACHLOOP_K_203()
		_CurrentNode = "RDK:203"
		Dim Values_RDK_203 as object = table
		Dim Index_RDK_203 as integer
		Dim MaxCount_RDK_203 as integer = CompilerUtil.Count(Values_RDK_203)
		If MaxCount_RDK_203 <= 0 then return
		Index_RDK_203 = 0
	next_foreach:
		row = Values_RDK_203(Index_RDK_203)
		
		'Set query_insert = dateformat+"INSERT INTO "+F_table+" VALUES("
		_CurrentNode = "RDK:199"
		query_insert = EvalExpression("Set_query_insert_K_199")
		
		'FOREACH field IN row BYREF
		Call FOREACHLOOP_K_201()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set query_insert = query_insert+")"
		_CurrentNode = "RDK:309"
		query_insert = EvalExpression("Set_query_insert_K_309")
		
		'Execute SQL Statement
		_CurrentNode = "RDK:202"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_202 as New Generic.list(of object)
		ActionArgs_K_202.Add("Fusion_Local") 'ConnectionName IN
		ActionArgs_K_202.Add(EvalExpression("SqlStatement_K_202")) 'SqlStatement IN
		ActionArgs_K_202.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_202.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_202 As object() = ActionArgs_K_202.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_202)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		Index_RDK_203 += 1
		If Index_RDK_203 >= MaxCount_RDK_203 then return
		goto next_foreach
	End Sub

	'FOREACH field IN row BYREF
	Private Sub FOREACHLOOP_K_201()
		_CurrentNode = "RDK:201"
		Dim Values_RDK_201 as object = row
		Dim Index_RDK_201 as integer
		Dim MaxCount_RDK_201 as integer = CompilerUtil.Count(Values_RDK_201)
		If MaxCount_RDK_201 <= 0 then return
		Index_RDK_201 = 0
		j = 1
	next_foreach:
		field = Values_RDK_201(Index_RDK_201)
		
		'If j>1 is True
		Call IFTHENELSE_K_303()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'Set query_insert = query_insert+IIF(field<>"","'"+StrSql(field)+"'", "null")
		_CurrentNode = "RDK:200"
		query_insert = EvalExpression("Set_query_insert_K_200")
		
	next_iteration:
		Index_RDK_201 += 1
		If Index_RDK_201 >= MaxCount_RDK_201 then return
		j += 1
		goto next_foreach
	End Sub

	'If j>1 is True
	Private Sub IFTHENELSE_K_303()
		_CurrentNode = "RDK:303"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_303")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If j>1 is True
			Call THENGROUP_K_302()

		End if
	End Sub

	'If j>1 is True
	Private Sub THENGROUP_K_302()
		_CurrentNode = "RDK:302"
		'Set query_insert = query_insert+","
		_CurrentNode = "RDK:301"
		query_insert = EvalExpression("Set_query_insert_K_301")
		
	End Sub

	'Execute SQL Statement
	Private Sub ELSEGROUP_K_180()
		_CurrentNode = "RDK:180"
		'Select DB Values
		_CurrentNode = "RDK:188"		'ACTION RDEngineering_DBSelect
		Dim ActionArgs_K_188 as New Generic.list(of object)
		ActionArgs_K_188.Add("FusionTest") 'ConnectionName IN
		ActionArgs_K_188.Add(EvalExpression("SelectQuery_K_188")) 'SelectQuery IN
		ActionArgs_K_188.Add(2) 'SelectQueryType IN
		ActionArgs_K_188.Add(Nothing) 'FirstValue OUT
		ActionArgs_K_188.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_188.Add(table) 'AllRows OUT
		ActionArgs_K_188.Add(Nothing) 'FirstColumn OUT
		ActionArgs_K_188.Add(Nothing) 'NumRows OUT
		ActionArgs_K_188.Add(Nothing) 'ColumnHeader OUT
		ActionArgs_K_188.Add(Nothing) 'ColumnHeaders OUT
		ActionArgs_K_188.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_188 As object() = ActionArgs_K_188.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelect",_ActionArgs_K_188)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		table = _ActionArgs_K_188(5)		'OUT
		
		'FOREACH row IN table BYREF
		Call FOREACHLOOP_K_107()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'FOREACH row IN table BYREF
	Private Sub FOREACHLOOP_K_107()
		_CurrentNode = "RDK:107"
		Dim Values_RDK_107 as object = table
		Dim Index_RDK_107 as integer
		Dim MaxCount_RDK_107 as integer = CompilerUtil.Count(Values_RDK_107)
		If MaxCount_RDK_107 <= 0 then return
		Index_RDK_107 = 0
	next_foreach:
		row = Values_RDK_107(Index_RDK_107)
		
		'Set query_insert = "SET DATEFORMAT dmy;INSERT INTO "+F_table+" VALUES("
		_CurrentNode = "RDK:103"
		query_insert = EvalExpression("Set_query_insert_K_103")
		
		'FOREACH field IN row BYREF
		Call FOREACHLOOP_K_105()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set query_insert = query_insert+")"
		_CurrentNode = "RDK:311"
		query_insert = EvalExpression("Set_query_insert_K_311")
		
		'Execute SQL Statement
		_CurrentNode = "RDK:106"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_106 as New Generic.list(of object)
		ActionArgs_K_106.Add("Fusion_Local") 'ConnectionName IN
		ActionArgs_K_106.Add(EvalExpression("SqlStatement_K_106")) 'SqlStatement IN
		ActionArgs_K_106.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_106.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_106 As object() = ActionArgs_K_106.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_106)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		Index_RDK_107 += 1
		If Index_RDK_107 >= MaxCount_RDK_107 then return
		goto next_foreach
	End Sub

	'FOREACH field IN row BYREF
	Private Sub FOREACHLOOP_K_105()
		_CurrentNode = "RDK:105"
		Dim Values_RDK_105 as object = row
		Dim Index_RDK_105 as integer
		Dim MaxCount_RDK_105 as integer = CompilerUtil.Count(Values_RDK_105)
		If MaxCount_RDK_105 <= 0 then return
		Index_RDK_105 = 0
		j = 1
	next_foreach:
		field = Values_RDK_105(Index_RDK_105)
		
		'If j>1 is True
		Call IFTHENELSE_K_319()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'If F_table="pr_project_001" is True AND ...
		Call IFTHENELSE_K_328()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'Set query_insert = query_insert+IIF(field<>"","'"+StrSql(field)+"'", IIF(j=35, "''", "null"))
		_CurrentNode = "RDK:104"
		query_insert = EvalExpression("Set_query_insert_K_104")
		
	next_iteration:
		Index_RDK_105 += 1
		If Index_RDK_105 >= MaxCount_RDK_105 then return
		j += 1
		goto next_foreach
	End Sub

	'If j>1 is True
	Private Sub IFTHENELSE_K_319()
		_CurrentNode = "RDK:319"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_319")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If j>1 is True
			Call THENGROUP_K_318()

		End if
	End Sub

	'If j>1 is True
	Private Sub THENGROUP_K_318()
		_CurrentNode = "RDK:318"
		'Set query_insert = query_insert+","
		_CurrentNode = "RDK:317"
		query_insert = EvalExpression("Set_query_insert_K_317")
		
	End Sub

	'If F_table="pr_project_001" is True AND ...
	Private Sub IFTHENELSE_K_328()
		_CurrentNode = "RDK:328"
		'Group Conditions
		Dim _GroupExecute As Boolean = True
		if NOT (EvalExpression("CondExp1_K_328") = True) then goto skip_group		'F_table="pr_project_001"
		if NOT (EvalExpression("CondExp2_K_328") = True) then goto skip_group		'j=26
		GoTo exec_group
skip_group:
		_GroupExecute = False
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If F_table="pr_project_001" is True AND ...
			Call THENGROUP_K_329()

		End if
	End Sub

	'If F_table="pr_project_001" is True AND ...
	Private Sub THENGROUP_K_329()
		_CurrentNode = "RDK:329"
		'Set field = StrReplace(field, ",", ".")
		_CurrentNode = "RDK:338"
		field = EvalExpression("Set_field_K_338")
		
	End Sub



#End Region

End Class
