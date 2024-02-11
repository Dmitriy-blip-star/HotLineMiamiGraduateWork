using Assets.Scripts.Enemy;
using Assets.Scripts.GameManager;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class Presenter : MonoBehaviour
    {

        [SerializeField] TextMeshProUGUI healthText;
        [SerializeField] TextMeshProUGUI enemysText;
        [SerializeField] GameObject levelCompletePanel;
        [SerializeField] GameObject levelUI;
        [SerializeField] GameObject lossPanel;

        private void Update()
        {
            enemysText.text = $"{EnemyHealth.DeadEnemys}/{LevelController.StartEnemysOnLevel}";
            healthText.text = $"{PlayerHealth.health}%";

            if (LevelController.isLevelComplete)
            {
                levelUI.SetActive(false);
                levelCompletePanel.SetActive(true);
            }
            LossChecker();
        }

        private void LossChecker()
        {
            if (PlayerHealth.health <= 0)
            { 
                lossPanel.SetActive(true);

            }
        }

    }
}