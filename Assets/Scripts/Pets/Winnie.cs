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

        
        base.setATK(base.getBaseATK());
        base.setSPD(base.getBaseSPD());
        base.setHP(base.getBaseHP());

        base.setPrefab("Pet_OBJ/Winnie_Prefab");

    }

    public override void onHit(Pets otherPet, List<Pets> alliedPets, List<Pets> opponentPets)
    {
        otherPet.setSPD(otherPet.getSPD() - 1);
        this.setSPD(this.getSPD() + 1);

        GameObject upArrow = Resources.Load("UI/UpArrowHoney") as GameObject;
        GameObject downArrow = Resources.Load("UI/DownArrowHoney") as GameObject;
        BattleHandler.instance.spawnObjectAbove(upArrow, this.visualEffect);
        BattleHandler.instance.spawnObjectAbove(downArrow, otherPet.visualEffect);
    }

}
