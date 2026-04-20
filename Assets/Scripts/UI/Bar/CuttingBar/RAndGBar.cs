using System;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Bar.CuttingBar
{
    public class RAndGBar : MonoBehaviour
    {
        public static RAndGBar instance;
        public Image redBar;
        public Image greenBar;

        public int redBarMaxValue;
        public int greenBarMaxValue;

        private int redBarCurrentValue;
        private int greenBarCurrentValue;
        private void Awake()
        {
            instance = this;
            
            redBarCurrentValue = -1;
            greenBarCurrentValue = 0;

            
        }

        private void Update()
        {
            redBar.fillAmount = (float)redBarCurrentValue / redBarMaxValue;
            greenBar.fillAmount = (float)greenBarCurrentValue / greenBarMaxValue;
        }

        public void AddCurrentbar(int index)
        //0是绿 1是红
        {
            if (index == 0)
            {
                greenBarCurrentValue++;
            }
            else if (index == 1)
            {
                redBarCurrentValue++;
            }
            else
            {
                Debug.LogError("Color index is illegal");
            }
        }
        public void SetCurrentbar(int index,int value)
            //0是绿 1是红
        {
            if (index == 0)
            {
                greenBarCurrentValue = value;
            }
            else if (index == 1)
            {
                redBarCurrentValue = value;
            }
            else
            {
                Debug.LogError("Color index is illegal");
            }
        }

        public int GetCurrentBar(int index)
        {
            if (index == 0)
            {
                return greenBarCurrentValue;
            }
            if (index == 1)
            {
                return redBarCurrentValue;
            }

            return 0;
        }
        
        
    }
}