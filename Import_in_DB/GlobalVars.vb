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
End Class

Public Class SupportRowTagsType
		Public [ORIGIN_ID_0] As string
		Public [ORIGIN_ID_1] As string
End Class



#End Region

#Region " -- Process Variables Table -- "

	Public [ConnStr_FUSION] As string
	Public [ConnStr_LOCAL] As string
	Public [ConnStr_PDM] As string
	Public [MetaTradTable] As New Generic.List(Of MetaTradType)
	Public [MetaTrad] As New MetaTradType
	Public [TradTable] As New Generic.List(Of TradType)
	Public [Trad] As New TradType
	Public [SupportTableTags] As New Generic.List(Of SupportRowTagsType)
	Public [SupportRowTags] As New SupportRowTagsType
	Public [queryTrads] As string
	Public [queryFindTags] As string
	Public [queryMetaTrads] As string
	Public [i] As integer
	Public [baseIDX] As integer
	Public [FusionInfoTables] As New Generic.List(Of FusionTableKeysType)
	Public [FusionTableKeys] As New FusionTableKeysType
	Public [Languages] As New Generic.List(Of string)
	Public [_language] As string
	Public [afterSelect] As string
	Public [condITA] As string
	Public [condENG] As string
	Public [condESP] As string
	Public [condFRA] As string
	Public [condDEU] As string


#End Region

End Module


