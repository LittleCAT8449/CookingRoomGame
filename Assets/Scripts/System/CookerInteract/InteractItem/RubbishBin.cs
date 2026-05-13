using Manager.InventoryManager;
using UnityEngine;

namespace System.CookerInteract
{
    public class RubbishBin : InteractCookerParent
    {
        
        public override void PressNumber()
        {
            items = Inventory.Instance.GetItems();

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetCurrentItem(items[0], 0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetCurrentItem(items[1], 1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SetCurrentItem(items[2], 2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SetCurrentItem(items[3], 3);
            }
        }

        
        private void SetCurrentItem(Item item, int index)
        {
            if (item == null) return;
            Inventory.Instance.SetItem(index, null);
            
        }
        
        
        
    }
}