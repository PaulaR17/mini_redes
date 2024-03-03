using UnityEngine;

public class ExplodeOnContact : MonoBehaviour
{
    public GameObject explosionEffect; // Asigna un prefab de efecto de explosión si lo deseas

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Opcional: Instancia un efecto de explosión
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);
            }

            // Aquí puedes agregar efectos adicionales, como dañar al jugador.

            // Destruye el enemigo.
            Destroy(gameObject);
        }
    }
}