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
            HaveStrength = true;
        }
        public override bool MainCast(Hero targetHero, uint strength)
        {
            if(CastCheck() && targetHero.statmnt != Hero.Statements.died && targetHero.statmnt != Hero.Statements.invulnerability)//Имя может быть упрощено
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
            return false;            
        }
        public override bool MainCast(Hero targetHero)
        {
            if (CastCheck() && targetHero.statmnt != Hero.Statements.invulnerability && targetHero.statmnt != Hero.Statements.died)
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
            return false;
        }
        public override string ToString()
        {
            return "AddHealth";
        }
    }
}
