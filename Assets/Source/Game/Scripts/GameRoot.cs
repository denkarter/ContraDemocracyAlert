using System;
using Movement.Source.Modules.Movement.Scripts;
using UnityEngine;

namespace ContraDA.Source.Game.Scripts
{
    public class GameRoot : MonoBehaviour
    {
        [SerializeField] private MovementInput _movementInput;

        private void Start()
        {
            _movementInput.Activate();
        }
    }
}
