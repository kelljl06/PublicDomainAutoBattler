using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Frankenstein : Pets
{

    public int[] stats = new int[] { 8, 3, 1, 7 };

    public Frankenstein() : base()
    {

        base.setID(stats[0]);
        base.setBaseATK(stats[1]);
        base.setBaseSPD(stats[2]);
        base.setBaseHP(stats[3]);


        base.setATK(base.getBaseATK());
        base.setSPD(base.getBaseSPD());
        base.setHP(base.getBaseHP());

        base.setPrefab("Pet_OBJ/Frankenstein_Prefab");

    }

    public override void onHit(Pets otherPet, List<Pets> alliedPets, List<Pets> opponentPets)
    {
        this.setHP(this.getHP() + this.getATK() + System.Math.Min(0,otherPet.getHP()));
        GameObject lifeSteal = Resources.Load("UI/LifeSteal") as GameObject;
        BattleHandler.instance.spawnObjectAbove(lifeSteal, this.visualEffect, setParent: true);
    }

}
