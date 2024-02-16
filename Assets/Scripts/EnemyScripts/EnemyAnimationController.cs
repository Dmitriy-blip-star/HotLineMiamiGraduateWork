using Assets.Scripts.Enemy;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Enemy _enemy;
    private EnemyWeapon _enemyWeapon;
    private EnemyHealth _enemyHealth;
    [SerializeField] private Animator _animator;

    private int _weaponID;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _enemyWeapon = GetComponent<EnemyWeapon>();
        _enemyHealth = GetComponent<EnemyHealth>();

        _weaponID = _enemyWeapon.WeaponID;
        _animator.SetInteger("weapons", _weaponID);
    }

    private void Update()
    {
        if (!_enemyHealth.isDead)
        {
            if (_enemy.MeshAgent.velocity.magnitude > 0.1f)
            {
                _animator.speed = 1;
            }
            else
            {
                _animator.speed = 0;
            }
        }
        else
        {
            _animator.speed = 1;
            _animator.SetBool("isDead", _enemyHealth.isDead);
        }
    }
}
