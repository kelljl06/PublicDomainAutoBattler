using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Bozo : Pets
{

    public int[] stats = new int[] { 7, 4, 3, 8 };

    public Bozo() : base()
    {

        base.setID(stats[0]);
        base.setBaseATK(stats[1]);
        base.setBaseSPD(stats[2]);
        base.setBaseHP(stats[3]);


        base.setATK(base.getBaseATK());
        base.setSPD(base.getBaseSPD());
        base.setHP(base.getBaseHP());

        base.setPrefab("Pet_OBJ/Bozo_Prefab");

    }

    

}
