using UnityEngine;

namespace StateMachines.Enemy
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Animator))]
    public class EnemyController : StateMachine<EnemyController>
    {
        [SerializeField] public float movementSpeed;
        [SerializeField] public float attackRange;
        [SerializeField] public GameObject attackColliderGO;

        [HideInInspector] public Rigidbody2D Rigidbody2D;
        [HideInInspector] public Animator Animator;
        [HideInInspector] public Collider2D target;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
        }

        private void Start() => SetState(new IdleState(this));

        private void Update() => StartCoroutine(State.Update());

        private void FixedUpdate() => StartCoroutine(State.FixedUpdate());
    }
}