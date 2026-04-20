using System;
using UnityEngine;
using System.Collections.Generic;

namespace UI.Bar.CuttingBar
{
    public class SpawnAndCheck : MonoBehaviour
    {
        public RectTransform checkLine;
        public Note notePrefab;
        public int noteCount = 5;
        public float spawnInterval = 1.0f;
        public Transform noteParent;
        private List<Note> notes = new List<Note>();
        private float spawnTimer;

        private int currentIndex;

        // 加在这里
        private bool gameIsFinished = false; // 游戏是否结束
        private float resultDelay = 0.2f; // 延迟触发结果，避免瞬间判定

        private void Start()
        {
            for (int i = 0; i < noteCount; i++)
            {
                Note note = Instantiate(notePrefab, noteParent);
                notes.Add(note);
            }
        }

        private void Update()
        {
            if (!CuttingBar.instance.startGame) return;
            if (gameIsFinished) return; // 结束后直接不更新

            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                SpawnNextNote();
                spawnTimer = 0;
            }

            foreach (var note in notes)
            {
                if (!note.isActiveAndEnabled) continue;
                RectTransform noteRT = note.GetComponent<RectTransform>();
                float noteLeft = note.GetCurrentX() - noteRT.rect.width / 2;
                if (noteLeft < checkLine.anchoredPosition.x - 200)
                {
                    note.ResetNote();
                }
            }

            // 游戏没结束才能按C判定
            if (Input.GetKeyDown(KeyCode.C) && !gameIsFinished)
            {
                Judge();
            }

            MakingResult();
        }

        private void SpawnNextNote()
        {
            Note note = notes[currentIndex];
            note.StartMoving();
            currentIndex = (currentIndex + 1) % notes.Count;
        }

        private void Judge()
        {
            if (!CuttingBar.instance.startGame) return;

            float lineX = checkLine.anchoredPosition.x;
            foreach (var note in notes)
            {
                if (!note.gameObject.activeSelf) continue;

                RectTransform noteRT = note.GetComponent<RectTransform>();
                float left = noteRT.anchoredPosition.x - noteRT.rect.width + 50;
                float right = noteRT.anchoredPosition.x + noteRT.rect.width + 50;

                // 只要判定线在方块内部就成功
                if (lineX >= left && lineX <= right)
                {
                    Debug.Log("Successful");
                    RAndGBar.instance.AddCurrentbar(0);
                    note.ResetNote();
                    return;
                }
            }

            Debug.Log("false");
            RAndGBar.instance.AddCurrentbar(1);
        }

        private void MakingResult()
        {
            if (gameIsFinished) return;

            if (RAndGBar.instance.GetCurrentBar(0) >= 8)
            {
                gameIsFinished = true;
                CuttingBar.instance.startGame = false;
        
                // 直接触发成功
                CookingEventListener.st_OncuttingSuccessful();
                ResetGame();
            }
            else if (RAndGBar.instance.GetCurrentBar(1) >= 3)
            {
                gameIsFinished = true;
                CuttingBar.instance.startGame = false;
        
                // 直接触发失败
                CookingEventListener.st_OncuttingFalse();
                ResetGame();
            }
            
            
        }
       

        private void ResetGame()
        {
            gameIsFinished = false;  // 游戏可以重新开始
            CuttingBar.instance.startGame = false;
            CuttingBar.instance.enterGame = false;
            

            // 重置进度条
            RAndGBar.instance.SetCurrentbar(0, 0);
            RAndGBar.instance.SetCurrentbar(1, -1);

            // 【关键】重置所有音符位置
            foreach (var note in notes)
            {
                note.ResetNote(); // 让每个音符自己重置
            }

            currentIndex = 0;       // 重置生成顺序
            spawnTimer = 0; 
        }


    }
}
