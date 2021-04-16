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
            if (SpellCastingHero.CurMn >= MinMana
             && (SpellCastingHero.MoveCheck == MoveAbility || !MoveAbility)
             && (targetHero.statmnt == Hero.Statements.poisoned))
            {
                if ((SpellCastingHero.SpeakCheck == SpeakAbility || !SpeakAbility))
                {
                    targetHero.statmnt = Hero.Statements.normal;
                    //если и говорит и двигаеться то полностью вылечивает
                }
                else
                {
                    targetHero.statmnt = Hero.Statements.weak;/*или??? Hero.Statements.normal*/
                    //если только двигаеться то переводит в ослаблен
                }
                SpellCastingHero.CurMn -= MinMana;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
