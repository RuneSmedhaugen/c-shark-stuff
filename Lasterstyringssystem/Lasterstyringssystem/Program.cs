using Lagerstyringssystem;

Lager lager = new Lager();

DateOnly milkExpiration = new DateOnly(2024, 6, 24);
Matvare melk = new Matvare("melk", 25, milkExpiration);

DateOnly grandiosaExpiration  = new DateOnly(2026, 12, 24);
Matvare grandiosa = new Matvare("Grandiosa", 62, grandiosaExpiration);

Klær BH = new Klær("BH", 249, "35C");
Klær lue = new Klær("lue", 666.69, "XL");

Elektronikk TV = new Elektronikk("TV", 13599,24);
Elektronikk iPhone = new Elektronikk("iPhone", 19999.99, 6);

lager.LeggTilProdukt(melk);
lager.LeggTilProdukt(grandiosa);
lager.LeggTilProdukt(BH);
lager.LeggTilProdukt(lue);
lager.LeggTilProdukt(TV);
lager.LeggTilProdukt(iPhone);

while (true)
{
    Console.WriteLine(@"Hei og velkommen til lager. Her er dine alternativer:
1: Sjekk lagerstatus alle produkter
2: Sjekk matvarebeholdning
3: Sjekk klesbeholdning
4: Sjekk elektronikkbeholdning
5: Fjern et produkt fra lager
6: Gå ut av lager");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Alle produkter:");
            lager.ListAlleProdukter();
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("Matvarer:");
            lager.ListProdukterAvKategori<Matvare>();
            break;

        case "3":
            Console.Clear();
            Console.WriteLine("Klær:");
            lager.ListProdukterAvKategori<Klær>();
            break;

        case "4":
            Console.Clear();
            Console.WriteLine("Elektronikk:");
            lager.ListProdukterAvKategori<Elektronikk>();
            break;

        case "5":
            Console.Clear();
            Console.WriteLine("Velg hvilken vare du vil fjerne (Skriv navnet til produktet):");
            lager.ListAlleProdukter();
            string removeItem = Console.ReadLine().Trim();
            if (lager.FjernProdukt(removeItem))
            {
                Console.Clear();
                Console.WriteLine($"Produktet {removeItem} er fjernet fra lager.");
                lager.FjernProdukt(removeItem);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Fant ikke produktet {removeItem} i lager.");
            }
            break;

        case "6":
            Console.WriteLine("Avslutter lagerstyringssystem.");
            return;

        default:
            Console.WriteLine("Ugyldig valg. get good bro");
            break;
    }
}
