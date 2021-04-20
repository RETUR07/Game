using System;
using System.Collections;
using System.Text;

namespace GameByCash
{
   class Inventory
   {
        Hashtable inventory;
        public Inventory() 
        {
            inventory = new Hashtable();
        }

        public void AddArtifact(object item)
        {
            inventory.Add(item.ToString(), item);
        }

        public object GetArtifact(object item)
        {
            return inventory[item.ToString()];
        }

        public void RemoveArtifact(object item)
        {
            inventory.Remove(item.ToString());
        }

        public bool FindItem(object item)
        {
            return inventory.ContainsKey(item.ToString());
        }

        public override string ToString()
        {
            ICollection keys = inventory.Keys;
            string s = "";
            foreach (string key in keys)
            {
                s += inventory[key].ToString();
            }
            return s;
        }
        //public void DropArtifact(object item)
        //{

        //}

    }
}
