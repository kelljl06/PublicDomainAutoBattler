using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    Winnie w1 = new Winnie();
    

    public void Start()
    {
        w1.getATK();
        //SPD_HUD.instance.spd = w1.getSPD();
        //ATK_HUD.instance.atk = w1.getATK();
        //HP_HUD.instance.hp = w1.getHP();
        Spawner.instance.createPet("Pet_OBJ/Winnie_Prefab");
    }


}
