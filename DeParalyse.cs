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
            if (SpellCastingHero.CurMn >= MinMana
             && (SpellCastingHero.MoveCheck == MoveAbility || !MoveAbility)
             && (targetHero.statmnt == Hero.Statements.paralized))
            {
                targetHero.CurHlth = 1;
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
