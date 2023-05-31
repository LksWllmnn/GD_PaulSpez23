using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinAsServerOrClient : MonoBehaviour
{
    private static JoinAsServerOrClient instance = null;

    public static JoinAsServerOrClient Instance { get { return instance; } }

    private bool _isServer = false;
    private string _iP = "localhost";

    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
    }

    public void GiveValues(bool isServer, string iP)
    {
        _isServer = isServer;
        _iP = iP;
    }

    public void GetInfos(ConnectInfosHandler handler)
    {
        handler.GetInfos(_iP, _isServer); 
    }


}
