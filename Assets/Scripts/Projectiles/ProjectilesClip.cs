using System;
using UnityEngine;

namespace Projectiles
{
    public class ProjectilesClip : MonoBehaviour
    {
        public ReactiveProperty<int> CurrentAmount { get; private set; } = new ReactiveProperty<int>();

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
            if (CurrentAmount.Value - amount >= 0)
            {
                CurrentAmount.Value -= amount;
                return true;
            }

            return false;
        }
    }
}