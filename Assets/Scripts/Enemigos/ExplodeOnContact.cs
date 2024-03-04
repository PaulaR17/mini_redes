using UnityEngine;

public class ExplodeOnContact : MonoBehaviour
{
    public GameObject explosionEffect; // Prefab de efecto de explosión
    public int damage = 25; // La cantidad de daño que causa la explosión

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Instancia un efecto de explosión, si tienes uno
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect, transform.position, transform.rotation);
            }

            // Causa daño al jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Destruye el enemigo después de causar daño
            Destroy(gameObject);
        }
    }
}