using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject doorToDeactivate; // Arrastra aqu� el GameObject de la puerta cerrada
    public GameObject doorToActivate; // Arrastra aqu� el GameObject de la puerta abierta

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Aseg�rate de que el jugador tiene el tag "Player"
        {
            doorToDeactivate.SetActive(false); // Desactiva la puerta "cerrada"
            doorToActivate.SetActive(true); // Activa la puerta "abierta"
        }
    }
}