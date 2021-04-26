using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class PoisonousSaliva: Artifact
    {
        public PoisonousSaliva(uint artifactPower) : base(artifactPower, true)
        {
            HaveStrength = true;
        }
        public override bool MainCast(Hero targetHero)
        {            
            if((int)targetHero.CurHlth - (int)ArtifactPower <= 0)
            {
                targetHero.CurHlth = 0;//Автоматически в die переводится 
            }
            else
            {
                targetHero.CurHlth -= ArtifactPower;
                if (targetHero.statmnt == Hero.Statements.normal
                || targetHero.statmnt == Hero.Statements.weak)
                {
                    targetHero.statmnt = Hero.Statements.poisoned;
                }
            }
            return true;
        }
        public override string ToString()
        {
            return "PoisonousSaliva " + ArtifactPower.ToString();
        }
    }
}
