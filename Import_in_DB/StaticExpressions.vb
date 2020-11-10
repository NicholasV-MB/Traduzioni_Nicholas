Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.BasicFunctionsProxy

Module StaticExpressions

    'This placeholder is for static expression table
	'FOREACH _language IN Languages BYREF
	'OriginalExpression: 'Languages
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_317(ByVal Main As RDCompiledProcess) As Object
		return Languages
	End Function

	'OriginalExpression: 'afterSelect + _Param.Input(4)+_language + " AS "+_language 
	<Extension()>
	Public Function Eval_Static_Set_afterSelect_K_321(ByVal Main As RDCompiledProcess) As Object
		return afterSelect + _Param.Input(4)+_language + " AS "+_language 
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

	'Condition for group IFTHENELSE
	'OriginalExpression: '_Param.Input(1) ="dm_folder_001"
	<Extension()>
	Public Function Eval_Static_CondExp1_K_554(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input(1) ="dm_folder_001"
	End Function

	'OriginalExpression: '"SELECT DISTINCT "+afterSelect+" FROM "+_Param.Input(1)  + " WHERE DMTYPE='C' " 
	<Extension()>
	Public Function Eval_Static_Set_queryTrads_K_552(ByVal Main As RDCompiledProcess) As Object
		return "SELECT DISTINCT "+afterSelect+" FROM "+_Param.Input(1)  + " WHERE DMTYPE='C' " 
	End Function

	'OriginalExpression: '"SELECT DISTINCT "+afterSelect+" FROM "+_Param.Input(1)  
	<Extension()>
	Public Function Eval_Static_Set_queryTrads_K_76(ByVal Main As RDCompiledProcess) As Object
		return "SELECT DISTINCT "+afterSelect+" FROM "+_Param.Input(1)  
	End Function

	'OriginalExpression: '""
	<Extension()>
	Public Function Eval_Static_Set_afterSelect_K_355(ByVal Main As RDCompiledProcess) As Object
		return ""
	End Function

	'OriginalExpression: '"DB_"+_Param.Input(0)
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_300(ByVal Main As RDCompiledProcess) As Object
		return "DB_"+_Param.Input(0)
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

	'OriginalExpression: 'TradTable
	<Extension()>
	Public Function Eval_Static_ListOfRows_K_341(ByVal Main As RDCompiledProcess) As Object
		return TradTable
	End Function

	'OriginalExpression: 'i+baseIDX
	<Extension()>
	Public Function Eval_Static_Set_baseIDX_K_358(ByVal Main As RDCompiledProcess) As Object
		return i+baseIDX
	End Function

	'OriginalExpression: '"SELECT DISTINCT "+_Param.Input(2) + " AS ORIGIN_ID_0" 
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_361(ByVal Main As RDCompiledProcess) As Object
		return "SELECT DISTINCT "+_Param.Input(2) + " AS ORIGIN_ID_0" 
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(_Param.Input(3))=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_362(ByVal Main As RDCompiledProcess) As Object
		return StrLength(_Param.Input(3))=0
	End Function

	'OriginalExpression: 'queryFindTags + ", "+_Param.Input(3) + " AS ORIGIN_ID_1"
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_370(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags + ", "+_Param.Input(3) + " AS ORIGIN_ID_1"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(Trad.ITA)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_426(ByVal Main As RDCompiledProcess) As Object
		return StrLength(Trad.ITA)=0
	End Function

	'OriginalExpression: '_Param.Input(4) +"ITA IS NULL"
	<Extension()>
	Public Function Eval_Static_Set_condITA_K_435(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input(4) +"ITA IS NULL"
	End Function

	'OriginalExpression: '_Param.Input(4)+"ITA='"+StrSqlWC(Trad.ITA)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condITA_K_437(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input(4)+"ITA='"+StrSqlWC(Trad.ITA)+"'"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(Trad.ENG)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_467(ByVal Main As RDCompiledProcess) As Object
		return StrLength(Trad.ENG)=0
	End Function

	'OriginalExpression: '_Param.Input(4) +"ENG IS NULL"
	<Extension()>
	Public Function Eval_Static_Set_condENG_K_463(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input(4) +"ENG IS NULL"
	End Function

	'OriginalExpression: '_Param.Input(4)+"ENG='"+StrSqlWC(Trad.ENG)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condENg_K_465(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input(4)+"ENG='"+StrSqlWC(Trad.ENG)+"'"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(Trad.ESP)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_489(ByVal Main As RDCompiledProcess) As Object
		return StrLength(Trad.ESP)=0
	End Function

	'OriginalExpression: '_Param.Input(4) +"ESP IS NULL"
	<Extension()>
	Public Function Eval_Static_Set_condESP_K_485(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input(4) +"ESP IS NULL"
	End Function

	'OriginalExpression: '_Param.Input(4)+"ESP='"+StrSqlWC(Trad.ESP)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condESP_K_487(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input(4)+"ESP='"+StrSqlWC(Trad.ESP)+"'"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(Trad.FRA)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_505(ByVal Main As RDCompiledProcess) As Object
		return StrLength(Trad.FRA)=0
	End Function

	'OriginalExpression: '_Param.Input(4) +"FRA IS NULL"
	<Extension()>
	Public Function Eval_Static_Set_condFRA_K_501(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input(4) +"FRA IS NULL"
	End Function

	'OriginalExpression: '_Param.Input(4)+"FRA='"+StrSqlWC(Trad.FRA)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condFRA_K_503(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input(4)+"FRA='"+StrSqlWC(Trad.FRA)+"'"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(Trad.DEU)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_523(ByVal Main As RDCompiledProcess) As Object
		return StrLength(Trad.DEU)=0
	End Function

	'OriginalExpression: '_Param.Input(4) +"DEU IS NULL"
	<Extension()>
	Public Function Eval_Static_Set_condDEU_K_519(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input(4) +"DEU IS NULL"
	End Function

	'OriginalExpression: '_Param.Input(4)+"DEU='"+StrSqlWC(Trad.DEU)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condDEU_K_521(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input(4)+"DEU='"+StrSqlWC(Trad.DEU)+"'"
	End Function

	'OriginalExpression: 'queryFindTags + " FROM "+_Param.Input(1) + " WHERE "+condITA+" AND "+condENG+" AND "+condESP+" AND "+condFRA+" AND "+condDEU
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_372(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags + " FROM "+_Param.Input(1) + " WHERE "+condITA+" AND "+condENG+" AND "+condESP+" AND "+condFRA+" AND "+condDEU
	End Function

	'OriginalExpression: '"DB_"+_Param.Input(0)
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_374(ByVal Main As RDCompiledProcess) As Object
		return "DB_"+_Param.Input(0)
	End Function

	'OriginalExpression: 'queryFindTags
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_374(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags
	End Function

	'OriginalExpression: '"INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1) VALUES ("+Trad.IDX+", '"+_Param.Input(0)+"', '"+_Param.Input(1)+"', '"+SupportRowTags.ORIGIN_ID_0+"', '"+SupportRowTags.ORIGIN_ID_1+"')"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_700(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1) VALUES ("+Trad.IDX+", '"+_Param.Input(0)+"', '"+_Param.Input(1)+"', '"+SupportRowTags.ORIGIN_ID_0+"', '"+SupportRowTags.ORIGIN_ID_1+"')"
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

	'OriginalExpression: 'TradTable
	<Extension()>
	Public Function Eval_Static_ListOfRows_K_634(ByVal Main As RDCompiledProcess) As Object
		return TradTable
	End Function

	'OriginalExpression: 'i+baseIDX
	<Extension()>
	Public Function Eval_Static_Set_baseIDX_K_636(ByVal Main As RDCompiledProcess) As Object
		return i+baseIDX
	End Function

	'OriginalExpression: '"SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL WHERE cpID in ('328', '329' ) AND cvalValore='"+StrSqlWC(Trad.ITA)+"' AND cvalTrans1='"+StrSqlWC(Trad.ENG)+"' AND cvalTrans2='"+StrSqlWC(Trad.FRA)+"' AND cvalTrans3='"+StrSqlWC(Trad.DEU)+"' AND cvalTrans4='"+StrSqlWC(Trad.ESP)+"'"
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_640(ByVal Main As RDCompiledProcess) As Object
		return "SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL WHERE cpID in ('328', '329' ) AND cvalValore='"+StrSqlWC(Trad.ITA)+"' AND cvalTrans1='"+StrSqlWC(Trad.ENG)+"' AND cvalTrans2='"+StrSqlWC(Trad.FRA)+"' AND cvalTrans3='"+StrSqlWC(Trad.DEU)+"' AND cvalTrans4='"+StrSqlWC(Trad.ESP)+"'"
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

	'OriginalExpression: 'MetaTradTable
	<Extension()>
	Public Function Eval_Static_ListOfRows_K_648(ByVal Main As RDCompiledProcess) As Object
		return MetaTradTable
	End Function

	'OriginalExpression: 'i+baseIDX
	<Extension()>
	Public Function Eval_Static_Set_TradTable_i_1__IDX_K_678(ByVal Main As RDCompiledProcess) As Object
		return i+baseIDX
	End Function

	'OriginalExpression: 'TradTable
	<Extension()>
	Public Function Eval_Static_ListOfRows_K_680(ByVal Main As RDCompiledProcess) As Object
		return TradTable
	End Function

	'OriginalExpression: 'i+baseIDX
	<Extension()>
	Public Function Eval_Static_Set_baseIDX_K_681(ByVal Main As RDCompiledProcess) As Object
		return i+baseIDX
	End Function

	'OriginalExpression: '"SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL WHERE cpID in ('497', '489', '459', '370', '222', '223', '220', '91') AND cvalTrans2='"+StrSqlWC(Trad.ITA)+"' AND cvalTrans3='"+StrSqlWC(Trad.ENG)+"' AND cvalTrans4='"+StrSqlWC(Trad.FRA)+"' AND cvalTrans5='"+StrSqlWC(Trad.DEU)+"'"
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_682(ByVal Main As RDCompiledProcess) As Object
		return "SELECT cvalID ORIGIN_ID_0, cpID AS ORIGIN_ID_1 FROM CODVAL WHERE cpID in ('497', '489', '459', '370', '222', '223', '220', '91') AND cvalTrans2='"+StrSqlWC(Trad.ITA)+"' AND cvalTrans3='"+StrSqlWC(Trad.ENG)+"' AND cvalTrans4='"+StrSqlWC(Trad.FRA)+"' AND cvalTrans5='"+StrSqlWC(Trad.DEU)+"'"
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

	'OriginalExpression: 'MetaTradTable
	<Extension()>
	Public Function Eval_Static_ListOfRows_K_686(ByVal Main As RDCompiledProcess) As Object
		return MetaTradTable
	End Function



End Module
