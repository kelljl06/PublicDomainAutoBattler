using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATK_HUD : MonoBehaviour
{
    public int atk;
    public Text atkText;

    public static ATK_HUD instance;
    public void Awake() => instance = this;

    void Update()
    {
        atkText.text = atk.ToString();
    }

}
