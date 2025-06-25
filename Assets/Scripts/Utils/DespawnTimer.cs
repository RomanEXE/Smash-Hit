using System;
using Projectiles;
using UnityEngine;

namespace Utils
{
    public class DespawnTimer : IDisposable
    {
        private float _timeRemaining;
        private Projectile _projectile;

        public DespawnTimer(float time, Projectile projectile)
        {
            _timeRemaining = time;
            _projectile = projectile;
        }

        public void Update()
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                ProjectilePool.Instance.Despawn(_projectile);
                Dispose();
            }
        }

        public void Dispose()
        {
            _projectile = null;
            ProjectilePool.Instance.DespawnTimers.Remove(this);
        }
    }
}