using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    abstract class MagicCast: IMagic
    {
        public uint MinMana;// лучше private мы же его нигде не меняем + только задаем в дочернем
        public bool MoveAbility;// 
        public bool SpeakAbility;//
        public bool HaveStrength = false;

        public MagicHero SpellCastingHero;// лучше private мы же его нигде не меняем
        //public Hero TargetHero; а зачем вообще нужны?
        //public int Strength;

        public MagicCast(MagicHero spellCastingHero, uint minMana, bool moveAbility, bool speakAbility)
        {
            SpellCastingHero = spellCastingHero;
            MinMana = minMana;
            MoveAbility = moveAbility;
            SpeakAbility = speakAbility;
        }
        public bool CastCheck()
        {
            if (SpellCastingHero.CurMn >= MinMana
            && (SpellCastingHero.SpeakCheck == SpeakAbility || !SpeakAbility)
            && (SpellCastingHero.MoveCheck == MoveAbility || !MoveAbility))
            {
                return true;
            }
            return false;
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
       
    }
}
