using System;
using UnityEngine;

namespace Movement.Source.Modules.Movement.Scripts
{
    public class MovementInput: MonoBehaviour
    {
        [SerializeField] private CharacterMovement _characterMovement;
        private const string _horizontal = "Horizontal";
        private const string _vertical = "Vertical";
        private bool _active;

        private void FixedUpdate()
        {
            if (_active == false)
                return;

            Vector2 direction = new Vector2(Input.GetAxisRaw(_horizontal), Input.GetAxisRaw(_vertical));
            _characterMovement.Move(direction);
        }

        public void Activate()
        {
            _active = true;
        }

        public void Deactivate()
        {
            _active = false;
        }
    }
}