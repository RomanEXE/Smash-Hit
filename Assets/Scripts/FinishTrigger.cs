using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class FinishTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.PLAYER))
            {
                Actions.FinishTriggered?.Invoke();
            }
        }
    }
}