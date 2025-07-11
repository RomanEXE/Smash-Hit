using DefaultNamespace;
using UnityEngine;
using Utils;

namespace Projectiles
{
    public class ProjectilesClip : MonoBehaviour
    {
        public ReactiveProperty<int> CurrentAmount { get; private set; } = new ReactiveProperty<int>();

        private void OnEnable()
        {
            Actions.BonusObstacleDestroyed += Add;
        }

        private void OnDisable()
        {
            Actions.BonusObstacleDestroyed -= Add;
        }

        private void Start()
        {
            CurrentAmount.Value = 10;
        }

        public void Add(int amount)
        {
            CurrentAmount.Value += amount;
        }

        public bool TryRemove(int amount)
        {
            if (CurrentAmount.Value - amount > 0)
            {
                CurrentAmount.Value -= amount;
                return true;
            }

            if (CurrentAmount.Value - amount <= 0)
            {
                CurrentAmount.Value -= amount;
                Actions.PlayerDead?.Invoke();
            }

            return false;
        }
    }
}