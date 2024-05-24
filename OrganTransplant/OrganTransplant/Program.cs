using System.ComponentModel.Design;
// !!! DETTE ER BARE MIDLERTIDIG HISTORIE, KOMMER SENERE TIL Å ENDRE TIL Å BRUKE KLASSER/METODER/OBJEKTER OSV OSV !!!
Console.WriteLine(@"Bernt kjører på en skogsvei.
Plutselig kommer en elg hoppende ut fra skogkanten og inn på veien!
Hva gjør Bernt?
1: Prøver å svinge unna.
2: Kjører rett på elgen.
");
String firstChoice  = Console.ReadLine();

if (firstChoice != "1")
{
    Console.WriteLine(@"Bernt prøver å svinge og unngår heldigvis elgen, som løper av skrekk i motsatt vei.
Men uheldigvis så skrenser bilen rundt og et tre. Bernt blir hardt skadet og en gren trenger gjennom korsryggen.
Hva gjør Bernt videre?
1: Ringer 113.
2: prøver å komme seg løs.
");
    String secondChoice = Console.ReadLine();

    if (secondChoice != "1")
    {
        Console.WriteLine(@"Bernt ringer 113 og blir hentet av ambulanse. 
De får han omsider løs, men ikke uten å skade en nyre som grenen lå nær.
Da de kommer til sykehuset, så finner de ut at Bernt trenger en nyretransplantasjon. Hva skjer videre?
1: Sykehuset ringer fetteren, Kåre.
2: Bernt nekter og drar hjem.
");
        String thirdChoice = Console.ReadLine();
        if (thirdChoice == "1")
        {
            Console.WriteLine(@"Sykehuset ringer fetteren til Bernt, Kåre og forteller at Bernt har vært i en ulykke og trenger en ny nyre. 
De ber han komme inn til testing.
Hva gjør Kåre?
1: Sier ja til å komme inn til testing og se om han er kompatibel.
2: Sier at Bernt er en forferdelig bror og at han får klare seg selv.
");
            String fourthChoice = Console.ReadLine();
            if (fourthChoice != "1")
            {
                Console.WriteLine(@"Kåre drar til sykehuset og går gjennom en del tester.
Testene kommer tilbake positive og det viser seg at hvis Kåre gir bort en av sine nyrer til Bernt så vil han ha høy sjanse for å overleve.
Hva gjør Kåre?
1: Han velger å donere en nyre til Bernt.
2: Han velger å ikke donere en nyre til Bernt.
");
                String fiveChoice = Console.ReadLine();
                if (fiveChoice == "1")
                {
                    Console.WriteLine("Kåre velger å donere bort en nyre til Bernt. Bernt overlever og alle lever lykkelige i resten av sine dager.");
                }
                else if (fiveChoice == "2")
                {
                    Console.WriteLine(@"Kåre velger allikevel å ikke donere bort en nyre.
Bernt levde i 5 dager til før han døde.
");
                }
                else
                {
                    Console.WriteLine("Velg enten valg 1 eller 2, dust.");
                }
            }
        }
    }
}