using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 movement = currentPosition - previousPosition;
        previousPosition = currentPosition;
    }


}
