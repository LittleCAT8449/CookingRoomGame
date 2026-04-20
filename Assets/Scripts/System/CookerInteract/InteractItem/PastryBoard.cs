using Manager.InventoryManager;
using Unity.VisualScripting;
using UnityEngine;
using Utils;

namespace System.CookerInteract
{
    public class PastryBoard : InteractCookerParent
    {
       
        
        public Item dough;
        private int globaleIndex;

        
        
        public override void PressNumber()
        {
            items=Inventory.Instance.GetItems();
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PastryRecipe(items[0],0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PastryRecipe(items[1],1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                PastryRecipe(items[2],2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                PastryRecipe(items[3],3);
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
                       
                        PastryBar.Instance.setUIActive();
                        PastryBar.Instance.setMakingStart = true;
                        globaleIndex = index;
                        break;
                        
                }
            }
        }

        private void OnEnable()
        {
            CookingEventListener.st_doughMakingDone += setDough;
        }

        private void OnDisable()
        {
            CookingEventListener.st_doughMakingDone -= setDough;
        }

        private void setDough()
        {
            Inventory.Instance.SetItem(globaleIndex,dough);
        }
    }
}