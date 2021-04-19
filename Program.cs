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
            LifeWaterBottle lb = new LifeWaterBottle(LifeWaterBottle.VolumeTypes.medium);
            h.Inventory.AddArtifact(lb);
            (h.Inventory.GetArtifact(lb.ToString()) as LifeWaterBottle).
            //LifeWaterBottle lbmain = (LifeWaterBottle)h.Inventory.GetArtifact(lb.ToString());
            //Console.WriteLine(lbmain.Volume);

        }

    }
}
