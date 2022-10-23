# Bumbo_POC
## Studenten
| name  | student ID |
| ------------- | ------------- |
| Rachen Wever  | 2175280  |
| Abukar Abukar  | 2183631  |
| Freek Straten | 2187585 |
| Cas Denteneer | 2166249 |
| Vincent van Hintum | 2189326 |
| Timo Westbroek | 2189033 |
| Thomas Meulenbroek | 2186592 |

## Startup handleiding 
Welke stappen moet een nieuwe werkgever volgen om mee te kunnen ontwikkelen aan het project? Welke solutions met hij downloaden? Welke packages installeren? Hoe moet hij de database configuren? Etc. 

<b>IDE:</b>
* Visual Studio 2022
* Microsoft SQL Server Management Studio 19

Andere belangrijke punten:
*	Chromium browser

<b>Packages:</b>
*	Entity Framework Core 
*	Entity Framework Core Relational 
*	SqlServer 
*	Microsoft.EntityFrameworkCore.Design 
*	Microsoft.EntityFrameworkCore.Tools 


Alle overige documentatie staat in de OneDrive. Dit omvat de projectplan, functioneel ontwerp samenwerkingsovereenkomsten en de technische ontwerp. In de groep K op Discord houden we alle groepsbijeenkomsten bij, meer diepgaand chatten over de taken waar we op dat moment mee bezig zijn, elkaar helpen, tips geven, planning bijhouden.

<b>Database opzetten:</b>
Verbind de database met de server Explorer in Visual Studio 2022. De database staat al online op Azure.  Verbind met de database ook in Microsoft SQL Server Management Studio 19. Dit is zodat je de database kan bekijken of editen met de Server management studio. 
In geval dat de database nog niet online staat, of de database is offline gebruik dan de lokale connection string in de appsettings. 

## Coding guidelines
Dit is een set van coding guidelines dat gebruikt zal worden in het project:
* PascalCasing voor benaming van een Class, Record, Struct, Fields, properties, events, methods en lokale Functions als ze public zijn. 
public class DataService { }, public void DoSomething() { }
public string FirstName;

*	Benamingen van Interface classes beginnen met een “I”.
public IExampleDemo ExampleDemo;

*	Private properties gebruiken camelCasing en beginnen met een ‘_’.
private string _firstName;

*	Parameters in een methode zijn camelCase. 
public void DoSomething(int exampleNumber, string exampleString) { }

*	Booleans beginnen met een ‘Is’.
public bool IsValid; public bool IsHappening;

*	Benamingen, code en comments worden in het Engels gedaan. 

*	Benamingen moeten duidelijk zijn wat het bevat, niet te kort. 
Slecht: public string N; public int Va;
Goed: public string Name; public int Value;

*	Beschrijf ‘het waarom’ achter de code die je hebt gemaakt, niet alleen de schijnbare informatie. Programmeurs begrijpen de code, maar niet waarom het geschreven is
Slecht: //this method adds two ints together 
   	public int DoSomthing(int value1, int value2)
      {
          return int1 + int2
}
*	Niet meer dan een Statement of Declaration per lijn in een editor. Comments moeten apart staan, niet achter code.

```	
/// <summary>
/// This method changes the point's location to
/// the given coordinates. <see cref="Translate"/>
/// </summary>
public void Move(int xPosition, int yPosition)
{
    X = xPosition;
    Y = yPosition;
}
/// <summary>This method changes the point's location by
/// the given x- and y-offsets. <see cref="Move"/>
/// </summary>
public void Translate(int dx, int dy)
{
    X += dx;
    Y += dy;
}
```

*	‘Var’ alleen gebruiken als het duidelijk is wat het property bevat, niet gebruiken wanneer het niet meteen duidelijk is wat er ingestopt wordt.

*	Try and Catch gebruiken om exceptions goed te handelen.

*	In geval van onduidelijkheid, zie deze website:  https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions

*	Voor html en css zie deze website: https://google.github.io/styleguide/htmlcssguide.html

<b>Checklist:</b>
*	Code is in het Engels, tekst in UI-elementen in het Nederlands
*	Documentatie is in het Engels
*	Tekst in de UI is in het Nederlands
*	Code is in correcte MVC
*	Code is correct gedocumenteerd (zie hierboven)
*	Belangrijk: Code in develop voldoet aan al deze eisen
*	Er zijn geen IDE-bestanden/niet-bronbestanden toegevoegd. Visual studio en Rider config-bestanden staan al in de .gitignore
*	Code voldoet aan C# codeerconventies
