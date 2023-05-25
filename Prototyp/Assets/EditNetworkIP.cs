using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditNetworkIP : MonoBehaviour
{
    [SerializeField] NetworkManager m_NetworkManager;
    [SerializeField] Text text;

    public void OnClickConnect()
    {
        m_NetworkManager.networkAddress = text.text;
        m_NetworkManager.OnClientConnect();
    }
}
