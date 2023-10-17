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

            Vector2 velocity = (new Vector2(Input.GetAxis(_horizontal), Input.GetAxis(_vertical))) * Time.fixedDeltaTime;
            _characterMovement.Move(velocity);
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