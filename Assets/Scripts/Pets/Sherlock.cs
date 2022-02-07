using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Sherlock : Pets
{

    public int[] stats = new int[] { 14, 5, 2, 8 };

    public Sherlock() : base()
    {

        base.setID(stats[0]);
        base.setBaseATK(stats[1]);
        base.setBaseSPD(stats[2]);
        base.setBaseHP(stats[3]);


        base.setATK(base.getBaseATK());
        base.setSPD(base.getBaseSPD());
        base.setHP(base.getBaseHP());

        base.setPrefab("Pet_OBJ/Sherlock_Prefab");

    }

}
