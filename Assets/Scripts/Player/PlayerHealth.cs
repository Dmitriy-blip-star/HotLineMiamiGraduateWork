using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] public static int MaxHealth { get; private set; } = 100;
        public static int Health { get; private set; }
        private PlayerAnimationController _animator;


        private void Start()
        {
            Health = MaxHealth;
            _animator = GetComponent<PlayerAnimationController>();
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                _animator.DeadAnimation();

                Destroy(GetComponent<PlayerHealth>());

            }
        }
    }
}