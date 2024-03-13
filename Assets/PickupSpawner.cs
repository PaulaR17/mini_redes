using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickupPrefabs; // Array de prefabs de pickups
    public Vector3 center; // Centro del área donde los pickups pueden aparecer
    public Vector3 size; // Tamaño del área (ancho, largo, alto)

    public float spawnTime = 5f; // Tiempo entre spawns

    private void Start()
    {
        // Empieza a generar pickups
        InvokeRepeating("SpawnPickup", spawnTime, spawnTime);
    }

    void SpawnPickup()
    {
        Vector3 spawnPosition = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        int pickupIndex = Random.Range(0, pickupPrefabs.Length);

        Instantiate(pickupPrefabs[pickupIndex], spawnPosition, Quaternion.identity);
    }

    // Opcional: Dibuja el área de spawn en el editor para facilitar el ajuste
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
