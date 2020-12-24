using UnityEngine;

namespace Utilities
{
    public class ConvertToPersistentObject : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Destroy(GetComponent<ConvertToPersistentObject>());
        }
    }
}