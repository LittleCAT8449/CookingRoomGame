using System;
using UnityEngine;

namespace UI.Bar.CuttingBar
{
    public class CuttingBar : MonoBehaviour
    {

        public static CuttingBar instance;
        public GameObject justiceBar;
        public GameObject UI;
        public float moveSpeed = 3;
        public bool enterGame;
        public bool startGame;

        public bool canMaking = false;

        private bool cuttingResultBool=false;
         
        private void Start()
        {
            instance = this;
            UI.gameObject.SetActive(false);
            startGame = false;
        }

        private void Update()
        {
            // 只有在游戏界面开启、且没开始时，按C才启动
            if (enterGame && !startGame && Input.GetKeyDown(KeyCode.C))
            {
                startGame = true;
                canMaking = false; // 一开始强制不能切菜
            }

            if (startGame)
            {
                justiceBar.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }

            if (enterGame)
            {
                UI.gameObject.SetActive(true);
            }
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
            CookingEventListener.st_cuttingMakingSuccessful += SetSuccessfulMaking;
            CookingEventListener.st_cuttingMakingFalse += SetFalseMaking;
        }

        private void OnDisable()
        {
            CookingEventListener.st_cuttingMakingSuccessful -= SetSuccessfulMaking;
            CookingEventListener.st_cuttingMakingFalse -= SetFalseMaking;
        }
    }
}