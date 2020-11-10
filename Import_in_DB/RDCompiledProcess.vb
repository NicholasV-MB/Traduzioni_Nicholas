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
		ConnStr_FUSION = "Provider=sqloledb;Initial Catalog=FusionTest;Data Source=192.168.0.27;User Id=sa;Password=Ruled2014;"
		ConnStr_LOCAL = "Provider=sqloledb;Initial Catalog=MBKOffline;Data Source=LAPT-IT07\RULEDESIGNER;User Id=sa;Password=MBOffline$;"
		ConnStr_PDM = "Provider=sqloledb;Initial Catalog=PDMTest;Data Source=192.168.0.27;User Id=sa;Password=Ruled2014;"
		Languages = EvalConstant(Languages.GetType, "LIST { ""ITA"",""ENG"",""ESP"",""FRA"",""DEU"" }")
		_language = " "
		afterSelect = " "


        'CALL TO MAIN PROCESS
        Call Main_Group_K_0008()

    End Sub

#Region " --- PROCESS FUNCTIONS TABLE "

	Public Sub ExtractFromDB()	'FUNCTION: ExtractFromDB
		_CurrentNode = "RDK:74"

		'FOREACH _language IN Languages BYREF
		Call FOREACHLOOP_K_317()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'If Param.Input[1] ="dm_folder_001" is True
		Call IFTHENELSE_K_554()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Set afterSelect = ""
		_CurrentNode = "RDK:355"
		afterSelect = EvalExpression("Set_afterSelect_K_355")
		
		'Select DB Structured
		_CurrentNode = "RDK:300"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_300 as New Generic.list(of object)
		ActionArgs_K_300.Add(EvalExpression("ConnectionName_K_300")) 'ConnectionName IN
		ActionArgs_K_300.Add(1) 'SelectQueryMode IN
		ActionArgs_K_300.Add(Nothing) 'SelectTable IN
		ActionArgs_K_300.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_300.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_300.Add(EvalExpression("SelectQuery_K_300")) 'SelectQuery IN
		ActionArgs_K_300.Add(2) 'SelectQueryType IN
		ActionArgs_K_300.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_300.Add(TradTable) 'AllRows OUT
		ActionArgs_K_300.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_300 As object() = ActionArgs_K_300.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_300,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		TradTable = _ActionArgs_K_300(8)		'OUT
		
		'FOREACH Trad IN TradTable BYREF
		Call FOREACHLOOP_K_350()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Insert DB Structured
		_CurrentNode = "RDK:341"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_341 as New Generic.list(of object)
		ActionArgs_K_341.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_341.Add("TRADS") 'InsertTable IN
		ActionArgs_K_341.Add(1) 'InsertQueryType IN
		ActionArgs_K_341.Add(Nothing) 'SingleRow IN
		ActionArgs_K_341.Add(EvalExpression("ListOfRows_K_341")) 'ListOfRows IN
		ActionArgs_K_341.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_341 As object() = ActionArgs_K_341.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_341,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Set baseIDX = i+baseIDX
		_CurrentNode = "RDK:358"
		baseIDX = EvalExpression("Set_baseIDX_K_358")
		
		'FOREACH Trad IN TradTable BYREF
		Call FOREACHLOOP_K_359()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set TradTable = NOTHING
		_CurrentNode = "RDK:405"
		TradTable = CompilerUtil.CreateInstanceByType(TradTable.GetType)
		
exit_function:
	End sub



#End Region

#End Region

