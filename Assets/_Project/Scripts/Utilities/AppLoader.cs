#if !UNITY_EDITOR
using Managers;
#endif
using UnityEngine;

namespace Utilities
{
    public class AppLoader : MonoBehaviour
    {
        [SerializeField] private string startScene;
        
#if !UNITY_EDITOR
        private void Awake()
        {
            GameManager.LoadScene(startScene);
        }      
#endif
    }
}