# IMPORT_IN_DB:
- tutti i nodi "Insert DB Struct" non funzionano quando viene chiamata la dll, invece da rdx si --> bisogna usare un "Execute SQL Statement" e scrivere a mano la query
- non è possibile controllare con la funzione "IsEmpty()" se è stata valorizzata una variabile con la dll, da rdx invece funziona --> bisogna fare il controllo che la variabile sia ="" o <>""
- all'interno della dll non è possibile eseguire la funzione "FileLastWriteDate()" prima di aver letto il file, mentre nell'rdx si

# MigrateToLocalDB:
- funzione Count(string[]) e Count(string[][]) vengono compilate quando viene generata la dll ma quando viene eseguita da errore di "riferimento ad oggetto non trovato"

# Web_Interface:
- filtro della web grid (captionfilter) non resta nella visualizzazione -> ho fatto un bottone di backup per sapere su cosa è stato fatto il filtro e per rimuoverlo + gestione di filtri multipli
- SortListOfStructs() non funziona se il campo scelto è "NEW" - Evaluation Error: SortListOfStructs(): '(' expected

# Export_from_DB:
- funzione ReplaceFromTo() il tag "TO" non è necessariamente successivo a quello "FROM"
- errore nello scrivere la fine "]]>" di una stringa che inizia per "<[CDATA["
- dll da errori come  "Cast non valido dalla stringa "SELECT * FROM METATRADS WHERE ID" al tipo 'Double'. Formato della stringa di input non corretto" in un nodo "Select DB Structured" dove la query è "SELECT * FROM METATRADS WHERE IDX="+Trad.IDX con Trad.IDX tipo "integer"