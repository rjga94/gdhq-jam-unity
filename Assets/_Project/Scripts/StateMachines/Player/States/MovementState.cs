using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachines.Player
{
    public class MovementState : State
    {
        private Rigidbody2D _rb;
        private float _movementSpeed;
        private InputAction _movementAction;

        public MovementState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override IEnumerator Start()
        {
            _rb = PlayerStateMachine.Rigidbody2D;
            _movementSpeed = PlayerStateMachine.movementSpeed;
            _movementAction = InputManager.Instance.Gameplay.Movement;
            yield return null;
        }

        public override IEnumerator FixedUpdate()
        {
            var movementAxis = _movementAction.ReadValue<Vector2>();
            var velocityX = _movementSpeed * movementAxis.x;
            _rb.velocity = new Vector2(velocityX, _rb.velocity.y);
            yield return null;
        }
    }
}