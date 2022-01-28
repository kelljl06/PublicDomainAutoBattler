using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPD_HUD : MonoBehaviour
{

    private int spd = 7;
    public Text spdText;

    void Update()
    {
        spdText.text = spd.ToString();

        if (Input.GetKeyDown(KeyCode.Y))
            spd--;
    }
}
