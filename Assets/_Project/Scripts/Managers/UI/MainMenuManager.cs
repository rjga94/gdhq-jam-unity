using UnityEngine;

namespace Managers
{
    public class MainMenuManager : MonoBehaviour
    {
        public void OnStartGameButtonClick() => ApplicationManager.Instance.LoadScene(GameScene.Level_1);

        public void OnQuitGameButtonClick() => ApplicationManager.Instance.ExitApplication();
    }
}