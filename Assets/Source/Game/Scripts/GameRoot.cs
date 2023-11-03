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
            var player =  Instantiate(playerPrefab, _playerInitialPoint.position, playerPrefab.transform.rotation);
            
            var playerMovementInputPrefab = Resources.Load<GameObject>("Prefabs/Services/PlayerMovementInput");
            var playerMovementInputObject = Instantiate(playerMovementInputPrefab, GetComponentInParent<Transform>());
            PlayerMovementInput playerMovementInput = playerMovementInputObject.GetComponent<PlayerMovementInput>();
            playerMovementInput.Construct(player.GetComponent<MovementRoot>());
            playerMovementInput.Activate();
        }
    }
}
