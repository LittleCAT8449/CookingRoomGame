using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Manager.RandomAndCheckManager
{
    public class RandomCookingOrder : MonoBehaviour
    {
        [SerializeField] private List<Item> foods = new List<Item>();
        [SerializeField] private List<Item> coffees = new List<Item>();
        [SerializeField] private Image food1;
        [SerializeField] private Image food2;
        [SerializeField] private Image coffee;
        [SerializeField] private TextMeshProUGUI food1Text;
        [SerializeField] private TextMeshProUGUI food2Text;
        [SerializeField] private TextMeshProUGUI coffeetext;
        [SerializeField] private TextMeshProUGUI time;

        // 当前订单物品（外部可访问）
        public List<Item> CurrentOrderItems { get; private set; } = new List<Item>();

        public List<Item> GetCurrentFoodItems()
        {
            return CurrentOrderItems.Where(item => foods.Contains(item)).ToList();
        }

        public Item GetCurrentCoffeeItem()
        {
            return CurrentOrderItems.FirstOrDefault(item => coffees.Contains(item));
        }

        [Header("时间限制")]
        [SerializeField] private float orderDuration = 60f;   // 订单有效期（秒）
        private float timer;                                   // 当前倒计时
        private bool orderActive = false;                      // 是否有活跃订单

        private void Update()
        {
            if (!orderActive) return;

            timer -= Time.deltaTime;
            UpdateTimerText();

            if (timer <= 0f)
            {
                timer = 0f;
                OrderExpired();
            }
        }

        /// <summary>
        /// 随机生成新订单，启动计时器
        /// </summary>
        public void RandomOrder()
        {
            // 清空旧订单
            CurrentOrderItems.Clear();

            // 决定是否要咖啡
            bool wantCoffee = Random.Range(0, 10) < 5;       // 50% 概率
            int foodCount = Random.Range(1, 3);               // 1~2 个食物（匹配两个食物图标）

            // 生成食物
            for (int i = 0; i < foodCount; i++)
            {
                int index = Random.Range(0, foods.Count);
                CurrentOrderItems.Add(foods[index]);
            }

            // 生成咖啡
            if (wantCoffee && coffees.Count > 0)
            {
                int index = Random.Range(0, coffees.Count);
                CurrentOrderItems.Add(coffees[index]);
            }

            // 更新 UI 并启动计时器
            UpdateOrderUI();
            StartTimer();

            // 调试输出
            string orderNames = string.Join(", ", CurrentOrderItems.Select(item => item.itemName));
            Debug.Log($"新订单：{orderNames}，剩余时间：{orderDuration}秒");
        }

        /// <summary>
        /// 根据当前订单更新食物和咖啡的图标与名称文本
        /// </summary>
        private void UpdateOrderUI()
        {
            // 隐藏所有图标
            if (food1 != null) food1.gameObject.SetActive(false);
            if (food2 != null) food2.gameObject.SetActive(false);
            if (coffee != null) coffee.gameObject.SetActive(false);

            // 清空所有名称文本
            if (food1Text != null) food1Text.text = "";
            if (food2Text != null) food2Text.text = "";
            if (coffeetext != null) coffeetext.text = "";

            // 分离食物与咖啡
            List<Item> orderFoods = CurrentOrderItems.Where(item => foods.Contains(item)).ToList();
            Item orderCoffee = CurrentOrderItems.FirstOrDefault(item => coffees.Contains(item));

            // 显示食物1
            if (orderFoods.Count > 0 && food1 != null)
            {
                food1.sprite = orderFoods[0].itemIcon;
                food1.gameObject.SetActive(true);
                if (food1Text != null) food1Text.text = orderFoods[0].itemName;
            }

            // 显示食物2
            if (orderFoods.Count > 1 && food2 != null)
            {
                food2.sprite = orderFoods[1].itemIcon;
                food2.gameObject.SetActive(true);
                if (food2Text != null) food2Text.text = orderFoods[1].itemName;
            }

            // 显示咖啡
            if (orderCoffee != null && coffee != null)
            {
                coffee.sprite = orderCoffee.itemIcon;
                coffee.gameObject.SetActive(true);
                if (coffeetext != null) coffeetext.text = orderCoffee.itemName;
            }
        }

        /// <summary>
        /// 重置并启动订单计时器
        /// </summary>
        private void StartTimer()
        {
            timer = orderDuration;
            orderActive = true;
            UpdateTimerText();
        }

        /// <summary>
        /// 更新倒计时文本显示（格式 mm:ss）
        /// </summary>
        private void UpdateTimerText()
        {
            if (time == null) return;

            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            time.text = $"{minutes:00}:{seconds:00}";
        }

        /// <summary>
        /// 订单超时处理：清空订单，隐藏 UI，刷新新订单
        /// </summary>
        private void OrderExpired()
        {
            Debug.Log("订单超时！");
            orderActive = false;
            CurrentOrderItems.Clear();
            UpdateOrderUI();      // 隐藏所有图标并清空文本
            time.text = "00:00";

            // 超时后自动生成下一单
            RandomOrder();
        }

        /// <summary>
        /// 外部（如提交按钮）通知订单已完成，停止计时并刷新
        /// </summary>
        public void CompleteOrder()
        {
            orderActive = false;
            // 不直接调 RandomOrder，而是由提交脚本在消耗物品后调用 RandomOrder
        }
    }
}
