using UnityEngine;
using Utils;

namespace System.CookingItemTrigger
{
    public class CookingItemParent:MonoBehaviour,CookingRoomItem
    {
        protected Vector2 vector2;
        protected bool interactRequested = false;
        protected bool playerInRange = false;
        protected Transform playerTransform = null;
        
        private void OnEnable() => CookingEventListener.st_vector+= setVector;
        private void OnDisable()  => CookingEventListener.st_vector-= setVector;
        private void setVector(Vector2 vector2) => this.vector2 = vector2;
        
        protected virtual void Update()
        {
            // 每渲染帧捕捉按键
            if (playerInRange && Input.GetKeyDown(KeyCode.E) && isFacingThisItem(playerTransform))
            {
                interactRequested = true;
            }
        }
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
                playerTransform = other.transform;
            }
            
        }

        private void OnTriggerStay2D(Collider2D other)
        {
           
            CookingEventListener.st_OnEnterType(GetType());
        }


        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
                playerTransform = null;
                interactRequested = false; // 离开时重置请求
            }
            CookingEventListener.st_OnExitType();
        }
        
        protected void FixedUpdate()
        {
            if (interactRequested)
            {
                InteractionItem();

                interactRequested = false; // 处理完后清除
            }
        }
        
        
        
        protected bool isFacingThisItem(Transform playerTransform)
        {
           
            Vector2 dirToItem = (transform.position - playerTransform.position).normalized;
            Vector2 playerDir = vector2; 
            float dot = Vector2.Dot(dirToItem, playerDir);
            return dot > 0.7f; 
        }
        
        protected virtual void InteractionItem(){}
        
        
    }
}