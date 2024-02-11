using Assets.Scripts.Enemy;
using UnityEngine;

public class LegacyBullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Start()
    {
        Destroy(gameObject, 5);
    }

    private void Update()
    {
        transform.Translate(new Vector2(_speed * Time.deltaTime, 0));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyOptionScript>())
        {
            Debug.Log("Hit Enemy");
        }

    }
}
