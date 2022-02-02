using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public static Battle instance;

    public BattleHandler battleHandlerClass;

    public bool isPlayersTurn;
    public bool inTurn = false;

    public const int TIRED = 2;


    public void Awake() => instance = this;

    private void Start()
    {
        battleHandlerClass = GetComponent<BattleHandler>();
    }

    //Battles the two lineups
    public void battle(List<Pets> player, List<Pets> opponent)
    {
        //Save the two pets that will battle
        Pets pet1 = player[0];
        Pets pet2 = opponent[0];

        Player_Spawner.instance.createClash();


        //Check which pet is faster and have it hit first
        if (pet1.getSPD() != pet2.getSPD())
        {
            if (!inTurn)
            {
                if (pet1.getSPD() > pet2.getSPD())
                {
                    isPlayersTurn = true;

                }
                else if (pet1.getSPD() < pet2.getSPD())
                {
                    isPlayersTurn = false;
                }
                inTurn = true;
            }
            else
            {
                inTurn = false;
            }

            if (isPlayersTurn)
            {
                pet1.onPreHit(pet2, player, opponent);
                hit(pet1, pet2, true);
                pet1.onHit(pet2, player, opponent);
                pet2.onGetHit(pet1, opponent, player);
                isPlayersTurn = false;
            }
            else
            {
                pet2.onPreHit(pet1, opponent, player);
                hit(pet2, pet1, false);
                pet2.onHit(pet1, opponent, player);
                pet1.onGetHit(pet2, player, opponent);
                isPlayersTurn = true;

            }
        }
        else {
            pet1.onPreHit(pet2, player, opponent);
            pet2.onPreHit(pet1, opponent, player);
            mutualHit(pet1, pet2);
            pet1.onHit(pet2, player, opponent);
            pet2.onHit(pet1, opponent, player);
            pet1.onGetHit(pet2, player, opponent);
            pet2.onGetHit(pet1, opponent, player);
            inTurn = false;
        }
        if (checkDead(pet1, pet2))
        {
            inTurn = false;
            if (checkDead(pet1) && checkDead(pet2)) {
                return;
            }

            else if (checkDead(pet1)) {
                pet2.setSPD(pet2.getSPD() - TIRED);
            } 
            else if (checkDead(pet2)) {
                pet1.setSPD(pet1.getSPD() - TIRED);
            }
        }
            
        

    }



    //Remove HP equal to other pets attack
    public void hit(Pets pet1, Pets pet2, bool playerHit)
    {
        
        if (playerHit)
        {
            battleHandlerClass.playerHitAna();
        }
        else {
            battleHandlerClass.oppHitAna();
        }
        pet2.setHP(pet2.getHP() - pet1.getATK());   
    }

    //If hitting at the same time do both
    public void mutualHit(Pets pet1, Pets pet2)
    {

        pet2.setHP(pet2.getHP() - pet1.getATK());
        pet1.setHP(pet1.getHP() - pet2.getATK());

        battleHandlerClass.playerHitAna();
        battleHandlerClass.oppHitAna();
    }
     
    //If pet has 0 health set all stats to 0
    public bool checkDead(Pets pet1, Pets pet2)
    {
        return checkDead(pet1) | checkDead(pet2);
    }
    public bool checkDead(Pets pet1)
    {
        if (pet1.getHP() <= 0)
        {
            pet1.setATK(0);
            pet1.setHP(0);
            pet1.setSPD(0);            
            return true;
        }
        else
        {
            return false;
        }
    }
}