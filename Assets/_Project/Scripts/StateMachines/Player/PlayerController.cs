using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachines.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : StateMachine<PlayerController>
    {
        [SerializeField] public float movementSpeed;
        [SerializeField] public float jumpForce;
        
        [HideInInspector] public Rigidbody2D Rigidbody2D;
        [HideInInspector] public Vector2 MovementAxis;
        public LayerMask groundLayer;

        private void Awake() => Rigidbody2D = GetComponent<Rigidbody2D>();

        private void Start()
        {
            var gameplayActions = InputManager.Instance.Gameplay;
            gameplayActions.Jump.performed += OnJumpInput;
            gameplayActions.Movement.performed += OnMovementInput;
            SetState(new MovementState(this));
        }

        private void OnDestroy()
        {
            var gameplayActions = InputManager.Instance.Gameplay;
            gameplayActions.Jump.performed -= OnJumpInput;
            gameplayActions.Movement.performed -= OnMovementInput;
        }

        private void Update() => StartCoroutine(State.Update());

        private void FixedUpdate() => StartCoroutine(State.FixedUpdate());

        private void OnJumpInput(InputAction.CallbackContext context) {
            if (IsGrounded() == true)
            {
                SetState(new JumpState(this));
            }
        }

        private void OnMovementInput(InputAction.CallbackContext context) =>
            MovementAxis = context.ReadValue<Vector2>();

        private bool IsGrounded()
        {
            Vector2 position = transform.position;
            Vector2 direction = Vector2.down;
            float distance = 2.0f;

            RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
            if (hit.collider != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}