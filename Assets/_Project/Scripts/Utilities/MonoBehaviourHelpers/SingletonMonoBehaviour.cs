using System;
using UnityEngine;

namespace Utilities
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        private static readonly Lazy<T> LazyInstance = new Lazy<T>(CreateSingleton);
        
        public static T Instance => LazyInstance.Value;
        
        private static T CreateSingleton()
        {
            var gameObject = new GameObject($"{typeof(T).Name} (singleton)");
            var instance = gameObject.AddComponent<T>();
            instance.OnCreateInstance();
            DontDestroyOnLoad(gameObject);
            return instance;
        }

        protected virtual void OnCreateInstance() {}
    }
}