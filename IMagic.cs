using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    interface IMagic
    {
        public bool MainCast(Hero TargetHero, int Strength);
        public bool MainCast(Hero TargetHero);
        public bool MainCast(int Strength);
        public bool MainCast();
    }
}
