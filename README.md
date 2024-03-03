# Progetto N. 1 Libreria
## Istruzioni per l'avvio:
1. Clonare al repository
2. Importare il database:
   1. Il file di backup si trova nella cartella /Libreria/DumpDb
   2. Andare su Microsoft SQL Managment Studio e una volta acceduto al proprio server SQL fare tasto destro sulla cartella Databases e selezionare Import Data Tier Application come nello screenshot

 ![Import Data tier application](https://github.com/Raccispini/Libreria/blob/master/Libreria/Screenshoot/dumpdb.png)
 
   5. Nella seconda schermata selezionare il file di backup menzionato nel punto (i) ed andare avanti
   6. Una volta completato il processo il database è stato ripristinato
3. Cambiare la stringa di connessione al server
    Nell file /Libreria/appsetting.json sotto il valore ConnectionStrings>DefaultString andare a cambiare la stringa con i seguenti dati:
   - data source: indirizzo del server sql
   - Initial catalog: il nome del database appena ripristinato
   - User id : nome utente per accedere al server
   - Password : password per accedere al server

## Utilizzo API
Per poter utilizzare le API è necessario effettuare il login con l'apposita chiamata. Nel database è già inserito un utente Username :"admin", Password :"admin", altrimenti può crearne uno nuovo con la rotta /signup
