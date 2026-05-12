using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Manager.RandomAndCheckManager
{
    public class RandomCookingOrder : MonoBehaviour
    {
        [SerializeField] private List<Item> foods = new List<Item>();
        [SerializeField] private List<Item> coffees = new List<Item>();

        private List<Item> chosedFoods = new List<Item>();
        private List<Item> chosedCoffee = new List<Item>();
        private bool isRandomCooffee=false;



        private void isRandomCoffeeItem()
        {

            if (Random.Range(1, 10) <= 5)
            {
                isRandomCooffee = true;
            }
            else
            {
                isRandomCooffee = false;
            }
            
        }

        private void RandomCookingItem()
        {
            isRandomCoffeeItem();
    
            // 随机决定添加 1~3 个食物（可根据需要修改范围）
            int foodCount = Random.Range(1, 3);  // 1,2,3
            for (int i = 0; i < foodCount; i++)
            {
                int randomFoodIndex = Random.Range(0, foods.Count);
                chosedFoods.Add(foods[randomFoodIndex]);
            }

            // 咖啡部分保持不变
            if (isRandomCooffee)
            {
                int randomCoffeeIndex = Random.Range(0, coffees.Count);
                chosedCoffee.Add(coffees[randomCoffeeIndex]);
            }
        }

        public void RandomOrder()
        {
            RandomCookingItem();
            string orderList="";
            foreach (var item in chosedFoods)
            {
                orderList += (item.itemName+",");
            }

            foreach (var item in chosedCoffee)
            {
                orderList += (item.itemName+",");
            }
            
            Debug.Log(orderList);
            chosedCoffee.Clear();
            chosedFoods.Clear();
            
        }
        
    }
}