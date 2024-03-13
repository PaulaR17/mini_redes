using System.Collections;
using UnityEngine;

public class DoorMover : MonoBehaviour
{
    public float moveDistance = 3f; // La distancia que la puerta se mover� hacia arriba
    public float moveSpeed = 1f; // La velocidad a la que la puerta se mover�
    private float initialY; // Posici�n inicial en Y de la puerta
    private bool doorMoving = false; // Para controlar si la puerta est� en movimiento

    public int requiredButtonsPressed; // N�mero de botones que deben presionarse para que esta puerta se abra

    private void Start()
    {
        initialY = transform.position.y;
    }

    private void Update()
    {
        // Comprobar si el n�mero requerido de botones ha sido presionado
        if (ButtonInteract.buttonsPressed == requiredButtonsPressed && !doorMoving)
        {
            StartCoroutine(MoveDoor(initialY + moveDistance)); // Movemos la puerta hacia arriba para abrirla
        }
    }

    private IEnumerator MoveDoor(float targetY)
    {
        doorMoving = true;
        while (Mathf.Abs(transform.position.y - targetY) > 0.01f)
        {
            float newY = Mathf.Lerp(transform.position.y, targetY, Time.deltaTime * moveSpeed);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            yield return null;
        }
        doorMoving = false; // La puerta ha terminado de moverse
    }
}