#Region " --- PROCESS CODE TABLE "

	'FOREACH _language IN Languages BYREF
	Private Sub FOREACHLOOP_K_317()
		_CurrentNode = "RDK:317"
		Dim Values_RDK_317 as object = EvalExpression("ForEachValues_K_317")
		Dim Index_RDK_317 as integer
		Dim MaxCount_RDK_317 as integer = CompilerUtil.Count(Values_RDK_317)
		If MaxCount_RDK_317 <= 0 then return
		Index_RDK_317 = 0
	next_foreach:
		_language = Values_RDK_317(Index_RDK_317)
		
		'Set afterSelect = afterSelect + Param.Input[4]+_language + " AS "+_language 
		_CurrentNode = "RDK:321"
		afterSelect = EvalExpression("Set_afterSelect_K_321")
		
		'If _language<>"DEU" is True
		Call IFTHENELSE_K_327()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_317 += 1
		If Index_RDK_317 >= MaxCount_RDK_317 then return
		goto next_foreach
	End Sub

	'If _language<>"DEU" is True
	Private Sub IFTHENELSE_K_327()
		_CurrentNode = "RDK:327"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_327")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If _language<>"DEU" is True
			Call THENGROUP_K_328()

		End if
	End Sub

	'If _language<>"DEU" is True
	Private Sub THENGROUP_K_328()
		_CurrentNode = "RDK:328"
		'Set afterSelect = afterSelect +", "
		_CurrentNode = "RDK:332"
		afterSelect = EvalExpression("Set_afterSelect_K_332")
		
	End Sub

	'If Param.Input[1] ="dm_folder_001" is True
	Private Sub IFTHENELSE_K_554()
		_CurrentNode = "RDK:554"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_554")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If Param.Input[1] ="dm_folder_001" is True
			Call THENGROUP_K_553()

		else
			'Set queryTrads = "SELECT DISTINCT "+afterSelect+" FROM "+Param.Input[1]  + " WHERE DMTYPE='C' "
			Call ELSEGROUP_K_557()

		End if
	End Sub

	'If Param.Input[1] ="dm_folder_001" is True
	Private Sub THENGROUP_K_553()
		_CurrentNode = "RDK:553"
		'Set queryTrads = "SELECT DISTINCT "+afterSelect+" FROM "+Param.Input[1]  + " WHERE DMTYPE='C' "
		_CurrentNode = "RDK:552"
		queryTrads = EvalExpression("Set_queryTrads_K_552")
		
	End Sub

	'Set queryTrads = "SELECT DISTINCT "+afterSelect+" FROM "+Param.Input[1]  + " WHERE DMTYPE='C' "
	Private Sub ELSEGROUP_K_557()
		_CurrentNode = "RDK:557"
		'Set queryTrads = "SELECT DISTINCT "+afterSelect+" FROM "+Param.Input[1]  
		_CurrentNode = "RDK:76"
		queryTrads = EvalExpression("Set_queryTrads_K_76")
		
	End Sub

	'FOREACH Trad IN TradTable BYREF
	Private Sub FOREACHLOOP_K_350()
		_CurrentNode = "RDK:350"
		Dim Values_RDK_350 as object = TradTable
		Dim Index_RDK_350 as integer
		Dim MaxCount_RDK_350 as integer = CompilerUtil.Count(Values_RDK_350)
		If MaxCount_RDK_350 <= 0 then return
		Index_RDK_350 = 0
		i = 1
	next_foreach:
		Trad = Values_RDK_350(Index_RDK_350)
		
		'Set TradTable[i-1].IDX = i+baseIDX
		_CurrentNode = "RDK:351"
		TradTable(i-1).IDX = EvalExpression("Set_TradTable_i_1__IDX_K_351")
		
	next_iteration:
		Index_RDK_350 += 1
		If Index_RDK_350 >= MaxCount_RDK_350 then return
		i += 1
		goto next_foreach
	End Sub

	'FOREACH Trad IN TradTable BYREF
	Private Sub FOREACHLOOP_K_359()
		_CurrentNode = "RDK:359"
		Dim Values_RDK_359 as object = TradTable
		Dim Index_RDK_359 as integer
		Dim MaxCount_RDK_359 as integer = CompilerUtil.Count(Values_RDK_359)
		If MaxCount_RDK_359 <= 0 then return
		Index_RDK_359 = 0
	next_foreach:
		Trad = Values_RDK_359(Index_RDK_359)
		
		'Set queryFindTags = "SELECT DISTINCT "+Param.Input[2] + " AS ORIGIN_ID_0"
		_CurrentNode = "RDK:361"
		queryFindTags = EvalExpression("Set_queryFindTags_K_361")
		
		'If StrLength(Param.Input[3])=0 is False
		Call IFTHENELSE_K_362()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'If StrLength(Trad.ITA)=0 is True
		Call IFTHENELSE_K_426()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'If StrLength(Trad.ENG)=0 is True
		Call IFTHENELSE_K_467()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'If StrLength(Trad.ESP)=0 is True
		Call IFTHENELSE_K_489()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'If StrLength(Trad.FRA)=0 is True
		Call IFTHENELSE_K_505()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'If StrLength(Trad.DEU)=0 is True
		Call IFTHENELSE_K_523()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'Set queryFindTags = queryFindTags + " FROM "+Param.Input[1] + " WHERE "+condITA+" AND "+condENG+" AND "+condESP+" AND "+... (143 chars)
		_CurrentNode = "RDK:372"
		queryFindTags = EvalExpression("Set_queryFindTags_K_372")
		
		'Select DB Structured
		_CurrentNode = "RDK:374"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_374 as New Generic.list(of object)
		ActionArgs_K_374.Add(EvalExpression("ConnectionName_K_374")) 'ConnectionName IN
		ActionArgs_K_374.Add(1) 'SelectQueryMode IN
		ActionArgs_K_374.Add(Nothing) 'SelectTable IN
		ActionArgs_K_374.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_374.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_374.Add(EvalExpression("SelectQuery_K_374")) 'SelectQuery IN
		ActionArgs_K_374.Add(2) 'SelectQueryType IN
		ActionArgs_K_374.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_374.Add(SupportTableTags) 'AllRows OUT
		ActionArgs_K_374.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_374 As object() = ActionArgs_K_374.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_374,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		SupportTableTags = _ActionArgs_K_374(8)		'OUT
		
		'FOREACH SupportRowTags IN SupportTableTags BYREF
		Call FOREACHLOOP_K_375()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set SupportTableTags = NOTHING
		_CurrentNode = "RDK:401"
		SupportTableTags = CompilerUtil.CreateInstanceByType(SupportTableTags.GetType)
		
		'Set MetaTradTable = NOTHING
		_CurrentNode = "RDK:403"
		MetaTradTable = CompilerUtil.CreateInstanceByType(MetaTradTable.GetType)
		
	next_iteration:
		Index_RDK_359 += 1
		If Index_RDK_359 >= MaxCount_RDK_359 then return
		goto next_foreach
	End Sub

	'If StrLength(Param.Input[3])=0 is False
	Private Sub IFTHENELSE_K_362()
		_CurrentNode = "RDK:362"
		'Group Conditions
		Dim _GroupExecute As Boolean = NOT EvalExpression("CondExp1_K_362")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If StrLength(Param.Input[3])=0 is False
			Call THENGROUP_K_363()

		End if
	End Sub

	'If StrLength(Param.Input[3])=0 is False
	Private Sub THENGROUP_K_363()
		_CurrentNode = "RDK:363"
		'Set queryFindTags = queryFindTags + ", "+Param.Input[3] + " AS ORIGIN_ID_1"
		_CurrentNode = "RDK:370"
		queryFindTags = EvalExpression("Set_queryFindTags_K_370")
		
	End Sub

	'If StrLength(Trad.ITA)=0 is True
	Private Sub IFTHENELSE_K_426()
		_CurrentNode = "RDK:426"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_426")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If StrLength(Trad.ITA)=0 is True
			Call THENGROUP_K_427()

		else
			'Set condITA = Param.Input[4] +"ITA IS NULL"
			Call ELSEGROUP_K_428()

		End if
	End Sub

	'If StrLength(Trad.ITA)=0 is True
	Private Sub THENGROUP_K_427()
		_CurrentNode = "RDK:427"
		'Set condITA = Param.Input[4] +"ITA IS NULL"
		_CurrentNode = "RDK:435"
		condITA = EvalExpression("Set_condITA_K_435")
		
	End Sub

	'Set condITA = Param.Input[4] +"ITA IS NULL"
	Private Sub ELSEGROUP_K_428()
		_CurrentNode = "RDK:428"
		'Set condITA = Param.Input[4]+"ITA='"+StrSqlWC(Trad.ITA)+"'"
		_CurrentNode = "RDK:437"
		condITA = EvalExpression("Set_condITA_K_437")
		
	End Sub

	'If StrLength(Trad.ENG)=0 is True
	Private Sub IFTHENELSE_K_467()
		_CurrentNode = "RDK:467"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_467")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If StrLength(Trad.ENG)=0 is True
			Call THENGROUP_K_464()

		else
			'Set condENG = Param.Input[4] +"ENG IS NULL"
			Call ELSEGROUP_K_466()

		End if
	End Sub

	'If StrLength(Trad.ENG)=0 is True
	Private Sub THENGROUP_K_464()
		_CurrentNode = "RDK:464"
		'Set condENG = Param.Input[4] +"ENG IS NULL"
		_CurrentNode = "RDK:463"
		condENG = EvalExpression("Set_condENG_K_463")
		
	End Sub

	'Set condENG = Param.Input[4] +"ENG IS NULL"
	Private Sub ELSEGROUP_K_466()
		_CurrentNode = "RDK:466"
		'Set condENg = Param.Input[4]+"ENG='"+StrSqlWC(Trad.ENG)+"'"
		_CurrentNode = "RDK:465"
		condENg = EvalExpression("Set_condENg_K_465")
		
	End Sub

	'If StrLength(Trad.ESP)=0 is True
	Private Sub IFTHENELSE_K_489()
		_CurrentNode = "RDK:489"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_489")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If StrLength(Trad.ESP)=0 is True
			Call THENGROUP_K_486()

		else
			'Set condESP = Param.Input[4] +"ESP IS NULL"
			Call ELSEGROUP_K_488()

		End if
	End Sub

	'If StrLength(Trad.ESP)=0 is True
	Private Sub THENGROUP_K_486()
		_CurrentNode = "RDK:486"
		'Set condESP = Param.Input[4] +"ESP IS NULL"
		_CurrentNode = "RDK:485"
		condESP = EvalExpression("Set_condESP_K_485")
		
	End Sub

	'Set condESP = Param.Input[4] +"ESP IS NULL"
	Private Sub ELSEGROUP_K_488()
		_CurrentNode = "RDK:488"
		'Set condESP = Param.Input[4]+"ESP='"+StrSqlWC(Trad.ESP)+"'"
		_CurrentNode = "RDK:487"
		condESP = EvalExpression("Set_condESP_K_487")
		
	End Sub

	'If StrLength(Trad.FRA)=0 is True
	Private Sub IFTHENELSE_K_505()
		_CurrentNode = "RDK:505"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_505")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If StrLength(Trad.FRA)=0 is True
			Call THENGROUP_K_502()

		else
			'Set condFRA = Param.Input[4] +"FRA IS NULL"
			Call ELSEGROUP_K_504()

		End if
	End Sub

	'If StrLength(Trad.FRA)=0 is True
	Private Sub THENGROUP_K_502()
		_CurrentNode = "RDK:502"
		'Set condFRA = Param.Input[4] +"FRA IS NULL"
		_CurrentNode = "RDK:501"
		condFRA = EvalExpression("Set_condFRA_K_501")
		
	End Sub

	'Set condFRA = Param.Input[4] +"FRA IS NULL"
	Private Sub ELSEGROUP_K_504()
		_CurrentNode = "RDK:504"
		'Set condFRA = Param.Input[4]+"FRA='"+StrSqlWC(Trad.FRA)+"'"
		_CurrentNode = "RDK:503"
		condFRA = EvalExpression("Set_condFRA_K_503")
		
	End Sub

	'If StrLength(Trad.DEU)=0 is True
	Private Sub IFTHENELSE_K_523()
		_CurrentNode = "RDK:523"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_523")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If StrLength(Trad.DEU)=0 is True
			Call THENGROUP_K_520()

		else
			'Set condDEU = Param.Input[4] +"DEU IS NULL"
			Call ELSEGROUP_K_522()

		End if
	End Sub

	'If StrLength(Trad.DEU)=0 is True
	Private Sub THENGROUP_K_520()
		_CurrentNode = "RDK:520"
		'Set condDEU = Param.Input[4] +"DEU IS NULL"
		_CurrentNode = "RDK:519"
		condDEU = EvalExpression("Set_condDEU_K_519")
		
	End Sub

	'Set condDEU = Param.Input[4] +"DEU IS NULL"
	Private Sub ELSEGROUP_K_522()
		_CurrentNode = "RDK:522"
		'Set condDEU = Param.Input[4]+"DEU='"+StrSqlWC(Trad.DEU)+"'"
		_CurrentNode = "RDK:521"
		condDEU = EvalExpression("Set_condDEU_K_521")
		
	End Sub

	'FOREACH SupportRowTags IN SupportTableTags BYREF
	Private Sub FOREACHLOOP_K_375()
		_CurrentNode = "RDK:375"
		Dim Values_RDK_375 as object = SupportTableTags
		Dim Index_RDK_375 as integer
		Dim MaxCount_RDK_375 as integer = CompilerUtil.Count(Values_RDK_375)
		If MaxCount_RDK_375 <= 0 then return
		Index_RDK_375 = 0
	next_foreach:
		SupportRowTags = Values_RDK_375(Index_RDK_375)
		
		'Execute SQL Statement
		_CurrentNode = "RDK:700"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_700 as New Generic.list(of object)
		ActionArgs_K_700.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_700.Add(EvalExpression("SqlStatement_K_700")) 'SqlStatement IN
		ActionArgs_K_700.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_700.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_700 As object() = ActionArgs_K_700.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_700)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	next_iteration:
		Index_RDK_375 += 1
		If Index_RDK_375 >= MaxCount_RDK_375 then return
		goto next_foreach
	End Sub

	'Main Group *LOG_CONTROLLED
	Private Sub Main_Group_K_0008()
		_CurrentNode = "RDK:0008"
		'INIT (Reimpimento tabella traduzioni)
		Call INIT_K_28()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Close DB Connection
		_CurrentNode = "RDK:270"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_270 as New Generic.list(of object)
		ActionArgs_K_270.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_270.Add(0) 'Transaction IN
		Dim _ActionArgs_K_270 As object() = ActionArgs_K_270.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_270)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'INIT (Reimpimento tabella traduzioni)
	Private Sub INIT_K_28()
		_CurrentNode = "RDK:28"
		'LocalDB
		Call LocalDB_K_248()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'FUSION *LOG_DISABLED
		Call FUSION_K_30()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'CONFIGURATOR *LOG_DISABLED
		Call CONFIGURATOR_K_569()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'PDM *LOG_DISABLED
		Call PDM_K_613()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'LocalDB
	Private Sub LocalDB_K_248()
		_CurrentNode = "RDK:248"
		'Open DB Connection
		_CurrentNode = "RDK:251"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_251 as New Generic.list(of object)
		ActionArgs_K_251.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_251.Add(EvalExpression("ConnectionString_K_251")) 'ConnectionString IN
		ActionArgs_K_251.Add(0) 'Transaction IN
		ActionArgs_K_251.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_251 As object() = ActionArgs_K_251.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_251)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Create Tables *ERROR_PROTECTED
		Call Create_Tables_K_257()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'Create Tables *ERROR_PROTECTED
	Private Sub Create_Tables_K_257()
		_CurrentNode = "RDK:257"
		'Execute SQL Statement
		_CurrentNode = "RDK:266"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_266 as New Generic.list(of object)
		ActionArgs_K_266.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_266.Add(EvalConstant(GetType(string),"CREATE TABLE TRADS (ç§    IDX INT  PRIMARY KEY ,ç§    ITA varchar(512),ç§    ENG varchar(512),ç§    ESP varchar(512),ç§    FRA varchar(512),ç§    DEU varchar(512)ç§)ç§")) 'SqlStatement IN
		ActionArgs_K_266.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_266.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_266 As object() = ActionArgs_K_266.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_266)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Execute SQL Statement
		_CurrentNode = "RDK:269"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_269 as New Generic.list(of object)
		ActionArgs_K_269.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_269.Add(EvalConstant(GetType(string),"CREATE TABLE METATRADS (ç§    IDX int,ç§    ORIGIN_DB varchar(512),ç§    ORIGIN_TABLE varchar(512),ç§    ORIGIN_ID_0 varchar(512) ,ç§    ORIGIN_ID_1 varchar(512),ç§    PRIMARY KEY(IDX, ORIGIN_ID_0, ORIGIN_ID_1, ORIGIN_TABLE, ORIGIN_DB)ç§)ç§")) 'SqlStatement IN
		ActionArgs_K_269.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_269.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_269 As object() = ActionArgs_K_269.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_269)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'FUSION *LOG_DISABLED
	Private Sub FUSION_K_30()
		_CurrentNode = "RDK:30"
		'Open DB Connection
		_CurrentNode = "RDK:36"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_36 as New Generic.list(of object)
		ActionArgs_K_36.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_36.Add(EvalExpression("ConnectionString_K_36")) 'ConnectionString IN
		ActionArgs_K_36.Add(1) 'Transaction IN
		ActionArgs_K_36.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_36 As object() = ActionArgs_K_36.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_36)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'PrepareInfoTables
		Call PrepareInfoTables_K_94()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'FOREACH FusionTableKeys IN FusionInfoTables BYREF
		Call FOREACHLOOP_K_108()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'PrepareInfoTables
	Private Sub PrepareInfoTables_K_94()
		_CurrentNode = "RDK:94"
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|ba_activitytype|ATTYPEID||ATDESCRI_
		_CurrentNode = "RDK:130"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "ba_activitytype"
			.ID = "ATTYPEID"
			.Fields = "ATDESCRI_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|ba_properties|PRCODEID||PRDESCRI_
		_CurrentNode = "RDK:97"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "ba_properties"
			.ID = "PRCODEID"
			.Fields = "PRDESCRI_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|ba_prop_value|PVPROPID|CPROWNUM|PVDESCRI_
		_CurrentNode = "RDK:100"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "ba_prop_value"
			.ID = "PVPROPID"
			.ID2 = "CPROWNUM"
			.Fields = "PVDESCRI_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|ba_activity_category|ACCATID||ACDESCRI_
		_CurrentNode = "RDK:133"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "ba_activity_category"
			.ID = "ACCATID"
			.Fields = "ACDESCRI_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|wo_state|STCODEID||STDESCRI_
		_CurrentNode = "RDK:142"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "wo_state"
			.ID = "STCODEID"
			.Fields = "STDESCRI_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|wo_state|STCODEID||STNAME_
		_CurrentNode = "RDK:561"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "wo_state"
			.ID = "STCODEID"
			.Fields = "STNAME_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|pr_item|ITITEMID||ITDESCRI_
		_CurrentNode = "RDK:144"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "pr_item"
			.ID = "ITITEMID"
			.Fields = "ITDESCRI_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|pr_type|PTTYPEID||PTDESCRI_
		_CurrentNode = "RDK:146"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "pr_type"
			.ID = "PTTYPEID"
			.Fields = "PTDESCRI_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|dm_class|CDCLASSID||CDDESCRI_
		_CurrentNode = "RDK:148"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "dm_class"
			.ID = "CDCLASSID"
			.Fields = "CDDESCRI_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|dm_folder_001|DMCODEID||DMDESCRI_
		_CurrentNode = "RDK:150"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "dm_folder_001"
			.ID = "DMCODEID"
			.Fields = "DMDESCRI_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|ba_source|SOID||SODESCRI_
		_CurrentNode = "RDK:151"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "ba_source"
			.ID = "SOID"
			.Fields = "SODESCRI_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
	End Sub

	'FOREACH FusionTableKeys IN FusionInfoTables BYREF
	Private Sub FOREACHLOOP_K_108()
		_CurrentNode = "RDK:108"
		Dim Values_RDK_108 as object = FusionInfoTables
		Dim Index_RDK_108 as integer
		Dim MaxCount_RDK_108 as integer = CompilerUtil.Count(Values_RDK_108)
		If MaxCount_RDK_108 <= 0 then return
		Index_RDK_108 = 0
	next_foreach:
		FusionTableKeys = Values_RDK_108(Index_RDK_108)
		
		'Call ExtractFromDB (FusionTableKeys)
		_CurrentNode = "RDK:75"
		Dim InputParam_K_75 = EvalExpression("InputParam_K_75")
		Dim ResultParam_K_75 = Nothing
		Dim OptionParam_K_75 = ""
		CompilerUtil.PushFunctionParams(InputParam_K_75,ResultParam_K_75,OptionParam_K_75)
		Call ExtractFromDB()		'FUNCTION CALL
	next_iteration:
		Index_RDK_108 += 1
		If Index_RDK_108 >= MaxCount_RDK_108 then return
		goto next_foreach
	End Sub

	'CONFIGURATOR *LOG_DISABLED
	Private Sub CONFIGURATOR_K_569()
		_CurrentNode = "RDK:569"
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|LANGUAGE|TAG||""
		_CurrentNode = "RDK:581"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "LANGUAGE"
			.ID = "TAG"
			.Fields = EvalExpression("Fields_K_581")
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'Call ExtractFromDB (FusionTableKeys)
		_CurrentNode = "RDK:589"
		Dim InputParam_K_589 = EvalExpression("InputParam_K_589")
		Dim ResultParam_K_589 = Nothing
		Dim OptionParam_K_589 = ""
		CompilerUtil.PushFunctionParams(InputParam_K_589,ResultParam_K_589,OptionParam_K_589)
		Call ExtractFromDB()		'FUNCTION CALL
		'Close DB Connection
		_CurrentNode = "RDK:592"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_592 as New Generic.list(of object)
		ActionArgs_K_592.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_592.Add(2) 'Transaction IN
		Dim _ActionArgs_K_592 As object() = ActionArgs_K_592.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_592)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'PDM *LOG_DISABLED
	Private Sub PDM_K_613()
		_CurrentNode = "RDK:613"
		'Open DB Connection
		_CurrentNode = "RDK:625"		'ACTION RDEngineering_DBOpen
		Dim ActionArgs_K_625 as New Generic.list(of object)
		ActionArgs_K_625.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_625.Add(EvalExpression("ConnectionString_K_625")) 'ConnectionString IN
		ActionArgs_K_625.Add(1) 'Transaction IN
		ActionArgs_K_625.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_625 As object() = ActionArgs_K_625.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBOpen",_ActionArgs_K_625)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'CASE cpID in ('328', '329')
		Call CASE_cpID_in___328____329___K_656()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'CASE cpID in ('497', '489', '459', '370', '222', '223', '220', '91' )
		Call CASE_cpID_in___497____489____459____370____222____223____220____91____K_691()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Close DB Connection
		_CurrentNode = "RDK:627"		'ACTION RDEngineering_DBClose
		Dim ActionArgs_K_627 as New Generic.list(of object)
		ActionArgs_K_627.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_627.Add(2) 'Transaction IN
		Dim _ActionArgs_K_627 As object() = ActionArgs_K_627.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBClose",_ActionArgs_K_627)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'CASE cpID in ('328', '329')
	Private Sub CASE_cpID_in___328____329___K_656()
		_CurrentNode = "RDK:656"
		'Select DB Structured
		_CurrentNode = "RDK:628"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_628 as New Generic.list(of object)
		ActionArgs_K_628.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_628.Add(1) 'SelectQueryMode IN
		ActionArgs_K_628.Add(Nothing) 'SelectTable IN
		ActionArgs_K_628.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_628.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_628.Add("SELECT cvalValore as ITA, cvalTrans1 as ENG, cvalTrans4 as ESP, cvalTrans2 as FRA, cvalTrans3 as DEU FROM CODVAL WHERE cpID in ('328', '329' )") 'SelectQuery IN
		ActionArgs_K_628.Add(2) 'SelectQueryType IN
		ActionArgs_K_628.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_628.Add(TradTable) 'AllRows OUT
		ActionArgs_K_628.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_628 As object() = ActionArgs_K_628.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_628,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		TradTable = _ActionArgs_K_628(8)		'OUT
		
		'FOREACH Trad IN TradTable BYREF
		Call FOREACHLOOP_K_632()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Insert DB Structured
		_CurrentNode = "RDK:634"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_634 as New Generic.list(of object)
		ActionArgs_K_634.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_634.Add("TRADS") 'InsertTable IN
		ActionArgs_K_634.Add(1) 'InsertQueryType IN
		ActionArgs_K_634.Add(Nothing) 'SingleRow IN
		ActionArgs_K_634.Add(EvalExpression("ListOfRows_K_634")) 'ListOfRows IN
		ActionArgs_K_634.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_634 As object() = ActionArgs_K_634.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_634,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Set baseIDX = i+baseIDX
		_CurrentNode = "RDK:636"
		baseIDX = EvalExpression("Set_baseIDX_K_636")
		
		'FOREACH Trad IN TradTable BYREF
		Call FOREACHLOOP_K_638()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set TradTable = NOTHING
		_CurrentNode = "RDK:654"
		TradTable = CompilerUtil.CreateInstanceByType(TradTable.GetType)
		
	End Sub

	'FOREACH Trad IN TradTable BYREF
	Private Sub FOREACHLOOP_K_632()
		_CurrentNode = "RDK:632"
		Dim Values_RDK_632 as object = TradTable
		Dim Index_RDK_632 as integer
		Dim MaxCount_RDK_632 as integer = CompilerUtil.Count(Values_RDK_632)
		If MaxCount_RDK_632 <= 0 then return
		Index_RDK_632 = 0
		i = 1
	next_foreach:
		Trad = Values_RDK_632(Index_RDK_632)
		
		'Set TradTable[i-1].IDX = i+baseIDX
		_CurrentNode = "RDK:631"
		TradTable(i-1).IDX = EvalExpression("Set_TradTable_i_1__IDX_K_631")
		
	next_iteration:
		Index_RDK_632 += 1
		If Index_RDK_632 >= MaxCount_RDK_632 then return
		i += 1
		goto next_foreach
	End Sub

	'FOREACH Trad IN TradTable BYREF
	Private Sub FOREACHLOOP_K_638()
		_CurrentNode = "RDK:638"
		Dim Values_RDK_638 as object = TradTable
		Dim Index_RDK_638 as integer
		Dim MaxCount_RDK_638 as integer = CompilerUtil.Count(Values_RDK_638)
		If MaxCount_RDK_638 <= 0 then return
		Index_RDK_638 = 0
	next_foreach:
		Trad = Values_RDK_638(Index_RDK_638)
		
		'Set queryFindTags = "SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL WHERE cpID in ('328', '329' ) AND cvalVa... (310 chars)
		_CurrentNode = "RDK:640"
		queryFindTags = EvalExpression("Set_queryFindTags_K_640")
		
		'Select DB Structured
		_CurrentNode = "RDK:642"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_642 as New Generic.list(of object)
		ActionArgs_K_642.Add(EvalExpression("ConnectionName_K_642")) 'ConnectionName IN
		ActionArgs_K_642.Add(1) 'SelectQueryMode IN
		ActionArgs_K_642.Add(Nothing) 'SelectTable IN
		ActionArgs_K_642.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_642.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_642.Add(EvalExpression("SelectQuery_K_642")) 'SelectQuery IN
		ActionArgs_K_642.Add(2) 'SelectQueryType IN
		ActionArgs_K_642.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_642.Add(SupportTableTags) 'AllRows OUT
		ActionArgs_K_642.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_642 As object() = ActionArgs_K_642.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_642,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		SupportTableTags = _ActionArgs_K_642(8)		'OUT
		
		'FOREACH SupportRowTags IN SupportTableTags BYREF
		Call FOREACHLOOP_K_646()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Insert DB Structured
		_CurrentNode = "RDK:648"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_648 as New Generic.list(of object)
		ActionArgs_K_648.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_648.Add("METATRADS") 'InsertTable IN
		ActionArgs_K_648.Add(1) 'InsertQueryType IN
		ActionArgs_K_648.Add(Nothing) 'SingleRow IN
		ActionArgs_K_648.Add(EvalExpression("ListOfRows_K_648")) 'ListOfRows IN
		ActionArgs_K_648.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_648 As object() = ActionArgs_K_648.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_648,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Set SupportTableTags = NOTHING
		_CurrentNode = "RDK:650"
		SupportTableTags = CompilerUtil.CreateInstanceByType(SupportTableTags.GetType)
		
		'Set MetaTradTable = NOTHING
		_CurrentNode = "RDK:652"
		MetaTradTable = CompilerUtil.CreateInstanceByType(MetaTradTable.GetType)
		
	next_iteration:
		Index_RDK_638 += 1
		If Index_RDK_638 >= MaxCount_RDK_638 then return
		goto next_foreach
	End Sub

	'FOREACH SupportRowTags IN SupportTableTags BYREF
	Private Sub FOREACHLOOP_K_646()
		_CurrentNode = "RDK:646"
		Dim Values_RDK_646 as object = SupportTableTags
		Dim Index_RDK_646 as integer
		Dim MaxCount_RDK_646 as integer = CompilerUtil.Count(Values_RDK_646)
		If MaxCount_RDK_646 <= 0 then return
		Index_RDK_646 = 0
	next_foreach:
		SupportRowTags = Values_RDK_646(Index_RDK_646)
		
		'SetStruct MetaTradTable <-- MetaTrad = Trad.IDX|PDM|CODVAL|SupportRowTags.ORIGIN_ID_0
		_CurrentNode = "RDK:645"
		MetaTrad = new MetaTradType
		With MetaTrad
			.IDX = EvalExpression("IDX_K_645")
			.ORIGIN_DB = "PDM"
			.ORIGIN_TABLE = "CODVAL"
			.ORIGIN_ID_0 = EvalExpression("ORIGIN_ID_0_K_645")
		End With
		MetaTradTable.Add(MetaTrad)
		
	next_iteration:
		Index_RDK_646 += 1
		If Index_RDK_646 >= MaxCount_RDK_646 then return
		goto next_foreach
	End Sub

	'CASE cpID in ('497', '489', '459', '370', '222', '223', '220', '91' )
	Private Sub CASE_cpID_in___497____489____459____370____222____223____220____91____K_691()
		_CurrentNode = "RDK:691"
		'Select DB Structured
		_CurrentNode = "RDK:677"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_677 as New Generic.list(of object)
		ActionArgs_K_677.Add("DB_PDM") 'ConnectionName IN
		ActionArgs_K_677.Add(1) 'SelectQueryMode IN
		ActionArgs_K_677.Add(Nothing) 'SelectTable IN
		ActionArgs_K_677.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_677.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_677.Add("SELECT  cvalTrans2 as ITA, cvalTrans3 as ENG, '' as ESP, cvalTrans4 as FRA,  cvalTrans5 as DEU FROM CODVAL WHERE cpID in ('497', '489', '459', '370', '222', '223', '220', '91' )") 'SelectQuery IN
		ActionArgs_K_677.Add(2) 'SelectQueryType IN
		ActionArgs_K_677.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_677.Add(TradTable) 'AllRows OUT
		ActionArgs_K_677.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_677 As object() = ActionArgs_K_677.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_677,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		TradTable = _ActionArgs_K_677(8)		'OUT
		
		'FOREACH Trad IN TradTable BYREF
		Call FOREACHLOOP_K_679()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Insert DB Structured
		_CurrentNode = "RDK:680"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_680 as New Generic.list(of object)
		ActionArgs_K_680.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_680.Add("TRADS") 'InsertTable IN
		ActionArgs_K_680.Add(1) 'InsertQueryType IN
		ActionArgs_K_680.Add(Nothing) 'SingleRow IN
		ActionArgs_K_680.Add(EvalExpression("ListOfRows_K_680")) 'ListOfRows IN
		ActionArgs_K_680.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_680 As object() = ActionArgs_K_680.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_680,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Set baseIDX = i+baseIDX
		_CurrentNode = "RDK:681"
		baseIDX = EvalExpression("Set_baseIDX_K_681")
		
		'FOREACH Trad IN TradTable BYREF
		Call FOREACHLOOP_K_690()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set TradTable = NOTHING
		_CurrentNode = "RDK:689"
		TradTable = CompilerUtil.CreateInstanceByType(TradTable.GetType)
		
	End Sub

	'FOREACH Trad IN TradTable BYREF
	Private Sub FOREACHLOOP_K_679()
		_CurrentNode = "RDK:679"
		Dim Values_RDK_679 as object = TradTable
		Dim Index_RDK_679 as integer
		Dim MaxCount_RDK_679 as integer = CompilerUtil.Count(Values_RDK_679)
		If MaxCount_RDK_679 <= 0 then return
		Index_RDK_679 = 0
		i = 1
	next_foreach:
		Trad = Values_RDK_679(Index_RDK_679)
		
		'Set TradTable[i-1].IDX = i+baseIDX
		_CurrentNode = "RDK:678"
		TradTable(i-1).IDX = EvalExpression("Set_TradTable_i_1__IDX_K_678")
		
		'Set TradTable[i-1].ESP = N/D
		_CurrentNode = "RDK:695"
		TradTable(i-1).ESP = EvalConstant(CompilerUtil.GetFieldType(TradTable(i-1),"ESP"), "N/D")
		
	next_iteration:
		Index_RDK_679 += 1
		If Index_RDK_679 >= MaxCount_RDK_679 then return
		i += 1
		goto next_foreach
	End Sub

	'FOREACH Trad IN TradTable BYREF
	Private Sub FOREACHLOOP_K_690()
		_CurrentNode = "RDK:690"
		Dim Values_RDK_690 as object = TradTable
		Dim Index_RDK_690 as integer
		Dim MaxCount_RDK_690 as integer = CompilerUtil.Count(Values_RDK_690)
		If MaxCount_RDK_690 <= 0 then return
		Index_RDK_690 = 0
	next_foreach:
		Trad = Values_RDK_690(Index_RDK_690)
		
		'Set queryFindTags = "SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL WHERE cpID in ('497', '489', '459', '370... (310 chars)
		_CurrentNode = "RDK:682"
		queryFindTags = EvalExpression("Set_queryFindTags_K_682")
		
		'Select DB Structured
		_CurrentNode = "RDK:683"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_683 as New Generic.list(of object)
		ActionArgs_K_683.Add(EvalExpression("ConnectionName_K_683")) 'ConnectionName IN
		ActionArgs_K_683.Add(1) 'SelectQueryMode IN
		ActionArgs_K_683.Add(Nothing) 'SelectTable IN
		ActionArgs_K_683.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_683.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_683.Add(EvalExpression("SelectQuery_K_683")) 'SelectQuery IN
		ActionArgs_K_683.Add(2) 'SelectQueryType IN
		ActionArgs_K_683.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_683.Add(SupportTableTags) 'AllRows OUT
		ActionArgs_K_683.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_683 As object() = ActionArgs_K_683.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_683,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		SupportTableTags = _ActionArgs_K_683(8)		'OUT
		
		'FOREACH SupportRowTags IN SupportTableTags BYREF
		Call FOREACHLOOP_K_685()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Insert DB Structured
		_CurrentNode = "RDK:686"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_686 as New Generic.list(of object)
		ActionArgs_K_686.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_686.Add("METATRADS") 'InsertTable IN
		ActionArgs_K_686.Add(1) 'InsertQueryType IN
		ActionArgs_K_686.Add(Nothing) 'SingleRow IN
		ActionArgs_K_686.Add(EvalExpression("ListOfRows_K_686")) 'ListOfRows IN
		ActionArgs_K_686.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_686 As object() = ActionArgs_K_686.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_686,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Set SupportTableTags = NOTHING
		_CurrentNode = "RDK:687"
		SupportTableTags = CompilerUtil.CreateInstanceByType(SupportTableTags.GetType)
		
		'Set MetaTradTable = NOTHING
		_CurrentNode = "RDK:688"
		MetaTradTable = CompilerUtil.CreateInstanceByType(MetaTradTable.GetType)
		
	next_iteration:
		Index_RDK_690 += 1
		If Index_RDK_690 >= MaxCount_RDK_690 then return
		goto next_foreach
	End Sub

	'FOREACH SupportRowTags IN SupportTableTags BYREF
	Private Sub FOREACHLOOP_K_685()
		_CurrentNode = "RDK:685"
		Dim Values_RDK_685 as object = SupportTableTags
		Dim Index_RDK_685 as integer
		Dim MaxCount_RDK_685 as integer = CompilerUtil.Count(Values_RDK_685)
		If MaxCount_RDK_685 <= 0 then return
		Index_RDK_685 = 0
	next_foreach:
		SupportRowTags = Values_RDK_685(Index_RDK_685)
		
		'SetStruct MetaTradTable <-- MetaTrad = Trad.IDX|PDM|CODVAL|SupportRowTags.ORIGIN_ID_0
		_CurrentNode = "RDK:684"
		MetaTrad = new MetaTradType
		With MetaTrad
			.IDX = EvalExpression("IDX_K_684")
			.ORIGIN_DB = "PDM"
			.ORIGIN_TABLE = "CODVAL"
			.ORIGIN_ID_0 = EvalExpression("ORIGIN_ID_0_K_684")
		End With
		MetaTradTable.Add(MetaTrad)
		
	next_iteration:
		Index_RDK_685 += 1
		If Index_RDK_685 >= MaxCount_RDK_685 then return
		goto next_foreach
	End Sub



#End Region

End Class
