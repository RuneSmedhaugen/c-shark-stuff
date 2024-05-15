
Console.WriteLine(@"
Choose an option:
1: Rotate Text
2: Change Word
");
var option = Console.ReadLine();

// Gadd ikke legge til en loop så man kan spille så mange ganger man vil

if (option == "1")
{
    Console.WriteLine("Write a word");
    var rotateAns = Console.ReadLine();
    Console.WriteLine($"{rotateAns} tar seg en snus kekw");
    string reversed = new string(rotateAns.Reverse().ToArray());
    Console.WriteLine(reversed);
}
else if (option == "2")
{
    Console.WriteLine("Write a word or sentence that includes e");
    var changeAns = Console.ReadLine();
    Console.WriteLine($"{changeAns} tar ikke seg en snus kekw");
    string etoA = new string(changeAns.Replace('e', 'a'));
    Console.WriteLine(etoA);
}
else
{
    Console.WriteLine("please choose 1 or 2");
}

