using Interfaces;
using UnityEngine;

namespace Items
{
    public class Obstacle : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform body;
        [SerializeField] private Transform cells;
        
        public virtual void Interact()
        {
            body.gameObject.SetActive(false);
            cells.gameObject.SetActive(true);
        }
    }
}