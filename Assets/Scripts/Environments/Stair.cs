using NavMeshPlus.Components;
using UnityEngine;

public class Stair : MonoBehaviour
{
    [SerializeField] Transform otherFloorSpawn;

    [SerializeField] GameObject currentFloor;
    [SerializeField] GameObject otherFloor;
    bool isActiveFloor = true;

    [SerializeField] NavMeshSurface navMeshSurface;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            collision.transform.position = otherFloorSpawn.position;
            currentFloor.SetActive(!isActiveFloor);
            otherFloor.SetActive(isActiveFloor);

        }
    }
}
