using Manager.InventoryManager;
using UI.Bar.BurnishBar;
using UnityEngine;

namespace System.CookerInteract
{
    public class BurnishBoard : InteractCookerParent
    {
        public Item burnishCheese;
        public Item burnishTomato;
        
        private Item[] items;
        private Item currentItem;      // 记录当前要切的物品
        private int currentItemIndex;
        
        private void Start()
        {
            items = Inventory.Instance.GetItems();
        }

        private void Update()
        {
            PressNumber();
        }

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

            currentItem = item;
            currentItemIndex = index;

            BurnishBar.instance.enterGame = true;
        }
        
        private void OnBurnishSuccess()
        {
            if (currentItem == null) return;

            string itemName = currentItem.name;

            switch (itemName)
            {
                case "cheese":
                    SetInventory(currentItemIndex, burnishCheese);
                    break;
                case "tomato":
                    SetInventory(currentItemIndex, burnishTomato);
                    break;
                
            }

            // 切完清空
            currentItem = null;
        }

        // 失败就啥也不做
        private void OnBurnishFail()
        {
            currentItem = null;
        }

        private void OnEnable()
        {
            CookingEventListener.st_burnishMakingSuccessful += OnBurnishSuccess;
            CookingEventListener.st_burnishMakingFalse += OnBurnishFail;
        }

        private void OnDisable()
        {
            CookingEventListener.st_burnishMakingSuccessful -= OnBurnishSuccess;
            CookingEventListener.st_burnishMakingFalse -= OnBurnishFail;
        }
        
        
        
    }
}