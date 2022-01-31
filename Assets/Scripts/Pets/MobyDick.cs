using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MobyDick : Pets
{

    public int[] stats = new int[] { 1, 5, 1, 7 };

    public MobyDick() : base()
    {

        base.setID(stats[0]);
        base.setBaseATK(stats[1]);
        base.setBaseSPD(stats[2]);
        base.setBaseHP(stats[3]);


        base.setATK(base.getBaseATK());
        base.setSPD(base.getBaseSPD());
        base.setHP(base.getBaseHP());

        base.setPrefab("Pet_OBJ/MobyDick_Prefab");

    }

}
