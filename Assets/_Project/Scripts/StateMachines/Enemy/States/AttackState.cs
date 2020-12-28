using System.Collections;
using UnityEngine;

namespace StateMachines.Enemy
{
    public class AttackState : State<EnemyController>
    {
        private Coroutine _coroutine;
        
        public AttackState(EnemyController controller) : base(controller)
        {
        }

        public override IEnumerator Update()
        {
            if (_coroutine == null) _coroutine = Controller.StartCoroutine(TimedAttack());
            yield return null;
        }

        private IEnumerator TimedAttack()
        {
            yield return new WaitForSeconds(0.5f);
            Controller.attackColliderGO.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            Controller.attackColliderGO.SetActive(false);
            _coroutine = null;
        }
    }
}