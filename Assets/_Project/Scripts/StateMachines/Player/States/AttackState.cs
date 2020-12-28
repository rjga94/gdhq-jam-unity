using System.Collections;
using UnityEngine;

namespace StateMachines.Player
{
    public class AttackState: State<PlayerController>
    {
        public AttackState(PlayerController controller) : base(controller)
        {
        }

        public override IEnumerator Start()
        {
            Controller.attackColliderGO.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            Controller.attackColliderGO.SetActive(false);
            Controller.SetState(new MovementState(Controller));
        }
    }
}