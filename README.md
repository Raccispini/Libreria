# Progetto N. 1 Libreria
## Istruzioni per l'avvio:
1. Clonare al repository
2. Importare il database:
   1. Il file di backup si trova nella cartella /Libreria/DumpDb
   2. Andare su Microsoft SQL Managment Studio e una volta acceduto al proprio server SQL fare tasto destro sulla cartella Databases e selezionare Import Data Tier Application come nello screenshot
   3. Nella seconda schermata selezionare il file di backup menzionato nel punto (i) ed andare avanti
   4. Una volta completato il processo il database è stato ripristinato
3. Cambiare la stringa di connessione al server
    Nell file /Libreria/appsetting.json sotto il valore ConnectionStrings>DefaultString andare a cambiare la stringa con i seguenti dati:
   - data source: indirizzo del server sql
   - Initial catalog: il nome del database appena ripristinato
   - User id : nome utente per accedere al server
   - Password : password per accedere al server
  
