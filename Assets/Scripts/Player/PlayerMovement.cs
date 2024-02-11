using UnityEngine;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _speed = 5f;

    private float _x, _y;

    private Vector2 _dir;

    public bool isMove = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_x == 0 && _y == 0)
        {
            isMove = false;
        }
        else
        {
            isMove = true;
        }

        Movement();
        Looking();        
    }

    private void Movement()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");
        _rb.velocity = new Vector2(_x, _y) * _speed;
    }

    private void Looking()
    {
        _dir = Input.mousePosition;
        _dir = Camera.main.ScreenToWorldPoint(_dir);
        _dir = _dir - (Vector2)transform.position;
        transform.right = _dir;
    }

}
