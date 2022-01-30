using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    Pets[] roster = new Pets[5];
    

    private void Awake()
    {
        roster[0] = new Winnie();
        roster[1] = new NutCracker();
        roster[2] = new Winnie();
        roster[3] = new NutCracker();
        roster[4] = new Winnie();
    }
    

    public void Start()
    {
        Player_Spawner.instance.createPet(roster[0].getPrefab());
        Player_Spawner.instance.createPet(roster[1].getPrefab());
        Player_Spawner.instance.createPet(roster[2].getPrefab());
        Player_Spawner.instance.createPet(roster[3].getPrefab());
        Player_Spawner.instance.createPet(roster[4].getPrefab());


        Player_Spawner.instance.updateHP(roster[0]);
    }


}
