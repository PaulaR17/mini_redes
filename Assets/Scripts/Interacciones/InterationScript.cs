using UnityEngine;
using TMPro; // Importa el namespace de TextMeshPro

public class InteractionScript : MonoBehaviour
{
    public TMP_Text interactionText_Timer; // El texto que aparece para indicar la interacción
    public TimerController timerController;
    public TMP_Text interactionText; // Cambia a usar TMP_Text en lugar de Text
    public WaveSpawner waveSpawner;

    private bool isPlayerNear = false;
    private bool hasBeenActivated = false;

    private void Start()
    {
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false); // Asegúrate de que el texto no se muestra al inicio
        }
    }

    private void Update()
    {
        if (isPlayerNear && !hasBeenActivated && Input.GetKeyDown(KeyCode.E))
        {
            hasBeenActivated = true;
            if (interactionText != null)
            {
                interactionText_Timer.gameObject.SetActive(false); // Oculta el texto de interacción
                timerController.StartTimer();
                interactionText.gameObject.SetActive(false); // Oculta el texto de interacción
            }
            waveSpawner.StartWaves(); // Inicia las oleadas y el temporizador en el otro script
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenActivated)
        {
            isPlayerNear = true;
            if (interactionText != null)
            {
                interactionText.gameObject.SetActive(true); // Muestra el texto de interacción
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (!hasBeenActivated && interactionText != null)
            {
                interactionText.gameObject.SetActive(false); // Oculta el texto si el jugador se aleja antes de activar el evento
            }
        }
    }
}