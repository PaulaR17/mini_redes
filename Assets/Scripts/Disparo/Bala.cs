using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Rigidbody BalaRB;
    public float velocidad;

   void Awake()
    {
        BalaRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Start ()
    {
        BalaRB.velocity = transform.forward * velocidad;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies") || collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject); 
        }
    }
}
