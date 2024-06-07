using codealong3;



List<Persons> personer  = new List<Persons>()
{
    new Persons("Bjarne", 35, "brogata 13"),
    new Persons("Arne", 19, "Haugelundsvegen 9A"),
    new Persons("Line", 31, "Haugelundsvegen 9A"),
    new Persons("Petter", 64, "Haugelundsvegen 9A"),
    new Persons("Gerd", 4, "Haugelundsvegen 9A"),
};

 void PeopleOverThirty()
{
    for (int i = 0; i < personer.Count; i++)
    {
        if (personer[i].Age > 30)
        {
            Console.WriteLine(@$"Navn: {personer[i].Name}
Alder: {personer[i].Age}
Adresse:{personer[i].Adress}");
        }
    }
}

 void AddPerson()
 {
     Console.WriteLine(@"Navn:");
     string name = Console.ReadLine();
     Console.WriteLine("Alder:");
     var age = Convert.ToInt32(Console.ReadLine());
     Console.WriteLine("Adresse:");
     string adress = Console.ReadLine();

     personer.Add(new Persons(name, age, adress));
     
 }

 while (true)
 {

 
Console.WriteLine(@"Hei. hva vil du gjøre?
1: se personer
2: legg til ny person");
var choices = Console.ReadLine();

if (choices == "1")
{
    PeopleOverThirty();
}
else if (choices == "2")
{
    AddPerson();
}
else
{
    Console.WriteLine("Vennligst velg enten 1 eller 2");
}
 }

