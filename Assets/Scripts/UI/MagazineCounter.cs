using Containers;
using TMPro;
using UnityEngine;
using Weapon;

namespace UI
{
    public class MagazineCounter : MonoBehaviour
    {
        [SerializeField] private ShootingPattern shootingPattern;
        private TMP_Text numberOfBulletsText;
        private int numberOfBullets;

        private void Start()
        {
            numberOfBulletsText = gameObject.GetComponent<TMP_Text>();
            numberOfBulletsText.text = $"{numberOfBullets = shootingPattern.magazine}/∞";
            AddListener();
        }

        private void AddListener()
        {
            ActionContainer.OnShoot += (() => numberOfBulletsText.text = $"{numberOfBullets -= 1}/∞");
            ActionContainer.OnReloadEnd += () => numberOfBulletsText.text = $"{numberOfBullets = shootingPattern.magazine}/∞";
        }
    }
}
