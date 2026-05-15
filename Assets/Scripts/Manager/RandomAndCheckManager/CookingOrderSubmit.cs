using System.Collections.Generic;
using Manager.InventoryManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Manager.RandomAndCheckManager
{
    public class CookingOrderSubmit : MonoBehaviour
    {
        [SerializeField] private RandomCookingOrder cookingOrder;
        [SerializeField] private Inventory inventory;

        [Header("需求提示图标（原有）")]
        [SerializeField] private Image food1Complete;
        [SerializeField] private Image food2Complete;
        [SerializeField] private Image coffeeComplete;

        [Header("新增：提交对号图标")]
        [SerializeField] private Image food1Check;
        [SerializeField] private Image food2Check;
        [SerializeField] private Image coffeeCheck;

        [SerializeField] private TextMeshProUGUI text;

        private readonly bool[] submitted = new bool[3];
        private int trackedOrderHash;

        private Inventory ActiveInventory => Inventory.Instance != null ? Inventory.Instance : inventory;

        private void Start()
        {
            ResetSubmitStateForCurrentOrder();
        }

        public void ButtonClick()
        {
            SubmitOrder();
        }

        public void SubmitOrder()
        {
            Inventory activeInventory = ActiveInventory;
            if (activeInventory == null || cookingOrder == null)
            {
                Debug.LogError("Order submit missing reference");
                return;
            }

            ResetSubmitStateIfOrderChanged();

            List<Item> orderSlots = GetOrderSlots();
            // 调试：打印订单需求
            Debug.Log($"Order slots: Food1={orderSlots[0]?.itemName}, Food2={orderSlots[1]?.itemName}, Coffee={orderSlots[2]?.itemName}");

            Item[] inventoryItems = activeInventory.GetItems();
            // 调试：打印背包物品
            for (int i = 0; i < inventoryItems.Length; i++)
            {
                if (inventoryItems[i] != null)
                    Debug.Log($"Inventory slot {i}: {inventoryItems[i].itemName}");
            }

            bool submittedThisClick = false;

            for (int orderIndex = 0; orderIndex < orderSlots.Count; orderIndex++)
            {
                if (submitted[orderIndex] || orderSlots[orderIndex] == null)
                    continue;

                int inventoryIndex = FindInventoryItemIndex(inventoryItems, orderSlots[orderIndex]);
                Debug.Log($"Looking for {orderSlots[orderIndex].itemName}, found at index: {inventoryIndex}");

                if (inventoryIndex == -1)
                    continue;

                activeInventory.ClearItem(inventoryIndex);
                inventoryItems[inventoryIndex] = null; // 保持本地数组同步
                submitted[orderIndex] = true;
                submittedThisClick = true;
                Debug.Log("Submitted: " + orderSlots[orderIndex].itemName);
                break;
            }

            RefreshAllImages(orderSlots);

            if (!submittedThisClick)
            {
                Debug.Log("No matching inventory item for unfinished order slots");
                return;
            }

            if (IsOrderComplete(orderSlots))
            {
                Debug.Log("Order submitted");
                text.text = "Order is Completed!!!";
                cookingOrder.CompleteOrder();
                cookingOrder.RandomOrder();
                ResetSubmitStateForCurrentOrder();
            }
        }

        private void ResetSubmitStateIfOrderChanged()
        {
            int currentHash = GetCurrentOrderHash();
            if (trackedOrderHash == currentHash)
                return;

            ResetSubmitStateForCurrentOrder();
        }

        private void ResetSubmitStateForCurrentOrder()
        {
            for (int i = 0; i < submitted.Length; i++)
                submitted[i] = false;

            trackedOrderHash = GetCurrentOrderHash();
            RefreshAllImages(GetOrderSlots());
        }

        private List<Item> GetOrderSlots()
        {
            List<Item> foods = cookingOrder != null ? cookingOrder.GetCurrentFoodItems() : new List<Item>();
            Item coffee = cookingOrder != null ? cookingOrder.GetCurrentCoffeeItem() : null;

            return new List<Item>
            {
                foods.Count > 0 ? foods[0] : null,
                foods.Count > 1 ? foods[1] : null,
                coffee
            };
        }

        private int FindInventoryItemIndex(Item[] items, Item orderItem)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (IsSameItem(items[i], orderItem))
                    return i;
            }
            return -1;
        }

        private bool IsOrderComplete(List<Item> orderSlots)
        {
            for (int i = 0; i < orderSlots.Count; i++)
            {
                if (orderSlots[i] != null && !submitted[i])
                    return false;
            }
            return true;
        }

        private void RefreshAllImages(List<Item> orderSlots)
        {
            // 需求图标：有需求显示，无需求隐藏，颜色始终全白
            SetCompleteImage(food1Complete, orderSlots.Count > 0 && orderSlots[0] != null, submitted[0]);
            SetCompleteImage(food2Complete, orderSlots.Count > 1 && orderSlots[1] != null, submitted[1]);
            SetCompleteImage(coffeeComplete, orderSlots.Count > 2 && orderSlots[2] != null, submitted[2]);

            // 对号图标：提交了才显示
            SetCheckImage(food1Check, orderSlots.Count > 0 && orderSlots[0] != null, submitted[0]);
            SetCheckImage(food2Check, orderSlots.Count > 1 && orderSlots[1] != null, submitted[1]);
            SetCheckImage(coffeeCheck, orderSlots.Count > 2 && orderSlots[2] != null, submitted[2]);
        }

        private void SetCompleteImage(Image image, bool hasOrderItem, bool isSubmitted)
        {
            if (image == null) return;
            image.gameObject.SetActive(hasOrderItem);   // 只控制显示/隐藏
            image.color = Color.white;                  // 固定白色，无透明度变化
        }

        private void SetCheckImage(Image image, bool hasOrderItem, bool isSubmitted)
        {
            if (image == null) return;
            image.gameObject.SetActive(hasOrderItem && isSubmitted);
        }

        private int GetCurrentOrderHash()
        {
            if (cookingOrder == null) return 0;

            unchecked
            {
                int hash = 17;
                foreach (Item item in cookingOrder.CurrentOrderItems)
                    hash = hash * 31 + (item != null ? item.GetInstanceID() : 0);
                return hash;
            }
        }

        private bool IsSameItem(Item item, Item orderItem)
        {
            if (item == null || orderItem == null) return false;

            // 如果 Item 有唯一 ID，优先用 ID 比较
            // return item.itemID == orderItem.itemID;

            // 否则用名称比较（忽略大小写、去除空格）
            return string.Equals(item.itemName.Trim(), orderItem.itemName.Trim(), System.StringComparison.OrdinalIgnoreCase);
        }
    }
}