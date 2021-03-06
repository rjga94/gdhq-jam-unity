﻿using UnityEngine;

namespace Managers
{
    public class MainMenuManager : MonoBehaviour
    {
        public void OnStartGameButtonClick() => ApplicationManager.Instance.LoadScene(GameScene.ProceduralLevel);

        public void OnQuitGameButtonClick() => ApplicationManager.Instance.ExitApplication();
    }
}