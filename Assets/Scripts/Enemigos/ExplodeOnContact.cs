using UnityEngine;

public class ExplodeOnContact : MonoBehaviour
{
    public GameObject explosionEffect; // Prefab de efecto de explosi�n
    public int damage = 25; // La cantidad de da�o que causa la explosi�n

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Instancia un efecto de explosi�n, si tienes uno
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);
            }

            // Causa da�o al jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Destruye el enemigo despu�s de causar da�o
            Destroy(gameObject);
        }
    }
}