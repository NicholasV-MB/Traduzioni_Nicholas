Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.BasicFunctionsProxy

Module StaticExpressions

    'This placeholder is for static expression table
	'OriginalExpression: 'ProcPath()+"Settings.ini"
	<Extension()>
	Public Function Eval_Static_Set_IniFilePath_K_7083(ByVal Main As RDCompiledProcess) As Object
		return ProcPath()+"Settings.ini"
	End Function

	'OriginalExpression: 'ReadIni(IniFilePath, "FUSION", "ConnectionString")
	<Extension()>
	Public Function Eval_Static_Set_ConnStr_FUSION_K_7109(ByVal Main As RDCompiledProcess) As Object
		return ReadIni(IniFilePath, "FUSION", "ConnectionString")
	End Function

	'OriginalExpression: 'ReadIni(IniFilePath, "LOCAL", "ConnectionString")
	<Extension()>
	Public Function Eval_Static_Set_ConnStr_LOCAL_K_7110(ByVal Main As RDCompiledProcess) As Object
		return ReadIni(IniFilePath, "LOCAL", "ConnectionString")
	End Function

	'OriginalExpression: 'ReadIni(IniFilePath, "FUSION", "SetDateFormat")
	<Extension()>
	Public Function Eval_Static_Set_dateformat_K_18091(ByVal Main As RDCompiledProcess) As Object
		return ReadIni(IniFilePath, "FUSION", "SetDateFormat")
	End Function

	'OriginalExpression: 'ReadIni(IniFilePath, "PDM", "ConnectionString")
	<Extension()>
	Public Function Eval_Static_Set_ConnStr_PDM_K_7111(ByVal Main As RDCompiledProcess) As Object
		return ReadIni(IniFilePath, "PDM", "ConnectionString")
	End Function

	'OriginalExpression: 'ProcPath()+ReadIni(IniFilePath, "GRAPHICAL STUDIO", "TranslationPath")
	<Extension()>
	Public Function Eval_Static_Set_GS_TradPath_K_7112(ByVal Main As RDCompiledProcess) As Object
		return ProcPath()+ReadIni(IniFilePath, "GRAPHICAL STUDIO", "TranslationPath")
	End Function

	'OriginalExpression: 'ProcPath()+ReadIni(IniFilePath, "CRM", "MBPath")
	<Extension()>
	Public Function Eval_Static_Set_CRM_TradPath_K_7113(ByVal Main As RDCompiledProcess) As Object
		return ProcPath()+ReadIni(IniFilePath, "CRM", "MBPath")
	End Function

	'OriginalExpression: 'SplitStr(ReadIni(IniFilePath, "LANGUAGES", "Languages"), ",", "")
	<Extension()>
	Public Function Eval_Static_Set_Languages_K_7114(ByVal Main As RDCompiledProcess) As Object
		return SplitStr(ReadIni(IniFilePath, "LANGUAGES", "Languages"), ",", "")
	End Function

	'OriginalExpression: 'ConnStr_LOCAL
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_136(ByVal Main As RDCompiledProcess) As Object
		return ConnStr_LOCAL
	End Function

	'Condition for group New To Add
	'OriginalExpression: 'Count(TradTableToAdd)>0
	<Extension()>
	Public Function Eval_Static_CondExp1_K_373(ByVal Main As RDCompiledProcess) As Object
		return Count(TradTableToAdd)>0
	End Function

	'OriginalExpression: 'ConnStr_FUSION
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_407(ByVal Main As RDCompiledProcess) As Object
		return ConnStr_FUSION
	End Function

	'FOREACH Trad IN TradTableToAdd BYREF
	'OriginalExpression: 'TradTableToAdd
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_364(ByVal Main As RDCompiledProcess) As Object
		return TradTableToAdd
	End Function

	'OriginalExpression: '"SELECT * FROM METATRADS WHERE IDX="+Trad.IDX
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_433(ByVal Main As RDCompiledProcess) As Object
		return "SELECT * FROM METATRADS WHERE IDX="+Trad.IDX
	End Function

	'OriginalExpression: '"INSERT INTO LANGUAGE (TAG, ENG, ITA, ESP, FRA, DEU, cpupdtms)  VALUES('"+StrSql(MetaTrad.ORIGIN_ID_0)+"',  "+IIF(Trad.ENG<>"", "'"+StrSql(Trad.ENG)+"'", "null")+", "+IIF(Trad.ITA<>"", "'"+StrSql(Trad.ITA)+"'", "null")+", "+IIF(Trad.ESP<>"", "'"+StrSql(Trad.ESP)+"'", "null")+", "+IIF(Trad.FRA<>"", "'"+StrSql(Trad.FRA)+"'", "null")+", "+IIF(Trad.DEU<>"", "'"+StrSql(Trad.DEU)+"'", "null")+",  '"+RDToString(MetaTrad.LAST_UPDATE)+"')" 
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_393(ByVal Main As RDCompiledProcess) As Object
		return "INSERT INTO LANGUAGE (TAG, ENG, ITA, ESP, FRA, DEU, cpupdtms)  VALUES('"+StrSql(MetaTrad.ORIGIN_ID_0)+"',  "+IIF(Trad.ENG<>"", "'"+StrSql(Trad.ENG)+"'", "null")+", "+IIF(Trad.ITA<>"", "'"+StrSql(Trad.ITA)+"'", "null")+", "+IIF(Trad.ESP<>"", "'"+StrSql(Trad.ESP)+"'", "null")+", "+IIF(Trad.FRA<>"", "'"+StrSql(Trad.FRA)+"'", "null")+", "+IIF(Trad.DEU<>"", "'"+StrSql(Trad.DEU)+"'", "null")+",  '"+RDToString(MetaTrad.LAST_UPDATE)+"')" 
	End Function

	'OriginalExpression: '"SELECT * FROM METATRADS WHERE IDX="+Trad.IDX
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_144(ByVal Main As RDCompiledProcess) As Object
		return "SELECT * FROM METATRADS WHERE IDX="+Trad.IDX
	End Function

	'FOREACH MetaTrad IN MetaTradTableToUpdate BYREF
	'OriginalExpression: 'MetaTradTableToUpdate
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_2952(ByVal Main As RDCompiledProcess) As Object
		return MetaTradTableToUpdate
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_DB = "FUSION"
	<Extension()>
	Public Function Eval_Static_NODE_FUSION_K_147(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_DB = "FUSION"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_DB = "PDM"
	<Extension()>
	Public Function Eval_Static_NODE_PDM_K_147(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_DB = "PDM"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_DB = "GRAPHICAL STUDIO"
	<Extension()>
	Public Function Eval_Static_NODE_GRAPHICAL_STUDIO_K_147(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_DB = "GRAPHICAL STUDIO"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_DB = "CRM"
	<Extension()>
	Public Function Eval_Static_NODE_CRM_K_147(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_DB = "CRM"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'FUSION
	<Extension()>
	Public Function Eval_Static_CondExp1_K_184(ByVal Main As RDCompiledProcess) As Object
		return FUSION
	End Function

	'OriginalExpression: 'ConnStr_FUSION
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_1453(ByVal Main As RDCompiledProcess) As Object
		return ConnStr_FUSION
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "LANGUAGE"
	<Extension()>
	Public Function Eval_Static_NODE_LANGUAGE_K_558(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "LANGUAGE"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "ba_properties"
	<Extension()>
	Public Function Eval_Static_NODE_ba_properties_K_558(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "ba_properties"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "ba_prop_value"
	<Extension()>
	Public Function Eval_Static_NODE_ba_prop_value_K_558(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "ba_prop_value"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "ba_activitytype"
	<Extension()>
	Public Function Eval_Static_NODE_ba_activitytype_K_558(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "ba_activitytype"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "ba_activity_category"
	<Extension()>
	Public Function Eval_Static_NODE_ba_activity_category_K_558(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "ba_activity_category"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "wo_state" 
	<Extension()>
	Public Function Eval_Static_NODE_wo_state_K_558(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "wo_state" 
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "pr_item"
	<Extension()>
	Public Function Eval_Static_NODE_pr_item_K_558(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "pr_item"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "pr_type"
	<Extension()>
	Public Function Eval_Static_NODE_pr_type_K_558(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "pr_type"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "dm_class"
	<Extension()>
	Public Function Eval_Static_NODE_dm_class_K_558(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "dm_class"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "dm_folder_001"
	<Extension()>
	Public Function Eval_Static_NODE_dm_folder_001_K_558(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "dm_folder_001"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "ba_source"
	<Extension()>
	Public Function Eval_Static_NODE_ba_source_K_558(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "ba_source"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'LANGUAGE
	<Extension()>
	Public Function Eval_Static_CondExp1_K_704(ByVal Main As RDCompiledProcess) As Object
		return LANGUAGE
	End Function

	'OriginalExpression: 'dateformat+" UPDATE LANGUAGE  SET ENG='"+StrSql(Trad.ENG)+"',      ITA='"+StrSql(Trad.ITA)+"',      ESP='"+StrSql(Trad.ESP)+"',      FRA='"+StrSql(Trad.FRA)+"',      DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE TAG='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_1610(ByVal Main As RDCompiledProcess) As Object
		return dateformat+" UPDATE LANGUAGE  SET ENG='"+StrSql(Trad.ENG)+"',      ITA='"+StrSql(Trad.ITA)+"',      ESP='"+StrSql(Trad.ESP)+"',      FRA='"+StrSql(Trad.FRA)+"',      DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE TAG='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ba_properties
	<Extension()>
	Public Function Eval_Static_CondExp1_K_755(ByVal Main As RDCompiledProcess) As Object
		return ba_properties
	End Function

	'OriginalExpression: 'dateformat+" UPDATE ba_properties  SET PRDESCRI_ENG='"+StrSql(Trad.ENG)+"',      PRDESCRI_ITA='"+StrSql(Trad.ITA)+"',      PRDESCRI_ESP='"+StrSql(Trad.ESP)+"',      PRDESCRI_FRA='"+StrSql(Trad.FRA)+"',      PRDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE PRCODEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_1804(ByVal Main As RDCompiledProcess) As Object
		return dateformat+" UPDATE ba_properties  SET PRDESCRI_ENG='"+StrSql(Trad.ENG)+"',      PRDESCRI_ITA='"+StrSql(Trad.ITA)+"',      PRDESCRI_ESP='"+StrSql(Trad.ESP)+"',      PRDESCRI_FRA='"+StrSql(Trad.FRA)+"',      PRDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE PRCODEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ba_prop_value
	<Extension()>
	Public Function Eval_Static_CondExp1_K_789(ByVal Main As RDCompiledProcess) As Object
		return ba_prop_value
	End Function

	'OriginalExpression: 'dateformat+" UPDATE ba_prop_value  SET PVDESCRI_ENG='"+StrSql(Trad.ENG)+"',      PVDESCRI_ITA='"+StrSql(Trad.ITA)+"',      PVDESCRI_ESP='"+StrSql(Trad.ESP)+"',      PVDESCRI_FRA='"+StrSql(Trad.FRA)+"',      PVDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE PVPROPID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND CPROWNUM="+MetaTrad.ORIGIN_ID_1
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_1883(ByVal Main As RDCompiledProcess) As Object
		return dateformat+" UPDATE ba_prop_value  SET PVDESCRI_ENG='"+StrSql(Trad.ENG)+"',      PVDESCRI_ITA='"+StrSql(Trad.ITA)+"',      PVDESCRI_ESP='"+StrSql(Trad.ESP)+"',      PVDESCRI_FRA='"+StrSql(Trad.FRA)+"',      PVDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE PVPROPID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND CPROWNUM="+MetaTrad.ORIGIN_ID_1
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ba_activitytype
	<Extension()>
	Public Function Eval_Static_CondExp1_K_823(ByVal Main As RDCompiledProcess) As Object
		return ba_activitytype
	End Function

	'OriginalExpression: 'dateformat+" UPDATE ba_activitytype SET ATDESCRI_ENG='"+StrSql(TradTableToUpdate(j-1).ENG)+"',      ATDESCRI_ITA='"+StrSql(TradTableToUpdate(j-1).ITA)+"',      ATDESCRI_ESP='"+StrSql(TradTableToUpdate(j-1).ESP)+"',      ATDESCRI_FRA='"+StrSql(TradTableToUpdate(j-1).FRA)+"',      ATDESCRI_DEU='"+StrSql(TradTableToUpdate(j-1).DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE ATTYPEID='"+StrSql(MetaTradTableToUpdate(i-1).ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_1992(ByVal Main As RDCompiledProcess) As Object
		return dateformat+" UPDATE ba_activitytype SET ATDESCRI_ENG='"+StrSql(TradTableToUpdate(j-1).ENG)+"',      ATDESCRI_ITA='"+StrSql(TradTableToUpdate(j-1).ITA)+"',      ATDESCRI_ESP='"+StrSql(TradTableToUpdate(j-1).ESP)+"',      ATDESCRI_FRA='"+StrSql(TradTableToUpdate(j-1).FRA)+"',      ATDESCRI_DEU='"+StrSql(TradTableToUpdate(j-1).DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE ATTYPEID='"+StrSql(MetaTradTableToUpdate(i-1).ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ba_activity_category
	<Extension()>
	Public Function Eval_Static_CondExp1_K_857(ByVal Main As RDCompiledProcess) As Object
		return ba_activity_category
	End Function

	'OriginalExpression: 'dateformat+" UPDATE ba_activity_category SET ACDESCRI_ENG='"+StrSql(Trad.ENG)+"',      ACDESCRI_ITA='"+StrSql(Trad.ITA)+"',      ACDESCRI_ESP='"+StrSql(Trad.ESP)+"',      ACDESCRI_FRA='"+StrSql(Trad.FRA)+"',      ACDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE ACCATID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_2071(ByVal Main As RDCompiledProcess) As Object
		return dateformat+" UPDATE ba_activity_category SET ACDESCRI_ENG='"+StrSql(Trad.ENG)+"',      ACDESCRI_ITA='"+StrSql(Trad.ITA)+"',      ACDESCRI_ESP='"+StrSql(Trad.ESP)+"',      ACDESCRI_FRA='"+StrSql(Trad.FRA)+"',      ACDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE ACCATID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'wo_state
	<Extension()>
	Public Function Eval_Static_CondExp1_K_891(ByVal Main As RDCompiledProcess) As Object
		return wo_state
	End Function

	'OriginalExpression: 'dateformat+" UPDATE wo_state SET ST"+MetaTrad.ORIGIN_ID_1+"_ENG='"+StrSql(Trad.ENG)+"',      ST"+MetaTrad.ORIGIN_ID_1+"_ITA='"+StrSql(Trad.ITA)+"',      ST"+MetaTrad.ORIGIN_ID_1+"_ESP='"+StrSql(Trad.ESP)+"',      ST"+MetaTrad.ORIGIN_ID_1+"_FRA='"+StrSql(Trad.FRA)+"',      ST"+MetaTrad.ORIGIN_ID_1+"_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE STCODEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_8482(ByVal Main As RDCompiledProcess) As Object
		return dateformat+" UPDATE wo_state SET ST"+MetaTrad.ORIGIN_ID_1+"_ENG='"+StrSql(Trad.ENG)+"',      ST"+MetaTrad.ORIGIN_ID_1+"_ITA='"+StrSql(Trad.ITA)+"',      ST"+MetaTrad.ORIGIN_ID_1+"_ESP='"+StrSql(Trad.ESP)+"',      ST"+MetaTrad.ORIGIN_ID_1+"_FRA='"+StrSql(Trad.FRA)+"',      ST"+MetaTrad.ORIGIN_ID_1+"_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE STCODEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'pr_item
	<Extension()>
	Public Function Eval_Static_CondExp1_K_925(ByVal Main As RDCompiledProcess) As Object
		return pr_item
	End Function

	'OriginalExpression: 'dateformat+" UPDATE pr_item SET ITDESCRI_ENG='"+StrSql(Trad.ENG)+"',      ITDESCRI_ITA='"+StrSql(Trad.ITA)+"',      ITDESCRI_ESP='"+StrSql(Trad.ESP)+"',      ITDESCRI_FRA='"+StrSql(Trad.FRA)+"',      ITDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE ITITEMID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_2418(ByVal Main As RDCompiledProcess) As Object
		return dateformat+" UPDATE pr_item SET ITDESCRI_ENG='"+StrSql(Trad.ENG)+"',      ITDESCRI_ITA='"+StrSql(Trad.ITA)+"',      ITDESCRI_ESP='"+StrSql(Trad.ESP)+"',      ITDESCRI_FRA='"+StrSql(Trad.FRA)+"',      ITDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE ITITEMID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'pr_type
	<Extension()>
	Public Function Eval_Static_CondExp1_K_959(ByVal Main As RDCompiledProcess) As Object
		return pr_type
	End Function

	'OriginalExpression: 'dateformat+" UPDATE pr_type SET PTDESCRI_ENG='"+StrSql(Trad.ENG)+"',      PTDESCRI_ITA='"+StrSql(Trad.ITA)+"',      PTDESCRI_ESP='"+StrSql(Trad.ESP)+"',      PTDESCRI_FRA='"+StrSql(Trad.FRA)+"',      PTDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE PTTYPEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_2497(ByVal Main As RDCompiledProcess) As Object
		return dateformat+" UPDATE pr_type SET PTDESCRI_ENG='"+StrSql(Trad.ENG)+"',      PTDESCRI_ITA='"+StrSql(Trad.ITA)+"',      PTDESCRI_ESP='"+StrSql(Trad.ESP)+"',      PTDESCRI_FRA='"+StrSql(Trad.FRA)+"',      PTDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE PTTYPEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'dm_class
	<Extension()>
	Public Function Eval_Static_CondExp1_K_993(ByVal Main As RDCompiledProcess) As Object
		return dm_class
	End Function

	'OriginalExpression: 'dateformat+" UPDATE dm_class SET CDDESCRI_ENG='"+StrSql(Trad.ENG)+"',      CDDESCRI_ITA='"+StrSql(Trad.ITA)+"',      CDDESCRI_ESP='"+StrSql(Trad.ESP)+"',      CDDESCRI_FRA='"+StrSql(Trad.FRA)+"',      CDDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE CDCLASSID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_2593(ByVal Main As RDCompiledProcess) As Object
		return dateformat+" UPDATE dm_class SET CDDESCRI_ENG='"+StrSql(Trad.ENG)+"',      CDDESCRI_ITA='"+StrSql(Trad.ITA)+"',      CDDESCRI_ESP='"+StrSql(Trad.ESP)+"',      CDDESCRI_FRA='"+StrSql(Trad.FRA)+"',      CDDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE CDCLASSID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'dm_folder_001
	<Extension()>
	Public Function Eval_Static_CondExp1_K_1027(ByVal Main As RDCompiledProcess) As Object
		return dm_folder_001
	End Function

	'OriginalExpression: 'dateformat+" UPDATE dm_folder_001  SET DMDESCRI_ENG='"+StrSql(Trad.ENG)+"',      DMDESCRI_ITA='"+StrSql(Trad.ITA)+"',      DMDESCRI_ESP='"+StrSql(Trad.ESP)+"',      DMDESCRI_FRA='"+StrSql(Trad.FRA)+"',      DMDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE DMDESCRI='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND DMTYPE='C'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_3441(ByVal Main As RDCompiledProcess) As Object
		return dateformat+" UPDATE dm_folder_001  SET DMDESCRI_ENG='"+StrSql(Trad.ENG)+"',      DMDESCRI_ITA='"+StrSql(Trad.ITA)+"',      DMDESCRI_ESP='"+StrSql(Trad.ESP)+"',      DMDESCRI_FRA='"+StrSql(Trad.FRA)+"',      DMDESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE DMDESCRI='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND DMTYPE='C'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ba_source
	<Extension()>
	Public Function Eval_Static_CondExp1_K_1398(ByVal Main As RDCompiledProcess) As Object
		return ba_source
	End Function

	'OriginalExpression: 'dateformat+" UPDATE ba_source SET SODESCRI_ENG='"+StrSql(Trad.ENG)+"',      SODESCRI_ITA='"+StrSql(Trad.ITA)+"',      SODESCRI_ESP='"+StrSql(Trad.ESP)+"',      SODESCRI_FRA='"+StrSql(Trad.FRA)+"',      SODESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE SOID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_2689(ByVal Main As RDCompiledProcess) As Object
		return dateformat+" UPDATE ba_source SET SODESCRI_ENG='"+StrSql(Trad.ENG)+"',      SODESCRI_ITA='"+StrSql(Trad.ITA)+"',      SODESCRI_ESP='"+StrSql(Trad.ESP)+"',      SODESCRI_FRA='"+StrSql(Trad.FRA)+"',      SODESCRI_DEU='"+StrSql(Trad.DEU)+"',      cpupdtms='"+DateToStr(Now())+"' WHERE SOID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'PDM
	<Extension()>
	Public Function Eval_Static_CondExp1_K_202(ByVal Main As RDCompiledProcess) As Object
		return PDM
	End Function

	'OriginalExpression: 'ConnStr_PDM
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_3843(ByVal Main As RDCompiledProcess) As Object
		return ConnStr_PDM
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'MetaTrad.ORIGIN_ID_1="328" or MetaTrad.ORIGIN_ID_1="329"
	<Extension()>
	Public Function Eval_Static_CondExp1_K_3568(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_ID_1="328" or MetaTrad.ORIGIN_ID_1="329"
	End Function

	'OriginalExpression: '"UPDATE CODVAL  SET cvalTrans1='"+StrSql(Trad.ENG)+"',      cvalValore='"+StrSql(Trad.ITA)+"',      cvalTrans4='"+StrSql(Trad.ESP)+"',      cvalTrans2='"+StrSql(Trad.FRA)+"',      cvalTrans3='"+StrSql(Trad.DEU)+"'  WHERE cvalID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND cpID='"+StrSql(MetaTrad.ORIGIN_ID_1)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_3790(ByVal Main As RDCompiledProcess) As Object
		return "UPDATE CODVAL  SET cvalTrans1='"+StrSql(Trad.ENG)+"',      cvalValore='"+StrSql(Trad.ITA)+"',      cvalTrans4='"+StrSql(Trad.ESP)+"',      cvalTrans2='"+StrSql(Trad.FRA)+"',      cvalTrans3='"+StrSql(Trad.DEU)+"'  WHERE cvalID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND cpID='"+StrSql(MetaTrad.ORIGIN_ID_1)+"'"
	End Function

	'OriginalExpression: '"UPDATE CODVAL  SET cvalTrans3='"+StrSql(Trad.ENG)+"',      cvalTrans2='"+StrSql(Trad.ITA)+"',      cvalTrans4='"+StrSql(Trad.FRA)+"',      cvalTrans5='"+StrSql(Trad.DEU)+"' WHERE cvalID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND cpID='"+StrSql(MetaTrad.ORIGIN_ID_1)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_3537(ByVal Main As RDCompiledProcess) As Object
		return "UPDATE CODVAL  SET cvalTrans3='"+StrSql(Trad.ENG)+"',      cvalTrans2='"+StrSql(Trad.ITA)+"',      cvalTrans4='"+StrSql(Trad.FRA)+"',      cvalTrans5='"+StrSql(Trad.DEU)+"' WHERE cvalID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND cpID='"+StrSql(MetaTrad.ORIGIN_ID_1)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'GRAPHICAL_STUDIO
	<Extension()>
	Public Function Eval_Static_CondExp1_K_214(ByVal Main As RDCompiledProcess) As Object
		return GRAPHICAL_STUDIO
	End Function

	'FOREACH _language IN Languages BYREF
	'OriginalExpression: 'Languages
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_4392(ByVal Main As RDCompiledProcess) As Object
		return Languages
	End Function

	'OriginalExpression: 'GS_TradPath+"\language_"+_language+".txt"
	<Extension()>
	Public Function Eval_Static_Set_JSONFile_K_4806(ByVal Main As RDCompiledProcess) As Object
		return GS_TradPath+"\language_"+_language+".txt"
	End Function

	'OriginalExpression: 'ReadTextFile(JSONFile)
	<Extension()>
	Public Function Eval_Static_Set_JSONtext_K_4898(ByVal Main As RDCompiledProcess) As Object
		return ReadTextFile(JSONFile)
	End Function

	'OriginalExpression: 'FromJSON(kvTable.GetType,JSONtext, "(HASH)(KEYVALUE)")
	<Extension()>
	Public Function Eval_Static_Set_kvTable_K_4930(ByVal Main As RDCompiledProcess) As Object
		return FromJSON(kvTable.GetType,JSONtext, "(HASH)(KEYVALUE)")
	End Function

	'FOREACH kvRow IN kvTable BYREF
	'OriginalExpression: 'kvTable
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_4962(ByVal Main As RDCompiledProcess) As Object
		return kvTable
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'MetaTrad.ORIGIN_ID_0=kvTable(i-1).key
	<Extension()>
	Public Function Eval_Static_CondExp1_K_5220(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_ID_0=kvTable(i-1).key
	End Function

	'OriginalExpression: 'IIF(_language="ITA", Trad.ITA,     IIF(_language="ENG", Trad.ENG,         IIF(_language="ESP", Trad.ESP,             IIF(_language="FRA", Trad.FRA, TRAD.DEU)         )     ) )
	<Extension()>
	Public Function Eval_Static_Set_kvTable_i_1__value_K_5008(ByVal Main As RDCompiledProcess) As Object
		return IIF(_language="ITA", Trad.ITA,     IIF(_language="ENG", Trad.ENG,         IIF(_language="ESP", Trad.ESP,             IIF(_language="FRA", Trad.FRA, TRAD.DEU)         )     ) )
	End Function

	'OriginalExpression: 'ToJSON(kvTable, "(HASH)")
	<Extension()>
	Public Function Eval_Static_Set_JSONtext_K_5528(ByVal Main As RDCompiledProcess) As Object
		return ToJSON(kvTable, "(HASH)")
	End Function

	'OriginalExpression: 'JSONFile
	<Extension()>
	Public Function Eval_Static_FileName_K_4239(ByVal Main As RDCompiledProcess) As Object
		return JSONFile
	End Function

	'OriginalExpression: 'JSONtext
	<Extension()>
	Public Function Eval_Static_StringText_K_4239(ByVal Main As RDCompiledProcess) As Object
		return JSONtext
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'CRM
	<Extension()>
	Public Function Eval_Static_CondExp1_K_226(ByVal Main As RDCompiledProcess) As Object
		return CRM
	End Function

	'OriginalExpression: 'ReadTextFile(CRM_TradPath)
	<Extension()>
	Public Function Eval_Static_Set_xml_crm_K_5791(ByVal Main As RDCompiledProcess) As Object
		return ReadTextFile(CRM_TradPath)
	End Function

	'OriginalExpression: 'IIF(Trad.ITA<>"", "     <ITA>"+IIF(IsTagInString(Trad.ITA, "<br>"),cdata_start+Trad.ITA+cdata_end+"]>",Trad.ITA)+"</ITA>", "")+IIF(Trad.ENG<>"", "     <ENG>"+IIF(IsTagInString(Trad.ENG, "<br>"),cdata_start+Trad.ENG+cdata_end+"]>",Trad.ENG)+"</ENG>", "")+IIF(Trad.ESP<>"", "     <ESP>"+IIF(IsTagInString(Trad.ESP, "<br>"),cdata_start+Trad.ESP+cdata_end+"]>",Trad.ESP)+"</ESP>", "")+IIF(Trad.FRA<>"", "     <FRA>"+IIF(IsTagInString(Trad.FRA, "<br>"),cdata_start+Trad.FRA+cdata_end+"]>",Trad.FRA)+"</FRA>", "")+IIF(Trad.DEU<>"", "     <DEU>"+IIF(IsTagInString(Trad.DEU, "<br>"),cdata_start+Trad.DEU+cdata_end+"]>",Trad.DEU)+"</DEU>", "")+" <Orig_str> "
	<Extension()>
	Public Function Eval_Static_Set_tags_to_replace_K_5838(ByVal Main As RDCompiledProcess) As Object
		return IIF(Trad.ITA<>"", "     <ITA>"+IIF(IsTagInString(Trad.ITA, "<br>"),cdata_start+Trad.ITA+cdata_end+"]>",Trad.ITA)+"</ITA>", "")+IIF(Trad.ENG<>"", "     <ENG>"+IIF(IsTagInString(Trad.ENG, "<br>"),cdata_start+Trad.ENG+cdata_end+"]>",Trad.ENG)+"</ENG>", "")+IIF(Trad.ESP<>"", "     <ESP>"+IIF(IsTagInString(Trad.ESP, "<br>"),cdata_start+Trad.ESP+cdata_end+"]>",Trad.ESP)+"</ESP>", "")+IIF(Trad.FRA<>"", "     <FRA>"+IIF(IsTagInString(Trad.FRA, "<br>"),cdata_start+Trad.FRA+cdata_end+"]>",Trad.FRA)+"</FRA>", "")+IIF(Trad.DEU<>"", "     <DEU>"+IIF(IsTagInString(Trad.DEU, "<br>"),cdata_start+Trad.DEU+cdata_end+"]>",Trad.DEU)+"</DEU>", "")+" <Orig_str> "
	End Function

	'OriginalExpression: 'ReplaceFromTo(     xml_crm,      "<Orig_str>"+IIF(IsTagInString(MetaTrad.ORIGIN_ID_0, "<br>"),cdata_start+MetaTrad.ORIGIN_ID_0+cdata_end+"]>", MetaTrad.ORIGIN_ID_0)+"</Orig_str>",      StrAfter(         StrAfter(             xml_crm,              "<Orig_str>"+IIF(IsTagInString(MetaTrad.ORIGIN_ID_0, "<br>"),cdata_start+MetaTrad.ORIGIN_ID_0+cdata_end+"]>", MetaTrad.ORIGIN_ID_0)+"</Orig_str>"),          "<Orig_str>"),  tags_to_replace)  
	<Extension()>
	Public Function Eval_Static_Set_final_xml_K_6476(ByVal Main As RDCompiledProcess) As Object
		return ReplaceFromTo(     xml_crm,      "<Orig_str>"+IIF(IsTagInString(MetaTrad.ORIGIN_ID_0, "<br>"),cdata_start+MetaTrad.ORIGIN_ID_0+cdata_end+"]>", MetaTrad.ORIGIN_ID_0)+"</Orig_str>",      StrAfter(         StrAfter(             xml_crm,              "<Orig_str>"+IIF(IsTagInString(MetaTrad.ORIGIN_ID_0, "<br>"),cdata_start+MetaTrad.ORIGIN_ID_0+cdata_end+"]>", MetaTrad.ORIGIN_ID_0)+"</Orig_str>"),          "<Orig_str>"),  tags_to_replace)  
	End Function

	'OriginalExpression: 'CRM_TradPath
	<Extension()>
	Public Function Eval_Static_FileName_K_6522(ByVal Main As RDCompiledProcess) As Object
		return CRM_TradPath
	End Function

	'OriginalExpression: 'final_xml
	<Extension()>
	Public Function Eval_Static_StringText_K_6522(ByVal Main As RDCompiledProcess) As Object
		return final_xml
	End Function

	'FOREACH Trad IN TradTableToDelete BYREF
	'OriginalExpression: 'TradTableToDelete
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_12532(ByVal Main As RDCompiledProcess) As Object
		return TradTableToDelete
	End Function

	'OriginalExpression: '"SELECT * FROM METATRADS WHERE IDX="+Trad.IDX
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_12449(ByVal Main As RDCompiledProcess) As Object
		return "SELECT * FROM METATRADS WHERE IDX="+Trad.IDX
	End Function

	'FOREACH MetaTrad IN MetaTradTableToDelete BYREF
	'OriginalExpression: 'MetaTradTableToDelete
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_12531(ByVal Main As RDCompiledProcess) As Object
		return MetaTradTableToDelete
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_DB = "FUSION"
	<Extension()>
	Public Function Eval_Static_NODE_FUSION_K_12530(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_DB = "FUSION"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_DB = "PDM"
	<Extension()>
	Public Function Eval_Static_NODE_PDM_K_12530(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_DB = "PDM"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_DB = "GRAPHICAL STUDIO"
	<Extension()>
	Public Function Eval_Static_NODE_GRAPHICAL_STUDIO_K_12530(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_DB = "GRAPHICAL STUDIO"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_DB = "CRM"
	<Extension()>
	Public Function Eval_Static_NODE_CRM_K_12530(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_DB = "CRM"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'FUSION
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12490(ByVal Main As RDCompiledProcess) As Object
		return FUSION
	End Function

	'OriginalExpression: 'ConnStr_FUSION
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_12454(ByVal Main As RDCompiledProcess) As Object
		return ConnStr_FUSION
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "LANGUAGE"
	<Extension()>
	Public Function Eval_Static_NODE_LANGUAGE_K_12488(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "LANGUAGE"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "ba_properties"
	<Extension()>
	Public Function Eval_Static_NODE_ba_properties_K_12488(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "ba_properties"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "ba_prop_value"
	<Extension()>
	Public Function Eval_Static_NODE_ba_prop_value_K_12488(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "ba_prop_value"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "ba_activitytype"
	<Extension()>
	Public Function Eval_Static_NODE_ba_activitytype_K_12488(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "ba_activitytype"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "ba_activity_category"
	<Extension()>
	Public Function Eval_Static_NODE_ba_activity_category_K_12488(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "ba_activity_category"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "wo_state" 
	<Extension()>
	Public Function Eval_Static_NODE_wo_state_K_12488(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "wo_state" 
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "pr_item"
	<Extension()>
	Public Function Eval_Static_NODE_pr_item_K_12488(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "pr_item"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "pr_type"
	<Extension()>
	Public Function Eval_Static_NODE_pr_type_K_12488(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "pr_type"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "dm_class"
	<Extension()>
	Public Function Eval_Static_NODE_dm_class_K_12488(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "dm_class"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "dm_folder_001"
	<Extension()>
	Public Function Eval_Static_NODE_dm_folder_001_K_12488(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "dm_folder_001"
	End Function

	'OriginalExpression: 'MetaTrad.ORIGIN_TABLE = "ba_source"
	<Extension()>
	Public Function Eval_Static_NODE_ba_source_K_12488(ByVal Main As RDCompiledProcess) As Object
		return MetaTrad.ORIGIN_TABLE = "ba_source"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'LANGUAGE
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12467(ByVal Main As RDCompiledProcess) As Object
		return LANGUAGE
	End Function

	'OriginalExpression: '"DELETE FROM LANGUAGE  WHERE TAG='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_12466(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM LANGUAGE  WHERE TAG='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ba_properties
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12469(ByVal Main As RDCompiledProcess) As Object
		return ba_properties
	End Function

	'OriginalExpression: '"DELETE FROM ba_properties  WHERE PRCODEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_12468(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM ba_properties  WHERE PRCODEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ba_prop_value
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12471(ByVal Main As RDCompiledProcess) As Object
		return ba_prop_value
	End Function

	'OriginalExpression: '"DELETE FROM ba_prop_value  WHERE PVPROPID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND CPROWNUM="+MetaTrad.ORIGIN_ID_1
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_12470(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM ba_prop_value  WHERE PVPROPID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND CPROWNUM="+MetaTrad.ORIGIN_ID_1
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ba_activitytype
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12473(ByVal Main As RDCompiledProcess) As Object
		return ba_activitytype
	End Function

	'OriginalExpression: '"DELETE FROM ba_activitytype WHERE ATTYPEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_12472(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM ba_activitytype WHERE ATTYPEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ba_activity_category
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12475(ByVal Main As RDCompiledProcess) As Object
		return ba_activity_category
	End Function

	'OriginalExpression: '"DELETE FROM ba_activity_category WHERE ACCATID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_12474(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM ba_activity_category WHERE ACCATID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'wo_state
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12477(ByVal Main As RDCompiledProcess) As Object
		return wo_state
	End Function

	'OriginalExpression: '"DELETE FROM wo_state WHERE STCODEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_12476(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM wo_state WHERE STCODEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'pr_item
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12479(ByVal Main As RDCompiledProcess) As Object
		return pr_item
	End Function

	'OriginalExpression: '"DELETE FROM pr_item WHERE ITITEMID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_12478(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM pr_item WHERE ITITEMID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'pr_type
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12481(ByVal Main As RDCompiledProcess) As Object
		return pr_type
	End Function

	'OriginalExpression: '"DELETE FROM pr_type WHERE PTTYPEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_12480(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM pr_type WHERE PTTYPEID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'dm_class
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12483(ByVal Main As RDCompiledProcess) As Object
		return dm_class
	End Function

	'OriginalExpression: '"DELETE FROM dm_class WHERE CDCLASSID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_12482(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM dm_class WHERE CDCLASSID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'dm_folder_001
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12485(ByVal Main As RDCompiledProcess) As Object
		return dm_folder_001
	End Function

	'OriginalExpression: '"DELETE FROM dm_folder_001  WHERE DMDESCRI='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND DMTYPE='C'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_12484(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM dm_folder_001  WHERE DMDESCRI='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND DMTYPE='C'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'ba_source
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12487(ByVal Main As RDCompiledProcess) As Object
		return ba_source
	End Function

	'OriginalExpression: '"DELETE FROM ba_source WHERE SOID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_12486(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM ba_source WHERE SOID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'PDM
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12498(ByVal Main As RDCompiledProcess) As Object
		return PDM
	End Function

	'OriginalExpression: 'ConnStr_PDM
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_12491(ByVal Main As RDCompiledProcess) As Object
		return ConnStr_PDM
	End Function

	'OriginalExpression: '"DELETE FROM CODVAL  WHERE cvalID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND cpID='"+StrSql(MetaTrad.ORIGIN_ID_1)+"'"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_16024(ByVal Main As RDCompiledProcess) As Object
		return "DELETE FROM CODVAL  WHERE cvalID='"+StrSql(MetaTrad.ORIGIN_ID_0)+"' AND cpID='"+StrSql(MetaTrad.ORIGIN_ID_1)+"'"
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'GRAPHICAL_STUDIO
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12514(ByVal Main As RDCompiledProcess) As Object
		return GRAPHICAL_STUDIO
	End Function

	'FOREACH _language IN Languages BYREF
	'OriginalExpression: 'Languages
	<Extension()>
	Public Function Eval_Static_ForEachValues_K_12513(ByVal Main As RDCompiledProcess) As Object
		return Languages
	End Function

	'OriginalExpression: 'GS_TradPath+"\language_"+_language+".txt"
	<Extension()>
	Public Function Eval_Static_Set_JSONFile_K_12504(ByVal Main As RDCompiledProcess) As Object
		return GS_TradPath+"\language_"+_language+".txt"
	End Function

	'OriginalExpression: 'ReadTextFile(JSONFile)
	<Extension()>
	Public Function Eval_Static_Set_JSONtext_K_12505(ByVal Main As RDCompiledProcess) As Object
		return ReadTextFile(JSONFile)
	End Function

	'OriginalExpression: 'FromJSON(kvTable.GetType,JSONtext, "(HASH)(KEYVALUE)")
	<Extension()>
	Public Function Eval_Static_Set_kvTable_K_12506(ByVal Main As RDCompiledProcess) As Object
		return FromJSON(kvTable.GetType,JSONtext, "(HASH)(KEYVALUE)")
	End Function

	'OriginalExpression: 'FilterByExp(kvTable, "Me.key<>MetaTrad.ORIGIN_ID_0", "")
	<Extension()>
	Public Function Eval_Static_Set_kvTable_K_13674(ByVal Main As RDCompiledProcess) As Object
		return FilterByExp(kvTable, "Me.key<>MetaTrad.ORIGIN_ID_0", "")
	End Function

	'OriginalExpression: 'ToJSON(kvTable, "(HASH)")
	<Extension()>
	Public Function Eval_Static_Set_JSONtext_K_12511(ByVal Main As RDCompiledProcess) As Object
		return ToJSON(kvTable, "(HASH)")
	End Function

	'OriginalExpression: 'JSONFile
	<Extension()>
	Public Function Eval_Static_FileName_K_12512(ByVal Main As RDCompiledProcess) As Object
		return JSONFile
	End Function

	'OriginalExpression: 'JSONtext
	<Extension()>
	Public Function Eval_Static_StringText_K_12512(ByVal Main As RDCompiledProcess) As Object
		return JSONtext
	End Function

	'Condition for group CHOICE
	'OriginalExpression: 'CRM
	<Extension()>
	Public Function Eval_Static_CondExp1_K_12529(ByVal Main As RDCompiledProcess) As Object
		return CRM
	End Function

	'OriginalExpression: 'ReadTextFile(CRM_TradPath)
	<Extension()>
	Public Function Eval_Static_Set_xml_crm_K_12523(ByVal Main As RDCompiledProcess) As Object
		return ReadTextFile(CRM_TradPath)
	End Function

	'OriginalExpression: 'IIF(Trad.ITA<>"", "     <ITA>"+IIF(IsTagInString(Trad.ITA, "<br>"),cdata_start+Trad.ITA+cdata_end+"]>",Trad.ITA)+"</ITA>", "")+IIF(Trad.ENG<>"", "     <ENG>"+IIF(IsTagInString(Trad.ENG, "<br>"),cdata_start+Trad.ENG+cdata_end+"]>",Trad.ENG)+"</ENG>", "")+IIF(Trad.ESP<>"", "     <ESP>"+IIF(IsTagInString(Trad.ESP, "<br>"),cdata_start+Trad.ESP+cdata_end+"]>",Trad.ESP)+"</ESP>", "")+IIF(Trad.FRA<>"", "     <FRA>"+IIF(IsTagInString(Trad.FRA, "<br>"),cdata_start+Trad.FRA+cdata_end+"]>",Trad.FRA)+"</FRA>", "")+IIF(Trad.DEU<>"", "     <DEU>"+IIF(IsTagInString(Trad.DEU, "<br>"),cdata_start+Trad.DEU+cdata_end+"]>",Trad.DEU)+"</DEU>", "")+" <Orig_str> "
	<Extension()>
	Public Function Eval_Static_Set_tags_to_replace_K_12524(ByVal Main As RDCompiledProcess) As Object
		return IIF(Trad.ITA<>"", "     <ITA>"+IIF(IsTagInString(Trad.ITA, "<br>"),cdata_start+Trad.ITA+cdata_end+"]>",Trad.ITA)+"</ITA>", "")+IIF(Trad.ENG<>"", "     <ENG>"+IIF(IsTagInString(Trad.ENG, "<br>"),cdata_start+Trad.ENG+cdata_end+"]>",Trad.ENG)+"</ENG>", "")+IIF(Trad.ESP<>"", "     <ESP>"+IIF(IsTagInString(Trad.ESP, "<br>"),cdata_start+Trad.ESP+cdata_end+"]>",Trad.ESP)+"</ESP>", "")+IIF(Trad.FRA<>"", "     <FRA>"+IIF(IsTagInString(Trad.FRA, "<br>"),cdata_start+Trad.FRA+cdata_end+"]>",Trad.FRA)+"</FRA>", "")+IIF(Trad.DEU<>"", "     <DEU>"+IIF(IsTagInString(Trad.DEU, "<br>"),cdata_start+Trad.DEU+cdata_end+"]>",Trad.DEU)+"</DEU>", "")+" <Orig_str> "
	End Function

	'OriginalExpression: 'StrBefore(xml_crm,      "<Orig_str>"+IIF(IsTagInString(MetaTrad.ORIGIN_ID_0, "<br>"),cdata_start+MetaTrad.ORIGIN_ID_0+cdata_end+"]>", MetaTrad.ORIGIN_ID_0)+"</Orig_str>")+ "<Orig_str>"+ StrAfter(     StrAfter(         xml_crm,          "<Orig_str>"+IIF(IsTagInString(MetaTrad.ORIGIN_ID_0, "<br>"),cdata_start+MetaTrad.ORIGIN_ID_0+cdata_end+"]>", MetaTrad.ORIGIN_ID_0)+"</Orig_str>"),      "<Orig_str>" )  
	<Extension()>
	Public Function Eval_Static_Set_final_xml_K_12525(ByVal Main As RDCompiledProcess) As Object
		return StrBefore(xml_crm,      "<Orig_str>"+IIF(IsTagInString(MetaTrad.ORIGIN_ID_0, "<br>"),cdata_start+MetaTrad.ORIGIN_ID_0+cdata_end+"]>", MetaTrad.ORIGIN_ID_0)+"</Orig_str>")+ "<Orig_str>"+ StrAfter(     StrAfter(         xml_crm,          "<Orig_str>"+IIF(IsTagInString(MetaTrad.ORIGIN_ID_0, "<br>"),cdata_start+MetaTrad.ORIGIN_ID_0+cdata_end+"]>", MetaTrad.ORIGIN_ID_0)+"</Orig_str>"),      "<Orig_str>" )  
	End Function

	'OriginalExpression: 'CRM_TradPath
	<Extension()>
	Public Function Eval_Static_FileName_K_12528(ByVal Main As RDCompiledProcess) As Object
		return CRM_TradPath
	End Function

	'OriginalExpression: 'final_xml
	<Extension()>
	Public Function Eval_Static_StringText_K_12528(ByVal Main As RDCompiledProcess) As Object
		return final_xml
	End Function



End Module
