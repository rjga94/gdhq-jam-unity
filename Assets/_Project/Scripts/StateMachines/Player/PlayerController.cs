using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachines.Player
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D)), RequireComponent(typeof(Animator))]
    public class PlayerController : StateMachine<PlayerController>
    {
        private static readonly int IsMovingAnimHash = Animator.StringToHash("IsMoving");
        
        private Collider2D _collider2D;
        private LayerMask _groundLayer;

        [SerializeField] public float movementSpeed;
        [SerializeField] public float jumpForce;
        [SerializeField] public float fireRate;
        [SerializeField] public GameObject attackColliderGO;
        [SerializeField] public GameObject projectilePrefab;
        [SerializeField] public GameObject projectileSpawnPosition;

        [HideInInspector] public Rigidbody2D Rigidbody2D;
        [HideInInspector] public Vector2 MovementAxis;
        [HideInInspector] public Animator Animator;
        
        [HideInInspector] public float lastRangedAttackTime;
        public int collectedShards;

        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
            _collider2D = GetComponent<Collider2D>();
            _groundLayer = LayerMask.GetMask("Ground");
        }

        private void Start()
        {
            var gameplayActions = InputManager.Instance.Gameplay;
            gameplayActions.Jump.performed += OnJumpInput;
            gameplayActions.Movement.performed += OnMovementInput;
            gameplayActions.Attack.performed += OnAttackInput;
            SetState(new MovementState(this));
        }

        private void OnDestroy()
        {
            FindObjectOfType<GameOverMenuManager>()?.Show();
            var gameplayActions = InputManager.Instance.Gameplay;
            gameplayActions.Jump.performed -= OnJumpInput;
            gameplayActions.Movement.performed -= OnMovementInput;
            gameplayActions.Attack.performed -= OnAttackInput;
        }

        private void Update()
        {
            StartCoroutine(State.Update());
            Animator.SetBool(IsMovingAnimHash, MovementAxis.x < -0.05f || MovementAxis.x > 0.05f);
        }

        private void FixedUpdate() => StartCoroutine(State.FixedUpdate());

        private void OnJumpInput(InputAction.CallbackContext context) {
            if (IsGrounded()) SetState(new JumpState(this));
        }

        private void OnMovementInput(InputAction.CallbackContext context) =>
            MovementAxis = context.ReadValue<Vector2>();

        private void OnAttackInput(InputAction.CallbackContext context)
        {
            SetState(new RangedAttackState(this));
        }

        private bool IsGrounded()
        {
            var bounds = _collider2D.bounds;
            var boundsMin = bounds.min;
            var boundsMax = bounds.max;
            const float distance = 0.25f;

            var leftOrigin = new Vector2(boundsMin.x, boundsMin.y);
            var rightOrigin = new Vector2(boundsMax.x, boundsMin.y);
            
            var leftHit = Physics2D.Raycast(leftOrigin, Vector2.down, distance, _groundLayer);
            var rightHit = Physics2D.Raycast(rightOrigin, Vector2.down, distance, _groundLayer);

            return leftHit.collider != null || rightHit.collider != null;
        }
    }
}