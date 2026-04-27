using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace System.Coffee
{
    public class CoffeeClose : MonoBehaviour
    {
        [SerializeField] private GameObject coffeeGame;
        [SerializeField] private GameObject makingObject;
        [SerializeField] private GameObject resultObject;
        [SerializeField] private Image resultCoffeeImage;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Sprite emptySprite;
        [SerializeField] private List<CoffeeIngredientUI> ingredientUis;
        [SerializeField] private CoffeeCup coffeeCup;


        public void OnClick()
        {
            // 重置数据层（清空原料列表）
            coffeeCup.ResetList();

            // 重置每个 UI 的贴图（会清空显示）
            foreach (var ui in ingredientUis)
            {
                if (ui != null)
                    ui.ResetIngredient();
            }

            // 关闭咖啡制作面板
            
            resultCoffeeImage.sprite = emptySprite;
            text.text = "null";
            makingObject.SetActive(true);
            resultObject.SetActive(false);
            coffeeGame.SetActive(false);
        }
    }
}