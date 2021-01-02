using System.Collections;
using UnityEngine;

namespace StateMachines.Enemy
{
    public class AttackState : State<EnemyController>
    {
        private Rigidbody2D _rb;
        private Coroutine _coroutine;
        private static readonly int Attack = Animator.StringToHash("Attack");

        public AttackState(EnemyController controller) : base(controller)
        {
        }

        public override IEnumerator Start()
        {
            _rb = Controller.Rigidbody2D;
            yield return null;
        }

        public override IEnumerator Update()
        {
            var targetX = Controller.target.gameObject.transform.position.x;
            var posX = _rb.position.x;
            if (Mathf.Abs(targetX - posX) >= Controller.attackRange)
            {
                _coroutine = null;
                Controller.SetState(new MoveState(Controller));
                yield return null;
            }
            
            if (_coroutine == null) _coroutine = Controller.StartCoroutine(TimedAttack());
            yield return null;
        }

        private IEnumerator TimedAttack()
        {
            yield return new WaitForSeconds(0.5f);
            Controller.Animator.SetTrigger(Attack);
            _coroutine = null;
        }
    }
}