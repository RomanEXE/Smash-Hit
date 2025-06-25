using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class EndGameUI : MonoBehaviour
    {
        [SerializeField] private Button restartBtn;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private GameObject panel;
        [SerializeField] private string winText;
        [SerializeField] private string looseText;

        private void OnEnable()
        {
            Actions.PlayerDead += OnGameLoose;
            Actions.FinishTriggered += OnGameWon;
            restartBtn.onClick.AddListener(Restart);
        }

        private void OnDisable()
        {
            Actions.PlayerDead -= OnGameLoose;
            Actions.FinishTriggered -= OnGameWon;
            restartBtn.onClick.RemoveListener(Restart);
        }
        
        private void OnGameWon()
        {
            text.text = winText;
            panel.SetActive(true);
        }

        private void OnGameLoose()
        {
            text.text = looseText;
            panel.SetActive(true);
        }

        private void Restart()
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }
    }
}