﻿using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Managers
{
    public enum GameScene
    {
        MainMenu,
        Level_1
    }
    
    [SuppressMessage("ReSharper", "MemberCanBeMadeStatic.Global")]
    public class ApplicationManager : SingletonMonoBehaviour<ApplicationManager>
    {
        public bool IsGamePaused
        {
            get => Time.timeScale == 0;
            private set => Time.timeScale = value ? 0 : 1;
        }

        public Scene ActiveScene => SceneManager.GetActiveScene();

        public void LoadScene(GameScene scene)
        {
            if (SceneManager.GetActiveScene().name != scene.ToString()) SceneManager.LoadScene(scene.ToString());
            IsGamePaused = false;
        }

        public void PauseGame() => IsGamePaused = true;

        public void ResumeGame() => IsGamePaused = false;

        public void ExitApplication()
        {
#if UNITY_EDITOR         
            UnityEditor.EditorApplication.isPlaying = false;                
#else 
            Application.Quit();
#endif
        }
    }
}