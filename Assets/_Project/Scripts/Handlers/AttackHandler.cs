using UnityEngine;

namespace Handlers
{
    public class AttackHandler : MonoBehaviour
    {
        [SerializeField] private GameObject attackColliderGO;

        public void OnAttackAnimationTrigger()
        {
            attackColliderGO.SetActive(true);
        }

        public void OnAttackAnimationEnd()
        {
            attackColliderGO.SetActive(false);
        }
    }
}