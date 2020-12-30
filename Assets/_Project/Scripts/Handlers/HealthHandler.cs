using System;
using System.Collections;
using UnityEngine;
using Random = System.Random;

namespace Handlers
{
    public class HealthHandler : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private float health;
        private Random _random;
        
        public float Health => health;

        public event Action OnHealthChanged;

        public GameObject lootGO;
        
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int Death = Animator.StringToHash("Death");

        private void Awake()
        {
            _random = new Random();
        }

        private bool _isDying;

        public void OnDamage(float amount)
        {
            if (_isDying) return;
            
            health -= amount;
            OnHealthChanged?.Invoke();
            if (health <= 0)
            {
                _isDying = true;
                animator.SetTrigger(Death);
                StartCoroutine(DestroySelfAfterTime());
                if (gameObject.CompareTag("Enemy")) DropLoot();
                return;
            }
            
            animator.SetTrigger(Hit);
        }

        private IEnumerator DestroySelfAfterTime()
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
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