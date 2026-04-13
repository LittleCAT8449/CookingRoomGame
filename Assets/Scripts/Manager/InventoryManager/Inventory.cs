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
                    UpdateUI();
                    break;
                }
                
            }
            Debug.Log("Inventory isFulled");
            
        }

        public bool HasItem(Item item)
        {
            foreach (Item i in items)
            {
                if (i.name == item.name)
                {
                    return true;
                }
            }
            return false;
        }
        public void ClearItem(int index)
        {
            if (index >= 0 && index < 4)
            {
                items[index] = null;
                UpdateUI();
                Debug.Log("Inventory cleared");
            }
        }

        public void UpdateUI()
        {
            for (int i = 0; i < 4; i++)
            {
                if (SlotUI.slots[i] != null)
                {
                    SlotUI.slots[i].SetItem(items[i]);
                }
            }
        }
        
    }
}