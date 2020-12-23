# RD per Traduzioni

## Logica 
La gestione delle traduzioni è così strutturata:
1. Import in due tabelle di supporto (TRADS e METATRADS) tutte le traduzioni fatte e da fare che provengono da diversi database e diversi file
2. Fase di aggiornamento/modifica o consultazione utilizzando solo le tabelle di supporto
3. Export delle modifiche da queste tabelle ai database e file di origine 

## Setup
Per testare in locale gli RDX sviluppati per la gestione delle traduzioni bisognerà seguire i seguenti passaggi:
- da Microsoft SQL Server Management Studio assicurarsi di avere un DB che si chiama MBKOffline e creare un DB che si chiama FusionTest e uno che si chiama PDMTest
- settare correttamente le connection string ai DB FuionTest e PDMTest locali nel file ["Settings.ini"](Settings.ini)
- lanciare il file rdx ["migrator_caller.rdx"](migrator_caller.rdx) che in circa 35 minuti creerà e clonerà i dati necessari dalle tabelle dei database sul server di test in locale
- nel frattempo copiare tutti i file contenuti nella cartella ["CSS"](CSS/) e nella cartella ["Button_Icons"](Button_Icons/) nel percorso di Rule Designer locale sotto la cartella "WebPlayer\Modulblok", ad esempio "C:\Program Files (x86)\RuleDesigner\RD Configurator Fusion\WebPlayer\Modulblok"
- quando l'importazione sarà conclusa, comparirà un messaggio che indicherà quanti secondi ha impiegato
- da questo momento sarà possibile avviare il file ["Home.rdx"](Home.rdx) e testare in modalità admin (o forzando un altro tipo di utente dal codice) la consultazione e la modifica delle traduzioni

## Note sull'esecuzione
- Quando un utente è collegato in modalità "modifica", chiunque arrivi dopo vedrà chi è l'utente collegato e, se è un amministratore può sceliere di liberare il lock ed entrare comunque in modifica, altrimenti  si collegherà automaticamente in modalità "lettura"
- È stato gestita la possibilità di incorrere in un errore durante la modifica, in questo caso verrà automaticamento liberato il lock.
- Se l'utente collegato in modifica è lo stesso di quello che si sta collegando, entrerà direttamente in modifica, questo può accadere se l'utente in questione non è uscito correttamente
- Il dateformat delle scritture a database è stato gestito da funzioni sql e predefinite di RuleDesign.
- L'import dei dati dalle tabelle sui DB locali FusionTest e PDMTest  avviene sempre quando non c'è nessun utente collegato in modifica e dura qualche secondo, se c'è già un utente in modifica, non avviene e l'utente in lettura vedrà i dati già importanti dall'utente in modifica
- Solo gli utenti del gruppo admin possono importare le traduzioni provenienti dalla tabella CODVAL del PDM
- La modalità "modifica" resterà bloccata finché l'utente in modifica premerà il pulsante "EXIT" e decidera di salvare o meno le sue modifiche
- Solo gli utenti "admin" (GruoupID=1) possono cancellare una riga e vedere database, tabelle/file e tags di origine
- In modalità "lettura" non sono visibili i pulsanti di modifica
- Ad ogni avvio, l'interfaccia di default è la ["v0"](Web_Interface_v0.rdx) che è una WebSummaryInput, la quale permette la visualizzazione contemporaneamente di una WebSummaryGrid e una WebInput. Ad ogni click su una riga della griglia verrà popolata la WebInput editabile e comparirà un pulsante in alto per salvare le modifiche direttamente a database.
- È presente un pulsante che permette di cambiare interfaccia con la ["v1"](Web_Interface_v1.rdx) che, invece, è una WebGrid editabile le cui modifiche delle celle non si riflettono sul database fino al momento della pressione di un altro pulsante (aggiunta, cancellazione, salvataggio, uscita, ordinamento e filtro), questo è abbastanza dispendioso in termini di tempo se la lista non è filtrata poichè è necessario fare un "ListDiff()" tra la lista originale e quella appena aggiornata. Basta premere "EXIT" per tornare alla visualizzazione predefinita.
- Filtri e ordinamenti della WebGrid avvengono sulla stuttura dati di RuleDesigner
- Gli amministratri possono aggiungere nuove traduzioni, ma queste andranno solo nella tabella "LANGUAGE" di FusionTest
- L'esportazione delle traduzioni modificate può essere eseguita da qualsiasi tipo di utente se sceglie di salvare dopo aver premuto "END" 
- Il merge del file xml relativo al CRM delle traduzioni originali fornite da RuleDesigner con quelle custom avviene nel file ["merge_update_xml.rdx"](merge_update_xml.rdx) chimato da ["Export_From_DB.rdx"](Export_From_DB.rdx)
- Ogni qualvolta si desidererà ripristinare fie e tabelle originali in locale, basterà rieseguire ["migrator_caller.rdx"](migrator_caller.rdx); copiare i file presenti in ["CRM/originals"](CRM/originals/) nella cartella ["CRM"](CRM/) e analogamente farlo con la cartella ["Graphical Studio"](Graphical%20Studio/)
- Sono presenti anche versioni della "Web_Interface":
  - La ["Web_Interface_MUI.rdx"](Web_Interface_MUI.rdx) è la versione sviluppata con le funzioni della "Modern UI", ancora in beta e non ancora utilizzabile, necessita dell'attivazione dell'IIS Mode
  - La ["Web_Interface_old_v0.rdx"](Web_Interface_old_v0.rdx) è la prima versione senza girglia editabile e con la maschera di modifica che si apre al click
