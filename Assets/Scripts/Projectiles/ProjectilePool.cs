using System.Collections.Generic;
using UnityEngine;

namespace Projectiles
{
    public class ProjectilePool : MonoBehaviour
    {
        public static ProjectilePool Instance { get; set; }
        
        private Queue<Projectile> _pool = new Queue<Projectile>();
        [SerializeField] private Projectile prefab;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void Spawn(Vector3 spawnPosition, Vector3 direction)
        {
            if (_pool.Count == 0)
            {
                Create();
            }

            Projectile spawnedProjectile = _pool.Dequeue();
            spawnedProjectile.transform.position = spawnPosition;
            spawnedProjectile.gameObject.SetActive(true);
            spawnedProjectile.Spawn(direction);
        }

        private void Create()
        {
            Projectile spawnedPrefab = Instantiate(prefab);
            spawnedPrefab.gameObject.SetActive(false);
            spawnedPrefab.Init(this);
            _pool.Enqueue(spawnedPrefab);
        }

        public void Despawn(Projectile projectile)
        {
            _pool.Enqueue(projectile);
            projectile.gameObject.SetActive(false);
        }
    }
}