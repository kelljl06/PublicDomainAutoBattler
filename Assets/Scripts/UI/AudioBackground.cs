using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);  
    }
}
