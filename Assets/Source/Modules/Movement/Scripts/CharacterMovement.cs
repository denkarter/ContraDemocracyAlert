using System;
using UnityEngine;

namespace Movement.Source.Modules.Movement.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    internal class CharacterMovement: MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        internal void Move(Vector2 direction)
        {
            _rigidbody.velocity = direction * _speed;
        }
    }
}