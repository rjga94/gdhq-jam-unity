using System;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachines.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerStateMachine : StateMachine
    {
        [SerializeField] public float movementSpeed;
        [SerializeField] public float jumpForce;
        
        [HideInInspector] public Rigidbody2D Rigidbody2D;

        private void Awake() => Rigidbody2D = GetComponent<Rigidbody2D>();

        private void Start()
        {
            SetState(new MovementState(this));
            InputManager.Instance.Gameplay.Jump.performed += OnJumpInput;
        }

        private void OnDestroy() => InputManager.Instance.Gameplay.Jump.performed -= OnJumpInput;

        private void Update() => StartCoroutine(State.Update());

        private void FixedUpdate() => StartCoroutine(State.FixedUpdate());

        private void OnJumpInput(InputAction.CallbackContext context) => SetState(new JumpState(this));
    }
}