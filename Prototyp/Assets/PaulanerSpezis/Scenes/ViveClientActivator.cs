using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wave.Essence.Interaction.Mode;

public class ViveClientActivator : NetworkBehaviour
{
    [Header("Camera")]
    [SerializeField] GameObject ARCam;
    [Header("Interaction Mode Manager")]
    [SerializeField] InteractionModeManager InteractionModeManager;

    private void Start()
    {
        if (isLocalPlayer)
        {
            ARCam.SetActive(true);
            InteractionModeManager.enabled = true;
        }
    }
}
