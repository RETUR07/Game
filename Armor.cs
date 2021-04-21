using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GameByCash
{
    class Armor : MagicCast
    {
        Hero h;
        uint str;
        Hero.Statements st;
        int seconds = 0;
        System.Timers.Timer timerRight = new System.Timers.Timer();
        void timerRight_Tick(object sender, EventArgs e)
        {
            seconds++;
            if (seconds >= str)//кол-во секунд поменять
            {
                h.statmnt = st;
                timerRight.Stop();
                timerRight.Close();
            }
        }
        public Armor(MagicHero spellCastingHero)
                          : base(spellCastingHero, 50, true, true)//MaxMana 150 а у нас 100 + она может меняться
        {
            HaveStrength = true;
        }
        public override bool MainCast(Hero targetHero, uint strength)
        {
            if (strength * 50 > SpellCastingHero.CurMn)
            {
                return false;
            }
            str = strength * 5;
            h = targetHero;
            st = targetHero.statmnt;
            timerRight.Elapsed += timerRight_Tick;
            timerRight.Interval = 1000d;

            if (CastCheck() && targetHero.statmnt != Hero.Statements.invulnerability) //проверка на силу
            {
                targetHero.statmnt = Hero.Statements.invulnerability;
                SpellCastingHero.CurMn -= strength * 50;
                timerRight.Start();

                return true;
            }
            return false;
        }

       
        public override string ToString()
        {
            return "Armor";
        }
    }
}
