# Button Panel Manager

Een configureerbare knoppenpaneel-applicatie voor Windows waarmee gebruikers eigen knoppen kunnen aanmaken, beheren en koppelen aan geselecteerde Windows-vensters.

## Functionaliteiten

### Hoofdvenster
- Overzicht van alle aangemaakte knoppen
- Weergave in raster of lijstformaat
- Schaalbaar venster
- Donkere en lichte modus

### Knoppenbeheer
- Nieuwe knop toevoegen
- Bestaande knop bewerken
- Knop verwijderen
- Knop dupliceren
- Naam van knop wijzigen
- Volgorde van knoppen wijzigen via drag-and-drop
- Configuratie automatisch opslaan

### Knopeigenschappen
- Weergavenaam
- Tekstinhoud
- Optioneel icoon
- Optionele kleur
- Sneltoets
- Aan/uit-status

### Vensterkoppeling
- Knop "Venster selecteren"
- Selecteer geopende Windows-venster door aan te klikken
- Geselecteerd venster wordt opgeslagen
- Mogelijkheid om koppeling later te wijzigen
- Ondersteuning voor meerdere profielen met verschillende vensterkoppelingen

### Profielen
- Nieuw profiel maken
- Profiel hernoemen
- Profiel verwijderen
- Profiel exporteren naar JSON
- Profiel importeren vanuit JSON

### Opslag
- Alle instellingen lokaal opgeslagen
- Automatisch laden bij opstarten
- JSON-configuratiebestanden (leesbaar en handmatig bewerkbaar)

### Gebruiksvriendelijkheid
- Contextmenu op elke knop
- Bevestiging bij verwijderen
- Zoekfunctie voor knoppen
- Mogelijkheid om knoppen te groeperen in categorieën

## Technische Eisen
- Windows 10 en Windows 11 ondersteuning
- Geen externe server vereist
- Standalone uitvoerbaar bestand
- Configuratiebestanden leesbaar en handmatig bewerkbaar
- Gebouwd met C# WPF

## Installatie & Gebruik

### Vereisten
- .NET 6.0 of hoger
- Windows 10/11

### Build
```bash
dotnet build
```

### Run
```bash
dotnet run
```

## Projectstructuur
```
ButtonPanelManager/
├── App.xaml                 # Application entry point
├── MainWindow.xaml          # Main UI
├── MainWindow.xaml.cs       # Main code-behind
├── Models/                  # Data models
├── ViewModels/              # MVVM ViewModels
├── Views/                   # User controls en windows
├── Services/                # Business logic
├── Resources/               # Themes en images
└── Utils/                   # Helper functions
```

## Voorbeeldknoppen
- ;;slayora
- ;;dzd
- ;;vb
- ;;gb
- ;;trinity
- ;;home
- ;;dz

Al deze knoppen zijn volledig aanpasbaar, verwijderbaar, toevoegbaar en verplaatsbaar.

## Licentie
MIT

## Auteur
thesneakyone