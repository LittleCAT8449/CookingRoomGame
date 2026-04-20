using Manager.InventoryManager;
using UnityEngine;
using Utils;

namespace System.CookerInteract
{
    public class InteractCookerParent : MonoBehaviour,IPressNumber
    {
        protected Item[] items;
        protected Item item;
        
        protected void Start()
        {
            items=Inventory.Instance.GetItems();
        }
        
        protected void Update()
        {
            
            PressNumber();
            
        }
        
        public virtual void PressNumber()
        {
            
        }
        
        
        protected void SetInventory(int index, Item item) => Inventory.Instance.SetItem(index, item);
    }
}