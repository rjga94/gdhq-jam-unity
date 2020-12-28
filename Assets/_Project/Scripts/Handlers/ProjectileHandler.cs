using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Handlers
{
    public class ProjectileHandler : MonoBehaviour
    {
        [SerializeField] private float attackPower;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float timeAlive;
        
        private Vector3 _target;
        private Vector3 movementVector;
        
        private void Awake()
        {
            _target = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            movementVector = (_target - transform.position).normalized * projectileSpeed;
            transform.right = _target - transform.position;

            StartCoroutine(DestroySelfAfterTime());
        }

        private void Update() => transform.position += new Vector3(movementVector.x * Time.deltaTime, movementVector.y * Time.deltaTime);

        private void OnTriggerEnter2D(Collider2D other)
        {
            var healthHandler = other.GetComponent<HealthHandler>();
            if (!healthHandler) return;
            
            healthHandler.OnDamage(attackPower);
            Destroy(gameObject);
        }

        private IEnumerator DestroySelfAfterTime()
        {
            yield return new WaitForSeconds(timeAlive);
            Destroy(gameObject);
        }
    }
}