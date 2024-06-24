using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class MainMenuConexion : MonoBehaviour
{

    [SerializeField] private string startGameScene = "GameScene";
    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene(startGameScene, LoadSceneMode.Single);

    }

    public void StartClient()
    {
        NetworkManager.Singleton.StartClient();
        //Como es el cliente ya va a cambiar de escena automaticamente al conectarse 
    }
}
