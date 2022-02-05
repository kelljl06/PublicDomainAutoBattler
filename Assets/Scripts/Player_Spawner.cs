using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player_Spawner : MonoBehaviour
{
    public GameObject pet;
    public static Player_Spawner instance;

    public void Awake() => instance = this;


    //Creates the 10 spots the pet can spawn on
    Vector3[] playerPositions = { new Vector3 { x = -1f, y = -2, z = 0 },
                            new Vector3 { x = -2.7f, y = -2, z = 0},
                            new Vector3 { x = -4.4f, y = -2, z = 0},
                            new Vector3 { x = -6.1f, y = -2, z = 0},
                            new Vector3 { x = -7.8f, y = -2, z = 0},
     };

    Vector3[] enemyPostitions = { new Vector3{ x = 1f, y = -2, z = 0 },
                            new Vector3 { x = 2.7f, y = -2, z = 0},
                            new Vector3 { x = 4.4f, y = -2, z = 0},
                            new Vector3 { x = 6.1f, y = -2, z = 0},
                            new Vector3 { x = 7.8f, y = -2, z = 0}

    };

    public int order = 0;
    public int playerOrder = 0;
    public int enemyOrder = 0;


    //This creates the hit picture
    public void createClash() {
        GameObject clashOBJ = Resources.Load("UI/HitImage") as GameObject;
        clashOBJ = Instantiate(clashOBJ, new Vector3(0, -2f, 0), transform.localRotation);
        StartCoroutine(deleteClash(.2f, clashOBJ));
    }

    //THis takes a name of a prefab from the pets class and turns it to an object
    public GameObject createPet(string name) {
        pet = Resources.Load(name) as GameObject;

        return Spawn(pet);
    }

    //This takes a pet OBJECT and puts it on the screen and returns the on screen object
    public GameObject Spawn(GameObject ppet) {

        GameObject tempPet;

        if (Player.instance.getHand().Count > order)
        {
            tempPet = Instantiate(ppet, playerPositions[playerOrder], transform.localRotation);
            playerOrder++;
        }
        else {
            tempPet = Instantiate(ppet, enemyPostitions[enemyOrder], transform.localRotation);
            tempPet.GetComponent<SpriteRenderer>().flipX = true;
            enemyOrder++;
        }

        order++;
        return tempPet;
    }

    //WHen this is called it will update the objects to have the stats of the class
    public void updateHP(GameObject charac, int ATK, int SPD, int HP)
    {
        Text[] test = charac.GetComponentsInChildren<Text>();
        test[0].text = ATK.ToString();
        test[1].text = SPD.ToString();
        test[2].text = HP.ToString();
    }


    //This will delete the clash img object after a certian amount of time
    public IEnumerator deleteClash(float time, GameObject clashOBJ)
    {
        
        yield return new WaitForSeconds(time);

        GameObject.Destroy(clashOBJ);
    }

}
