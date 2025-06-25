using DefaultNamespace;
using UnityEngine;
using Utils;

namespace Items
{
    public class BonusObstacle : Obstacle
    {
        [SerializeField] private int additionalProjectilesAmount;
        
        public override void Interact()
        {
            base.Interact();
            
            Actions.BonusObstacleDestroyed?.Invoke(additionalProjectilesAmount);
        }
    }
}