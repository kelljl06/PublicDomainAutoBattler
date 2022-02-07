using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnieVisual : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        Destroy(this);
    }

    void OnMouseOver()
    {
        Destroy(this);
    }

    void OnMouseExit()
    {
        Debug.Log("Remove Info");
    }
}
