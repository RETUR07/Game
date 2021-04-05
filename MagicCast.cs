using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    abstract class MagicCast:IMagic
    {
        public uint MinMana;
        public bool MoveAbility;
        public bool TalkAbility;

        public MagicCast(){

        }

        public bool MainCast(Hero TargetHero, int Strength)
        {
            return true;
        }
        public bool MainCast(Hero TargetHero)
        {
            return true;
        }
        public bool MainCast(int Strength)
        {
            return true;
        }
        public bool MainCast()
        {
            return true;
        }
    }
}
