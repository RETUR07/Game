using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    abstract class Artifact: IMagic
    {
        public bool Renewable;
        public uint ArtifactPower;

        public Artifact(uint artifactPower, bool renewable){
            ArtifactPower = artifactPower;
            Renewable = renewable;
        }

        public virtual bool MainCast(Hero targetHero, uint strength)
        {
            return false;//Если метод не переопределён в дочернем классе
                         //то данную перегрузку нельзя кастануть поэтому false
        }
        public virtual bool MainCast(Hero targetHero)
        {
            return false;
        }
        public virtual bool MainCast(MagicHero targetHero, uint strength)
        {
            return false;
        }
        public virtual bool MainCast(MagicHero targetHero)
        {
            return false;
        }
        public virtual bool MainCast(uint strength)
        {
            return false;
        }
        public virtual bool MainCast()
        {
            return false;
        }
    }
}
