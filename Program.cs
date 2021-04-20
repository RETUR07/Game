using System;

namespace GameByCash
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            Hero.Races race = Hero.Races.human;
            Hero.Gender gender = Hero.Gender.male;
            int age = 27;
            Console.WriteLine("Введите имя героя:");
            name = Console.ReadLine();
            Console.WriteLine("Выберите расу(введите номер расы): 0 - human, 1 - gnome, 2 - elf, 3 - ork, 4 - goblin");
            if (Int32.TryParse(Console.ReadLine(), out int r) && r >= 0 && r <= 5)
                race = (Hero.Races)r;

            Console.WriteLine("Выберите пол(введите номер пола): 0 - male, 1 - female");
            if (Int32.TryParse(Console.ReadLine(), out r) && r >= 0 && r <= 1)
                gender = (Hero.Gender)r;

            Console.WriteLine("Введите возраст");
            if (Int32.TryParse(Console.ReadLine(), out r) && r >= 0)
                age = r;

            MagicHero hero = new MagicHero(name , race, gender, age);
            MagicHero enemy = new MagicHero("enemy", Hero.Races.ork, Hero.Gender.male, 500);

            hero.Inventory.AddArtifact(new LifeWaterBottle(LifeWaterBottle.VolumeTypes.small));
            hero.Inventory.AddArtifact(new LifeWaterBottle(LifeWaterBottle.VolumeTypes.small));

            Console.Clear();
            Console.WriteLine(hero.ToString());
            Console.WriteLine(hero.Inventory.ToString());
            bool flag = false;
            while (hero.CurHlth > 0)
            {
                if (flag)
                {
                    Console.Clear();
                    Console.WriteLine(hero.ToString());
                    Console.WriteLine(hero.Inventory.ToString());
                }
                System.Threading.Thread.Sleep(1000);
            }

        }

    }
}
