using Assets.Scripts.Enemy;
using Assets.Scripts.GameManager;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class PresenterGameUI : MonoBehaviour
    {
        [SerializeField] private Image _healthImage;

        [SerializeField] private TextMeshProUGUI _enemysText;
        [SerializeField] private TextMeshProUGUI _bulletsText;

        [SerializeField] private GameObject _levelCompletePanel;
        [SerializeField] private GameObject _levelUI;
        [SerializeField] private GameObject _lossPanel;

        [SerializeField] private PlayerWeaponManager _playerWeaponManger;

        private void Update()
        {
            _enemysText.text = $"{EnemyHealth.DeadEnemys}/{LevelController.StartEnemysOnLevel}";
            _healthImage.fillAmount = (float)PlayerHealth.Health / PlayerHealth.MaxHealth;
            _bulletsText.text = _playerWeaponManger.BulletInMagazine.ToString();

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