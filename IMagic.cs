using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    interface IMagic
    {
        public bool MainCast(Hero TargetHero, uint Strength);
        public bool MainCast(Hero TargetHero);
        
    }
}
