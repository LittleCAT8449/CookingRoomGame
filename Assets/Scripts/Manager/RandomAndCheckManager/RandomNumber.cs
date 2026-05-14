using System;
using System.Collections.Generic;
using System.Linq;
using Event;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Manager.RandomAndCheckManager
{
    public class RandomNumber : MonoBehaviour
    {
        private List<int> number = new List<int>();
        private List<int> numberPress = new List<int>();
        [SerializeField] private TextMeshProUGUI text;

        private void Awake()
        {
            text.text = "";
        }

        /// <summary>
        /// 开始新回合：生成6位随机数（1~5），并清空所有输入记录
        /// </summary>
        public void StartNewRound()
        {
            number.Clear();
            numberPress.Clear();

            for (int i = 0; i < 6; i++)
            {
                number.Add(Random.Range(1, 6)); // 范围1~5，若需1~6请改为(1,7)
            }

            text.text = string.Join(", ", number);

            Debug.Log("随机序列：" + string.Join(", ", number));
        }

        /// <summary>
        /// 检查输入是否与生成序列完全一致（顺序需相同）
        /// </summary>
        public bool MakineDone()
        {
            if (number.Count != numberPress.Count)
                return false;
            return number.SequenceEqual(numberPress);
        }

        private void OnEnable() => PressNumberListener.st_pressNumber += NumberCount;
        private void OnDisable() => PressNumberListener.st_pressNumber -= NumberCount;

        private void NumberCount(int num) => numberPress.Add(num);
    }
}