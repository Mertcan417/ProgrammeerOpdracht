# Welkom!

Voor de ontwikkeling van de backend is Postman gebruikt om de API-endpoints te testen.
De bijbehorende collectie bevindt zich in de map /Postman als een .json bestand. Dit bestand kan geïmporteerd worden in Postman om de API-endpoints te testen.

## Doel van het project
Het doel van dit project is om zorginstellingen in staat te stellen documenten uit te wisselen.
Onder "document" wordt verstaan:
- Medicatiegegevens
- Allergie-informatie van de patiënt
- Verwijsbrieven

Met deze definitie is de applicatie opgezet.

## Domeinmodel

Het domeinmodel bestaat uit de volgende klassen:
- **Document**
- **DocumentType**
- **DocumentContent**
- **AllergyContent**
- **MedicationContent**
- **ReferralLetterContent**
- **Patient**
- **Medicine**

**Document** is een klasse die uit de volgende informatie bestaat:
- Id (Id van het document)
- PatientId (Id van de patient)
- Sender (Zorginstelling die het document verstuurt)
- Receiver (Zorginstelling die het document ontvangt)
- (Document) Type (Het type document: Verwijsbrief, Allergieoverzicht, Medicatiegebruik)
- (Document) Content (inhoud van het document, dit varieert per type document. Bij een verwijsbrief wordt de reden en beschrijving ingevuld, bij een allergieoverzicht een lijst met allergien, bij medicatiegebruik een lijst met medicijnen die door de patient worden gebruikt)

- **DocumentType** – is een enum en beschrijft of het document een verwijzing betreft, medische gegevens of allergie-informatie van de patiënt.
- **DocumentContent** – is een abstracte klasse voor de inhoud van het document, de basis voor verschillende documenttypes, waarbij de structuur grotendeels hetzelfde is maar de inhoud verschilt.

De abstracte klasse wordt afgeleid door:
- **AllergyContent** – bevat informatie over de allergieën van de patiënt
- **MedicationContent** – bevat een lijst van medicijnen die de patiënt gebruikt
- **ReferralLetterContent** – bevat attributen voor de reden van verwijzing en beschrijving

## Architectuur
Het project volgt een vierlagenarchitectuur:
Domeinmodel – bevat geen businesslogica
Services – methodes voor het aanmaken en opvragen van documenten
Repositories – methodes om gegevens in-memory op te slaan
Controllers – API-endpoints en foutafhandeling

Dependency Injection wordt gebruikt in Program.cs om interfaces in services en repositories te koppelen aan de juiste implementatie.
Voor de opslag wordt een in-memory lijst gebruikt. Daarnaast is er dummy-data voor patiënten als seed toegevoegd.

## Ontwerpkeuzes

- De Document-klasse verwijst niet direct naar de Patient-klasse, maar gebruikt de patient ID. Dit vergroot de flexibiliteit.
- Voor het aanmaken van documenten via de controller wordt een Data Transfer Object (DTO) gebruikt, voor het terugsturen van data naar de client wordt dit aangemoedigd om te gebruiken. Dit wordt momenteel nog niet gedaan voor het opvragen van documenten. Er wordt namelijk
  bij het opvragen van documenten nog overbodige informatie verstuurd naar de client.
- Er wordt een Factory Design Pattern toegepast om bij het kiezen van een documenttype automatisch het juiste document aan te maken.
- Validatie vindt plaats in de DTO, bijvoorbeeld om te controleren of de patient ID bestaat bij het aanmaken van een verwijsbrief.
- Zorginstellingen kunnen bepaalde documentgegevens (medicatiegebruik, verwijsbrief, allergieinformatie) van de patient inzien via API route /documents. Hiervoor kunnen er query parameters worden gebruikt.
- Foutafhandeling wordt succesvol opgevangen via exceptions in de map /controllers/exceptions en vanuit de controller in de vorm van een HTTP Status code, zoals 404, 400 teruggestuurd.

## Logging
Bij elke succesvolle document uitwisseling (aanmaak van een document) wordt er met ILogger gelogd in de API controller.

## API Endpoints
-- Documenten ophalen
Endpoint: /documents
Beschikbare query parameters:
patientId
receiver
documentType

Bij het niet opgeven van query parameters worden alle documenten weergegeven.
Bij het opvragen van een specifiek document (verwijsbrief, medicatiegegevens, allergie-informatie) kan filtering plaatsvinden op patiënt ID, ontvangend ziekenhuis en documenttype.

-- Aanmaken van documenten (verwijzingen, medicatiegegevens, allergieoverzicht)
Endpoint: /documents

Bij het aanmaken van een document wordt de patient id meegegeven. Deze moet bestaan, zo niet ontvangt de client een 404 met een duidelijke foutmelding.
Daarnaast is er ook een sender, receiver en het document type met de behorende document content.

Voorbeeld van API request in JSON voor het aanmaken van een verwijsbrief naar Hospital B:
{
  "PatientId": "c4f0c136-9eeb-4437-9743-f389db6aadbf",
  "Sender": "Hospital A",
  "Receiver": "Hospital B",
  "Type": "ReferralLetter",
  "Content": {
    "Reason": "Sick!",
    "Description":"Patient suffers"
  }
}

-- Patienten inzien
Endpoint: /patients

Deze endpoint is gebruikt tijdens development voor het inzien van alle patienten en het selecteren van de juiste id's bij het aanmaken van een document.


