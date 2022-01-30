using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_HUD : MonoBehaviour
{
    public int hp;
    public Text hpText;

    public static HP_HUD instance;
    public void Awake() => instance = this;

    void Update()
    { 
        hpText.text = hp.ToString();
    }
}
