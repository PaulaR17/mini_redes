using UnityEngine;
using TMPro;
using System.Collections;

public class TimerController : MonoBehaviour
{
    public TMP_Text timerText; // Referencia al TextMeshPro UI
    public TMP_Text runToDoorText; // Texto para correr hacia la puerta
    public GameObject door; // La puerta que se mover�
    public float openPositionY; // La posici�n Y a la que la puerta debe moverse para "abrirse"
    public float doorOpenSpeed = 3f; // Velocidad a la que la puerta se abrir�
    public float startTime = 60f; // Tiempo inicial en segundos
    public PlayerHealth playerHealth;
    private float timeRemaining;
    private bool timerIsRunning = false;
    private bool doorIsOpening = false;

    private void Start()
    {
        // Inicializa el temporizador y aseg�rate de que el texto "�Corre hacia la puerta!" est� desactivado al inicio
        timeRemaining = startTime;
        timerIsRunning = false;
        runToDoorText.gameObject.SetActive(false); // Asegura que este texto est� desactivado al inicio
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

                // Comprueba si el temporizador ha llegado a 10 segundos y la puerta a�n no se ha empezado a abrir
                if (timeRemaining <= 10f && !doorIsOpening)
                {
                    doorIsOpening = true; // Evita que este bloque se ejecute m�s de una vez
                    StartCoroutine(OpenDoor());
                    runToDoorText.gameObject.SetActive(true); // Activa el texto "�Corre hacia la puerta!"
                }
            }
            else
            {
                Debug.Log("Tiempo terminado!");
                timeRemaining = 0;
                timerIsRunning = false;
                timerText.gameObject.SetActive(false); // Oculta el temporizador cuando termine
                runToDoorText.gameObject.SetActive(false); // Aseg�rate de ocultar tambi�n este texto

                // Aqu� es donde establecemos la salud del jugador a 0.
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(playerHealth.currentHealth);
                }
            }
        }
    }

    public void StartTimer()
    {
        if (!timerIsRunning)
        {
            timerIsRunning = true;
            timeRemaining = startTime;
            timerText.gameObject.SetActive(true); // Muestra el temporizador
            doorIsOpening = false; // Reinicia el estado de apertura de la puerta
            runToDoorText.gameObject.SetActive(false); // Aseg�rate de que este texto est� desactivado al inicio del temporizador
        }
    }

    IEnumerator OpenDoor()
    {
        // Mientras la puerta no est� en la posici�n abierta...
        while (door.transform.position.y != openPositionY)
        {
            // Mueve la puerta hacia la posici�n abierta
            Vector3 newPosition = door.transform.position;
            newPosition.y = Mathf.MoveTowards(door.transform.position.y, openPositionY, doorOpenSpeed * Time.deltaTime);
            door.transform.position = newPosition;

            yield return null; // Espera un frame antes de continuar
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}