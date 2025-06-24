using Interfaces;
using UnityEngine;

namespace Items
{
    public class DoorTrigger : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject door;
        
        public void Interact()
        {
            Destroy(door);
        }
    }
}