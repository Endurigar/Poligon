using System;
using System.Collections;
using System.Collections.Generic;
using Containers;
using TMPro;
using UnityEngine;

public class HightScoreCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text hightScoreText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text lastScoreText;
    private int score = 0;
    private int hightScore;

    private void Start()
    {
        hightScore = PlayerPrefs.GetInt("HightScore");
        hightScoreText.text = hightScore.ToString();
        AddListener();
    }

    private void AddListener()
    {
        ActionContainer.OnTimeOut += () => LastScoreHandler(); 
        ActionContainer.OnReset += () => LastScoreHandler(); 
        ActionContainer.OnHittingTheTarget += () =>
        {
            score++;
            scoreText.text = score.ToString();
            if (score > hightScore)
            {
                hightScore = score;
                PlayerPrefs.SetInt("HightScore",hightScore);
                hightScoreText.text = hightScore.ToString();
            }
        };
    }

    private void LastScoreHandler()
    {
        lastScoreText.text = score.ToString();
        score = 0;
        scoreText.text = score.ToString();
    }
}
