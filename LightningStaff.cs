using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class LightningStaff: Artifact
    {
        public LightningStaff(uint artifactPower) : base(artifactPower, true)
        {
            HaveStrength = true;
        }
        public override bool MainCast(Hero targetHero, uint strength)
        {
            if(ArtifactPower != 0
            && ArtifactPower - strength >= 0//Может ли персонаж умереть от посоха?
            && (int)targetHero.CurHlth - (int)strength > 0)//если нет тогда нужна эта проверка иначе переделать чуть
            {
                targetHero.CurHlth -= strength;
                ArtifactPower -= strength;
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
