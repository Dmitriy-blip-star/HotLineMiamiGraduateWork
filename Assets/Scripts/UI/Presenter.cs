using Assets.Scripts.Enemy;
using Assets.Scripts.GameManager;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Presenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _enemysText;

        [SerializeField] private GameObject _levelCompletePanel;
        [SerializeField] private GameObject _levelUI;
        [SerializeField] private GameObject _lossPanel;

        private void Update()
        {
            _enemysText.text = $"{EnemyHealth.DeadEnemys}/{LevelController.StartEnemysOnLevel}";
            _healthText.text = $"{PlayerHealth.Health}%";

            if (LevelController.isLevelComplete)
            {
                _levelUI.SetActive(false);
                _levelCompletePanel.SetActive(true);
            }
            LossChecker();
        }

        private void LossChecker()
        {
            if (PlayerHealth.Health <= 0)
            {
                _lossPanel.SetActive(true);

            }
        }

    }
}