using System;
using Containers;
using TMPro;
using UnityEngine;

namespace Utilities
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;
        private float maxTime = 60f;

        private void Update()
        {
            TimeCounter();
            AddListener();
        }

        private void AddListener()
        {
            ActionContainer.OnReset += () => maxTime = 60f;
        }

        private void TimeCounter()
        {
            if (maxTime > 0)
            {
                maxTime -= Time.deltaTime;
                timerText.text = Math.Round(maxTime).ToString();
            }
            else
            {
                ActionContainer.OnTimeOut();
                maxTime = 60f;
            }
        }
    }
}