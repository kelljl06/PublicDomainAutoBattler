using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Death : Pets
{

    public int[] stats = new int[] { 6, 5, 0, 5 };
    public int attackCount = 0;
    public const int MAXATTACK = 2;


    public Death() : base()
    {

        base.setID(stats[0]);
        base.setBaseATK(stats[1]);
        base.setBaseSPD(stats[2]);
        base.setBaseHP(stats[3]);


        base.setATK(base.getBaseATK());
        base.setSPD(base.getBaseSPD());
        base.setHP(base.getBaseHP());

        base.setPrefab("Pet_OBJ/Death_Prefab");

    }

    
    public override void setHP(int pHP)
    {
        if (attackCount < MAXATTACK)
        {
            base.setHP(System.Math.Max(pHP, 1));
        }
        else
        {
            base.setHP(pHP);
        }
    }

    public override void onHit(Pets otherPet, List<Pets> alliedPets, List<Pets> opponentPets)
    {
        base.onHit(otherPet, alliedPets, opponentPets);
        attackCount += 1;
        if (attackCount >= MAXATTACK)
        {
            this.setHP(0);
        }
    }



}
