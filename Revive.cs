using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class Revive : MagicCast
    {
        public Revive(MagicHero spellCastingHero)
                      : base(spellCastingHero, 150, true, true)//MaxMana 150 а у нас 100 + она может меняться
        {

        }
        public override bool MainCast(Hero targetHero)
        {
            if (CastCheck() && (targetHero.statmnt == Hero.Statements.died))
            {
                targetHero.CurHlth = 1;               
                targetHero.statmnt = Hero.Statements.normal;              
                SpellCastingHero.CurMn -= MinMana;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "Revive";
        }
    }
}
