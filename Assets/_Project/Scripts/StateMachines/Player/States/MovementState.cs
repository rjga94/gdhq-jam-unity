using System.Collections;
using UnityEngine;

namespace StateMachines.Player
{
    public class MovementState : State<PlayerController>
    {
        private Rigidbody2D _rb;
        private float _movementSpeed;

        public MovementState(PlayerController controller) : base(controller)
        {
        }

        public override IEnumerator Start()
        {
            _rb = Controller.Rigidbody2D;
            _movementSpeed = Controller.movementSpeed;
            yield return null;
        }

        public override IEnumerator FixedUpdate()
        {
            var movementAxis = Controller.MovementAxis;
            var velocityX = _movementSpeed * movementAxis.x;
            _rb.velocity = new Vector2(velocityX, _rb.velocity.y);
            yield return null;
        }
    }
}