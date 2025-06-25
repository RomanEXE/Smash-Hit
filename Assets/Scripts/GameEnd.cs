using Player;
using Projectiles;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameEnd : MonoBehaviour
    {
        [SerializeField] private PlayerMovement movement;
        [SerializeField] private ProjectileShooter shooter;
        
        private void OnEnable()
        {
            Actions.PlayerDead += OnPlayerDead;
            Actions.FinishTriggered += OnPlayerDead;
        }
        
        private void OnDisable()
        {
            Actions.PlayerDead -= OnPlayerDead;
            Actions.FinishTriggered -= OnPlayerDead;
        }

        private void OnPlayerDead()
        {
            movement.enabled = false;
            shooter.enabled = false;
        }
    }
}