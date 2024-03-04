using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healingAmount = 25; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Heal(healingAmount);
            }

            Destroy(gameObject); 
        }
    }
}