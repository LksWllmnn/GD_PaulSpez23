using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivator : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject cam;
    void Start()
    {
        if(isLocalPlayer)
        {
            cam.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
