using Assets.Scripts.Enemy;
using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rb;
        [HideInInspector] public int damage = 12;
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
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
            _rb.velocity = transform.right * _speed;
        }


    }
}