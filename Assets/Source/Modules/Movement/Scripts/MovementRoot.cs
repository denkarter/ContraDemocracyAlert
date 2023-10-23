using UnityEngine;

namespace Movement.Source.Modules.Movement.Scripts
{
    public class MovementRoot: MonoBehaviour
    {
        [SerializeField] private CharacterMovement _characterMovement;

        public void Move(Vector2 movementDirection)
        {
            Debug.Log(movementDirection);
            _characterMovement.Move((movementDirection));
        }
    }
}