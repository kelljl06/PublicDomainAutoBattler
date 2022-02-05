using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartCount : MonoBehaviour
{

    public Text heartCount;

    void Update()
    {
        heartCount.text = Player.instance.getHealth().ToString();
    }
}
