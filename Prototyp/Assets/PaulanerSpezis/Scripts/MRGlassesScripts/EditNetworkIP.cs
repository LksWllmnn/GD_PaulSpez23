using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EditNetworkIP : MonoBehaviour
{
    //[SerializeField] NetworkManager m_NetworkManager;
    [SerializeField] TMP_InputField text;

    public void OnClickConnect()
    {
        //m_NetworkManager.networkAddress = text.text;
        //m_NetworkManager.OnClientConnect();

        JoinAsServerOrClient.Instance.GiveValues(false, "192.168.8.1");
        SceneManager.LoadScene(1);
    }

    public void OnClickConnectServer()
    {

        //m_NetworkManager.networkAddress = text.text;
        //m_NetworkManager.StartServer();

        JoinAsServerOrClient.Instance.GiveValues(true, "192.168.8.1");
        SceneManager.LoadScene(1);
    }

    
}
