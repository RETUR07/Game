using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class DeParalyse : MagicCast
    {
        public DeParalyse(MagicHero spellCastingHero)
                      : base(spellCastingHero, 85, true, false)
        {

        }
        public override bool MainCast(Hero targetHero)
        {
            if (CastCheck() && (targetHero.statmnt == Hero.Statements.paralized))
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
            return "DeParalyse";
        }
    }
}
