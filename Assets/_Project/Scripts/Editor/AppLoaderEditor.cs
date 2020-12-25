using JetBrains.Annotations;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Editor
{
    [InitializeOnLoad]
    public static class AppLoaderEditor
    {
        [CanBeNull] private static int _startSceneBuildIndex;

        static AppLoaderEditor() => EditorApplication.playModeStateChanged += OnPlayerModeStateChanged;

        private static void OnPlayerModeStateChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredPlayMode)
            {
                _startSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
                if (_startSceneBuildIndex != 0)
                {
                    SceneManager.sceneLoaded += OnSceneLoaded;
                    SceneManager.LoadScene(0);
                }
            }
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            SceneManager.LoadScene(_startSceneBuildIndex);
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}