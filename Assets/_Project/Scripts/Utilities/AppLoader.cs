#if !UNITY_EDITOR
using Managers;   
#endif
using UnityEngine;

namespace Utilities
{
    public class AppLoader : MonoBehaviour
    {
        private void Awake()
        {
#if !UNITY_EDITOR
        ApplicationManager.Instance.LoadStartScene();      
#endif
        }
    }
}