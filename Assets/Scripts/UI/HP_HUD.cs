using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HP_HUD : MonoBehaviour
{
    private int hp = 9;
    public Text hpText;

    void Update()
    {
        hpText.text = hp.ToString();

        if (Input.GetKeyDown(KeyCode.Y))
            hp--;  
    }
}
