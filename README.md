# WestCoast Education

Solution to "Inlämningsuppgift CUA20G-Molndatabaser"



>>
WestCoast-Education behöver en IAAS lösning med en SQL-databas i molnet.
Detta är början på densamma.
>>
Alla funktioner som eftersöks i kravspec finns på plats.
Nästa steg är att slå isär tabeller för att minimera dataduplicering och effektivisera,
tex skulle man kunna gå mot att bryta isär 'Name' => 'Kategori' + 'Code' för att slippa
duplicering av Kurskategori i namnet på varje kurs som ingår i en kategori.

Vidare borde ett objekt/table skapas som har hand om registering på kurser samt betyg i densamma..
denna skulle kunna användas mot både användare och lärare...
kanske mha en hash på ett GUID för att på så sätt skapa en envängs koppling.. 
något som kan anonymisera enskilda betyg för utomstående om detta behövs...
>>
