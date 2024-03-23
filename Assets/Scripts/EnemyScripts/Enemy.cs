using Assets.Scripts;
using Assets.Scripts.AudioManager;
using Assets.Scripts.Enemy;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("Follow settings")]
    [SerializeField] private PlayerHealth _target;
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _rotationSpeed;
    private Transform _curentTarget;
    private int _pointInd = 0;

    [Header("Detected settings")]
    [SerializeField] private float _distanceDetected = 6;
    [SerializeField] private float _shootDistance;
    private RaycastHit2D _hit;
    private bool _targetIsClose = false;
    private int _layerMask = 1 << 8;

    [Header("Audio")]
    [SerializeField] private AudioManager _audioManager;
    
    [HideInInspector] public NavMeshAgent MeshAgent;
    
    private EnemyWeapon _enemyWeapon;
    private EnemyHealth _enemyHealth;

    private void Start()
    {
        _enemyWeapon = GetComponent<EnemyWeapon>();
        MeshAgent = GetComponent<NavMeshAgent>();
        _enemyHealth = GetComponent<EnemyHealth>();

        MeshAgent.updateRotation = false;
        MeshAgent.updateUpAxis = false;

        _layerMask = ~_layerMask;
    }
    private void Update()
    {
        if (!_enemyHealth.isDead)
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
            MeshAgent.enabled = false;
            _audioManager.StopShootAudio();
            _enemyWeapon.DropWeapon(_enemyWeapon.CurrentWeaponType);

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
        Vector3 directional = _target.transform.position - transform.position;
        _hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(directional.x, directional.y), 1000, _layerMask);
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
            _curentTarget = _wayPoints[_pointInd];
            MeshAgent.SetDestination(_curentTarget.position);
        }
    }

    private void PlayerDetected()
    {
        if (_hit.collider != null)
        {
            if (_hit.transform.gameObject.GetComponent<PlayerHealth>() && _hit.distance <= _distanceDetected)
            {
                _targetIsClose = true;
                _curentTarget = _target.transform;
                MeshAgent.SetDestination(_curentTarget.position);

                if (_hit.transform.gameObject.GetComponent<PlayerHealth>() && _hit.distance <= _shootDistance)
                {
                    MeshAgent.SetDestination(transform.position);
                    _enemyWeapon.AttackManager(_enemyWeapon.WeaponID);
                    if (!_audioManager.isShoot)
                    {
                        _audioManager.PlayShootAudio();
                    }
                }
                else
                {
                    _enemyWeapon.ShootLight.SetActive(false);
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
