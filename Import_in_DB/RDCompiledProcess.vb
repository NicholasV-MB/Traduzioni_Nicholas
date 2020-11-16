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
		GS_TradPath = "C:\Program Files (x86)\RuleDesigner\RD Configurator Fusion\WebPlayer\Editor2D\ModulBlokLibrary\shapes"
		CRM_TradPath = "\\192.168.0.27\FonteDatiPDMtest\Updates\3_Livello_TEST\mb_project_translations.inc"
		Languages = EvalConstant(Languages.GetType, "LIST { ""ITA"",""ENG"",""ESP"",""FRA"",""DEU"" }")
		_language = " "
		afterSelect = " "
		LastUpdate = EvalExpression("Set_LastUpdate_K_596654")
		j = 0
		LastUpdate = EvalExpression("Set_LastUpdate_K_596928")


        'CALL TO MAIN PROCESS
        Call Main_Group_K_0008()

    End Sub

#Region " --- PROCESS FUNCTIONS TABLE "

	Public Sub ExtractFromDB()	'FUNCTION: ExtractFromDB
		_CurrentNode = "RDK:74"

		'FOREACH _language IN Languages BYREF
		Call FOREACHLOOP_K_317()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set queryTrads = "SELECT DISTINCT "+afterSelect+" FROM "+Param.Input.TableName
		_CurrentNode = "RDK:597357"
		queryTrads = EvalExpression("Set_queryTrads_K_597357")
		
		'Set afterSelect = ""
		_CurrentNode = "RDK:355"
		afterSelect = EvalExpression("Set_afterSelect_K_355")
		
		'Set queryTrads = queryTrads+ " WHERE NOT ("+Param.Input.Fields+"ITA IS NULL AND "+Param.Input.Fields+"ENG IS NULL AND "+... (267 chars)
		_CurrentNode = "RDK:662637"
		queryTrads = EvalExpression("Set_queryTrads_K_662637")
		
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
		
		'Set afterSelect = afterSelect + Param.Input.Fields+_language + " AS "+_language 
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
		
		'Set queryFindTags = "SELECT DISTINCT "+Param.Input.ID+ " AS ORIGIN_ID_0"
		_CurrentNode = "RDK:361"
		queryFindTags = EvalExpression("Set_queryFindTags_K_361")
		
		'If StrLength(Param.Input.ID2)>0 AND Param.Input.TableName<>"wo_state" is True
		Call IFTHENELSE_K_362()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'Set queryFindTags = queryFindTags + ", MAX(cpupdtms) AS LAST_UPDATE"
		_CurrentNode = "RDK:596512"
		queryFindTags = EvalExpression("Set_queryFindTags_K_596512")
		
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

		'Set queryFindTags = queryFindTags + " FROM "+Param.Input.TableName + " WHERE "+condITA+" AND "+condENG+" AND "+condESP+"... (178 chars)
		_CurrentNode = "RDK:372"
		queryFindTags = EvalExpression("Set_queryFindTags_K_372")
		
		'If StrLength(Param.Input.ID2)>0 AND Param.Input.TableName<>"wo_state" is True
		Call IFTHENELSE_K_596588()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

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

	'If StrLength(Param.Input.ID2)>0 AND Param.Input.TableName<>"wo_state" is True
	Private Sub IFTHENELSE_K_362()
		_CurrentNode = "RDK:362"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_362")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If StrLength(Param.Input.ID2)>0 AND Param.Input.TableName<>"wo_state" is True
			Call THENGROUP_K_363()

		End if
	End Sub

	'If StrLength(Param.Input.ID2)>0 AND Param.Input.TableName<>"wo_state" is True
	Private Sub THENGROUP_K_363()
		_CurrentNode = "RDK:363"
		'Set queryFindTags = queryFindTags + ", "+Param.Input.ID2+ " AS ORIGIN_ID_1"
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
			'Set condITA = Param.Input.Fields+"ITA IS NULL"
			Call ELSEGROUP_K_428()

		End if
	End Sub

	'If StrLength(Trad.ITA)=0 is True
	Private Sub THENGROUP_K_427()
		_CurrentNode = "RDK:427"
		'Set condITA = Param.Input.Fields+"ITA IS NULL"
		_CurrentNode = "RDK:435"
		condITA = EvalExpression("Set_condITA_K_435")
		
	End Sub

	'Set condITA = Param.Input.Fields+"ITA IS NULL"
	Private Sub ELSEGROUP_K_428()
		_CurrentNode = "RDK:428"
		'Set condITA = Param.Input.Fields+"ITA='"+StrSql(Trad.ITA)+"'"
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
			'Set condENG = Param.Input.Fields +"ENG IS NULL"
			Call ELSEGROUP_K_466()

		End if
	End Sub

	'If StrLength(Trad.ENG)=0 is True
	Private Sub THENGROUP_K_464()
		_CurrentNode = "RDK:464"
		'Set condENG = Param.Input.Fields +"ENG IS NULL"
		_CurrentNode = "RDK:463"
		condENG = EvalExpression("Set_condENG_K_463")
		
	End Sub

	'Set condENG = Param.Input.Fields +"ENG IS NULL"
	Private Sub ELSEGROUP_K_466()
		_CurrentNode = "RDK:466"
		'Set condENg = Param.Input.Fields+"ENG='"+StrSql(Trad.ENG)+"'"
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
			'Set condESP = Param.Input.Fields +"ESP IS NULL"
			Call ELSEGROUP_K_488()

		End if
	End Sub

	'If StrLength(Trad.ESP)=0 is True
	Private Sub THENGROUP_K_486()
		_CurrentNode = "RDK:486"
		'Set condESP = Param.Input.Fields +"ESP IS NULL"
		_CurrentNode = "RDK:485"
		condESP = EvalExpression("Set_condESP_K_485")
		
	End Sub

	'Set condESP = Param.Input.Fields +"ESP IS NULL"
	Private Sub ELSEGROUP_K_488()
		_CurrentNode = "RDK:488"
		'Set condESP = Param.Input.Fields+"ESP='"+StrSql(Trad.ESP)+"'"
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
			'Set condFRA = Param.Input.Fields+"FRA IS NULL"
			Call ELSEGROUP_K_504()

		End if
	End Sub

	'If StrLength(Trad.FRA)=0 is True
	Private Sub THENGROUP_K_502()
		_CurrentNode = "RDK:502"
		'Set condFRA = Param.Input.Fields+"FRA IS NULL"
		_CurrentNode = "RDK:501"
		condFRA = EvalExpression("Set_condFRA_K_501")
		
	End Sub

	'Set condFRA = Param.Input.Fields+"FRA IS NULL"
	Private Sub ELSEGROUP_K_504()
		_CurrentNode = "RDK:504"
		'Set condFRA = Param.Input.Fields+"FRA='"+StrSql(Trad.FRA)+"'"
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
			'Set condDEU = Param.Input.Fields +"DEU IS NULL"
			Call ELSEGROUP_K_522()

		End if
	End Sub

	'If StrLength(Trad.DEU)=0 is True
	Private Sub THENGROUP_K_520()
		_CurrentNode = "RDK:520"
		'Set condDEU = Param.Input.Fields +"DEU IS NULL"
		_CurrentNode = "RDK:519"
		condDEU = EvalExpression("Set_condDEU_K_519")
		
	End Sub

	'Set condDEU = Param.Input.Fields +"DEU IS NULL"
	Private Sub ELSEGROUP_K_522()
		_CurrentNode = "RDK:522"
		'Set condDEU = Param.Input.Fields+"DEU='"+StrSql(Trad.DEU)+"'"
		_CurrentNode = "RDK:521"
		condDEU = EvalExpression("Set_condDEU_K_521")
		
	End Sub

	'If StrLength(Param.Input.ID2)>0 AND Param.Input.TableName<>"wo_state" is True
	Private Sub IFTHENELSE_K_596588()
		_CurrentNode = "RDK:596588"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_596588")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If StrLength(Param.Input.ID2)>0 AND Param.Input.TableName<>"wo_state" is True
			Call THENGROUP_K_596587()

		End if
	End Sub

	'If StrLength(Param.Input.ID2)>0 AND Param.Input.TableName<>"wo_state" is True
	Private Sub THENGROUP_K_596587()
		_CurrentNode = "RDK:596587"
		'Set queryFindTags = queryFindTags + ", "+Param.Input.ID2
		_CurrentNode = "RDK:596586"
		queryFindTags = EvalExpression("Set_queryFindTags_K_596586")
		
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

		'GRAPHICAL STUDIO *LOG_DISABLED
		Call GRAPHICAL_STUDIO_K_704()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'CRM *LOG_DISABLED
		Call CRM_K_780()
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
		ActionArgs_K_266.Add(EvalConstant(GetType(string),"IF NOT EXISTS (SELECT * ç§           FROM INFORMATION_SCHEMA.TABLES ç§           WHERE TABLE_TYPE='BASE TABLE' ç§           AND TABLE_NAME='TRADS') ç§   CREATE TABLE TRADS (ç§    IDX INT  PRIMARY KEY ,ç§    ITA varchar(1024),ç§    ENG varchar(1024),ç§    ESP varchar(1024),ç§    FRA varchar(1024),ç§    DEU varchar(1024),ç§    UPDATED BIT,ç§    NEW BITç§)ç§ELSEç§TRUNCATE TABLE TRADS")) 'SqlStatement IN
		ActionArgs_K_266.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_266.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_266 As object() = ActionArgs_K_266.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_266)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Execute SQL Statement
		_CurrentNode = "RDK:269"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_269 as New Generic.list(of object)
		ActionArgs_K_269.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_269.Add(EvalConstant(GetType(string),"IF NOT EXISTS (SELECT * ç§           FROM INFORMATION_SCHEMA.TABLES ç§           WHERE TABLE_TYPE='BASE TABLE' ç§           AND TABLE_NAME='METATRADS') ç§CREATE TABLE METATRADS (ç§    IDX int,ç§    ORIGIN_DB varchar(512),ç§    ORIGIN_TABLE varchar(512),ç§    ORIGIN_ID_0 varchar(1024) ,ç§    ORIGIN_ID_1 varchar(512),ç§    LAST_UPDATE DATETIME,ç§    PRIMARY KEY(IDX, ORIGIN_ID_0, ORIGIN_ID_1, ORIGIN_TABLE, ORIGIN_DB)ç§)ç§ELSEç§TRUNCATE TABLE METATRADSç§")) 'SqlStatement IN
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

		'Select DB Structured
		_CurrentNode = "RDK:597113"		'ACTION RDEngineering_DBSelectStructured
		Dim ActionArgs_K_597113 as New Generic.list(of object)
		ActionArgs_K_597113.Add("DB_FUSION") 'ConnectionName IN
		ActionArgs_K_597113.Add(1) 'SelectQueryMode IN
		ActionArgs_K_597113.Add(Nothing) 'SelectTable IN
		ActionArgs_K_597113.Add(Nothing) 'SelectFieldName IN
		ActionArgs_K_597113.Add(Nothing) 'SelectFieldValue IN
		ActionArgs_K_597113.Add(EvalConstant(GetType(string),"SELECT max(TAG) AS TAG, max(ITA) AS ITA, max(ENG) AS ENG, max(ESP) AS ESP, max(FRA) AS FRA, max(DEU) AS DEU, max(DATAUP) AS LAST_UPDATEç§from(ç§select DISTINCT A.DMDESCRI as TAG, A.DMDESCRI_ITA AS ITA, A.DMDESCRI_ENG AS ENG, A.DMDESCRI_ESP AS ESP, A.DMDESCRI_FRA AS FRA, A.DMDESCRI_DEU AS DEU, max(A.cpupdtms) as DATAUP from dm_folder_001 A left outer join dm_folder_prop_001 B on A.DMCODEID=B.PPNODEID and A.DMVERID=B.PPVERIDç§left outer join pr_project_001 C on B.PPVALUE=C.PJPRJIDç§where C.PJTEMPLATE='S' and A.DMTYPE='C' and  B.PPNAMEID='PROJECT' Group by A.DMDESCRI, A.DMDESCRI_ITA, A.DMDESCRI_ENG, A.DMDESCRI_ESP, A.DMDESCRI_FRA, A.DMDESCRI_DEUç§) as x group by TAG")) 'SelectQuery IN
		ActionArgs_K_597113.Add(2) 'SelectQueryType IN
		ActionArgs_K_597113.Add(Nothing) 'FirstRow OUT
		ActionArgs_K_597113.Add(dmfolder_table) 'AllRows OUT
		ActionArgs_K_597113.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_597113 As object() = ActionArgs_K_597113.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBSelectStructured",_ActionArgs_K_597113,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.BASIC))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		dmfolder_table = _ActionArgs_K_597113(8)		'OUT
		
		'FOREACH dmfolder_row IN dmfolder_table
		Call FOREACHLOOP_K_597147()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Set baseIDX = i+baseIDX
		_CurrentNode = "RDK:597220"
		baseIDX = EvalExpression("Set_baseIDX_K_597220")
		
		'Insert DB Structured
		_CurrentNode = "RDK:597234"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_597234 as New Generic.list(of object)
		ActionArgs_K_597234.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_597234.Add("TRADS") 'InsertTable IN
		ActionArgs_K_597234.Add(1) 'InsertQueryType IN
		ActionArgs_K_597234.Add(Nothing) 'SingleRow IN
		ActionArgs_K_597234.Add(EvalExpression("ListOfRows_K_597234")) 'ListOfRows IN
		ActionArgs_K_597234.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_597234 As object() = ActionArgs_K_597234.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_597234,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Insert DB Structured
		_CurrentNode = "RDK:597242"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_597242 as New Generic.list(of object)
		ActionArgs_K_597242.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_597242.Add("METATRADS") 'InsertTable IN
		ActionArgs_K_597242.Add(1) 'InsertQueryType IN
		ActionArgs_K_597242.Add(Nothing) 'SingleRow IN
		ActionArgs_K_597242.Add(EvalExpression("ListOfRows_K_597242")) 'ListOfRows IN
		ActionArgs_K_597242.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_597242 As object() = ActionArgs_K_597242.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_597242,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Set MetaTradTable = NOTHING
		_CurrentNode = "RDK:597258"
		MetaTradTable = CompilerUtil.CreateInstanceByType(MetaTradTable.GetType)
		
		'Set TradTable = NOTHING
		_CurrentNode = "RDK:597266"
		TradTable = CompilerUtil.CreateInstanceByType(TradTable.GetType)
		
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
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|wo_state|STCODEID|DESCRI|STDESCRI_
		_CurrentNode = "RDK:142"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "wo_state"
			.ID = "STCODEID"
			.ID2 = "DESCRI"
			.Fields = "STDESCRI_"
		End With
		FusionInfoTables.Add(FusionTableKeys)
		
		'SetStruct FusionInfoTables <-- FusionTableKeys = FUSION|wo_state|STCODEID|NAME|STNAME_
		_CurrentNode = "RDK:561"
		FusionTableKeys = new FusionTableKeysType
		With FusionTableKeys
			.DB = "FUSION"
			.TableName = "wo_state"
			.ID = "STCODEID"
			.ID2 = "NAME"
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

	'FOREACH dmfolder_row IN dmfolder_table
	Private Sub FOREACHLOOP_K_597147()
		_CurrentNode = "RDK:597147"
		Dim Values_RDK_597147 as object = dmfolder_table
		Dim Index_RDK_597147 as integer
		Dim MaxCount_RDK_597147 as integer = CompilerUtil.Count(Values_RDK_597147)
		If MaxCount_RDK_597147 <= 0 then return
		Index_RDK_597147 = 0
		i = 1
	next_foreach:
		dmfolder_row = CompilerUtil.Clone(Values_RDK_597147(Index_RDK_597147))
		
		'SetStruct MetaTradTable <-- MetaTrad = baseIDX+i|FUSION|dm_folder_001|dmfolder_row.TAG||dmfolder_row.LAST_UPDATE
		_CurrentNode = "RDK:597180"
		MetaTrad = new MetaTradType
		With MetaTrad
			.IDX = EvalExpression("IDX_K_597180")
			.ORIGIN_DB = "FUSION"
			.ORIGIN_TABLE = "dm_folder_001"
			.ORIGIN_ID_0 = EvalExpression("ORIGIN_ID_0_K_597180")
			.LAST_UPDATE = EvalExpression("LAST_UPDATE_K_597180")
		End With
		MetaTradTable.Add(MetaTrad)
		
		'SetStruct TradTable <-- Trad = baseIDX+i|dmfolder_row.ITA|dmfolder_row.ENG|dmfolder_row.ESP|dmfolder_row.FRA|dmfolder_ro... (125 chars)
		_CurrentNode = "RDK:597206"
		Trad = new TradType
		With Trad
			.IDX = EvalExpression("IDX_K_597206")
			.ITA = EvalExpression("ITA_K_597206")
			.ENG = EvalExpression("ENG_K_597206")
			.ESP = EvalExpression("ESP_K_597206")
			.FRA = EvalExpression("FRA_K_597206")
			.DEU = EvalExpression("DEU_K_597206")
		End With
		TradTable.Add(Trad)
		
	next_iteration:
		Index_RDK_597147 += 1
		If Index_RDK_597147 >= MaxCount_RDK_597147 then return
		i += 1
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
		ActionArgs_K_628.Add(EvalConstant(GetType(string),"SELECT cvalValore as ITA, cvalTrans1 as ENG, cvalTrans4 as ESP, cvalTrans2 as FRA, cvalTrans3 as DEU FROM CODVAL WHERE cpID in ('328', '329' ) ANDç§NOT (cvalValore='' AND cvalTrans1='' AND cvalTrans4='' AND cvalTrans2='' AND cvalTrans3='')")) 'SelectQuery IN
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
		
		'Set queryFindTags = "SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL WHERE cpID in ('328', '329') AND cvalV... (536 chars)
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
		
		'SetStruct MetaTradTable <-- MetaTrad = Trad.IDX|PDM|CODVAL|SupportRowTags.ORIGIN_ID_0|SupportRowTags.ORIGIN_ID_1|Now()
		_CurrentNode = "RDK:645"
		MetaTrad = new MetaTradType
		With MetaTrad
			.IDX = EvalExpression("IDX_K_645")
			.ORIGIN_DB = "PDM"
			.ORIGIN_TABLE = "CODVAL"
			.ORIGIN_ID_0 = EvalExpression("ORIGIN_ID_0_K_645")
			.ORIGIN_ID_1 = EvalExpression("ORIGIN_ID_1_K_645")
			.LAST_UPDATE = EvalExpression("LAST_UPDATE_K_645")
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
		
		'Set queryFindTags = "SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL WHERE cpID in ('497', '489', '459', '37... (492 chars)
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
		
		'SetStruct MetaTradTable <-- MetaTrad = Trad.IDX|PDM|CODVAL|SupportRowTags.ORIGIN_ID_0|SupportRowTags.ORIGIN_ID_1|Now()
		_CurrentNode = "RDK:684"
		MetaTrad = new MetaTradType
		With MetaTrad
			.IDX = EvalExpression("IDX_K_684")
			.ORIGIN_DB = "PDM"
			.ORIGIN_TABLE = "CODVAL"
			.ORIGIN_ID_0 = EvalExpression("ORIGIN_ID_0_K_684")
			.ORIGIN_ID_1 = EvalExpression("ORIGIN_ID_1_K_684")
			.LAST_UPDATE = EvalExpression("LAST_UPDATE_K_684")
		End With
		MetaTradTable.Add(MetaTrad)
		
	next_iteration:
		Index_RDK_685 += 1
		If Index_RDK_685 >= MaxCount_RDK_685 then return
		goto next_foreach
	End Sub

	'GRAPHICAL STUDIO *LOG_DISABLED
	Private Sub GRAPHICAL_STUDIO_K_704()
		_CurrentNode = "RDK:704"
		'FOREACH _language IN Languages BYREF
		Call FOREACHLOOP_K_722()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Insert DB Structured
		_CurrentNode = "RDK:767"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_767 as New Generic.list(of object)
		ActionArgs_K_767.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_767.Add("TRADS") 'InsertTable IN
		ActionArgs_K_767.Add(1) 'InsertQueryType IN
		ActionArgs_K_767.Add(Nothing) 'SingleRow IN
		ActionArgs_K_767.Add(EvalExpression("ListOfRows_K_767")) 'ListOfRows IN
		ActionArgs_K_767.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_767 As object() = ActionArgs_K_767.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_767,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'FOREACH MetaTrad IN MetaTradTable
		Call FOREACHLOOP_K_596820()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Insert DB Structured
		_CurrentNode = "RDK:596807"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_596807 as New Generic.list(of object)
		ActionArgs_K_596807.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_596807.Add("METATRADS") 'InsertTable IN
		ActionArgs_K_596807.Add(1) 'InsertQueryType IN
		ActionArgs_K_596807.Add(Nothing) 'SingleRow IN
		ActionArgs_K_596807.Add(EvalExpression("ListOfRows_K_596807")) 'ListOfRows IN
		ActionArgs_K_596807.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_596807 As object() = ActionArgs_K_596807.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_596807,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Set baseIDX = baseIDX+i
		_CurrentNode = "RDK:778"
		baseIDX = EvalExpression("Set_baseIDX_K_778")
		
		'Set TradTable = NOTHING
		_CurrentNode = "RDK:828"
		TradTable = CompilerUtil.CreateInstanceByType(TradTable.GetType)
		
		'Set MetaTradTable = NOTHING
		_CurrentNode = "RDK:833"
		MetaTradTable = CompilerUtil.CreateInstanceByType(MetaTradTable.GetType)
		
		'Set SupportTableTags = NOTHING
		_CurrentNode = "RDK:838"
		SupportTableTags = CompilerUtil.CreateInstanceByType(SupportTableTags.GetType)
		
	End Sub

	'FOREACH _language IN Languages BYREF
	Private Sub FOREACHLOOP_K_722()
		_CurrentNode = "RDK:722"
		Dim Values_RDK_722 as object = EvalExpression("ForEachValues_K_722")
		Dim Index_RDK_722 as integer
		Dim MaxCount_RDK_722 as integer = CompilerUtil.Count(Values_RDK_722)
		If MaxCount_RDK_722 <= 0 then return
		Index_RDK_722 = 0
	next_foreach:
		_language = Values_RDK_722(Index_RDK_722)
		
		'Set JSONFile = GS_TradPath+"\language_"+_language+".txt"
		_CurrentNode = "RDK:596676"
		JSONFile = EvalExpression("Set_JSONFile_K_596676")
		
		'Set JSONtext = ReadTextFile(JSONFile)
		_CurrentNode = "RDK:752"
		JSONtext = EvalExpression("Set_JSONtext_K_752")
		
		'Set kvTable = FromJSON(JSONtext, "(HASH)(KEYVALUE)")
		_CurrentNode = "RDK:753"
		kvTable = EvalExpression("Set_kvTable_K_753")
		
		'If FileLastWriteDate(JSONFile)>LastUpdate is True
		Call IFTHENELSE_K_596713()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

		'If _language="ITA" is True
		Call IFTHENELSE_K_756()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_722 += 1
		If Index_RDK_722 >= MaxCount_RDK_722 then return
		goto next_foreach
	End Sub

	'If FileLastWriteDate(JSONFile)>LastUpdate is True
	Private Sub IFTHENELSE_K_596713()
		_CurrentNode = "RDK:596713"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_596713")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If FileLastWriteDate(JSONFile)>LastUpdate is True
			Call THENGROUP_K_596714()

		End if
	End Sub

	'If FileLastWriteDate(JSONFile)>LastUpdate is True
	Private Sub THENGROUP_K_596714()
		_CurrentNode = "RDK:596714"
		'Set LastUpdate = FileLastWriteDate(JSONFile)
		_CurrentNode = "RDK:596753"
		LastUpdate = EvalExpression("Set_LastUpdate_K_596753")
		
	End Sub

	'If _language="ITA" is True
	Private Sub IFTHENELSE_K_756()
		_CurrentNode = "RDK:756"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_756")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If _language="ITA" is True
			Call THENGROUP_K_757()

		else
			'SetStruct TradTable <-- Trad = baseIDX+i|iif(_language="ITA",kvRow.value,Trad.ITA)
			Call ELSEGROUP_K_774()

		End if
	End Sub

	'If _language="ITA" is True
	Private Sub THENGROUP_K_757()
		_CurrentNode = "RDK:757"
		'FOREACH kvRow IN kvTable
		Call FOREACHLOOP_K_764()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'FOREACH kvRow IN kvTable
	Private Sub FOREACHLOOP_K_764()
		_CurrentNode = "RDK:764"
		Dim Values_RDK_764 as object = kvTable
		Dim Index_RDK_764 as integer
		Dim MaxCount_RDK_764 as integer = CompilerUtil.Count(Values_RDK_764)
		If MaxCount_RDK_764 <= 0 then return
		Index_RDK_764 = 0
		i = 1
	next_foreach:
		kvRow = CompilerUtil.Clone(Values_RDK_764(Index_RDK_764))
		
		'SetStruct MetaTradTable <-- MetaTrad = baseIDX+i|GRAPHICAL STUDIO|JSON FILES|kvRow.key
		_CurrentNode = "RDK:763"
		MetaTrad = new MetaTradType
		With MetaTrad
			.IDX = EvalExpression("IDX_K_763")
			.ORIGIN_DB = "GRAPHICAL STUDIO"
			.ORIGIN_TABLE = "JSON FILES"
			.ORIGIN_ID_0 = EvalExpression("ORIGIN_ID_0_K_763")
		End With
		MetaTradTable.Add(MetaTrad)
		
		'SetStruct TradTable <-- Trad = baseIDX+i|iif(_language="ITA",kvRow.value,Trad.ITA)
		_CurrentNode = "RDK:755"
		Trad = new TradType
		With Trad
			.IDX = EvalExpression("IDX_K_755")
			.ITA = EvalExpression("ITA_K_755")
		End With
		TradTable.Add(Trad)
		
	next_iteration:
		Index_RDK_764 += 1
		If Index_RDK_764 >= MaxCount_RDK_764 then return
		i += 1
		goto next_foreach
	End Sub

	'SetStruct TradTable <-- Trad = baseIDX+i|iif(_language="ITA",kvRow.value,Trad.ITA)
	Private Sub ELSEGROUP_K_774()
		_CurrentNode = "RDK:774"
		'FOREACH kvRow IN kvTable
		Call FOREACHLOOP_K_754()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

	End Sub

	'FOREACH kvRow IN kvTable
	Private Sub FOREACHLOOP_K_754()
		_CurrentNode = "RDK:754"
		Dim Values_RDK_754 as object = kvTable
		Dim Index_RDK_754 as integer
		Dim MaxCount_RDK_754 as integer = CompilerUtil.Count(Values_RDK_754)
		If MaxCount_RDK_754 <= 0 then return
		Index_RDK_754 = 0
		i = 1
	next_foreach:
		kvRow = CompilerUtil.Clone(Values_RDK_754(Index_RDK_754))
		
		'SetStruct Trad = TradTable[i-1].IDX|TradTable[i-1].ITA|iif(_language="ENG",kvRow.value,TradTable[i-1].ENG)|iif(_language... (262 chars)
		_CurrentNode = "RDK:596640"
		Trad = new TradType
		With Trad
			.IDX = EvalExpression("IDX_K_596640")
			.ITA = EvalExpression("ITA_K_596640")
			.ENG = EvalExpression("ENG_K_596640")
			.ESP = EvalExpression("ESP_K_596640")
			.FRA = EvalExpression("FRA_K_596640")
			.DEU = EvalExpression("DEU_K_596640")
		End With
		
		'Set TradTable[i-1] = Trad
		_CurrentNode = "RDK:663069"
		TradTable(i-1) = EvalExpression("Set_TradTable_i_1__K_663069")
		
	next_iteration:
		Index_RDK_754 += 1
		If Index_RDK_754 >= MaxCount_RDK_754 then return
		i += 1
		goto next_foreach
	End Sub

	'FOREACH MetaTrad IN MetaTradTable
	Private Sub FOREACHLOOP_K_596820()
		_CurrentNode = "RDK:596820"
		Dim Values_RDK_596820 as object = MetaTradTable
		Dim Index_RDK_596820 as integer
		Dim MaxCount_RDK_596820 as integer = CompilerUtil.Count(Values_RDK_596820)
		If MaxCount_RDK_596820 <= 0 then return
		Index_RDK_596820 = 0
		j = 1
	next_foreach:
		MetaTrad = CompilerUtil.Clone(Values_RDK_596820(Index_RDK_596820))
		
		'SetStruct MetaTrad = MetaTradTable[j-1].IDX|MetaTradTable[j-1].ORIGIN_DB|MetaTradTable[j-1].ORIGIN_TABLE|MetaTradTable[j... (147 chars)
		_CurrentNode = "RDK:596846"
		MetaTrad = new MetaTradType
		With MetaTrad
			.IDX = EvalExpression("IDX_K_596846")
			.ORIGIN_DB = EvalExpression("ORIGIN_DB_K_596846")
			.ORIGIN_TABLE = EvalExpression("ORIGIN_TABLE_K_596846")
			.ORIGIN_ID_0 = EvalExpression("ORIGIN_ID_0_K_596846")
			.LAST_UPDATE = EvalExpression("LAST_UPDATE_K_596846")
		End With
		
		'Set MetaTradTable[j-1] = MetaTrad
		_CurrentNode = "RDK:663107"
		MetaTradTable(j-1) = EvalExpression("Set_MetaTradTable_j_1__K_663107")
		
	next_iteration:
		Index_RDK_596820 += 1
		If Index_RDK_596820 >= MaxCount_RDK_596820 then return
		j += 1
		goto next_foreach
	End Sub

	'CRM *LOG_DISABLED
	Private Sub CRM_K_780()
		_CurrentNode = "RDK:780"
		'Set xml_crm = StrReplace(ReadTextFile(CRM_TradPath), "-->", "--><TRANSLATED_STRINGS>")+"</TRANSLATED_STRINGS>"
		_CurrentNode = "RDK:784"
		xml_crm = EvalExpression("Set_xml_crm_K_784")
		
		'Set array_xml = XmlChildren(xml_crm, "TRANSLATED_STRINGS")
		_CurrentNode = "RDK:795"
		array_xml = EvalExpression("Set_array_xml_K_795")
		
		'FOREACH tag IN array_xml
		Call FOREACHLOOP_K_803()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Insert DB Structured
		_CurrentNode = "RDK:873"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_873 as New Generic.list(of object)
		ActionArgs_K_873.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_873.Add("METATRADS") 'InsertTable IN
		ActionArgs_K_873.Add(1) 'InsertQueryType IN
		ActionArgs_K_873.Add(Nothing) 'SingleRow IN
		ActionArgs_K_873.Add(EvalExpression("ListOfRows_K_873")) 'ListOfRows IN
		ActionArgs_K_873.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_873 As object() = ActionArgs_K_873.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_873,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Insert DB Structured
		_CurrentNode = "RDK:1403"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_1403 as New Generic.list(of object)
		ActionArgs_K_1403.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_1403.Add("TRADS") 'InsertTable IN
		ActionArgs_K_1403.Add(1) 'InsertQueryType IN
		ActionArgs_K_1403.Add(Nothing) 'SingleRow IN
		ActionArgs_K_1403.Add(EvalExpression("ListOfRows_K_1403")) 'ListOfRows IN
		ActionArgs_K_1403.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_1403 As object() = ActionArgs_K_1403.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_1403,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
	End Sub

	'FOREACH tag IN array_xml
	Private Sub FOREACHLOOP_K_803()
		_CurrentNode = "RDK:803"
		Dim Values_RDK_803 as object = array_xml
		Dim Index_RDK_803 as integer
		Dim MaxCount_RDK_803 as integer = CompilerUtil.Count(Values_RDK_803)
		If MaxCount_RDK_803 <= 0 then return
		Index_RDK_803 = 0
	next_foreach:
		tag = CompilerUtil.Clone(Values_RDK_803(Index_RDK_803))
		
		'TAG TYPE
		Call CONDITIONALNODE_K_807()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_803 += 1
		If Index_RDK_803 >= MaxCount_RDK_803 then return
		goto next_foreach
	End Sub

	'TAG TYPE
	Private Sub CONDITIONALNODE_K_807()
		_CurrentNode = "RDK:807"
		Dim _ChoiceTaken as boolean = false
		
		'---------- START NODE CONDITIONS 
		Orig_str = EvalExpression("NODE_Orig_str_K_807")
		ITA = EvalExpression("NODE_ITA_K_807")
		ENG = EvalExpression("NODE_ENG_K_807")
		ESP = EvalExpression("NODE_ESP_K_807")
		FRA = EvalExpression("NODE_FRA_K_807")
		DEU = EvalExpression("NODE_DEU_K_807")
		'---------- END CONDITIONAL NODE
		'Choice: Orig_str is True
		Call CHOICE_K_821(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ITA is True
		Call CHOICE_K_918(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ENG is True
		Call CHOICE_K_1086(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: ESP is True
		Call CHOICE_K_1117(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: FRA is True
		Call CHOICE_K_1148(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

		'Choice: DEU is True
		Call CHOICE_K_1179(_ChoiceTaken)
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return

	End Sub

	'Choice: Orig_str is True
	Private Sub CHOICE_K_821(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:821"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_821")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'Set Trad = NOTHING
		_CurrentNode = "RDK:849"
		Trad = CompilerUtil.CreateInstanceByType(Trad.GetType)
		
		'Set value = XmlText(tag)
		_CurrentNode = "RDK:802"
		value = EvalExpression("Set_value_K_802")
		
		'Set j = j+1
		_CurrentNode = "RDK:863"
		j = EvalExpression("Set_j_K_863")
		
		'SetStruct MetaTradTable <-- MetaTrad = j+baseIDX|CRM|XML|value||LastUpdate
		_CurrentNode = "RDK:876"
		MetaTrad = new MetaTradType
		With MetaTrad
			.IDX = EvalExpression("IDX_K_876")
			.ORIGIN_DB = "CRM"
			.ORIGIN_TABLE = "XML"
			.ORIGIN_ID_0 = EvalExpression("ORIGIN_ID_0_K_876")
			.LAST_UPDATE = EvalExpression("LAST_UPDATE_K_876")
		End With
		MetaTradTable.Add(MetaTrad)
		
		'SetStruct TradTable <-- Trad = baseIDX+j
		_CurrentNode = "RDK:887"
		Trad = new TradType
		With Trad
			.IDX = EvalExpression("IDX_K_887")
		End With
		TradTable.Add(Trad)
		
	End Sub

	'Choice: ITA is True
	Private Sub CHOICE_K_918(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:918"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_918")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'SetStruct Trad = TradTable[j-1].IDX|XmlText(tag)|TradTable[j-1].ENG|TradTable[j-1].ESP|TradTable[j-1].FRA|TradTable[j-1]... (124 chars)
		_CurrentNode = "RDK:989"
		Trad = new TradType
		With Trad
			.IDX = EvalExpression("IDX_K_989")
			.ITA = EvalExpression("ITA_K_989")
			.ENG = EvalExpression("ENG_K_989")
			.ESP = EvalExpression("ESP_K_989")
			.FRA = EvalExpression("FRA_K_989")
			.DEU = EvalExpression("DEU_K_989")
		End With
		
		'Set TradTable[j-1] = Trad
		_CurrentNode = "RDK:663145"
		TradTable(j-1) = EvalExpression("Set_TradTable_j_1__K_663145")
		
	End Sub

	'Choice: ENG is True
	Private Sub CHOICE_K_1086(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:1086"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_1086")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'SetStruct Trad = TradTable[j-1].IDX|TradTable[j-1].ITA|XmlText(tag)|TradTable[j-1].ESP|TradTable[j-1].FRA|TradTable[j-1]... (124 chars)
		_CurrentNode = "RDK:1085"
		Trad = new TradType
		With Trad
			.IDX = EvalExpression("IDX_K_1085")
			.ITA = EvalExpression("ITA_K_1085")
			.ENG = EvalExpression("ENG_K_1085")
			.ESP = EvalExpression("ESP_K_1085")
			.FRA = EvalExpression("FRA_K_1085")
			.DEU = EvalExpression("DEU_K_1085")
		End With
		
		'Set TradTable[j-1] = Trad
		_CurrentNode = "RDK:663183"
		TradTable(j-1) = EvalExpression("Set_TradTable_j_1__K_663183")
		
	End Sub

	'Choice: ESP is True
	Private Sub CHOICE_K_1117(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:1117"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_1117")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'SetStruct Trad = TradTable[j-1].IDX|TradTable[j-1].ITA|TradTable[j-1].ENG|XmlText(tag)|TradTable[j-1].FRA|TradTable[j-1]... (124 chars)
		_CurrentNode = "RDK:1116"
		Trad = new TradType
		With Trad
			.IDX = EvalExpression("IDX_K_1116")
			.ITA = EvalExpression("ITA_K_1116")
			.ENG = EvalExpression("ENG_K_1116")
			.ESP = EvalExpression("ESP_K_1116")
			.FRA = EvalExpression("FRA_K_1116")
			.DEU = EvalExpression("DEU_K_1116")
		End With
		
		'Set TradTable[j-1] = Trad
		_CurrentNode = "RDK:663203"
		TradTable(j-1) = EvalExpression("Set_TradTable_j_1__K_663203")
		
	End Sub

	'Choice: FRA is True
	Private Sub CHOICE_K_1148(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:1148"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_1148")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'SetStruct Trad = TradTable[j-1].IDX|TradTable[j-1].ITA|TradTable[j-1].ENG|TradTable[j-1].ESP|XmlText(tag)|TradTable[j-1]... (124 chars)
		_CurrentNode = "RDK:1147"
		Trad = new TradType
		With Trad
			.IDX = EvalExpression("IDX_K_1147")
			.ITA = EvalExpression("ITA_K_1147")
			.ENG = EvalExpression("ENG_K_1147")
			.ESP = EvalExpression("ESP_K_1147")
			.FRA = EvalExpression("FRA_K_1147")
			.DEU = EvalExpression("DEU_K_1147")
		End With
		
		'Set TradTable[j-1] = Trad
		_CurrentNode = "RDK:663223"
		TradTable(j-1) = EvalExpression("Set_TradTable_j_1__K_663223")
		
	End Sub

	'Choice: DEU is True
	Private Sub CHOICE_K_1179(ByRef _ChoiceTaken As Boolean)
		_CurrentNode = "RDK:1179"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_1179")
exec_group:
'----------------------------------------------------
		if not _GroupExecute then return
		_ChoiceTaken = True
		'SetStruct Trad = TradTable[j-1].IDX|TradTable[j-1].ITA|TradTable[j-1].ENG|TradTable[j-1].ESP|TradTable[j-1].FRA|XmlText(... (124 chars)
		_CurrentNode = "RDK:1178"
		Trad = new TradType
		With Trad
			.IDX = EvalExpression("IDX_K_1178")
			.ITA = EvalExpression("ITA_K_1178")
			.ENG = EvalExpression("ENG_K_1178")
			.ESP = EvalExpression("ESP_K_1178")
			.FRA = EvalExpression("FRA_K_1178")
			.DEU = EvalExpression("DEU_K_1178")
		End With
		
		'Set TradTable[j-1] = Trad
		_CurrentNode = "RDK:663243"
		TradTable(j-1) = EvalExpression("Set_TradTable_j_1__K_663243")
		
	End Sub



#End Region

End Class
