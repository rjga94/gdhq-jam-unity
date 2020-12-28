using UnityEngine;

namespace Utilities
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(SpriteRenderer))]
    public class SpriteFlipper : MonoBehaviour
    {
        private const float threshold = 0.1f;
        
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;

        private bool _wasFlippedAtStart;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _wasFlippedAtStart = _spriteRenderer.flipX;
        }

        private void Update()
        {
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