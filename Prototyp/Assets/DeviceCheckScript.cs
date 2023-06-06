using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceCheckScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private GameObject _3DCanvas;
    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("HelloWindows");
        } else
        {
            _3DCanvas.SetActive(true);
        }
    }
}
