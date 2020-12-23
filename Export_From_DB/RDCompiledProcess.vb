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
		IniFilePath = EvalExpression("Set_IniFilePath_K_7083")
		Languages = EvalConstant(Languages.GetType, "LIST { ""ITA"",""ENG"",""ESP"",""FRA"",""DEU"" }")
		cdata_start = "<![CDATA["
		cdata_end = "]"
		cdata_start = "<![CDATA["
		cdata_end = "]"


        'CALL TO MAIN PROCESS
        Call Main_Group_K_4()

    End Sub

#Region " --- PROCESS FUNCTIONS TABLE "

	Public Sub Void()	'FUNCTION: 
		_CurrentNode = "RDK:1556"

exit_function:
	End sub



#End Region

#End Region

#Region " --- PROCESS CODE TABLE "

	'Main Group *LOG_DISABLED
	Private Sub Main_Group_K_4()
		_CurrentNode = "RDK:4"
		'INIT (Set Connection Strings)
		Call INIT_K_7115()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Open DB Connection
		_CurrentNode = "RDK:136"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_136 as New Generic.list(of object)
		ActionArgs_K_136.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_136.Add(EvalExpression("ConnectionString_K_136")) 'ConnectionString IN
		ActionArgs_K_136.Add(0) 'Transaction IN
		ActionArgs_K_136.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_136 As object() = ActionArgs_K_136.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_136)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Select DB Structured (FIND NEW)
		_CurrentNode = "RDK:344"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_344 as New Generic.list(of object)
		ActionArgs_K_344.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_344.Add(1) 'SelectQueryMode IN
		ActionArgs_K_344.Add(Nothing) 'SelectTable IN
		ActionArgs_K_344.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_344.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_344.Add("SELECT * FROM TRADS WHERE NEW=1") 'SelectQuery IN
		ActionArgs_K_344.Add(2) 'SelectQueryType IN
		ActionArgs_K_344.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_344.Add(TradTableToAdd) 'AllRows OUT
		ActionArgs_K_344.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_344 As object() = ActionArgs_K_344.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_344,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		TradTableToAdd = _ActionArgs_K_344(8)		'OUT
		
		'New To Add <Count(TradTableToAdd)>0 is True>
		Call New_To_Add_K_373()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Select DB Structured (FIND UPDATED)
		_CurrentNode = "RDK:139"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_139 as New Generic.list(of object)
		ActionArgs_K_139.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_139.Add(1) 'SelectQueryMode IN
		ActionArgs_K_139.Add(Nothing) 'SelectTable IN
		ActionArgs_K_139.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_139.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_139.Add("SELECT * FROM TRADS WHERE UPDATED=1 AND (NEW<>1 or NEW IS NULL)") 'SelectQuery IN
		ActionArgs_K_139.Add(2) 'SelectQueryType IN
		ActionArgs_K_139.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_139.Add(TradTableToUpdate) 'AllRows OUT
		ActionArgs_K_139.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_139 As object() = ActionArgs_K_139.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_139,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		TradTableToUpdate = _ActionArgs_K_139(8)		'OUT
		
		'FOREACH Trad IN TradTableToUpdate BYREF
		Call FOREACHLOOP_K_140()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Select DB Structured (FIND DELETED)
		_CurrentNode = "RDK:11854"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_11854 as New Generic.list(of object)
		ActionArgs_K_11854.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_11854.Add(1) 'SelectQueryMode IN
		ActionArgs_K_11854.Add(Nothing) 'SelectTable IN
		ActionArgs_K_11854.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_11854.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_11854.Add("SELECT * FROM TRADS WHERE DELETED=1") 'SelectQuery IN
		ActionArgs_K_11854.Add(2) 'SelectQueryType IN
		ActionArgs_K_11854.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_11854.Add(TradTableToDelete) 'AllRows OUT
		ActionArgs_K_11854.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_11854 As object() = ActionArgs_K_11854.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_11854,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		TradTableToDelete = _ActionArgs_K_11854(8)		'OUT
		
		'FOREACH Trad IN TradTableToDelete BYREF
		Call FOREACHLOOP_K_12532()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Execute SQL Statement
		_CurrentNode = "RDK:6958"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_6958 as New Generic.list(of object)
		ActionArgs_K_6958.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_6958.Add("TRUNCATE TABLE IS_MODIFY_LOCKED") 'SqlStatement IN
		ActionArgs_K_6958.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_6958.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_6958 As object() = ActionArgs_K_6958.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_6958)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Close DB Connection
		_CurrentNode = "RDK:138"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_138 as New Generic.list(of object)
		ActionArgs_K_138.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_138.Add(0) 'Transaction IN
		Dim _ActionArgs_K_138 As object() = ActionArgs_K_138.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_138)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'INIT (Set Connection Strings)
	Private Sub INIT_K_7115()
		_CurrentNode = "RDK:7115"
		'Set ConnStr_FUSION = ReadIni(IniFilePath, "FUSION", "ConnectionString")
		_CurrentNode = "RDK:7109"
		ConnStr_FUSION = EvalExpression("Set_ConnStr_FUSION_K_7109")
		
		'Set ConnStr_LOCAL = ReadIni(IniFilePath, "LOCAL", "ConnectionString")
		_CurrentNode = "RDK:7110"
		ConnStr_LOCAL = EvalExpression("Set_ConnStr_LOCAL_K_7110")
		
		'Set dateformat = ReadIni(IniFilePath, "FUSION", "SetDateFormat")
		_CurrentNode = "RDK:18091"
		dateformat = EvalExpression("Set_dateformat_K_18091")
		
		'Set ConnStr_PDM = ReadIni(IniFilePath, "PDM", "ConnectionString")
		_CurrentNode = "RDK:7111"
		ConnStr_PDM = EvalExpression("Set_ConnStr_PDM_K_7111")
		
		'Set GS_TradPath = ProcPath()+ReadIni(IniFilePath, "GRAPHICAL STUDIO", "TranslationPath")
		_CurrentNode = "RDK:7112"
		GS_TradPath = EvalExpression("Set_GS_TradPath_K_7112")
		
		'Set CRM_TradPath = ProcPath()+ReadIni(IniFilePath, "CRM", "MBPath")
		_CurrentNode = "RDK:7113"
		CRM_TradPath = EvalExpression("Set_CRM_TradPath_K_7113")
		
		'Set Languages = SplitStr(ReadIni(IniFilePath, "LANGUAGES", "Languages"), ",", "")
		_CurrentNode = "RDK:7114"
		Languages = EvalExpression("Set_Languages_K_7114")
		
	End Sub

	'New To Add <Count(TradTableToAdd)>0 is True>
	Private Sub New_To_Add_K_373()
		_CurrentNode = "RDK:373"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_373")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		'Open DB Connection
		_CurrentNode = "RDK:407"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_407 as New Generic.list(of object)
		ActionArgs_K_407.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_407.Add(EvalExpression("ConnectionString_K_407")) 'ConnectionString IN
		ActionArgs_K_407.Add(1) 'Transaction IN
		ActionArgs_K_407.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_407 As object() = ActionArgs_K_407.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_407)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'FOREACH Trad IN TradTableToAdd BYREF
		Call FOREACHLOOP_K_364()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Close DB Connection
		_CurrentNode = "RDK:419"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_419 as New Generic.list(of object)
		ActionArgs_K_419.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_419.Add(1) 'Transaction IN
		Dim _ActionArgs_K_419 As object() = ActionArgs_K_419.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_419)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'FOREACH Trad IN TradTableToAdd BYREF
	Private Sub FOREACHLOOP_K_364()
		_CurrentNode = "RDK:364"
		Dim Values_RDK_364 as object = EvalExpression("ForEachValues_K_364")
		Dim MaxCount_RDK_364 as integer = CompilerUtil.Count(Values_RDK_364)
		If MaxCount_RDK_364 <= 0 then return
		i = 0
	next_foreach:
		Trad = Values_RDK_364(i)
		
		'Select DB Structured
		_CurrentNode = "RDK:433"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_433 as New Generic.list(of object)
		ActionArgs_K_433.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_433.Add(1) 'SelectQueryMode IN
		ActionArgs_K_433.Add(Nothing) 'SelectTable IN
		ActionArgs_K_433.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_433.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_433.Add(EvalExpression("SelectQuery_K_433")) 'SelectQuery IN
		ActionArgs_K_433.Add(1) 'SelectQueryType IN
		ActionArgs_K_433.Add(MetaTrad) 'FirstRow OUT
		ActionArgs_K_433.Add(Nothing) 'AllRows OUT
		ActionArgs_K_433.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_433 As object() = ActionArgs_K_433.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_433,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		MetaTrad = _ActionArgs_K_433(7)		'OUT
		
		'Execute SQL Statement
		_CurrentNode = "RDK:393"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_393 as New Generic.list(of object)
		ActionArgs_K_393.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_393.Add(EvalExpression("SqlStatement_K_393")) 'SqlStatement IN
		ActionArgs_K_393.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_393.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_393 As object() = ActionArgs_K_393.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_393)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		i += 1
		If i >= MaxCount_RDK_364 then return
		goto next_foreach
	End Sub

	'FOREACH Trad IN TradTableToUpdate BYREF
	Private Sub FOREACHLOOP_K_140()
		_CurrentNode = "RDK:140"
		Dim Values_RDK_140 as object = TradTableToUpdate
		Dim Index_RDK_140 as integer
		Dim MaxCount_RDK_140 as integer = CompilerUtil.Count(Values_RDK_140)
		If MaxCount_RDK_140 <= 0 then return
		Index_RDK_140 = 0
		i = 1
	next_foreach:
		Trad = Values_RDK_140(Index_RDK_140)
		
		'Select DB Structured
		_CurrentNode = "RDK:144"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_144 as New Generic.list(of object)
		ActionArgs_K_144.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_144.Add(1) 'SelectQueryMode IN
		ActionArgs_K_144.Add(Nothing) 'SelectTable IN
		ActionArgs_K_144.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_144.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_144.Add(EvalExpression("SelectQuery_K_144")) 'SelectQuery IN
		ActionArgs_K_144.Add(2) 'SelectQueryType IN
		ActionArgs_K_144.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_144.Add(MetaTradTableToUpdate) 'AllRows OUT
		ActionArgs_K_144.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_144 As object() = ActionArgs_K_144.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_144,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		MetaTradTableToUpdate = _ActionArgs_K_144(8)		'OUT
		
		'FOREACH MetaTrad IN MetaTradTableToUpdate BYREF
		Call FOREACHLOOP_K_2952()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	next_iteration:
		Index_RDK_140 += 1
		If Index_RDK_140 >= MaxCount_RDK_140 then return
		i += 1
		goto next_foreach
	End Sub

	'FOREACH MetaTrad IN MetaTradTableToUpdate BYREF
	Private Sub FOREACHLOOP_K_2952()
		_CurrentNode = "RDK:2952"
		Dim Values_RDK_2952 as object = EvalExpression("ForEachValues_K_2952")
		Dim Index_RDK_2952 as integer
		Dim MaxCount_RDK_2952 as integer = CompilerUtil.Count(Values_RDK_2952)
		If MaxCount_RDK_2952 <= 0 then return
		Index_RDK_2952 = 0
		j = 1
	next_foreach:
		MetaTrad = Values_RDK_2952(Index_RDK_2952)
		
		'FIND ORIGIN DB
		Call CONDITIONALNODE_K_147()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_2952 += 1
		If Index_RDK_2952 >= MaxCount_RDK_2952 then return
		j += 1
		goto next_foreach
	End Sub

	'FIND ORIGIN DB
	Private Sub CONDITIONALNODE_K_147()
		_CurrentNode = "RDK:147"
		Dim _ChoiceTaken as boolean = false
		
		'---------- START NODE CONDITIONS 
		FUSION = EvalExpression("NODE_FUSION_K_147")
		PDM = EvalExpression("NODE_PDM_K_147")
		GRAPHICAL_STUDIO = EvalExpression("NODE_GRAPHICAL_STUDIO_K_147")
		CRM = EvalExpression("NODE_CRM_K_147")
		'---------- END CONDITIONAL NODE
		'Choice: FUSION is True (FUSION)
		Call CHOICE_K_184(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: PDM is True (PDM)
		Call CHOICE_K_202(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: GRAPHICAL_STUDIO is True (GRAPHICAL STUDIO)
		Call CHOICE_K_214(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: CRM is True (CRM)
		Call CHOICE_K_226(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'Choice: FUSION is True (FUSION)
	Private Sub CHOICE_K_184(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:184"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_184")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Open DB Connection
		_CurrentNode = "RDK:1453"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_1453 as New Generic.list(of object)
		ActionArgs_K_1453.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_1453.Add(EvalExpression("ConnectionString_K_1453")) 'ConnectionString IN
		ActionArgs_K_1453.Add(1) 'Transaction IN
		ActionArgs_K_1453.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_1453 As object() = ActionArgs_K_1453.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_1453)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'FIND ORIGIN TABLE
		Call CONDITIONALNODE_K_558()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Close DB Connection
		_CurrentNode = "RDK:1504"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_1504 as New Generic.list(of object)
		ActionArgs_K_1504.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_1504.Add(1) 'Transaction IN
		Dim _ActionArgs_K_1504 As object() = ActionArgs_K_1504.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_1504)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'FIND ORIGIN TABLE
	Private Sub CONDITIONALNODE_K_558()
		_CurrentNode = "RDK:558"
		Dim _ChoiceTaken as boolean = false
		
		'---------- START NODE CONDITIONS 
		LANGUAGE = EvalExpression("NODE_LANGUAGE_K_558")
		ba_properties = EvalExpression("NODE_ba_properties_K_558")
		ba_prop_value = EvalExpression("NODE_ba_prop_value_K_558")
		ba_activitytype = EvalExpression("NODE_ba_activitytype_K_558")
		ba_activity_category = EvalExpression("NODE_ba_activity_category_K_558")
		wo_state = EvalExpression("NODE_wo_state_K_558")
		pr_item = EvalExpression("NODE_pr_item_K_558")
		pr_type = EvalExpression("NODE_pr_type_K_558")
		dm_class = EvalExpression("NODE_dm_class_K_558")
		dm_folder_001 = EvalExpression("NODE_dm_folder_001_K_558")
		ba_source = EvalExpression("NODE_ba_source_K_558")
		'---------- END CONDITIONAL NODE
		'Choice: LANGUAGE is True
		Call CHOICE_K_704(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ba_properties is True
		Call CHOICE_K_755(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ba_prop_value is True
		Call CHOICE_K_789(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ba_activitytype is True
		Call CHOICE_K_823(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ba_activity_category is True
		Call CHOICE_K_857(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: wo_state is True
		Call CHOICE_K_891(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: pr_item is True
		Call CHOICE_K_925(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: pr_type is True
		Call CHOICE_K_959(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: dm_class is True
		Call CHOICE_K_993(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: dm_folder_001 is True
		Call CHOICE_K_1027(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ba_source is True
		Call CHOICE_K_1398(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'Choice: LANGUAGE is True
	Private Sub CHOICE_K_704(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:704"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_704")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:1610"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_1610 as New Generic.list(of object)
		ActionArgs_K_1610.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_1610.Add(EvalExpression("SqlStatement_K_1610")) 'SqlStatement IN
		ActionArgs_K_1610.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_1610.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_1610 As object() = ActionArgs_K_1610.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_1610)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: ba_properties is True
	Private Sub CHOICE_K_755(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:755"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_755")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:1804"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_1804 as New Generic.list(of object)
		ActionArgs_K_1804.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_1804.Add(EvalExpression("SqlStatement_K_1804")) 'SqlStatement IN
		ActionArgs_K_1804.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_1804.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_1804 As object() = ActionArgs_K_1804.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_1804)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: ba_prop_value is True
	Private Sub CHOICE_K_789(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:789"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_789")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:1883"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_1883 as New Generic.list(of object)
		ActionArgs_K_1883.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_1883.Add(EvalExpression("SqlStatement_K_1883")) 'SqlStatement IN
		ActionArgs_K_1883.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_1883.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_1883 As object() = ActionArgs_K_1883.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_1883)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: ba_activitytype is True
	Private Sub CHOICE_K_823(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:823"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_823")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:1992"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_1992 as New Generic.list(of object)
		ActionArgs_K_1992.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_1992.Add(EvalExpression("SqlStatement_K_1992")) 'SqlStatement IN
		ActionArgs_K_1992.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_1992.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_1992 As object() = ActionArgs_K_1992.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_1992)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: ba_activity_category is True
	Private Sub CHOICE_K_857(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:857"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_857")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:2071"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_2071 as New Generic.list(of object)
		ActionArgs_K_2071.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_2071.Add(EvalExpression("SqlStatement_K_2071")) 'SqlStatement IN
		ActionArgs_K_2071.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_2071.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_2071 As object() = ActionArgs_K_2071.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_2071)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: wo_state is True
	Private Sub CHOICE_K_891(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:891"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_891")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:8482"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_8482 as New Generic.list(of object)
		ActionArgs_K_8482.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_8482.Add(EvalExpression("SqlStatement_K_8482")) 'SqlStatement IN
		ActionArgs_K_8482.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_8482.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_8482 As object() = ActionArgs_K_8482.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_8482)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: pr_item is True
	Private Sub CHOICE_K_925(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:925"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_925")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:2418"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_2418 as New Generic.list(of object)
		ActionArgs_K_2418.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_2418.Add(EvalExpression("SqlStatement_K_2418")) 'SqlStatement IN
		ActionArgs_K_2418.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_2418.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_2418 As object() = ActionArgs_K_2418.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_2418)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: pr_type is True
	Private Sub CHOICE_K_959(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:959"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_959")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:2497"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_2497 as New Generic.list(of object)
		ActionArgs_K_2497.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_2497.Add(EvalExpression("SqlStatement_K_2497")) 'SqlStatement IN
		ActionArgs_K_2497.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_2497.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_2497 As object() = ActionArgs_K_2497.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_2497)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: dm_class is True
	Private Sub CHOICE_K_993(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:993"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_993")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:2593"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_2593 as New Generic.list(of object)
		ActionArgs_K_2593.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_2593.Add(EvalExpression("SqlStatement_K_2593")) 'SqlStatement IN
		ActionArgs_K_2593.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_2593.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_2593 As object() = ActionArgs_K_2593.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_2593)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: dm_folder_001 is True
	Private Sub CHOICE_K_1027(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:1027"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_1027")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:3441"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_3441 as New Generic.list(of object)
		ActionArgs_K_3441.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_3441.Add(EvalExpression("SqlStatement_K_3441")) 'SqlStatement IN
		ActionArgs_K_3441.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_3441.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_3441 As object() = ActionArgs_K_3441.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_3441)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: ba_source is True
	Private Sub CHOICE_K_1398(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:1398"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_1398")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:2689"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_2689 as New Generic.list(of object)
		ActionArgs_K_2689.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_2689.Add(EvalExpression("SqlStatement_K_2689")) 'SqlStatement IN
		ActionArgs_K_2689.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_2689.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_2689 As object() = ActionArgs_K_2689.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_2689)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: PDM is True (PDM)
	Private Sub CHOICE_K_202(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:202"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_202")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Open DB Connection
		_CurrentNode = "RDK:3843"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_3843 as New Generic.list(of object)
		ActionArgs_K_3843.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_3843.Add(EvalExpression("ConnectionString_K_3843")) 'ConnectionString IN
		ActionArgs_K_3843.Add(1) 'Transaction IN
		ActionArgs_K_3843.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_3843 As object() = ActionArgs_K_3843.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_3843)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'If MetaTrad.ORIGIN_ID_1="328" or MetaTrad.ORIGIN_ID_1="329" is True
		Call IFTHENELSE_K_3568()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Close DB Connection
		_CurrentNode = "RDK:4115"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_4115 as New Generic.list(of object)
		ActionArgs_K_4115.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_4115.Add(1) 'Transaction IN
		Dim _ActionArgs_K_4115 As object() = ActionArgs_K_4115.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_4115)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'If MetaTrad.ORIGIN_ID_1="328" or MetaTrad.ORIGIN_ID_1="329" is True
	Private Sub IFTHENELSE_K_3568()
		_CurrentNode = "RDK:3568"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_3568")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If MetaTrad.ORIGIN_ID_1="328" or MetaTrad.ORIGIN_ID_1="329" is True
			Call THENGROUP_K_3569()

		else
			'Execute SQL Statement
			Call ELSEGROUP_K_3570()

		End if
	End Sub

	'If MetaTrad.ORIGIN_ID_1="328" or MetaTrad.ORIGIN_ID_1="329" is True
	Private Sub THENGROUP_K_3569()
		_CurrentNode = "RDK:3569"
		'Execute SQL Statement
		_CurrentNode = "RDK:3790"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_3790 as New Generic.list(of object)
		ActionArgs_K_3790.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_3790.Add(EvalExpression("SqlStatement_K_3790")) 'SqlStatement IN
		ActionArgs_K_3790.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_3790.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_3790 As object() = ActionArgs_K_3790.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_3790)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Execute SQL Statement
	Private Sub ELSEGROUP_K_3570()
		_CurrentNode = "RDK:3570"
		'Execute SQL Statement
		_CurrentNode = "RDK:3537"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_3537 as New Generic.list(of object)
		ActionArgs_K_3537.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_3537.Add(EvalExpression("SqlStatement_K_3537")) 'SqlStatement IN
		ActionArgs_K_3537.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_3537.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_3537 As object() = ActionArgs_K_3537.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_3537)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: GRAPHICAL_STUDIO is True (GRAPHICAL STUDIO)
	Private Sub CHOICE_K_214(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:214"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_214")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'FOREACH _language IN Languages BYREF
		Call FOREACHLOOP_K_4392()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'FOREACH _language IN Languages BYREF
	Private Sub FOREACHLOOP_K_4392()
		_CurrentNode = "RDK:4392"
		Dim Values_RDK_4392 as object = EvalExpression("ForEachValues_K_4392")
		Dim Index_RDK_4392 as integer
		Dim MaxCount_RDK_4392 as integer = CompilerUtil.Count(Values_RDK_4392)
		If MaxCount_RDK_4392 <= 0 then return
		Index_RDK_4392 = 0
		j = 1
	next_foreach:
		_language = Values_RDK_4392(Index_RDK_4392)
		
		'Set JSONFile = GS_TradPath+"\language_"+_language+".txt"
		_CurrentNode = "RDK:4806"
		JSONFile = EvalExpression("Set_JSONFile_K_4806")
		
		'Set JSONtext = ReadTextFile(JSONFile)
		_CurrentNode = "RDK:4898"
		JSONtext = EvalExpression("Set_JSONtext_K_4898")
		
		'Set kvTable = FromJSON(JSONtext, "(HASH)(KEYVALUE)")
		_CurrentNode = "RDK:4930"
		kvTable = EvalExpression("Set_kvTable_K_4930")
		
		'FOREACH kvRow IN kvTable BYREF
		Call FOREACHLOOP_K_4962()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set JSONtext = ToJSON(kvTable, "(HASH)")
		_CurrentNode = "RDK:5528"
		JSONtext = EvalExpression("Set_JSONtext_K_5528")
		
		'Write to Textfile
		_CurrentNode = "RDK:4239"		'ACTION RDEngineering_WriteToTextFile
		Dim ActionArgs_K_4239 as New Generic.list(of object)
		ActionArgs_K_4239.Add(EvalExpression("FileName_K_4239")) 'FileName IN
		ActionArgs_K_4239.Add(0) 'DataType IN
		ActionArgs_K_4239.Add(EvalExpression("StringText_K_4239")) 'StringText IN
		ActionArgs_K_4239.Add(Nothing) 'StringVector IN
		ActionArgs_K_4239.Add(Nothing) 'StringTable IN
		ActionArgs_K_4239.Add(Nothing) 'NumberVector IN
		ActionArgs_K_4239.Add(Nothing) 'NumberTable IN
		ActionArgs_K_4239.Add(0) 'FileFormat IN
		ActionArgs_K_4239.Add(Nothing) 'IniSection IN
		ActionArgs_K_4239.Add(Nothing) 'IniProperty IN
		ActionArgs_K_4239.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_4239 As object() = ActionArgs_K_4239.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_FILE_TEXT","RDEngineering_WriteToTextFile",_ActionArgs_K_4239)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		Index_RDK_4392 += 1
		If Index_RDK_4392 >= MaxCount_RDK_4392 then return
		j += 1
		goto next_foreach
	End Sub

	'FOREACH kvRow IN kvTable BYREF
	Private Sub FOREACHLOOP_K_4962()
		_CurrentNode = "RDK:4962"
		Dim Values_RDK_4962 as object = EvalExpression("ForEachValues_K_4962")
		Dim Index_RDK_4962 as integer
		Dim MaxCount_RDK_4962 as integer = CompilerUtil.Count(Values_RDK_4962)
		If MaxCount_RDK_4962 <= 0 then return
		Index_RDK_4962 = 0
		i = 1
	next_foreach:
		kvRow = Values_RDK_4962(Index_RDK_4962)
		
		'If MetaTrad.ORIGIN_ID_0=kvTable[i-1].key is True
		Call IFTHENELSE_K_5220()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_4962 += 1
		If Index_RDK_4962 >= MaxCount_RDK_4962 then return
		i += 1
		goto next_foreach
	End Sub

	'If MetaTrad.ORIGIN_ID_0=kvTable[i-1].key is True
	Private Sub IFTHENELSE_K_5220()
		_CurrentNode = "RDK:5220"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_5220")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If MetaTrad.ORIGIN_ID_0=kvTable[i-1].key is True
			Call THENGROUP_K_5221()

		End if
	End Sub

	'If MetaTrad.ORIGIN_ID_0=kvTable[i-1].key is True
	Private Sub THENGROUP_K_5221()
		_CurrentNode = "RDK:5221"
		'Set kvTable[i-1].value = IIF(_language="ITA", Trad.ITA,    IIF(_language="ENG", Trad.ENG,        IIF(_language="ESP", ... (200 chars)
		_CurrentNode = "RDK:5008"
		kvTable(i-1).value = EvalExpression("Set_kvTable_i_1__value_K_5008")
		
	End Sub

	'Choice: CRM is True (CRM)
	Private Sub CHOICE_K_226(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:226"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_226")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Set xml_crm = ReadTextFile(CRM_TradPath)
		_CurrentNode = "RDK:5791"
		xml_crm = EvalExpression("Set_xml_crm_K_5791")
		
		'Set tags_to_replace = IIF(Trad.ITA<>"", "    <ITA>"+IIF(IsTagInString(Trad.ITA, "<br>"),cdata_start+Trad.ITA+cdata_end+... (671 chars)
		_CurrentNode = "RDK:5838"
		tags_to_replace = EvalExpression("Set_tags_to_replace_K_5838")
		
		'Set final_xml = ReplaceFromTo(    xml_crm,     "<Orig_str>"+IIF(IsTagInString(MetaTrad.ORIGIN_ID_0, "<br>"),cdata_star... (454 chars)
		_CurrentNode = "RDK:6476"
		final_xml = EvalExpression("Set_final_xml_K_6476")
		
		'Write to Textfile
		_CurrentNode = "RDK:6522"		'ACTION RDEngineering_WriteToTextFile
		Dim ActionArgs_K_6522 as New Generic.list(of object)
		ActionArgs_K_6522.Add(EvalExpression("FileName_K_6522")) 'FileName IN
		ActionArgs_K_6522.Add(0) 'DataType IN
		ActionArgs_K_6522.Add(EvalExpression("StringText_K_6522")) 'StringText IN
		ActionArgs_K_6522.Add(Nothing) 'StringVector IN
		ActionArgs_K_6522.Add(Nothing) 'StringTable IN
		ActionArgs_K_6522.Add(Nothing) 'NumberVector IN
		ActionArgs_K_6522.Add(Nothing) 'NumberTable IN
		ActionArgs_K_6522.Add(0) 'FileFormat IN
		ActionArgs_K_6522.Add(Nothing) 'IniSection IN
		ActionArgs_K_6522.Add(Nothing) 'IniProperty IN
		ActionArgs_K_6522.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_6522 As object() = ActionArgs_K_6522.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_FILE_TEXT","RDEngineering_WriteToTextFile",_ActionArgs_K_6522)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'FOREACH Trad IN TradTableToDelete BYREF
	Private Sub FOREACHLOOP_K_12532()
		_CurrentNode = "RDK:12532"
		Dim Values_RDK_12532 as object = EvalExpression("ForEachValues_K_12532")
		Dim Index_RDK_12532 as integer
		Dim MaxCount_RDK_12532 as integer = CompilerUtil.Count(Values_RDK_12532)
		If MaxCount_RDK_12532 <= 0 then return
		Index_RDK_12532 = 0
		i = 1
	next_foreach:
		Trad = Values_RDK_12532(Index_RDK_12532)
		
		'Select DB Structured
		_CurrentNode = "RDK:12449"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_12449 as New Generic.list(of object)
		ActionArgs_K_12449.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_12449.Add(1) 'SelectQueryMode IN
		ActionArgs_K_12449.Add(Nothing) 'SelectTable IN
		ActionArgs_K_12449.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_12449.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_12449.Add(EvalExpression("SelectQuery_K_12449")) 'SelectQuery IN
		ActionArgs_K_12449.Add(2) 'SelectQueryType IN
		ActionArgs_K_12449.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_12449.Add(MetaTradTableToDelete) 'AllRows OUT
		ActionArgs_K_12449.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12449 As object() = ActionArgs_K_12449.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_12449,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		MetaTradTableToDelete = _ActionArgs_K_12449(8)		'OUT
		
		'FOREACH MetaTrad IN MetaTradTableToDelete BYREF
		Call FOREACHLOOP_K_12531()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	next_iteration:
		Index_RDK_12532 += 1
		If Index_RDK_12532 >= MaxCount_RDK_12532 then return
		i += 1
		goto next_foreach
	End Sub

	'FOREACH MetaTrad IN MetaTradTableToDelete BYREF
	Private Sub FOREACHLOOP_K_12531()
		_CurrentNode = "RDK:12531"
		Dim Values_RDK_12531 as object = EvalExpression("ForEachValues_K_12531")
		Dim Index_RDK_12531 as integer
		Dim MaxCount_RDK_12531 as integer = CompilerUtil.Count(Values_RDK_12531)
		If MaxCount_RDK_12531 <= 0 then return
		Index_RDK_12531 = 0
		j = 1
	next_foreach:
		MetaTrad = Values_RDK_12531(Index_RDK_12531)
		
		'FIND ORIGIN DB
		Call CONDITIONALNODE_K_12530()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_12531 += 1
		If Index_RDK_12531 >= MaxCount_RDK_12531 then return
		j += 1
		goto next_foreach
	End Sub

	'FIND ORIGIN DB
	Private Sub CONDITIONALNODE_K_12530()
		_CurrentNode = "RDK:12530"
		Dim _ChoiceTaken as boolean = false
		
		'---------- START NODE CONDITIONS 
		FUSION = EvalExpression("NODE_FUSION_K_12530")
		PDM = EvalExpression("NODE_PDM_K_12530")
		GRAPHICAL_STUDIO = EvalExpression("NODE_GRAPHICAL_STUDIO_K_12530")
		CRM = EvalExpression("NODE_CRM_K_12530")
		'---------- END CONDITIONAL NODE
		'Choice: FUSION is True (FUSION)
		Call CHOICE_K_12490(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: PDM is True (PDM)
		Call CHOICE_K_12498(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: GRAPHICAL_STUDIO is True (GRAPHICAL STUDIO)
		Call CHOICE_K_12514(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: CRM is True (CRM)
		Call CHOICE_K_12529(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'Choice: FUSION is True (FUSION)
	Private Sub CHOICE_K_12490(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12490"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12490")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Open DB Connection
		_CurrentNode = "RDK:12454"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_12454 as New Generic.list(of object)
		ActionArgs_K_12454.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12454.Add(EvalExpression("ConnectionString_K_12454")) 'ConnectionString IN
		ActionArgs_K_12454.Add(1) 'Transaction IN
		ActionArgs_K_12454.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12454 As object() = ActionArgs_K_12454.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_12454)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'FIND ORIGIN TABLE
		Call CONDITIONALNODE_K_12488()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Close DB Connection
		_CurrentNode = "RDK:12489"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_12489 as New Generic.list(of object)
		ActionArgs_K_12489.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12489.Add(1) 'Transaction IN
		Dim _ActionArgs_K_12489 As object() = ActionArgs_K_12489.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_12489)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'FIND ORIGIN TABLE
	Private Sub CONDITIONALNODE_K_12488()
		_CurrentNode = "RDK:12488"
		Dim _ChoiceTaken as boolean = false
		
		'---------- START NODE CONDITIONS 
		LANGUAGE = EvalExpression("NODE_LANGUAGE_K_12488")
		ba_properties = EvalExpression("NODE_ba_properties_K_12488")
		ba_prop_value = EvalExpression("NODE_ba_prop_value_K_12488")
		ba_activitytype = EvalExpression("NODE_ba_activitytype_K_12488")
		ba_activity_category = EvalExpression("NODE_ba_activity_category_K_12488")
		wo_state = EvalExpression("NODE_wo_state_K_12488")
		pr_item = EvalExpression("NODE_pr_item_K_12488")
		pr_type = EvalExpression("NODE_pr_type_K_12488")
		dm_class = EvalExpression("NODE_dm_class_K_12488")
		dm_folder_001 = EvalExpression("NODE_dm_folder_001_K_12488")
		ba_source = EvalExpression("NODE_ba_source_K_12488")
		'---------- END CONDITIONAL NODE
		'Choice: LANGUAGE is True
		Call CHOICE_K_12467(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ba_properties is True
		Call CHOICE_K_12469(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ba_prop_value is True
		Call CHOICE_K_12471(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ba_activitytype is True
		Call CHOICE_K_12473(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ba_activity_category is True
		Call CHOICE_K_12475(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: wo_state is True
		Call CHOICE_K_12477(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: pr_item is True
		Call CHOICE_K_12479(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: pr_type is True
		Call CHOICE_K_12481(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: dm_class is True
		Call CHOICE_K_12483(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: dm_folder_001 is True
		Call CHOICE_K_12485(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ba_source is True
		Call CHOICE_K_12487(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'Choice: LANGUAGE is True
	Private Sub CHOICE_K_12467(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12467"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12467")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:12466"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_12466 as New Generic.list(of object)
		ActionArgs_K_12466.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12466.Add(EvalExpression("SqlStatement_K_12466")) 'SqlStatement IN
		ActionArgs_K_12466.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_12466.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12466 As object() = ActionArgs_K_12466.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_12466)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: ba_properties is True
	Private Sub CHOICE_K_12469(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12469"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12469")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:12468"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_12468 as New Generic.list(of object)
		ActionArgs_K_12468.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12468.Add(EvalExpression("SqlStatement_K_12468")) 'SqlStatement IN
		ActionArgs_K_12468.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_12468.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12468 As object() = ActionArgs_K_12468.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_12468)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: ba_prop_value is True
	Private Sub CHOICE_K_12471(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12471"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12471")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:12470"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_12470 as New Generic.list(of object)
		ActionArgs_K_12470.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12470.Add(EvalExpression("SqlStatement_K_12470")) 'SqlStatement IN
		ActionArgs_K_12470.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_12470.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12470 As object() = ActionArgs_K_12470.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_12470)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: ba_activitytype is True
	Private Sub CHOICE_K_12473(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12473"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12473")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:12472"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_12472 as New Generic.list(of object)
		ActionArgs_K_12472.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12472.Add(EvalExpression("SqlStatement_K_12472")) 'SqlStatement IN
		ActionArgs_K_12472.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_12472.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12472 As object() = ActionArgs_K_12472.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_12472)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: ba_activity_category is True
	Private Sub CHOICE_K_12475(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12475"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12475")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:12474"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_12474 as New Generic.list(of object)
		ActionArgs_K_12474.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12474.Add(EvalExpression("SqlStatement_K_12474")) 'SqlStatement IN
		ActionArgs_K_12474.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_12474.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12474 As object() = ActionArgs_K_12474.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_12474)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: wo_state is True
	Private Sub CHOICE_K_12477(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12477"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12477")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:12476"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_12476 as New Generic.list(of object)
		ActionArgs_K_12476.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12476.Add(EvalExpression("SqlStatement_K_12476")) 'SqlStatement IN
		ActionArgs_K_12476.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_12476.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12476 As object() = ActionArgs_K_12476.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_12476)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: pr_item is True
	Private Sub CHOICE_K_12479(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12479"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12479")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:12478"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_12478 as New Generic.list(of object)
		ActionArgs_K_12478.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12478.Add(EvalExpression("SqlStatement_K_12478")) 'SqlStatement IN
		ActionArgs_K_12478.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_12478.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12478 As object() = ActionArgs_K_12478.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_12478)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: pr_type is True
	Private Sub CHOICE_K_12481(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12481"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12481")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:12480"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_12480 as New Generic.list(of object)
		ActionArgs_K_12480.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12480.Add(EvalExpression("SqlStatement_K_12480")) 'SqlStatement IN
		ActionArgs_K_12480.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_12480.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12480 As object() = ActionArgs_K_12480.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_12480)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: dm_class is True
	Private Sub CHOICE_K_12483(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12483"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12483")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:12482"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_12482 as New Generic.list(of object)
		ActionArgs_K_12482.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12482.Add(EvalExpression("SqlStatement_K_12482")) 'SqlStatement IN
		ActionArgs_K_12482.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_12482.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12482 As object() = ActionArgs_K_12482.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_12482)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: dm_folder_001 is True
	Private Sub CHOICE_K_12485(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12485"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12485")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:12484"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_12484 as New Generic.list(of object)
		ActionArgs_K_12484.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12484.Add(EvalExpression("SqlStatement_K_12484")) 'SqlStatement IN
		ActionArgs_K_12484.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_12484.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12484 As object() = ActionArgs_K_12484.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_12484)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: ba_source is True
	Private Sub CHOICE_K_12487(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12487"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12487")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Execute SQL Statement
		_CurrentNode = "RDK:12486"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_12486 as New Generic.list(of object)
		ActionArgs_K_12486.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_12486.Add(EvalExpression("SqlStatement_K_12486")) 'SqlStatement IN
		ActionArgs_K_12486.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_12486.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12486 As object() = ActionArgs_K_12486.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_12486)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: PDM is True (PDM)
	Private Sub CHOICE_K_12498(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12498"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12498")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Open DB Connection
		_CurrentNode = "RDK:12491"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_12491 as New Generic.list(of object)
		ActionArgs_K_12491.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_12491.Add(EvalExpression("ConnectionString_K_12491")) 'ConnectionString IN
		ActionArgs_K_12491.Add(1) 'Transaction IN
		ActionArgs_K_12491.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12491 As object() = ActionArgs_K_12491.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_12491)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Execute SQL Statement
		_CurrentNode = "RDK:16024"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_16024 as New Generic.list(of object)
		ActionArgs_K_16024.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_16024.Add(EvalExpression("SqlStatement_K_16024")) 'SqlStatement IN
		ActionArgs_K_16024.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_16024.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_16024 As object() = ActionArgs_K_16024.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_16024)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Close DB Connection
		_CurrentNode = "RDK:12497"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_12497 as New Generic.list(of object)
		ActionArgs_K_12497.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_12497.Add(1) 'Transaction IN
		Dim _ActionArgs_K_12497 As object() = ActionArgs_K_12497.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_12497)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'Choice: GRAPHICAL_STUDIO is True (GRAPHICAL STUDIO)
	Private Sub CHOICE_K_12514(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12514"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12514")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'FOREACH _language IN Languages BYREF
		Call FOREACHLOOP_K_12513()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'FOREACH _language IN Languages BYREF
	Private Sub FOREACHLOOP_K_12513()
		_CurrentNode = "RDK:12513"
		Dim Values_RDK_12513 as object = EvalExpression("ForEachValues_K_12513")
		Dim Index_RDK_12513 as integer
		Dim MaxCount_RDK_12513 as integer = CompilerUtil.Count(Values_RDK_12513)
		If MaxCount_RDK_12513 <= 0 then return
		Index_RDK_12513 = 0
		i = 1
	next_foreach:
		_language = Values_RDK_12513(Index_RDK_12513)
		
		'Set JSONFile = GS_TradPath+"\language_"+_language+".txt"
		_CurrentNode = "RDK:12504"
		JSONFile = EvalExpression("Set_JSONFile_K_12504")
		
		'Set JSONtext = ReadTextFile(JSONFile)
		_CurrentNode = "RDK:12505"
		JSONtext = EvalExpression("Set_JSONtext_K_12505")
		
		'Set kvTable = FromJSON(JSONtext, "(HASH)(KEYVALUE)")
		_CurrentNode = "RDK:12506"
		kvTable = EvalExpression("Set_kvTable_K_12506")
		
		'Set kvTable = FilterByExp(kvTable, "Me.key<>MetaTrad.ORIGIN_ID_0", "")
		_CurrentNode = "RDK:13674"
		kvTable = EvalExpression("Set_kvTable_K_13674")
		
		'Set JSONtext = ToJSON(kvTable, "(HASH)")
		_CurrentNode = "RDK:12511"
		JSONtext = EvalExpression("Set_JSONtext_K_12511")
		
		'Write to Textfile
		_CurrentNode = "RDK:12512"		'ACTION RDEngineering_WriteToTextFile
		Dim ActionArgs_K_12512 as New Generic.list(of object)
		ActionArgs_K_12512.Add(EvalExpression("FileName_K_12512")) 'FileName IN
		ActionArgs_K_12512.Add(0) 'DataType IN
		ActionArgs_K_12512.Add(EvalExpression("StringText_K_12512")) 'StringText IN
		ActionArgs_K_12512.Add(Nothing) 'StringVector IN
		ActionArgs_K_12512.Add(Nothing) 'StringTable IN
		ActionArgs_K_12512.Add(Nothing) 'NumberVector IN
		ActionArgs_K_12512.Add(Nothing) 'NumberTable IN
		ActionArgs_K_12512.Add(0) 'FileFormat IN
		ActionArgs_K_12512.Add(Nothing) 'IniSection IN
		ActionArgs_K_12512.Add(Nothing) 'IniProperty IN
		ActionArgs_K_12512.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12512 As object() = ActionArgs_K_12512.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_FILE_TEXT","RDEngineering_WriteToTextFile",_ActionArgs_K_12512)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		Index_RDK_12513 += 1
		If Index_RDK_12513 >= MaxCount_RDK_12513 then return
		i += 1
		goto next_foreach
	End Sub

	'Choice: CRM is True (CRM)
	Private Sub CHOICE_K_12529(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:12529"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_12529")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Set xml_crm = ReadTextFile(CRM_TradPath)
		_CurrentNode = "RDK:12523"
		xml_crm = EvalExpression("Set_xml_crm_K_12523")
		
		'Set tags_to_replace = IIF(Trad.ITA<>"", "    <ITA>"+IIF(IsTagInString(Trad.ITA, "<br>"),cdata_start+Trad.ITA+cdata_end+... (671 chars)
		_CurrentNode = "RDK:12524"
		tags_to_replace = EvalExpression("Set_tags_to_replace_K_12524")
		
		'Set final_xml = StrBefore(xml_crm,     "<Orig_str>"+IIF(IsTagInString(MetaTrad.ORIGIN_ID_0, "<br>"),cdata_start+MetaTra... (421 chars)
		_CurrentNode = "RDK:12525"
		final_xml = EvalExpression("Set_final_xml_K_12525")
		
		'Write to Textfile
		_CurrentNode = "RDK:12528"		'ACTION RDEngineering_WriteToTextFile
		Dim ActionArgs_K_12528 as New Generic.list(of object)
		ActionArgs_K_12528.Add(EvalExpression("FileName_K_12528")) 'FileName IN
		ActionArgs_K_12528.Add(0) 'DataType IN
		ActionArgs_K_12528.Add(EvalExpression("StringText_K_12528")) 'StringText IN
		ActionArgs_K_12528.Add(Nothing) 'StringVector IN
		ActionArgs_K_12528.Add(Nothing) 'StringTable IN
		ActionArgs_K_12528.Add(Nothing) 'NumberVector IN
		ActionArgs_K_12528.Add(Nothing) 'NumberTable IN
		ActionArgs_K_12528.Add(0) 'FileFormat IN
		ActionArgs_K_12528.Add(Nothing) 'IniSection IN
		ActionArgs_K_12528.Add(Nothing) 'IniProperty IN
		ActionArgs_K_12528.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_12528 As object() = ActionArgs_K_12528.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_FILE_TEXT","RDEngineering_WriteToTextFile",_ActionArgs_K_12528)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub



#End Region

End Class
