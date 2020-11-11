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
		j = 0


        'CALL TO MAIN PROCESS
        Call Main_Group_K_0008()

    End Sub

#Region " --- PROCESS FUNCTIONS TABLE "

	Public Sub ExtractFromDB()	'FUNCTION: ExtractFromDB
		_CurrentNode = "RDK:74"

		'FOREACH _language IN Languages BYREF
		Call FOREACHLOOP_K_317()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'If Param.Input.TableName="dm_folder_001" is True
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
		ActionArgs_K_341.Add(EvalExpression("ConnectionName_K_341")) 'ConnectionName IN
		ActionArgs_K_341.Add("TRADS") 'InsertTable IN
		ActionArgs_K_341.Add(1) 'InsertQueryType IN
		ActionArgs_K_341.Add(Nothing) 'SingleRow IN
		ActionArgs_K_341.Add(EvalExpression("ListOfRows_K_341")) 'ListOfRows IN
		ActionArgs_K_341.Add("(NOERRORS)") 'Options IN
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

	'If Param.Input.TableName="dm_folder_001" is True
	Private Sub IFTHENELSE_K_554()
		_CurrentNode = "RDK:554"
		'Group Conditions
		Dim _GroupExecute As Boolean = EvalExpression("CondExp1_K_554")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If Param.Input.TableName="dm_folder_001" is True
			Call THENGROUP_K_553()

		else
			'Set queryTrads = "SELECT DISTINCT "+afterSelect+" FROM "+Param.Input.TableName+ " WHERE DMTYPE='C' AND DMDESCRI_ITA<>'PR... (157 chars)
			Call ELSEGROUP_K_557()

		End if
	End Sub

	'If Param.Input.TableName="dm_folder_001" is True
	Private Sub THENGROUP_K_553()
		_CurrentNode = "RDK:553"
		'Set queryTrads = "SELECT DISTINCT "+afterSelect+" FROM "+Param.Input.TableName+ " WHERE DMTYPE='C' AND DMDESCRI_ITA<>'PR... (157 chars)
		_CurrentNode = "RDK:552"
		queryTrads = EvalExpression("Set_queryTrads_K_552")
		
	End Sub

	'Set queryTrads = "SELECT DISTINCT "+afterSelect+" FROM "+Param.Input.TableName+ " WHERE DMTYPE='C' AND DMDESCRI_ITA<>'PR... (157 chars)
	Private Sub ELSEGROUP_K_557()
		_CurrentNode = "RDK:557"
		'Set queryTrads = "SELECT DISTINCT "+afterSelect+" FROM "+Param.Input.TableName
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
		
		'Set queryFindTags = "SELECT DISTINCT "+Param.Input.ID+ " AS ORIGIN_ID_0"
		_CurrentNode = "RDK:361"
		queryFindTags = EvalExpression("Set_queryFindTags_K_361")
		
		'If StrLength(Param.Input.ID2)=0 is False
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

		'Set queryFindTags = queryFindTags + " FROM "+Param.Input.TableName + " WHERE "+condITA+" AND "+condENG+" AND "+condESP+"... (150 chars)
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

	'If StrLength(Param.Input.ID2)=0 is False
	Private Sub IFTHENELSE_K_362()
		_CurrentNode = "RDK:362"
		'Group Conditions
		Dim _GroupExecute As Boolean = NOT EvalExpression("CondExp1_K_362")
