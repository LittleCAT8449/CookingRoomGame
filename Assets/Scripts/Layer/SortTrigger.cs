using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SortTrigger : MonoBehaviour
{
    private TilemapRenderer layer;

    private void Awake()
    {
        layer = GetComponentInParent<TilemapRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerSort = other.GetComponent<PlayerSortController>();
        if (playerSort != null)
        {
            playerSort.afterOrder = layer.sortingOrder;
            playerSort.SetBehined(true);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var playerSort = other.GetComponent<PlayerSortController>();
        if (playerSort != null)
        {
            playerSort.SetBehined(false);
        }
    }
}