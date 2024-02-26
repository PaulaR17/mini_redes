using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; 
    private Vector3 distancia; 

    void Start()
    {
        
        distancia = transform.position - player.position;
    }

    void Update()
    {
        transform.position = player.position + distancia;
    }
}