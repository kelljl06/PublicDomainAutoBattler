using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MobyDick : Pets
{

    public int[] stats = new int[] { 3, 5, 1, 7 };

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

    public override void onPreHit(Pets otherPet, List<Pets> alliedPets, List<Pets> opponentPets)
    {
        int rand = Random.Range(0, opponentPets.Count);
        opponentPets[rand].setHP(0);
        this.setHP(0);
        this.setATK(0);
        foreach (Pets pet in opponentPets)
        {
            pet.setSPD(pet.getSPD() - 1);
        }

        Vector3 startPos = this.visualEffect.transform.position;
        Vector3 grabPos = opponentPets[rand].visualEffect.transform.position;

        bool movingLeft = this.visualEffect.transform.position[0] > 0;


        BattleHandler.instance.waveAccrossStream(startPos, movingLeft);
        BattleHandler.instance.waveAccrossStream(grabPos, movingLeft);
    }



}
