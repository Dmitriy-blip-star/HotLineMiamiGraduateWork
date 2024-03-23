using UnityEngine;

public class MovePlayerCanvas : MonoBehaviour
{
    [SerializeField] Transform player;

    private void Update()
    {
        transform.position = player.position;
    }
}
