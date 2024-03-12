using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float rotationSpeed = 5f;

    void Update()
    {
        // Mueve el enemigo hacia el jugador
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        // Calcula la direcci�n hacia el jugador
        Vector3 direction = (player.position - transform.position).normalized;

        // Calcula la rotaci�n deseada mirando hacia el jugador pero manteniendo el eje X en -90 grados
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotationEulerAngles = lookRotation.eulerAngles;
        rotationEulerAngles.x = -90; // Forza la rotaci�n en el eje X a -90 grados

        // Aplica la rotaci�n al enemigo
        transform.rotation = Quaternion.Euler(rotationEulerAngles);
    }
}
