using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Enemy
{
    public class EnemyOptionScript : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Transform[] _wayPoints;
        private int _pointInd = 0;

        public NavMeshAgent meshAgent;
        RaycastHit2D hit;

        private bool _targetIsClose = false;
        [SerializeField] private float _distanceDetected = 6;

        private void Start()
        {
            meshAgent= GetComponent<NavMeshAgent>();
            meshAgent.SetDestination(_wayPoints[_pointInd].position);

        }

        private void Update()
        {
            if (!_targetIsClose)
            {
                Movement();
            }
            DrawRay();
            PlayerDetected();
        }

        private void DrawRay()
        {
            Vector3 directional = _target.position - transform.position;
            hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(directional.x, directional.y));
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
                meshAgent.SetDestination(_wayPoints[_pointInd].position);
            }
        }

        private void PlayerDetected()
        {
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.GetComponent<PlayerMovement>() && hit.distance <= _distanceDetected)
                {
                    _targetIsClose = true;
                    meshAgent.SetDestination(_target.position);
                }
                else
                {
                    _targetIsClose = false;
                    meshAgent.SetDestination(_wayPoints[_pointInd].position);
                }
            }
            
        }
    }
}