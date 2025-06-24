using Projectiles;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ProjectilesAmountUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currentAmountText;
        [SerializeField] private ProjectilesClip _projectilesClip;
        
        private void OnEnable()
        {
            _projectilesClip.CurrentAmount.OnChanged += CurrentAmountChanged;
        }
        
        private void OnDisable()
        {
            _projectilesClip.CurrentAmount.OnChanged -= CurrentAmountChanged;
        }

        private void CurrentAmountChanged(int value)
        {
            currentAmountText.text = value.ToString();
        }
    }
}