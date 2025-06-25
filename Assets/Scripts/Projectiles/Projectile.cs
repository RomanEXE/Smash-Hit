using Interfaces;
using UnityEngine;
using Utils;

namespace Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private Rigidbody rigidbody;
        private ProjectilePool _pool;
        private bool _isFirstCollision = true;
        
        public void Spawn(Vector3 direction)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(direction * force);
            _isFirstCollision = true;
        }

        public void Despawn()
        {
            rigidbody.isKinematic = true;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag(Tags.INTERACTABLE))
            {
                other.transform.GetComponent<IInteractable>().Interact();
            }

            if (_isFirstCollision)
            {
                ProjectilePool.Instance.Despawn(this, 5f);
                _isFirstCollision = false;
            }
        }
    }
}