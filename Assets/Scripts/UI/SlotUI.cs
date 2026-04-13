using System;
using System.Collections;
using System.Collections.Generic;
using Manager.InventoryManager;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public static SlotUI[] slots= new SlotUI[4];

    public Image icon;
    public int slotIndex;

    private void Awake()
    {
        slots[slotIndex] = this;
    }

    public void SetItem(Item item)
    {
        if (item != null)
        {
            icon.sprite = item.itemIcon;
            icon.enabled = true;
        }
        else
        {
            icon.sprite = null;
            icon.enabled = false;
        }
    }

    public void OnClickClear()
    {
        Inventory.instance.ClearItem(slotIndex);
    }
    
}
