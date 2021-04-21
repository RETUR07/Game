using System;
using System.Collections;
using System.Text;

namespace GameByCash
{
    class MagicInventoryObject
    {
        public MagicCast Spell;        
        public MagicInventoryObject(MagicCast spell)
        {
            Spell = spell;          
        }
    }
    class MagicInventory
    {
        Hashtable magicInventory;
        public MagicInventory()
        {
            magicInventory = new Hashtable();
        }

        public void AddSpell(MagicCast spell)
        {
            MagicInventoryObject item = new MagicInventoryObject(spell);
            if (!magicInventory.ContainsKey(spell.ToString()))
            {
                magicInventory.Add(spell.ToString(), item);
            }
           

        }
        public void RemoveSpell(MagicCast spell)
        {
            if (magicInventory.ContainsKey(spell.ToString()))
            {
                magicInventory.Remove(spell.ToString());
            }
        }
        public MagicCast GetSpell(MagicCast spell)
        {
            if (magicInventory.ContainsKey(spell.ToString()))
            {
                return (magicInventory[spell.ToString()] as MagicInventoryObject).Spell;
            }
            else
            {
                return null;
            }

        }
        public MagicCast GetSpell(string spell)
        {
            if (magicInventory.ContainsKey(spell))
            {
                return (magicInventory[spell] as MagicInventoryObject).Spell;
            }
            else
            {
                return null;
            }

        }

        public bool FindSpell(MagicCast spell)
        {
            return magicInventory.ContainsKey(spell.ToString());
        }
        public bool FindSpell(string s)
        {
            return magicInventory.ContainsKey(s);
        }
        public override string ToString()
        {
            ICollection keys = magicInventory.Keys;
            string s = "";
            foreach (string key in keys)
            {
                s += (magicInventory[key] as MagicInventoryObject).Spell.ToString() + '\n';
            }
            return s;
        }
        
        public void UseSpell(MagicCast spell, Hero targethero)
        {
            if (spell != null)
            {
                spell.MainCast(targethero);         
            }
        }
        public void UseSpell(MagicCast spell, Hero targethero, uint strength)
        {
            if (spell != null)
            {
                spell.MainCast(targethero, strength);
            }
        }
    }
}