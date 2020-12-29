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

        private Vector3 _dir;
        
        private void Awake()
        {
            var point = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            _target = new Vector3(point.x, point.y, 0);

            _dir = (_target - transform.position).normalized;
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(_dir));
            
            StartCoroutine(DestroySelfAfterTime());
        }

        private float GetAngleFromVectorFloat(Vector3 dir)
        {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;
            return n;
        }

        private void Update()
        {
            transform.position += new Vector3(_dir.x, _dir.y, 0) * (projectileSpeed * Time.deltaTime);
        }

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