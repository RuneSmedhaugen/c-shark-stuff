using System.Reflection.PortableExecutable;

var range = 250;
var counts = new int[range];
string text = "something";
int total = 0;
while (!string.IsNullOrWhiteSpace(text))
{
    
    text = Console.ReadLine()?.ToLower();
    total = text.Length;
    Array.Clear(counts, 0, counts.Length);

    foreach (var character in text ?? string.Empty)
    {
        counts[(int)character]++;
    }
    for (var i = 0; i < range; i++)
    {
        if (counts[i] > 0)
        {
            var character = (char)i;
            int count = counts[(int)character];
            double percentage = (double)count / total * 100;
            string output = character + " - " + percentage.ToString("F2") + "%";
            Console.CursorLeft = Console.BufferWidth - output.Length - 1;
            Console.WriteLine(output);
        }
    }
}