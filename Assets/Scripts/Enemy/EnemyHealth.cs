using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        int health;
        [SerializeField] int maxHealth;
        public bool isDead = false;
        public static int DeadEnemys = 0;

        private void Start()
        {
            health = maxHealth;
            DeadEnemys = 0;
        }

        public void TakeDamage(int damage)
        {
            if (!isDead)
            {
                health -= damage;
                if (health <= 0)
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