using Manager.InventoryManager;
using UnityEngine;
using Utils;

namespace System.CookerInteract
{
    public class PastryBoard : InteractCookerParent
    {
       
        public Item dough;
        
        public override void PressNumber()
        {
            items=Inventory.Instance.GetItems();
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PastryRecipe(items[0],0);
                Debug.Log("Pressed 1"+items[0].name);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PastryRecipe(items[1],1);
                Debug.Log("Pressed 2"+items[1].name);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                PastryRecipe(items[2],2);
                Debug.Log("Pressed 3"+items[2].name);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                PastryRecipe(items[3],3);
                Debug.Log("Pressed 4"+items[3].name);
            }
        }

        private void PastryRecipe(Item item,int index)
        {
            if (item != null)
            {
                String itemName = item.name;
                switch (itemName)
                {
                    case "flour":
                        
                        SetInventory(index,dough);
                        break;
                        
                }
            }
        }
        
        
    }
}