using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto que ha entrado en el trigger es el jugador
        if (other.CompareTag("Player"))
        {
            // Destruye el objeto jugador
            Destroy(other.gameObject);
        }
    }
}