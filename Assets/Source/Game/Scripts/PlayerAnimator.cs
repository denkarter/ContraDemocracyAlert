using System;
using UnityEngine;

namespace ContraDA.Source.Game.Scripts
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;

        //private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Move()
        {
            _animator.SetBool(IsMoving, true);
        }

        public void StopMoving()
        {
            _animator.SetBool(IsMoving, false);
        }
    }
}
