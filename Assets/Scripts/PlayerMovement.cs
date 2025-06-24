using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
    }
}