using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Winnie : Pets
{

    public int[] stats = new int[] {1, 30, 10, 50};

    public Winnie() : base()
    {

        base.setID(stats[0]);
        base.setBaseHP(stats[1]);
        base.setBaseATK(stats[3]);
        base.setBaseSPD(stats[2]);
        
        base.setHP(base.getBaseHP());
        base.setATK(base.getBaseATK());
        base.setSPD(base.getBaseSPD());
    }
}
