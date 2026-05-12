using System.Collections.Generic;
using UnityEngine;

namespace System.CookedFood
{
    [CreateAssetMenu(fileName = "FoodRecipeData", menuName = "Recipe Data/Food")]
    public class CookedFoodItemRecipe : ScriptableObject
    {
        [Header("OutPut")] 
        public Item outPutItem;

        [Header("Ingredients")] 
        public List<Item> ingredient = new List<Item>();


    }
}