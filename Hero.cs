using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
    class Hero:IComparable
    {
        //возможные состояния персонажа
        public enum Statements { normal, weak, ill, poisoned, paralized, died };
        string[] st = { "normal", "weak", "ill", "poisoned", "paralized", "died" };
        public Statements statmnt { get; set; } = Statements.normal;

        //гендер
        public enum Gender { male, female };
        public Gender Gnd { get; }

        //раса
        public enum Races { human, gnome, elf, ork, goblin };
        public Races Race { get; }

        //возраст
        public uint Age { get; }

        //здоровье
        public uint MaxHealth { get; } = 100;
        public uint CurrentHealth
        {
            get { return CurrentHealth; }
            set 
            {
                if (value == 0)
                {
                    CurrentHealth = value;
                    statmnt = Statements.died;
                }
                else
                if ((Convert.ToDouble(value) / MaxHealth) < 0.1 && (Convert.ToDouble(CurrentHealth) / MaxHealth) >= 0.1)
                {
                    CurrentHealth = value;
                    statmnt = Statements.weak;
                }
                else
                if ((Convert.ToDouble(value) / MaxHealth) >= 0.1 && (Convert.ToDouble(CurrentHealth) / MaxHealth) < 0.1)
                {
                    CurrentHealth = value;
                    statmnt = Statements.normal;
                }
                else CurrentHealth = value;


            }
        }


        //опыт
        public uint Exp { get; set; } = 0;

        //ID
        private static int _ID_= 0;
        public int Id { get; }

        //имя
        public string Name { get; }

        //конструкторы
        public Hero(string n, Races r, Gender g, int age)
        {
            Id = ++_ID_;
            Name = n;
            Race = r;
            Gnd = g;
            if (age < 0) { throw new Exception("wrong age"); }
            else { Age = Convert.ToUInt32(age); }
        }

        //возможность говорить
        public void Talk(string msg)
        {
            Console.WriteLine(msg);
        }

        //возможность двигаться
        public void Move (int speed, int direction)
        {
            //пока пусто без графики
        }

        public int CompareTo(object obj)
        {
            return Convert.ToInt32(Exp - (obj as Hero).Exp);
        }

        public override string ToString()
        {
            return $"РАСА: {Race}  ПОЛ: {Gnd}  ВОЗРАСТ:{Age}  ИМЯ:{Name}\nСОСТОЯНИЕ:{st[Convert.ToInt32(statmnt)]}  ЗДОРОВЬЕ:{CurrentHealth}/{MaxHealth}  ОПЫТ{Exp}";
        }
    }
}
