using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] GameObject explosionEffect;
    [SerializeField] int explosionDamage = 20; 
    public AudioClip explosionSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            Explode();
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(explosionDamage);
        }
    }

    public void Explode()
    {
        SFXManager.instance.PlaySFXClip(explosionSound, transform, 1, false);
        explosionEffect.SetActive(true);
        Instantiate(explosionEffect, transform.position, Quaternion.identity); 
        Destroy(gameObject); 
    }
}