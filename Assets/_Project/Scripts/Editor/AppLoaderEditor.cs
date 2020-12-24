using JetBrains.Annotations;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Editor
{
    [InitializeOnLoad]
    public static class AppLoaderEditor
    {
        [CanBeNull] private static string _afterLoadSceneName;

        static AppLoaderEditor() => SceneManager.sceneLoaded += OnSceneLoaded;

        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (_afterLoadSceneName == null)
            {
                _afterLoadSceneName = scene.name;
                SceneManager.LoadScene(0);
                return;
            }
            
            SceneManager.LoadScene(_afterLoadSceneName);
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}