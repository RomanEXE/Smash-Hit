using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class ProjectilePool : MonoBehaviour
    {
        [SerializeField] private Queue<Projectile> pool = new Queue<Projectile>();
        [SerializeField] private Projectile prefab;
        
        public void Spawn(Vector3 spawnPosition)
        {
            if (pool.Count == 0)
            {
                Create();
            }

            Projectile spawnedProjectile = pool.Dequeue();
            spawnedProjectile.transform.position = spawnPosition;
            spawnedProjectile.gameObject.SetActive(true);
            spawnedProjectile.Spawn();
        }

        private void Create()
        {
            Projectile spawnedPrefab = Instantiate(prefab);
            spawnedPrefab.gameObject.SetActive(false);
            spawnedPrefab.Init(this);
            pool.Enqueue(spawnedPrefab);
        }

        public void Despawn(Projectile projectile)
        {
            pool.Enqueue(projectile);
            projectile.gameObject.SetActive(false);
        }
    }
}