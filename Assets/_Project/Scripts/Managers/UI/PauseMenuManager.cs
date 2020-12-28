using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class PauseMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject canvasGO;
        [SerializeField] private GameObject settingsCanvasGO;
        [SerializeField] private GameScene[] ignoreScenes;

        private void Start() => InputManager.Instance.Gameplay.PauseGame.performed += OnPauseGameInput;

        private void OnDestroy() => InputManager.Instance.Gameplay.PauseGame.performed -= OnPauseGameInput;

        private void PauseGame()
        {
            canvasGO.SetActive(true);
            ApplicationManager.Instance.PauseGame();
        }

        private void ResumeGame()
        {
            canvasGO.SetActive(false);
            settingsCanvasGO.SetActive(false);
            ApplicationManager.Instance.ResumeGame();   
        }

        private void OnPauseGameInput(InputAction.CallbackContext context)
        {
            if (ignoreScenes.Any(scene => scene.ToString() == ApplicationManager.Instance.ActiveScene.name)) return;
            if (ApplicationManager.Instance.IsGamePaused) ResumeGame();
            else PauseGame();
        }

        public void OnResumeButtonClick() => ResumeGame();

        public void OnMainMenuButtonClick()
        {
            ResumeGame();
            ApplicationManager.Instance.LoadScene(GameScene.MainMenu);
        }

        public void OnQuitGameButtonClick() => ApplicationManager.Instance.ExitApplication();

        public void onSettingsButtonClick()
        {
            settingsCanvasGO.SetActive(true);
            canvasGO.SetActive(false);
        }
    }
}