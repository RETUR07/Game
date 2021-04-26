using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class LifeWaterBottle : Artifact
    {
        public enum VolumeTypes { small = 10, medium = 25, big = 50 };
        public VolumeTypes Volume; //{ get; set; } Своство не нужно вроде?
        public LifeWaterBottle(VolumeTypes volume): base(0, true)
        {
            Volume = volume;
        }
        public override bool MainCast(Hero targetHero)
        {
            if(Renewable)//Если ещё не использовали артефакт
            {
                if (targetHero.CurHlth + (uint)Volume > targetHero.MaxHealth)
                {
                    targetHero.CurHlth = targetHero.MaxHealth;
                }
                else
                {
                    targetHero.CurHlth = targetHero.CurHlth + (uint)Volume;
                }
                Renewable = false;
                return true;
            }
            return false;              
        }

        public override string ToString()
        {
            return "LifeWaterBottle " + Volume.ToString();
        }
    }
}
