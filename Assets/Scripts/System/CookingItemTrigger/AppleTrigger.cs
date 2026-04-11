using Unity.VisualScripting;
using UnityEngine;
using Utils;

namespace System.CookingItemTrigger
{
    public class AppleTrigger : CookingItemParent
    {
        

        private void Update()
        {
            // 每渲染帧捕捉按键
            if (playerInRange && Input.GetKeyDown(KeyCode.E) && isFacingThisItem(playerTransform))
            {
                interactRequested = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
                playerTransform = other.transform;
            }
        }

        

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
                playerTransform = null;
                interactRequested = false; // 离开时重置请求
            }
        }

        // 在 FixedUpdate 或 OnTriggerStay2D 中处理请求
        private void FixedUpdate()
        {
            if (interactRequested)
            {
                Debug.Log($"{playerTransform?.name} Interacted with Apple!");
                // 执行互动逻辑

                interactRequested = false; // 处理完后清除
            }
        }

        
       
    }
}