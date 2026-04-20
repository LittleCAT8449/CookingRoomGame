using System;
using UnityEngine;

namespace UI.Bar.CuttingBar
{
    public class Note : MonoBehaviour
    {
        public float moveSpeed;
        private RectTransform _rectTransform;
        private bool isActive = false;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.anchoredPosition = new Vector2(230, 0);
            gameObject.SetActive(false);

        }

        private void Update()
        {
            if (!isActive||!CuttingBar.instance.startGame) return;

            _rectTransform.anchoredPosition += Vector2.left * moveSpeed * Time.deltaTime;
        }

        public void StartMoving()
        {
            gameObject.SetActive(true);
            isActive = true;
            _rectTransform.anchoredPosition = new Vector2(230, 0);
        }


        public void ResetNote()
        {
            isActive = false;
            gameObject.SetActive(false);
            _rectTransform.anchoredPosition = new Vector2(230, 0);
        }

        public void MissNote()
        {
            ResetNote();
        }

        public float GetCurrentX()
        {
            return _rectTransform.anchoredPosition.x;
        }
    }
}