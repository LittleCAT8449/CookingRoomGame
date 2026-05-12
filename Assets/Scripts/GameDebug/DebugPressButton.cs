using UnityEngine;

namespace GameDebug
{
    public class DebugMainPressButton : MonoBehaviour
    {
        [SerializeField] private GameObject childObject;
        private int clicks=1;
        public void ButtonClick()
        {
            if (clicks % 2 == 0)
            {
                childObject.SetActive(false);            
            }
            else
            {
                childObject.SetActive(true);
            }

            clicks++;


        }
    }
}