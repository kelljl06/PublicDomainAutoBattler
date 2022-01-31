using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public static Battle instance;

    public Player playerClass;

    public void Awake() => instance = this;

    private void Start()
    {
        playerClass = GetComponent<Player>();
    }

    //Battles the two lineups
    public void battle(List<Pets> player, List<Pets> opponent)
    {
        //Save the two pets that will battle
        Pets pet1 = player[0];
        Pets pet2 = opponent[0];

        Player_Spawner.instance.createClash();

        //Check which pet is faster and have it hit first
        if (pet1.getSPD() > pet2.getSPD())
        {
            hit(pet1, pet2, true);
            //Check so dead pet does not attack
            if (checkDead(pet1, pet2))
                return;
            hit(pet2, pet1, false);
            
        }
        else if (pet1.getSPD() < pet2.getSPD())
        {
            hit(pet2, pet1, false);
            //Check so dead pet does not attack
            if (checkDead(pet1, pet2))
                return;
            hit(pet1, pet2, true);
            
        }
        else
        {
            //Hit each other
            mutualHit(pet1, pet2);
            
        }

    }

    //Remove HP equal to other pets attack
    public void hit(Pets pet1, Pets pet2, bool playerHit)
    {
        
        if (playerHit)
        {
            playerClass.playerHitAna();
        }
        else {
            playerClass.oppHitAna();
        }
        pet2.setHP(pet2.getHP() - pet1.getATK());   
    }

    //If hitting at the same time do both
    public void mutualHit(Pets pet1, Pets pet2)
    {

        pet2.setHP(pet2.getHP() - pet1.getATK());
        pet1.setHP(pet1.getHP() - pet2.getATK());

        playerClass.playerHitAna();
        playerClass.oppHitAna();
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
            Debug.Log("This pet is dead");
            return true;
        }
        else
        {
            return false;
        }
    }
}