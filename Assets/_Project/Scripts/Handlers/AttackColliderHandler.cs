using StateMachines.Enemy;
using UnityEngine;

namespace Handlers
{
    public class AttackColliderHandler : MonoBehaviour
    {
        [SerializeField] private EnemyController enemyController;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var healthHandler = other.GetComponent<HealthHandler>();
            if (!healthHandler) return;
            
            healthHandler.OnDamage(enemyController.attackPower);
        }
    }
}