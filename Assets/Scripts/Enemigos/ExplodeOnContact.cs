using UnityEngine;

public class ExplodeOnContact : MonoBehaviour
{
    public GameObject explosionEffect; // Asigna un prefab de efecto de explosi�n si lo deseas

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Opcional: Instancia un efecto de explosi�n
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);
            }

            // Aqu� puedes agregar efectos adicionales, como da�ar al jugador.

            // Destruye el enemigo.
            Destroy(gameObject);
        }
    }
}