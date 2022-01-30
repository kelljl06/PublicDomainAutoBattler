using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class NutCracker : Pets
{

    public int[] stats = new int[] { 2, 4, 3, 2 };

    public NutCracker() : base()
    {

        base.setID(stats[0]);
        base.setBaseATK(stats[1]);
        base.setBaseSPD(stats[2]);
        base.setBaseHP(stats[3]);

        base.setHP(base.getBaseHP());
        base.setATK(base.getBaseATK());
        base.setSPD(base.getBaseSPD());

        base.setPrefab("Pet_OBJ/NutCracker_Prefab");

    }

}
