using System.Collections;
using UnityEngine;

namespace StateMachines.Player
{
    public class JumpState : State
    {
        private Rigidbody2D _rb;
        
        public JumpState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {
        }

        public override IEnumerator Start()
        {
            _rb = PlayerStateMachine.Rigidbody2D;
            yield return null;
        }

        public override IEnumerator Update()
        {
            _rb.velocity = new Vector2(_rb.velocity.x, 5);
            PlayerStateMachine.SetState(new MovementState(PlayerStateMachine));
            yield return null;
        }
    }
}