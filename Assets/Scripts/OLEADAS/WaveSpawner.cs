using UnityEngine;
using System.Collections;
using System.Collections.Generic; // Necesitarás este namespace para usar listas

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array de prefabs de enemigos
    public Transform[] enemySpawnPoints; // Puntos de spawn de los enemigos
    public int[] enemiesPerWave; // Array de cantidades de enemigos por oleada
    public GameObject door; // La puerta que debe moverse
    public Transform doorOpenPosition; // La posición de apertura de la puerta
    public float doorOpenSpeed = 1f; // Velocidad de apertura de la puerta

    private float waveTimer = 60f; // Duración del temporizador de oleadas
    public int currentWave = 0; // Controla la oleada actual
    private bool wavesStarted = false;
    private List<GameObject> currentWaveEnemies = new List<GameObject>(); // Lista de enemigos de la oleada actual

    public void StartWaves()
    {
        if (!wavesStarted)
        {
            wavesStarted = true;
            StartCoroutine(SpawnWaves());
        }
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWave < enemiesPerWave.Length)
        {
            for (int i = 0; i < enemiesPerWave[currentWave]; i++)
            {
                int spawnPointIndex = i % enemySpawnPoints.Length; // Asegúrate de no exceder el número de spawn points
                GameObject enemy = Instantiate(enemyPrefabs[currentWave], enemySpawnPoints[spawnPointIndex].position, enemySpawnPoints[spawnPointIndex].rotation);
                enemy.GetComponent<EnemyHealth>().waveSpawner = this; // Asume que añades un campo público waveSpawner en EnemyHealth
                currentWaveEnemies.Add(enemy);
                yield return new WaitForSeconds(1f); // Espera un segundo antes de spawnear el siguiente enemigo (ajusta este tiempo como necesites)
            }

            yield return new WaitUntil(() => currentWaveEnemies.TrueForAll(e => e == null)); // Espera hasta que todos los enemigos hayan sido destruidos

            currentWave++;

            if (currentWave < enemiesPerWave.Length)
            {
                // Espera un tiempo antes de comenzar la siguiente oleada
                yield return new WaitForSeconds(10f); // Espera 10 segundos entre oleadas (ajusta este tiempo como necesites)
            }

            // A los 10 segundos finales, comienza a abrir la puerta
            if (waveTimer <= 10f)
            {
                StartCoroutine(OpenDoor());
                break; // Sal del bucle ya que no se necesitan más oleadas
            }
        }
    }

    private IEnumerator OpenDoor()
    {
        while (door.transform.position != doorOpenPosition.position)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorOpenPosition.position, doorOpenSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void Update()
    {
        if (wavesStarted)
        {
            if (waveTimer > 0)
            {
                waveTimer -= Time.deltaTime;
            }
            else
            {
                // El temporizador ha terminado y el jugador ha fallado en escapar a tiempo
                // Aquí puedes manejar lo que sucede si el temporizador se acaba, por ejemplo, terminar el juego o reiniciar el nivel
                wavesStarted = false;
            }

            currentWaveEnemies.RemoveAll(enemy => enemy == null); // Limpia la lista de cualquier enemigo que haya sido destruido

            // Comprueba si la puerta ya debería estar abriéndose
            if (waveTimer <= 10f && !doorOpening)
            {
                StartCoroutine(OpenDoor());
                doorOpening = true; // Asegúrate de no iniciar la corrutina varias veces
            }
        }
    }

    private bool doorOpening = false; // Para controlar la apertura de la puerta una sola vez

    // Llamado por cada enemigo cuando es derrotado
    public void EnemyDefeated(GameObject enemy)
    {
        currentWaveEnemies.Remove(enemy);
    }

    public void EnemyDied(GameObject enemy)
    {
        currentWaveEnemies.Remove(enemy);
        // Opcionalmente, aquí podrías verificar si todos los enemigos de la oleada actual han sido derrotados.
    }
}