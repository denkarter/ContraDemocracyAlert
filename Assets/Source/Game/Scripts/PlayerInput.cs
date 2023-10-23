using System;
using Movement.Source.Modules.Movement.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ContraDA.Source.Game.Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        private MovementRoot _movement;
        private PlayerInputActions _inputActions;
        private bool _active;

        public event Action OnJump;
        public event Action OnMove;

        private void Start()
        {
            _movement = GetComponent<MovementRoot>();
        }

        private void FixedUpdate()
        {
            if (_active == false)
                return;
            Vector2 direction = _inputActions.HumanoidLand.Move.ReadValue<Vector2>();
            _movement.Move(direction * Time.fixedDeltaTime);
        }

        public void Activate()
        {
            _active = true;
        }

        public void Deactivate()
        {
            _active = false;
        }
        
        private void OnEnable()
        {
            _inputActions = new PlayerInputActions();
            _inputActions.HumanoidLand.Move.Enable();

            _inputActions.HumanoidLand.Move.performed += SetMove;
            _inputActions.HumanoidLand.Jump.performed += Jump;
        }

        private void OnDisable()
        {
            _inputActions.HumanoidLand.Move.performed -= SetMove;
            _inputActions.HumanoidLand.Jump.performed -= Jump;
            _inputActions.HumanoidLand.Move.Enable();
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            OnJump?.Invoke();
        }

        private void SetMove(InputAction.CallbackContext obj)
        {
            OnMove?.Invoke();
        }
    }
}
