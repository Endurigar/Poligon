using Containers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HightScoreCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text hightScoreText;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text lastScoreText;
        private int score = 0;
        private int hightScore;
        private const string PlayerPrefsKey = "HightScore";

        private void Start()
        {
            hightScore = PlayerPrefs.GetInt(PlayerPrefsKey);
            hightScoreText.text = hightScore.ToString();
            AddListener();
        }

        private void AddListener()
        {
            ActionContainer.OnTimeOut += () => LastScoreHandler();
            ActionContainer.OnReset += () => LastScoreHandler();
            ActionContainer.OnHittingTheTarget += () => ScoreCounter();
        }

        private void ScoreCounter()
        {
            score++;
            scoreText.text = score.ToString();
            if (score > hightScore)
            {
                hightScore = score;
                PlayerPrefs.SetInt(PlayerPrefsKey, hightScore);
                hightScoreText.text = hightScore.ToString();
            }
        }

        private void LastScoreHandler()
        {
            lastScoreText.text = score.ToString();
            score = 0;
            scoreText.text = score.ToString();
        }
    }
}