using Cinemachine;
using Containers;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Utilities;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button resetButton;
        [SerializeField] private TMP_Dropdown dropdown;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private FirstPersonController firstPersonController;
        private CinemachineBrain cinemachineBrain;

        private void Start()
        {
            cinemachineBrain = Camera.main.gameObject.GetComponent<CinemachineBrain>();
            resumeButton.onClick.AddListener(MenuHandler);
            exitButton.onClick.AddListener(ExitGame);
            resetButton.onClick.AddListener(OnReset);
            AddListener();
        }

        private void AddListener()
        {
            playerInput.actions["Menu"].started += OnMenu;
            ActionContainer.OnTimeOut += () => MenuHandler();
            dropdown.onValueChanged.AddListener(СhangeMod);
        }

        public void OnMenu(InputAction.CallbackContext context)
        {
            MenuHandler();
        }

        private void MenuHandler()
        {
            menu.SetActive(!menu.activeSelf);
            firstPersonController.enabled = !menu.activeSelf;
            Cursor.lockState = menu.activeSelf ? CursorLockMode.Confined : CursorLockMode.Locked;
            Cursor.visible = menu.activeSelf;
            cinemachineBrain.enabled = !menu.activeSelf;
            Time.timeScale = menu.activeSelf ? 0f : 1f;
        }

        private void СhangeMod(int modID)
        {
            ActionContainer.OnModeChanged?.Invoke((ModsEnum)modID);
        }

        private void ExitGame() => Application.Quit();

        private void OnReset() => ActionContainer.OnReset();
    }
}