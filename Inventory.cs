using System;
using System.Collections;
using System.Text;

namespace GameByCash
{
    class InventoryObject
    {
        public Artifact Artifact;
        public int amount;
        public InventoryObject(Artifact artifact)
        {
            Artifact = artifact;
            amount = 1;
        }
    }
    class Inventory
    {
        Hashtable inventory;
        public Inventory()
        {
            inventory = new Hashtable();
        }

        public void AddArtifact(Artifact art)
        {
            InventoryObject item = new InventoryObject(art);
            if (inventory.ContainsKey(art.ToString()))
            {
                (inventory[art.ToString()] as InventoryObject).amount++;
            }
            else
            {
                inventory.Add(art.ToString(), item);
            }

        }
        public Artifact GetArtifact(Artifact item)
        {
            if (inventory.ContainsKey(item.ToString()))
            {
                return (Artifact)(inventory[item.ToString()] as InventoryObject).Artifact;
            }
            else
            {
                return null;
            }

        }
        public Artifact GetArtifact(string s)
        {
            if (inventory.ContainsKey(s))
            {
                return (inventory[s] as InventoryObject).Artifact;
            }
            else
            {
                return null;
            }

        }
        public void RemoveArtifact(Artifact art)
        {
            if (inventory.ContainsKey(art.ToString()))
            {
                if ((inventory[art.ToString()] as InventoryObject).amount > 1)
                {
                    (inventory[art.ToString()] as InventoryObject).amount--;
                }
                else
                {
                    inventory.Remove(art.ToString());
                }
            }
        }
        public bool FindItem(Artifact art)
        {
            return inventory.ContainsKey(art.ToString());
        }
        public bool FindItem(string s)
        {
            return inventory.ContainsKey(s);
        }
        public override string ToString()
        {
            ICollection keys = inventory.Keys;
            string s = "";
            foreach (string key in keys)
            {
                s += (inventory[key] as InventoryObject).Artifact.ToString() + ' ' + (inventory[key] as InventoryObject).amount + '\n';
            }
            return s;
        }
        public void GiveArtifact(Artifact art, Hero reciever)
        {
            if (FindItem(art))
            {
                RemoveArtifact(art);
                reciever.Inventory.AddArtifact((inventory[art.ToString()] as InventoryObject).Artifact);
            }
        }
        public void UseArtifact(Artifact item, Hero targethero)
        {
            if (item != null)
            {
                item.MainCast(targethero);
                RemoveArtifact(item);
            }
        }
        public void UseArtifact(Artifact item, Hero targethero, uint str)
        {
            if (item is LightningStaff)
            {
                LightningStaff olditem = new LightningStaff(item.ArtifactPower);
                item.MainCast(targethero, str);
                AddArtifact(item);
                RemoveArtifact(olditem);
            }
            else
            {
                item.MainCast(targethero, str);
            }
        }
    }
}