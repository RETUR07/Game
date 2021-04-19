using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
   class Inventory
   {   
       List<Artifact> inventory;
       public Inventory() 
        {
            inventory = new List<Artifact>();
        }

        public void AddArtifact(Artifact item)
        {
            if (!item.IsInInventory)
            {
                item.IsInInventory = true;
                inventory.Add(item);
            }
        }
        //void RemoveArtifact(Artifact item)
        //{         
        //    if (!item.Reusable())
        //    {
        //        inventory.Remove(item);
        //    }
            
        //}
        public void DropArtifact(Artifact item)
        {
            if (item.IsInInventory)
            {
                item.IsInInventory = false;
                inventory.Remove(item);
            }
        }

    }
}
