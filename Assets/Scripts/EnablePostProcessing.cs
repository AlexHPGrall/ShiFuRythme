using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EnablePostProcessing : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;

    void Start()
    {
        if (postProcessVolume != null)
        {
            postProcessVolume.enabled = true;
        }
    }
}

