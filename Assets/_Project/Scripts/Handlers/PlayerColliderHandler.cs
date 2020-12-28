using StateMachines.Enemy;
using UnityEngine;

namespace Handlers
{
    public class PlayerColliderHandler : MonoBehaviour
    {
        [SerializeField] private EnemyController enemyController;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            enemyController.target = other;
            enemyController.SetState(new MoveState(enemyController));
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            enemyController.SetState(new IdleState(enemyController));
            enemyController.target = null;
        }
    }
}