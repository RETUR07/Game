using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    interface IMagic
    {
        public bool MainCast(Hero TargetHero, uint Strength);
        public bool MainCast(Hero TargetHero);        
        public bool MainCast(MagicHero TargetHero, uint Strength);
        public bool MainCast(MagicHero TargetHero);
        public bool MainCast(uint Strength);
        public bool MainCast();
    }
}
