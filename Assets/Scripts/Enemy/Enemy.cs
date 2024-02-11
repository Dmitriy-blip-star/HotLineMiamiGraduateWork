using Assets.Scripts;
using Assets.Scripts.AudioManager;
using Assets.Scripts.Enemy;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] AudioManager _audioManager;
    private Transform _curentTarget;
    private int _pointInd = 0;

    public NavMeshAgent MeshAgent;
    RaycastHit2D hit;
    EnemyWeapon enemyWeapon;
    EnemyHealth enemyHealth;

    private bool _targetIsClose = false;
    [SerializeField] private float _distanceDetected = 6;
    [SerializeField] private float _shootDistance;
    
    int layerMask = 1 << 8;

    private void Start()
    {
        enemyWeapon = GetComponent<EnemyWeapon>();
        MeshAgent= GetComponent<NavMeshAgent>();
        enemyHealth= GetComponent<EnemyHealth>();

        MeshAgent.updateRotation = false;
        MeshAgent.updateUpAxis= false;

        layerMask = ~layerMask;
    }
    private void Update()
    {
        if (!enemyHealth.isDead)
        {
            if (!_targetIsClose)
            {
                Movement();
            }
            DrawRay();
            PlayerDetected();
            LookAt();
        }
        else
        {
            MeshAgent.enabled= false;
            _audioManager.StopShootAudio();
            enemyWeapon.DropWeapon(enemyWeapon.curentWeaponType);

        }
    }

    private void LookAt()
    {
        float angle = Mathf.Atan2(_curentTarget.position.y - transform.position.y, _curentTarget.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    private void DrawRay()
    {
        Vector3 directional = _target.position - transform.position;
        hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(directional.x, directional.y), 1000, layerMask);
        Debug.DrawRay(transform.position, directional, Color.red);
    }

    private void Movement()
    {
        if (Vector2.Distance(transform.position, _wayPoints[_pointInd].position) < .1f)
        {
            _pointInd++;
            if (_pointInd >= _wayPoints.Length)
            {
                _pointInd = 0;
            }
            _curentTarget= _wayPoints[_pointInd];
            MeshAgent.SetDestination(_curentTarget.position);
        }
    }

    private void PlayerDetected()
    {
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.GetComponent<PlayerHealth>() && hit.distance <= _distanceDetected)
            {
                _targetIsClose = true;
                _curentTarget = _target;
                MeshAgent.SetDestination(_curentTarget.position);

                if (hit.transform.gameObject.GetComponent<PlayerHealth>() && hit.distance <= _shootDistance)
                {
                    MeshAgent.SetDestination(transform.position);
                    enemyWeapon.AttackManager(enemyWeapon.Weapon);
                    if (!_audioManager.isShoot)
                    {
                        _audioManager.PlayShootAudio();
                    }
                }
                else
                {
                    enemyWeapon.shootLight.SetActive(false);
                    _audioManager.StopShootAudio();
                    Movement();
                }
            }
            else
            {
                _targetIsClose = false;
                _audioManager.StopShootAudio();
                _curentTarget = _wayPoints[_pointInd];
                MeshAgent.SetDestination(_curentTarget.position);
            }
        }

    }
}
