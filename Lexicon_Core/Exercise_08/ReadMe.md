# Practice on Delegates and Events

Övning 1: Delegat för beräkning: Delegater
Uppgift:
Skapa en metod som tar ett heltal och en delegat som bestämmer hur talet 
ska behandlas. Testa metoden med minst fyra olika beräkningar.

Övning 2: Delegater
1. Skapa en klass som har tre metoder med samma metodsignatur.
2. Skapa en delegat med samma metodsignatur.
3. Använd delegat-variabeln för att skriva ut resultatet för första metoden.
4. Ge de övriga metoderna som nytt värde till delegat-variabeln så att det gamla värdet försvinner.
5. Skapa nu i stället en multicast delegat som kör alla metoder på en gång.
6. Ta bort en av metoderna så att den inte körs.
7. Fråga: Vilken metod körs först?

Övning 3: Events
1. Skapa en klass som är publisher.
Den ska innehålla:
- En delegat.
- Ett event som använder typen som ni skapade i delegaten.
- En metod som kör ett event om ett visst villkor är uppfyllt.
- - Detta är bara för att ”trigga” ett event för test.
- I metoden ska ett event köras om ett visst villkor är uppfyllt.

2. Skapa en klass som är subscriber.
Den ska innehålla:
- En metod som har samma metodsignatur som delegaten.
- Denna kommer att kopplas till delegaten.
- Om ett event ”triggas” kommer denna metod att köras.
- Skriv ut något som visar att metoden körs.

Övning 4:
1. Skapa en delegat
1.1 Skapa två metoder med samma signatur som delegaten.
1.2 Lägg metoderna till delegaten så båda körs när delegaten körs.
3. Förklara hur Event och Delegate hänger ihop.

Övning 5:
Extra uppgift som är lite svårare
1. Skapa en Publisher-klass som aktiverar ett Event.
2. Skapa en Subscriber-klass som prenumererar på ett event.
3. När eventet triggas ska subscriber-klassen ta hand om Eventet och göra något med det (som att visa ett meddelande)
4. Du ska använda EventHandler.
5. Skapa ditt eget skräddarsydda meddelande med EventArgs.
