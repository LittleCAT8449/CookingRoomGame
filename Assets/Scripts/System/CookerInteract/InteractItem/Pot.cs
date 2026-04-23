using Manager.InventoryManager;
using UnityEngine;

namespace System.CookerInteract
{
    public class Pot : InteractCookerParent
    {
        public enum E_PotState
        {
            Idle,
            Cooking,
            Ready,
            OverCooked
        }

        [Header("烹饪时间")]
        public float cookTime = 20f;
        public float overCookDelay = 10f;

        [Header("可煮食材（用来判断）")]
        public Item potNoodles;
        public Item potPumpkin;
        public Item potPotato;

        [Header("煮熟后的产物")]
        public Item cookedNoodles;
        public Item cookedPumpkin;
        public Item cookedPotato;
        public Item garbage;

        [Header("UI - 世界空间图标")]
        public GameObject backPanel;          // 背景面板（可选，如果是 Sprite 可删）
        public SpriteRenderer cookingIcon;   // 改为 SpriteRenderer

        // 烹饪中显示的图标（生食材）
        public Sprite noodlesIcon;
        public Sprite pumpkinIcon;
        public Sprite potatoIcon;

        // 完成后显示的图标（成品）
        public Sprite readyNoodlesIcon;
        public Sprite readyPumpkinIcon;
        public Sprite readyPotatoIcon;

        // 煮过头显示的图标
        public Sprite overcookedIcon;
        
        

        // 静态变量：记录玩家当前站在哪个锅的触发器内
        public static Pot currentFocusedPot;

        private Item[] items;
        private E_PotState currentState = E_PotState.Idle;
        private float currentTimer = 0f;
        private Item cookingIngredient;   // 正在烹饪的原始食材

        private void Start()
        {
            items = Inventory.Instance.GetItems();
            if (backPanel != null)
                backPanel.SetActive(false);
            if (cookingIcon != null)
                cookingIcon.gameObject.SetActive(false);
        }

        private void Update()
        {
            PressNumber();
            UpdateCookingProgress();
        }

        public override void PressNumber()
        {
            if (currentFocusedPot == null) return;

            items = Inventory.Instance.GetItems();
            if (items == null || items.Length < 4)
            {
                Debug.LogError("背包物品数组异常");
                return;
            }

            Item selectedItem = null;
            int selectedIndex = -1;

            if (Input.GetKeyDown(KeyCode.Alpha1)) { selectedItem = items[0]; selectedIndex = 0; }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) { selectedItem = items[1]; selectedIndex = 1; }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) { selectedItem = items[2]; selectedIndex = 2; }
            else if (Input.GetKeyDown(KeyCode.Alpha4)) { selectedItem = items[3]; selectedIndex = 3; }
            else return;

            if (selectedItem == null)
            {
                Debug.Log($"格子 {selectedIndex + 1} 没有物品");
                return;
            }

            currentFocusedPot.TryStartCooking(selectedItem, selectedIndex);
        }

        /// <summary>
        /// 统一更新图标（根据状态和食材）
        /// </summary>
        private void UpdateIcon()
        {
            if (cookingIcon == null) return;

            // 空闲状态：隐藏图标和背板
            if (currentState == E_PotState.Idle)
            {
                cookingIcon.gameObject.SetActive(false);
                if (backPanel != null) backPanel.SetActive(false);
                return;
            }

            // 非空闲状态：显示背板和图标
            if (backPanel != null) backPanel.SetActive(true);
            cookingIcon.gameObject.SetActive(true);

            switch (currentState)
            {
                case E_PotState.Cooking:
                    if (cookingIngredient == potNoodles && noodlesIcon != null)
                        cookingIcon.sprite = noodlesIcon;
                    else if (cookingIngredient == potPumpkin && pumpkinIcon != null)
                        cookingIcon.sprite = pumpkinIcon;
                    else if (cookingIngredient == potPotato && potatoIcon != null)
                        cookingIcon.sprite = potatoIcon;
                    break;

                case E_PotState.Ready:
                    if (cookingIngredient == potNoodles && readyNoodlesIcon != null)
                        cookingIcon.sprite = readyNoodlesIcon;
                    else if (cookingIngredient == potPumpkin && readyPumpkinIcon != null)
                        cookingIcon.sprite = readyPumpkinIcon;
                    else if (cookingIngredient == potPotato && readyPotatoIcon != null)
                        cookingIcon.sprite = readyPotatoIcon;
                    break;

                case E_PotState.OverCooked:
                    if (overcookedIcon != null)
                        cookingIcon.sprite = overcookedIcon;
                    break;
            }
        }

        /// <summary>
        /// 尝试开始烹饪（由数字键调用）
        /// </summary>
        public void TryStartCooking(Item item, int itemIndex)
        {
            if (currentState != E_PotState.Idle)
            {
                Debug.Log("锅正在使用中，无法放入新食材");
                return;
            }

            if (!IsCookable(item))
            {
                Debug.Log($"【{item.itemName}】不能放进锅里煮");
                return;
            }

            if (!Inventory.Instance.ClearItem(itemIndex))
            {
                Debug.Log("从背包移除食材失败");
                return;
            }

            cookingIngredient = item;
            currentState = E_PotState.Cooking;
            currentTimer = 0f;
            Debug.Log($"开始烹饪 【{item.itemName}】");
            UpdateIcon();   // 显示生食材图标
        }

        private void UpdateCookingProgress()
        {
            if (currentState == E_PotState.Cooking)
            {
                if (currentTimer >= cookTime)
                {
                    currentState = E_PotState.Ready;
                    currentTimer = 0f;
                    Debug.Log("烹饪完成！");
                    UpdateIcon();   // 显示成品图标
                }
                else
                {
                    currentTimer += Time.deltaTime;
                    // 可在此更新进度条
                }
            }
            else if (currentState == E_PotState.Ready)
            {
                if (currentTimer >= overCookDelay)
                {
                    currentState = E_PotState.OverCooked;
                    currentTimer = 0f;
                    Debug.Log("煮过头了，变成垃圾");
                    UpdateIcon();   // 显示烧焦图标
                }
                else
                {
                    currentTimer += Time.deltaTime;
                }
            }
        }

        // 按 E 交互（仅用于取出成品或清理垃圾）
        public void Interact()
        {
            switch (currentState)
            {
                case E_PotState.Ready:
                    TakeFood();
                    break;
                case E_PotState.OverCooked:
                    ClearGarbage();
                    break;
                case E_PotState.Cooking:
                    Debug.Log("食物还在煮，请稍后再来");
                    break;
                case E_PotState.Idle:
                    // 空闲状态按 E 无效果
                    break;
            }
        }

        private bool IsCookable(Item item)
        {
            return item == potNoodles || item == potPumpkin || item == potPotato;
        }

        private void TakeFood()
        {
            Item output = GetCookedOutput(cookingIngredient);
            if (output != null)
                Inventory.Instance.AddItem(output);
            else
                Debug.LogError("没有找到对应的煮熟产物");
            ResetPot();
        }

        private void ClearGarbage()
        {
            if (garbage != null)
                Inventory.Instance.AddItem(garbage);
            ResetPot();
        }

        private void ResetPot()
        {
            currentState = E_PotState.Idle;
            currentTimer = 0f;
            cookingIngredient = null;
            UpdateIcon();   // 隐藏图标
        }

        private Item GetCookedOutput(Item raw)
        {
            if (raw == potNoodles) return cookedNoodles;
            if (raw == potPumpkin) return cookedPumpkin;
            if (raw == potPotato) return cookedPotato;
            return null;
        }
    }
}