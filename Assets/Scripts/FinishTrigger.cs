using UnityEngine;
using Utils;

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