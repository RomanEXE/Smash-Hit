using DefaultNamespace;
using UnityEngine;

namespace Player
{
    public class PlayerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag("Interactable"))
            {
                Actions.PlayerDead?.Invoke();
                print("Dead");
            }
        }
    }
}