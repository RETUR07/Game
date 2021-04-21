using System;
using System.Threading;

namespace GameByCash
{
    class Program
    {
        static object locker = new object();
        static uint counter = 0;

        class EnemyAtack
        {
            MagicHero enemy;
            MagicHero hero;
            public EnemyAtack(MagicHero e, MagicHero h)
            {
                enemy = e;
                hero = h;
            }
            public void EnemyAtackThread()
            {
                while (true)
                {
                    lock (locker)
                    {
                        counter++;
                        LightningStaff enemyStaff = new LightningStaff(counter);
                        enemy.Inventory.AddArtifact(enemyStaff);
                        enemy.Inventory.UseArtifact(enemy.Inventory.GetArtifact(enemyStaff), hero, counter);
                    }
                    if (hero.statmnt == Hero.Statements.died) break;
                    System.Threading.Thread.Sleep(5000);
                }
            }
        }



        static void Main(string[] args)
        {
            //инициализаци персов
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
            hero.statmnt = Hero.Statements.ill;
            hero.CurHlth = 50;

            //добавление инвентаря hero
            hero.Inventory.AddArtifact(new LifeWaterBottle(LifeWaterBottle.VolumeTypes.small));
            hero.Inventory.AddArtifact(new LifeWaterBottle(LifeWaterBottle.VolumeTypes.big));
            hero.Inventory.AddArtifact(new DeadWaterBottle(DeadWaterBottle.VolumeTypes.medium));
            hero.Inventory.AddArtifact(new LightningStaff(100));
            hero.Inventory.AddArtifact(new BasiliskEye());
            hero.Inventory.AddArtifact(new PoisonousSaliva(5));
            hero.Inventory.AddArtifact(new FrogDecoction());
            

            //добавление спелов
            hero.magicInventory.AddSpell(new Armor(hero));
            hero.magicInventory.AddSpell(new AddHealth(hero));
            hero.magicInventory.AddSpell(new Heal(hero));

            Console.Clear();
            Console.WriteLine(hero.ToString());
            Console.WriteLine(hero.Inventory.ToString());
            Console.WriteLine(hero.magicInventory.ToString());

            EnemyAtack atack = new EnemyAtack(enemy, hero);
            Thread enmy = new Thread(new ThreadStart(atack.EnemyAtackThread));
            enmy.Start();

            
            while (true)
            {
                string s, s2;
                Console.WriteLine("введите название заклинания или предмета");
                s = Console.ReadLine();
                Console.WriteLine("введите цель");
                s2 = Console.ReadLine();
                // поиск в инвентаре
                if (hero.Inventory.FindItem(s))
                {
                    if (s2 == "enemy")
                    {
                        Artifact art = hero.Inventory.GetArtifact(s);
                        if (art.HaveStrength)
                        {
                            uint str;
                            Console.WriteLine("введите силу предмета");
                            UInt32.TryParse(Console.ReadLine(), out str);
                            hero.Inventory.UseArtifact(art, enemy, str);
                        }
                        else
                        {
                            hero.Inventory.UseArtifact(art, enemy);
                        }

                    }
                    else
                    {
                        Artifact art = hero.Inventory.GetArtifact(s);
                        if (art.HaveStrength)
                        {
                            uint str;
                            Console.WriteLine("введите силу предмета");
                            UInt32.TryParse(Console.ReadLine(), out str);
                            hero.Inventory.UseArtifact(art, hero, str);
                        }
                        else
                        {
                            hero.Inventory.UseArtifact(art, hero);
                        }

                    }
                    
                }

                if (hero.magicInventory.FindSpell(s))
                {
                    if (s2 == "enemy")
                    {
                        MagicCast spell = hero.magicInventory.GetSpell(s);
                        if (spell.HaveStrength)
                        {
                            uint str;
                            Console.WriteLine("введите силу предмета");
                            UInt32.TryParse(Console.ReadLine(), out str);
                            hero.magicInventory.UseSpell(spell, enemy, str);
                        }
                        else
                        {
                            hero.magicInventory.UseSpell(spell, enemy);
                        }

                    }
                    else
                    {
                        Artifact art = hero.Inventory.GetArtifact(s);
                        if (art.HaveStrength)
                        {
                            uint str;
                            Console.WriteLine("введите силу предмета");
                            UInt32.TryParse(Console.ReadLine(), out str);
                            hero.Inventory.UseArtifact(art, hero, str);
                        }
                        else
                        {
                            hero.Inventory.UseArtifact(art, hero);
                        }

                    }

                }

                    Draw(hero);

                if (enemy.statmnt == Hero.Statements.died)
                {
                    Console.WriteLine("YOU WIN");
                    break;
                }
                if (hero.statmnt == Hero.Statements.died)
                {
                    Console.WriteLine("YOU LOSE");
                    break;
                }

            }


            enmy.Join();
        }
        static void Draw(MagicHero hero)
        {
            Console.Clear();

            Console.WriteLine(hero.ToString());
            Console.WriteLine(hero.Inventory.ToString());
            Console.WriteLine(hero.magicInventory.ToString());
        }
    }
}
