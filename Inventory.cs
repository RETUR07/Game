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

        void AddArtifact(Artifact item)
        {
            inventory.Add(item);
        }
        //void RemoveArtifact(Artifact item)
        //{         
        //    if (!item.Reusable())
        //    {
        //        inventory.Remove(item);
        //    }
            
        //}
        void DropArtifact(Artifact item)
        {
            inventory.Remove(item);
        }

    }
}
