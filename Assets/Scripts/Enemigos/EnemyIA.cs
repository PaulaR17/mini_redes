using UnityEngine;
using UnityEngine.AI;

public class EnemyIA : MonoBehaviour
{
    public float speed = 5f;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        GetComponent<NavMeshAgent>().destination=playerTransform.position;
    }
}
