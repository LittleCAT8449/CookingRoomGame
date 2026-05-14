using UnityEngine;

namespace Manager.RandomAndCheckManager
{
    public class NumberButtonConfirmClick : MonoBehaviour
    {
        [SerializeField] private RandomNumber number;

        public void ButtonClick()
        {
            if (number.MakineDone())
            {
                // 检查是否有正在等待的烹饪台
                if (CookMake.CurrentCooking != null)
                {
                    CookMake.CurrentCooking.GiveOutput();
                    Debug.Log("数字正确，获得成品！");
                }
                else
                {
                    Debug.LogWarning("没有活跃的烹饪过程！");
                }
            }
            else
            {
                Debug.Log("数字顺序错误！");
            }
        }
    }
}
