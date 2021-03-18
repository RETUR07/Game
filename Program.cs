using System;

namespace GameByCash
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero h = new Hero("hero", Hero.Races.human, Hero.Gender.male, 30);

            Console.WriteLine(h.ToString());
            h.Exp = 100;
            Console.WriteLine(h.ToString());
            h.CurHlth = 9;
            Console.WriteLine(h.ToString());

        }
        
    }
}
