using System;

namespace pikachu
{
    public class Pikachu
    {
        private int health = 50;
        private int level = 21;

        public void ShowInfo()
        {
            Console.WriteLine($"Pikachu sin helse er: {health} og level: {level}");
        }
    }
}