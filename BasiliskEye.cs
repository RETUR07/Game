using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class BasiliskEye: Artifact
    {
        public BasiliskEye() : base(0, true)
        {           
        }        
        public override bool MainCast(Hero targetHero)
        {
            if (this.Renewable && targetHero.statmnt != Hero.Statements.died)//Чтобы артефакт использовал только герой
            {
                targetHero.statmnt = Hero.Statements.paralized;
                this.Renewable = false;
                return true;
            }
            return false;
        }
        public override bool MainCast(MagicHero targetHero)
        {
            if (this.Renewable && targetHero.statmnt != Hero.Statements.died)//Чтобы артефакт использовал только герой
            {
                targetHero.statmnt = Hero.Statements.paralized;
                this.Renewable = false;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return "BasiliskEye";
        }
    }
}
