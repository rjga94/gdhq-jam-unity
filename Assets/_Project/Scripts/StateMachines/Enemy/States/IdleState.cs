using System.Collections;
using UnityEngine;

namespace StateMachines.Enemy
{
    public class IdleState : State<EnemyController>
    {
        private Rigidbody2D _rb;
        
        public IdleState(EnemyController controller) : base(controller)
        {
        }

        public override IEnumerator Start()
        {
            _rb = Controller.Rigidbody2D;
            _rb.velocity = Vector2.zero;
            yield return null;
        }
    }
}