using System;
using UnityEngine;

namespace Handlers
{
    public class HealthHandler : MonoBehaviour
    {
        [SerializeField] private float health;

        public float Health => health;

        public event Action OnHealthChanged;

        public GameObject lootGO;

        public void OnDamage(float amount)
        {
            health -= amount;
            OnHealthChanged?.Invoke();
            if (health <= 0)
            {
                Destroy(gameObject); 
                if (this.gameObject.tag == "Enemy")
                {

                    Instantiate(lootGO, transform.position, Quaternion.identity);
                }
                     
            }
        }
    }
}