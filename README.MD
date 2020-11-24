# RD per Traduzioni

## Logica 
La gestione delle traduzioni è così strutturata:
1. Import in due tabelle di supporto (TRADS e METATRADS) tutte le traduzioni fatte e da fare che provengono da diversi database e diversi file
2. Fase di aggiornamento/modifica o consultazione utilizzando solo le tabelle di supporto
3. Export delle modifche da queste tabelle ai database e file di origine 

## Setup
Per testare in locale gli RDX sviluppati per la gestione delle traduzioni bisognerà seguire i seguenti passaggi:
- da Microsoft SQL Server Management Studio assicurarsi di avere un DB che si chiama MBKOffline e creare un DB che si chiama FusionTest e uno che si chiama PDMTest
- settare correttamente le connection string ai DB FuionTest e PDMTest locali nel file ["Settings.ini"](Settings.ini)
- lanciare il file rdx ["migrator_caller.rdx"](migrator_caller.rdx) che in circa 35 minuti creerà e clonerà i dati necessari dalle tabelle dei database sul server di test
- nel frattempo copiare il file ["Grid_FixHeader.css"](Grid_FixHeader.css) nel percorso di Rule Designer locale sotto la cartella "WebPlayer\CSS", ad esempio "C:\Program Files (x86)\RuleDesigner\RD Configurator Fusion\WebPlayer\CSS"
- quando l'importazione sarà conclusa, comparirà un messaggio che indicherà quanti secondi ha impiegato
- da questo momento sarà possibile avviare il file ["Home.rdx"](Home.rdx) e testare in modalità admin (o forzando un altro tipo di utente dal codice) la consultazione e la modifica delle traduzioni

## Note sull'esecuzione
- Quando un utente è collegato in modalità "modifica", chiunque arrivi dopo si collegherà automaticamente in modalità "lettura"
- L'import dei dati dalle tabelle sui DB locali FusionTest e PDMTest  avviene sempre quando non c'è nessun utente collegato in modifica e dura qualche secondo, se c'è già un utente in modifica, non avviene e l'utente in lettura vedrà i dati già importanti dall'utente in modifica
- La modalità "modifica" resterà bloccata finché l'utente in modifica premerà il pulsante "END" e decidera di salvare o meno le sue modifiche
- Solo gli utenti "admin" (GruoupID=1) possono selezionare e cancellare un riga
- In modalità "lettura" non sono visibili i pulsanti di modifica
- Filtri e ordinamenti della WebGrid avvengono sulla stuttura dati di RuleDesigner, non con query SQL
- Si può aggiungere nuove traduzioni, ma queste andranno solo nella tabella "LANGUAGE" di FusionTest
- L'esportazione delle traduzioni modificate può essere eseguita da qualsiasi tipo di utente se sceglie di salvare dopo aver premuto "END"
- Tutte le modifiche apportate verranno esportate nei file e nei database locali 
- Si può testare il merge del file xml relativo al CRM delle traduzioni originali fornite da RuleDesigner con quelle custom esegueendo ["merge_update_xml.rdx"](merge_update_xml.rdx)

## Altre note
- Sono stati riscontrati diversi problemi, soprattutto nell'esecuzione delle dll generate dai file rdx. Tutti quelli riscontrati sono elencati nel file ["errori_trovati.md"](errori_trovati.md)
- Le dll rendono l'esecuzione del codice molto più veloce, purtroppo è non è stato possibile generarla per il file ["Export_From_Db.rdx"](Export_From_Db.rdx) poiché non sono riuscito a trovare un soluzione efficace che sostiuisse il nodo che mi da l'errore
- L'esecuzione di ["Export_From_Db.rdx"](Export_From_Db.rdx) è abbastanza veloce per una quantità ridotta di modifiche, ma presenta un vero collo di bottiglia nella modifica dei file [".json"]("/Graphical%20Studio") che arrivano da Graphical Studio poichè in RuleDesigner non è presente una gestione dei json in quanto tali, ma solo come testi da leggere e inserire in una lista di strutture "chiave-valore", che quindi bisogna scorrere fino a trovare l'occorrenza giusta e modificarla (per 5 file) 