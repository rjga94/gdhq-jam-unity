#if !UNITY_EDITOR
using Managers;
#endif
using Managers;
using UnityEngine;

namespace Utilities
{
    public class AppLoader : MonoBehaviour
    {
        [SerializeField] private GameScene startScene;

#if !UNITY_EDITOR
        private void Awake()
        {
            ApplicationManager.Instance.LoadScene(startScene);
        } 
#endif
    }
}