using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPD_HUD : MonoBehaviour
{
    public int spd;
    public Text spdText;

    public static SPD_HUD instance;
    public void Awake() => instance = this;

    void Update()
    {
        spdText.text = spd.ToString();
    }
}
