using UnityEngine;

namespace Utils
{
    public class Timer : MonoBehaviour
    {
        public float timeRemaining = 10;

        private void Update()
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
        }
    }
}