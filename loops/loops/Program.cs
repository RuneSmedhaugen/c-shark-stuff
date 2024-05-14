using System.ComponentModel.Design;

Console.WriteLine("velg et tall mellom 1 og 3 for å gå videre.");
var answer = Console.ReadLine();

if (answer == "1")
{
    for (int i = 0; i!=5; i++)
    {Console.WriteLine("Terje er IKKE kul!");}
    
}
else if (answer == "2")
{
    string[] tull = new string[] { "dette", "er", "ikke", "gøy", "bare", "tulla", "kekw" };
    foreach (var arg in tull)
    {
        Console.WriteLine(arg);
    }
}
else if (answer == "3")
{
    bool condition = true;
    int rounds = 0;

    while (condition)
        if (rounds != 10)
        {
            Console.WriteLine($"Runde {rounds}");
            rounds++;
        }
        else
        {
            Console.WriteLine("Du har nå tatt 10 runder.");
            condition = false;
        }
}