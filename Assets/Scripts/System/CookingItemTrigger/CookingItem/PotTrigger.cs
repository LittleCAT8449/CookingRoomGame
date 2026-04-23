using System.CookerInteract;
using System.CookingItemTrigger;
using UnityEngine;

public class PotTrigger : CookingItemParent
{
    public Pot targetPot;   // 在 Inspector 中拖入对应的锅

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);   // 保留基类逻辑（设置 playerInRange = true 等）
        if (other.CompareTag("Player"))
        {
            Pot.currentFocusedPot = targetPot;
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (other.CompareTag("Player") && Pot.currentFocusedPot == targetPot)
        {
            Pot.currentFocusedPot = null;
        }
    }

    protected override void InteractionItem()
    {
        if (targetPot != null)
            targetPot.Interact();   // 处理取出成品或清理垃圾
    }
}