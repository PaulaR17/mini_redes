using UnityEngine;
using System.Collections; // Aseg�rate de incluir este namespace para usar corrutinas
using UnityEngine.UI; // Necesita este namespace para trabajar con elementos de UI

public class InteractionS : MonoBehaviour
{
    public GameObject objectToAnimate; // El objeto que quieres mover
    public Vector3 targetPosition; // La posici�n a la que quieres mover el objeto
    public float speed = 1f; // La velocidad de la animaci�n
    public GameObject interactionIndicator; // El elemento de UI que indica que puedes interactuar
    private bool isPlayerNear = false;
    private bool hasBeenActivated = false; // Controla si el bot�n ya ha sido activado

    void Update()
    {
        // Chequea si el jugador est� cerca, ha presionado la tecla E, y el bot�n no ha sido activado a�n
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E) && !hasBeenActivated)
        {
            StartCoroutine(MoveObject(objectToAnimate, targetPosition, speed));
            hasBeenActivated = true; // Asegura que no se pueda activar nuevamente
            interactionIndicator.SetActive(false); // Oculta el indicador de interacci�n una vez activado
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenActivated) // Solo muestra el indicador si no ha sido activado
        {
            interactionIndicator.SetActive(true);
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionIndicator.SetActive(false);
            isPlayerNear = false;
        }
    }

    IEnumerator MoveObject(GameObject obj, Vector3 target, float speed)
    {
        // Obtiene la posici�n inicial para mantener las coordenadas Y y Z constantes
        float startX = obj.transform.position.x;
        float targetX = target.x;
        Vector3 newPosition = obj.transform.position;

        // Calcula la distancia a recorrer
        float distance = Mathf.Abs(targetX - startX);
        if (distance == 0) yield break; // Si no hay distancia que recorrer, termina la corrutina

        float currentTime = 0; // Tiempo transcurrido desde el inicio del movimiento
        while (currentTime < distance / speed)
        {
            // Calcula la nueva posici�n X basada en la velocidad y el tiempo transcurrido
            currentTime += Time.deltaTime;
            float newX = Mathf.Lerp(startX, targetX, currentTime * speed / distance);
            newPosition.x = newX; // Actualiza solo la componente X de la nueva posici�n
            obj.transform.position = newPosition;

            yield return null; // Espera hasta el pr�ximo frame antes de continuar
        }

        // Asegura que la posici�n final es exactamente el objetivo en el eje X
        newPosition.x = targetX;
        obj.transform.position = newPosition;
    }
}
