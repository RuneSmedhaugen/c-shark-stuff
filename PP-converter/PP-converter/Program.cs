

using PP_converter;




bool mainmenu = true;
while (mainmenu)
{
    Console.WriteLine(@"
    Hei velkommen til Converteren våres. Her er menyen:
    1. Temperatur
    2. Vekt
    3. Valuta
    4. Exit
");
    string hehexd = Console.ReadLine();
    if (hehexd == "1")
    {
       Temperature converter = new Temperature();
        converter.Temp();
    }
    else if (hehexd == "2") 
    {
        Weight converter = new Weight();
        converter.Vekt();
    }
    else if (hehexd == "3")
    {
        Valuta converter = new Valuta();
        converter.KekW();
    }
    else if (hehexd == "4")
    {
        Console.WriteLine("hade bra din møll");
        break;
    }
    else
    {
        Console.WriteLine("HALLO??? 1 2 3 eller 4 skal du velge? kokt i hue du el?");
    }
}
