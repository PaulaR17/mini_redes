using UnityEngine;
using TMPro; // Asegúrate de incluir este namespace para TextMeshPro

public class ButtonInteract : MonoBehaviour
{
    public static int buttonsPressed = 0;
    private bool isPlayerInRange = false;
    private bool isButtonPressed = false; 
    public TMP_Text promptText; 

    private void Start()
    {
        promptText.gameObject.SetActive(false); 
    }

    private void Update()
    {
        if (isPlayerInRange && !isButtonPressed && Input.GetKeyDown(KeyCode.E))
        {
            buttonsPressed++;
            isButtonPressed = true; 
            promptText.gameObject.SetActive(false); 
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (!isButtonPressed) 
            {
                promptText.gameObject.SetActive(true); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            promptText.gameObject.SetActive(false); 
        }
    }
}