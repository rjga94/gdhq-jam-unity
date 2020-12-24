using UnityEngine;

namespace Managers
{
    public class MainMenuManager : MonoBehaviour
    {
        public void OnStartGameButtonClick() => ApplicationManager.LoadScene("Level_1");

        public void OnQuitButtonClick() => ApplicationManager.ExitApplication();
    }
}