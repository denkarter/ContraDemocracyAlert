using System;
using Movement.Source.Modules.Movement.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ContraDA.Source.Game.Scripts
{
    public class PlayerMovementInput : MonoBehaviour
    {
        private MovementRoot _movementRoot;
        private PlayerInputActions _inputActions;
        private PlayerAnimator _animator;
        private bool _active;
        private Vector2 _direction;

        public event Action OnJump;
        public event Action OnShoot;

        private void Start()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            _movementRoot = player.GetComponent<MovementRoot>();
            _animator = player.GetComponent<PlayerAnimator>();
        }

        public void Construct(MovementRoot movementRoot)
        {
            _movementRoot = movementRoot;
        }

        private void Update()
        {
            if (_active == false)
                return;
            _direction = _inputActions.HumanoidLand.Move.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            if (_direction.sqrMagnitude > Constants.Epsilon)
            {
                _movementRoot.Move(_direction.normalized * Time.deltaTime);
                _animator.Move();
            }

            if (_direction.sqrMagnitude == 0)
            {
                _animator.StopMoving();
            }
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

            _inputActions.HumanoidLand.Move.performed += Shoot;
            _inputActions.HumanoidLand.Jump.performed += Jump;
        }

        private void OnDisable()
        {
            _inputActions.HumanoidLand.Move.performed -= Shoot;
            _inputActions.HumanoidLand.Jump.performed -= Jump;
            _inputActions.HumanoidLand.Move.Disable();
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            OnJump?.Invoke();
        }

        private void Shoot(InputAction.CallbackContext obj)
        {
            OnShoot?.Invoke();
        }
    }
}
