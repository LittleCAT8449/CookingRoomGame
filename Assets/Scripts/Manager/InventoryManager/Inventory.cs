using System;
using UnityEngine;

namespace Manager.InventoryManager
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory instance;
        public Item[] items= new Item[4];

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            
        }

        public void AddItem(Item item)
        {
            for (int i = 0; i < 4; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    Debug.Log(items[i].name+" added");
                    break;
                }
                
            }
            Debug.Log("Inventory isFulled");
            
        }

        public void ClearItem(int index)
        {
            if (index >= 0 && index < 4)
            {
                items[index] = null;
                Debug.Log("Inventory cleared");
            }
        }
        
    }
}