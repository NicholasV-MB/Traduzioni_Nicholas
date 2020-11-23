Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.BasicFunctionsProxy

Module StaticExpressions

    'This placeholder is for static expression table
	'OriginalExpression: 'ProcPath()+"Settings.ini"
	<Extension()>
	Public Function Eval_Static_Set_IniFilePath_K_686349(ByVal Main As RDCompiledProcess) As Object
		return ProcPath()+"Settings.ini"
	End Function

	'FOREACH _language IN Languages BYREF
	'OriginalExpression: 'Languages
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_317(ByVal Main As RDCompiledProcess) As Object
		return Languages
	End Function

	'OriginalExpression: 'afterSelect + _Param.Input.Fields+_language + " AS "+_language 
	<Extension()>
	Public Function Eval_Static_Set_afterSelect_K_321(ByVal Main As RDCompiledProcess) As Object
		return afterSelect + _Param.Input.Fields+_language + " AS "+_language 
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: '_language<>"DEU"
	<Extension()>
	Public Function Eval_Static_CondExp1_K_327(ByVal Main As RDCompiledProcess) As Object
		return _language<>"DEU"
	End Function

	'OriginalExpression: 'afterSelect +", "
	<Extension()>
	Public Function Eval_Static_Set_afterSelect_K_332(ByVal Main As RDCompiledProcess) As Object
		return afterSelect +", "
	End Function

	'OriginalExpression: '"SELECT DISTINCT "+afterSelect+" FROM "+_Param.Input.TableName
	<Extension()>
	Public Function Eval_Static_Set_queryTrads_K_597357(ByVal Main As RDCompiledProcess) As Object
		return "SELECT DISTINCT "+afterSelect+" FROM "+_Param.Input.TableName
	End Function

	'OriginalExpression: '""
	<Extension()>
	Public Function Eval_Static_Set_afterSelect_K_355(ByVal Main As RDCompiledProcess) As Object
		return ""
	End Function

	'OriginalExpression: 'queryTrads+ " WHERE NOT ("+_Param.Input.Fields+"ITA IS NULL AND "+_Param.Input.Fields+"ENG IS NULL AND "+_Param.Input.Fields+"ESP IS NULL AND "+_Param.Input.Fields+"FRA IS NULL AND "+_Param.Input.Fields+"DEU IS NULL) AND "+_Param.Input.Fields+"ENG<>'_ENG'"
	<Extension()>
	Public Function Eval_Static_Set_queryTrads_K_662637(ByVal Main As RDCompiledProcess) As Object
		return queryTrads+ " WHERE NOT ("+_Param.Input.Fields+"ITA IS NULL AND "+_Param.Input.Fields+"ENG IS NULL AND "+_Param.Input.Fields+"ESP IS NULL AND "+_Param.Input.Fields+"FRA IS NULL AND "+_Param.Input.Fields+"DEU IS NULL) AND "+_Param.Input.Fields+"ENG<>'_ENG'"
	End Function

	'OriginalExpression: '"DB_"+_Param.Input.DB
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_300(ByVal Main As RDCompiledProcess) As Object
		return "DB_"+_Param.Input.DB
	End Function

	'OriginalExpression: 'queryTrads
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_300(ByVal Main As RDCompiledProcess) As Object
		return queryTrads
	End Function

	'OriginalExpression: 'i+baseIDX
	<Extension()>
	Public Function Eval_Static_Set_TradTable_i_1__IDX_K_351(ByVal Main As RDCompiledProcess) As Object
		return i+baseIDX
	End Function

	'OriginalExpression: '"INSERT INTO TRADS VALUES('"+StrSql(TradTable(i-1).IDX)+"', '"+StrSql(TradTable(i-1).ITA)+"', '"+StrSql(TradTable(i-1).ENG)+"', '"+StrSql(TradTable(i-1).ESP)+"', '"+StrSql(TradTable(i-1).FRA)+"', '"+StrSql(TradTable(i-1).DEU)+"', Null, Null, Null)"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_663596(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO TRADS VALUES('"+StrSql(TradTable(i-1).IDX)+"', '"+StrSql(TradTable(i-1).ITA)+"', '"+StrSql(TradTable(i-1).ENG)+"', '"+StrSql(TradTable(i-1).ESP)+"', '"+StrSql(TradTable(i-1).FRA)+"', '"+StrSql(TradTable(i-1).DEU)+"', Null, Null, Null)"
	End Function

	'OriginalExpression: 'i+baseIDX
	<Extension()>
	Public Function Eval_Static_Set_baseIDX_K_358(ByVal Main As RDCompiledProcess) As Object
		return i+baseIDX
	End Function

	'OriginalExpression: '"SELECT DISTINCT "+_Param.Input.ID+ " AS ORIGIN_ID_0" 
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_361(ByVal Main As RDCompiledProcess) As Object
		return "SELECT DISTINCT "+_Param.Input.ID+ " AS ORIGIN_ID_0" 
	End Function

	'Condition for group: IFTHENELSE
	'OriginalExpression: '_Param.Input.ID2<>""
	<Extension()>
	Public Function Eval_Static_CondExp1_K_362(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.ID2<>""
	End Function

	'Condition for group: IFTHENELSE
	'OriginalExpression: '_Param.Input.TableName<>"wo_state"
	<Extension()>
	Public Function Eval_Static_CondExp2_K_362(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.TableName<>"wo_state"
	End Function

	'OriginalExpression: 'queryFindTags + ", "+_Param.Input.ID2+ " AS ORIGIN_ID_1"
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_370(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags + ", "+_Param.Input.ID2+ " AS ORIGIN_ID_1"
	End Function

	'OriginalExpression: 'queryFindTags + ", MAX(cpupdtms) AS LAST_UPDATE"
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_596512(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags + ", MAX(cpupdtms) AS LAST_UPDATE"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(Trad.ITA)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_426(ByVal Main As RDCompiledProcess) As Object
		return StrLength(Trad.ITA)=0
	End Function

	'OriginalExpression: '_Param.Input.Fields+"ITA IS NULL"
	<Extension()>
	Public Function Eval_Static_Set_condITA_K_435(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"ITA IS NULL"
	End Function

	'OriginalExpression: '_Param.Input.Fields+"ITA='"+StrSql(Trad.ITA)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condITA_K_437(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"ITA='"+StrSql(Trad.ITA)+"'"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(Trad.ENG)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_467(ByVal Main As RDCompiledProcess) As Object
		return StrLength(Trad.ENG)=0
	End Function

	'OriginalExpression: '_Param.Input.Fields +"ENG IS NULL"
	<Extension()>
	Public Function Eval_Static_Set_condENG_K_463(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields +"ENG IS NULL"
	End Function

	'OriginalExpression: '_Param.Input.Fields+"ENG='"+StrSql(Trad.ENG)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condENg_K_465(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"ENG='"+StrSql(Trad.ENG)+"'"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(Trad.ESP)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_489(ByVal Main As RDCompiledProcess) As Object
		return StrLength(Trad.ESP)=0
	End Function

	'OriginalExpression: '_Param.Input.Fields +"ESP IS NULL"
	<Extension()>
	Public Function Eval_Static_Set_condESP_K_485(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields +"ESP IS NULL"
	End Function

	'OriginalExpression: '_Param.Input.Fields+"ESP='"+StrSql(Trad.ESP)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condESP_K_487(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"ESP='"+StrSql(Trad.ESP)+"'"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(Trad.FRA)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_505(ByVal Main As RDCompiledProcess) As Object
		return StrLength(Trad.FRA)=0
	End Function

	'OriginalExpression: '_Param.Input.Fields+"FRA IS NULL"
	<Extension()>
	Public Function Eval_Static_Set_condFRA_K_501(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"FRA IS NULL"
	End Function

	'OriginalExpression: '_Param.Input.Fields+"FRA='"+StrSql(Trad.FRA)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condFRA_K_503(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"FRA='"+StrSql(Trad.FRA)+"'"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(Trad.DEU)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_523(ByVal Main As RDCompiledProcess) As Object
		return StrLength(Trad.DEU)=0
	End Function

	'OriginalExpression: '_Param.Input.Fields +"DEU IS NULL"
	<Extension()>
	Public Function Eval_Static_Set_condDEU_K_519(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields +"DEU IS NULL"
	End Function

	'OriginalExpression: '_Param.Input.Fields+"DEU='"+StrSql(Trad.DEU)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condDEU_K_521(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"DEU='"+StrSql(Trad.DEU)+"'"
	End Function

	'OriginalExpression: 'queryFindTags + " FROM "+_Param.Input.TableName + " WHERE "+condITA+" AND "+condENG+" AND "+condESP+" AND "+condFRA+" AND "+condDEU+" GROUP BY "+_Param.Input.ID
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_372(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags + " FROM "+_Param.Input.TableName + " WHERE "+condITA+" AND "+condENG+" AND "+condESP+" AND "+condFRA+" AND "+condDEU+" GROUP BY "+_Param.Input.ID
	End Function

	'Condition for group: IFTHENELSE
	'OriginalExpression: '_Param.Input.ID2<>""
	<Extension()>
	Public Function Eval_Static_CondExp1_K_596588(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.ID2<>""
	End Function

	'Condition for group: IFTHENELSE
	'OriginalExpression: '_Param.Input.TableName<>"wo_state"
	<Extension()>
	Public Function Eval_Static_CondExp2_K_596588(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.TableName<>"wo_state"
	End Function

	'OriginalExpression: 'queryFindTags + ", "+_Param.Input.ID2
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_596586(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags + ", "+_Param.Input.ID2
	End Function

	'OriginalExpression: '"DB_"+_Param.Input.DB
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_374(ByVal Main As RDCompiledProcess) As Object
		return "DB_"+_Param.Input.DB
	End Function

	'OriginalExpression: 'queryFindTags
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_374(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'Count(SupportTableTags)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_698105(ByVal Main As RDCompiledProcess) As Object
		return Count(SupportTableTags)=0
	End Function

	'OriginalExpression: '"DB_"+_Param.Input.DB
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_698137(ByVal Main As RDCompiledProcess) As Object
		return "DB_"+_Param.Input.DB
	End Function

	'OriginalExpression: 'StrReplace(queryFindTags, " IS NULL", "=''")
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_698137(ByVal Main As RDCompiledProcess) As Object
		return StrReplace(queryFindTags, " IS NULL", "=''")
	End Function

	'FOREACH SupportRowTags IN SupportTableTags BYREF
	'OriginalExpression: 'SupportTableTags
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_375(ByVal Main As RDCompiledProcess) As Object
		return SupportTableTags
	End Function

	'OriginalExpression: '"INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(Trad.IDX)+"', '"+_Param.Input.DB+"', '"+_Param.Input.TableName+"', '"+SupportRowTags.ORIGIN_ID_0+"', '"+IIF(_Param.Input.TableName="wo_state", _Param.Input.ID2, SupportRowTags.ORIGIN_ID_1)+"', '"+IIF(RDToString(SupportRowTags.LAST_UPDATE)="",RDToString(Now()),RDToString(SupportRowTags.LAST_UPDATE))+"')"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_700(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(Trad.IDX)+"', '"+_Param.Input.DB+"', '"+_Param.Input.TableName+"', '"+SupportRowTags.ORIGIN_ID_0+"', '"+IIF(_Param.Input.TableName="wo_state", _Param.Input.ID2, SupportRowTags.ORIGIN_ID_1)+"', '"+IIF(RDToString(SupportRowTags.LAST_UPDATE)="",RDToString(Now()),RDToString(SupportRowTags.LAST_UPDATE))+"')"
	End Function

	'OriginalExpression: 'ReadIni(IniFilePath, "FUSION", "ConnectionString")
	<Extension()>
	Public Function Eval_Static_Set_ConnStr_FUSION_K_686229(ByVal Main As RDCompiledProcess) As Object
		return ReadIni(IniFilePath, "FUSION", "ConnectionString")
	End Function

	'OriginalExpression: 'ReadIni(IniFilePath, "LOCAL", "ConnectionString")
	<Extension()>
	Public Function Eval_Static_Set_ConnStr_LOCAL_K_686243(ByVal Main As RDCompiledProcess) As Object
		return ReadIni(IniFilePath, "LOCAL", "ConnectionString")
	End Function

	'OriginalExpression: 'ReadIni(IniFilePath, "PDM", "ConnectionString")
	<Extension()>
	Public Function Eval_Static_Set_ConnStr_PDM_K_686251(ByVal Main As RDCompiledProcess) As Object
		return ReadIni(IniFilePath, "PDM", "ConnectionString")
	End Function

	'OriginalExpression: 'ProcPath()+ReadIni(IniFilePath, "GRAPHICAL STUDIO", "TranslationPath")
	<Extension()>
	Public Function Eval_Static_Set_GS_TradPath_K_686259(ByVal Main As RDCompiledProcess) As Object
		return ProcPath()+ReadIni(IniFilePath, "GRAPHICAL STUDIO", "TranslationPath")
	End Function

	'OriginalExpression: 'ProcPath()+ReadIni(IniFilePath, "CRM", "MBPath")
	<Extension()>
	Public Function Eval_Static_Set_CRM_TradPath_K_686267(ByVal Main As RDCompiledProcess) As Object
		return ProcPath()+ReadIni(IniFilePath, "CRM", "MBPath")
	End Function

	'OriginalExpression: 'SplitStr(ReadIni(IniFilePath, "LANGUAGES", "Languages"), ",", "")
	<Extension()>
	Public Function Eval_Static_Set_Languages_K_686311(ByVal Main As RDCompiledProcess) As Object
		return SplitStr(ReadIni(IniFilePath, "LANGUAGES", "Languages"), ",", "")
	End Function

	'OriginalExpression: 'ConnStr_LOCAL
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_251(ByVal Main As RDCompiledProcess) As Object
		return ConnStr_LOCAL
	End Function

	'OriginalExpression: 'ConnStr_FUSION
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_36(ByVal Main As RDCompiledProcess) As Object
		return ConnStr_FUSION
	End Function

	'OriginalExpression: 'FusionTableKeys
	<Extension()>
	Public Function Eval_Static_InputParam_K_75(ByVal Main As RDCompiledProcess) As Object
		return FusionTableKeys
	End Function

	'OriginalExpression: 'baseIDX+i
	<Extension()>
	Public Function Eval_Static_IDX_K_597180(ByVal Main As RDCompiledProcess) As Object
		return baseIDX+i
	End Function

	'OriginalExpression: 'dmfolder_row.TAG
	<Extension()>
	Public Function Eval_Static_ORIGIN_ID_0_K_597180(ByVal Main As RDCompiledProcess) As Object
		return dmfolder_row.TAG
	End Function

	'OriginalExpression: 'dmfolder_row.LAST_UPDATE
	<Extension()>
	Public Function Eval_Static_LAST_UPDATE_K_597180(ByVal Main As RDCompiledProcess) As Object
		return dmfolder_row.LAST_UPDATE
	End Function

	'OriginalExpression: '"INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(MetaTrad.IDX)+"', '"+StrSql(MetaTrad.ORIGIN_DB)+"', '"+StrSql(MetaTrad.ORIGIN_TABLE)+"', '"+StrSql(MetaTrad.ORIGIN_ID_0)+"', '"+StrSql("")+"', '"+RDToString(MetaTrad.LAST_UPDATE)+"')"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_664072(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(MetaTrad.IDX)+"', '"+StrSql(MetaTrad.ORIGIN_DB)+"', '"+StrSql(MetaTrad.ORIGIN_TABLE)+"', '"+StrSql(MetaTrad.ORIGIN_ID_0)+"', '"+StrSql("")+"', '"+RDToString(MetaTrad.LAST_UPDATE)+"')"
	End Function

	'OriginalExpression: 'baseIDX+i
	<Extension()>
	Public Function Eval_Static_IDX_K_597206(ByVal Main As RDCompiledProcess) As Object
		return baseIDX+i
	End Function

	'OriginalExpression: 'dmfolder_row.ITA
	<Extension()>
	Public Function Eval_Static_ITA_K_597206(ByVal Main As RDCompiledProcess) As Object
		return dmfolder_row.ITA
	End Function

	'OriginalExpression: 'dmfolder_row.ENG
	<Extension()>
	Public Function Eval_Static_ENG_K_597206(ByVal Main As RDCompiledProcess) As Object
		return dmfolder_row.ENG
	End Function

	'OriginalExpression: 'dmfolder_row.ESP
	<Extension()>
	Public Function Eval_Static_ESP_K_597206(ByVal Main As RDCompiledProcess) As Object
		return dmfolder_row.ESP
	End Function

	'OriginalExpression: 'dmfolder_row.FRA
	<Extension()>
	Public Function Eval_Static_FRA_K_597206(ByVal Main As RDCompiledProcess) As Object
		return dmfolder_row.FRA
	End Function

	'OriginalExpression: 'dmfolder_row.DEU
	<Extension()>
	Public Function Eval_Static_DEU_K_597206(ByVal Main As RDCompiledProcess) As Object
		return dmfolder_row.DEU
	End Function

	'OriginalExpression: '"INSERT INTO TRADS VALUES('"+StrSql(Trad.IDX)+"', '"+StrSql(Trad.ITA)+"', '"+StrSql(Trad.ENG)+"', '"+StrSql(Trad.ESP)+"', '"+StrSql(Trad.FRA)+"', '"+StrSql(Trad.DEU)+"', Null, Null, Null)"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_664064(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO TRADS VALUES('"+StrSql(Trad.IDX)+"', '"+StrSql(Trad.ITA)+"', '"+StrSql(Trad.ENG)+"', '"+StrSql(Trad.ESP)+"', '"+StrSql(Trad.FRA)+"', '"+StrSql(Trad.DEU)+"', Null, Null, Null)"
	End Function

	'OriginalExpression: 'i+baseIDX
	<Extension()>
	Public Function Eval_Static_Set_baseIDX_K_597220(ByVal Main As RDCompiledProcess) As Object
		return i+baseIDX
	End Function

	'OriginalExpression: '""
	<Extension()>
	Public Function Eval_Static_Fields_K_581(ByVal Main As RDCompiledProcess) As Object
		return ""
	End Function

	'OriginalExpression: 'FusionTableKeys
	<Extension()>
	Public Function Eval_Static_InputParam_K_589(ByVal Main As RDCompiledProcess) As Object
		return FusionTableKeys
	End Function

	'OriginalExpression: 'ConnStr_PDM
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_625(ByVal Main As RDCompiledProcess) As Object
		return ConnStr_PDM
	End Function

	'OriginalExpression: 'i+baseIDX
	<Extension()>
	Public Function Eval_Static_Set_TradTable_i_1__IDX_K_631(ByVal Main As RDCompiledProcess) As Object
		return i+baseIDX
	End Function

	'OriginalExpression: '"INSERT INTO TRADS  VALUES('"+StrSql(TradTable(i-1).IDX)+"',  '"+StrSql(TradTable(i-1).ITA)+"',  '"+StrSql(TradTable(i-1).ENG)+"',  '"+StrSql(TradTable(i-1).ESP)+"',  '"+StrSql(TradTable(i-1).FRA)+"',  '"+StrSql(TradTable(i-1).DEU)+"',  Null, Null, Null)"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_664140(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO TRADS  VALUES('"+StrSql(TradTable(i-1).IDX)+"',  '"+StrSql(TradTable(i-1).ITA)+"',  '"+StrSql(TradTable(i-1).ENG)+"',  '"+StrSql(TradTable(i-1).ESP)+"',  '"+StrSql(TradTable(i-1).FRA)+"',  '"+StrSql(TradTable(i-1).DEU)+"',  Null, Null, Null)"
	End Function

	'OriginalExpression: 'i+baseIDX
	<Extension()>
	Public Function Eval_Static_Set_baseIDX_K_636(ByVal Main As RDCompiledProcess) As Object
		return i+baseIDX
	End Function

	'OriginalExpression: '"SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL  WHERE cpID in ('328', '329')  AND cvalValore='"+StrSql(Trad.ITA)+"'  AND cvalTrans1='"+StrSql(Trad.ENG)+"'  AND cvalTrans2='"+StrSql(Trad.FRA)+"'  AND cvalTrans3='"+StrSql(Trad.DEU)+"'  AND cvalTrans4='"+StrSql(Trad.ESP)+"'"
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_640(ByVal Main As RDCompiledProcess) As Object
		return "SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL  WHERE cpID in ('328', '329')  AND cvalValore='"+StrSql(Trad.ITA)+"'  AND cvalTrans1='"+StrSql(Trad.ENG)+"'  AND cvalTrans2='"+StrSql(Trad.FRA)+"'  AND cvalTrans3='"+StrSql(Trad.DEU)+"'  AND cvalTrans4='"+StrSql(Trad.ESP)+"'"
	End Function

	'OriginalExpression: '"DB_PDM"
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_642(ByVal Main As RDCompiledProcess) As Object
		return "DB_PDM"
	End Function

	'OriginalExpression: 'queryFindTags
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_642(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'Count(SupportTableTags)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_697802(ByVal Main As RDCompiledProcess) As Object
		return Count(SupportTableTags)=0
	End Function

	'OriginalExpression: '"SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL  WHERE cpID in ('328', '329')  AND cvalValore"+IIF(Trad.ITA="", " IS NULL ", "='"+StrSql(Trad.ITA)+"' ")+"  AND cvalTrans1"+IIF(Trad.ENG="", " IS NULL ", "='"+StrSql(Trad.ENG)+"' ")+"  AND cvalTrans2"+IIF(Trad.FRA="", " IS NULL ", "='"+StrSql(Trad.FRA)+"' ")+"  AND cvalTrans3"+IIF(Trad.DEU="", " IS NULL ", "='"+StrSql(Trad.DEU)+"' ")+"  AND cvalTrans4"+IIF(Trad.ESP="", " IS NULL ", "='"+StrSql(Trad.ESP)+"'") 
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_697834(ByVal Main As RDCompiledProcess) As Object
		return "SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL  WHERE cpID in ('328', '329')  AND cvalValore"+IIF(Trad.ITA="", " IS NULL ", "='"+StrSql(Trad.ITA)+"' ")+"  AND cvalTrans1"+IIF(Trad.ENG="", " IS NULL ", "='"+StrSql(Trad.ENG)+"' ")+"  AND cvalTrans2"+IIF(Trad.FRA="", " IS NULL ", "='"+StrSql(Trad.FRA)+"' ")+"  AND cvalTrans3"+IIF(Trad.DEU="", " IS NULL ", "='"+StrSql(Trad.DEU)+"' ")+"  AND cvalTrans4"+IIF(Trad.ESP="", " IS NULL ", "='"+StrSql(Trad.ESP)+"'") 
	End Function

	'OriginalExpression: '"DB_PDM"
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_697842(ByVal Main As RDCompiledProcess) As Object
		return "DB_PDM"
	End Function

	'OriginalExpression: 'queryFindTags
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_697842(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags
	End Function

	'OriginalExpression: 'Trad.IDX
	<Extension()>
	Public Function Eval_Static_IDX_K_645(ByVal Main As RDCompiledProcess) As Object
		return Trad.IDX
	End Function

	'OriginalExpression: 'SupportRowTags.ORIGIN_ID_0
	<Extension()>
	Public Function Eval_Static_ORIGIN_ID_0_K_645(ByVal Main As RDCompiledProcess) As Object
		return SupportRowTags.ORIGIN_ID_0
	End Function

	'OriginalExpression: 'SupportRowTags.ORIGIN_ID_1
	<Extension()>
	Public Function Eval_Static_ORIGIN_ID_1_K_645(ByVal Main As RDCompiledProcess) As Object
		return SupportRowTags.ORIGIN_ID_1
	End Function

	'OriginalExpression: 'Now()
	<Extension()>
	Public Function Eval_Static_LAST_UPDATE_K_645(ByVal Main As RDCompiledProcess) As Object
		return Now()
	End Function

	'OriginalExpression: '"INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(MetaTrad.IDX)+"', '"+StrSql(MetaTrad.ORIGIN_DB)+"', '"+StrSql(MetaTrad.ORIGIN_TABLE)+"', '"+StrSql(MetaTrad.ORIGIN_ID_0)+"', '"+StrSql(MetaTrad.ORIGIN_ID_1)+"', '"+RDToString(MetaTrad.LAST_UPDATE)+"')"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_664166(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(MetaTrad.IDX)+"', '"+StrSql(MetaTrad.ORIGIN_DB)+"', '"+StrSql(MetaTrad.ORIGIN_TABLE)+"', '"+StrSql(MetaTrad.ORIGIN_ID_0)+"', '"+StrSql(MetaTrad.ORIGIN_ID_1)+"', '"+RDToString(MetaTrad.LAST_UPDATE)+"')"
	End Function

	'OriginalExpression: 'i+baseIDX
	<Extension()>
	Public Function Eval_Static_Set_TradTable_i_1__IDX_K_678(ByVal Main As RDCompiledProcess) As Object
		return i+baseIDX
	End Function

	'OriginalExpression: '"INSERT INTO TRADS VALUES('"+StrSql(TradTable(i-1).IDX)+"', '"+StrSql(TradTable(i-1).ITA)+"', '"+StrSql(TradTable(i-1).ENG)+"', '"+StrSql(TradTable(i-1).ESP)+"', '"+StrSql(TradTable(i-1).FRA)+"', '"+StrSql(TradTable(i-1).DEU)+"', Null, Null, Null)"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_664192(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO TRADS VALUES('"+StrSql(TradTable(i-1).IDX)+"', '"+StrSql(TradTable(i-1).ITA)+"', '"+StrSql(TradTable(i-1).ENG)+"', '"+StrSql(TradTable(i-1).ESP)+"', '"+StrSql(TradTable(i-1).FRA)+"', '"+StrSql(TradTable(i-1).DEU)+"', Null, Null, Null)"
	End Function

	'OriginalExpression: 'i+baseIDX
	<Extension()>
	Public Function Eval_Static_Set_baseIDX_K_681(ByVal Main As RDCompiledProcess) As Object
		return i+baseIDX
	End Function

	'OriginalExpression: '"SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL  WHERE cpID in ('497', '489', '459', '370', '222', '223', '220', '91')  AND cvalTrans2='"+StrSql(Trad.ITA)+"'  AND cvalTrans3='"+StrSql(Trad.ENG)+"'  AND cvalTrans4='"+StrSql(Trad.FRA)+"'  AND cvalTrans5='"+StrSql(Trad.DEU)+"'" 
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_682(ByVal Main As RDCompiledProcess) As Object
		return "SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL  WHERE cpID in ('497', '489', '459', '370', '222', '223', '220', '91')  AND cvalTrans2='"+StrSql(Trad.ITA)+"'  AND cvalTrans3='"+StrSql(Trad.ENG)+"'  AND cvalTrans4='"+StrSql(Trad.FRA)+"'  AND cvalTrans5='"+StrSql(Trad.DEU)+"'" 
	End Function

	'OriginalExpression: '"DB_PDM"
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_683(ByVal Main As RDCompiledProcess) As Object
		return "DB_PDM"
	End Function

	'OriginalExpression: 'queryFindTags
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_683(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'Count(SupportTableTags)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_697910(ByVal Main As RDCompiledProcess) As Object
		return Count(SupportTableTags)=0
	End Function

	'OriginalExpression: '"SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL  WHERE cpID in ('497', '489', '459', '370', '222', '223', '220', '91')  AND cvalTrans2"+IIF(Trad.ITA<>"", "='"+StrSql(Trad.ITA)+"'", " IS NULL") +"  AND cvalTrans3"+IIF(Trad.ENG<>"", "='"+StrSql(Trad.ENG)+"'", " IS NULL") +"  AND cvalTrans4"+IIF(Trad.FRA<>"", "='"+StrSql(Trad.FRA)+"'", " IS NULL") +"  AND cvalTrans5"+IIF(Trad.DEU<>"", "='"+StrSql(Trad.DEU)+"'", " IS NULL")  
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_697907(ByVal Main As RDCompiledProcess) As Object
		return "SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL  WHERE cpID in ('497', '489', '459', '370', '222', '223', '220', '91')  AND cvalTrans2"+IIF(Trad.ITA<>"", "='"+StrSql(Trad.ITA)+"'", " IS NULL") +"  AND cvalTrans3"+IIF(Trad.ENG<>"", "='"+StrSql(Trad.ENG)+"'", " IS NULL") +"  AND cvalTrans4"+IIF(Trad.FRA<>"", "='"+StrSql(Trad.FRA)+"'", " IS NULL") +"  AND cvalTrans5"+IIF(Trad.DEU<>"", "='"+StrSql(Trad.DEU)+"'", " IS NULL")  
	End Function

	'OriginalExpression: '"DB_PDM"
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_697908(ByVal Main As RDCompiledProcess) As Object
		return "DB_PDM"
	End Function

	'OriginalExpression: 'queryFindTags
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_697908(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags
	End Function

	'OriginalExpression: 'Trad.IDX
	<Extension()>
	Public Function Eval_Static_IDX_K_684(ByVal Main As RDCompiledProcess) As Object
		return Trad.IDX
	End Function

	'OriginalExpression: 'SupportRowTags.ORIGIN_ID_0
	<Extension()>
	Public Function Eval_Static_ORIGIN_ID_0_K_684(ByVal Main As RDCompiledProcess) As Object
		return SupportRowTags.ORIGIN_ID_0
	End Function

	'OriginalExpression: 'SupportRowTags.ORIGIN_ID_1
	<Extension()>
	Public Function Eval_Static_ORIGIN_ID_1_K_684(ByVal Main As RDCompiledProcess) As Object
		return SupportRowTags.ORIGIN_ID_1
	End Function

	'OriginalExpression: 'Now()
	<Extension()>
	Public Function Eval_Static_LAST_UPDATE_K_684(ByVal Main As RDCompiledProcess) As Object
		return Now()
	End Function

	'OriginalExpression: '"INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(MetaTrad.IDX)+"', '"+StrSql(MetaTrad.ORIGIN_DB)+"', '"+StrSql(MetaTrad.ORIGIN_TABLE)+"', '"+StrSql(MetaTrad.ORIGIN_ID_0)+"', '"+StrSql(MetaTrad.ORIGIN_ID_1)+"', '"+RDToString(MetaTrad.LAST_UPDATE)+"')"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_664200(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(MetaTrad.IDX)+"', '"+StrSql(MetaTrad.ORIGIN_DB)+"', '"+StrSql(MetaTrad.ORIGIN_TABLE)+"', '"+StrSql(MetaTrad.ORIGIN_ID_0)+"', '"+StrSql(MetaTrad.ORIGIN_ID_1)+"', '"+RDToString(MetaTrad.LAST_UPDATE)+"')"
	End Function

	'OriginalExpression: 'NewDateTime(1800, 1, 1, 10, 0, 0)
	<Extension()>
	Public Function Eval_Static_Set_LastUpdate_K_596654(ByVal Main As RDCompiledProcess) As Object
		return NewDateTime(1800, 1, 1, 10, 0, 0)
	End Function

	'FOREACH _language IN Languages BYREF
	'OriginalExpression: 'Languages
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_722(ByVal Main As RDCompiledProcess) As Object
		return Languages
	End Function

	'OriginalExpression: 'GS_TradPath+"\language_"+_language+".txt"
	<Extension()>
	Public Function Eval_Static_Set_JSONFile_K_596676(ByVal Main As RDCompiledProcess) As Object
		return GS_TradPath+"\language_"+_language+".txt"
	End Function

	'OriginalExpression: 'ReadTextFile(JSONFile)
	<Extension()>
	Public Function Eval_Static_Set_JSONtext_K_752(ByVal Main As RDCompiledProcess) As Object
		return ReadTextFile(JSONFile)
	End Function

	'OriginalExpression: 'FromJSON(kvTable.GetType,JSONtext, "(HASH)(KEYVALUE)")
	<Extension()>
	Public Function Eval_Static_Set_kvTable_K_753(ByVal Main As RDCompiledProcess) As Object
		return FromJSON(kvTable.GetType,JSONtext, "(HASH)(KEYVALUE)")
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'FileLastWriteDate(JSONFile)>LastUpdate
	<Extension()>
	Public Function Eval_Static_CondExp1_K_596713(ByVal Main As RDCompiledProcess) As Object
		return FileLastWriteDate(JSONFile)>LastUpdate
	End Function

	'OriginalExpression: 'FileLastWriteDate(JSONFile)
	<Extension()>
	Public Function Eval_Static_Set_LastUpdate_K_596753(ByVal Main As RDCompiledProcess) As Object
		return FileLastWriteDate(JSONFile)
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: '_language="ITA"
	<Extension()>
	Public Function Eval_Static_CondExp1_K_756(ByVal Main As RDCompiledProcess) As Object
		return _language="ITA"
	End Function

	'OriginalExpression: 'baseIDX+i
	<Extension()>
	Public Function Eval_Static_IDX_K_763(ByVal Main As RDCompiledProcess) As Object
		return baseIDX+i
	End Function

	'OriginalExpression: 'kvRow.key
	<Extension()>
	Public Function Eval_Static_ORIGIN_ID_0_K_763(ByVal Main As RDCompiledProcess) As Object
		return kvRow.key
	End Function

	'OriginalExpression: 'baseIDX+i
	<Extension()>
	Public Function Eval_Static_IDX_K_755(ByVal Main As RDCompiledProcess) As Object
		return baseIDX+i
	End Function

	'OriginalExpression: 'iif(_language="ITA",kvRow.value,Trad.ITA)
	<Extension()>
	Public Function Eval_Static_ITA_K_755(ByVal Main As RDCompiledProcess) As Object
		return iif(_language="ITA",kvRow.value,Trad.ITA)
	End Function

	'OriginalExpression: '"INSERT INTO TRADS VALUES('"+StrSql(Trad.IDX)+"', '"+StrSql(Trad.ITA)+"', Null, Null, Null, Null, Null, Null, Null)"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_664220(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO TRADS VALUES('"+StrSql(Trad.IDX)+"', '"+StrSql(Trad.ITA)+"', Null, Null, Null, Null, Null, Null, Null)"
	End Function

	'OriginalExpression: 'TradTable(i-1).IDX
	<Extension()>
	Public Function Eval_Static_IDX_K_596640(ByVal Main As RDCompiledProcess) As Object
		return TradTable(i-1).IDX
	End Function

	'OriginalExpression: 'TradTable(i-1).ITA
	<Extension()>
	Public Function Eval_Static_ITA_K_596640(ByVal Main As RDCompiledProcess) As Object
		return TradTable(i-1).ITA
	End Function

	'OriginalExpression: 'iif(_language="ENG",kvRow.value,TradTable(i-1).ENG)
	<Extension()>
	Public Function Eval_Static_ENG_K_596640(ByVal Main As RDCompiledProcess) As Object
		return iif(_language="ENG",kvRow.value,TradTable(i-1).ENG)
	End Function

	'OriginalExpression: 'iif(_language="ESP",kvRow.value,TradTable(i-1).ESP)
	<Extension()>
	Public Function Eval_Static_ESP_K_596640(ByVal Main As RDCompiledProcess) As Object
		return iif(_language="ESP",kvRow.value,TradTable(i-1).ESP)
	End Function

	'OriginalExpression: 'iif(_language="FRA",kvRow.value,TradTable(i-1).FRA)
	<Extension()>
	Public Function Eval_Static_FRA_K_596640(ByVal Main As RDCompiledProcess) As Object
		return iif(_language="FRA",kvRow.value,TradTable(i-1).FRA)
	End Function

	'OriginalExpression: 'iif(_language="DEU",kvRow.value,TradTable(i-1).DEU)
	<Extension()>
	Public Function Eval_Static_DEU_K_596640(ByVal Main As RDCompiledProcess) As Object
		return iif(_language="DEU",kvRow.value,TradTable(i-1).DEU)
	End Function

	'OriginalExpression: 'Trad
	<Extension()>
	Public Function Eval_Static_Set_TradTable_i_1__K_663069(ByVal Main As RDCompiledProcess) As Object
		return Trad
	End Function

	'OriginalExpression: '"UPDATE TRADS  SET ENG='"+StrSql(Trad.ENG)+"',      ESP='"+StrSql(Trad.ESP)+"',      FRA='"+StrSql(Trad.FRA)+"',      DEU='"+StrSql(Trad.DEU)+"'  WHERE IDX='"+StrSql(Trad.IDX)+"'" 
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_664240(ByVal Main As RDCompiledProcess) As Object
		return "UPDATE TRADS  SET ENG='"+StrSql(Trad.ENG)+"',      ESP='"+StrSql(Trad.ESP)+"',      FRA='"+StrSql(Trad.FRA)+"',      DEU='"+StrSql(Trad.DEU)+"'  WHERE IDX='"+StrSql(Trad.IDX)+"'" 
	End Function

	'OriginalExpression: 'MetaTradTable(j-1).IDX
	<Extension()>
	Public Function Eval_Static_IDX_K_596846(ByVal Main As RDCompiledProcess) As Object
		return MetaTradTable(j-1).IDX
	End Function

	'OriginalExpression: 'MetaTradTable(j-1).ORIGIN_DB
	<Extension()>
	Public Function Eval_Static_ORIGIN_DB_K_596846(ByVal Main As RDCompiledProcess) As Object
		return MetaTradTable(j-1).ORIGIN_DB
	End Function

	'OriginalExpression: 'MetaTradTable(j-1).ORIGIN_TABLE
	<Extension()>
	Public Function Eval_Static_ORIGIN_TABLE_K_596846(ByVal Main As RDCompiledProcess) As Object
		return MetaTradTable(j-1).ORIGIN_TABLE
	End Function

	'OriginalExpression: 'MetaTradTable(j-1).ORIGIN_ID_0
	<Extension()>
	Public Function Eval_Static_ORIGIN_ID_0_K_596846(ByVal Main As RDCompiledProcess) As Object
		return MetaTradTable(j-1).ORIGIN_ID_0
	End Function

	'OriginalExpression: 'LastUpdate
	<Extension()>
	Public Function Eval_Static_LAST_UPDATE_K_596846(ByVal Main As RDCompiledProcess) As Object
		return LastUpdate
	End Function

	'OriginalExpression: 'MetaTrad
	<Extension()>
	Public Function Eval_Static_Set_MetaTradTable_j_1__K_663107(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad
	End Function

	'OriginalExpression: '"INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(MetaTrad.IDX)+"', '"+StrSql(MetaTrad.ORIGIN_DB)+"', '"+StrSql(MetaTrad.ORIGIN_TABLE)+"', '"+StrSql(MetaTrad.ORIGIN_ID_0)+"', '"+StrSql("")+"', '"+RDToString(MetaTrad.LAST_UPDATE)+"')"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_664254(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(MetaTrad.IDX)+"', '"+StrSql(MetaTrad.ORIGIN_DB)+"', '"+StrSql(MetaTrad.ORIGIN_TABLE)+"', '"+StrSql(MetaTrad.ORIGIN_ID_0)+"', '"+StrSql("")+"', '"+RDToString(MetaTrad.LAST_UPDATE)+"')"
	End Function

	'OriginalExpression: 'baseIDX+i
	<Extension()>
	Public Function Eval_Static_Set_baseIDX_K_778(ByVal Main As RDCompiledProcess) As Object
		return baseIDX+i
	End Function

	'OriginalExpression: 'StrReplace(ReadTextFile(CRM_TradPath), "-->", "--> <TRANSLATED_STRINGS>")+"</TRANSLATED_STRINGS>"
	<Extension()>
	Public Function Eval_Static_Set_xml_crm_K_784(ByVal Main As RDCompiledProcess) As Object
		return StrReplace(ReadTextFile(CRM_TradPath), "-->", "--> <TRANSLATED_STRINGS>")+"</TRANSLATED_STRINGS>"
	End Function

	'OriginalExpression: 'FileLastWriteDate(CRM_TradPath)
	<Extension()>
	Public Function Eval_Static_Set_LastUpdateCRM_K_686784(ByVal Main As RDCompiledProcess) As Object
		return FileLastWriteDate(CRM_TradPath)
	End Function

	'OriginalExpression: 'XmlChildren(xml_crm, "TRANSLATED_STRINGS")
	<Extension()>
	Public Function Eval_Static_Set_array_xml_K_795(ByVal Main As RDCompiledProcess) As Object
		return XmlChildren(xml_crm, "TRANSLATED_STRINGS")
	End Function

	'OriginalExpression: 'StrStartWith(tag, "<Orig_str")
	<Extension()>
	Public Function Eval_Static_NODE_Orig_str_K_807(ByVal Main As RDCompiledProcess) As Object
		return StrStartWith(tag, "<Orig_str")
	End Function

	'OriginalExpression: 'StrStartWith(tag, "<ITA")
	<Extension()>
	Public Function Eval_Static_NODE_ITA_K_807(ByVal Main As RDCompiledProcess) As Object
		return StrStartWith(tag, "<ITA")
	End Function

	'OriginalExpression: 'StrStartWith(tag, "<ENG")
	<Extension()>
	Public Function Eval_Static_NODE_ENG_K_807(ByVal Main As RDCompiledProcess) As Object
		return StrStartWith(tag, "<ENG")
	End Function

	'OriginalExpression: 'StrStartWith(tag, "<ESP")
	<Extension()>
	Public Function Eval_Static_NODE_ESP_K_807(ByVal Main As RDCompiledProcess) As Object
		return StrStartWith(tag, "<ESP")
	End Function

	'OriginalExpression: 'StrStartWith(tag, "<FRA")
	<Extension()>
	Public Function Eval_Static_NODE_FRA_K_807(ByVal Main As RDCompiledProcess) As Object
		return StrStartWith(tag, "<FRA")
	End Function

	'OriginalExpression: 'StrStartWith(tag, "<DEU")
	<Extension()>
	Public Function Eval_Static_NODE_DEU_K_807(ByVal Main As RDCompiledProcess) As Object
		return StrStartWith(tag, "<DEU")
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'Orig_str
	<Extension()>
	Public Function Eval_Static_CondExp1_K_821(ByVal Main As RDCompiledProcess) As Object
		return Orig_str
	End Function

	'OriginalExpression: 'XmlText(tag)
	<Extension()>
	Public Function Eval_Static_Set_value_K_802(ByVal Main As RDCompiledProcess) As Object
		return XmlText(tag)
	End Function

	'OriginalExpression: 'k+1
	<Extension()>
	Public Function Eval_Static_Set_k_K_863(ByVal Main As RDCompiledProcess) As Object
		return k+1
	End Function

	'OriginalExpression: 'k+baseIDX
	<Extension()>
	Public Function Eval_Static_IDX_K_876(ByVal Main As RDCompiledProcess) As Object
		return k+baseIDX
	End Function

	'OriginalExpression: 'value
	<Extension()>
	Public Function Eval_Static_ORIGIN_ID_0_K_876(ByVal Main As RDCompiledProcess) As Object
		return value
	End Function

	'OriginalExpression: 'LastUpdateCRM
	<Extension()>
	Public Function Eval_Static_LAST_UPDATE_K_876(ByVal Main As RDCompiledProcess) As Object
		return LastUpdateCRM
	End Function

	'OriginalExpression: 'baseIDX+k
	<Extension()>
	Public Function Eval_Static_IDX_K_887(ByVal Main As RDCompiledProcess) As Object
		return baseIDX+k
	End Function

	'OriginalExpression: '"INSERT INTO TRADS VALUES('"+StrSql(Trad.IDX)+"', '', '', '', '', '', Null, Null, Null)"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_669674(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO TRADS VALUES('"+StrSql(Trad.IDX)+"', '', '', '', '', '', Null, Null, Null)"
	End Function

	'OriginalExpression: '"INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(MetaTrad.IDX)+"', '"+StrSql(MetaTrad.ORIGIN_DB)+"', '"+StrSql(MetaTrad.ORIGIN_TABLE)+"', '"+StrSql(MetaTrad.ORIGIN_ID_0)+"', '"+StrSql("")+"', '"+RDToString(MetaTrad.LAST_UPDATE)+"')"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_669712(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1, LAST_UPDATE) VALUES ('"+StrSql(MetaTrad.IDX)+"', '"+StrSql(MetaTrad.ORIGIN_DB)+"', '"+StrSql(MetaTrad.ORIGIN_TABLE)+"', '"+StrSql(MetaTrad.ORIGIN_ID_0)+"', '"+StrSql("")+"', '"+RDToString(MetaTrad.LAST_UPDATE)+"')"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ITA
	<Extension()>
	Public Function Eval_Static_CondExp1_K_918(ByVal Main As RDCompiledProcess) As Object
		return ITA
	End Function

	'OriginalExpression: 'Trad.IDX
	<Extension()>
	Public Function Eval_Static_IDX_K_989(ByVal Main As RDCompiledProcess) As Object
		return Trad.IDX
	End Function

	'OriginalExpression: 'XmlText(tag)
	<Extension()>
	Public Function Eval_Static_ITA_K_989(ByVal Main As RDCompiledProcess) As Object
		return XmlText(tag)
	End Function

	'OriginalExpression: 'Trad.ENG
	<Extension()>
	Public Function Eval_Static_ENG_K_989(ByVal Main As RDCompiledProcess) As Object
		return Trad.ENG
	End Function

	'OriginalExpression: 'Trad.ESP
	<Extension()>
	Public Function Eval_Static_ESP_K_989(ByVal Main As RDCompiledProcess) As Object
		return Trad.ESP
	End Function

	'OriginalExpression: 'Trad.FRA
	<Extension()>
	Public Function Eval_Static_FRA_K_989(ByVal Main As RDCompiledProcess) As Object
		return Trad.FRA
	End Function

	'OriginalExpression: 'Trad.DEU
	<Extension()>
	Public Function Eval_Static_DEU_K_989(ByVal Main As RDCompiledProcess) As Object
		return Trad.DEU
	End Function

	'OriginalExpression: 'Trad
	<Extension()>
	Public Function Eval_Static_Set_TradTable_k_1__K_663145(ByVal Main As RDCompiledProcess) As Object
		return Trad
	End Function

	'OriginalExpression: '"UPDATE TRADS  SET ITA='"+StrSql(XmlText(tag))+"' WHERE IDX="+StrSql(baseIDX+k) 
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_669732(ByVal Main As RDCompiledProcess) As Object
		return "UPDATE TRADS  SET ITA='"+StrSql(XmlText(tag))+"' WHERE IDX="+StrSql(baseIDX+k) 
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ENG
	<Extension()>
	Public Function Eval_Static_CondExp1_K_1086(ByVal Main As RDCompiledProcess) As Object
		return ENG
	End Function

	'OriginalExpression: 'Trad.IDX
	<Extension()>
	Public Function Eval_Static_IDX_K_1085(ByVal Main As RDCompiledProcess) As Object
		return Trad.IDX
	End Function

	'OriginalExpression: 'Trad.ITA
	<Extension()>
	Public Function Eval_Static_ITA_K_1085(ByVal Main As RDCompiledProcess) As Object
		return Trad.ITA
	End Function

	'OriginalExpression: 'XmlText(tag)
	<Extension()>
	Public Function Eval_Static_ENG_K_1085(ByVal Main As RDCompiledProcess) As Object
		return XmlText(tag)
	End Function

	'OriginalExpression: 'Trad.ESP
	<Extension()>
	Public Function Eval_Static_ESP_K_1085(ByVal Main As RDCompiledProcess) As Object
		return Trad.ESP
	End Function

	'OriginalExpression: 'Trad.FRA
	<Extension()>
	Public Function Eval_Static_FRA_K_1085(ByVal Main As RDCompiledProcess) As Object
		return Trad.FRA
	End Function

	'OriginalExpression: 'Trad.DEU
	<Extension()>
	Public Function Eval_Static_DEU_K_1085(ByVal Main As RDCompiledProcess) As Object
		return Trad.DEU
	End Function

	'OriginalExpression: 'Trad
	<Extension()>
	Public Function Eval_Static_Set_TradTable_k_1__K_663183(ByVal Main As RDCompiledProcess) As Object
		return Trad
	End Function

	'OriginalExpression: '"UPDATE TRADS  SET ENG='"+StrSql(XmlText(tag))+"' WHERE IDX="+StrSql(baseIDX+k)
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_669758(ByVal Main As RDCompiledProcess) As Object
		return "UPDATE TRADS  SET ENG='"+StrSql(XmlText(tag))+"' WHERE IDX="+StrSql(baseIDX+k)
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ESP
	<Extension()>
	Public Function Eval_Static_CondExp1_K_1117(ByVal Main As RDCompiledProcess) As Object
		return ESP
	End Function

	'OriginalExpression: 'Trad.IDX
	<Extension()>
	Public Function Eval_Static_IDX_K_1116(ByVal Main As RDCompiledProcess) As Object
		return Trad.IDX
	End Function

	'OriginalExpression: 'Trad.ITA
	<Extension()>
	Public Function Eval_Static_ITA_K_1116(ByVal Main As RDCompiledProcess) As Object
		return Trad.ITA
	End Function

	'OriginalExpression: 'Trad.ENG
	<Extension()>
	Public Function Eval_Static_ENG_K_1116(ByVal Main As RDCompiledProcess) As Object
		return Trad.ENG
	End Function

	'OriginalExpression: 'XmlText(tag)
	<Extension()>
	Public Function Eval_Static_ESP_K_1116(ByVal Main As RDCompiledProcess) As Object
		return XmlText(tag)
	End Function

	'OriginalExpression: 'Trad.FRA
	<Extension()>
	Public Function Eval_Static_FRA_K_1116(ByVal Main As RDCompiledProcess) As Object
		return Trad.FRA
	End Function

	'OriginalExpression: 'Trad.DEU
	<Extension()>
	Public Function Eval_Static_DEU_K_1116(ByVal Main As RDCompiledProcess) As Object
		return Trad.DEU
	End Function

	'OriginalExpression: 'Trad
	<Extension()>
	Public Function Eval_Static_Set_TradTable_k_1__K_663203(ByVal Main As RDCompiledProcess) As Object
		return Trad
	End Function

	'OriginalExpression: '"UPDATE TRADS  SET ESP='"+StrSql(XmlText(tag))+"' WHERE IDX="+StrSql(baseIDX+k)
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_669796(ByVal Main As RDCompiledProcess) As Object
		return "UPDATE TRADS  SET ESP='"+StrSql(XmlText(tag))+"' WHERE IDX="+StrSql(baseIDX+k)
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'FRA
	<Extension()>
	Public Function Eval_Static_CondExp1_K_1148(ByVal Main As RDCompiledProcess) As Object
		return FRA
	End Function

	'OriginalExpression: 'Trad.IDX
	<Extension()>
	Public Function Eval_Static_IDX_K_1147(ByVal Main As RDCompiledProcess) As Object
		return Trad.IDX
	End Function

	'OriginalExpression: 'Trad.ITA
	<Extension()>
	Public Function Eval_Static_ITA_K_1147(ByVal Main As RDCompiledProcess) As Object
		return Trad.ITA
	End Function

	'OriginalExpression: 'Trad.ENG
	<Extension()>
	Public Function Eval_Static_ENG_K_1147(ByVal Main As RDCompiledProcess) As Object
		return Trad.ENG
	End Function

	'OriginalExpression: 'Trad.ESP
	<Extension()>
	Public Function Eval_Static_ESP_K_1147(ByVal Main As RDCompiledProcess) As Object
		return Trad.ESP
	End Function

	'OriginalExpression: 'XmlText(tag)
	<Extension()>
	Public Function Eval_Static_FRA_K_1147(ByVal Main As RDCompiledProcess) As Object
		return XmlText(tag)
	End Function

	'OriginalExpression: 'Trad.DEU
	<Extension()>
	Public Function Eval_Static_DEU_K_1147(ByVal Main As RDCompiledProcess) As Object
		return Trad.DEU
	End Function

	'OriginalExpression: 'Trad
	<Extension()>
	Public Function Eval_Static_Set_TradTable_k_1__K_663223(ByVal Main As RDCompiledProcess) As Object
		return Trad
	End Function

	'OriginalExpression: '"UPDATE TRADS  SET FRA='"+StrSql(XmlText(tag))+"' WHERE IDX="+StrSql(baseIDX+k) 
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_669822(ByVal Main As RDCompiledProcess) As Object
		return "UPDATE TRADS  SET FRA='"+StrSql(XmlText(tag))+"' WHERE IDX="+StrSql(baseIDX+k) 
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'DEU
	<Extension()>
	Public Function Eval_Static_CondExp1_K_1179(ByVal Main As RDCompiledProcess) As Object
		return DEU
	End Function

	'OriginalExpression: 'Trad.IDX
	<Extension()>
	Public Function Eval_Static_IDX_K_1178(ByVal Main As RDCompiledProcess) As Object
		return Trad.IDX
	End Function

	'OriginalExpression: 'Trad.ITA
	<Extension()>
	Public Function Eval_Static_ITA_K_1178(ByVal Main As RDCompiledProcess) As Object
		return Trad.ITA
	End Function

	'OriginalExpression: 'Trad.ENG
	<Extension()>
	Public Function Eval_Static_ENG_K_1178(ByVal Main As RDCompiledProcess) As Object
		return Trad.ENG
	End Function

	'OriginalExpression: 'Trad.ESP
	<Extension()>
	Public Function Eval_Static_ESP_K_1178(ByVal Main As RDCompiledProcess) As Object
		return Trad.ESP
	End Function

	'OriginalExpression: 'Trad.FRA
	<Extension()>
	Public Function Eval_Static_FRA_K_1178(ByVal Main As RDCompiledProcess) As Object
		return Trad.FRA
	End Function

	'OriginalExpression: 'XmlText(tag)
	<Extension()>
	Public Function Eval_Static_DEU_K_1178(ByVal Main As RDCompiledProcess) As Object
		return XmlText(tag)
	End Function

	'OriginalExpression: 'Trad
	<Extension()>
	Public Function Eval_Static_Set_TradTable_k_1__K_663243(ByVal Main As RDCompiledProcess) As Object
		return Trad
	End Function

	'OriginalExpression: '"UPDATE TRADS  SET DEU='"+StrSql(XmlText(tag))+"' WHERE IDX="+StrSql(baseIDX+k) 
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_669848(ByVal Main As RDCompiledProcess) As Object
		return "UPDATE TRADS  SET DEU='"+StrSql(XmlText(tag))+"' WHERE IDX="+StrSql(baseIDX+k) 
	End Function



End Module
