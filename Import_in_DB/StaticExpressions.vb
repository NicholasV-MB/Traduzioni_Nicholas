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

	'Condition for group IFTHENELSE
	'OriginalExpression: '_Param.Input.TableName="dm_folder_001"
	<Extension()>
	Public Function Eval_Static_CondExp1_K_554(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.TableName="dm_folder_001"
	End Function

	'OriginalExpression: '"SELECT DISTINCT "+afterSelect+" FROM "+_Param.Input.TableName+ " WHERE DMTYPE='C' AND DMDESCRI_ITA<>'PROJECT' AND DMDESCRI_ITA<>'COMPANY' " 
	<Extension()>
	Public Function Eval_Static_Set_queryTrads_K_552(ByVal Main As RDCompiledProcess) As Object
		return "SELECT DISTINCT "+afterSelect+" FROM "+_Param.Input.TableName+ " WHERE DMTYPE='C' AND DMDESCRI_ITA<>'PROJECT' AND DMDESCRI_ITA<>'COMPANY' " 
	End Function

	'OriginalExpression: '"SELECT DISTINCT "+afterSelect+" FROM "+_Param.Input.TableName
	<Extension()>
	Public Function Eval_Static_Set_queryTrads_K_76(ByVal Main As RDCompiledProcess) As Object
		return "SELECT DISTINCT "+afterSelect+" FROM "+_Param.Input.TableName
	End Function

	'OriginalExpression: '""
	<Extension()>
	Public Function Eval_Static_Set_afterSelect_K_355(ByVal Main As RDCompiledProcess) As Object
		return ""
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

	'OriginalExpression: 'ConnStr_LOCAL
	<Extension()>
	Public Function Eval_Static_ConnectionName_K_341(ByVal Main As RDCompiledProcess) As Object
		return ConnStr_LOCAL
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

	'OriginalExpression: '"SELECT DISTINCT "+_Param.Input.ID+ " AS ORIGIN_ID_0" 
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_361(ByVal Main As RDCompiledProcess) As Object
		return "SELECT DISTINCT "+_Param.Input.ID+ " AS ORIGIN_ID_0" 
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'StrLength(_Param.Input.ID2)=0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_362(ByVal Main As RDCompiledProcess) As Object
		return StrLength(_Param.Input.ID2)=0
	End Function

	'OriginalExpression: 'queryFindTags + ", "+_Param.Input.ID2+ " AS ORIGIN_ID_1"
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_370(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags + ", "+_Param.Input.ID2+ " AS ORIGIN_ID_1"
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

	'OriginalExpression: '_Param.Input.Fields+"ITA='"+StrSqlWC(Trad.ITA)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condITA_K_437(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"ITA='"+StrSqlWC(Trad.ITA)+"'"
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

	'OriginalExpression: '_Param.Input.Fields+"ENG='"+StrSqlWC(Trad.ENG)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condENg_K_465(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"ENG='"+StrSqlWC(Trad.ENG)+"'"
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

	'OriginalExpression: '_Param.Input.Fields+"ESP='"+StrSqlWC(Trad.ESP)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condESP_K_487(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"ESP='"+StrSqlWC(Trad.ESP)+"'"
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

	'OriginalExpression: '_Param.Input.Fields+"FRA='"+StrSqlWC(Trad.FRA)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condFRA_K_503(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"FRA='"+StrSqlWC(Trad.FRA)+"'"
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

	'OriginalExpression: '_Param.Input.Fields+"DEU='"+StrSqlWC(Trad.DEU)+"'"
	<Extension()>
	Public Function Eval_Static_Set_condDEU_K_521(ByVal Main As RDCompiledProcess) As Object
		return _Param.Input.Fields+"DEU='"+StrSqlWC(Trad.DEU)+"'"
	End Function

	'OriginalExpression: 'queryFindTags + " FROM "+_Param.Input.TableName + " WHERE "+condITA+" AND "+condENG+" AND "+condESP+" AND "+condFRA+" AND "+condDEU
	<Extension()>
	Public Function Eval_Static_Set_queryFindTags_K_372(ByVal Main As RDCompiledProcess) As Object
		return queryFindTags + " FROM "+_Param.Input.TableName + " WHERE "+condITA+" AND "+condENG+" AND "+condESP+" AND "+condFRA+" AND "+condDEU
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

	'OriginalExpression: '"INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1) VALUES ("+Trad.IDX+", '"+_Param.Input.DB+"', '"+_Param.Input.TableName+"', '"+SupportRowTags.ORIGIN_ID_0+"', '"+SupportRowTags.ORIGIN_ID_1+"')"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_700(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO METATRADS (IDX, ORIGIN_DB, ORIGIN_TABLE, ORIGIN_ID_0, ORIGIN_ID_1) VALUES ("+Trad.IDX+", '"+_Param.Input.DB+"', '"+_Param.Input.TableName+"', '"+SupportRowTags.ORIGIN_ID_0+"', '"+SupportRowTags.ORIGIN_ID_1+"')"
	End Function

	'OriginalExpression: 'ConnStr_LOCAL
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_251(ByVal Main As RDCompiledProcess) As Object
		return ConnStr_LOCAL
	End Function

	'FOREACH _language IN Languages BYREF
	'OriginalExpression: 'Languages
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_722(ByVal Main As RDCompiledProcess) As Object
		return Languages
	End Function

	'OriginalExpression: 'ReadTextFile(GS_TradPath+"\language_"+_language+".txt")
	<Extension()>
	Public Function Eval_Static_Set_JSONtext_K_752(ByVal Main As RDCompiledProcess) As Object
		return ReadTextFile(GS_TradPath+"\language_"+_language+".txt")
	End Function

	'OriginalExpression: 'FromJSON(kvTable.GetType,JSONtext, "(HASH)(KEYVALUE)")
	<Extension()>
	Public Function Eval_Static_Set_kvTable_K_753(ByVal Main As RDCompiledProcess) As Object
		return FromJSON(kvTable.GetType,JSONtext, "(HASH)(KEYVALUE)")
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

	'OriginalExpression: 'MetaTradTable
	<Extension()>
	Public Function Eval_Static_ListOfRows_K_765(ByVal Main As RDCompiledProcess) As Object
		return MetaTradTable
	End Function

	'OriginalExpression: 'TradTable
	<Extension()>
	Public Function Eval_Static_ListOfRows_K_767(ByVal Main As RDCompiledProcess) As Object
		return TradTable
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

	'OriginalExpression: 'j+1
	<Extension()>
	Public Function Eval_Static_Set_j_K_863(ByVal Main As RDCompiledProcess) As Object
		return j+1
	End Function

	'OriginalExpression: 'j+baseIDX
	<Extension()>
	Public Function Eval_Static_IDX_K_876(ByVal Main As RDCompiledProcess) As Object
		return j+baseIDX
	End Function

	'OriginalExpression: 'value
	<Extension()>
	Public Function Eval_Static_ORIGIN_ID_0_K_876(ByVal Main As RDCompiledProcess) As Object
		return value
	End Function

	'OriginalExpression: 'baseIDX+j
	<Extension()>
	Public Function Eval_Static_IDX_K_887(ByVal Main As RDCompiledProcess) As Object
		return baseIDX+j
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ITA
	<Extension()>
	Public Function Eval_Static_CondExp1_K_918(ByVal Main As RDCompiledProcess) As Object
		return ITA
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ENG
	<Extension()>
	Public Function Eval_Static_CondExp1_K_1086(ByVal Main As RDCompiledProcess) As Object
		return ENG
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ESP
	<Extension()>
	Public Function Eval_Static_CondExp1_K_1117(ByVal Main As RDCompiledProcess) As Object
		return ESP
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'FRA
	<Extension()>
	Public Function Eval_Static_CondExp1_K_1148(ByVal Main As RDCompiledProcess) As Object
		return FRA
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'DEU
	<Extension()>
	Public Function Eval_Static_CondExp1_K_1179(ByVal Main As RDCompiledProcess) As Object
		return DEU
	End Function

	'OriginalExpression: 'MetaTradTable
	<Extension()>
	Public Function Eval_Static_ListOfRows_K_873(ByVal Main As RDCompiledProcess) As Object
		return MetaTradTable
	End Function

	'OriginalExpression: 'TradTable
	<Extension()>
	Public Function Eval_Static_ListOfRows_K_1403(ByVal Main As RDCompiledProcess) As Object
		return TradTable
	End Function



End Module
