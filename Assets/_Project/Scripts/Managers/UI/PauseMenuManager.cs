using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class PauseMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject canvasGO;
        [SerializeField] private GameScene[] ignoreScenes;
        
        private void PauseGame()
        {
            canvasGO.SetActive(true);
            ApplicationManager.Instance.PauseGame();
        }

        private void ResumeGame()
        {
            canvasGO.SetActive(false);
            ApplicationManager.Instance.ResumeGame();   
        }

        public void OnPauseGameInput(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
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
    }
}