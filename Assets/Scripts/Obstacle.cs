using Interfaces;
using UnityEngine;

namespace DefaultNamespace
{
    public class Obstacle : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform body;
        [SerializeField] private Transform cells;
        
        public void Interact()
        {
            body.gameObject.SetActive(false);
            cells.gameObject.SetActive(true);
        }
    }
}