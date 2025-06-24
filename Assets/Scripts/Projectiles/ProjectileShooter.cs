using Player;
using UnityEngine;

namespace Projectiles
{
    public class ProjectileShooter : MonoBehaviour
    {
        [SerializeField] private PlayerInput input;
        [SerializeField] private ProjectilesClip clip;
        
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
            if (!clip.TryRemove(1))
                return;
            
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            Vector3 direction = ray.direction.normalized;
            ProjectilePool.Instance.Spawn(transform.position, direction);
        }
    }
}