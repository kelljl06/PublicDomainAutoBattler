using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Winnie : Pets
{

    public int[] stats = new int[] {1, 3, 1, 5};

    public Winnie() : base()
    {
        
        base.setID(stats[0]);
        base.setBaseATK(stats[1]);
        base.setBaseSPD(stats[2]);
        base.setBaseHP(stats[3]);

        base.setHP(base.getBaseHP());
        base.setATK(base.getBaseATK());
        base.setSPD(base.getBaseSPD());

        base.setPrefab("Pet_OBJ/Winnie_Prefab");

}

}
