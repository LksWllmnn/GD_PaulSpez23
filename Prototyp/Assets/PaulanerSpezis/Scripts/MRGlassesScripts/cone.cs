using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cone : MonoBehaviour
{
    [SerializeField]
    EditNetworkIP EditNetworkIP = null;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Connect());
    }
    private IEnumerator Connect()
    {
        yield return new WaitForSeconds(5);EditNetworkIP.OnClickConnectServer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
