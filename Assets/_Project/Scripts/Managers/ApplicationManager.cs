using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Managers
{
    public class ApplicationManager : SingletonMonoBehaviour<ApplicationManager>
    {
        private static bool IsGamePaused
        {
            get => Time.timeScale == 0;
            set => Time.timeScale = value ? 0 : 1;
        }
        
        public static void LoadScene(string sceneName)
        {
            IsGamePaused = false;
            SceneManager.LoadScene(sceneName);
        }

        public static void ExitApplication()
        {
#if UNITY_EDITOR         
            UnityEditor.EditorApplication.isPlaying = false;                
#else 
            Application.Quit();
#endif
        }
    }
}