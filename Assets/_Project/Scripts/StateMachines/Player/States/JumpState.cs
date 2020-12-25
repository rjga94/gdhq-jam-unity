using System.Collections;
using UnityEngine;

namespace StateMachines.Player
{
    public class JumpState : State<PlayerController>
    {
        private Rigidbody2D _rb;
        
        public JumpState(PlayerController controller) : base(controller)
        {
        }

        public override IEnumerator Start()
        {
            _rb = Controller.Rigidbody2D;
            yield return null;
        }

        public override IEnumerator Update()
        {
            _rb.velocity = new Vector2(_rb.velocity.x, Controller.jumpForce);
            Controller.SetState(new MovementState(Controller));
            yield return null;
        }
    }
}