using UI.Bar.BurnishBar;
using UnityEngine;

namespace System.CookerInteract.BurnishBoardAndCheck
{
    public class FishCheckLine : MonoBehaviour
    {
        public float topBoundLocal = -69f;
        public float bottomBoundLocal = -317f;
        public float moveSpeed = 3f;

        private float dirY;
        private float slowTimer;
        public readonly int totalAddPerSec = 10;

        private RectTransform barRect;
        public RectTransform fishRect;

        private bool gameIsFinished = false;
        private Vector3 initialLocalPos;      // 记录初始局部坐标
        private bool lastStartGame = false;    // 记录上一帧的游戏状态

        private void Start()
        {
            // 记录初始位置（此时场景中摆放的位置）
            initialLocalPos = transform.localPosition;

            // 确保初始位置在边界内（防止编辑器里超出范围）
            Vector3 localPos = transform.localPosition;
            localPos.y = Mathf.Clamp(localPos.y, bottomBoundLocal, topBoundLocal);
            transform.localPosition = localPos;

            barRect = GetComponent<RectTransform>();
        }

        private void Update()
        {
            // 检测游戏是否刚刚开始（从 false 变为 true）
            if (BurnishBar.instance.startGame && !lastStartGame)
            {
                // 重置判定线位置到初始位置
                transform.localPosition = initialLocalPos;
                // 可选：重置计时器，避免残留数值
                slowTimer = 0f;
            }
            lastStartGame = BurnishBar.instance.startGame;

            // 移动逻辑：只在游戏进行时执行
            if (BurnishBar.instance.startGame)
            {
                // 根据按键决定方向（按住 C 向上，否则向下）
                if (Input.GetKey(KeyCode.C))
                    dirY = 1;
                else
                    dirY = -1;

                // 移动并限制边界
                Vector3 newLocalPos = transform.localPosition + Vector3.up * dirY * moveSpeed * Time.deltaTime;
                newLocalPos.y = Mathf.Clamp(newLocalPos.y, bottomBoundLocal, topBoundLocal);
                transform.localPosition = newLocalPos;
            }
            else
            {
                dirY = 0;   // 游戏未开始时停止移动
            }

            // 游戏进行中才累加进度值
            if (BurnishBar.instance.startGame)
            {
                if (RectOverlapCheck(barRect, fishRect))
                {
                    slowTimer += totalAddPerSec * Time.deltaTime;
                    if (slowTimer >= 1)
                    {
                        BurnishBar.instance.currentGreenValue++;
                        slowTimer -= 1;
                    }
                }
                else
                {
                    slowTimer += totalAddPerSec * Time.deltaTime;
                    if (slowTimer >= 1)
                    {
                        BurnishBar.instance.currentRedValue++;
                        slowTimer -= 1;
                    }
                }
            }

            MakingResult();
        }

        private bool RectOverlapCheck(RectTransform rect1, RectTransform rect2)
        {
            Rect rect1World = rect1.rect;
            rect1World.position += (Vector2)rect1.transform.position;

            Rect rect2World = rect2.rect;
            rect2World.position += (Vector2)rect2.transform.position;

            return rect1World.Overlaps(rect2World);
        }

        private void MakingResult()
        {
            if (gameIsFinished) return;

            if (BurnishBar.instance.currentGreenValue >= BurnishBar.instance.maxGreenValue)
            {
                gameIsFinished = true;
                BurnishBar.instance.startGame = false;

                CookingEventListener.st_OnBurnishSuccessful();
                ResetGame();
            }
            else if (BurnishBar.instance.currentRedValue >= BurnishBar.instance.maxRedValue)
            {
                gameIsFinished = true;
                BurnishBar.instance.startGame = false;

                CookingEventListener.st_OnBurnishFalse();
                ResetGame();
            }
        }

        private void ResetGame()
        {
            gameIsFinished = false;
            BurnishBar.instance.startGame = false;
            BurnishBar.instance.enterGame = false;
            BurnishBar.instance.currentGreenValue = 0;
            BurnishBar.instance.currentRedValue = 0;

            // 注意：这里不重置位置，位置会在下一次游戏开始时（startGame 变为 true 时）自动重置
            // 这样避免在 ResetGame 时立即重置，导致可能在外部又被移动
        }
    }
}