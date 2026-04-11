using UnityEngine;

public class PlayerSortController : MonoBehaviour
{
    public int normalOrder =11 ;    // 正常层级
    public int afterOrder = 0;  // 在后面时的层级

    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void SetBehined(bool isBehind)
    {
        if (isBehind)
        {
            sr.sortingOrder = afterOrder-1;
        }
        else
        {
            sr.sortingOrder = normalOrder;
        }
    }
}