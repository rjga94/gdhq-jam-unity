﻿using System.Collections;
using UnityEngine;

namespace StateMachines.Enemy
{
    public class IdleState : State<EnemyController>
    {
        private Rigidbody2D _rb;
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");

        public IdleState(EnemyController controller) : base(controller)
        {
        }

        public override IEnumerator Start()
        {
            _rb = Controller.Rigidbody2D;
            _rb.velocity = Vector2.zero;
            Controller.Animator.SetBool(IsWalking, false);
            yield return null;
        }
    }
}