using UnityEngine;

namespace Handlers
{
    public class HealthHandler : MonoBehaviour
    {
        [SerializeField] private float health;

        public void OnDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}