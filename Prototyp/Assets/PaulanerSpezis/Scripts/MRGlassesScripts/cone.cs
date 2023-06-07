using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cone : MonoBehaviour
{
    [SerializeField] NetworkManager networkManager;
    [SerializeField] string _iP;
    void Start()
    {
        networkManager.networkAddress = _iP;
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {

            //networkManager.StartServer();
            networkManager.StartClient();
        } else
        {
            networkManager.StartClient();
        }
            
    }
}
