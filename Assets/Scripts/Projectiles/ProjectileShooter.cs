using Player;
using UnityEngine;

namespace Projectiles
{
    public class ProjectileShooter : MonoBehaviour
    {
        [SerializeField] private PlayerInput input;
        
        private void OnEnable()
        {
            input.FingerDown += Shoot;
        }

        private void OnDisable()
        {
            input.FingerDown -= Shoot;
        }

        private void Shoot(Vector2 screenPosition)
        {
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            Vector3 direction = ray.direction.normalized;
            ProjectilePool.Instance.Spawn(transform.position, direction);
        }
    }
}