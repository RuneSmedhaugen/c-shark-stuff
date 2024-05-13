while (true)
{
Console.WriteLine("skriv et tall mellom 1 og 7.");
var number = Console.ReadLine();

// Lagde en loop istedenfor å lage en funksjon. Fungerer på samme måte men ville gjøre det anderledes enn videoen viste
    switch (number)
    {
        case "1":
            Console.WriteLine("Mandag");
            break;
        case "2":
            Console.WriteLine("Tirsdag");
            break;
        case "3":
            Console.WriteLine("Onsdag");
            break;
        case "4":
            Console.WriteLine("Torsdag");
            break;
        case "5":
            Console.WriteLine("Fredag");
            break;
        case "6":
            Console.WriteLine("Lørdag");
            break;
        case "7":
            Console.WriteLine("Søndag");
            break;
        default:
            Console.WriteLine("Det er ikke et tall mellom 1 og 7!");
            break;
    }
}