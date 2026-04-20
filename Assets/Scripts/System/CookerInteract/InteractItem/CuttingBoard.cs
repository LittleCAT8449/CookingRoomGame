using Manager.InventoryManager;
using UI.Bar.CuttingBar;
using UnityEngine;
using Utils;

namespace System.CookerInteract
{
    public class CuttingBoard : InteractCookerParent
    {
        public Item cuttingApple;
        public Item cuttingTomato;
        public Item cuttingCucumber;
        public Item cuttingCarrot;
        public Item cuttingMurshroom;
        public Item cuttingPotato;
        public Item cuttingPumpkin;
        
        private Item[] items;
        private Item currentItem;      // 记录当前要切的物品
        private int currentItemIndex; // 记录当前格子

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

        // 记录当前要切的东西，而不是直接判断
        private void SetCurrentItem(Item item, int index)
        {
            if (item == null) return;

            currentItem = item;
            currentItemIndex = index;

            CuttingBar.instance.enterGame = true;
        }

        // 小游戏成功后，这里才真正切菜
        private void OnCuttingSuccess()
        {
            if (currentItem == null) return;

            string itemName = currentItem.name;

            switch (itemName)
            {
                case "apple":
                    SetInventory(currentItemIndex, cuttingApple);
                    break;
                case "tomato":
                    SetInventory(currentItemIndex, cuttingTomato);
                    break;
                case "cucumber":
                    SetInventory(currentItemIndex, cuttingCucumber);
                    break;
                case "carrot":
                    SetInventory(currentItemIndex, cuttingCarrot);
                    break;
                case "murshroom":
                    SetInventory(currentItemIndex, cuttingMurshroom);
                    break;
                case "potato":
                    SetInventory(currentItemIndex, cuttingPotato);
                    break;
                case "pumpkin":
                    SetInventory(currentItemIndex, cuttingPumpkin);
                    break;
            }

            // 切完清空
            currentItem = null;
        }

        // 失败就啥也不做
        private void OnCuttingFail()
        {
            currentItem = null;
        }

        private void OnEnable()
        {
            CookingEventListener.st_cuttingMakingSuccessful += OnCuttingSuccess;
            CookingEventListener.st_cuttingMakingFalse += OnCuttingFail;
        }

        private void OnDisable()
        {
            CookingEventListener.st_cuttingMakingSuccessful -= OnCuttingSuccess;
            CookingEventListener.st_cuttingMakingFalse -= OnCuttingFail;
        }
    }
}