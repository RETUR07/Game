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
            if(SpellCastingHero.CurMn >= MinMana 
             && (SpellCastingHero.MoveCheck == MoveAbility || !MoveAbility)             
             && (targetHero.statmnt == Hero.Statements.ill))
            {
                if ((SpellCastingHero.SpeakCheck == SpeakAbility || !SpeakAbility)){
                    targetHero.statmnt = Hero.Statements.normal;
                    //если и говорит и двигаеться то полностью вылечивает
                }
                else{
                    targetHero.statmnt = Hero.Statements.weak;/*или??? Hero.Statements.normal*/
                    //если только двигаеться то переводит в ослаблен
                }
                SpellCastingHero.CurMn -= MinMana;
                return true;
            }
            else{
                return false;
            }            
        }
    }
}
