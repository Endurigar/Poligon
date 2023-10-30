using Containers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DifficultyChanger : MonoBehaviour
    {
        [SerializeField] private Button buttonEasyDifficulty;
        [SerializeField] private Button buttonMidDifficulty;
        [SerializeField] private Button buttonHardDifficulty;

        private void Start()
        {
            buttonEasyDifficulty.onClick.AddListener(ChangeDifficultyToEasy);
            buttonMidDifficulty.onClick.AddListener(ChangeDifficultyToMid);
            buttonHardDifficulty.onClick.AddListener(ChangeDifficultyToHard);
        }

        private void ChangeDifficultyToEasy()
        {
            ActionContainer.OnDifficultyChange(2f);
        }

        private void ChangeDifficultyToMid()
        {
            ActionContainer.OnDifficultyChange(1f);
        }

        private void ChangeDifficultyToHard()
        {
            ActionContainer.OnDifficultyChange(0.5f);
        }
    }
}