Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports RuleDesigner.Configurator.Core.RDCoreCompiler.BasicFunctionsProxy

Module StaticExpressions

    'This placeholder is for static expression table
	'OriginalExpression: 'PDMServer
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_45(ByVal Main As RDCompiledProcess) As Object
		return PDMServer
	End Function

	'OriginalExpression: 'PDMLocal
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_46(ByVal Main As RDCompiledProcess) As Object
		return PDMLocal
	End Function

	'OriginalExpression: '"IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='CODVAL')" +CreateCODVAL+" ELSE TRUNCATE TABLE CODVAL"
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_44(ByVal Main As RDCompiledProcess) As Object
		return "IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='CODVAL')" +CreateCODVAL+" ELSE TRUNCATE TABLE CODVAL"
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'i>1
	<Extension()>
	Public Function Eval_Static_CondExp1_K_258(ByVal Main As RDCompiledProcess) As Object
		return i>1
	End Function

	'OriginalExpression: 'query_insert+","
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_268(ByVal Main As RDCompiledProcess) As Object
		return query_insert+","
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'row(i-1)<>""
	<Extension()>
	Public Function Eval_Static_CondExp1_K_236(ByVal Main As RDCompiledProcess) As Object
		return row(i-1)<>""
	End Function

	'OriginalExpression: 'query_insert+"'"+StrSql(row(i-1))+"'"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_246(ByVal Main As RDCompiledProcess) As Object
		return query_insert+"'"+StrSql(row(i-1))+"'"
	End Function

	'OriginalExpression: 'query_insert+"''"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_257(ByVal Main As RDCompiledProcess) As Object
		return query_insert+"''"
	End Function

	'OriginalExpression: 'query_insert+")"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_288(ByVal Main As RDCompiledProcess) As Object
		return query_insert+")"
	End Function

	'OriginalExpression: 'query_insert
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_58(ByVal Main As RDCompiledProcess) As Object
		return query_insert
	End Function

	'OriginalExpression: 'FusionServer
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_79(ByVal Main As RDCompiledProcess) As Object
		return FusionServer
	End Function

	'OriginalExpression: 'FusionLocal
	<Extension()>
	Public Function Eval_Static_ConnectionString_K_81(ByVal Main As RDCompiledProcess) As Object
		return FusionLocal
	End Function

	'OriginalExpression: '"IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='"+F_table+"') " +FusionCreateTables(i-1)+"  ELSE TRUNCATE TABLE "+F_table
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_97(ByVal Main As RDCompiledProcess) As Object
		return "IF NOT EXISTS (SELECT *             FROM INFORMATION_SCHEMA.TABLES             WHERE TABLE_TYPE='BASE TABLE'             AND TABLE_NAME='"+F_table+"') " +FusionCreateTables(i-1)+"  ELSE TRUNCATE TABLE "+F_table
	End Function

	'Condition for group: IFTHENELSE
	'OriginalExpression: 'F_table="dm_folder_001"
	<Extension()>
	Public Function Eval_Static_CondExp1_K_178(ByVal Main As RDCompiledProcess) As Object
		return F_table="dm_folder_001"
	End Function

	'Condition for group: IFTHENELSE
	'OriginalExpression: 'F_table="dm_folder_prop_001"
	<Extension()>
	Public Function Eval_Static_CondExp2_K_178(ByVal Main As RDCompiledProcess) As Object
		return F_table="dm_folder_prop_001"
	End Function

	'Condition for group WHILE
	'OriginalExpression: 'endwhile
	<Extension()>
	Public Function Eval_Static_CondExp1_K_219(ByVal Main As RDCompiledProcess) As Object
		return endwhile
	End Function

	'OriginalExpression: '"SELECT * FROM "+F_table+" WHERE DMCODEID>"+RDToString(MinCounter)+" AND DMCODEID<"+RDToString(MaxCounter)
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_91(ByVal Main As RDCompiledProcess) As Object
		return "SELECT * FROM "+F_table+" WHERE DMCODEID>"+RDToString(MinCounter)+" AND DMCODEID<"+RDToString(MaxCounter)
	End Function

	'OriginalExpression: 'IIF(k=0, True, False)
	<Extension()>
	Public Function Eval_Static_Set_endwhile_K_225(ByVal Main As RDCompiledProcess) As Object
		return IIF(k=0, True, False)
	End Function

	'OriginalExpression: 'MaxCounter
	<Extension()>
	Public Function Eval_Static_Set_MinCounter_K_226(ByVal Main As RDCompiledProcess) As Object
		return MaxCounter
	End Function

	'OriginalExpression: 'MaxCounter+10000
	<Extension()>
	Public Function Eval_Static_Set_MaxCounter_K_228(ByVal Main As RDCompiledProcess) As Object
		return MaxCounter+10000
	End Function

	'OriginalExpression: '"SET DATEFORMAT dmy;  INSERT INTO "+F_table+" VALUES("
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_199(ByVal Main As RDCompiledProcess) As Object
		return "SET DATEFORMAT dmy;  INSERT INTO "+F_table+" VALUES("
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'j>1
	<Extension()>
	Public Function Eval_Static_CondExp1_K_303(ByVal Main As RDCompiledProcess) As Object
		return j>1
	End Function

	'OriginalExpression: 'query_insert+","
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_301(ByVal Main As RDCompiledProcess) As Object
		return query_insert+","
	End Function

	'OriginalExpression: 'query_insert+IIF(field<>"","'"+StrSql(field)+"'", "null")
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_200(ByVal Main As RDCompiledProcess) As Object
		return query_insert+IIF(field<>"","'"+StrSql(field)+"'", "null")
	End Function

	'OriginalExpression: 'query_insert+")"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_309(ByVal Main As RDCompiledProcess) As Object
		return query_insert+")"
	End Function

	'OriginalExpression: 'query_insert
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_202(ByVal Main As RDCompiledProcess) As Object
		return query_insert
	End Function

	'OriginalExpression: '"SELECT * FROM "+F_table
	<Extension()>
	Public Function Eval_Static_SelectQuery_K_188(ByVal Main As RDCompiledProcess) As Object
		return "SELECT * FROM "+F_table
	End Function

	'OriginalExpression: '"SET DATEFORMAT dmy;  INSERT INTO "+F_table+" VALUES("
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_103(ByVal Main As RDCompiledProcess) As Object
		return "SET DATEFORMAT dmy;  INSERT INTO "+F_table+" VALUES("
	End Function

	'Condition for group IFTHENELSE
	'OriginalExpression: 'j>1
	<Extension()>
	Public Function Eval_Static_CondExp1_K_319(ByVal Main As RDCompiledProcess) As Object
		return j>1
	End Function

	'OriginalExpression: 'query_insert+","
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_317(ByVal Main As RDCompiledProcess) As Object
		return query_insert+","
	End Function

	'Condition for group: IFTHENELSE
	'OriginalExpression: 'F_table="pr_project_001"
	<Extension()>
	Public Function Eval_Static_CondExp1_K_328(ByVal Main As RDCompiledProcess) As Object
		return F_table="pr_project_001"
	End Function

	'Condition for group: IFTHENELSE
	'OriginalExpression: 'j=26
	<Extension()>
	Public Function Eval_Static_CondExp2_K_328(ByVal Main As RDCompiledProcess) As Object
		return j=26
	End Function

	'OriginalExpression: 'StrReplace(field, ",", ".")
	<Extension()>
	Public Function Eval_Static_Set_field_K_338(ByVal Main As RDCompiledProcess) As Object
		return StrReplace(field, ",", ".")
	End Function

	'OriginalExpression: 'query_insert+IIF(field<>"","'"+StrSql(field)+"'", IIF(j=35, "''", "null"))
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_104(ByVal Main As RDCompiledProcess) As Object
		return query_insert+IIF(field<>"","'"+StrSql(field)+"'", IIF(j=35, "''", "null"))
	End Function

	'OriginalExpression: 'query_insert+")"
	<Extension()>
	Public Function Eval_Static_Set_query_insert_K_311(ByVal Main As RDCompiledProcess) As Object
		return query_insert+")"
	End Function

	'OriginalExpression: 'query_insert
	<Extension()>
	Public Function Eval_Static_SqlStatement_K_106(ByVal Main As RDCompiledProcess) As Object
		return query_insert
	End Function



End Module
