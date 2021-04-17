using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class PoisonousSaliva: Artifact
    {
        public PoisonousSaliva(uint artifactPower) : base(artifactPower, true)
        {

        }
        public override bool MainCast(Hero targetHero, uint strength)
        {            
            if(targetHero.CurHlth - strength <= 0)
            {
                targetHero.CurHlth = 0;//Автоматически в die переводится 
            }
            else
            {
                targetHero.CurHlth -= targetHero.CurHlth - strength;
                if (targetHero.statmnt == Hero.Statements.normal
                || targetHero.statmnt == Hero.Statements.weak)
                {
                    targetHero.statmnt = Hero.Statements.poisoned;
                }
            }
            return true;
        }
    }
}
