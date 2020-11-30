# IMPORT_IN_DB:
- tutti i nodi "Insert DB Struct" non funzionano quando viene chiamata la dll, invece da rdx si --> bisogna usare un "Execute SQL Statement" e scrivere a mano la query
- non è possibile controllare con la funzione "IsEmpty()" se è stata valorizzata una variabile con la dll, da rdx invece funziona --> bisogna fare il controllo che la variabile sia ="" o <>""
- all'interno della dll non è possibile eseguire la funzione "FileLastWriteDate()" prima di aver letto il file, mentre nell'rdx si

# MigrateToLocalDB:
- funzione Count(string[]) e Count(string[][]) vengono compilate quando viene generata la dll ma quando viene eseguita da errore di "riferimento ad oggetto non trovato"

# Web_Interface:
- SortListOfStructs() non funziona se il campo scelto è "NEW" - Evaluation Error: SortListOfStructs(): '(' expected --> ho dovuto rinominare il campo con "IS_NEW"
- Nella grid editabile non è possibile settare un campo di una riga non editabile a partire da una condizione e non è possibile sapere quale campo è stato appena modificato o selezionato senza forzare l'autocommit

# Export_from_DB:
- funzione ReplaceFromTo() il tag "TO" non è necessariamente successivo a quello "FROM"
- errore nello scrivere la fine "]]>" di una stringa che inizia per "<[CDATA[", l'ho separato in variabili
- dll da errori come  "Cast non valido dalla stringa "SELECT * FROM METATRADS WHERE ID" al tipo 'Double'. Formato della stringa di input non corretto" in un nodo "Select DB Structured" dove la query è "SELECT * FROM METATRADS WHERE IDX="+Trad.IDX con Trad.IDX tipo "integer", anche provando ad usare un "Execute SQL Statement" al suo posto viene fornito un errore generico "DBG: RUNDLL" sul nodo