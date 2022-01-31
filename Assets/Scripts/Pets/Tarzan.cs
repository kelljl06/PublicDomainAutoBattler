using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Tarzan : Pets
{

    public int[] stats = new int[] { 1, 1, 9, 3 };

    public Tarzan() : base()
    {

        base.setID(stats[0]);
        base.setBaseATK(stats[1]);
        base.setBaseSPD(stats[2]);
        base.setBaseHP(stats[3]);


        base.setATK(base.getBaseATK());
        base.setSPD(base.getBaseSPD());
        base.setHP(base.getBaseHP());

        base.setPrefab("Pet_OBJ/Tarzan_Prefab");

    }

}
