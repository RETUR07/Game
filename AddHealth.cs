using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class AddHealth : MagicCast
    {
        public AddHealth(MagicHero spellCastingHero) 
               : base(spellCastingHero, 2, true, false)//как выбирать компоненты t или f??
        {
            
        }
        public override bool MainCast(Hero targetHero, uint strength)//Проблемма оступа к полям (проверить) 
        {
            if(SpellCastingHero.CurMn >= MinMana 
             && (SpellCastingHero.MoveCheck == MoveAbility || !MoveAbility)//Проверять ли? Выносить в класс Magic cast ли?
             && (SpellCastingHero.SpeakCheck == SpeakAbility || !SpeakAbility))
            {
                if(targetHero.CurHlth + strength > targetHero.MaxHealth)
                {
                    targetHero.CurHlth = targetHero.MaxHealth;
                } 
                else{
                    targetHero.CurHlth = targetHero.CurHlth + strength;                    
                }
                SpellCastingHero.CurMn -= MinMana;//Как менять ману хз 
                return true;
            }
            else
            {
                return false;
            }
        }
        public override bool MainCast(Hero targetHero)
        {
            if(SpellCastingHero.CurMn >= MinMana 
             && (SpellCastingHero.MoveCheck == MoveAbility || !MoveAbility)
             && (SpellCastingHero.SpeakCheck == SpeakAbility || !SpeakAbility))
            {
                if (targetHero.CurHlth + SpellCastingHero.CurMn / 2 > targetHero.MaxHealth)
                {
                    targetHero.CurHlth = targetHero.MaxHealth;                    
                }
                else
                {
                    targetHero.CurHlth = targetHero.CurHlth + SpellCastingHero.CurMn / 2;
                }
                SpellCastingHero.CurMn -= SpellCastingHero.CurMn / 2 * 2;//Может одна мана остаться
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
