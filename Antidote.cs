using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class Antidote : MagicCast
    {
        public Antidote(MagicHero spellCastingHero)
                  : base(spellCastingHero, 30, false, false)
        {

        }
        public override bool MainCast(Hero targetHero)
        {
            if (this.CastCheck() && (targetHero.statmnt == Hero.Statements.poisoned))
            {
                targetHero.statmnt = Hero.Statements.normal;
                SpellCastingHero.CurMn -= MinMana;
                return true;
            }
            return false;
        }
    }
}
