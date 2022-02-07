using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Jesus : Pets
{

    public int[] stats = new int[] { 5, 1, 1, 1 };
    public const int roundDeadLimit = 3;
    public int roundDeadCount = 0;
    public bool hasRespawned = false;

    public Jesus() : base()
    {

        base.setID(stats[0]);
        base.setBaseATK(stats[1]);
        base.setBaseSPD(stats[2]);
        base.setBaseHP(stats[3]);


        base.setATK(base.getBaseATK());
        base.setSPD(base.getBaseSPD());
        base.setHP(base.getBaseHP());

        base.setPrefab("Pet_OBJ/Jesus_Prefab");

    }

    public override void onSpawn(List<Pets> alliedPets, List<Pets> opponentPets)
    {
        alliedPets.Remove(this);
    }

    public override void onRoundStart(Pets pet, List<Pets> alliedPets, List<Pets> opponentPets)
    {
        this.roundDeadCount += 1;
        if (roundDeadCount >= 3 & !hasRespawned)
        {
            alliedPets.Add(this);
        }
    }



    public override void onAllyDeath(Pets pet, List<Pets> alliedPets, List<Pets> opponentPets)
    {
        this.setATK(this.getATK() + 2);
        this.setHP(this.getHP() + 2);
        GameObject cross = Resources.Load("UI/Cross") as GameObject;
        BattleHandler.instance.spawnObjectAbove(cross, this.visualEffect, setParent : true);

    }

}
