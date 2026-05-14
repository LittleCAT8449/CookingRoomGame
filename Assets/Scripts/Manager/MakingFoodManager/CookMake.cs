using System.Collections.Generic;
using System.Linq;
using Manager.InventoryManager;
using UnityEngine;

namespace Manager.RandomAndCheckManager
{
    public class CookMake : MonoBehaviour
    {
        public static CookMake CurrentCooking { get; private set; }

        [Header("Required ingredients")]
        public List<Item> ingre;

        [Header("Inventory")]
        public Inventory inventory;

        [Header("Random number manager")]
        public RandomNumber number;

        [Header("Output item")]
        [SerializeField] private Item outPutItem;

        private Inventory ActiveInventory => Inventory.Instance != null ? Inventory.Instance : inventory;

        public void Progress()
        {
            Inventory activeInventory = ActiveInventory;
            if (activeInventory == null)
            {
                Debug.LogError("Inventory is missing");
                return;
            }

            Item[] currentItems = activeInventory.GetItems();
            List<int> ingredientIndexes = GetIngredientIndexes(currentItems);

            if (ingredientIndexes == null)
            {
                Debug.Log("Ingredients do not match");
                return;
            }

            foreach (int index in ingredientIndexes.OrderByDescending(i => i))
            {
                bool removed = activeInventory.ClearItem(index);
                Debug.Log($"Clear ingredient slot {index}: {removed}");
            }

            CurrentCooking = this;
            number.StartNewRound();

            Debug.Log($"{gameObject.name} consumed ingredients, start number input");
        }

        public void GiveOutput()
        {
            ActiveInventory.AddItem(outPutItem);
            Debug.Log($"Cooking success: {outPutItem.itemName}");

            if (CurrentCooking == this)
            {
                CurrentCooking = null;
            }
        }

        private List<int> GetIngredientIndexes(Item[] items)
        {
            List<int> result = new List<int>();
            bool[] used = new bool[items.Length];

            foreach (Item ing in ingre)
            {
                int index = -1;

                for (int i = 0; i < items.Length; i++)
                {
                    if (used[i] || !IsSameItem(items[i], ing))
                    {
                        continue;
                    }

                    index = i;
                    break;
                }

                if (index == -1)
                {
                    return null;
                }

                used[index] = true;
                result.Add(index);
            }

            return result;
        }

        private bool IsSameItem(Item item, Item ingredient)
        {
            if (item == null || ingredient == null)
            {
                return false;
            }

            return item == ingredient || item.itemName == ingredient.itemName;
        }

        public void ButtonClick()
        {
            Progress();
        }

        private void OnDisable()
        {
            if (CurrentCooking == this)
            {
                CurrentCooking = null;
            }
        }
    }
}
