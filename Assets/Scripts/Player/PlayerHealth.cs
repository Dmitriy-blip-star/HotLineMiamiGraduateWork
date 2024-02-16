using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 10;
        public static int Health { get; private set; }
        private PlayerAnimationController _animator;


        private void Start()
        {
            Health = _maxHealth;
            _animator = GetComponent<PlayerAnimationController>();
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                _animator.DeadAnimation();
                Time.timeScale = 0;
                Destroy(GetComponent<PlayerHealth>());

            }
        }
    }
}