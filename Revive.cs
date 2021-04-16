using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class Revive : MagicCast
    {
        public Revive(MagicHero spellCastingHero)
                      : base(spellCastingHero, 150, true, true)//MaxMana 150 а у нас 100 + она может меняться, задаётся в конструкторе
        {

        }
        public override bool MainCast(Hero targetHero)
        {
            if (SpellCastingHero.CurMn >= MinMana
             && (SpellCastingHero.MoveCheck == MoveAbility || !MoveAbility)
             && (targetHero.statmnt == Hero.Statements.died))
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
