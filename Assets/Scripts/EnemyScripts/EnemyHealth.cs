using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour
    { 
        [SerializeField] private int _maxHealth;
        private int _health;
        public bool isDead = false;
        public static int DeadEnemys = 0;

        private void Start()
        {
            _health = _maxHealth;
            DeadEnemys = 0;
        }

        public void TakeDamage(int damage)
        {
            if (!isDead)
            {
                _health -= damage;
                if (_health <= 0)
                {
                    isDead = true;
                    DeadEnemys++;
                    CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();
                    circleCollider.enabled = false;
                }
            }
        }
    }
}