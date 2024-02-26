using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public Transform puntodedisparo;
    public GameObject bala;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Dispara();
        }
    }

    void Dispara()
    {
        Instantiate(bala, puntodedisparo.position, puntodedisparo.rotation);

    }
}
