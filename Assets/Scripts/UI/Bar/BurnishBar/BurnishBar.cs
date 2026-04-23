using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Bar.BurnishBar
{
    public class BurnishBar : MonoBehaviour
    {
        public static BurnishBar instance; 
        
        public Image greenBar;
        public Image redBar;
        
        public GameObject UI;
        

        public int maxRedValue=100;
        public int maxGreenValue=80;

        public int currentRedValue;
        public int currentGreenValue;
        
        public bool enterGame;
        public bool startGame;
        
        

        private void Start()
        {
            instance = this;
            currentGreenValue = 0;
            currentRedValue = 0;
            startGame = false;
            UI.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (enterGame && !startGame && Input.GetKeyDown(KeyCode.C))
            {
                startGame = true; // 一开始强制不能切菜
            }
            
            if (enterGame)
            {
                UI.gameObject.SetActive(true);
            }
            
            
            greenBar.fillAmount = (float)currentGreenValue / maxGreenValue;
            redBar.fillAmount = (float)currentRedValue / maxRedValue;
        }
        
        private void SetSuccessfulMaking()
        {
            startGame = false;
            enterGame = false;
            UI.SetActive(false);
        }

        private void SetFalseMaking()
        {
            startGame = false;
            enterGame = false;
            UI.SetActive(false);
        }
        
        
        private void OnEnable()
        {
            CookingEventListener.st_burnishMakingSuccessful += SetSuccessfulMaking;
            CookingEventListener.st_burnishMakingFalse += SetFalseMaking;
        }

        private void OnDisable()
        {
            CookingEventListener.st_burnishMakingSuccessful -= SetSuccessfulMaking;
            CookingEventListener.st_burnishMakingFalse -= SetFalseMaking;
        }
        
    }
}