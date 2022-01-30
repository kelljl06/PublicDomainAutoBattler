using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{


    Winnie pet1 = new Winnie();
    Winnie pet2 = new Winnie();


    // Start is called before the first frame update
    void Start()
    {
        pet1.setSPD(3);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Before: " + pet1.ToString() + " , " + pet2.ToString());
            if (checkDead(pet1) | checkDead(pet2))
            {
                return;
            }
            if (pet1.getSPD() > pet2.getSPD())
            {
                hit(pet1, pet2);
                if (checkDead(pet1) | checkDead(pet2))
                {
                    return;
                }
                hit(pet2, pet1);
            }
            else if (pet1.getSPD() < pet2.getSPD())
            {
                hit(pet2, pet1);
                if (checkDead(pet1) | checkDead(pet2))
                {
                    return;
                }
                hit(pet1, pet2);
            }
            else
            {
                mutualHit(pet1, pet2);
            }
            Debug.Log("After: " + pet1.ToString() + " , " + pet2.ToString());
        }
    }

    public void hit(Pets pet1, Pets pet2)
    {
        pet2.setHP(pet2.getHP() - pet1.getATK());   
    }

    public void mutualHit(Pets pet1, Pets pet2)
    {
        pet2.setHP(pet2.getHP() - pet1.getATK());
        pet1.setHP(pet1.getHP() - pet2.getATK());
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
