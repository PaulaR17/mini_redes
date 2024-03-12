using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo a instanciar
    public Transform[] spawnPoints; // Array de puntos de spawn

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el objeto que activa el trigger es el jugador
        {
            SpawnEnemies();
            // Opcional: Desactivar el trigger si solo quieres que se active una vez
            gameObject.SetActive(false);
        }
    }

    void SpawnEnemies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}