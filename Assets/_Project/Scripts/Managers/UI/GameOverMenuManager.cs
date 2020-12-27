using UnityEngine;
using Utilities;

namespace Managers
{
    public class GameOverMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject canvasGO;

        public void Show()
        {
            canvasGO.SetActive(true);
            ApplicationManager.Instance.PauseGame();
        }

        public void OnTryAgainButtonClick() => ApplicationManager.Instance.ReloadActiveScene();

        public void OnQuitButtonClick() => ApplicationManager.Instance.LoadScene(GameScene.MainMenu);
    }
}