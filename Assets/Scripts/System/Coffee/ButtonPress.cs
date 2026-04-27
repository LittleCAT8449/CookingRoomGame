using Event;
using UnityEngine;

namespace System.Coffee
{
    /// <summary>
    /// 按钮点击日志脚本。
    /// 用处：挂到 Unity Button 上，点击后在 Console 输出当前点了什么按钮。
    /// </summary>
    public class ButtonPress : MonoBehaviour
    {
        
        [SerializeField] private string buttonName;
        [SerializeField] private CoffeeEventListener.E_DrinkIngredients ingredients;

        /// <summary>
        /// Unity Button 的 OnClick 绑定这个方法。
        /// </summary>
        public void ButtonClick()
        {
            string displayName = string.IsNullOrWhiteSpace(buttonName) ? gameObject.name : buttonName;
            Debug.Log($"点击了按钮：{displayName}");
            CoffeeEventListener.st_OnSelectCoffee(ingredients);
            
        }
    }
}
