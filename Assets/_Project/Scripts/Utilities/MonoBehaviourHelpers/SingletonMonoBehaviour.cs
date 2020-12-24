using System;
using UnityEngine;

namespace Utilities
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static readonly Lazy<T> LazyInstance = new Lazy<T>(CreateSingleton);
        
        public static T Instance => LazyInstance.Value;
        
        private static T CreateSingleton()
        {
            var gameObject = new GameObject($"{typeof(T).Name} (singleton)");
            return gameObject.AddComponent<T>();
        }
    }
}