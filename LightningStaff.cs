using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class LightningStaff: Artifact
    {
        public LightningStaff(uint artifactPower) : base(artifactPower, true)
        {
           
        }
        public override bool MainCast(Hero targetHero, uint strength)
        {
            if(this.ArtifactPower != 0
            && this.ArtifactPower - strength >= 0//Может ли персонаж умереть от посоха?
            && targetHero.CurHlth - strength > 0)//если нет тогда нужна эта проверка иначе переделать чуть
            {
                targetHero.CurHlth -= strength;
                this.ArtifactPower -= strength;
                return true;
            }
            return false;           
        }
        public override string ToString()
        {
            return "LightningStaff " + ArtifactPower.ToString();
        }
    }
}
