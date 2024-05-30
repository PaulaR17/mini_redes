using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject explosionEffect;
    public WaveSpawner waveSpawner;
    public AudioClip explosionSound;

    public void TakeDamage (float damage)
    {
        if(health > 0)
        {
            health -= damage;
            if (health <= 0) EnemyDeath();
            Debug.Log("Hit");
        }
        
    }

    void EnemyDeath()
    {
        SFXManager.instance.PlaySFXClip(explosionSound, transform, 1, false);
        explosionEffect.SetActive(true);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
        Debug.Log("Moritomuertomoritssimo");

        if (waveSpawner != null)
        {
            waveSpawner.EnemyDied(this.gameObject);
        }
    }

}
