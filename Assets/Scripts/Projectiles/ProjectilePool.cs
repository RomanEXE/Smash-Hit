using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Projectiles
{
    public class ProjectilePool : MonoBehaviour
    {
        public static ProjectilePool Instance { get; set; }
        public readonly List<DespawnTimer> DespawnTimers = new List<DespawnTimer>();
        
        [SerializeField] private Projectile prefab;

        private Queue<Projectile> _pool = new Queue<Projectile>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        private void Update()
        {
            if (DespawnTimers.Count > 0)
            {
                for (int i = 0; i < DespawnTimers.Count; i++)
                {
                    DespawnTimers[i].Update();
                }
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
            _pool.Enqueue(spawnedPrefab);
        }

        public void Despawn(Projectile projectile)
        {
            _pool.Enqueue(projectile);
            projectile.gameObject.SetActive(false);
            projectile.Despawn();
        }

        public void Despawn(Projectile projectile, float time)
        {
            DespawnTimers.Add(new DespawnTimer(time, projectile));
        }
    }
}