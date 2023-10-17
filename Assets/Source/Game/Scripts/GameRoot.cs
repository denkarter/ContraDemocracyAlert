using System;
using Movement.Source.Modules.Movement.Scripts;
using UnityEngine;

namespace ContraDA.Source.Game.Scripts
{
    public class GameRoot : MonoBehaviour
    {
        [SerializeField] private Transform _playerInitialPoint;

        private void Start()
        {
            var playerPrefab = Resources.Load<GameObject>("Prefabs/Player/Player");
            var player =  Instantiate(playerPrefab, _playerInitialPoint.position, Quaternion.identity);
            var movementInput = player.GetComponent<MovementInput>();
            movementInput.Activate();
        }
    }
}
