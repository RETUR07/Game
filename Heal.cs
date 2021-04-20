using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class Heal : MagicCast
    {
        public Heal(MagicHero spellCastingHero)
               : base(spellCastingHero, 20, true, true)
        {

        }
        public override bool MainCast(Hero targetHero)
        {
            if (CastCheck() && (targetHero.statmnt == Hero.Statements.ill))
            {
                targetHero.statmnt = Hero.Statements.normal;
                SpellCastingHero.CurMn -= MinMana;
                return true;
            }           
            return false;            
        }
        public override string ToString()
        {
            return "Heal";
        }
    }
}