- È stata gestita la paginazione per migliorare le perfomarmance di caricamento della WebGrid in entrambe le versioni dell'interfaccia
- Sono stati gestiti i pulsanti come strutture per poterci applicare le immagini e i tooltip
- La riga selezionata della WebSummary_Input viene colorata di verde
- ["Settings_locale.ini"](Settings_locale.ini) deve contenere le stringhe di connessione del pc locale mentre ["Settings.ini"](Settings.ini) contiene le stringhe di connessione dei server di test e produzione. La scelta dell'ambiente dipenda dall'url trovato dalla chiamata ad un file "Process.rdx" presente nella cartella PROCESSES/SYSTEM (dove anche questa cartella deve essere posizionata). La chiamata a questo processo non è necessaria se si lavora in ambiente locale con Settings_local

## Altre note
- Sono stati riscontrati diversi problemi, soprattutto nell'esecuzione delle dll generate dai file rdx. Tutti quelli riscontrati sono elencati nel file ["errori_trovati.md"](errori_trovati.md)
- Le dll rendono l'esecuzione del codice molto più veloce, purtroppo è non è stato possibile generarla per il file ["Export_From_Db.rdx"](Export_From_Db.rdx) poiché non sono riuscito a trovare un soluzione efficace che sostiuisse il nodo che mi da l'errore
- In ambiente di test e produzioni sono presenti due versioni diverse del software RuleDesigner, perciò la dll dell'import ["Import_in_DB.dll"](Import_in_DB.dll) generare su un server non funziona se copiata nell'altro, è necessario ricrearla dall'applicativo del server corrente. 
- L'esecuzione di ["Export_From_Db.rdx"](Export_From_Db.rdx) è abbastanza veloce per una quantità ridotta di modifiche, ma presenta un vero collo di bottiglia nella modifica dei file ["json"](Graphical%20Studio/) che arrivano da Graphical Studio poichè in RuleDesigner non è presente una gestione dei json in quanto tali, ma solo come testi da leggere e inserire in una lista di strutture "chiave-valore", che quindi bisogna scorrere fino a trovare l'occorrenza giusta e modificarla (per 5 file) 
