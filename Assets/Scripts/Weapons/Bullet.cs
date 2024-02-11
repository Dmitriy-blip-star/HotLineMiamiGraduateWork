using Assets.Scripts.Enemy;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] float speed;
        Rigidbody2D rb;
        [HideInInspector] public int damage = 12;
        private void Start()
        {
            rb= GetComponent<Rigidbody2D>();
            Destroy(gameObject, 3);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.GetComponent<Bullet>() && !collision.GetComponent<WeaponManager>())
            {
                Destroy(gameObject);
                if (collision.GetComponent<EnemyHealth>())
                {
                    collision.GetComponent<EnemyHealth>().TakeDamage(damage);
                }
                if (collision.GetComponent<PlayerHealth>())
                {
                    collision.GetComponent<PlayerHealth>().TakeDamage(damage);
                }
            }
        }

        private void Update()
        {
            rb.velocity = transform.right * speed;
        }


    }
}