using UnityEngine;
using System.Collections.Generic;
using Event;
using Manager.InventoryManager;
using TMPro;
using UnityEngine.UI; // 你的 Item 类型所在命名空间

namespace System.Coffee
{
    public class CoffeeCheck : MonoBehaviour
    {
        [SerializeField] private GameObject makingObject;
        [SerializeField] private GameObject resultObject;
        [SerializeField] private CoffeeCup coffeeCup;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image resultItemImage; 
        [SerializeField] private List<CoffeeRecipeData> recipeList;

        public void RightButtonClick()
        {
            CoffeeRecipeData matchedRecipe = GetMatchedRecipe();
            if (matchedRecipe != null)
            {
                Item outputItem = matchedRecipe.outputObject;
                Debug.Log($"配方正确！产出：{outputItem?.name}");
                Inventory.Instance.AddItem(outputItem);
                resultItemImage.sprite = outputItem.itemIcon;
                text.text = outputItem.name;
                resultObject.SetActive(true);
                makingObject.SetActive(false);
                
                


                // TODO: 实际产出物品的逻辑，比如：
                // if (outputItem != null) InventoryManager.Instance.AddItem(outputItem);
            }
            else
            {
                Debug.Log("配方错误");
            }
        }

        /// <summary>
        /// 返回当前咖啡杯原料所匹配的配方，若没有匹配则返回 null。
        /// </summary>
        public CoffeeRecipeData GetMatchedRecipe()
        {
            if (coffeeCup == null || recipeList == null || recipeList.Count == 0)
                return null;

            var ingredientsList = coffeeCup.IngredientsList;
            if (ingredientsList == null || ingredientsList.Count != 5)
                return null;

            foreach (var recipe in recipeList)
            {
                if (recipe == null) continue;

                // 顺序匹配（严格要求原料顺序与配方设定的顺序一致）
                if (ingredientsList[0] == recipe.ingredient1 &&
                    ingredientsList[1] == recipe.ingredient2 &&
                    ingredientsList[2] == recipe.ingredient3 &&
                    ingredientsList[3] == recipe.ingredient4 &&
                    ingredientsList[4] == recipe.ingredient5)
                {
                    return recipe;
                }
            }
            return null;
        }

        // 保留原方法，方便其他地方调用（如果只需要 bool）
        public bool IsMatchRecipe()
        {
            return GetMatchedRecipe() != null;
        }
        

        public void DropIngredient()
        {
            
            CoffeeEventListener.st_OnDropIngredient();
            
        }
    }
}