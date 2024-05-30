using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public AimStateManager aimStateManager; 

    private bool Pausa = false;

    void Start()
    {
        ObjetoMenuPausa.SetActive(false);

        if (aimStateManager == null)
        {
            aimStateManager = FindObjectOfType<AimStateManager>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pausa)
            {
                Pausar();
            }
            else
            {
                Resumir();
            }
        }
    }

    public void Pausar()
    {
        ObjetoMenuPausa.SetActive(true);
        Pausa = true;
        Time.timeScale = 0;

        if (aimStateManager != null)
        {
            aimStateManager.enabled = false;
        }
    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        Pausa = false;
        Time.timeScale = 1;

        if (aimStateManager != null)
        {
            aimStateManager.enabled = true;
        }
    }

    public void IrAlMenu(string NombreMenu)
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(NombreMenu);
    }
}
