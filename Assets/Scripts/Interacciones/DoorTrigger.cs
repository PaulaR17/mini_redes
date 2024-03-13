using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject doorToDeactivate; // Arrastra aquí el GameObject de la puerta cerrada
    public GameObject doorToActivate; // Arrastra aquí el GameObject de la puerta abierta

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tiene el tag "Player"
        {
            doorToDeactivate.SetActive(false); // Desactiva la puerta "cerrada"
            doorToActivate.SetActive(true); // Activa la puerta "abierta"
        }
    }
}