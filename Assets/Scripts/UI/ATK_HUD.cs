using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATK_HUD : MonoBehaviour
{

    private int atk = 7;
    public Text atkText;

    void Update()
    {
        atkText.text = atk.ToString();

        if (Input.GetKeyDown(KeyCode.Y))
            atk--;
    }

}
