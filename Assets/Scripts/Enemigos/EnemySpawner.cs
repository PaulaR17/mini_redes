using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform spawnPoint;
    public int numberOfEnemies = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnEnemy();
            Destroy(gameObject);
        }
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Puedes ajustar la posición de spawn para cada enemigo si lo deseas
            Vector3 spawnPos = spawnPoint.position + new Vector3(i * 2, 0, 0); // Ajuste simple para evitar la superposición

            Instantiate(enemyPrefab, spawnPos, spawnPoint.rotation);
        }
    }
}