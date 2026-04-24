using UnityEngine;
using UnityEngine.UI;

namespace UI.Bar.PotBar
{
    public class PotBar : MonoBehaviour
    {
        public Image progressGreenImage;   // 绿色进度条（Type = Filled）
        public Image progressRedImage;     // 红色进度条（Type = Filled）
        public GameObject progressBarObj;  // 整个进度条物体的根（用于显隐）

        public float maxGreenValue = 20f;
        public float maxRedValue = 30f;

        private float currentGreenValue;
        private float currentRedValue;

        private void Start()
        {
            ResetUI();
            if (progressBarObj != null)
                progressBarObj.SetActive(false);
        }

        private void Update()
        {
            UpdatePotUI();
        }

        public void ResetUI()
        {
            currentGreenValue = 0;
            currentRedValue = 0;
        }

        /// <summary>
        /// 设置绿色进度（归一化值 0~1）
        /// </summary>
        public void SetGreenProgress(float normalized)
        {
            currentGreenValue = Mathf.Clamp01(normalized) * maxGreenValue;
        }

        /// <summary>
        /// 设置红色进度（归一化值 0~1）
        /// </summary>
        public void SetRedProgress(float normalized)
        {
            currentRedValue = Mathf.Clamp01(normalized) * maxRedValue;
        }

        /// <summary>
        /// 显示进度条面板
        /// </summary>
        public void Show()
        {
            if (progressBarObj != null)
                progressBarObj.SetActive(true);
        }

        /// <summary>
        /// 隐藏进度条面板
        /// </summary>
        public void Hide()
        {
            if (progressBarObj != null)
                progressBarObj.SetActive(false);
        }

        private void UpdatePotUI()
        {
            
            if (progressGreenImage != null)
                progressGreenImage.fillAmount = currentGreenValue / maxGreenValue;
               
            if (progressRedImage != null)
                progressRedImage.fillAmount = currentRedValue / maxRedValue;
                
        }
    }
}