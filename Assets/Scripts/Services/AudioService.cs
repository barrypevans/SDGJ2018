using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour
{
    static AudioService Instance;

    private void Awake()
    {
        if (null == Instance)
            Instance = this;
        else
        {
            Destroy(this);
        }

    }

}
