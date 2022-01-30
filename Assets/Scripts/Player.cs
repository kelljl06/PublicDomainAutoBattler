using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    Pets[] roster = new Pets[5];
    GameObject[] rosterOBJ = new GameObject[5];


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
        rosterOBJ[0]= Player_Spawner.instance.createPet(roster[0].getPrefab());
        rosterOBJ[1] = Player_Spawner.instance.createPet(roster[1].getPrefab());
        rosterOBJ[2] = Player_Spawner.instance.createPet(roster[2].getPrefab());
        rosterOBJ[3] = Player_Spawner.instance.createPet(roster[3].getPrefab());
        rosterOBJ[4] = Player_Spawner.instance.createPet(roster[4].getPrefab());

    }
    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            Player_Spawner.instance.updateHP(rosterOBJ[i], roster[i].getATK(), roster[i].getSPD(), roster[i].getHP());
        }
            
    }


}
