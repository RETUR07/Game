using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class FrogDecoction: Artifact
    {
        public FrogDecoction() : base(0, true)
        {

        }
        public override bool MainCast(Hero targetHero)
        {
            if (this.Renewable && targetHero.statmnt == Hero.Statements.poisoned)
            {
                targetHero.statmnt = Hero.Statements.normal;
                this.Renewable = false;
                return true;
            }
            return false;
        }
    }
}
