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
            inventory.Add(item.GetType().ToString(), item);
        }
        public object GetArtifact(string s)
        {
            return inventory[s];
        }
        public void RemoveArtifact(object item)
        {

        }
        public void DropArtifact(object item)
        {

        }

    }
}
