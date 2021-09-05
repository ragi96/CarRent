Teschnische Schulden
=================
1. Momentan wird für das DTO -> Objekt Mapping der Automapper oder ein eigener Mapper verwendet, was ich als schlecht empfinden, deshalb müsste man es umbauen, damit nur noch eine Mapping Technologie verwendet wird. 
2. Dazu könnte man noch die Unit-Tests weiter ausbauen.

Weiterentwicklung
=================
![Weiterentwicklung Icon](images/weiterentwicklung.png)

Die nächsten Erweiterungspunkten könnten unteranderem diese sein:

- Authentifizierung durch JWT-Token
- Login-Kontext für Kunden, damit der Kunde selbständig Autos reservieren kann
- Address Management, eine Kunde kann mehrere Addressen haben und diese selbständig verwalten