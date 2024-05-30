using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
   private static CursorManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LockCursor();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
