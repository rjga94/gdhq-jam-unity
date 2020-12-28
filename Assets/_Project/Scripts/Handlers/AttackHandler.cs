using UnityEngine;

namespace Handlers
{
    public class AttackHandler : MonoBehaviour
    {
        [SerializeField] private float attackPower;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var healthHandler = other.GetComponent<HealthHandler>();
            if (!healthHandler) return;
            
            healthHandler.OnDamage(attackPower);
            gameObject.SetActive(false);
        }
    }
}