using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class MagicHero : Hero
    {
        public MagicInventory magicInventory;
        
        //мана
        public uint MaxMana { get; set; } = 150;
        private uint CurrentMana;
        public uint CurMn
        {
            get
            {
                return CurrentMana;
            }
            set
            {
                CurrentMana = value;
            }
        }

        //конструкторы
        public MagicHero(string n, Races r, Gender g, int age) : base(n, r, g, age)
        {
            CurrentMana = 100;
            magicInventory = new MagicInventory();
        }
        public override string ToString()
        {
            return base.ToString() + $"  МАНА:{ CurrentMana}/{MaxMana}";
        }
    }
}
