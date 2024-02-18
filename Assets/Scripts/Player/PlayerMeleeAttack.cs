using Assets.Scripts.Enemy;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    private float _cooldownAttack;
    [SerializeField] private float _timeBtwAttack;

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _attackRang;
    [SerializeField] private int _damage;
    [SerializeField] private Animator _anim;

    private void Update()
    {
        if (_cooldownAttack <= 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                _anim.SetTrigger("MeleeAttack");
                Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRang, _enemyLayer);

                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<EnemyHealth>().TakeDamage(_damage);
                }
            }
            _cooldownAttack = _timeBtwAttack;
        }
        else
        {
            _cooldownAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRang);
    }
}
