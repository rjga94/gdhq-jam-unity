using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Handlers
{
    [RequireComponent(typeof(Animator))]
    public class ProjectileHandler : MonoBehaviour
    {
        [SerializeField] private float attackPower;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float timeAlive;

        private Animator _animator;
        
        private Vector3 _target;
        private Vector3 _dir;
        private static readonly int Explosion = Animator.StringToHash("Explosion");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            
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

        private bool _isExploding = false;
        
        private void Update()
        {
            if (_isExploding) transform.position += new Vector3(_dir.x, _dir.y, 0) * (projectileSpeed * 0.1f * Time.deltaTime);
            else transform.position += new Vector3(_dir.x, _dir.y, 0) * (projectileSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var healthHandler = other.GetComponent<HealthHandler>();
            if (!healthHandler) return;
            
            healthHandler.OnDamage(attackPower);
            _animator.SetTrigger(Explosion);
            _isExploding = true;
        }

        private IEnumerator DestroySelfAfterTime()
        {
            yield return new WaitForSeconds(timeAlive);
            Destroy(gameObject);
        }

        public void OnExplosionAnimationEnd() => Destroy(gameObject);
    }
}