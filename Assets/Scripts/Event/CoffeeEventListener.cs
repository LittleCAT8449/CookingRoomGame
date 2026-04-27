using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Event
{
    public class CoffeeEventListener
    {

        public enum E_DrinkIngredients
        {
            Coffee,
            Milk,
            Water,
            Coco,
            Bubble
            
            
        }

        public static event Action<E_DrinkIngredients> st_selectIngredient;
        public static event Action st_dropIngredient; 

        public static void st_OnSelectCoffee(E_DrinkIngredients ingredient)
        {
            st_selectIngredient?.Invoke(ingredient);
        }

        public static void st_OnDropIngredient()
        {
            st_dropIngredient?.Invoke();
        }
    }
}