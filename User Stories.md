Creare Ticket (Utilizator)

Descriere: Ca utilizator, vreau să pot crea un ticket pentru a raporta o problemă și a solicita ajutor de la echipa IT, astfel încât să pot obține suport pentru problemele întâmpinate.

Taskuri:

    Frontend: Creează un formular de creare ticket care să permită utilizatorului să adauge informații esențiale:
        Titlul ticketului
        Descrierea detaliată a problemei
        Selectarea categoriei (ex: Hardware, Software, Rețea, etc.)
        Validare pentru câmpuri obligatorii

    Backend: Creează un endpoint POST /api/tickets pentru a salva ticketul în baza de date. Validarea datelor trimise de frontend:
        Verifică existența unui titlu valid, descriere și categorie.
        Verifică legăturile cu tabelele Category și Users.

    Baza de date: Asigură-te că ticketul este corect salvat în tabela Tickets și că relațiile între Users și Categories sunt respectate.

    Testare: Verifică că ticketul a fost salvat corect în baza de date și că toate câmpurile sunt valide.





Vizualizare Tickete (Administrator)

Descriere: Ca administrator, vreau să pot vizualiza toate ticketele create în sistem, astfel încât să pot urmări progresul lor și să administrez eficient resursele IT.

Taskuri:

    Frontend: Creează o pagină de vizualizare a ticketelor existente, care să afișeze informații esențiale (titlu, descriere, categorie, status, utilizator asociat).

    Backend: Creează un endpoint GET /api/tickets pentru a aduce toate ticketurile din baza de date. Permite filtrarea acestora după status.

    Testare: Testează că pagina afișează corect toate ticketelor și că administratorul poate vizualiza informațiile corect.