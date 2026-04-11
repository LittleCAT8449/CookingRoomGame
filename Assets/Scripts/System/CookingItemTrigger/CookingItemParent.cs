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
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
                playerTransform = other.transform;
            }
        }

        

        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
                playerTransform = null;
                interactRequested = false; // 离开时重置请求
            }
        }
        
        
        
        
        protected bool isFacingThisItem(Transform playerTransform)
        {
           
            Vector2 dirToItem = (transform.position - playerTransform.position).normalized;
            Vector2 playerDir = vector2; 
            float dot = Vector2.Dot(dirToItem, playerDir);
            return dot > 0.7f; 
        }
        
        
        
    }
}