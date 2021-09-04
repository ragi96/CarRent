Einleitung
======================

Aufgabenstellung
-------------
Eine kleine Autovermietungssoftware ohne Oberfläche nur mit einer API zu erstellen.
Es soll ein neues Autovermietungssystem „CarRent“ erstellt werden. Das System soll aus Server-Teilen und optional einen Web-Client bestehen. 

* Die Daten sollen mittels «Repository Pattern» in eine Datenbank gespeichert werden können.
* Die Business Logik soll auf dem Backend laufen und REST APIs anbieten.
* Der Web-Client benutzt die REST API um die Funktionen auszuführen.


[Mehr Information](/documents/T01-Architecture-Mini-Projekt-Aufgabe.pdf)

Qualitätsziele
-------------
1. Performance: CarRent soll schnelle Antwortzeiten (<1 Sek.) und für parallele Anfragen in kleiner Anzahl ausgelegt sein
2. Installierbarkeit: CarRent soll einfach eingerichtet werden können.
3. Erweiterbarkeit: CarRent soll für zukünftige Erweiterungen offen sein.
4. Benutzbarkeit: CarRent soll automatisch mit einem Swagger.json und somit mit einer API-Dokumentation ausgestattet werden.

Stakeholder
-------------
| Roll                   | Erwartungen                                            |
| -----------------------| ------------------------------------------------------ |
| Sachbearbeiter         | Ein System zur Verwaltung der Autovermietung           | 
| Kunde                  | Einfache Bedienung, schnelles Automieten und bezahlen  |
| Andere Entwickler      | Vollständig dokumentierte API                          |

Rahmenbedingungen
-------------
* VS2019 / .NET Core
* Nodejs
* NPM
* Sonarcloud