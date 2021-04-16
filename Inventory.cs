using System;
using System.Collections.Generic;
using System.Text;

namespace GameByCash
{
   class Inventory
   {   
       List<Artefact> inventory;
       public Inventory() 
        {
            inventory = new List<Artefact>();
        }

        void AddArtefact(Artefact item)
        {
            inventory.Add(item);
        }
        void RemoveArtefact(Artefact item)
        {         
            if (!item.Reusable())
            {
                inventory.Remove(item);
            }
            
        }
        void DropArtefact(Artefact item)
        {
            inventory.Remove(item);
        }

    }
}
