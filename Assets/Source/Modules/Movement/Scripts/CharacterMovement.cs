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
            var rotation = Quaternion.LookRotation(direction);
            _rigidbody.MoveRotation(rotation);
             
            var tempVector = new Vector3(direction.x, direction.y, 0);
            _rigidbody.MovePosition(_rigidbody.position + tempVector * _speed);
        }
    }
}