exec_group:
'----------------------------------------------------
		if _GroupExecute then
		    'Call THEN group
			'If StrLength(Param.Input.ID2)=0 is False
			Call THENGROUP_K_363()

		End if
	End Sub

	'If StrLength(Param.Input.ID2)=0 is False
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
		'Set condITA = Param.Input.Fields+"ITA='"+StrSqlWC(Trad.ITA)+"'"
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
		'Set condENg = Param.Input.Fields+"ENG='"+StrSqlWC(Trad.ENG)+"'"
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
		'Set condESP = Param.Input.Fields+"ESP='"+StrSqlWC(Trad.ESP)+"'"
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
		'Set condFRA = Param.Input.Fields+"FRA='"+StrSqlWC(Trad.FRA)+"'"
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
		'Set condDEU = Param.Input.Fields+"DEU='"+StrSqlWC(Trad.DEU)+"'"
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

	End Sub

	'INIT (Reimpimento tabella traduzioni)
	Private Sub INIT_K_28()
		_CurrentNode = "RDK:28"
		'LocalDB
		Call LocalDB_K_248()
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
		ActionArgs_K_266.Add(EvalConstant(GetType(string),"IF NOT EXISTS (SELECT * ç§           FROM INFORMATION_SCHEMA.TABLES ç§           WHERE TABLE_TYPE='BASE TABLE' ç§           AND TABLE_NAME='TRADS') ç§   CREATE TABLE TRADS (ç§    IDX INT  PRIMARY KEY ,ç§    ITA varchar(1024),ç§    ENG varchar(1024),ç§    ESP varchar(1024),ç§    FRA varchar(1024),ç§    DEU varchar(1024),ç§    UPDATED BITç§)")) 'SqlStatement IN
		ActionArgs_K_266.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_266.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_266 As object() = ActionArgs_K_266.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_266)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
		'Execute SQL Statement
		_CurrentNode = "RDK:269"		'ACTION RDEngineering_DBExecuteStatement
		Dim ActionArgs_K_269 as New Generic.list(of object)
		ActionArgs_K_269.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_269.Add(EvalConstant(GetType(string),"IF NOT EXISTS (SELECT * ç§           FROM INFORMATION_SCHEMA.TABLES ç§           WHERE TABLE_TYPE='BASE TABLE' ç§           AND TABLE_NAME='METATRADS') ç§CREATE TABLE METATRADS (ç§    IDX int,ç§    ORIGIN_DB varchar(512),ç§    ORIGIN_TABLE varchar(512),ç§    ORIGIN_ID_0 varchar(1024) ,ç§    ORIGIN_ID_1 varchar(512),ç§    PRIMARY KEY(IDX, ORIGIN_ID_0, ORIGIN_ID_1, ORIGIN_TABLE, ORIGIN_DB)ç§)ç§")) 'SqlStatement IN
		ActionArgs_K_269.Add(Nothing) 'StatementResult OUT
		ActionArgs_K_269.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_269 As object() = ActionArgs_K_269.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBExecuteStatement",_ActionArgs_K_269)
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
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
		
		'Set JSONtext = ReadTextFile(GS_TradPath+"\language_"+_language+".txt")
		_CurrentNode = "RDK:752"
		JSONtext = EvalExpression("Set_JSONtext_K_752")
		
		'Set kvTable = FromJSON(JSONtext, "(HASH)(KEYVALUE)")
		_CurrentNode = "RDK:753"
		kvTable = EvalExpression("Set_kvTable_K_753")
		
		'If _language="ITA" is True
		Call IFTHENELSE_K_756()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,false) Then Return
		If CompilerUtil.MustDoNextIteration(_ExitTarget) Then goto next_iteration

	next_iteration:
		Index_RDK_722 += 1
		If Index_RDK_722 >= MaxCount_RDK_722 then return
		goto next_foreach
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
			'Insert DB Structured
			Call ELSEGROUP_K_774()

		End if
	End Sub

	'If _language="ITA" is True
	Private Sub THENGROUP_K_757()
		_CurrentNode = "RDK:757"
		'FOREACH kvRow IN kvTable
		Call FOREACHLOOP_K_764()
		If CompilerUtil.MustReturnToCaller(_ExitTarget,true) Then Return

		'Insert DB Structured
		_CurrentNode = "RDK:765"		'ACTION RDEngineering_DBInsert
		Dim ActionArgs_K_765 as New Generic.list(of object)
		ActionArgs_K_765.Add("LocalDB") 'ConnectionName IN
		ActionArgs_K_765.Add("METATRADS") 'InsertTable IN
		ActionArgs_K_765.Add(1) 'InsertQueryType IN
		ActionArgs_K_765.Add(Nothing) 'SingleRow IN
		ActionArgs_K_765.Add(EvalExpression("ListOfRows_K_765")) 'ListOfRows IN
		ActionArgs_K_765.Add(Nothing) 'Options IN
		Dim _ActionArgs_K_765 As object() = ActionArgs_K_765.ToArray
		_ActionResult = CompilerUtil.ExecuteAction("RDEngineering_DB_OLEDB","RDEngineering_DBInsert",_ActionArgs_K_765,CompilerUtil.ContextBuilder(CompilerUtil.CTXMODE.EMPTY))
		_ActionResult.ThrowExceptionIfFail(_CurrentNode)
		
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

	'Insert DB Structured
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
		
		'SetStruct TradTable[i-1] = TradTable[i-1].IDX|TradTable[i-1].ITA|iif(_language="ENG",kvRow.value,TradTable[i-1].ENG)|iif... (272 chars)
		_CurrentNode = "RDK:776"
		TradTable(i-1) = new Generic.List(Of TradType)
		With TradTable(i-1)
		End With
		
	next_iteration:
		Index_RDK_754 += 1
		If Index_RDK_754 >= MaxCount_RDK_754 then return
		i += 1
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
		
		'SetStruct MetaTradTable <-- MetaTrad = j+baseIDX|CRM|XML|value
		_CurrentNode = "RDK:876"
		MetaTrad = new MetaTradType
		With MetaTrad
			.IDX = EvalExpression("IDX_K_876")
			.ORIGIN_DB = "CRM"
			.ORIGIN_TABLE = "XML"
			.ORIGIN_ID_0 = EvalExpression("ORIGIN_ID_0_K_876")
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
	End Sub



#End Region

End Class
