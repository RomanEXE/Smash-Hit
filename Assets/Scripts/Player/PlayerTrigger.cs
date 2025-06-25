using DefaultNamespace;
using UnityEngine;

namespace Player
{
    public class PlayerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(Tags.INTERACTABLE) || other.transform.CompareTag(Tags.OBSTACLE))
            {
                Actions.PlayerDead?.Invoke();
            }
        }
    }
}