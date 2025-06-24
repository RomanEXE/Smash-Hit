using Interfaces;
using UnityEngine;

namespace Projectiles
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float force;
        [SerializeField] private Rigidbody rigidbody;
        private ProjectilePool _pool;

        public void Init(ProjectilePool pool)
        {
            _pool = pool;
        }
        
        public void Spawn(Vector3 direction)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(direction * force);
        }

        private void Despawn()
        {
            rigidbody.isKinematic = true;
            _pool.Despawn(this);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag(Tags.INTERACTABLE))
            {
                other.transform.GetComponent<IInteractable>().Interact();
            }
            
            Despawn();
        }
    }
}