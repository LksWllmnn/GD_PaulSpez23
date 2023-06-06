using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectInfosHandler : MonoBehaviour
{
    [SerializeField]NetworkManager networkManager;
    
    // Start is called before the first frame update
    void Start()
    {
        JoinAsServerOrClient.Instance.GetInfos(this);
    }

    public void GetInfos(string ip, bool isServer)
    {
        Debug.Log("IP: " + ip + " | isServer: " +  isServer);
        networkManager.networkAddress = ip;
        if(isServer)
        {
            networkManager.StartServer();
        }
        else
        {
            networkManager.OnClientConnect();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
