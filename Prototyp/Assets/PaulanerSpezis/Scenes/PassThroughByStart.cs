using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wave.Native;

public class PassThroughByStart : MonoBehaviour
{
    void Start()
    {
        Interop.WVR_ShowPassthroughUnderlay(true);
        Interop.WVR_SetPassthroughImageQuality(WVR_PassthroughImageQuality.QualityMode);
    }
}
