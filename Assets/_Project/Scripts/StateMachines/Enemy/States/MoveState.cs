using System.Collections;
using UnityEngine;

namespace StateMachines.Enemy
{
    public class MoveState : State<EnemyController>
    {
        private Rigidbody2D _rb;
        
        public MoveState(EnemyController controller) : base(controller)
        {
        }

        public override IEnumerator Start()
        {
            _rb = Controller.Rigidbody2D;
            yield return null;
        }

        public override IEnumerator FixedUpdate()
        {
            var posX = _rb.position.x;
            var targetX = Controller.target.gameObject.transform.position.x;

            if (targetX - posX >= Controller.attackRange) _rb.velocity = new Vector2(Controller.movementSpeed, _rb.velocity.y);
            else if (targetX - posX <= -Controller.attackRange) _rb.velocity = new Vector2(-Controller.movementSpeed, _rb.velocity.y);
            else
            {
                _rb.velocity = new Vector2(0, _rb.velocity.y);
                Controller.SetState(new AttackState(Controller));
            }
            
            yield return null;
        }
    }
}