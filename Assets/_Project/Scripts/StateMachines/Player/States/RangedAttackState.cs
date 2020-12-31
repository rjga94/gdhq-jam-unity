using System.Collections;
using UnityEngine;

namespace StateMachines.Player
{
    public class RangedAttackState: State<PlayerController>
    {
        private GameObject _projectileGO;
        
        public RangedAttackState(PlayerController controller) : base(controller)
        {
        }

        public override IEnumerator Start()
        {
            if (Time.time - Controller.lastRangedAttackTime >= Controller.fireRate)
            {
                Object.Instantiate(Controller.projectilePrefab, Controller.projectileSpawnPosition.transform.position, Quaternion.identity);
                Controller.lastRangedAttackTime = Time.time;
            }
            Controller.SetState(new MovementState(Controller));
            yield return null;
        }
    }
}