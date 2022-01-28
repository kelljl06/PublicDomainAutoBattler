using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winnie : Pets
{
    public Winnie(int pID, int pHP, int pATK, int pSPD) : base(pID, pHP, pATK, pSPD)
    {
        base.setID(pID);
        base.setHP(pHP);
        base.setATK(pATK);
        base.setSPD(pSPD);
    }
}
