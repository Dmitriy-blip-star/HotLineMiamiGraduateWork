using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] int maxHealth = 10;
        public static int health { get; private set; }
        PlayerAnimationController animator;
       

        private void Start()
        {
            health = maxHealth;
            animator = GetComponent<PlayerAnimationController>();
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            
            if (health <= 0)
            {
                animator.DeadAnimation();
                Time.timeScale = 0;
                Destroy(GetComponent<PlayerHealth>());
                          
            }
        }
    }
}