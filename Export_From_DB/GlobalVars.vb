Imports System
Imports System.Collections
Imports System.Reflection
Imports RuleDesigner.Configurator.Core.RDCoreCompiler
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.CompilerUtil

Public Module GlobalVars

#Region " -- Process Parameters Table -- "



#End Region

#Region " -- Process Types Table -- "

Public Class TradType
		Public [IDX] As integer
		Public [ITA] As string
		Public [ENG] As string
		Public [ESP] As string
		Public [FRA] As string
		Public [DEU] As string
		Public [UPDATED] As boolean
		Public [NEW] As boolean
End Class

Public Class FusionTableKeysType
		Public [DB] As string
		Public [TableName] As string
		Public [ID] As string
		Public [ID2] As string
		Public [Fields] As string
End Class

Public Class MetaTradType
		Public [IDX] As integer
		Public [ORIGIN_DB] As string
		Public [ORIGIN_TABLE] As string
		Public [ORIGIN_ID_0] As string
		Public [ORIGIN_ID_1] As string
		Public [LAST_UPDATE] As date
End Class

Public Class SupportRowTagsType
		Public [ORIGIN_ID_0] As string
		Public [ORIGIN_ID_1] As string
End Class

Public Class kvType
		Public [key] As string
		Public [value] As string
End Class



#End Region

#Region " -- Process Variables Table -- "

	Public [ConnStr_FUSION] As string
	Public [ConnStr_LOCAL] As string
	Public [ConnStr_PDM] As string
	Public [GS_TradPath] As string
	Public [CRM_TradPath] As string
	Public [IniFilePath] As string
	Public [MetaTradTableToUpdate] As New Generic.List(Of MetaTradType)
	Public [MetaTradTableToDelete] As New Generic.List(Of MetaTradType)
	Public [MetaTrad] As New MetaTradType
	Public [TradTableToUpdate] As New Generic.List(Of TradType)
	Public [TradTableToDelete] As New Generic.List(Of TradType)
	Public [TradTableToAdd] As New Generic.List(Of TradType)
	Public [Trad] As New TradType
	Public [SupportTableTags] As New Generic.List(Of SupportRowTagsType)
	Public [SupportRowTags] As New SupportRowTagsType
	Public [TimeStamp] As date
	Public [Languages] As New Generic.List(Of string)
	Public [_language] As string
	Public [i] As integer
	Public [array_xml] As New Generic.List(Of string)
	Public [FUSION] As boolean
	Public [PDM] As boolean
	Public [GRAPHICAL_STUDIO] As boolean
	Public [CRM] As boolean
	Public [LANGUAGE] As boolean
	Public [ba_properties] As boolean
	Public [ba_prop_value] As boolean
	Public [ba_activitytype] As boolean
	Public [ba_activity_category] As boolean
	Public [wo_state] As boolean
	Public [pr_item] As boolean
	Public [pr_type] As boolean
	Public [dm_class] As boolean
	Public [dm_folder_001] As boolean
	Public [ba_source] As boolean
	Public [JSONtext] As string
	Public [JSONFile] As string
	Public [kvTable] As New Generic.List(Of kvType)
	Public [kvRow] As New kvType
	Public [xml_crm] As string
	Public [final_xml] As string
	Public [tags_to_replace] As string
	Public [cdata_start] As string
	Public [cdata_end] As string


#End Region

End Module


