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
                if (SceneManager.GetActiveScene().buildIndex != 0) SceneManager.LoadScene(0);
                return;
            }

            if (SceneManager.GetActiveScene().name != _afterLoadSceneName) SceneManager.LoadScene(_afterLoadSceneName);
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}