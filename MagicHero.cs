using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class MagicHero : Hero
    {
        MagicInventory magicInventory;
        
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
        //заклинания ManaNeed это количество маны необходимое для каста с силой х1,
        //а StrenthK коэфициент силы (количество маны на все заклинание ManaNeed * StrenthK)

        //bool можно ли кастануть 
        public bool CastCheck(int ManaNeed, int StrenthK)
        {
            if (ManaNeed * StrenthK > CurrentMana) return false;
            return true;
        }

        //каст заклинания
        public void MagicCast(int ManaNeed, int StrenthK)
        {
            if (CastCheck(ManaNeed, StrenthK)) CurrentMana = CurrentMana - Convert.ToUInt16(ManaNeed * StrenthK);
        }
    }
}
