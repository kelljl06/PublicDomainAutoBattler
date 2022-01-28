using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    void Start()
    {
        Winnie winnie = new Winnie();
        //Pet_HUD HUD = new Pet_HUD();

        int HP = winnie.getHP();
        int ATK = winnie.getATK();
        int SPD = winnie.getSPD();

        //HUD.updateHPHUD(10);

        //HUD.updateHPHUD(HP);
        //HUD.updateATKHUD(ATK);
        //HUD.updateSPDHUD(SPD);
    }
}
