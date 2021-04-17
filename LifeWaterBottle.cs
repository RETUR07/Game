using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class LifeWaterBottle : Artifact
    {
        public enum VolumeTypes { small = 10, medium = 25, big = 50 };
        public  VolumeTypes Volume { get; set; } 
        public bool IsUsed = false;//вынести поле в "артифакт" мб, прост зачем тогда возобновляемость
        public LifeWaterBottle(VolumeTypes volume): base(0, false)
        {
            Volume = volume;
        }
        public override bool MainCast(Hero targetHero)
        {
            if(!this.IsUsed)//Если ещё не использовали артефакт
            {
                if (targetHero.CurHlth + (uint)Volume > targetHero.MaxHealth)
                {
                    targetHero.CurHlth = targetHero.MaxHealth;
                }
                else
                {
                    targetHero.CurHlth = targetHero.CurHlth + (uint)Volume;
                }
                this.IsUsed = true;
                return true;
            }
            else{
                //мб как-то уничтожить объект????
                return false;
            }           
        }
    }
}
