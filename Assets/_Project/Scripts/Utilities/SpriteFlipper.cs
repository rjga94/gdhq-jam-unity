using UnityEngine;

namespace Utilities
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteFlipper : MonoBehaviour
    {
        private const float threshold = 0.1f;
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;

        private bool _wasFlippedAtStart;
        
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _wasFlippedAtStart = _spriteRenderer.flipX;
        }

        private void Update()
        {
            if (_rigidbody2D == null) return;

            var velocityX = _rigidbody2D.velocity.x;
            if (velocityX < -threshold)
            {
                if (_wasFlippedAtStart) _spriteRenderer.flipX = false;
                else _spriteRenderer.flipX = true;
            }
            else if (velocityX > threshold)
            {
                if (_wasFlippedAtStart) _spriteRenderer.flipX = true;
                else _spriteRenderer.flipX = false;
            }
        }
    }
}