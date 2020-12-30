using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace Handlers
{
    public class HealthHandler : MonoBehaviour
    {
        [SerializeField] private float health;
        private Random _random;
        
        public float Health => health;

        public event Action OnHealthChanged;

        public GameObject lootGO;

        private void Awake()
        {
            _random = new Random();
        }

        public void OnDamage(float amount)
        {
            health -= amount;
            OnHealthChanged?.Invoke();
            if (health <= 0)
            {
                Destroy(gameObject); 
                if (gameObject.CompareTag("Enemy")) DropLoot();
            }
        }

        private void DropLoot()
        {
            var count = _random.Next(1, 10);
            var pos = transform.position;
            for (var i = 0; i < count; i++)
            {
                var offsetX = _random.Next(-20, 30) * 0.1f;
                var offsetY = _random.Next(10, 20) * 0.1f;
                var go = Instantiate(lootGO, new Vector3(pos.x + offsetX, pos.y + offsetY, pos.z), Quaternion.identity);
                go.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
            }
        }
    }
}