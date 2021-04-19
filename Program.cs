using System;

namespace GameByCash
{
    class Program
    {
        static void Main(string[] args)
        {
            MagicHero h = new MagicHero("hero", Hero.Races.human, Hero.Gender.male, 30);

            Console.WriteLine(h.ToString());
            h.Exp = 100;
            Console.WriteLine(h.ToString());
            h.CurHlth = 100;
            Console.WriteLine(h.ToString());
            h.CurMn = 100;
            Armor armor = new Armor(h);
            armor.MainCast(h, 1);
            while (true)
            {
                Console.WriteLine(h.ToString());
                System.Threading.Thread.Sleep(5000);
            }
        }
        
    }
}
