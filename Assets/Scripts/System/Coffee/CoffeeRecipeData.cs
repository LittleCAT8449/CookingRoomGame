using Event;
using UnityEngine;

namespace System.Coffee
{
    /// <summary>
    /// 咖啡配方数据：在 Inspector 中设置一个输出物和 5 个所需原料。
    /// </summary>
    [CreateAssetMenu(fileName = "CoffeeRecipeData", menuName = "Recipe Data/Coffee")]
    public class CoffeeRecipeData : ScriptableObject
    {
        [Header("Output")]
        public Item outputObject;

        [Header("Required Ingredients")]
        public CoffeeEventListener.E_DrinkIngredients ingredient1;
        public CoffeeEventListener.E_DrinkIngredients ingredient2;
        public CoffeeEventListener.E_DrinkIngredients ingredient3;
        public CoffeeEventListener.E_DrinkIngredients ingredient4;
        public CoffeeEventListener.E_DrinkIngredients ingredient5;
    }
}
