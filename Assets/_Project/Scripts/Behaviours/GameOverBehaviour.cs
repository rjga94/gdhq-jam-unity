using Managers;
using UnityEngine;

namespace Behaviours
{
    public class GameOverBehaviour : MonoBehaviour
    {
        private GameOverMenuManager _gameOverMenu;
        
        private void Awake() => _gameOverMenu = FindObjectOfType<GameOverMenuManager>();

        private void OnTriggerEnter2D(Collider2D other) => _gameOverMenu.Show();
    }
}