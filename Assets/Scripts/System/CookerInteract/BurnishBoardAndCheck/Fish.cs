using UI.Bar.BurnishBar;
using UnityEngine;

public class Fish : MonoBehaviour
{
    // 这些边界是相对于父物体的局部坐标
    public float topBoundLocal = -69f;
    public float bottomBoundLocal = -317f;
    public float moveSpeed = 3f;

    private float randomChangeDirTimer;
    private float nextChangeInterval;
    private float dirY; // 1 = 向上, -1 = 向下

    private void Start()
    {
        dirY = Random.value > 0.5f ? 1 : -1;
        nextChangeInterval = Random.Range(0.4f, 1.2f);
        
        // 确保初始局部位置在边界内
        Vector3 localPos = transform.localPosition;
        localPos.y = Mathf.Clamp(localPos.y, bottomBoundLocal, topBoundLocal);
        transform.localPosition = localPos;
    }

    private void Update()
    {
        // 随机换向计时
        if (BurnishBar.instance.startGame)
        {
            randomChangeDirTimer += Time.deltaTime;
            if (randomChangeDirTimer >= nextChangeInterval)
            {
                dirY *= -1;
                randomChangeDirTimer = 0;
                nextChangeInterval = GetRandomTurnInteral();
            }

            // 移动（局部坐标）
            Vector3 newLocalPos = transform.localPosition + Vector3.up * dirY * moveSpeed * Time.deltaTime;
            newLocalPos.y = Mathf.Clamp(newLocalPos.y, bottomBoundLocal, topBoundLocal);
            transform.localPosition = newLocalPos;
        }

        // 边界处强制反向（避免一直贴边）
        if (transform.localPosition.y <= bottomBoundLocal) dirY = 1;
        if (transform.localPosition.y >= topBoundLocal) dirY = -1;
    }

    private float GetRandomTurnInteral()
    {
        if (UnityEngine.Random.value < 0.7f)
            return UnityEngine.Random.Range(3f, 5f);
        else
            return Random.Range(0.8f, 2.5f);
    }
}